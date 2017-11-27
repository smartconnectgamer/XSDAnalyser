using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bttnOpenFileDlg_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = txtFileName.Text;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = openFileDialog1.FileName;
            }

        }

        private void bttnGo_Click(object sender, EventArgs e)
        {
            var mySchema = XSDAdapter.Read(txtFileName.Text);

            mySchema.Compile(XSDAdapter.CompileCallback);

            sb = new StringBuilder();
            sbts = new StringBuilder();

            txtLog.Text = mySchema.Namespaces.Count.ToString() + "\r\n";
            txtTabStopped.Text = "";

            sb.Append(string.Format("Es sind {0} Elemente vorhanden:\r\n", mySchema.Elements.Count));

            foreach (XmlSchemaElement item in mySchema.Elements.Values)
            {
                OutputSchemaElement(item, 1);
            }

            txtLog.Text += sb.ToString();
            txtTabStopped.Text = sbts.ToString();
            sb.Clear();
            sbts.Clear();
        }

        private System.Text.StringBuilder sb;
        private System.Text.StringBuilder sbts;
        private void OutputSchemaElement(XmlSchemaElement Element, int indent)
        {
            string MaxOccurance = "";
            string Mandatory = "";
            string Typ = "";
            string DataType = "";
            string Length = "";
            string DecimalPlaces = "";
            string NodeText = "";
            string Pattern = "";
            string Enumeration = "";
            string Whitespace = "";

            XmlSchemaSimpleTypeRestriction Restriction;


            if (Element.MinOccurs == 1) Mandatory = "PFLICHTFELD: ";
            if (Element.MaxOccurs > 1) MaxOccurance = string.Format(" <-- {0} x WIEDERHOLUNGEN", Element.MaxOccurs);
            if (Element.ElementSchemaType.GetType() == typeof(XmlSchemaComplexType))
            {
                NodeText = string.Format("NODE: {0}", ((XmlSchemaComplexType)Element.ElementSchemaType).Name);
                Typ = NodeText;
            }
            else
            {
                DataType = string.Format("{0}", ((XmlSchemaSimpleType)Element.ElementSchemaType).Datatype.ValueType.Name);
                Typ = DataType;
                if ((((XmlSchemaSimpleType)Element.ElementSchemaType).Content).GetType() == typeof(XmlSchemaSimpleTypeRestriction))
                {
                    Restriction = (XmlSchemaSimpleTypeRestriction)((XmlSchemaSimpleType)Element.ElementSchemaType).Content;

                    foreach (XmlSchemaFacet facet in Restriction.Facets)
                    {
                        if (facet.GetType() == typeof(XmlSchemaTotalDigitsFacet) || facet.GetType() == typeof(XmlSchemaMaxLengthFacet))
                        {
                            Typ = string.Format("{0} ({1})", Typ, facet.Value);
                            Length = facet.Value;
                        }
                        else
                        {
                            if (facet.GetType() == typeof(XmlSchemaFractionDigitsFacet))
                            {
                                Typ = string.Format("{0}, (Fraction {1})", Typ, facet.Value);
                                DecimalPlaces = facet.Value;
                            }
                            else
                                if (facet.GetType() == typeof(XmlSchemaPatternFacet))
                            {
                                Typ = string.Format("{0} <{1}>", Typ, facet.Value);
                                Pattern = facet.Value;
                            }
                            else
                                if (facet.GetType() == typeof(XmlSchemaEnumerationFacet))
                            {
                                Typ = string.Format("{0} ENUM:{1}", Typ, facet.Value);
                                Enumeration += facet.Value + " , ";
                            }
                            else
                                if (facet.GetType() == typeof(XmlSchemaWhiteSpaceFacet))
                            {
                                Typ = string.Format("{0} WHITESPACE {1}", Typ, facet.Value);
                                Whitespace = facet.Value;
                            }
                            else
                                Typ = string.Format("{0} UNBEKANNTES FACET <{1}>", Typ, facet.GetType().Name);
                        }

                    }
                }

            }
            sb.Append(string.Format("{0} {1}{2}\r\n"
                                    , string.Format("{0}{1}{2}", " ".PadRight(indent * 4), Mandatory, Element.Name).PadRight(60)
                                    , Typ
                                    , MaxOccurance));

            sbts.Append("\t".PadRight(indent, "\t".ToCharArray()[0]));
            sbts.Append(Element.Name);
            sbts.Append("\t".PadRight(8 - indent, "\t".ToCharArray()[0]));
            if (Element.MinOccurs == 1) sbts.Append("Y"); else sbts.Append("N");
            sbts.Append("\t");
            if (Element.MaxOccurs > 1) sbts.Append(Element.MaxOccurs);
            sbts.Append("\t");
            sbts.Append(NodeText);
            sbts.Append("\t");
            sbts.Append(DataType);
            sbts.Append("\t");
            sbts.Append(Length);
            sbts.Append("\t");
            sbts.Append(DecimalPlaces);
            sbts.Append("\t");
            sbts.Append(Pattern);
            sbts.Append("\t");
            sbts.Append(Enumeration);
            sbts.Append("\t");
            sbts.Append(Whitespace);
            sbts.AppendLine();

            if (sb.Length > 10000)
            {
                txtLog.Text += sb.ToString();
                sb.Clear();
                Application.DoEvents();
            }
            ReportElement(Element, indent);

        }

        private void ReportElement(XmlSchemaElement Element, int indent)
        {
            XmlSchemaElement SL;
            XmlSchemaChoice SC;
            XmlSchemaComplexType SCT;

            indent += 1;
            if (Element.ElementSchemaType.GetType() == typeof(XmlSchemaComplexType))
            {
                SCT = (XmlSchemaComplexType)Element.ElementSchemaType;

                if (SCT.ContentTypeParticle.GetType() == typeof(XmlSchemaSequence))
                {
                    foreach (XmlSchemaObject item in ((XmlSchemaSequence)SCT.ContentTypeParticle).Items)
                    {
                        if (item.GetType() == typeof(XmlSchemaElement))
                        {
                            OutputSchemaElement((XmlSchemaElement)item, indent);
                        }
                        else
                        {
                            SC = (XmlSchemaChoice)item;
                            sb.Append(string.Format("{0} Anzahl={1}\r\n"
                                            , string.Format("{0}{1}{2}", " ".PadRight(indent * 4), "SCHEMA CHOISE: ", SC.GetType().Name).PadRight(60)
                                            , SC.Items.Count));

                            sbts.Append("\t".PadRight(indent, "\t".ToCharArray()[0]));
                            sbts.Append("###### SCHEMA CHOISE ######");
                            sbts.AppendLine();

                            foreach (var choise in SC.Items)
                            {
                                SL = (XmlSchemaElement)choise;

                                OutputSchemaElement(SL, indent + 2);
                                //sb.Append(string.Format("{0} Typ={1}\r\n"
                                //            , string.Format("{0}{1}{2}", " ".PadRight((indent + 2) * 4), "CHOISE: ", SL.Name).PadRight(60)
                                //            , SL.ElementSchemaType.Name));
                                //ReportElement(SL, indent + 2);
                            }
                        }
                    }
                }
                else
                {
                    if (SCT.BaseXmlSchemaType.GetType() == typeof(XmlSchemaSimpleType))
                    {
                        sb.Append(string.Format("{0}Element mit Simple ContentType: {1} Typ={2}\r\n", " ".PadRight(4 * indent), SCT.Name, SCT.BaseSchemaType.GetType().Name));

                        sbts.Append("\t".PadRight(indent, "\t".ToCharArray()[0]));
                        sbts.Append(SCT.Name);
                        sbts.Append("\t".PadRight(8 - indent, "\t".ToCharArray()[0]));
                        sbts.Append("\t");
                        if (Element.MaxOccurs > 1) sbts.Append(Element.MaxOccurs);
                        sbts.Append("\t");
                        sbts.Append("SIMPLE NODE");
                        sbts.Append("\t");
                        sbts.Append("String");
                        sbts.Append("\t");
                        sbts.AppendLine();


                        foreach (var item in ((XmlSchemaSimpleContentExtension)SCT.ContentModel.Content).Attributes)
                        {

                            sb.Append(string.Format("{0}Element ATTRIBUT: {1} \r\n", " ".PadRight(4 * (indent + 2)), ((XmlSchemaAttribute)item).Name));

                            sbts.Append("\t".PadRight(indent +2, "\t".ToCharArray()[0]));
                            sbts.Append(((XmlSchemaAttribute)item).Name);
                            sbts.Append("\t".PadRight(8 - (indent +2), "\t".ToCharArray()[0]));
                            sbts.AppendLine();

                        }
                    }
                    else
                        txtLog.Text += string.Format("{0}Element mit UNBEKANNTEM ContentType: {1} Typ={2}\r\n", " ".PadRight(4 * indent), SCT.Name, SCT.ContentTypeParticle.GetType().Name);
                }
            }
        }
    }
}
