namespace PhalanxAdmin
{
    partial class frmBaseConfigMailing
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lnkCuentaEnvioMail = new System.Windows.Forms.LinkLabel();
            this.lnkPlantillasMails = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pnlXPGrps)).BeginInit();
            this.pnlXPGrps.SuspendLayout();
            this.xppnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // xppnlMenu
            // 
            this.xppnlMenu.Caption = "Mailing";
            this.xppnlMenu.Controls.Add(this.lnkCuentaEnvioMail);
            this.xppnlMenu.Controls.Add(this.lnkPlantillasMails);
            this.xppnlMenu.ImageItems.ImageSet = null;
            // 
            // lnkCuentaEnvioMail
            // 
            this.lnkCuentaEnvioMail.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkCuentaEnvioMail.AutoSize = true;
            this.lnkCuentaEnvioMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.lnkCuentaEnvioMail.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkCuentaEnvioMail.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkCuentaEnvioMail.Location = new System.Drawing.Point(10, 48);
            this.lnkCuentaEnvioMail.Name = "lnkCuentaEnvioMail";
            this.lnkCuentaEnvioMail.Size = new System.Drawing.Size(152, 13);
            this.lnkCuentaEnvioMail.TabIndex = 24;
            this.lnkCuentaEnvioMail.TabStop = true;
            this.lnkCuentaEnvioMail.Text = "Cuenta de envío de mails";
            this.lnkCuentaEnvioMail.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkCuentaEnvioMail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCuentaEnvioMail_LinkClicked);
            // 
            // lnkPlantillasMails
            // 
            this.lnkPlantillasMails.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkPlantillasMails.AutoSize = true;
            this.lnkPlantillasMails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.lnkPlantillasMails.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkPlantillasMails.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkPlantillasMails.Location = new System.Drawing.Point(9, 69);
            this.lnkPlantillasMails.Name = "lnkPlantillasMails";
            this.lnkPlantillasMails.Size = new System.Drawing.Size(108, 13);
            this.lnkPlantillasMails.TabIndex = 25;
            this.lnkPlantillasMails.TabStop = true;
            this.lnkPlantillasMails.Text = "Plantillas de mails";
            this.lnkPlantillasMails.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkPlantillasMails.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPlantillasMails_LinkClicked);
            // 
            // frmBaseConfigMailing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1051, 581);
            this.ControlBox = false;
            this.Name = "frmBaseConfigMailing";
            this.Text = "Parametría de Mailing";
            this.Load += new System.EventHandler(this.frmBaseConfigMailing_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlXPGrps)).EndInit();
            this.pnlXPGrps.ResumeLayout(false);
            this.xppnlMenu.ResumeLayout(false);
            this.xppnlMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.LinkLabel lnkCuentaEnvioMail;
        protected System.Windows.Forms.LinkLabel lnkPlantillasMails;
    }
}
