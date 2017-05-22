namespace TestWSInterfaceClaves
{
    partial class FormConectoresConsulta
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
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkLog = new System.Windows.Forms.CheckBox();
            this.rbAutenticacionPlain = new System.Windows.Forms.RadioButton();
            this.rbAutenticacionEncript = new System.Windows.Forms.RadioButton();
            this.txtAutEncript = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsrPwd = new System.Windows.Forms.TextBox();
            this.txtDominio = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(132, 175);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(607, 49);
            this.txtLog.TabIndex = 9;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(12, 187);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(96, 23);
            this.btnAceptar.TabIndex = 8;
            this.btnAceptar.Text = "Ejecutar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkLog);
            this.groupBox1.Controls.Add(this.rbAutenticacionPlain);
            this.groupBox1.Controls.Add(this.rbAutenticacionEncript);
            this.groupBox1.Controls.Add(this.txtAutEncript);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtUsrPwd);
            this.groupBox1.Controls.Add(this.txtDominio);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtUsuario);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(727, 102);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Autenticación";
            // 
            // chkLog
            // 
            this.chkLog.AutoSize = true;
            this.chkLog.Location = new System.Drawing.Point(19, 77);
            this.chkLog.Name = "chkLog";
            this.chkLog.Size = new System.Drawing.Size(44, 17);
            this.chkLog.TabIndex = 9;
            this.chkLog.Text = "Log";
            this.chkLog.UseVisualStyleBackColor = true;
            // 
            // rbAutenticacionPlain
            // 
            this.rbAutenticacionPlain.AutoSize = true;
            this.rbAutenticacionPlain.Checked = true;
            this.rbAutenticacionPlain.Location = new System.Drawing.Point(19, 54);
            this.rbAutenticacionPlain.Name = "rbAutenticacionPlain";
            this.rbAutenticacionPlain.Size = new System.Drawing.Size(90, 17);
            this.rbAutenticacionPlain.TabIndex = 2;
            this.rbAutenticacionPlain.TabStop = true;
            this.rbAutenticacionPlain.Text = "Autenticación";
            this.rbAutenticacionPlain.UseVisualStyleBackColor = true;
            // 
            // rbAutenticacionEncript
            // 
            this.rbAutenticacionEncript.AutoSize = true;
            this.rbAutenticacionEncript.Location = new System.Drawing.Point(19, 20);
            this.rbAutenticacionEncript.Name = "rbAutenticacionEncript";
            this.rbAutenticacionEncript.Size = new System.Drawing.Size(115, 17);
            this.rbAutenticacionEncript.TabIndex = 0;
            this.rbAutenticacionEncript.Text = "Cadena encriptada";
            this.rbAutenticacionEncript.UseVisualStyleBackColor = true;
            // 
            // txtAutEncript
            // 
            this.txtAutEncript.Location = new System.Drawing.Point(134, 19);
            this.txtAutEncript.Name = "txtAutEncript";
            this.txtAutEncript.Size = new System.Drawing.Size(569, 20);
            this.txtAutEncript.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(131, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Dominio";
            // 
            // txtUsrPwd
            // 
            this.txtUsrPwd.Location = new System.Drawing.Point(512, 53);
            this.txtUsrPwd.Name = "txtUsrPwd";
            this.txtUsrPwd.PasswordChar = '*';
            this.txtUsrPwd.Size = new System.Drawing.Size(152, 20);
            this.txtUsrPwd.TabIndex = 8;
            // 
            // txtDominio
            // 
            this.txtDominio.Location = new System.Drawing.Point(182, 53);
            this.txtDominio.Name = "txtDominio";
            this.txtDominio.Size = new System.Drawing.Size(86, 20);
            this.txtDominio.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(445, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Contraseña";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(282, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Usuario";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(333, 53);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(103, 20);
            this.txtUsuario.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Location = new System.Drawing.Point(12, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(727, 47);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo de Acción";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "Dominio";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(58, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(180, 21);
            this.comboBox1.TabIndex = 6;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 230);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(727, 179);
            this.dataGridView1.TabIndex = 12;
            // 
            // FormConectoresConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(777, 434);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnAceptar);
            this.Name = "FormConectoresConsulta";
            this.Text = "Tests Phalanx";
            this.Load += new System.EventHandler(this.FormConectoresConsulta_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbAutenticacionPlain;
        private System.Windows.Forms.RadioButton rbAutenticacionEncript;
        private System.Windows.Forms.TextBox txtAutEncript;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsrPwd;
        private System.Windows.Forms.TextBox txtDominio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.CheckBox chkLog;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

