namespace PhalanxAdmin
{
    partial class FABMNotifBlanqueo
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FABMNotifBlanqueo));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.lblFolioTit = new System.Windows.Forms.Label();
            this.lblFolioNro = new System.Windows.Forms.Label();
            this.lps = new System.Windows.Forms.GroupBox();
            this.chkVisualizar = new System.Windows.Forms.CheckBox();
            this.tPassword2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tPassword1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.txtTicketNro = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbDomain = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbAplicacion = new System.Windows.Forms.ComboBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSolicitante = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtFechaAyC = new System.Windows.Forms.TextBox();
            this.lps.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 393);
            this.groupBox1.Size = new System.Drawing.Size(471, 43);
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
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Active.jpg");
            this.imageList.Images.SetKeyName(1, "Desactivo.jpg");
            // 
            // lblFolioTit
            // 
            this.lblFolioTit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFolioTit.AutoSize = true;
            this.lblFolioTit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolioTit.Location = new System.Drawing.Point(14, 30);
            this.lblFolioTit.Name = "lblFolioTit";
            this.lblFolioTit.Size = new System.Drawing.Size(71, 13);
            this.lblFolioTit.TabIndex = 1;
            this.lblFolioTit.Text = "Ticket Nro:";
            // 
            // lblFolioNro
            // 
            this.lblFolioNro.AutoSize = true;
            this.lblFolioNro.Location = new System.Drawing.Point(89, 210);
            this.lblFolioNro.Name = "lblFolioNro";
            this.lblFolioNro.Size = new System.Drawing.Size(0, 13);
            this.lblFolioNro.TabIndex = 11;
            // 
            // lps
            // 
            this.lps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lps.Controls.Add(this.chkVisualizar);
            this.lps.Controls.Add(this.tPassword2);
            this.lps.Controls.Add(this.label4);
            this.lps.Controls.Add(this.tPassword1);
            this.lps.Controls.Add(this.label1);
            this.lps.Location = new System.Drawing.Point(7, 272);
            this.lps.Name = "lps";
            this.lps.Size = new System.Drawing.Size(430, 116);
            this.lps.TabIndex = 12;
            this.lps.TabStop = false;
            this.lps.Text = "Contraseña del Usuario de Aplicación";
            // 
            // chkVisualizar
            // 
            this.chkVisualizar.AutoSize = true;
            this.chkVisualizar.Location = new System.Drawing.Point(86, 81);
            this.chkVisualizar.Name = "chkVisualizar";
            this.chkVisualizar.Size = new System.Drawing.Size(127, 17);
            this.chkVisualizar.TabIndex = 4;
            this.chkVisualizar.Text = "Visualizar Contraseña";
            this.chkVisualizar.UseVisualStyleBackColor = true;
            this.chkVisualizar.CheckedChanged += new System.EventHandler(this.chkVisualizar_CheckedChanged);
            // 
            // tPassword2
            // 
            this.tPassword2.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tPassword2.Location = new System.Drawing.Point(86, 50);
            this.tPassword2.MaxLength = 50;
            this.tPassword2.Name = "tPassword2";
            this.tPassword2.PasswordChar = '*';
            this.tPassword2.Size = new System.Drawing.Size(320, 22);
            this.tPassword2.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(7, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 31);
            this.label4.TabIndex = 2;
            this.label4.Text = "Confirmación Contraseña";
            // 
            // tPassword1
            // 
            this.tPassword1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tPassword1.Location = new System.Drawing.Point(86, 20);
            this.tPassword1.MaxLength = 50;
            this.tPassword1.Name = "tPassword1";
            this.tPassword1.PasswordChar = '*';
            this.tPassword1.Size = new System.Drawing.Size(320, 22);
            this.tPassword1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Contraseña";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(240, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha:";
            // 
            // txtFecha
            // 
            this.txtFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtFecha.Location = new System.Drawing.Point(315, 27);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.ReadOnly = true;
            this.txtFecha.Size = new System.Drawing.Size(122, 20);
            this.txtFecha.TabIndex = 4;
            this.txtFecha.TabStop = false;
            // 
            // txtTicketNro
            // 
            this.txtTicketNro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTicketNro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtTicketNro.Location = new System.Drawing.Point(94, 27);
            this.txtTicketNro.Name = "txtTicketNro";
            this.txtTicketNro.ReadOnly = true;
            this.txtTicketNro.Size = new System.Drawing.Size(120, 20);
            this.txtTicketNro.TabIndex = 2;
            this.txtTicketNro.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.cbDomain);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtUser);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(7, 93);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(430, 85);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Usuario de Red";
            // 
            // cbDomain
            // 
            this.cbDomain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbDomain.DisplayMember = "Nombre";
            this.cbDomain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDomain.FormattingEnabled = true;
            this.cbDomain.Location = new System.Drawing.Point(87, 25);
            this.cbDomain.Name = "cbDomain";
            this.cbDomain.Size = new System.Drawing.Size(320, 21);
            this.cbDomain.Sorted = true;
            this.cbDomain.TabIndex = 1;
            this.cbDomain.ValueMember = "Id";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Usuario:";
            // 
            // txtUser
            // 
            this.txtUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtUser.Location = new System.Drawing.Point(86, 51);
            this.txtUser.MaxLength = 50;
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(320, 20);
            this.txtUser.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Dominio:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.cbAplicacion);
            this.groupBox3.Controls.Add(this.txtUsername);
            this.groupBox3.Location = new System.Drawing.Point(7, 182);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(430, 85);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Aplicación";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Aplicación:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Usuario:";
            // 
            // cbAplicacion
            // 
            this.cbAplicacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbAplicacion.DisplayMember = "Nombre";
            this.cbAplicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAplicacion.FormattingEnabled = true;
            this.cbAplicacion.Location = new System.Drawing.Point(87, 19);
            this.cbAplicacion.Name = "cbAplicacion";
            this.cbAplicacion.Size = new System.Drawing.Size(320, 21);
            this.cbAplicacion.Sorted = true;
            this.cbAplicacion.TabIndex = 1;
            this.cbAplicacion.ValueMember = "Id";
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtUsername.Location = new System.Drawing.Point(87, 46);
            this.txtUsername.MaxLength = 50;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(320, 20);
            this.txtUsername.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(14, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Solicitante:";
            // 
            // txtSolicitante
            // 
            this.txtSolicitante.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSolicitante.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtSolicitante.Location = new System.Drawing.Point(94, 53);
            this.txtSolicitante.Name = "txtSolicitante";
            this.txtSolicitante.ReadOnly = true;
            this.txtSolicitante.Size = new System.Drawing.Size(122, 20);
            this.txtSolicitante.TabIndex = 6;
            this.txtSolicitante.TabStop = false;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(240, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Fecha AyC:";
            // 
            // txtFechaAyC
            // 
            this.txtFechaAyC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFechaAyC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtFechaAyC.Location = new System.Drawing.Point(315, 53);
            this.txtFechaAyC.Name = "txtFechaAyC";
            this.txtFechaAyC.ReadOnly = true;
            this.txtFechaAyC.Size = new System.Drawing.Size(122, 20);
            this.txtFechaAyC.TabIndex = 8;
            this.txtFechaAyC.TabStop = false;
            // 
            // FABMNotifBlanqueo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(471, 436);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtFechaAyC);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtSolicitante);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtTicketNro);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.lblFolioTit);
            this.Controls.Add(this.lblFolioNro);
            this.Controls.Add(this.lps);
            this.Name = "FABMNotifBlanqueo";
            this.Load += new System.EventHandler(this.FABMDBPwd_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.lps, 0);
            this.Controls.SetChildIndex(this.lblFolioNro, 0);
            this.Controls.SetChildIndex(this.lblFolioTit, 0);
            this.Controls.SetChildIndex(this.txtFecha, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtTicketNro, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.txtSolicitante, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txtFechaAyC, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.lps.ResumeLayout(false);
            this.lps.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Label lblFolioTit;
        protected System.Windows.Forms.Label lblFolioNro;
        protected System.Windows.Forms.GroupBox lps;
        private System.Windows.Forms.CheckBox chkVisualizar;
        protected System.Windows.Forms.TextBox tPassword2;
        protected System.Windows.Forms.Label label4;
        protected System.Windows.Forms.TextBox tPassword1;
        protected System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        protected System.Windows.Forms.TextBox txtFecha;
        protected System.Windows.Forms.TextBox txtTicketNro;
        protected System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        protected System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label5;
        protected System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbAplicacion;
        protected System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.ComboBox cbDomain;
        private System.Windows.Forms.Label label8;
        protected System.Windows.Forms.TextBox txtSolicitante;
        private System.Windows.Forms.Label label9;
        protected System.Windows.Forms.TextBox txtFechaAyC;


    }
}
