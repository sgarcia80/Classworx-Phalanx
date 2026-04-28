namespace PhalanxAdmin
{
    partial class FBasePanel
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
            this.pnlXPGrps = new UIComponents.XPPanelGroup();
            this.xppnlMenu = new UIComponents.XPPanel(139);
            this.pnlIzq = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pnlXPGrps)).BeginInit();
            this.pnlXPGrps.SuspendLayout();
            this.pnlIzq.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlXPGrps
            // 
            this.pnlXPGrps.AutoScroll = true;
            this.pnlXPGrps.BackColor = System.Drawing.Color.Transparent;
            this.pnlXPGrps.Controls.Add(this.xppnlMenu);
            this.pnlXPGrps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlXPGrps.Location = new System.Drawing.Point(0, 0);
            this.pnlXPGrps.Name = "pnlXPGrps";
            this.pnlXPGrps.PanelGradient.End = System.Drawing.Color.CornflowerBlue;
            this.pnlXPGrps.PanelGradient.Start = System.Drawing.Color.CornflowerBlue;
            this.pnlXPGrps.Size = new System.Drawing.Size(200, 508);
            this.pnlXPGrps.TabIndex = 0;
            // 
            // xppnlMenu
            // 
            this.xppnlMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xppnlMenu.BackColor = System.Drawing.Color.Transparent;
            this.xppnlMenu.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xppnlMenu.CaptionGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
            this.xppnlMenu.CaptionGradient.Start = System.Drawing.Color.White;
            this.xppnlMenu.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xppnlMenu.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xppnlMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.xppnlMenu.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xppnlMenu.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xppnlMenu.ImageItems.ImageSet = null;
            this.xppnlMenu.Location = new System.Drawing.Point(8, 8);
            this.xppnlMenu.Name = "xppnlMenu";
            this.xppnlMenu.PanelGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.xppnlMenu.PanelGradient.Start = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.xppnlMenu.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xppnlMenu.Size = new System.Drawing.Size(184, 139);
            this.xppnlMenu.TabIndex = 0;
            this.xppnlMenu.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.xppnlMenu.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.xppnlMenu.VertAlignment = System.Drawing.StringAlignment.Center;
            // 
            // pnlIzq
            // 
            this.pnlIzq.Controls.Add(this.pnlXPGrps);
            this.pnlIzq.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlIzq.Location = new System.Drawing.Point(0, 0);
            this.pnlIzq.Name = "pnlIzq";
            this.pnlIzq.Size = new System.Drawing.Size(200, 508);
            this.pnlIzq.TabIndex = 1;
            // 
            // FBasePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(661, 508);
            this.Controls.Add(this.pnlIzq);
            this.Name = "FBasePanel";
            this.Load += new System.EventHandler(this.FBasePanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlXPGrps)).EndInit();
            this.pnlXPGrps.ResumeLayout(false);
            this.pnlIzq.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected UIComponents.XPPanelGroup pnlXPGrps;
        protected System.Windows.Forms.Panel pnlIzq;
        protected UIComponents.XPPanel xppnlMenu;

    }
}
