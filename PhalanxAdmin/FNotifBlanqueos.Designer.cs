namespace PhalanxAdmin
{
    partial class FNotifBlanqueos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FNotifBlanqueos));
            this.pnlFilters = new System.Windows.Forms.Panel();
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
            this.colUsuarioApp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUsuario = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFecha = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSolicitante = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.bwRefreshEntities = new System.ComponentModel.BackgroundWorker();
            this.xppnlPCs = new UIComponents.XPPanel(141);
            this.lnkView = new System.Windows.Forms.LinkLabel();
            this.lnkReenviar = new System.Windows.Forms.LinkLabel();
            this.lnkAdd = new System.Windows.Forms.LinkLabel();
            colAplicacion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            colDominioApp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.pnlXPGrps)).BeginInit();
            this.pnlXPGrps.SuspendLayout();
            this.pnlIzq.SuspendLayout();
            this.pnlFilters.SuspendLayout();
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
            this.xppnlMenu.Location = new System.Drawing.Point(8, 157);
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
            this.pnlFilters.Controls.Add(this.groupBox1);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Location = new System.Drawing.Point(200, 0);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(611, 108);
            this.pnlFilters.TabIndex = 10;
            // 
            // groupBox1
            // 
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
            this.groupBox1.Size = new System.Drawing.Size(571, 88);
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
            this.cbDominio.Size = new System.Drawing.Size(143, 21);
            this.cbDominio.TabIndex = 20;
            // 
            // txtFilUsuarioApp
            // 
            this.txtFilUsuarioApp.Location = new System.Drawing.Point(304, 52);
            this.txtFilUsuarioApp.Name = "txtFilUsuarioApp";
            this.txtFilUsuarioApp.Size = new System.Drawing.Size(143, 20);
            this.txtFilUsuarioApp.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(232, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Usuario App";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Dominio";
            // 
            // cbAplicacion
            // 
            this.cbAplicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAplicacion.FormattingEnabled = true;
            this.cbAplicacion.Location = new System.Drawing.Point(73, 51);
            this.cbAplicacion.Name = "cbAplicacion";
            this.cbAplicacion.Size = new System.Drawing.Size(143, 21);
            this.cbAplicacion.TabIndex = 3;
            // 
            // labelApp
            // 
            this.labelApp.AutoSize = true;
            this.labelApp.Location = new System.Drawing.Point(11, 54);
            this.labelApp.Name = "labelApp";
            this.labelApp.Size = new System.Drawing.Size(56, 13);
            this.labelApp.TabIndex = 15;
            this.labelApp.Text = "Aplicacion";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.SystemColors.Control;
            this.btnLimpiar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnLimpiar.Location = new System.Drawing.Point(489, 19);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(76, 21);
            this.btnLimpiar.TabIndex = 4;
            this.btnLimpiar.Text = "&Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.SystemColors.Control;
            this.btnBuscar.Location = new System.Drawing.Point(490, 47);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(76, 21);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtFilUsuario
            // 
            this.txtFilUsuario.Location = new System.Drawing.Point(304, 20);
            this.txtFilUsuario.Name = "txtFilUsuario";
            this.txtFilUsuario.Size = new System.Drawing.Size(143, 20);
            this.txtFilUsuario.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(232, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 3;
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
            this.statusbar.Size = new System.Drawing.Size(611, 22);
            this.statusbar.TabIndex = 11;
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
            this.pnlList.Location = new System.Drawing.Point(200, 108);
            this.pnlList.Name = "pnlList";
            this.pnlList.Size = new System.Drawing.Size(611, 406);
            this.pnlList.TabIndex = 12;
            // 
            // lvLista
            // 
            this.lvLista.AllowColumnReorder = true;
            this.lvLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvLista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colId,
            colAplicacion,
            this.colUsuarioApp,
            colDominioApp,
            this.colUsuario,
            this.colFecha,
            this.colSolicitante});
            this.lvLista.FullRowSelect = true;
            this.lvLista.HideSelection = false;
            this.lvLista.Location = new System.Drawing.Point(18, 6);
            this.lvLista.MultiSelect = false;
            this.lvLista.Name = "lvLista";
            this.lvLista.Size = new System.Drawing.Size(571, 325);
            this.lvLista.SmallImageList = this.imageList;
            this.lvLista.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvLista.TabIndex = 1;
            this.lvLista.UseCompatibleStateImageBehavior = false;
            this.lvLista.View = System.Windows.Forms.View.Details;
            this.lvLista.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvLista_ColumnClick);
            this.lvLista.DoubleClick += new System.EventHandler(this.lvLista_DoubleClick);
            // 
            // colId
            // 
            this.colId.Text = "Solicitud";
            // 
            // colUsuarioApp
            // 
            this.colUsuarioApp.Text = "Usuario App";
            this.colUsuarioApp.Width = 97;
            // 
            // colUsuario
            // 
            this.colUsuario.Text = "Usuario Red";
            this.colUsuario.Width = 94;
            // 
            // colFecha
            // 
            this.colFecha.Tag = "ddMMyyyyHHmm";
            this.colFecha.Text = "Fecha";
            this.colFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colFecha.Width = 117;
            // 
            // colSolicitante
            // 
            this.colSolicitante.Text = "Solicitante";
            this.colSolicitante.Width = 111;
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
            this.xppnlPCs.Caption = "Notificación de Blanqueos";
            this.xppnlPCs.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xppnlPCs.CaptionGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
            this.xppnlPCs.CaptionGradient.Start = System.Drawing.Color.White;
            this.xppnlPCs.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xppnlPCs.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
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
            this.xppnlPCs.Size = new System.Drawing.Size(184, 141);
            this.xppnlPCs.TabIndex = 4;
            this.xppnlPCs.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.xppnlPCs.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.xppnlPCs.VertAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lnkView
            // 
            this.lnkView.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkView.AutoSize = true;
            this.lnkView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.lnkView.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkView.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkView.Location = new System.Drawing.Point(18, 71);
            this.lnkView.Name = "lnkView";
            this.lnkView.Size = new System.Drawing.Size(61, 13);
            this.lnkView.TabIndex = 11;
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
            this.lnkReenviar.Location = new System.Drawing.Point(18, 92);
            this.lnkReenviar.Name = "lnkReenviar";
            this.lnkReenviar.Size = new System.Drawing.Size(85, 13);
            this.lnkReenviar.TabIndex = 10;
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
            this.lnkAdd.Size = new System.Drawing.Size(51, 13);
            this.lnkAdd.TabIndex = 8;
            this.lnkAdd.TabStop = true;
            this.lnkAdd.Text = "Agregar";
            this.lnkAdd.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAdd_LinkClicked);
            // 
            // FNotifBlanqueos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(811, 536);
            this.Controls.Add(this.pnlList);
            this.Controls.Add(this.statusbar);
            this.Controls.Add(this.pnlFilters);
            this.Name = "FNotifBlanqueos";
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

    }
}
