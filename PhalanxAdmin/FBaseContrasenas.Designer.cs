namespace PhalanxAdmin
{
    partial class FBaseContrasenas
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
            this.lnkAppPwd = new System.Windows.Forms.LinkLabel();
            this.lnkDBPwd = new System.Windows.Forms.LinkLabel();
            this.lnkWinPwd = new System.Windows.Forms.LinkLabel();
            this.lnkUnixPwd = new System.Windows.Forms.LinkLabel();
            this.lnkAS400Pwd = new System.Windows.Forms.LinkLabel();
            this.pnlchk = new UIComponents.XPPanel(139);
            this.lnkChkWin = new System.Windows.Forms.LinkLabel();
            this.linkEcPwd = new System.Windows.Forms.LinkLabel();
            this.lnkATMPwd = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pnlXPGrps)).BeginInit();
            this.pnlXPGrps.SuspendLayout();
            this.pnlIzq.SuspendLayout();
            this.xppnlMenu.SuspendLayout();
            this.pnlchk.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlXPGrps
            // 
            this.pnlXPGrps.Controls.Add(this.pnlchk);
            this.pnlXPGrps.Size = new System.Drawing.Size(200, 486);
            this.pnlXPGrps.Controls.SetChildIndex(this.xppnlMenu, 0);
            this.pnlXPGrps.Controls.SetChildIndex(this.pnlchk, 0);
            // 
            // pnlIzq
            // 
            this.pnlIzq.Size = new System.Drawing.Size(200, 486);
            // 
            // xppnlMenu
            // 
            this.xppnlMenu.Caption = "Contraseñas";
            this.xppnlMenu.Controls.Add(this.lnkATMPwd);
            this.xppnlMenu.Controls.Add(this.linkEcPwd);
            this.xppnlMenu.Controls.Add(this.lnkAS400Pwd);
            this.xppnlMenu.Controls.Add(this.lnkAppPwd);
            this.xppnlMenu.Controls.Add(this.lnkDBPwd);
            this.xppnlMenu.Controls.Add(this.lnkWinPwd);
            this.xppnlMenu.Controls.Add(this.lnkUnixPwd);
            this.xppnlMenu.ImageItems.ImageSet = null;
            this.xppnlMenu.Location = new System.Drawing.Point(8, 155);
            this.xppnlMenu.Size = new System.Drawing.Size(184, 200);
            // 
            // lnkAppPwd
            // 
            this.lnkAppPwd.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkAppPwd.AutoSize = true;
            this.lnkAppPwd.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkAppPwd.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkAppPwd.Location = new System.Drawing.Point(18, 129);
            this.lnkAppPwd.Name = "lnkAppPwd";
            this.lnkAppPwd.Size = new System.Drawing.Size(69, 13);
            this.lnkAppPwd.TabIndex = 10;
            this.lnkAppPwd.TabStop = true;
            this.lnkAppPwd.Text = "Aplicativos";
            this.lnkAppPwd.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkAppPwd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAppPwd_LinkClicked);
            // 
            // lnkDBPwd
            // 
            this.lnkDBPwd.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkDBPwd.AutoSize = true;
            this.lnkDBPwd.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkDBPwd.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkDBPwd.Location = new System.Drawing.Point(18, 108);
            this.lnkDBPwd.Name = "lnkDBPwd";
            this.lnkDBPwd.Size = new System.Drawing.Size(96, 13);
            this.lnkDBPwd.TabIndex = 9;
            this.lnkDBPwd.TabStop = true;
            this.lnkDBPwd.Text = "Bases de Datos";
            this.lnkDBPwd.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkDBPwd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDBPwd_LinkClicked);
            // 
            // lnkWinPwd
            // 
            this.lnkWinPwd.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkWinPwd.AutoSize = true;
            this.lnkWinPwd.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkWinPwd.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkWinPwd.Location = new System.Drawing.Point(18, 45);
            this.lnkWinPwd.Name = "lnkWinPwd";
            this.lnkWinPwd.Size = new System.Drawing.Size(58, 13);
            this.lnkWinPwd.TabIndex = 8;
            this.lnkWinPwd.TabStop = true;
            this.lnkWinPwd.Text = "Windows";
            this.lnkWinPwd.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkWinPwd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkWinPwd_LinkClicked);
            // 
            // lnkUnixPwd
            // 
            this.lnkUnixPwd.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkUnixPwd.AutoSize = true;
            this.lnkUnixPwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkUnixPwd.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkUnixPwd.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkUnixPwd.Location = new System.Drawing.Point(18, 66);
            this.lnkUnixPwd.Name = "lnkUnixPwd";
            this.lnkUnixPwd.Size = new System.Drawing.Size(32, 13);
            this.lnkUnixPwd.TabIndex = 7;
            this.lnkUnixPwd.TabStop = true;
            this.lnkUnixPwd.Text = "Unix";
            this.lnkUnixPwd.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkUnixPwd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkUnixPwd_LinkClicked);
            // 
            // lnkAS400Pwd
            // 
            this.lnkAS400Pwd.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkAS400Pwd.AutoSize = true;
            this.lnkAS400Pwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkAS400Pwd.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkAS400Pwd.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkAS400Pwd.Location = new System.Drawing.Point(18, 87);
            this.lnkAS400Pwd.Name = "lnkAS400Pwd";
            this.lnkAS400Pwd.Size = new System.Drawing.Size(44, 13);
            this.lnkAS400Pwd.TabIndex = 13;
            this.lnkAS400Pwd.TabStop = true;
            this.lnkAS400Pwd.Text = "AS400";
            this.lnkAS400Pwd.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkAS400Pwd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAS400Pwd_LinkClicked);
            // 
            // pnlchk
            // 
            this.pnlchk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlchk.BackColor = System.Drawing.Color.Transparent;
            this.pnlchk.Caption = "Chequeos";
            this.pnlchk.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.pnlchk.CaptionGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
            this.pnlchk.CaptionGradient.Start = System.Drawing.Color.White;
            this.pnlchk.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.pnlchk.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlchk.Controls.Add(this.lnkChkWin);
            this.pnlchk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.pnlchk.ForeColor = System.Drawing.SystemColors.WindowText;
            this.pnlchk.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.pnlchk.ImageItems.ImageSet = null;
            this.pnlchk.Location = new System.Drawing.Point(8, 8);
            this.pnlchk.Name = "pnlchk";
            this.pnlchk.PanelGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.pnlchk.PanelGradient.Start = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.pnlchk.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.pnlchk.Size = new System.Drawing.Size(184, 139);
            this.pnlchk.TabIndex = 1;
            this.pnlchk.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.pnlchk.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.pnlchk.VertAlignment = System.Drawing.StringAlignment.Center;
            this.pnlchk.Visible = false;
            // 
            // lnkChkWin
            // 
            this.lnkChkWin.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkChkWin.AutoSize = true;
            this.lnkChkWin.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkChkWin.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkChkWin.Location = new System.Drawing.Point(18, 47);
            this.lnkChkWin.Name = "lnkChkWin";
            this.lnkChkWin.Size = new System.Drawing.Size(58, 13);
            this.lnkChkWin.TabIndex = 9;
            this.lnkChkWin.TabStop = true;
            this.lnkChkWin.Text = "Windows";
            this.lnkChkWin.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkChkWin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkChkWin_LinkClicked);
            // 
            // linkEcPwd
            // 
            this.linkEcPwd.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.linkEcPwd.AutoSize = true;
            this.linkEcPwd.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkEcPwd.LinkColor = System.Drawing.Color.MidnightBlue;
            this.linkEcPwd.Location = new System.Drawing.Point(18, 151);
            this.linkEcPwd.Name = "linkEcPwd";
            this.linkEcPwd.Size = new System.Drawing.Size(153, 13);
            this.linkEcPwd.TabIndex = 14;
            this.linkEcPwd.TabStop = true;
            this.linkEcPwd.Text = "Equipos de Comunicación";
            this.linkEcPwd.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.linkEcPwd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkEcPwd_LinkClicked);
            // 
            // lnkATMPwd
            // 
            this.lnkATMPwd.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkATMPwd.AutoSize = true;
            this.lnkATMPwd.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkATMPwd.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkATMPwd.Location = new System.Drawing.Point(18, 173);
            this.lnkATMPwd.Name = "lnkATMPwd";
            this.lnkATMPwd.Size = new System.Drawing.Size(39, 13);
            this.lnkATMPwd.TabIndex = 15;
            this.lnkATMPwd.TabStop = true;
            this.lnkATMPwd.Text = "ATMs";
            this.lnkATMPwd.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkATMPwd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkATMPwd_LinkClicked);
            // 
            // FBaseContrasenas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(727, 486);
            this.Name = "FBaseContrasenas";
            this.Load += new System.EventHandler(this.FBaseContrasenas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlXPGrps)).EndInit();
            this.pnlXPGrps.ResumeLayout(false);
            this.pnlIzq.ResumeLayout(false);
            this.xppnlMenu.ResumeLayout(false);
            this.xppnlMenu.PerformLayout();
            this.pnlchk.ResumeLayout(false);
            this.pnlchk.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnkAppPwd;
        private System.Windows.Forms.LinkLabel lnkDBPwd;
        private System.Windows.Forms.LinkLabel lnkWinPwd;
        private System.Windows.Forms.LinkLabel lnkUnixPwd;
        private System.Windows.Forms.LinkLabel lnkAS400Pwd;
        protected UIComponents.XPPanel pnlchk;
        private System.Windows.Forms.LinkLabel lnkChkWin;
        private System.Windows.Forms.LinkLabel linkEcPwd;
        private System.Windows.Forms.LinkLabel lnkATMPwd;
    }
}
