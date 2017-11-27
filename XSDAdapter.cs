using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Schema;


class XSDAdapter
{
    public static XmlSchema Read(string Filename)
    {
        try
        {
            XmlTextReader reader = new XmlTextReader(Filename);
            XmlSchema myschema = XmlSchema.Read(reader, ValidationCallback);

            return myschema;

            /* myschema.Write(Console.Out);
            FileStream file = new FileStream("new.xsd", FileMode.Create, FileAccess.ReadWrite);
            XmlTextWriter xwriter = new XmlTextWriter(file, new UTF8Encoding());
            xwriter.Formatting = Formatting.Indented;
            myschema.Write(xwriter);
            */ 
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw e;
        }
    }

    static void ValidationCallback(object sender, ValidationEventArgs args)
    {
        if (args.Severity == XmlSeverityType.Warning)
            Console.Write("WARNING: ");
        else if (args.Severity == XmlSeverityType.Error)
            Console.Write("ERROR: ");

        Console.WriteLine(args.Message);

    }


    public static void CompileCallback(object sender, ValidationEventArgs args)
    {
        if (args.Severity == XmlSeverityType.Warning)
            Console.Write("WARNING: ");
        else if (args.Severity == XmlSeverityType.Error)
            System.Diagnostics.Debug.WriteLine("ERROR: " + args.Message);

        Console.WriteLine(args.Message);

    }
}
