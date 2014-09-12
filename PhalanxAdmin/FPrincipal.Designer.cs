namespace PhalanxAdmin
{
    partial class FPrincipal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FPrincipal));
            this.panelIcons = new System.Windows.Forms.Panel();
            this.lVIcons = new System.Windows.Forms.ListView();
            this.iListIcons = new System.Windows.Forms.ImageList(this.components);
            this.pnlIconsLeft = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlIconsRight = new System.Windows.Forms.Panel();
            this.picMenuRight = new System.Windows.Forms.PictureBox();
            this.panelIcons.SuspendLayout();
            this.pnlIconsLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlIconsRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMenuRight)).BeginInit();
            this.SuspendLayout();
            // 
            // panelIcons
            // 
            this.panelIcons.BackColor = System.Drawing.Color.Gray;
            this.panelIcons.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelIcons.BackgroundImage")));
            this.panelIcons.Controls.Add(this.lVIcons);
            this.panelIcons.Controls.Add(this.pnlIconsLeft);
            this.panelIcons.Controls.Add(this.pnlIconsRight);
            this.panelIcons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelIcons.Location = new System.Drawing.Point(0, 0);
            this.panelIcons.Name = "panelIcons";
            this.panelIcons.Size = new System.Drawing.Size(848, 104);
            this.panelIcons.TabIndex = 1;
            this.panelIcons.Resize += new System.EventHandler(this.panelIcons_Resize);
            // 
            // lVIcons
            // 
            this.lVIcons.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lVIcons.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lVIcons.AutoArrange = false;
            this.lVIcons.BackColor = System.Drawing.Color.Silver;
            this.lVIcons.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lVIcons.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lVIcons.LabelWrap = false;
            this.lVIcons.LargeImageList = this.iListIcons;
            this.lVIcons.Location = new System.Drawing.Point(80, 24);
            this.lVIcons.MultiSelect = false;
            this.lVIcons.Name = "lVIcons";
            this.lVIcons.Scrollable = false;
            this.lVIcons.Size = new System.Drawing.Size(448, 56);
            this.lVIcons.TabIndex = 2;
            this.lVIcons.UseCompatibleStateImageBehavior = false;
            this.lVIcons.Click += new System.EventHandler(this.lVIcons_Click);
            this.lVIcons.Resize += new System.EventHandler(this.lVIcons_Resize);
            // 
            // iListIcons
            // 
            this.iListIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iListIcons.ImageStream")));
            this.iListIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.iListIcons.Images.SetKeyName(0, "Work.ico");
            this.iListIcons.Images.SetKeyName(1, "Clipboard.ico");
            this.iListIcons.Images.SetKeyName(2, "password32x32.gif");
            this.iListIcons.Images.SetKeyName(3, "reports.gif");
            this.iListIcons.Images.SetKeyName(4, "IconoAuditorias2.png");
            this.iListIcons.Images.SetKeyName(5, "ExitIcon.gif");
            // 
            // pnlIconsLeft
            // 
            this.pnlIconsLeft.Controls.Add(this.pictureBox1);
            this.pnlIconsLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlIconsLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlIconsLeft.Name = "pnlIconsLeft";
            this.pnlIconsLeft.Size = new System.Drawing.Size(73, 104);
            this.pnlIconsLeft.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 104);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pnlIconsRight
            // 
            this.pnlIconsRight.Controls.Add(this.picMenuRight);
            this.pnlIconsRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlIconsRight.Location = new System.Drawing.Point(669, 0);
            this.pnlIconsRight.Name = "pnlIconsRight";
            this.pnlIconsRight.Size = new System.Drawing.Size(179, 104);
            this.pnlIconsRight.TabIndex = 0;
            // 
            // picMenuRight
            // 
            this.picMenuRight.Image = global::PhalanxAdmin.Properties.Resources.AdmHeaderRightMacro;
            this.picMenuRight.Location = new System.Drawing.Point(0, 0);
            this.picMenuRight.Name = "picMenuRight";
            this.picMenuRight.Size = new System.Drawing.Size(179, 104);
            this.picMenuRight.TabIndex = 0;
            this.picMenuRight.TabStop = false;
            // 
            // FPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 381);
            this.Controls.Add(this.panelIcons);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "FPrincipal";
            this.Text = "Phalanx Security Manager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FPrincipal_Load);
            this.Resize += new System.EventHandler(this.FPrincipal_Resize);
            this.panelIcons.ResumeLayout(false);
            this.pnlIconsLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlIconsRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMenuRight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelIcons;
        private System.Windows.Forms.Panel pnlIconsLeft;
        private System.Windows.Forms.Panel pnlIconsRight;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox picMenuRight;
        private System.Windows.Forms.ListView lVIcons;
        private System.Windows.Forms.ImageList iListIcons;
    }
}