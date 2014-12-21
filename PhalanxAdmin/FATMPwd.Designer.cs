namespace PhalanxAdmin
{
    partial class FATMPwd
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
			System.Windows.Forms.ColumnHeader columnHeader3;
			System.Windows.Forms.ColumnHeader columnHeader5;
			System.Windows.Forms.ColumnHeader columnHeader1;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FATMPwd));
			this.statusbar = new System.Windows.Forms.StatusStrip();
			this.pbDB = new System.Windows.Forms.ToolStripProgressBar();
			this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.lnkCancelar = new System.Windows.Forms.ToolStripStatusLabel();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.bwRefreshEntities = new System.ComponentModel.BackgroundWorker();
			this.pnlList = new System.Windows.Forms.Panel();
			this.lvLista = new System.Windows.Forms.ListView();
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.pnlFilters = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cbCritico = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cboEstado = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnLimpiar = new System.Windows.Forms.Button();
			this.btnBuscar = new System.Windows.Forms.Button();
			this.txtFilNombre = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.xppnlDBs = new UIComponents.XPPanel(141);
			this.lnkView = new System.Windows.Forms.LinkLabel();
			this.lnkDelete = new System.Windows.Forms.LinkLabel();
			this.lnkModify = new System.Windows.Forms.LinkLabel();
			this.lnkAdd = new System.Windows.Forms.LinkLabel();
			columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			((System.ComponentModel.ISupportInitialize)(this.pnlXPGrps)).BeginInit();
			this.pnlXPGrps.SuspendLayout();
			this.pnlIzq.SuspendLayout();
			this.statusbar.SuspendLayout();
			this.pnlList.SuspendLayout();
			this.pnlFilters.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.xppnlDBs.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlchk
			// 
			this.pnlchk.ImageItems.ImageSet = null;
			this.pnlchk.Location = new System.Drawing.Point(8, 365);
			this.pnlchk.Size = new System.Drawing.Size(167, 139);
			// 
			// pnlXPGrps
			// 
			this.pnlXPGrps.Controls.Add(this.xppnlDBs);
			this.pnlXPGrps.Size = new System.Drawing.Size(200, 501);
			this.pnlXPGrps.Controls.SetChildIndex(this.pnlchk, 0);
			this.pnlXPGrps.Controls.SetChildIndex(this.xppnlMenu, 0);
			this.pnlXPGrps.Controls.SetChildIndex(this.xppnlDBs, 0);
			// 
			// pnlIzq
			// 
			this.pnlIzq.Size = new System.Drawing.Size(200, 501);
			// 
			// xppnlMenu
			// 
			this.xppnlMenu.ImageItems.ImageSet = null;
			this.xppnlMenu.Location = new System.Drawing.Point(8, 157);
			this.xppnlMenu.Size = new System.Drawing.Size(167, 200);
			// 
			// columnHeader3
			// 
			columnHeader3.Text = "Usuario";
			columnHeader3.Width = 130;
			// 
			// columnHeader5
			// 
			columnHeader5.Text = "ATM";
			columnHeader5.Width = 146;
			// 
			// columnHeader1
			// 
			columnHeader1.Text = "";
			columnHeader1.Width = 30;
			// 
			// statusbar
			// 
			this.statusbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pbDB,
            this.lblStatus,
            this.lnkCancelar});
			this.statusbar.Location = new System.Drawing.Point(200, 479);
			this.statusbar.Name = "statusbar";
			this.statusbar.Size = new System.Drawing.Size(535, 22);
			this.statusbar.TabIndex = 20;
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
			this.lnkCancelar.Click += new System.EventHandler(this.lnkCancelar_Click);
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
			this.bwRefreshEntities.WorkerSupportsCancellation = true;
			this.bwRefreshEntities.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwRefreshEntities_DoWork);
			this.bwRefreshEntities.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwRefreshEntities_RunWorkerCompleted);
			// 
			// pnlList
			// 
			this.pnlList.Controls.Add(this.lvLista);
			this.pnlList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlList.Location = new System.Drawing.Point(200, 101);
			this.pnlList.Name = "pnlList";
			this.pnlList.Size = new System.Drawing.Size(535, 400);
			this.pnlList.TabIndex = 22;
			// 
			// lvLista
			// 
			this.lvLista.AllowColumnReorder = true;
			this.lvLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lvLista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeader1,
            this.columnHeader2,
            columnHeader5,
            columnHeader3,
            this.columnHeader6,
            this.columnHeader7});
			this.lvLista.FullRowSelect = true;
			this.lvLista.HideSelection = false;
			this.lvLista.Location = new System.Drawing.Point(18, 16);
			this.lvLista.MultiSelect = false;
			this.lvLista.Name = "lvLista";
			this.lvLista.Size = new System.Drawing.Size(485, 342);
			this.lvLista.SmallImageList = this.imageList;
			this.lvLista.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.lvLista.TabIndex = 1;
			this.lvLista.UseCompatibleStateImageBehavior = false;
			this.lvLista.View = System.Windows.Forms.View.Details;
			this.lvLista.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvLista_ColumnClick);
			// 
			// columnHeader2
			// 
			this.columnHeader2.Tag = "Numeric";
			this.columnHeader2.Text = "Folio";
			this.columnHeader2.Width = 35;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Crítico";
			// 
			// columnHeader7
			// 
			this.columnHeader7.Tag = "ddMyyyyHHm";
			this.columnHeader7.Text = "Ult. Modificación";
			this.columnHeader7.Width = 110;
			// 
			// pnlFilters
			// 
			this.pnlFilters.Controls.Add(this.groupBox1);
			this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlFilters.Location = new System.Drawing.Point(200, 0);
			this.pnlFilters.Name = "pnlFilters";
			this.pnlFilters.Size = new System.Drawing.Size(535, 101);
			this.pnlFilters.TabIndex = 21;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cbCritico);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.cboEstado);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.btnLimpiar);
			this.groupBox1.Controls.Add(this.btnBuscar);
			this.groupBox1.Controls.Add(this.txtFilNombre);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Location = new System.Drawing.Point(18, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(485, 84);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Filtros de búsqueda";
			// 
			// cbCritico
			// 
			this.cbCritico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCritico.FormattingEnabled = true;
			this.cbCritico.Items.AddRange(new object[] {
            "Todos",
            "Si",
            "No"});
			this.cbCritico.Location = new System.Drawing.Point(224, 47);
			this.cbCritico.Name = "cbCritico";
			this.cbCritico.Size = new System.Drawing.Size(98, 21);
			this.cbCritico.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(180, 49);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(38, 13);
			this.label3.TabIndex = 22;
			this.label3.Text = "Crítico";
			// 
			// cboEstado
			// 
			this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboEstado.FormattingEnabled = true;
			this.cboEstado.Items.AddRange(new object[] {
            "Activos",
            "Inactivos",
            "Todos"});
			this.cboEstado.Location = new System.Drawing.Point(67, 46);
			this.cboEstado.Name = "cboEstado";
			this.cboEstado.Size = new System.Drawing.Size(98, 21);
			this.cboEstado.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(11, 49);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 13);
			this.label1.TabIndex = 21;
			this.label1.Text = "Estado";
			// 
			// btnLimpiar
			// 
			this.btnLimpiar.BackColor = System.Drawing.SystemColors.Control;
			this.btnLimpiar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnLimpiar.Location = new System.Drawing.Point(388, 50);
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
			this.btnBuscar.Location = new System.Drawing.Point(389, 22);
			this.btnBuscar.Name = "btnBuscar";
			this.btnBuscar.Size = new System.Drawing.Size(76, 21);
			this.btnBuscar.TabIndex = 3;
			this.btnBuscar.Text = "&Buscar";
			this.btnBuscar.UseVisualStyleBackColor = false;
			this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
			// 
			// txtFilNombre
			// 
			this.txtFilNombre.Location = new System.Drawing.Point(67, 20);
			this.txtFilNombre.Name = "txtFilNombre";
			this.txtFilNombre.Size = new System.Drawing.Size(304, 20);
			this.txtFilNombre.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(11, 23);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(44, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Nombre";
			// 
			// xppnlDBs
			// 
			this.xppnlDBs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.xppnlDBs.BackColor = System.Drawing.Color.Transparent;
			this.xppnlDBs.Caption = "Usuarios Aplicativos";
			this.xppnlDBs.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
			this.xppnlDBs.CaptionGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
			this.xppnlDBs.CaptionGradient.Start = System.Drawing.Color.White;
			this.xppnlDBs.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
			this.xppnlDBs.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.xppnlDBs.Controls.Add(this.lnkView);
			this.xppnlDBs.Controls.Add(this.lnkDelete);
			this.xppnlDBs.Controls.Add(this.lnkModify);
			this.xppnlDBs.Controls.Add(this.lnkAdd);
			this.xppnlDBs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
			this.xppnlDBs.ForeColor = System.Drawing.SystemColors.WindowText;
			this.xppnlDBs.HorzAlignment = System.Drawing.StringAlignment.Near;
			this.xppnlDBs.ImageItems.ImageSet = null;
			this.xppnlDBs.Location = new System.Drawing.Point(8, 8);
			this.xppnlDBs.Name = "xppnlDBs";
			this.xppnlDBs.PanelGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
			this.xppnlDBs.PanelGradient.Start = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
			this.xppnlDBs.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
			this.xppnlDBs.Size = new System.Drawing.Size(167, 141);
			this.xppnlDBs.TabIndex = 5;
			this.xppnlDBs.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
			this.xppnlDBs.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
			this.xppnlDBs.VertAlignment = System.Drawing.StringAlignment.Center;
			// 
			// lnkView
			// 
			this.lnkView.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
			this.lnkView.AutoSize = true;
			this.lnkView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
			this.lnkView.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.lnkView.LinkColor = System.Drawing.Color.MidnightBlue;
			this.lnkView.Location = new System.Drawing.Point(17, 92);
			this.lnkView.Name = "lnkView";
			this.lnkView.Size = new System.Drawing.Size(61, 13);
			this.lnkView.TabIndex = 11;
			this.lnkView.TabStop = true;
			this.lnkView.Text = "Visualizar";
			this.lnkView.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
			this.lnkView.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkView_LinkClicked);
			// 
			// lnkDelete
			// 
			this.lnkDelete.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
			this.lnkDelete.AutoSize = true;
			this.lnkDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
			this.lnkDelete.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.lnkDelete.LinkColor = System.Drawing.Color.MidnightBlue;
			this.lnkDelete.Location = new System.Drawing.Point(17, 113);
			this.lnkDelete.Name = "lnkDelete";
			this.lnkDelete.Size = new System.Drawing.Size(51, 13);
			this.lnkDelete.TabIndex = 10;
			this.lnkDelete.TabStop = true;
			this.lnkDelete.Text = "Eliminar";
			this.lnkDelete.Visible = false;
			this.lnkDelete.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
			// 
			// lnkModify
			// 
			this.lnkModify.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
			this.lnkModify.AutoSize = true;
			this.lnkModify.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
			this.lnkModify.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.lnkModify.LinkColor = System.Drawing.Color.MidnightBlue;
			this.lnkModify.Location = new System.Drawing.Point(17, 71);
			this.lnkModify.Name = "lnkModify";
			this.lnkModify.Size = new System.Drawing.Size(59, 13);
			this.lnkModify.TabIndex = 9;
			this.lnkModify.TabStop = true;
			this.lnkModify.Text = "Modificar";
			this.lnkModify.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
			this.lnkModify.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkModify_LinkClicked);
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
			// FATMPwd
			// 
			this.AcceptButton = this.btnBuscar;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(735, 501);
			this.Controls.Add(this.statusbar);
			this.Controls.Add(this.pnlList);
			this.Controls.Add(this.pnlFilters);
			this.Name = "FATMPwd";
			this.Load += new System.EventHandler(this.FAppPwd_Load);
			this.Controls.SetChildIndex(this.pnlIzq, 0);
			this.Controls.SetChildIndex(this.pnlFilters, 0);
			this.Controls.SetChildIndex(this.pnlList, 0);
			this.Controls.SetChildIndex(this.statusbar, 0);
			((System.ComponentModel.ISupportInitialize)(this.pnlXPGrps)).EndInit();
			this.pnlXPGrps.ResumeLayout(false);
			this.pnlIzq.ResumeLayout(false);
			this.statusbar.ResumeLayout(false);
			this.statusbar.PerformLayout();
			this.pnlList.ResumeLayout(false);
			this.pnlFilters.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.xppnlDBs.ResumeLayout(false);
			this.xppnlDBs.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusbar;
        private System.Windows.Forms.ToolStripProgressBar pbDB;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lnkCancelar;
        private System.Windows.Forms.ImageList imageList;
        private System.ComponentModel.BackgroundWorker bwRefreshEntities;
        private System.Windows.Forms.Panel pnlList;
        protected System.Windows.Forms.ListView lvLista;
        private System.Windows.Forms.Panel pnlFilters;
        protected System.Windows.Forms.GroupBox groupBox1;
        protected System.Windows.Forms.Button btnLimpiar;
        protected System.Windows.Forms.Button btnBuscar;
        protected System.Windows.Forms.TextBox txtFilNombre;
        protected System.Windows.Forms.Label label2;
        private UIComponents.XPPanel xppnlDBs;
        protected System.Windows.Forms.LinkLabel lnkView;
        protected System.Windows.Forms.LinkLabel lnkDelete;
        protected System.Windows.Forms.LinkLabel lnkModify;
        protected System.Windows.Forms.LinkLabel lnkAdd;
		private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ComboBox cboEstado;
        protected System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCritico;
        protected System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
    }
}
