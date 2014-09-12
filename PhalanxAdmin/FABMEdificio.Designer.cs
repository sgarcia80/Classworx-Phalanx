namespace PhalanxAdmin
{
    partial class FABMEdificio
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
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblDelBuilding = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 88);
            this.groupBox1.Size = new System.Drawing.Size(454, 43);
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
            this.label1.Location = new System.Drawing.Point(26, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Dirección";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(107, 42);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(265, 20);
            this.txtDireccion.TabIndex = 30;
            // 
            // lblDelBuilding
            // 
            this.lblDelBuilding.AutoSize = true;
            this.lblDelBuilding.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDelBuilding.ForeColor = System.Drawing.Color.Red;
            this.lblDelBuilding.Location = new System.Drawing.Point(61, 72);
            this.lblDelBuilding.Name = "lblDelBuilding";
            this.lblDelBuilding.Size = new System.Drawing.Size(290, 13);
            this.lblDelBuilding.TabIndex = 10;
            this.lblDelBuilding.Text = "Se va a borrar el edificio. Confirme la operación...";
            this.lblDelBuilding.Visible = false;
            // 
            // FABMEdificio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(454, 131);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDelBuilding);
            this.Controls.Add(this.txtDireccion);
            this.Name = "FABMEdificio";
            this.Load += new System.EventHandler(this.FABMEdificio_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.txtDireccion, 0);
            this.Controls.SetChildIndex(this.lblDelBuilding, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblDelBuilding;
    }
}
