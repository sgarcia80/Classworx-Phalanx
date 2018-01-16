namespace PhalanxAdmin
{
    partial class FNotifBlanqueosTC
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
            System.Windows.Forms.ColumnHeader colAplicacion;
            System.Windows.Forms.ColumnHeader colDominioApp;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FNotifBlanqueosTC));
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDestino = new System.Windows.Forms.Button();
            this.txtDestino = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbDominio = new System.Windows.Forms.ComboBox();
            this.txtFilUsuarioApp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbAplicacion = new System.Windows.Forms.ComboBox();
            this.labelApp = new System.Windows.Forms.Label();
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
            this.colId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTipoNotif = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTicketNro = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUsuario = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUsuarioApp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFecha = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSolicitante = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEstado = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFechaNotificado = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.bwRefreshEntities = new System.ComponentModel.BackgroundWorker();
            this.xppnlPCs = new UIComponents.XPPanel(198);
            this.lnkProcesadasError = new System.Windows.Forms.LinkLabel();
            this.lnkProcesadasOk = new System.Windows.Forms.LinkLabel();
            this.lnkGenerar = new System.Windows.Forms.LinkLabel();
            this.lnkView = new System.Windows.Forms.LinkLabel();
            this.lnkReenviar = new System.Windows.Forms.LinkLabel();
            this.lnkAdd = new System.Windows.Forms.LinkLabel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            colAplicacion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            colDominioApp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.pnlXPGrps)).BeginInit();
            this.pnlXPGrps.SuspendLayout();
            this.pnlIzq.SuspendLayout();
            this.pnlFilters.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusbar.SuspendLayout();
            this.pnlList.SuspendLayout();
            this.xppnlPCs.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlXPGrps
            // 
            this.pnlXPGrps.Controls.Add(this.xppnlPCs);
            this.pnlXPGrps.Size = new System.Drawing.Size(200, 536);
            this.pnlXPGrps.Controls.SetChildIndex(this.xppnlMenu, 0);
            this.pnlXPGrps.Controls.SetChildIndex(this.xppnlPCs, 0);
            // 
            // pnlIzq
            // 
            this.pnlIzq.Size = new System.Drawing.Size(200, 536);
            // 
            // xppnlMenu
            // 
            this.xppnlMenu.ImageItems.ImageSet = null;
            this.xppnlMenu.Location = new System.Drawing.Point(8, 214);
            this.xppnlMenu.Size = new System.Drawing.Size(184, 119);
            this.xppnlMenu.TabIndex = 1;
            // 
            // colAplicacion
            // 
            colAplicacion.Text = "Aplicación";
            colAplicacion.Width = 98;
            // 
            // colDominioApp
            // 
            colDominioApp.Text = "Dominio";
            colDominioApp.Width = 110;
            // 
            // pnlFilters
            // 
            this.pnlFilters.Controls.Add(this.groupBox2);
            this.pnlFilters.Controls.Add(this.groupBox1);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Location = new System.Drawing.Point(200, 0);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(830, 161);
            this.pnlFilters.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnDestino);
            this.groupBox2.Controls.Add(this.txtDestino);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(18, 102);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(800, 53);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Destino de Archivos";
            // 
            // btnDestino
            // 
            this.btnDestino.BackColor = System.Drawing.SystemColors.Control;
            this.btnDestino.Location = new System.Drawing.Point(452, 22);
            this.btnDestino.Name = "btnDestino";
            this.btnDestino.Size = new System.Drawing.Size(44, 21);
            this.btnDestino.TabIndex = 2;
            this.btnDestino.Text = "...";
            this.btnDestino.UseVisualStyleBackColor = false;
            this.btnDestino.Click += new System.EventHandler(this.btnDestino_Click);
            // 
            // txtDestino
            // 
            this.txtDestino.Location = new System.Drawing.Point(73, 23);
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.Size = new System.Drawing.Size(373, 20);
            this.txtDestino.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Carpeta";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbEstado);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbDominio);
            this.groupBox1.Controls.Add(this.txtFilUsuarioApp);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbAplicacion);
            this.groupBox1.Controls.Add(this.labelApp);
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.txtFilUsuario);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(18, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 88);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de búsqueda";
            // 
            // cbDominio
            // 
            this.cbDominio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDominio.FormattingEnabled = true;
            this.cbDominio.Location = new System.Drawing.Point(73, 20);
            this.cbDominio.Name = "cbDominio";
            this.cbDominio.Size = new System.Drawing.Size(176, 21);
            this.cbDominio.TabIndex = 1;
            // 
            // txtFilUsuarioApp
            // 
            this.txtFilUsuarioApp.Location = new System.Drawing.Point(326, 47);
            this.txtFilUsuarioApp.Name = "txtFilUsuarioApp";
            this.txtFilUsuarioApp.Size = new System.Drawing.Size(120, 20);
            this.txtFilUsuarioApp.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(255, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Usuario App";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dominio";
            // 
            // cbAplicacion
            // 
            this.cbAplicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAplicacion.FormattingEnabled = true;
            this.cbAplicacion.Location = new System.Drawing.Point(73, 47);
            this.cbAplicacion.Name = "cbAplicacion";
            this.cbAplicacion.Size = new System.Drawing.Size(176, 21);
            this.cbAplicacion.TabIndex = 5;
            // 
            // labelApp
            // 
            this.labelApp.AutoSize = true;
            this.labelApp.Location = new System.Drawing.Point(11, 50);
            this.labelApp.Name = "labelApp";
            this.labelApp.Size = new System.Drawing.Size(56, 13);
            this.labelApp.TabIndex = 4;
            this.labelApp.Text = "Aplicacion";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.SystemColors.Control;
            this.btnLimpiar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnLimpiar.Location = new System.Drawing.Point(681, 46);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(76, 21);
            this.btnLimpiar.TabIndex = 10;
            this.btnLimpiar.Text = "&Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.SystemColors.Control;
            this.btnBuscar.Location = new System.Drawing.Point(599, 46);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(76, 21);
            this.btnBuscar.TabIndex = 9;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtFilUsuario
            // 
            this.txtFilUsuario.Location = new System.Drawing.Point(327, 20);
            this.txtFilUsuario.Name = "txtFilUsuario";
            this.txtFilUsuario.Size = new System.Drawing.Size(120, 20);
            this.txtFilUsuario.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(255, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Usuario Red";
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
            this.pnlList.Location = new System.Drawing.Point(200, 161);
            this.pnlList.Name = "pnlList";
            this.pnlList.Size = new System.Drawing.Size(830, 353);
            this.pnlList.TabIndex = 1;
            // 
            // lvLista
            // 
            this.lvLista.AllowColumnReorder = true;
            this.lvLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvLista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colId,
            this.colTipoNotif,
            this.colTicketNro,
            colDominioApp,
            this.colUsuario,
            colAplicacion,
            this.colUsuarioApp,
            this.colFecha,
            this.colSolicitante,
            this.colEstado,
            this.colFechaNotificado});
            this.lvLista.FullRowSelect = true;
            this.lvLista.HideSelection = false;
            this.lvLista.Location = new System.Drawing.Point(18, 6);
            this.lvLista.Name = "lvLista";
            this.lvLista.Size = new System.Drawing.Size(800, 272);
            this.lvLista.SmallImageList = this.imageList;
            this.lvLista.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvLista.TabIndex = 0;
            this.lvLista.UseCompatibleStateImageBehavior = false;
            this.lvLista.View = System.Windows.Forms.View.Details;
            this.lvLista.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvLista_ColumnClick);
            this.lvLista.DoubleClick += new System.EventHandler(this.lvLista_DoubleClick);
            // 
            // colId
            // 
            this.colId.Tag = "Numeric";
            this.colId.Text = "Notif. Nro.";
            this.colId.Width = 80;
            // 
            // colTipoNotif
            // 
            this.colTipoNotif.Text = "Tipo Notif.";
            this.colTipoNotif.Width = 80;
            // 
            // colTicketNro
            // 
            this.colTicketNro.Tag = "Numeric";
            this.colTicketNro.Text = "Ticket Nro.";
            this.colTicketNro.Width = 80;
            // 
            // colUsuario
            // 
            this.colUsuario.Text = "Usuario Red";
            this.colUsuario.Width = 94;
            // 
            // colUsuarioApp
            // 
            this.colUsuarioApp.Text = "Usuario App";
            this.colUsuarioApp.Width = 97;
            // 
            // colFecha
            // 
            this.colFecha.Tag = "ddMMyyyyHHmm";
            this.colFecha.Text = "Fecha Envio";
            this.colFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colFecha.Width = 117;
            // 
            // colSolicitante
            // 
            this.colSolicitante.Text = "Solicitante";
            this.colSolicitante.Width = 111;
            // 
            // colEstado
            // 
            this.colEstado.Text = "Estado";
            this.colEstado.Width = 100;
            // 
            // colFechaNotificado
            // 
            this.colFechaNotificado.Tag = "ddMMyyyyHHmm";
            this.colFechaNotificado.Text = "Fecha Notif.";
            this.colFechaNotificado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colFechaNotificado.Width = 117;
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
            // xppnlPCs
            // 
            this.xppnlPCs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xppnlPCs.BackColor = System.Drawing.Color.Transparent;
            this.xppnlPCs.Caption = "Notificación de Blanqueos TC";
            this.xppnlPCs.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xppnlPCs.CaptionGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
            this.xppnlPCs.CaptionGradient.Start = System.Drawing.Color.White;
            this.xppnlPCs.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xppnlPCs.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xppnlPCs.Controls.Add(this.lnkProcesadasError);
            this.xppnlPCs.Controls.Add(this.lnkProcesadasOk);
            this.xppnlPCs.Controls.Add(this.lnkGenerar);
            this.xppnlPCs.Controls.Add(this.lnkView);
            this.xppnlPCs.Controls.Add(this.lnkReenviar);
            this.xppnlPCs.Controls.Add(this.lnkAdd);
            this.xppnlPCs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.xppnlPCs.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xppnlPCs.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xppnlPCs.ImageItems.ImageSet = null;
            this.xppnlPCs.Location = new System.Drawing.Point(8, 8);
            this.xppnlPCs.Name = "xppnlPCs";
            this.xppnlPCs.PanelGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.xppnlPCs.PanelGradient.Start = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.xppnlPCs.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xppnlPCs.Size = new System.Drawing.Size(184, 198);
            this.xppnlPCs.TabIndex = 0;
            this.xppnlPCs.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.xppnlPCs.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.xppnlPCs.VertAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lnkProcesadasError
            // 
            this.lnkProcesadasError.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkProcesadasError.AutoSize = true;
            this.lnkProcesadasError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.lnkProcesadasError.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkProcesadasError.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkProcesadasError.Location = new System.Drawing.Point(18, 120);
            this.lnkProcesadasError.Name = "lnkProcesadasError";
            this.lnkProcesadasError.Size = new System.Drawing.Size(129, 13);
            this.lnkProcesadasError.TabIndex = 3;
            this.lnkProcesadasError.TabStop = true;
            this.lnkProcesadasError.Text = "Procesadas con Error";
            this.lnkProcesadasError.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkProcesadasError.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkProcesadasError_LinkClicked);
            // 
            // lnkProcesadasOk
            // 
            this.lnkProcesadasOk.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkProcesadasOk.AutoSize = true;
            this.lnkProcesadasOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.lnkProcesadasOk.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkProcesadasOk.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkProcesadasOk.Location = new System.Drawing.Point(18, 100);
            this.lnkProcesadasOk.Name = "lnkProcesadasOk";
            this.lnkProcesadasOk.Size = new System.Drawing.Size(94, 13);
            this.lnkProcesadasOk.TabIndex = 2;
            this.lnkProcesadasOk.TabStop = true;
            this.lnkProcesadasOk.Text = "Procesadas OK";
            this.lnkProcesadasOk.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkProcesadasOk.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkProcesadasOk_LinkClicked);
            // 
            // lnkGenerar
            // 
            this.lnkGenerar.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkGenerar.AutoSize = true;
            this.lnkGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.lnkGenerar.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkGenerar.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkGenerar.Location = new System.Drawing.Point(18, 80);
            this.lnkGenerar.Name = "lnkGenerar";
            this.lnkGenerar.Size = new System.Drawing.Size(91, 13);
            this.lnkGenerar.TabIndex = 1;
            this.lnkGenerar.TabStop = true;
            this.lnkGenerar.Text = "Generar Macro";
            this.lnkGenerar.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkGenerar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkGenerar_LinkClicked);
            // 
            // lnkView
            // 
            this.lnkView.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkView.AutoSize = true;
            this.lnkView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.lnkView.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkView.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkView.Location = new System.Drawing.Point(18, 172);
            this.lnkView.Name = "lnkView";
            this.lnkView.Size = new System.Drawing.Size(61, 13);
            this.lnkView.TabIndex = 5;
            this.lnkView.TabStop = true;
            this.lnkView.Text = "Visualizar";
            this.lnkView.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkView.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkView_LinkClicked);
            // 
            // lnkReenviar
            // 
            this.lnkReenviar.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkReenviar.AutoSize = true;
            this.lnkReenviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.lnkReenviar.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkReenviar.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkReenviar.Location = new System.Drawing.Point(18, 152);
            this.lnkReenviar.Name = "lnkReenviar";
            this.lnkReenviar.Size = new System.Drawing.Size(85, 13);
            this.lnkReenviar.TabIndex = 4;
            this.lnkReenviar.TabStop = true;
            this.lnkReenviar.Text = "Reenviar Mail";
            this.lnkReenviar.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkReenviar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkReenviar_LinkClicked);
            // 
            // lnkAdd
            // 
            this.lnkAdd.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkAdd.AutoSize = true;
            this.lnkAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.lnkAdd.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkAdd.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkAdd.Location = new System.Drawing.Point(18, 50);
            this.lnkAdd.Name = "lnkAdd";
            this.lnkAdd.Size = new System.Drawing.Size(128, 13);
            this.lnkAdd.TabIndex = 0;
            this.lnkAdd.TabStop = true;
            this.lnkAdd.Text = "Agregar Blanqueo TC";
            this.lnkAdd.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAdd_LinkClicked);
            // 
            // cbEstado
            // 
            this.cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstado.FormattingEnabled = true;
            this.cbEstado.Location = new System.Drawing.Point(535, 20);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(222, 21);
            this.cbEstado.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(463, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Estado";
            // 
            // FNotifBlanqueosTC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1030, 536);
            this.Controls.Add(this.pnlList);
            this.Controls.Add(this.statusbar);
            this.Controls.Add(this.pnlFilters);
            this.Name = "FNotifBlanqueosTC";
            this.Load += new System.EventHandler(this.FEquiposWin_Load);
            this.Controls.SetChildIndex(this.pnlIzq, 0);
            this.Controls.SetChildIndex(this.pnlFilters, 0);
            this.Controls.SetChildIndex(this.statusbar, 0);
            this.Controls.SetChildIndex(this.pnlList, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pnlXPGrps)).EndInit();
            this.pnlXPGrps.ResumeLayout(false);
            this.pnlIzq.ResumeLayout(false);
            this.pnlFilters.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusbar.ResumeLayout(false);
            this.statusbar.PerformLayout();
            this.pnlList.ResumeLayout(false);
            this.xppnlPCs.ResumeLayout(false);
            this.xppnlPCs.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlFilters;
        protected System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbAplicacion;
        private System.Windows.Forms.Label labelApp;
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
        private System.Windows.Forms.ColumnHeader colUsuarioApp;
        private System.ComponentModel.BackgroundWorker bwRefreshEntities;
        private UIComponents.XPPanel xppnlPCs;
        protected System.Windows.Forms.LinkLabel lnkView;
        protected System.Windows.Forms.LinkLabel lnkReenviar;
        protected System.Windows.Forms.LinkLabel lnkAdd;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ColumnHeader colFecha;
        protected System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader colSolicitante;
        private System.Windows.Forms.ColumnHeader colUsuario;
        protected System.Windows.Forms.TextBox txtFilUsuarioApp;
        protected System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbDominio;
        private System.Windows.Forms.ColumnHeader colId;
        private System.Windows.Forms.ColumnHeader colTicketNro;
        private System.Windows.Forms.ColumnHeader colEstado;
        private System.Windows.Forms.ColumnHeader colFechaNotificado;
        protected System.Windows.Forms.LinkLabel lnkGenerar;
        protected System.Windows.Forms.LinkLabel lnkProcesadasOk;
        private System.Windows.Forms.ColumnHeader colTipoNotif;
        protected System.Windows.Forms.LinkLabel lnkProcesadasError;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.GroupBox groupBox2;
        protected System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.Label label4;
        protected System.Windows.Forms.Button btnDestino;
        private System.Windows.Forms.ComboBox cbEstado;
        protected System.Windows.Forms.Label label5;

    }
}
