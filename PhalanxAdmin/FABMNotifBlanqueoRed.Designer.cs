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
            this.lblFolioNro = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
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
            this.label10 = new System.Windows.Forms.Label();
            this.txtSolicitante = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.picActivo = new System.Windows.Forms.PictureBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picActivo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 265);
            this.groupBox1.Size = new System.Drawing.Size(538, 43);
            this.groupBox1.TabIndex = 16;
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
            // lblFolioNro
            // 
            this.lblFolioNro.AutoSize = true;
            this.lblFolioNro.Location = new System.Drawing.Point(92, 198);
            this.lblFolioNro.Name = "lblFolioNro";
            this.lblFolioNro.Size = new System.Drawing.Size(0, 13);
            this.lblFolioNro.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(306, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha Envio:";
            // 
            // txtFecha
            // 
            this.txtFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtFecha.Location = new System.Drawing.Point(395, 27);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.ReadOnly = true;
            this.txtFecha.Size = new System.Drawing.Size(122, 20);
            this.txtFecha.TabIndex = 4;
            this.txtFecha.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.picActivo);
            this.groupBox2.Controls.Add(this.btnGenerar);
            this.groupBox2.Controls.Add(this.chkVisualizar);
            this.groupBox2.Controls.Add(this.tPassword1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cbDomain);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtUser);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(10, 113);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(507, 140);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Usuario de Red";
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(413, 76);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(61, 23);
            this.btnGenerar.TabIndex = 10;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // chkVisualizar
            // 
            this.chkVisualizar.AutoSize = true;
            this.chkVisualizar.Location = new System.Drawing.Point(86, 106);
            this.chkVisualizar.Name = "chkVisualizar";
            this.chkVisualizar.Size = new System.Drawing.Size(126, 17);
            this.chkVisualizar.TabIndex = 9;
            this.chkVisualizar.Text = "Visualizar contraseña";
            this.chkVisualizar.UseVisualStyleBackColor = true;
            this.chkVisualizar.CheckedChanged += new System.EventHandler(this.chkVisualizar_CheckedChanged);
            // 
            // tPassword1
            // 
            this.tPassword1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tPassword1.Location = new System.Drawing.Point(87, 77);
            this.tPassword1.MaxLength = 50;
            this.tPassword1.Name = "tPassword1";
            this.tPassword1.PasswordChar = '*';
            this.tPassword1.ReadOnly = true;
            this.tPassword1.Size = new System.Drawing.Size(320, 22);
            this.tPassword1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Contraseña";
            // 
            // cbDomain
            // 
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
            this.txtUser.Size = new System.Drawing.Size(320, 20);
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
            this.txtUsuarioCarga.Size = new System.Drawing.Size(176, 20);
            this.txtUsuarioCarga.TabIndex = 2;
            this.txtUsuarioCarga.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(306, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Fecha Notif.:";
            // 
            // txtFechaAyC
            // 
            this.txtFechaAyC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtFechaAyC.Location = new System.Drawing.Point(395, 79);
            this.txtFechaAyC.Name = "txtFechaAyC";
            this.txtFechaAyC.ReadOnly = true;
            this.txtFechaAyC.Size = new System.Drawing.Size(122, 20);
            this.txtFechaAyC.TabIndex = 12;
            this.txtFechaAyC.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(17, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Solicitante:";
            // 
            // txtSolicitante
            // 
            this.txtSolicitante.BackColor = System.Drawing.SystemColors.Window;
            this.txtSolicitante.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtSolicitante.Location = new System.Drawing.Point(97, 53);
            this.txtSolicitante.Name = "txtSolicitante";
            this.txtSolicitante.Size = new System.Drawing.Size(176, 20);
            this.txtSolicitante.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(306, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "Estado:";
            // 
            // txtEstado
            // 
            this.txtEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtEstado.Location = new System.Drawing.Point(395, 53);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(122, 20);
            this.txtEstado.TabIndex = 8;
            this.txtEstado.TabStop = false;
            // 
            // picActivo
            // 
            this.picActivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picActivo.ErrorImage = null;
            this.picActivo.Image = ((System.Drawing.Image)(resources.GetObject("picActivo.Image")));
            this.picActivo.Location = new System.Drawing.Point(413, 54);
            this.picActivo.Margin = new System.Windows.Forms.Padding(0);
            this.picActivo.Name = "picActivo";
            this.picActivo.Size = new System.Drawing.Size(22, 17);
            this.picActivo.TabIndex = 48;
            this.picActivo.TabStop = false;
            this.picActivo.Visible = false;
            // 
            // FABMNotifBlanqueoRed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(538, 308);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtSolicitante);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtFechaAyC);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtUsuarioCarga);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.lblFolioNro);
            this.Name = "FABMNotifBlanqueoRed";
            this.Load += new System.EventHandler(this.FABMDBPwd_Load);
            this.Controls.SetChildIndex(this.lblFolioNro, 0);
            this.Controls.SetChildIndex(this.txtFecha, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.txtUsuarioCarga, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txtFechaAyC, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.txtSolicitante, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.txtEstado, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picActivo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList;
        protected System.Windows.Forms.Label lblFolioNro;
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
        private System.Windows.Forms.Label label10;
        protected System.Windows.Forms.TextBox txtSolicitante;
        private System.Windows.Forms.Label label11;
        protected System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.CheckBox chkVisualizar;
        protected System.Windows.Forms.TextBox tPassword1;
        protected System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picActivo;


    }
}
