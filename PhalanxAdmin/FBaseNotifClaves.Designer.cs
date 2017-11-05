namespace PhalanxAdmin
{
    partial class FBaseNotifClaves
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
            this.linkNotifBlanqueos = new System.Windows.Forms.LinkLabel();
            this.linkNotifBlanqueosTC = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pnlXPGrps)).BeginInit();
            this.pnlXPGrps.SuspendLayout();
            this.pnlIzq.SuspendLayout();
            this.xppnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlXPGrps
            // 
            this.pnlXPGrps.Size = new System.Drawing.Size(200, 522);
            // 
            // pnlIzq
            // 
            this.pnlIzq.Size = new System.Drawing.Size(200, 522);
            // 
            // xppnlMenu
            // 
            this.xppnlMenu.Caption = "Notificaciones";
            this.xppnlMenu.Controls.Add(this.linkNotifBlanqueosTC);
            this.xppnlMenu.Controls.Add(this.linkNotifBlanqueos);
            this.xppnlMenu.ImageItems.ImageSet = null;
            this.xppnlMenu.Size = new System.Drawing.Size(184, 195);
            // 
            // linkNotifBlanqueos
            // 
            this.linkNotifBlanqueos.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.linkNotifBlanqueos.AutoSize = true;
            this.linkNotifBlanqueos.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkNotifBlanqueos.LinkColor = System.Drawing.Color.MidnightBlue;
            this.linkNotifBlanqueos.Location = new System.Drawing.Point(18, 45);
            this.linkNotifBlanqueos.Name = "linkNotifBlanqueos";
            this.linkNotifBlanqueos.Size = new System.Drawing.Size(111, 13);
            this.linkNotifBlanqueos.TabIndex = 30;
            this.linkNotifBlanqueos.TabStop = true;
            this.linkNotifBlanqueos.Text = "Blanqueos de Red";
            this.linkNotifBlanqueos.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.linkNotifBlanqueos.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkNotifBlanqueos_LinkClicked);
            // 
            // linkNotifBlanqueosTC
            // 
            this.linkNotifBlanqueosTC.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.linkNotifBlanqueosTC.AutoSize = true;
            this.linkNotifBlanqueosTC.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkNotifBlanqueosTC.LinkColor = System.Drawing.Color.MidnightBlue;
            this.linkNotifBlanqueosTC.Location = new System.Drawing.Point(18, 67);
            this.linkNotifBlanqueosTC.Name = "linkNotifBlanqueosTC";
            this.linkNotifBlanqueosTC.Size = new System.Drawing.Size(148, 13);
            this.linkNotifBlanqueosTC.TabIndex = 31;
            this.linkNotifBlanqueosTC.TabStop = true;
            this.linkNotifBlanqueosTC.Text = "Blanqueos de Tarj. Cred.";
            this.linkNotifBlanqueosTC.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.linkNotifBlanqueosTC.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkNotifBlanqueosTC_LinkClicked);
            // 
            // FBaseNotifClaves
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(539, 522);
            this.Name = "FBaseNotifClaves";
            this.Load += new System.EventHandler(this.FBaseNotifClaves_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlXPGrps)).EndInit();
            this.pnlXPGrps.ResumeLayout(false);
            this.pnlIzq.ResumeLayout(false);
            this.xppnlMenu.ResumeLayout(false);
            this.xppnlMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkNotifBlanqueos;
        private System.Windows.Forms.LinkLabel linkNotifBlanqueosTC;


    }
}
