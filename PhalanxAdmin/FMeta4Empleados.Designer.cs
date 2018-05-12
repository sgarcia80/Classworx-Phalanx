namespace PhalanxAdmin
{
    partial class FMeta4Empleados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMeta4Empleados));
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtFilApellido = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFilNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtFilUsuario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.statusbar = new System.Windows.Forms.StatusStrip();
            this.pbDB = new System.Windows.Forms.ToolStripProgressBar();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lnkCancelar = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlList = new System.Windows.Forms.Panel();
            this.lvLista = new System.Windows.Forms.ListView();
            this.col_UsuarioRed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_Nombre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_Apellido = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_TipoDocumento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_Documento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_FechaNacimiento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_Calle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_Numero = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_Piso = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_Departamento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_EstadoCivil = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_EMail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.bwRefreshEntities = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.pnlXPGrps)).BeginInit();
            this.pnlXPGrps.SuspendLayout();
            this.pnlIzq.SuspendLayout();
            this.pnlFilters.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusbar.SuspendLayout();
            this.pnlList.SuspendLayout();
            this.SuspendLayout();
            // 
            // xppnlTC
            // 
            this.xppnlTC.ImageItems.ImageSet = null;
            this.xppnlTC.Location = new System.Drawing.Point(8, 135);
            // 
            // pnlXPGrps
            // 
            this.pnlXPGrps.Size = new System.Drawing.Size(200, 536);
            // 
            // pnlIzq
            // 
            this.pnlIzq.Size = new System.Drawing.Size(200, 536);
            // 
            // xppnlMenu
            // 
            this.xppnlMenu.ImageItems.ImageSet = null;
            // 
            // pnlFilters
            // 
            this.pnlFilters.Controls.Add(this.groupBox1);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Location = new System.Drawing.Point(200, 0);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(830, 95);
            this.pnlFilters.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtFilApellido);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtFilNombre);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.txtFilUsuario);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(18, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 82);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de búsqueda";
            // 
            // txtFilApellido
            // 
            this.txtFilApellido.Location = new System.Drawing.Point(310, 47);
            this.txtFilApellido.Name = "txtFilApellido";
            this.txtFilApellido.Size = new System.Drawing.Size(222, 20);
            this.txtFilApellido.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(260, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Apellido";
            // 
            // txtFilNombre
            // 
            this.txtFilNombre.Location = new System.Drawing.Point(93, 46);
            this.txtFilNombre.Name = "txtFilNombre";
            this.txtFilNombre.Size = new System.Drawing.Size(120, 20);
            this.txtFilNombre.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Nombre";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.SystemColors.Control;
            this.btnLimpiar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnLimpiar.Location = new System.Drawing.Point(675, 46);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(76, 21);
            this.btnLimpiar.TabIndex = 18;
            this.btnLimpiar.Text = "&Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.SystemColors.Control;
            this.btnBuscar.Location = new System.Drawing.Point(593, 46);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(76, 21);
            this.btnBuscar.TabIndex = 17;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtFilUsuario
            // 
            this.txtFilUsuario.Location = new System.Drawing.Point(93, 20);
            this.txtFilUsuario.Name = "txtFilUsuario";
            this.txtFilUsuario.Size = new System.Drawing.Size(120, 20);
            this.txtFilUsuario.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Usuario";
            // 
            // statusbar
            // 
            this.statusbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pbDB,
            this.lblStatus,
            this.lnkCancelar});
            this.statusbar.Location = new System.Drawing.Point(200, 514);
            this.statusbar.Name = "statusbar";
            this.statusbar.Size = new System.Drawing.Size(830, 22);
            this.statusbar.TabIndex = 2;
            this.statusbar.Text = "statusStrip1";
            // 
            // pbDB
            // 
            this.pbDB.Name = "pbDB";
            this.pbDB.Size = new System.Drawing.Size(100, 16);
            this.pbDB.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(133, 17);
            this.lblStatus.Text = "Ejecutando búsqueda ...";
            // 
            // lnkCancelar
            // 
            this.lnkCancelar.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkCancelar.IsLink = true;
            this.lnkCancelar.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkCancelar.Name = "lnkCancelar";
            this.lnkCancelar.Size = new System.Drawing.Size(53, 17);
            this.lnkCancelar.Text = "Cancelar";
            this.lnkCancelar.ToolTipText = "Cancela la ejecución actual";
            // 
            // pnlList
            // 
            this.pnlList.Controls.Add(this.lvLista);
            this.pnlList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlList.Location = new System.Drawing.Point(200, 95);
            this.pnlList.Name = "pnlList";
            this.pnlList.Size = new System.Drawing.Size(830, 419);
            this.pnlList.TabIndex = 1;
            // 
            // lvLista
            // 
            this.lvLista.AllowColumnReorder = true;
            this.lvLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvLista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_UsuarioRed,
            this.col_Nombre,
            this.col_Apellido,
            this.col_TipoDocumento,
            this.col_Documento,
            this.col_FechaNacimiento,
            this.col_Calle,
            this.col_Numero,
            this.col_Piso,
            this.col_Departamento,
            this.col_EstadoCivil,
            this.col_EMail});
            this.lvLista.FullRowSelect = true;
            this.lvLista.HideSelection = false;
            this.lvLista.Location = new System.Drawing.Point(18, 6);
            this.lvLista.Name = "lvLista";
            this.lvLista.Size = new System.Drawing.Size(800, 338);
            this.lvLista.SmallImageList = this.imageList;
            this.lvLista.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvLista.TabIndex = 0;
            this.lvLista.UseCompatibleStateImageBehavior = false;
            this.lvLista.View = System.Windows.Forms.View.Details;
            this.lvLista.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvLista_ColumnClick);
            // 
            // col_UsuarioRed
            // 
            this.col_UsuarioRed.Text = "Usuario";
            this.col_UsuarioRed.Width = 100;
            // 
            // col_Nombre
            // 
            this.col_Nombre.Text = "Nombre";
            this.col_Nombre.Width = 160;
            // 
            // col_Apellido
            // 
            this.col_Apellido.Text = "Apellido";
            this.col_Apellido.Width = 160;
            // 
            // col_TipoDocumento
            // 
            this.col_TipoDocumento.Text = "Tipo Doc.";
            this.col_TipoDocumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.col_TipoDocumento.Width = 90;
            // 
            // col_Documento
            // 
            this.col_Documento.Text = "Documento";
            this.col_Documento.Width = 80;
            // 
            // col_FechaNacimiento
            // 
            this.col_FechaNacimiento.Tag = "ddMMyyyy";
            this.col_FechaNacimiento.Text = "Fecha Nacimiento";
            this.col_FechaNacimiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.col_FechaNacimiento.Width = 120;
            // 
            // col_Calle
            // 
            this.col_Calle.Text = "Calle";
            this.col_Calle.Width = 170;
            // 
            // col_Numero
            // 
            this.col_Numero.Text = "Numero";
            this.col_Numero.Width = 70;
            // 
            // col_Piso
            // 
            this.col_Piso.Text = "Piso";
            this.col_Piso.Width = 70;
            // 
            // col_Departamento
            // 
            this.col_Departamento.Text = "Departamento";
            this.col_Departamento.Width = 70;
            // 
            // col_EstadoCivil
            // 
            this.col_EstadoCivil.Text = "Estado Civil";
            this.col_EstadoCivil.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.col_EstadoCivil.Width = 90;
            // 
            // col_EMail
            // 
            this.col_EMail.Text = "Email";
            this.col_EMail.Width = 160;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Active.jpg");
            this.imageList.Images.SetKeyName(1, "Desactivo.jpg");
            // 
            // bwRefreshEntities
            // 
            this.bwRefreshEntities.WorkerReportsProgress = true;
            this.bwRefreshEntities.WorkerSupportsCancellation = true;
            this.bwRefreshEntities.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwRefreshEntities_DoWork);
            this.bwRefreshEntities.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwRefreshEntities_RunWorkerCompleted);
            // 
            // FMeta4Empleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1030, 536);
            this.Controls.Add(this.pnlList);
            this.Controls.Add(this.statusbar);
            this.Controls.Add(this.pnlFilters);
            this.Name = "FMeta4Empleados";
            this.Load += new System.EventHandler(this.FEquiposWin_Load);
            this.Controls.SetChildIndex(this.pnlIzq, 0);
            this.Controls.SetChildIndex(this.pnlFilters, 0);
            this.Controls.SetChildIndex(this.statusbar, 0);
            this.Controls.SetChildIndex(this.pnlList, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pnlXPGrps)).EndInit();
            this.pnlXPGrps.ResumeLayout(false);
            this.pnlIzq.ResumeLayout(false);
            this.pnlFilters.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusbar.ResumeLayout(false);
            this.statusbar.PerformLayout();
            this.pnlList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlFilters;
        protected System.Windows.Forms.GroupBox groupBox1;
        protected System.Windows.Forms.Button btnLimpiar;
        protected System.Windows.Forms.Button btnBuscar;
        protected System.Windows.Forms.TextBox txtFilUsuario;
        protected System.Windows.Forms.Label label2;
        private System.Windows.Forms.StatusStrip statusbar;
        private System.Windows.Forms.ToolStripProgressBar pbDB;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lnkCancelar;
        private System.Windows.Forms.Panel pnlList;
        protected System.Windows.Forms.ListView lvLista;
        private System.ComponentModel.BackgroundWorker bwRefreshEntities;
        private System.Windows.Forms.ImageList imageList;
        protected System.Windows.Forms.TextBox txtFilNombre;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.TextBox txtFilApellido;
        protected System.Windows.Forms.Label label5;
        private System.Windows.Forms.ColumnHeader col_UsuarioRed;
        private System.Windows.Forms.ColumnHeader col_Nombre;
        private System.Windows.Forms.ColumnHeader col_Apellido;
        private System.Windows.Forms.ColumnHeader col_TipoDocumento;
        private System.Windows.Forms.ColumnHeader col_Documento;
        private System.Windows.Forms.ColumnHeader col_FechaNacimiento;
        private System.Windows.Forms.ColumnHeader col_Calle;
        private System.Windows.Forms.ColumnHeader col_Numero;
        private System.Windows.Forms.ColumnHeader col_Piso;
        private System.Windows.Forms.ColumnHeader col_Departamento;
        private System.Windows.Forms.ColumnHeader col_EstadoCivil;
        private System.Windows.Forms.ColumnHeader col_EMail;

    }
}
