namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.bttnOpenFileDlg = new System.Windows.Forms.Button();
            this.bttnGo = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.txtTabStopped = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dateiname:";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(80, 28);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(639, 20);
            this.txtFileName.TabIndex = 1;
            this.txtFileName.Text = "S:\\Projekte\\Monega\\AIM\\Blommberg Feed Beschreibungen\\Trade Feed XMLSchema.xsd";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // bttnOpenFileDlg
            // 
            this.bttnOpenFileDlg.Location = new System.Drawing.Point(725, 28);
            this.bttnOpenFileDlg.Name = "bttnOpenFileDlg";
            this.bttnOpenFileDlg.Size = new System.Drawing.Size(26, 20);
            this.bttnOpenFileDlg.TabIndex = 2;
            this.bttnOpenFileDlg.Text = "...";
            this.bttnOpenFileDlg.UseVisualStyleBackColor = true;
            this.bttnOpenFileDlg.Click += new System.EventHandler(this.bttnOpenFileDlg_Click);
            // 
            // bttnGo
            // 
            this.bttnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttnGo.Location = new System.Drawing.Point(659, 511);
            this.bttnGo.Name = "bttnGo";
            this.bttnGo.Size = new System.Drawing.Size(93, 26);
            this.bttnGo.TabIndex = 3;
            this.bttnGo.Text = "Go";
            this.bttnGo.UseVisualStyleBackColor = true;
            this.bttnGo.Click += new System.EventHandler(this.bttnGo_Click);
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.Location = new System.Drawing.Point(12, 54);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(584, 451);
            this.txtLog.TabIndex = 4;
            // 
            // txtTabStopped
            // 
            this.txtTabStopped.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTabStopped.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTabStopped.Location = new System.Drawing.Point(602, 54);
            this.txtTabStopped.Multiline = true;
            this.txtTabStopped.Name = "txtTabStopped";
            this.txtTabStopped.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTabStopped.Size = new System.Drawing.Size(150, 451);
            this.txtTabStopped.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 549);
            this.Controls.Add(this.txtTabStopped);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.bttnGo);
            this.Controls.Add(this.bttnOpenFileDlg);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button bttnOpenFileDlg;
        private System.Windows.Forms.Button bttnGo;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.TextBox txtTabStopped;
    }
}

