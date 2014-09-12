namespace PhalanxAdmin
{
    partial class FSelectWinDomains
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
            this.cHDomain = new System.Windows.Forms.ColumnHeader();
            this.cHComments = new System.Windows.Forms.ColumnHeader();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvLista
            // 
            this.lvLista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cHDomain,
            this.cHComments});
            // 
            // cHDomain
            // 
            this.cHDomain.Text = "Dominio";
            this.cHDomain.Width = 120;
            // 
            // cHComments
            // 
            this.cHComments.Text = "Comentarios";
            this.cHComments.Width = 120;
            // 
            // FSelectWinDomains
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(296, 440);
            this.Name = "FSelectWinDomains";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader cHDomain;
        private System.Windows.Forms.ColumnHeader cHComments;
    }
}
