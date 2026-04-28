namespace PhalanxAdmin
{
    partial class FSelectWinPC
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
            System.Windows.Forms.ColumnHeader cHPCName;
            System.Windows.Forms.ColumnHeader cHIP;
            cHPCName = new System.Windows.Forms.ColumnHeader();
            cHIP = new System.Windows.Forms.ColumnHeader();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvLista
            // 
            this.lvLista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            cHPCName,
            cHIP});
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(13, 4);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cHPCName
            // 
            cHPCName.Text = "Nombre PC";
            cHPCName.Width = 120;
            // 
            // cHIP
            // 
            cHIP.Text = "IP";
            cHIP.Width = 120;
            // 
            // FSelectWinPC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(296, 440);
            this.Name = "FSelectWinPC";
            this.Load += new System.EventHandler(this.FSelectWinPC_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

    }
}
