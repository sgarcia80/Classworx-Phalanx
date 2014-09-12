namespace PhalanxAdmin
{
    partial class FEsquemas
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnChgEsquema = new System.Windows.Forms.Button();
            this.txtEsquemaActivo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pnlXPGrps)).BeginInit();
            this.pnlXPGrps.SuspendLayout();
            this.pnlIzq.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlXPGrps
            // 
            this.pnlXPGrps.Size = new System.Drawing.Size(200, 525);
            // 
            // pnlIzq
            // 
            this.pnlIzq.Size = new System.Drawing.Size(200, 525);
            // 
            // xppnlMenu
            // 
            this.xppnlMenu.ImageItems.ImageSet = null;
            this.xppnlMenu.Location = new System.Drawing.Point(8, 8);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(263, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Esquema activo:";
            // 
            // btnChgEsquema
            // 
            this.btnChgEsquema.Location = new System.Drawing.Point(340, 133);
            this.btnChgEsquema.Name = "btnChgEsquema";
            this.btnChgEsquema.Size = new System.Drawing.Size(140, 23);
            this.btnChgEsquema.TabIndex = 4;
            this.btnChgEsquema.Text = "Cambiar Esquema";
            this.btnChgEsquema.UseVisualStyleBackColor = true;
            this.btnChgEsquema.Click += new System.EventHandler(this.btnChgEsquema_Click);
            // 
            // txtEsquemaActivo
            // 
            this.txtEsquemaActivo.BackColor = System.Drawing.Color.White;
            this.txtEsquemaActivo.Location = new System.Drawing.Point(355, 67);
            this.txtEsquemaActivo.Name = "txtEsquemaActivo";
            this.txtEsquemaActivo.ReadOnly = true;
            this.txtEsquemaActivo.Size = new System.Drawing.Size(163, 20);
            this.txtEsquemaActivo.TabIndex = 3;
            // 
            // FEsquemas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(776, 525);
            this.Controls.Add(this.txtEsquemaActivo);
            this.Controls.Add(this.btnChgEsquema);
            this.Controls.Add(this.label1);
            this.Name = "FEsquemas";
            this.Load += new System.EventHandler(this.FEsquemas_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnChgEsquema, 0);
            this.Controls.SetChildIndex(this.txtEsquemaActivo, 0);
            this.Controls.SetChildIndex(this.pnlIzq, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pnlXPGrps)).EndInit();
            this.pnlXPGrps.ResumeLayout(false);
            this.pnlIzq.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnChgEsquema;
        private System.Windows.Forms.TextBox txtEsquemaActivo;
    }
}
