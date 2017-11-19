namespace PhalanxAdmin
{
    partial class FABMAplicativoBPM
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
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbNotificable = new System.Windows.Forms.CheckBox();
            this.cbEmuladores = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbMacro = new System.Windows.Forms.ComboBox();
            this.txtPrefijoUsuario = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 205);
            this.groupBox1.Size = new System.Drawing.Size(450, 43);
            this.groupBox1.TabIndex = 13;
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
            this.label1.Location = new System.Drawing.Point(24, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(105, 61);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(265, 20);
            this.txtNombre.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Código";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(105, 35);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(265, 20);
            this.txtCodigo.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Notificable";
            // 
            // cbNotificable
            // 
            this.cbNotificable.AutoSize = true;
            this.cbNotificable.Location = new System.Drawing.Point(105, 90);
            this.cbNotificable.Name = "cbNotificable";
            this.cbNotificable.Size = new System.Drawing.Size(15, 14);
            this.cbNotificable.TabIndex = 6;
            this.cbNotificable.UseVisualStyleBackColor = true;
            // 
            // cbEmuladores
            // 
            this.cbEmuladores.AutoSize = true;
            this.cbEmuladores.Location = new System.Drawing.Point(105, 116);
            this.cbEmuladores.Name = "cbEmuladores";
            this.cbEmuladores.Size = new System.Drawing.Size(15, 14);
            this.cbEmuladores.TabIndex = 8;
            this.cbEmuladores.UseVisualStyleBackColor = true;
            this.cbEmuladores.CheckedChanged += new System.EventHandler(this.cbEmuladores_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Emuladores";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Macro";
            // 
            // cbMacro
            // 
            this.cbMacro.DisplayMember = "Name";
            this.cbMacro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMacro.FormattingEnabled = true;
            this.cbMacro.Location = new System.Drawing.Point(105, 140);
            this.cbMacro.Name = "cbMacro";
            this.cbMacro.Size = new System.Drawing.Size(265, 21);
            this.cbMacro.TabIndex = 10;
            this.cbMacro.ValueMember = "Id";
            // 
            // txtPrefijoUsuario
            // 
            this.txtPrefijoUsuario.Location = new System.Drawing.Point(105, 167);
            this.txtPrefijoUsuario.MaxLength = 10;
            this.txtPrefijoUsuario.Name = "txtPrefijoUsuario";
            this.txtPrefijoUsuario.Size = new System.Drawing.Size(128, 20);
            this.txtPrefijoUsuario.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Prefijo Usuario";
            // 
            // FABMAplicativoBPM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(450, 248);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPrefijoUsuario);
            this.Controls.Add(this.cbMacro);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbEmuladores);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbNotificable);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNombre);
            this.Name = "FABMAplicativoBPM";
            this.Load += new System.EventHandler(this.FABMAplicativoBPM_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.txtNombre, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtCodigo, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.cbNotificable, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.cbEmuladores, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.cbMacro, 0);
            this.Controls.SetChildIndex(this.txtPrefijoUsuario, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbNotificable;
        private System.Windows.Forms.CheckBox cbEmuladores;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbMacro;
        private System.Windows.Forms.TextBox txtPrefijoUsuario;
        private System.Windows.Forms.Label label6;
    }
}
