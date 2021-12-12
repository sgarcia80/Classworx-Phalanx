namespace PhalanxAdmin
{
    partial class frmBaseMaxMdiChilds
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaseMaxMdiChilds));
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.pnlXPGrps = new UIComponents.XPPanelGroup();
            this.xppnlMenu = new UIComponents.XPPanel(139);
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlXPGrps)).BeginInit();
            this.pnlXPGrps.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.pnlXPGrps);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(200, 581);
            this.pnlMenu.TabIndex = 0;
            // 
            // pnlXPGrps
            // 
            this.pnlXPGrps.AutoScroll = true;
            this.pnlXPGrps.BackColor = System.Drawing.Color.Transparent;
            this.pnlXPGrps.Controls.Add(this.xppnlMenu);
            this.pnlXPGrps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlXPGrps.Location = new System.Drawing.Point(0, 0);
            this.pnlXPGrps.Name = "pnlXPGrps";
            this.pnlXPGrps.PanelGradient = ((UIComponents.GradientColor)(resources.GetObject("pnlXPGrps.PanelGradient")));
            this.pnlXPGrps.Size = new System.Drawing.Size(200, 581);
            this.pnlXPGrps.TabIndex = 1;
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
            // pnlContenido
            // 
            this.pnlContenido.BackColor = System.Drawing.Color.White;
            this.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenido.Location = new System.Drawing.Point(200, 0);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Size = new System.Drawing.Size(851, 581);
            this.pnlContenido.TabIndex = 1;
            // 
            // frmBaseMaxMdiChilds
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 581);
            this.Controls.Add(this.pnlContenido);
            this.Controls.Add(this.pnlMenu);
            this.Name = "frmBaseMaxMdiChilds";
            this.Text = "frmBaseMaxMdiChilds";
            this.pnlMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlXPGrps)).EndInit();
            this.pnlXPGrps.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        protected UIComponents.XPPanelGroup pnlXPGrps;
        protected UIComponents.XPPanel xppnlMenu;
        protected System.Windows.Forms.Panel pnlContenido;

    }
}