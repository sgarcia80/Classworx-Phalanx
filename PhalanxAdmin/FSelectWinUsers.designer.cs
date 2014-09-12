namespace PhalanxAdmin
{
    partial class FSelectWinUsers
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
            this.cHUserName = new System.Windows.Forms.ColumnHeader();
            this.cHDesc = new System.Windows.Forms.ColumnHeader();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvLista
            // 
            this.lvLista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cHUserName,
            this.cHDesc});
            // 
            // cHUserName
            // 
            this.cHUserName.Text = "Nombre Usuario";
            this.cHUserName.Width = 120;
            // 
            // cHDesc
            // 
            this.cHDesc.Text = "Descripción";
            this.cHDesc.Width = 120;
            // 
            // FSelectWinUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(296, 440);
            this.Name = "FSelectWinUsers";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader cHUserName;
        private System.Windows.Forms.ColumnHeader cHDesc;
    }
}
