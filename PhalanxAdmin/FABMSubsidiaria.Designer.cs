namespace PhalanxAdmin
{
    partial class FABMSubsidiaria
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
			this.lblDelSubsidiaria = new System.Windows.Forms.Label();
			this.txtNombre = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtCodigo = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtEmail01 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtEmail02 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(0, 186);
			this.groupBox1.Size = new System.Drawing.Size(450, 43);
			this.groupBox1.TabIndex = 5;
			// 
			// btnAceptar
			// 
			this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(24, 69);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(44, 13);
			this.label1.TabIndex = 34;
			this.label1.Text = "Nombre";
			// 
			// lblDelSubsidiaria
			// 
			this.lblDelSubsidiaria.AutoSize = true;
			this.lblDelSubsidiaria.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDelSubsidiaria.ForeColor = System.Drawing.Color.Red;
			this.lblDelSubsidiaria.Location = new System.Drawing.Point(63, 170);
			this.lblDelSubsidiaria.Name = "lblDelSubsidiaria";
			this.lblDelSubsidiaria.Size = new System.Drawing.Size(309, 13);
			this.lblDelSubsidiaria.TabIndex = 32;
			this.lblDelSubsidiaria.Text = "Se va a borrar la subsidiaria. Confirme la operación...";
			this.lblDelSubsidiaria.Visible = false;
			// 
			// txtNombre
			// 
			this.txtNombre.Location = new System.Drawing.Point(105, 69);
			this.txtNombre.Name = "txtNombre";
			this.txtNombre.Size = new System.Drawing.Size(265, 20);
			this.txtNombre.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(24, 35);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 13);
			this.label2.TabIndex = 36;
			this.label2.Text = "Código";
			// 
			// txtCodigo
			// 
			this.txtCodigo.Location = new System.Drawing.Point(105, 35);
			this.txtCodigo.Name = "txtCodigo";
			this.txtCodigo.Size = new System.Drawing.Size(265, 20);
			this.txtCodigo.TabIndex = 0;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(24, 104);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(41, 13);
			this.label3.TabIndex = 40;
			this.label3.Text = "Email 1";
			// 
			// txtEmail01
			// 
			this.txtEmail01.Location = new System.Drawing.Point(105, 104);
			this.txtEmail01.Name = "txtEmail01";
			this.txtEmail01.Size = new System.Drawing.Size(265, 20);
			this.txtEmail01.TabIndex = 3;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(24, 138);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(41, 13);
			this.label4.TabIndex = 39;
			this.label4.Text = "Email 2";
			// 
			// txtEmail02
			// 
			this.txtEmail02.Location = new System.Drawing.Point(105, 138);
			this.txtEmail02.Name = "txtEmail02";
			this.txtEmail02.Size = new System.Drawing.Size(265, 20);
			this.txtEmail02.TabIndex = 4;
			// 
			// FABMSubsidiaria
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(450, 229);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtEmail01);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtEmail02);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtCodigo);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblDelSubsidiaria);
			this.Controls.Add(this.txtNombre);
			this.Name = "FABMSubsidiaria";
			this.Load += new System.EventHandler(this.FABMSubsidiaria_Load);
			this.Controls.SetChildIndex(this.groupBox1, 0);
			this.Controls.SetChildIndex(this.txtNombre, 0);
			this.Controls.SetChildIndex(this.lblDelSubsidiaria, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.txtCodigo, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.txtEmail02, 0);
			this.Controls.SetChildIndex(this.label4, 0);
			this.Controls.SetChildIndex(this.txtEmail01, 0);
			this.Controls.SetChildIndex(this.label3, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDelSubsidiaria;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmail01;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEmail02;
    }
}
