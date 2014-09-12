namespace PhalanxAdmin
{
    partial class FBaseAuditoria
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
            this.lnkLogPwdChg = new System.Windows.Forms.LinkLabel();
            this.lnkMailsAlert = new System.Windows.Forms.LinkLabel();
            this.lnkHistPwd = new System.Windows.Forms.LinkLabel();
            this.lnkLogueos = new System.Windows.Forms.LinkLabel();
            this.lnkDepuracionLogs = new System.Windows.Forms.LinkLabel();
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
            this.xppnlMenu.Caption = "Auditoria";
            this.xppnlMenu.Controls.Add(this.lnkDepuracionLogs);
            this.xppnlMenu.Controls.Add(this.lnkLogueos);
            this.xppnlMenu.Controls.Add(this.lnkLogPwdChg);
            this.xppnlMenu.Controls.Add(this.lnkMailsAlert);
            this.xppnlMenu.Controls.Add(this.lnkHistPwd);
            this.xppnlMenu.ImageItems.ImageSet = null;
            this.xppnlMenu.Size = new System.Drawing.Size(184, 174);
            // 
            // lnkLogPwdChg
            // 
            this.lnkLogPwdChg.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkLogPwdChg.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkLogPwdChg.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkLogPwdChg.Location = new System.Drawing.Point(18, 46);
            this.lnkLogPwdChg.Name = "lnkLogPwdChg";
            this.lnkLogPwdChg.Size = new System.Drawing.Size(128, 31);
            this.lnkLogPwdChg.TabIndex = 18;
            this.lnkLogPwdChg.TabStop = true;
            this.lnkLogPwdChg.Text = "Log de Moficación de Contraseñas";
            this.lnkLogPwdChg.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkLogPwdChg.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLogPwdChg_LinkClicked);
            // 
            // lnkMailsAlert
            // 
            this.lnkMailsAlert.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkMailsAlert.AutoSize = true;
            this.lnkMailsAlert.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkMailsAlert.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkMailsAlert.Location = new System.Drawing.Point(18, 78);
            this.lnkMailsAlert.Name = "lnkMailsAlert";
            this.lnkMailsAlert.Size = new System.Drawing.Size(131, 13);
            this.lnkMailsAlert.TabIndex = 19;
            this.lnkMailsAlert.TabStop = true;
            this.lnkMailsAlert.Text = "Mails y Notificaciones";
            this.lnkMailsAlert.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkMailsAlert.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkMailsAlert_LinkClicked);
            // 
            // lnkHistPwd
            // 
            this.lnkHistPwd.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkHistPwd.AutoSize = true;
            this.lnkHistPwd.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkHistPwd.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkHistPwd.Location = new System.Drawing.Point(18, 99);
            this.lnkHistPwd.Name = "lnkHistPwd";
            this.lnkHistPwd.Size = new System.Drawing.Size(148, 13);
            this.lnkHistPwd.TabIndex = 20;
            this.lnkHistPwd.TabStop = true;
            this.lnkHistPwd.Text = "Histórico de contraseñas";
            this.lnkHistPwd.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkHistPwd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkHistPwd_LinkClicked_1);
            this.lnkHistPwd.Click += new System.EventHandler(this.lnkHistPwd_Click);
            // 
            // lnkLogueos
            // 
            this.lnkLogueos.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkLogueos.AutoSize = true;
            this.lnkLogueos.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkLogueos.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkLogueos.Location = new System.Drawing.Point(18, 120);
            this.lnkLogueos.Name = "lnkLogueos";
            this.lnkLogueos.Size = new System.Drawing.Size(55, 13);
            this.lnkLogueos.TabIndex = 23;
            this.lnkLogueos.TabStop = true;
            this.lnkLogueos.Text = "Logueos";
            this.lnkLogueos.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkLogueos.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLogueos_LinkClicked);
            // 
            // lnkDepuracionLogs
            // 
            this.lnkDepuracionLogs.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkDepuracionLogs.AutoSize = true;
            this.lnkDepuracionLogs.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkDepuracionLogs.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkDepuracionLogs.Location = new System.Drawing.Point(18, 142);
            this.lnkDepuracionLogs.Name = "lnkDepuracionLogs";
            this.lnkDepuracionLogs.Size = new System.Drawing.Size(121, 13);
            this.lnkDepuracionLogs.TabIndex = 24;
            this.lnkDepuracionLogs.TabStop = true;
            this.lnkDepuracionLogs.Text = "Depuración de Logs";
            this.lnkDepuracionLogs.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkDepuracionLogs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDepuracionLogs_LinkClicked);
            // 
            // FBaseAuditoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(539, 522);
            this.Name = "FBaseAuditoria";
            this.Load += new System.EventHandler(this.FBaseAuditoria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlXPGrps)).EndInit();
            this.pnlXPGrps.ResumeLayout(false);
            this.pnlIzq.ResumeLayout(false);
            this.xppnlMenu.ResumeLayout(false);
            this.xppnlMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnkLogPwdChg;
        private System.Windows.Forms.LinkLabel lnkMailsAlert;
        private System.Windows.Forms.LinkLabel lnkHistPwd;
        private System.Windows.Forms.LinkLabel lnkLogueos;
        private System.Windows.Forms.LinkLabel lnkDepuracionLogs;
    }
}
