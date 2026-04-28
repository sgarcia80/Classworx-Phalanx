namespace PhalanxAdmin
{
    partial class FBaseReportes
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
            this.linkInternos = new System.Windows.Forms.LinkLabel();
            this.linkNormativos = new System.Windows.Forms.LinkLabel();
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
            this.xppnlMenu.Caption = "Reportes";
            this.xppnlMenu.Controls.Add(this.linkInternos);
            this.xppnlMenu.Controls.Add(this.linkNormativos);
            this.xppnlMenu.ImageItems.ImageSet = null;
            this.xppnlMenu.Size = new System.Drawing.Size(184, 104);
            // 
            // linkInternos
            // 
            this.linkInternos.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.linkInternos.AutoSize = true;
            this.linkInternos.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkInternos.LinkColor = System.Drawing.Color.MidnightBlue;
            this.linkInternos.Location = new System.Drawing.Point(5, 46);
            this.linkInternos.Name = "linkInternos";
            this.linkInternos.Size = new System.Drawing.Size(53, 13);
            this.linkInternos.TabIndex = 30;
            this.linkInternos.TabStop = true;
            this.linkInternos.Text = "Internos";
            this.linkInternos.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.linkInternos.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkInternos_LinkClicked);
            // 
            // linkNormativos
            // 
            this.linkNormativos.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.linkNormativos.AutoSize = true;
            this.linkNormativos.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkNormativos.LinkColor = System.Drawing.Color.MidnightBlue;
            this.linkNormativos.Location = new System.Drawing.Point(5, 68);
            this.linkNormativos.Name = "linkNormativos";
            this.linkNormativos.Size = new System.Drawing.Size(70, 13);
            this.linkNormativos.TabIndex = 31;
            this.linkNormativos.TabStop = true;
            this.linkNormativos.Text = "Normativos";
            this.linkNormativos.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.linkNormativos.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkNormativos_LinkClicked);
            // 
            // FBaseReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(539, 522);
            this.Name = "FBaseReportes";
            this.Load += new System.EventHandler(this.FBaseReportes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlXPGrps)).EndInit();
            this.pnlXPGrps.ResumeLayout(false);
            this.pnlIzq.ResumeLayout(false);
            this.xppnlMenu.ResumeLayout(false);
            this.xppnlMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkInternos;
        private System.Windows.Forms.LinkLabel linkNormativos;


    }
}
