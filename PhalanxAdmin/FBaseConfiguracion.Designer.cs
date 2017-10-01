namespace PhalanxAdmin
{
    partial class FBaseConfiguracion
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
            this.xppnlConfig = new UIComponents.XPPanel(231);
            this.lnkWSConectores = new System.Windows.Forms.LinkLabel();
            this.lnkNDC = new System.Windows.Forms.LinkLabel();
            this.lnkWSCOBIS = new System.Windows.Forms.LinkLabel();
            this.lnkWSBPM = new System.Windows.Forms.LinkLabel();
            this.lnkEsquemas = new System.Windows.Forms.LinkLabel();
            this.lnkATMs = new System.Windows.Forms.LinkLabel();
            this.lnkconfigMailsExpPwd = new System.Windows.Forms.LinkLabel();
            this.lnkMacros = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pnlXPGrps)).BeginInit();
            this.pnlXPGrps.SuspendLayout();
            this.pnlIzq.SuspendLayout();
            this.xppnlConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlXPGrps
            // 
            this.pnlXPGrps.Controls.Add(this.xppnlConfig);
            this.pnlXPGrps.Size = new System.Drawing.Size(200, 522);
            this.pnlXPGrps.Controls.SetChildIndex(this.xppnlMenu, 0);
            this.pnlXPGrps.Controls.SetChildIndex(this.xppnlConfig, 0);
            // 
            // pnlIzq
            // 
            this.pnlIzq.Size = new System.Drawing.Size(200, 522);
            // 
            // xppnlMenu
            // 
            this.xppnlMenu.ImageItems.ImageSet = null;
            this.xppnlMenu.Location = new System.Drawing.Point(8, 247);
            // 
            // xppnlConfig
            // 
            this.xppnlConfig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xppnlConfig.BackColor = System.Drawing.Color.Transparent;
            this.xppnlConfig.Caption = "Configuración";
            this.xppnlConfig.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xppnlConfig.CaptionGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
            this.xppnlConfig.CaptionGradient.Start = System.Drawing.Color.White;
            this.xppnlConfig.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xppnlConfig.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xppnlConfig.Controls.Add(this.lnkMacros);
            this.xppnlConfig.Controls.Add(this.lnkWSConectores);
            this.xppnlConfig.Controls.Add(this.lnkNDC);
            this.xppnlConfig.Controls.Add(this.lnkWSCOBIS);
            this.xppnlConfig.Controls.Add(this.lnkWSBPM);
            this.xppnlConfig.Controls.Add(this.lnkEsquemas);
            this.xppnlConfig.Controls.Add(this.lnkATMs);
            this.xppnlConfig.Controls.Add(this.lnkconfigMailsExpPwd);
            this.xppnlConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.xppnlConfig.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xppnlConfig.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xppnlConfig.ImageItems.ImageSet = null;
            this.xppnlConfig.Location = new System.Drawing.Point(8, 8);
            this.xppnlConfig.Name = "xppnlConfig";
            this.xppnlConfig.PanelGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.xppnlConfig.PanelGradient.Start = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.xppnlConfig.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xppnlConfig.Size = new System.Drawing.Size(184, 231);
            this.xppnlConfig.TabIndex = 4;
            this.xppnlConfig.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.xppnlConfig.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.xppnlConfig.VertAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lnkWSConectores
            // 
            this.lnkWSConectores.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkWSConectores.AutoSize = true;
            this.lnkWSConectores.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.lnkWSConectores.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkWSConectores.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkWSConectores.Location = new System.Drawing.Point(18, 181);
            this.lnkWSConectores.Name = "lnkWSConectores";
            this.lnkWSConectores.Size = new System.Drawing.Size(154, 13);
            this.lnkWSConectores.TabIndex = 15;
            this.lnkWSConectores.TabStop = true;
            this.lnkWSConectores.Text = "Web Services Conectores";
            this.lnkWSConectores.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkWSConectores.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkWSConectores_LinkClicked);
            // 
            // lnkNDC
            // 
            this.lnkNDC.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkNDC.AutoSize = true;
            this.lnkNDC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.lnkNDC.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkNDC.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkNDC.Location = new System.Drawing.Point(18, 158);
            this.lnkNDC.Name = "lnkNDC";
            this.lnkNDC.Size = new System.Drawing.Size(135, 13);
            this.lnkNDC.TabIndex = 14;
            this.lnkNDC.TabStop = true;
            this.lnkNDC.Text = "Notificación de Claves";
            this.lnkNDC.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkNDC.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkNDC_LinkClicked);
            // 
            // lnkWSCOBIS
            // 
            this.lnkWSCOBIS.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkWSCOBIS.AutoSize = true;
            this.lnkWSCOBIS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.lnkWSCOBIS.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkWSCOBIS.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkWSCOBIS.Location = new System.Drawing.Point(18, 136);
            this.lnkWSCOBIS.Name = "lnkWSCOBIS";
            this.lnkWSCOBIS.Size = new System.Drawing.Size(127, 13);
            this.lnkWSCOBIS.TabIndex = 13;
            this.lnkWSCOBIS.TabStop = true;
            this.lnkWSCOBIS.Text = "Web Services COBIS";
            this.lnkWSCOBIS.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkWSCOBIS.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lnkWSBPM
            // 
            this.lnkWSBPM.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkWSBPM.AutoSize = true;
            this.lnkWSBPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.lnkWSBPM.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkWSBPM.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkWSBPM.Location = new System.Drawing.Point(18, 114);
            this.lnkWSBPM.Name = "lnkWSBPM";
            this.lnkWSBPM.Size = new System.Drawing.Size(110, 13);
            this.lnkWSBPM.TabIndex = 12;
            this.lnkWSBPM.TabStop = true;
            this.lnkWSBPM.Text = "Web Service BPM";
            this.lnkWSBPM.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkWSBPM.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkWSBPM_LinkClicked);
            // 
            // lnkEsquemas
            // 
            this.lnkEsquemas.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkEsquemas.AutoSize = true;
            this.lnkEsquemas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.lnkEsquemas.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkEsquemas.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkEsquemas.Location = new System.Drawing.Point(18, 70);
            this.lnkEsquemas.Name = "lnkEsquemas";
            this.lnkEsquemas.Size = new System.Drawing.Size(64, 13);
            this.lnkEsquemas.TabIndex = 11;
            this.lnkEsquemas.TabStop = true;
            this.lnkEsquemas.Text = "Esquemas";
            this.lnkEsquemas.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkEsquemas.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkEsquemas_LinkClicked);
            // 
            // lnkATMs
            // 
            this.lnkATMs.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkATMs.AutoSize = true;
            this.lnkATMs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.lnkATMs.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkATMs.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkATMs.Location = new System.Drawing.Point(18, 92);
            this.lnkATMs.Name = "lnkATMs";
            this.lnkATMs.Size = new System.Drawing.Size(39, 13);
            this.lnkATMs.TabIndex = 10;
            this.lnkATMs.TabStop = true;
            this.lnkATMs.Text = "ATMs";
            this.lnkATMs.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkATMs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkATMs_LinkClicked);
            // 
            // lnkconfigMailsExpPwd
            // 
            this.lnkconfigMailsExpPwd.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkconfigMailsExpPwd.AutoSize = true;
            this.lnkconfigMailsExpPwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.lnkconfigMailsExpPwd.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkconfigMailsExpPwd.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkconfigMailsExpPwd.Location = new System.Drawing.Point(18, 50);
            this.lnkconfigMailsExpPwd.Name = "lnkconfigMailsExpPwd";
            this.lnkconfigMailsExpPwd.Size = new System.Drawing.Size(36, 13);
            this.lnkconfigMailsExpPwd.TabIndex = 8;
            this.lnkconfigMailsExpPwd.TabStop = true;
            this.lnkconfigMailsExpPwd.Text = "Mails";
            this.lnkconfigMailsExpPwd.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkconfigMailsExpPwd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkconfigMailsExpPwd_LinkClicked);
            // 
            // lnkMacros
            // 
            this.lnkMacros.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkMacros.AutoSize = true;
            this.lnkMacros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.lnkMacros.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkMacros.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkMacros.Location = new System.Drawing.Point(18, 203);
            this.lnkMacros.Name = "lnkMacros";
            this.lnkMacros.Size = new System.Drawing.Size(111, 13);
            this.lnkMacros.TabIndex = 16;
            this.lnkMacros.TabStop = true;
            this.lnkMacros.Text = "Macro Emuladores";
            this.lnkMacros.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkMacros.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkMacros_LinkClicked);
            // 
            // FBaseConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(769, 522);
            this.Name = "FBaseConfiguracion";
            this.Load += new System.EventHandler(this.FBaseConfiguracion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlXPGrps)).EndInit();
            this.pnlXPGrps.ResumeLayout(false);
            this.pnlIzq.ResumeLayout(false);
            this.xppnlConfig.ResumeLayout(false);
            this.xppnlConfig.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UIComponents.XPPanel xppnlConfig;
        protected System.Windows.Forms.LinkLabel lnkEsquemas;
        protected System.Windows.Forms.LinkLabel lnkATMs;
        protected System.Windows.Forms.LinkLabel lnkconfigMailsExpPwd;
        protected System.Windows.Forms.LinkLabel lnkWSBPM;
        protected System.Windows.Forms.LinkLabel lnkWSCOBIS;
        protected System.Windows.Forms.LinkLabel lnkNDC;
        protected System.Windows.Forms.LinkLabel lnkWSConectores;
        protected System.Windows.Forms.LinkLabel lnkMacros;

    }
}
