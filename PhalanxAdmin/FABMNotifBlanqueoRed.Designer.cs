namespace PhalanxAdmin
{
    partial class FABMNotifBlanqueoRed
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FABMNotifBlanqueoRed));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtUsuarioNombre = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtUsuarioOfic = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtUsuarioDpto = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtUsuarioProv = new System.Windows.Forms.TextBox();
            this.picActivo = new System.Windows.Forms.PictureBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.chkVisualizar = new System.Windows.Forms.CheckBox();
            this.tPassword1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbDomain = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtUsuarioCarga = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtFechaAyC = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSolicitanteOfic = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSolicitanteDpto = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSolicitanteNombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSolicitanteProv = new System.Windows.Forms.TextBox();
            this.picSolicitante = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSolicitantePuesto = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSolicitante = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picActivo)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSolicitante)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 331);
            this.groupBox1.Size = new System.Drawing.Size(673, 43);
            this.groupBox1.TabIndex = 11;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(277, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Fecha Envio:";
            // 
            // txtFecha
            // 
            this.txtFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtFecha.Location = new System.Drawing.Point(370, 27);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.ReadOnly = true;
            this.txtFecha.Size = new System.Drawing.Size(94, 20);
            this.txtFecha.TabIndex = 6;
            this.txtFecha.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.txtUsuarioNombre);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtUsuarioOfic);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.txtUsuarioDpto);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.txtUsuarioProv);
            this.groupBox2.Controls.Add(this.picActivo);
            this.groupBox2.Controls.Add(this.btnGenerar);
            this.groupBox2.Controls.Add(this.chkVisualizar);
            this.groupBox2.Controls.Add(this.tPassword1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cbDomain);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtUser);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(10, 192);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(653, 136);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos Usuario Red";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(7, 80);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(54, 13);
            this.label17.TabIndex = 4;
            this.label17.Text = "Nombre:";
            // 
            // txtUsuarioNombre
            // 
            this.txtUsuarioNombre.BackColor = System.Drawing.SystemColors.Control;
            this.txtUsuarioNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtUsuarioNombre.Location = new System.Drawing.Point(86, 77);
            this.txtUsuarioNombre.Name = "txtUsuarioNombre";
            this.txtUsuarioNombre.ReadOnly = true;
            this.txtUsuarioNombre.Size = new System.Drawing.Size(244, 20);
            this.txtUsuarioNombre.TabIndex = 5;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(343, 80);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "Oficina:";
            // 
            // txtUsuarioOfic
            // 
            this.txtUsuarioOfic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtUsuarioOfic.Location = new System.Drawing.Point(458, 77);
            this.txtUsuarioOfic.Name = "txtUsuarioOfic";
            this.txtUsuarioOfic.ReadOnly = true;
            this.txtUsuarioOfic.Size = new System.Drawing.Size(189, 20);
            this.txtUsuarioOfic.TabIndex = 14;
            this.txtUsuarioOfic.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(343, 54);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(90, 13);
            this.label15.TabIndex = 11;
            this.label15.Text = "Departamento:";
            // 
            // txtUsuarioDpto
            // 
            this.txtUsuarioDpto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtUsuarioDpto.Location = new System.Drawing.Point(458, 51);
            this.txtUsuarioDpto.Name = "txtUsuarioDpto";
            this.txtUsuarioDpto.ReadOnly = true;
            this.txtUsuarioDpto.Size = new System.Drawing.Size(189, 20);
            this.txtUsuarioDpto.TabIndex = 12;
            this.txtUsuarioDpto.TabStop = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(343, 28);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(109, 13);
            this.label16.TabIndex = 9;
            this.label16.Text = "Estado/Provincia:";
            // 
            // txtUsuarioProv
            // 
            this.txtUsuarioProv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtUsuarioProv.Location = new System.Drawing.Point(458, 25);
            this.txtUsuarioProv.Name = "txtUsuarioProv";
            this.txtUsuarioProv.ReadOnly = true;
            this.txtUsuarioProv.Size = new System.Drawing.Size(189, 20);
            this.txtUsuarioProv.TabIndex = 10;
            this.txtUsuarioProv.TabStop = false;
            // 
            // picActivo
            // 
            this.picActivo.ErrorImage = null;
            this.picActivo.Image = ((System.Drawing.Image)(resources.GetObject("picActivo.Image")));
            this.picActivo.Location = new System.Drawing.Point(239, 51);
            this.picActivo.Margin = new System.Windows.Forms.Padding(0);
            this.picActivo.Name = "picActivo";
            this.picActivo.Size = new System.Drawing.Size(22, 17);
            this.picActivo.TabIndex = 48;
            this.picActivo.TabStop = false;
            this.picActivo.Visible = false;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(239, 102);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(61, 23);
            this.btnGenerar.TabIndex = 8;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // chkVisualizar
            // 
            this.chkVisualizar.AutoSize = true;
            this.chkVisualizar.Location = new System.Drawing.Point(346, 106);
            this.chkVisualizar.Name = "chkVisualizar";
            this.chkVisualizar.Size = new System.Drawing.Size(126, 17);
            this.chkVisualizar.TabIndex = 15;
            this.chkVisualizar.Text = "Visualizar contraseña";
            this.chkVisualizar.UseVisualStyleBackColor = true;
            this.chkVisualizar.CheckedChanged += new System.EventHandler(this.chkVisualizar_CheckedChanged);
            // 
            // tPassword1
            // 
            this.tPassword1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tPassword1.Location = new System.Drawing.Point(86, 103);
            this.tPassword1.MaxLength = 50;
            this.tPassword1.Name = "tPassword1";
            this.tPassword1.PasswordChar = '*';
            this.tPassword1.ReadOnly = true;
            this.tPassword1.Size = new System.Drawing.Size(147, 22);
            this.tPassword1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Contraseña";
            // 
            // cbDomain
            // 
            this.cbDomain.DisplayMember = "Nombre";
            this.cbDomain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDomain.FormattingEnabled = true;
            this.cbDomain.Location = new System.Drawing.Point(87, 25);
            this.cbDomain.Name = "cbDomain";
            this.cbDomain.Size = new System.Drawing.Size(147, 21);
            this.cbDomain.Sorted = true;
            this.cbDomain.TabIndex = 1;
            this.cbDomain.ValueMember = "Id";
            this.cbDomain.SelectedIndexChanged += new System.EventHandler(this.cbDomain_SelectedIndexChanged);
            // 
            // label7
            // 
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
            this.txtUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtUser.Location = new System.Drawing.Point(87, 51);
            this.txtUser.MaxLength = 50;
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(147, 20);
            this.txtUser.TabIndex = 3;
            this.txtUser.Validating += new System.ComponentModel.CancelEventHandler(this.txtUser_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Dominio:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(17, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Cargado por:";
            // 
            // txtUsuarioCarga
            // 
            this.txtUsuarioCarga.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtUsuarioCarga.Location = new System.Drawing.Point(97, 27);
            this.txtUsuarioCarga.Name = "txtUsuarioCarga";
            this.txtUsuarioCarga.ReadOnly = true;
            this.txtUsuarioCarga.Size = new System.Drawing.Size(147, 20);
            this.txtUsuarioCarga.TabIndex = 2;
            this.txtUsuarioCarga.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(277, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Fecha Notif.:";
            // 
            // txtFechaAyC
            // 
            this.txtFechaAyC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtFechaAyC.Location = new System.Drawing.Point(370, 53);
            this.txtFechaAyC.Name = "txtFechaAyC";
            this.txtFechaAyC.ReadOnly = true;
            this.txtFechaAyC.Size = new System.Drawing.Size(94, 20);
            this.txtFechaAyC.TabIndex = 8;
            this.txtFechaAyC.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(17, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "Estado:";
            // 
            // txtEstado
            // 
            this.txtEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtEstado.Location = new System.Drawing.Point(96, 53);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(147, 20);
            this.txtEstado.TabIndex = 4;
            this.txtEstado.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.txtSolicitanteOfic);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.txtSolicitanteDpto);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtSolicitanteNombre);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtSolicitanteProv);
            this.groupBox3.Controls.Add(this.picSolicitante);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtSolicitantePuesto);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtSolicitante);
            this.groupBox3.Location = new System.Drawing.Point(10, 85);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(653, 101);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos Solicitante";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(343, 74);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 13);
            this.label13.TabIndex = 10;
            this.label13.Text = "Oficina:";
            // 
            // txtSolicitanteOfic
            // 
            this.txtSolicitanteOfic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtSolicitanteOfic.Location = new System.Drawing.Point(458, 71);
            this.txtSolicitanteOfic.Name = "txtSolicitanteOfic";
            this.txtSolicitanteOfic.ReadOnly = true;
            this.txtSolicitanteOfic.Size = new System.Drawing.Size(189, 20);
            this.txtSolicitanteOfic.TabIndex = 11;
            this.txtSolicitanteOfic.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(343, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "Departamento:";
            // 
            // txtSolicitanteDpto
            // 
            this.txtSolicitanteDpto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtSolicitanteDpto.Location = new System.Drawing.Point(458, 45);
            this.txtSolicitanteDpto.Name = "txtSolicitanteDpto";
            this.txtSolicitanteDpto.ReadOnly = true;
            this.txtSolicitanteDpto.Size = new System.Drawing.Size(189, 20);
            this.txtSolicitanteDpto.TabIndex = 9;
            this.txtSolicitanteDpto.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Nombre:";
            // 
            // txtSolicitanteNombre
            // 
            this.txtSolicitanteNombre.BackColor = System.Drawing.SystemColors.Control;
            this.txtSolicitanteNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtSolicitanteNombre.Location = new System.Drawing.Point(86, 45);
            this.txtSolicitanteNombre.Name = "txtSolicitanteNombre";
            this.txtSolicitanteNombre.ReadOnly = true;
            this.txtSolicitanteNombre.Size = new System.Drawing.Size(244, 20);
            this.txtSolicitanteNombre.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(343, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Estado/Provincia:";
            // 
            // txtSolicitanteProv
            // 
            this.txtSolicitanteProv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtSolicitanteProv.Location = new System.Drawing.Point(458, 19);
            this.txtSolicitanteProv.Name = "txtSolicitanteProv";
            this.txtSolicitanteProv.ReadOnly = true;
            this.txtSolicitanteProv.Size = new System.Drawing.Size(189, 20);
            this.txtSolicitanteProv.TabIndex = 7;
            this.txtSolicitanteProv.TabStop = false;
            // 
            // picSolicitante
            // 
            this.picSolicitante.ErrorImage = null;
            this.picSolicitante.Image = ((System.Drawing.Image)(resources.GetObject("picSolicitante.Image")));
            this.picSolicitante.Location = new System.Drawing.Point(239, 19);
            this.picSolicitante.Margin = new System.Windows.Forms.Padding(0);
            this.picSolicitante.Name = "picSolicitante";
            this.picSolicitante.Size = new System.Drawing.Size(22, 17);
            this.picSolicitante.TabIndex = 54;
            this.picSolicitante.TabStop = false;
            this.picSolicitante.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Puesto:";
            // 
            // txtSolicitantePuesto
            // 
            this.txtSolicitantePuesto.BackColor = System.Drawing.SystemColors.Control;
            this.txtSolicitantePuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtSolicitantePuesto.Location = new System.Drawing.Point(86, 71);
            this.txtSolicitantePuesto.Name = "txtSolicitantePuesto";
            this.txtSolicitantePuesto.ReadOnly = true;
            this.txtSolicitantePuesto.Size = new System.Drawing.Size(244, 20);
            this.txtSolicitantePuesto.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(7, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Solicitante:";
            // 
            // txtSolicitante
            // 
            this.txtSolicitante.BackColor = System.Drawing.SystemColors.Window;
            this.txtSolicitante.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtSolicitante.Location = new System.Drawing.Point(87, 19);
            this.txtSolicitante.Name = "txtSolicitante";
            this.txtSolicitante.Size = new System.Drawing.Size(147, 20);
            this.txtSolicitante.TabIndex = 1;
            this.txtSolicitante.Validating += new System.ComponentModel.CancelEventHandler(this.txtSolicitante_Validating);
            // 
            // FABMNotifBlanqueoRed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(673, 374);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtFechaAyC);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtUsuarioCarga);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFecha);
            this.Name = "FABMNotifBlanqueoRed";
            this.Load += new System.EventHandler(this.FABMDBPwd_Load);
            this.Controls.SetChildIndex(this.txtFecha, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.txtUsuarioCarga, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txtFechaAyC, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.txtEstado, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picActivo)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSolicitante)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Label label2;
        protected System.Windows.Forms.TextBox txtFecha;
        protected System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        protected System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbDomain;
        private System.Windows.Forms.Label label8;
        protected System.Windows.Forms.TextBox txtUsuarioCarga;
        private System.Windows.Forms.Label label9;
        protected System.Windows.Forms.TextBox txtFechaAyC;
        private System.Windows.Forms.Label label11;
        protected System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.CheckBox chkVisualizar;
        protected System.Windows.Forms.TextBox tPassword1;
        protected System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picActivo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label12;
        protected System.Windows.Forms.TextBox txtSolicitanteDpto;
        private System.Windows.Forms.Label label6;
        protected System.Windows.Forms.TextBox txtSolicitanteNombre;
        private System.Windows.Forms.Label label4;
        protected System.Windows.Forms.TextBox txtSolicitanteProv;
        private System.Windows.Forms.PictureBox picSolicitante;
        private System.Windows.Forms.Label label3;
        protected System.Windows.Forms.TextBox txtSolicitantePuesto;
        private System.Windows.Forms.Label label10;
        protected System.Windows.Forms.TextBox txtSolicitante;
        private System.Windows.Forms.Label label13;
        protected System.Windows.Forms.TextBox txtSolicitanteOfic;
        private System.Windows.Forms.Label label17;
        protected System.Windows.Forms.TextBox txtUsuarioNombre;
        private System.Windows.Forms.Label label14;
        protected System.Windows.Forms.TextBox txtUsuarioOfic;
        private System.Windows.Forms.Label label15;
        protected System.Windows.Forms.TextBox txtUsuarioDpto;
        private System.Windows.Forms.Label label16;
        protected System.Windows.Forms.TextBox txtUsuarioProv;
    }
}
