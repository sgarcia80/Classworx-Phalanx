namespace PhalanxAdmin
{
    partial class FTestMail
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
            this.cbParams = new System.Windows.Forms.ComboBox();
            this.labelDom = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMailDestin = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 156);
            this.groupBox1.Size = new System.Drawing.Size(454, 43);
            // 
            // btnAceptar
            // 
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.TabIndex = 3;
            // 
            // cbParams
            // 
            this.cbParams.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbParams.FormattingEnabled = true;
            this.cbParams.Items.AddRange(new object[] {
            "Mail de solicitud de contraseña",
            "Mail de expiración de uso de contraseña"});
            this.cbParams.Location = new System.Drawing.Point(117, 50);
            this.cbParams.Name = "cbParams";
            this.cbParams.Size = new System.Drawing.Size(302, 21);
            this.cbParams.TabIndex = 0;
            // 
            // labelDom
            // 
            this.labelDom.AutoSize = true;
            this.labelDom.Location = new System.Drawing.Point(34, 53);
            this.labelDom.Name = "labelDom";
            this.labelDom.Size = new System.Drawing.Size(26, 13);
            this.labelDom.TabIndex = 17;
            this.labelDom.Text = "Mail";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Destinatario";
            // 
            // txtMailDestin
            // 
            this.txtMailDestin.Location = new System.Drawing.Point(117, 102);
            this.txtMailDestin.MaxLength = 200;
            this.txtMailDestin.Name = "txtMailDestin";
            this.txtMailDestin.Size = new System.Drawing.Size(302, 20);
            this.txtMailDestin.TabIndex = 1;
            // 
            // FTestMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(454, 199);
            this.Controls.Add(this.txtMailDestin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbParams);
            this.Controls.Add(this.labelDom);
            this.Name = "FTestMail";
            this.Load += new System.EventHandler(this.FTestMail_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.labelDom, 0);
            this.Controls.SetChildIndex(this.cbParams, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtMailDestin, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbParams;
        private System.Windows.Forms.Label labelDom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMailDestin;

    }
}
