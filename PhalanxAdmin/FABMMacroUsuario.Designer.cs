namespace PhalanxAdmin
{
    partial class FABMMacroUsuario
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
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsuarioRed = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbMacro = new System.Windows.Forms.ComboBox();
            this.cbDominio = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.cbVisualizar = new System.Windows.Forms.CheckBox();
            this.chkPrincipal = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 207);
            this.groupBox1.Size = new System.Drawing.Size(481, 43);
            this.groupBox1.TabIndex = 14;
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
            this.label1.Location = new System.Drawing.Point(24, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Usuario";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(105, 131);
            this.txtUsuario.MaxLength = 50;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(265, 20);
            this.txtUsuario.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Usuario Red";
            // 
            // txtUsuarioRed
            // 
            this.txtUsuarioRed.Location = new System.Drawing.Point(105, 54);
            this.txtUsuarioRed.MaxLength = 50;
            this.txtUsuarioRed.Name = "txtUsuarioRed";
            this.txtUsuarioRed.Size = new System.Drawing.Size(265, 20);
            this.txtUsuarioRed.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Macro";
            // 
            // cbMacro
            // 
            this.cbMacro.DisplayMember = "Name";
            this.cbMacro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMacro.FormattingEnabled = true;
            this.cbMacro.Location = new System.Drawing.Point(105, 104);
            this.cbMacro.Name = "cbMacro";
            this.cbMacro.Size = new System.Drawing.Size(265, 21);
            this.cbMacro.TabIndex = 6;
            this.cbMacro.ValueMember = "Id";
            // 
            // cbDominio
            // 
            this.cbDominio.DisplayMember = "NtName";
            this.cbDominio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDominio.FormattingEnabled = true;
            this.cbDominio.Location = new System.Drawing.Point(105, 27);
            this.cbDominio.Name = "cbDominio";
            this.cbDominio.Size = new System.Drawing.Size(265, 21);
            this.cbDominio.TabIndex = 2;
            this.cbDominio.ValueMember = "Id";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Dominio";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Clave";
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(105, 157);
            this.txtClave.MaxLength = 250;
            this.txtClave.Name = "txtClave";
            this.txtClave.PasswordChar = '*';
            this.txtClave.Size = new System.Drawing.Size(265, 20);
            this.txtClave.TabIndex = 10;
            // 
            // cbVisualizar
            // 
            this.cbVisualizar.AutoSize = true;
            this.cbVisualizar.Location = new System.Drawing.Point(376, 159);
            this.cbVisualizar.Name = "cbVisualizar";
            this.cbVisualizar.Size = new System.Drawing.Size(70, 17);
            this.cbVisualizar.TabIndex = 11;
            this.cbVisualizar.Text = "Visualizar";
            this.cbVisualizar.UseVisualStyleBackColor = true;
            this.cbVisualizar.CheckedChanged += new System.EventHandler(this.cbVisualizar_CheckedChanged);
            // 
            // chkPrincipal
            // 
            this.chkPrincipal.AutoSize = true;
            this.chkPrincipal.Location = new System.Drawing.Point(105, 185);
            this.chkPrincipal.Name = "chkPrincipal";
            this.chkPrincipal.Size = new System.Drawing.Size(15, 14);
            this.chkPrincipal.TabIndex = 13;
            this.chkPrincipal.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Principal";
            // 
            // FABMMacroUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(481, 250);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkPrincipal);
            this.Controls.Add(this.cbVisualizar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.cbDominio);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbMacro);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUsuarioRed);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUsuario);
            this.Name = "FABMMacroUsuario";
            this.Load += new System.EventHandler(this.FABMMacroUsuario_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.txtUsuario, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtUsuarioRed, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.cbMacro, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.cbDominio, 0);
            this.Controls.SetChildIndex(this.txtClave, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.cbVisualizar, 0);
            this.Controls.SetChildIndex(this.chkPrincipal, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsuarioRed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbMacro;
        private System.Windows.Forms.ComboBox cbDominio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.CheckBox cbVisualizar;
        private System.Windows.Forms.CheckBox chkPrincipal;
        private System.Windows.Forms.Label label4;
    }
}
