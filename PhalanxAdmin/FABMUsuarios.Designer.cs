namespace PhalanxAdmin
{
    partial class FABMUsuarios
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
			System.Windows.Forms.ColumnHeader columnHeader2;
			System.Windows.Forms.ColumnHeader columnHeader1;
			System.Windows.Forms.ColumnHeader columnHeader3;
			System.Windows.Forms.ColumnHeader columnHeader4;
			System.Windows.Forms.ColumnHeader columnHeader5;
			System.Windows.Forms.ColumnHeader columnHeader6;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FABMUsuarios));
			this.pnlABMPhxUsers = new System.Windows.Forms.Panel();
			this.tabUsuario = new System.Windows.Forms.TabControl();
			this.tpgDatosUsr = new System.Windows.Forms.TabPage();
			this.btnCargarDatos = new System.Windows.Forms.Button();
			this.cbSuperior = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.chkActivo = new System.Windows.Forms.CheckBox();
			this.lblPiso = new System.Windows.Forms.Label();
			this.txtPiso = new System.Windows.Forms.TextBox();
			this.cboEdificio = new System.Windows.Forms.ComboBox();
			this.cboRelacionLaboral = new System.Windows.Forms.ComboBox();
			this.lblEdificio = new System.Windows.Forms.Label();
			this.lblSector = new System.Windows.Forms.Label();
			this.lblInterno = new System.Windows.Forms.Label();
			this.lblFuncion = new System.Windows.Forms.Label();
			this.lblRelLaboral = new System.Windows.Forms.Label();
			this.txtSector = new System.Windows.Forms.TextBox();
			this.txtFuncion = new System.Windows.Forms.TextBox();
			this.txtInterno = new System.Windows.Forms.TextBox();
			this.txtLegajo = new System.Windows.Forms.TextBox();
			this.lblLegajo = new System.Windows.Forms.Label();
			this.cbDominio = new System.Windows.Forms.ComboBox();
			this.txtFullName = new System.Windows.Forms.TextBox();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.txtUserName = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lblNombreUsuario = new System.Windows.Forms.Label();
			this.tpgPermisosUsr = new System.Windows.Forms.TabPage();
			this.pnlPermisosUsr = new System.Windows.Forms.Panel();
			this.lvPermisosUsr = new System.Windows.Forms.ListView();
			this.pnlPermisosEdit = new System.Windows.Forms.Panel();
			this.btnDelRole = new System.Windows.Forms.Button();
			this.btnDelAllRoles = new System.Windows.Forms.Button();
			this.btnAddAllRoles = new System.Windows.Forms.Button();
			this.btnAddRole = new System.Windows.Forms.Button();
			this.lvPermisosDB = new System.Windows.Forms.ListView();
			this.tpgGruposUsr = new System.Windows.Forms.TabPage();
			this.pnlGruposUsr = new System.Windows.Forms.Panel();
			this.lvGruposUsr = new System.Windows.Forms.ListView();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.pnlGruposEdit = new System.Windows.Forms.Panel();
			this.btnDelGroup = new System.Windows.Forms.Button();
			this.btnDelAllGroups = new System.Windows.Forms.Button();
			this.btnAddAllGroups = new System.Windows.Forms.Button();
			this.btnAddGroup = new System.Windows.Forms.Button();
			this.lvGruposDB = new System.Windows.Forms.ListView();
			this.tpgGruposSeguimUsr = new System.Windows.Forms.TabPage();
			this.panel4 = new System.Windows.Forms.Panel();
			this.lvGruposSeguimUsr = new System.Windows.Forms.ListView();
			this.pnlGuposSegEdit = new System.Windows.Forms.Panel();
			this.btnDelGroupSeguim = new System.Windows.Forms.Button();
			this.btnDelAllGroupsSeguim = new System.Windows.Forms.Button();
			this.btnAddAllGroupsSeguim = new System.Windows.Forms.Button();
			this.btnAddGroupSeguim = new System.Windows.Forms.Button();
			this.lvGruposSeguimDB = new System.Windows.Forms.ListView();
			columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.pnlABMPhxUsers.SuspendLayout();
			this.tabUsuario.SuspendLayout();
			this.tpgDatosUsr.SuspendLayout();
			this.tpgPermisosUsr.SuspendLayout();
			this.pnlPermisosUsr.SuspendLayout();
			this.pnlPermisosEdit.SuspendLayout();
			this.tpgGruposUsr.SuspendLayout();
			this.pnlGruposUsr.SuspendLayout();
			this.pnlGruposEdit.SuspendLayout();
			this.tpgGruposSeguimUsr.SuspendLayout();
			this.panel4.SuspendLayout();
			this.pnlGuposSegEdit.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(0, 345);
			this.groupBox1.Size = new System.Drawing.Size(604, 43);
			// 
			// btnAceptar
			// 
			this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// columnHeader2
			// 
			columnHeader2.Text = "Permisos del Usuario";
			columnHeader2.Width = 201;
			// 
			// columnHeader1
			// 
			columnHeader1.Text = "Permisos";
			columnHeader1.Width = 200;
			// 
			// columnHeader3
			// 
			columnHeader3.Text = "Grupos del Usuario";
			columnHeader3.Width = 201;
			// 
			// columnHeader4
			// 
			columnHeader4.Text = "Grupos";
			columnHeader4.Width = 200;
			// 
			// columnHeader5
			// 
			columnHeader5.Text = "Grupos";
			columnHeader5.Width = 200;
			// 
			// columnHeader6
			// 
			columnHeader6.Text = "Grupos del Usuario";
			columnHeader6.Width = 201;
			// 
			// pnlABMPhxUsers
			// 
			this.pnlABMPhxUsers.Controls.Add(this.tabUsuario);
			this.pnlABMPhxUsers.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlABMPhxUsers.Location = new System.Drawing.Point(0, 21);
			this.pnlABMPhxUsers.Name = "pnlABMPhxUsers";
			this.pnlABMPhxUsers.Size = new System.Drawing.Size(604, 324);
			this.pnlABMPhxUsers.TabIndex = 4;
			// 
			// tabUsuario
			// 
			this.tabUsuario.Controls.Add(this.tpgDatosUsr);
			this.tabUsuario.Controls.Add(this.tpgPermisosUsr);
			this.tabUsuario.Controls.Add(this.tpgGruposUsr);
			this.tabUsuario.Controls.Add(this.tpgGruposSeguimUsr);
			this.tabUsuario.Location = new System.Drawing.Point(13, 16);
			this.tabUsuario.Name = "tabUsuario";
			this.tabUsuario.SelectedIndex = 0;
			this.tabUsuario.Size = new System.Drawing.Size(577, 302);
			this.tabUsuario.TabIndex = 1;
			// 
			// tpgDatosUsr
			// 
			this.tpgDatosUsr.BackColor = System.Drawing.Color.WhiteSmoke;
			this.tpgDatosUsr.Controls.Add(this.btnCargarDatos);
			this.tpgDatosUsr.Controls.Add(this.cbSuperior);
			this.tpgDatosUsr.Controls.Add(this.label1);
			this.tpgDatosUsr.Controls.Add(this.chkActivo);
			this.tpgDatosUsr.Controls.Add(this.lblPiso);
			this.tpgDatosUsr.Controls.Add(this.txtPiso);
			this.tpgDatosUsr.Controls.Add(this.cboEdificio);
			this.tpgDatosUsr.Controls.Add(this.cboRelacionLaboral);
			this.tpgDatosUsr.Controls.Add(this.lblEdificio);
			this.tpgDatosUsr.Controls.Add(this.lblSector);
			this.tpgDatosUsr.Controls.Add(this.lblInterno);
			this.tpgDatosUsr.Controls.Add(this.lblFuncion);
			this.tpgDatosUsr.Controls.Add(this.lblRelLaboral);
			this.tpgDatosUsr.Controls.Add(this.txtSector);
			this.tpgDatosUsr.Controls.Add(this.txtFuncion);
			this.tpgDatosUsr.Controls.Add(this.txtInterno);
			this.tpgDatosUsr.Controls.Add(this.txtLegajo);
			this.tpgDatosUsr.Controls.Add(this.lblLegajo);
			this.tpgDatosUsr.Controls.Add(this.cbDominio);
			this.tpgDatosUsr.Controls.Add(this.txtFullName);
			this.tpgDatosUsr.Controls.Add(this.txtEmail);
			this.tpgDatosUsr.Controls.Add(this.txtUserName);
			this.tpgDatosUsr.Controls.Add(this.label4);
			this.tpgDatosUsr.Controls.Add(this.label3);
			this.tpgDatosUsr.Controls.Add(this.label2);
			this.tpgDatosUsr.Controls.Add(this.lblNombreUsuario);
			this.tpgDatosUsr.Location = new System.Drawing.Point(4, 22);
			this.tpgDatosUsr.Name = "tpgDatosUsr";
			this.tpgDatosUsr.Padding = new System.Windows.Forms.Padding(3);
			this.tpgDatosUsr.Size = new System.Drawing.Size(569, 276);
			this.tpgDatosUsr.TabIndex = 0;
			this.tpgDatosUsr.Text = "Datos";
			this.tpgDatosUsr.UseVisualStyleBackColor = true;
			// 
			// btnCargarDatos
			// 
			this.btnCargarDatos.Location = new System.Drawing.Point(435, 43);
			this.btnCargarDatos.Name = "btnCargarDatos";
			this.btnCargarDatos.Size = new System.Drawing.Size(128, 24);
			this.btnCargarDatos.TabIndex = 17;
			this.btnCargarDatos.Text = "Cargar datos desde AD";
			this.btnCargarDatos.UseVisualStyleBackColor = true;
			this.btnCargarDatos.Click += new System.EventHandler(this.btnCargarDatos_Click);
			// 
			// cbSuperior
			// 
			this.cbSuperior.DisplayMember = "{0,0,0}";
			this.cbSuperior.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSuperior.FormattingEnabled = true;
			this.cbSuperior.Location = new System.Drawing.Point(332, 155);
			this.cbSuperior.Name = "cbSuperior";
			this.cbSuperior.Size = new System.Drawing.Size(188, 21);
			this.cbSuperior.TabIndex = 7;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(329, 134);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 13);
			this.label1.TabIndex = 16;
			this.label1.Text = "Superior";
			// 
			// chkActivo
			// 
			this.chkActivo.AutoSize = true;
			this.chkActivo.Checked = true;
			this.chkActivo.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkActivo.Location = new System.Drawing.Point(464, 21);
			this.chkActivo.Name = "chkActivo";
			this.chkActivo.Size = new System.Drawing.Size(56, 17);
			this.chkActivo.TabIndex = 1;
			this.chkActivo.Text = "Activo";
			this.chkActivo.UseVisualStyleBackColor = true;
			// 
			// lblPiso
			// 
			this.lblPiso.AutoSize = true;
			this.lblPiso.Location = new System.Drawing.Point(317, 240);
			this.lblPiso.Name = "lblPiso";
			this.lblPiso.Size = new System.Drawing.Size(27, 13);
			this.lblPiso.TabIndex = 14;
			this.lblPiso.Text = "Piso";
			// 
			// txtPiso
			// 
			this.txtPiso.Location = new System.Drawing.Point(363, 237);
			this.txtPiso.MaxLength = 5;
			this.txtPiso.Name = "txtPiso";
			this.txtPiso.Size = new System.Drawing.Size(53, 20);
			this.txtPiso.TabIndex = 12;
			this.txtPiso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// cboEdificio
			// 
			this.cboEdificio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.cboEdificio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cboEdificio.FormattingEnabled = true;
			this.cboEdificio.Location = new System.Drawing.Point(169, 237);
			this.cboEdificio.MaxLength = 50;
			this.cboEdificio.Name = "cboEdificio";
			this.cboEdificio.Size = new System.Drawing.Size(142, 21);
			this.cboEdificio.TabIndex = 11;
			// 
			// cboRelacionLaboral
			// 
			this.cboRelacionLaboral.DisplayMember = "{0,0,0}";
			this.cboRelacionLaboral.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboRelacionLaboral.FormattingEnabled = true;
			this.cboRelacionLaboral.Location = new System.Drawing.Point(169, 155);
			this.cboRelacionLaboral.Name = "cboRelacionLaboral";
			this.cboRelacionLaboral.Size = new System.Drawing.Size(142, 21);
			this.cboRelacionLaboral.TabIndex = 6;
			this.cboRelacionLaboral.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboRelacionLaboral_KeyDown);
			// 
			// lblEdificio
			// 
			this.lblEdificio.AutoSize = true;
			this.lblEdificio.Location = new System.Drawing.Point(33, 239);
			this.lblEdificio.Name = "lblEdificio";
			this.lblEdificio.Size = new System.Drawing.Size(41, 13);
			this.lblEdificio.TabIndex = 10;
			this.lblEdificio.Text = "Edificio";
			// 
			// lblSector
			// 
			this.lblSector.AutoSize = true;
			this.lblSector.Location = new System.Drawing.Point(33, 212);
			this.lblSector.Name = "lblSector";
			this.lblSector.Size = new System.Drawing.Size(130, 13);
			this.lblSector.TabIndex = 9;
			this.lblSector.Text = "Sector/Sucursal/Empresa";
			// 
			// lblInterno
			// 
			this.lblInterno.AutoSize = true;
			this.lblInterno.Location = new System.Drawing.Point(317, 213);
			this.lblInterno.Name = "lblInterno";
			this.lblInterno.Size = new System.Drawing.Size(40, 13);
			this.lblInterno.TabIndex = 9;
			this.lblInterno.Text = "Interno";
			// 
			// lblFuncion
			// 
			this.lblFuncion.AutoSize = true;
			this.lblFuncion.Location = new System.Drawing.Point(33, 186);
			this.lblFuncion.Name = "lblFuncion";
			this.lblFuncion.Size = new System.Drawing.Size(45, 13);
			this.lblFuncion.TabIndex = 9;
			this.lblFuncion.Text = "Función";
			// 
			// lblRelLaboral
			// 
			this.lblRelLaboral.AutoSize = true;
			this.lblRelLaboral.Location = new System.Drawing.Point(33, 158);
			this.lblRelLaboral.Name = "lblRelLaboral";
			this.lblRelLaboral.Size = new System.Drawing.Size(87, 13);
			this.lblRelLaboral.TabIndex = 9;
			this.lblRelLaboral.Text = "Relación Laboral";
			// 
			// txtSector
			// 
			this.txtSector.Location = new System.Drawing.Point(169, 210);
			this.txtSector.MaxLength = 100;
			this.txtSector.Name = "txtSector";
			this.txtSector.Size = new System.Drawing.Size(142, 20);
			this.txtSector.TabIndex = 9;
			// 
			// txtFuncion
			// 
			this.txtFuncion.Location = new System.Drawing.Point(169, 183);
			this.txtFuncion.MaxLength = 50;
			this.txtFuncion.Name = "txtFuncion";
			this.txtFuncion.Size = new System.Drawing.Size(142, 20);
			this.txtFuncion.TabIndex = 8;
			// 
			// txtInterno
			// 
			this.txtInterno.Location = new System.Drawing.Point(363, 210);
			this.txtInterno.MaxLength = 4;
			this.txtInterno.Name = "txtInterno";
			this.txtInterno.Size = new System.Drawing.Size(53, 20);
			this.txtInterno.TabIndex = 10;
			this.txtInterno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtLegajo
			// 
			this.txtLegajo.Location = new System.Drawing.Point(169, 128);
			this.txtLegajo.MaxLength = 10;
			this.txtLegajo.Name = "txtLegajo";
			this.txtLegajo.Size = new System.Drawing.Size(142, 20);
			this.txtLegajo.TabIndex = 5;
			this.txtLegajo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblLegajo
			// 
			this.lblLegajo.AutoSize = true;
			this.lblLegajo.Location = new System.Drawing.Point(33, 131);
			this.lblLegajo.Name = "lblLegajo";
			this.lblLegajo.Size = new System.Drawing.Size(39, 13);
			this.lblLegajo.TabIndex = 8;
			this.lblLegajo.Text = "Legajo";
			// 
			// cbDominio
			// 
			this.cbDominio.FormattingEnabled = true;
			this.cbDominio.Location = new System.Drawing.Point(169, 46);
			this.cbDominio.MaxLength = 50;
			this.cbDominio.Name = "cbDominio";
			this.cbDominio.Size = new System.Drawing.Size(247, 21);
			this.cbDominio.TabIndex = 2;
			// 
			// txtFullName
			// 
			this.txtFullName.Location = new System.Drawing.Point(169, 74);
			this.txtFullName.MaxLength = 100;
			this.txtFullName.Name = "txtFullName";
			this.txtFullName.Size = new System.Drawing.Size(247, 20);
			this.txtFullName.TabIndex = 3;
			// 
			// txtEmail
			// 
			this.txtEmail.Location = new System.Drawing.Point(169, 101);
			this.txtEmail.MaxLength = 150;
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(247, 20);
			this.txtEmail.TabIndex = 4;
			// 
			// txtUserName
			// 
			this.txtUserName.Location = new System.Drawing.Point(169, 19);
			this.txtUserName.MaxLength = 50;
			this.txtUserName.Name = "txtUserName";
			this.txtUserName.Size = new System.Drawing.Size(247, 20);
			this.txtUserName.TabIndex = 0;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(33, 104);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(93, 13);
			this.label4.TabIndex = 3;
			this.label4.Text = "Correo electrónico";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(33, 77);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(90, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Nombre completo";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(33, 49);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(45, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Dominio";
			// 
			// lblNombreUsuario
			// 
			this.lblNombreUsuario.AutoSize = true;
			this.lblNombreUsuario.Location = new System.Drawing.Point(33, 22);
			this.lblNombreUsuario.Name = "lblNombreUsuario";
			this.lblNombreUsuario.Size = new System.Drawing.Size(98, 13);
			this.lblNombreUsuario.TabIndex = 0;
			this.lblNombreUsuario.Text = "Nombre de Usuario";
			// 
			// tpgPermisosUsr
			// 
			this.tpgPermisosUsr.BackColor = System.Drawing.Color.WhiteSmoke;
			this.tpgPermisosUsr.Controls.Add(this.pnlPermisosUsr);
			this.tpgPermisosUsr.Controls.Add(this.pnlPermisosEdit);
			this.tpgPermisosUsr.Location = new System.Drawing.Point(4, 22);
			this.tpgPermisosUsr.Name = "tpgPermisosUsr";
			this.tpgPermisosUsr.Padding = new System.Windows.Forms.Padding(3);
			this.tpgPermisosUsr.Size = new System.Drawing.Size(569, 276);
			this.tpgPermisosUsr.TabIndex = 1;
			this.tpgPermisosUsr.Text = "Permisos";
			this.tpgPermisosUsr.UseVisualStyleBackColor = true;
			// 
			// pnlPermisosUsr
			// 
			this.pnlPermisosUsr.Controls.Add(this.lvPermisosUsr);
			this.pnlPermisosUsr.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlPermisosUsr.Location = new System.Drawing.Point(311, 3);
			this.pnlPermisosUsr.Name = "pnlPermisosUsr";
			this.pnlPermisosUsr.Size = new System.Drawing.Size(255, 270);
			this.pnlPermisosUsr.TabIndex = 1;
			// 
			// lvPermisosUsr
			// 
			this.lvPermisosUsr.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeader2});
			this.lvPermisosUsr.FullRowSelect = true;
			this.lvPermisosUsr.HideSelection = false;
			this.lvPermisosUsr.Location = new System.Drawing.Point(28, 17);
			this.lvPermisosUsr.Name = "lvPermisosUsr";
			this.lvPermisosUsr.Size = new System.Drawing.Size(207, 218);
			this.lvPermisosUsr.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.lvPermisosUsr.TabIndex = 1;
			this.lvPermisosUsr.UseCompatibleStateImageBehavior = false;
			this.lvPermisosUsr.View = System.Windows.Forms.View.Details;
			this.lvPermisosUsr.DoubleClick += new System.EventHandler(this.lvPermisosUsr_DoubleClick);
			// 
			// pnlPermisosEdit
			// 
			this.pnlPermisosEdit.Controls.Add(this.btnDelRole);
			this.pnlPermisosEdit.Controls.Add(this.btnDelAllRoles);
			this.pnlPermisosEdit.Controls.Add(this.btnAddAllRoles);
			this.pnlPermisosEdit.Controls.Add(this.btnAddRole);
			this.pnlPermisosEdit.Controls.Add(this.lvPermisosDB);
			this.pnlPermisosEdit.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlPermisosEdit.Location = new System.Drawing.Point(3, 3);
			this.pnlPermisosEdit.Name = "pnlPermisosEdit";
			this.pnlPermisosEdit.Size = new System.Drawing.Size(308, 270);
			this.pnlPermisosEdit.TabIndex = 0;
			// 
			// btnDelRole
			// 
			this.btnDelRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDelRole.BackColor = System.Drawing.SystemColors.Control;
			this.btnDelRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDelRole.Location = new System.Drawing.Point(253, 168);
			this.btnDelRole.Name = "btnDelRole";
			this.btnDelRole.Size = new System.Drawing.Size(42, 26);
			this.btnDelRole.TabIndex = 3;
			this.btnDelRole.Text = "<";
			this.btnDelRole.UseVisualStyleBackColor = false;
			this.btnDelRole.Click += new System.EventHandler(this.btnDelRole_Click);
			// 
			// btnDelAllRoles
			// 
			this.btnDelAllRoles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDelAllRoles.BackColor = System.Drawing.SystemColors.Control;
			this.btnDelAllRoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDelAllRoles.Location = new System.Drawing.Point(253, 139);
			this.btnDelAllRoles.Name = "btnDelAllRoles";
			this.btnDelAllRoles.Size = new System.Drawing.Size(42, 26);
			this.btnDelAllRoles.TabIndex = 2;
			this.btnDelAllRoles.Text = "<<";
			this.btnDelAllRoles.UseVisualStyleBackColor = false;
			this.btnDelAllRoles.Click += new System.EventHandler(this.btnDelAllRoles_Click);
			// 
			// btnAddAllRoles
			// 
			this.btnAddAllRoles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAddAllRoles.BackColor = System.Drawing.SystemColors.Control;
			this.btnAddAllRoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAddAllRoles.Location = new System.Drawing.Point(253, 97);
			this.btnAddAllRoles.Name = "btnAddAllRoles";
			this.btnAddAllRoles.Size = new System.Drawing.Size(42, 26);
			this.btnAddAllRoles.TabIndex = 1;
			this.btnAddAllRoles.Text = ">>";
			this.btnAddAllRoles.UseVisualStyleBackColor = false;
			this.btnAddAllRoles.Click += new System.EventHandler(this.btnAddAllRoles_Click);
			// 
			// btnAddRole
			// 
			this.btnAddRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAddRole.BackColor = System.Drawing.SystemColors.Control;
			this.btnAddRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAddRole.Location = new System.Drawing.Point(253, 68);
			this.btnAddRole.Name = "btnAddRole";
			this.btnAddRole.Size = new System.Drawing.Size(42, 26);
			this.btnAddRole.TabIndex = 0;
			this.btnAddRole.Text = ">";
			this.btnAddRole.UseVisualStyleBackColor = false;
			this.btnAddRole.Click += new System.EventHandler(this.btnAddRole_Click);
			// 
			// lvPermisosDB
			// 
			this.lvPermisosDB.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeader1});
			this.lvPermisosDB.FullRowSelect = true;
			this.lvPermisosDB.HideSelection = false;
			this.lvPermisosDB.Location = new System.Drawing.Point(14, 17);
			this.lvPermisosDB.Name = "lvPermisosDB";
			this.lvPermisosDB.Size = new System.Drawing.Size(207, 218);
			this.lvPermisosDB.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.lvPermisosDB.TabIndex = 0;
			this.lvPermisosDB.UseCompatibleStateImageBehavior = false;
			this.lvPermisosDB.View = System.Windows.Forms.View.Details;
			this.lvPermisosDB.DoubleClick += new System.EventHandler(this.lvPermisosDB_DoubleClick);
			// 
			// tpgGruposUsr
			// 
			this.tpgGruposUsr.BackColor = System.Drawing.Color.WhiteSmoke;
			this.tpgGruposUsr.Controls.Add(this.pnlGruposUsr);
			this.tpgGruposUsr.Controls.Add(this.pnlGruposEdit);
			this.tpgGruposUsr.Location = new System.Drawing.Point(4, 22);
			this.tpgGruposUsr.Name = "tpgGruposUsr";
			this.tpgGruposUsr.Size = new System.Drawing.Size(569, 276);
			this.tpgGruposUsr.TabIndex = 2;
			this.tpgGruposUsr.Text = "Grupos de Solicitudes";
			// 
			// pnlGruposUsr
			// 
			this.pnlGruposUsr.Controls.Add(this.lvGruposUsr);
			this.pnlGruposUsr.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlGruposUsr.Location = new System.Drawing.Point(308, 0);
			this.pnlGruposUsr.Name = "pnlGruposUsr";
			this.pnlGruposUsr.Size = new System.Drawing.Size(261, 276);
			this.pnlGruposUsr.TabIndex = 3;
			// 
			// lvGruposUsr
			// 
			this.lvGruposUsr.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeader3});
			this.lvGruposUsr.Location = new System.Drawing.Point(28, 17);
			this.lvGruposUsr.Name = "lvGruposUsr";
			this.lvGruposUsr.Size = new System.Drawing.Size(207, 218);
			this.lvGruposUsr.SmallImageList = this.imageList;
			this.lvGruposUsr.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.lvGruposUsr.TabIndex = 1;
			this.lvGruposUsr.UseCompatibleStateImageBehavior = false;
			this.lvGruposUsr.View = System.Windows.Forms.View.Details;
			this.lvGruposUsr.DoubleClick += new System.EventHandler(this.lvGruposUsr_DoubleClick);
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "Active.jpg");
			this.imageList.Images.SetKeyName(1, "Desactivo.jpg");
			// 
			// pnlGruposEdit
			// 
			this.pnlGruposEdit.Controls.Add(this.btnDelGroup);
			this.pnlGruposEdit.Controls.Add(this.btnDelAllGroups);
			this.pnlGruposEdit.Controls.Add(this.btnAddAllGroups);
			this.pnlGruposEdit.Controls.Add(this.btnAddGroup);
			this.pnlGruposEdit.Controls.Add(this.lvGruposDB);
			this.pnlGruposEdit.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlGruposEdit.Location = new System.Drawing.Point(0, 0);
			this.pnlGruposEdit.Name = "pnlGruposEdit";
			this.pnlGruposEdit.Size = new System.Drawing.Size(308, 276);
			this.pnlGruposEdit.TabIndex = 2;
			// 
			// btnDelGroup
			// 
			this.btnDelGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDelGroup.BackColor = System.Drawing.SystemColors.Control;
			this.btnDelGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDelGroup.Location = new System.Drawing.Point(253, 168);
			this.btnDelGroup.Name = "btnDelGroup";
			this.btnDelGroup.Size = new System.Drawing.Size(42, 26);
			this.btnDelGroup.TabIndex = 3;
			this.btnDelGroup.Text = "<";
			this.btnDelGroup.UseVisualStyleBackColor = false;
			this.btnDelGroup.Click += new System.EventHandler(this.btnDelGroup_Click);
			// 
			// btnDelAllGroups
			// 
			this.btnDelAllGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDelAllGroups.BackColor = System.Drawing.SystemColors.Control;
			this.btnDelAllGroups.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDelAllGroups.Location = new System.Drawing.Point(253, 139);
			this.btnDelAllGroups.Name = "btnDelAllGroups";
			this.btnDelAllGroups.Size = new System.Drawing.Size(42, 26);
			this.btnDelAllGroups.TabIndex = 2;
			this.btnDelAllGroups.Text = "<<";
			this.btnDelAllGroups.UseVisualStyleBackColor = false;
			this.btnDelAllGroups.Click += new System.EventHandler(this.btnDelAllGroups_Click);
			// 
			// btnAddAllGroups
			// 
			this.btnAddAllGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAddAllGroups.BackColor = System.Drawing.SystemColors.Control;
			this.btnAddAllGroups.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAddAllGroups.Location = new System.Drawing.Point(253, 97);
			this.btnAddAllGroups.Name = "btnAddAllGroups";
			this.btnAddAllGroups.Size = new System.Drawing.Size(42, 26);
			this.btnAddAllGroups.TabIndex = 1;
			this.btnAddAllGroups.Text = ">>";
			this.btnAddAllGroups.UseVisualStyleBackColor = false;
			this.btnAddAllGroups.Click += new System.EventHandler(this.btnAddAllGroups_Click);
			// 
			// btnAddGroup
			// 
			this.btnAddGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAddGroup.BackColor = System.Drawing.SystemColors.Control;
			this.btnAddGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAddGroup.Location = new System.Drawing.Point(253, 68);
			this.btnAddGroup.Name = "btnAddGroup";
			this.btnAddGroup.Size = new System.Drawing.Size(42, 26);
			this.btnAddGroup.TabIndex = 0;
			this.btnAddGroup.Text = ">";
			this.btnAddGroup.UseVisualStyleBackColor = false;
			this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
			// 
			// lvGruposDB
			// 
			this.lvGruposDB.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeader4});
			this.lvGruposDB.Location = new System.Drawing.Point(14, 17);
			this.lvGruposDB.Name = "lvGruposDB";
			this.lvGruposDB.Size = new System.Drawing.Size(207, 218);
			this.lvGruposDB.SmallImageList = this.imageList;
			this.lvGruposDB.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.lvGruposDB.TabIndex = 0;
			this.lvGruposDB.UseCompatibleStateImageBehavior = false;
			this.lvGruposDB.View = System.Windows.Forms.View.Details;
			this.lvGruposDB.DoubleClick += new System.EventHandler(this.lvGruposDB_DoubleClick);
			// 
			// tpgGruposSeguimUsr
			// 
			this.tpgGruposSeguimUsr.BackColor = System.Drawing.Color.WhiteSmoke;
			this.tpgGruposSeguimUsr.Controls.Add(this.panel4);
			this.tpgGruposSeguimUsr.Controls.Add(this.pnlGuposSegEdit);
			this.tpgGruposSeguimUsr.Location = new System.Drawing.Point(4, 22);
			this.tpgGruposSeguimUsr.Name = "tpgGruposSeguimUsr";
			this.tpgGruposSeguimUsr.Padding = new System.Windows.Forms.Padding(3);
			this.tpgGruposSeguimUsr.Size = new System.Drawing.Size(569, 276);
			this.tpgGruposSeguimUsr.TabIndex = 3;
			this.tpgGruposSeguimUsr.Text = "Grupos de Seguimientos de Solicitudes";
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.lvGruposSeguimUsr);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new System.Drawing.Point(311, 3);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(255, 270);
			this.panel4.TabIndex = 4;
			// 
			// lvGruposSeguimUsr
			// 
			this.lvGruposSeguimUsr.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeader6});
			this.lvGruposSeguimUsr.Location = new System.Drawing.Point(28, 17);
			this.lvGruposSeguimUsr.Name = "lvGruposSeguimUsr";
			this.lvGruposSeguimUsr.Size = new System.Drawing.Size(207, 218);
			this.lvGruposSeguimUsr.SmallImageList = this.imageList;
			this.lvGruposSeguimUsr.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.lvGruposSeguimUsr.TabIndex = 1;
			this.lvGruposSeguimUsr.UseCompatibleStateImageBehavior = false;
			this.lvGruposSeguimUsr.View = System.Windows.Forms.View.Details;
			this.lvGruposSeguimUsr.DoubleClick += new System.EventHandler(this.lvGruposSeguimUsr_DoubleClick);
			// 
			// pnlGuposSegEdit
			// 
			this.pnlGuposSegEdit.Controls.Add(this.btnDelGroupSeguim);
			this.pnlGuposSegEdit.Controls.Add(this.btnDelAllGroupsSeguim);
			this.pnlGuposSegEdit.Controls.Add(this.btnAddAllGroupsSeguim);
			this.pnlGuposSegEdit.Controls.Add(this.btnAddGroupSeguim);
			this.pnlGuposSegEdit.Controls.Add(this.lvGruposSeguimDB);
			this.pnlGuposSegEdit.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlGuposSegEdit.Location = new System.Drawing.Point(3, 3);
			this.pnlGuposSegEdit.Name = "pnlGuposSegEdit";
			this.pnlGuposSegEdit.Size = new System.Drawing.Size(308, 270);
			this.pnlGuposSegEdit.TabIndex = 3;
			// 
			// btnDelGroupSeguim
			// 
			this.btnDelGroupSeguim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDelGroupSeguim.BackColor = System.Drawing.SystemColors.Control;
			this.btnDelGroupSeguim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDelGroupSeguim.Location = new System.Drawing.Point(253, 168);
			this.btnDelGroupSeguim.Name = "btnDelGroupSeguim";
			this.btnDelGroupSeguim.Size = new System.Drawing.Size(42, 26);
			this.btnDelGroupSeguim.TabIndex = 3;
			this.btnDelGroupSeguim.Text = "<";
			this.btnDelGroupSeguim.UseVisualStyleBackColor = false;
			this.btnDelGroupSeguim.Click += new System.EventHandler(this.btnDelGroupSeguim_Click);
			// 
			// btnDelAllGroupsSeguim
			// 
			this.btnDelAllGroupsSeguim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDelAllGroupsSeguim.BackColor = System.Drawing.SystemColors.Control;
			this.btnDelAllGroupsSeguim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDelAllGroupsSeguim.Location = new System.Drawing.Point(253, 139);
			this.btnDelAllGroupsSeguim.Name = "btnDelAllGroupsSeguim";
			this.btnDelAllGroupsSeguim.Size = new System.Drawing.Size(42, 26);
			this.btnDelAllGroupsSeguim.TabIndex = 2;
			this.btnDelAllGroupsSeguim.Text = "<<";
			this.btnDelAllGroupsSeguim.UseVisualStyleBackColor = false;
			this.btnDelAllGroupsSeguim.Click += new System.EventHandler(this.btnDelAllGroupsSeguim_Click);
			// 
			// btnAddAllGroupsSeguim
			// 
			this.btnAddAllGroupsSeguim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAddAllGroupsSeguim.BackColor = System.Drawing.SystemColors.Control;
			this.btnAddAllGroupsSeguim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAddAllGroupsSeguim.Location = new System.Drawing.Point(253, 97);
			this.btnAddAllGroupsSeguim.Name = "btnAddAllGroupsSeguim";
			this.btnAddAllGroupsSeguim.Size = new System.Drawing.Size(42, 26);
			this.btnAddAllGroupsSeguim.TabIndex = 1;
			this.btnAddAllGroupsSeguim.Text = ">>";
			this.btnAddAllGroupsSeguim.UseVisualStyleBackColor = false;
			this.btnAddAllGroupsSeguim.Click += new System.EventHandler(this.btnAddAllGroupsSeguim_Click);
			// 
			// btnAddGroupSeguim
			// 
			this.btnAddGroupSeguim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAddGroupSeguim.BackColor = System.Drawing.SystemColors.Control;
			this.btnAddGroupSeguim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAddGroupSeguim.Location = new System.Drawing.Point(253, 68);
			this.btnAddGroupSeguim.Name = "btnAddGroupSeguim";
			this.btnAddGroupSeguim.Size = new System.Drawing.Size(42, 26);
			this.btnAddGroupSeguim.TabIndex = 0;
			this.btnAddGroupSeguim.Text = ">";
			this.btnAddGroupSeguim.UseVisualStyleBackColor = false;
			this.btnAddGroupSeguim.Click += new System.EventHandler(this.btnAddGroupSeguim_Click);
			// 
			// lvGruposSeguimDB
			// 
			this.lvGruposSeguimDB.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeader5});
			this.lvGruposSeguimDB.Location = new System.Drawing.Point(14, 17);
			this.lvGruposSeguimDB.Name = "lvGruposSeguimDB";
			this.lvGruposSeguimDB.Size = new System.Drawing.Size(207, 218);
			this.lvGruposSeguimDB.SmallImageList = this.imageList;
			this.lvGruposSeguimDB.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.lvGruposSeguimDB.TabIndex = 0;
			this.lvGruposSeguimDB.UseCompatibleStateImageBehavior = false;
			this.lvGruposSeguimDB.View = System.Windows.Forms.View.Details;
			this.lvGruposSeguimDB.DoubleClick += new System.EventHandler(this.lvGruposSeguimDB_DoubleClick);
			// 
			// FABMUsuarios
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(604, 388);
			this.Controls.Add(this.pnlABMPhxUsers);
			this.Name = "FABMUsuarios";
			this.Load += new System.EventHandler(this.FABMUsuarios_Load);
			this.Controls.SetChildIndex(this.groupBox1, 0);
			this.Controls.SetChildIndex(this.pnlABMPhxUsers, 0);
			this.pnlABMPhxUsers.ResumeLayout(false);
			this.tabUsuario.ResumeLayout(false);
			this.tpgDatosUsr.ResumeLayout(false);
			this.tpgDatosUsr.PerformLayout();
			this.tpgPermisosUsr.ResumeLayout(false);
			this.pnlPermisosUsr.ResumeLayout(false);
			this.pnlPermisosEdit.ResumeLayout(false);
			this.tpgGruposUsr.ResumeLayout(false);
			this.pnlGruposUsr.ResumeLayout(false);
			this.pnlGruposEdit.ResumeLayout(false);
			this.tpgGruposSeguimUsr.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.pnlGuposSegEdit.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlABMPhxUsers;
        private System.Windows.Forms.TabControl tabUsuario;
        private System.Windows.Forms.TabPage tpgDatosUsr;
        private System.Windows.Forms.TextBox txtLegajo;
        private System.Windows.Forms.Label lblLegajo;
        private System.Windows.Forms.ComboBox cbDominio;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNombreUsuario;
        private System.Windows.Forms.TabPage tpgPermisosUsr;
        private System.Windows.Forms.Panel pnlPermisosUsr;
        private System.Windows.Forms.ListView lvPermisosUsr;
        private System.Windows.Forms.Panel pnlPermisosEdit;
        private System.Windows.Forms.Button btnDelRole;
        private System.Windows.Forms.Button btnDelAllRoles;
        private System.Windows.Forms.Button btnAddAllRoles;
        private System.Windows.Forms.Button btnAddRole;
        private System.Windows.Forms.ListView lvPermisosDB;
        private System.Windows.Forms.TabPage tpgGruposUsr;
        private System.Windows.Forms.Panel pnlGruposUsr;
        private System.Windows.Forms.ListView lvGruposUsr;
        private System.Windows.Forms.Panel pnlGruposEdit;
        private System.Windows.Forms.Button btnDelGroup;
        private System.Windows.Forms.Button btnDelAllGroups;
        private System.Windows.Forms.Button btnAddAllGroups;
        private System.Windows.Forms.Button btnAddGroup;
        private System.Windows.Forms.ListView lvGruposDB;
        private System.Windows.Forms.Label lblSector;
        private System.Windows.Forms.Label lblFuncion;
        private System.Windows.Forms.Label lblRelLaboral;
        private System.Windows.Forms.TextBox txtFuncion;
        private System.Windows.Forms.TextBox txtSector;
        private System.Windows.Forms.Label lblInterno;
        private System.Windows.Forms.ComboBox cboEdificio;
        private System.Windows.Forms.ComboBox cboRelacionLaboral;
        private System.Windows.Forms.Label lblEdificio;
        private System.Windows.Forms.TextBox txtInterno;
        private System.Windows.Forms.Label lblPiso;
        private System.Windows.Forms.TextBox txtPiso;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.ComboBox cbSuperior;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tpgGruposSeguimUsr;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ListView lvGruposSeguimUsr;
        private System.Windows.Forms.Panel pnlGuposSegEdit;
        private System.Windows.Forms.Button btnDelGroupSeguim;
        private System.Windows.Forms.Button btnDelAllGroupsSeguim;
        private System.Windows.Forms.Button btnAddAllGroupsSeguim;
        private System.Windows.Forms.Button btnAddGroupSeguim;
        private System.Windows.Forms.ListView lvGruposSeguimDB;
        private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.Button btnCargarDatos;
    }
}
