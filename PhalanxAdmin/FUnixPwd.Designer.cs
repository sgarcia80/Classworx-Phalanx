namespace PhalanxAdmin
{
    partial class FUnixPwd
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
            System.Windows.Forms.ColumnHeader columnHeader1;
            System.Windows.Forms.ColumnHeader columnHeader3;
            System.Windows.Forms.ColumnHeader columnHeader4;
            System.Windows.Forms.ColumnHeader columnHeader2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FUnixPwd));
            this.xppnlWinPwd = new UIComponents.XPPanel(141);
            this.lnkView = new System.Windows.Forms.LinkLabel();
            this.lnkDelete = new System.Windows.Forms.LinkLabel();
            this.lnkModify = new System.Windows.Forms.LinkLabel();
            this.lnkAdd = new System.Windows.Forms.LinkLabel();
            this.bwRefreshEntities = new System.ComponentModel.BackgroundWorker();
            this.statusbar = new System.Windows.Forms.StatusStrip();
            this.pbDB = new System.Windows.Forms.ToolStripProgressBar();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lnkCancelar = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlList = new System.Windows.Forms.Panel();
            this.lvLista = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
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
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.pnlXPGrps)).BeginInit();
            this.pnlXPGrps.SuspendLayout();
            this.pnlIzq.SuspendLayout();
            this.xppnlWinPwd.SuspendLayout();
            this.statusbar.SuspendLayout();
            this.pnlList.SuspendLayout();
            this.pnlFilters.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.pnlXPGrps.Controls.Add(this.xppnlWinPwd);
            this.pnlXPGrps.Size = new System.Drawing.Size(200, 502);
            this.pnlXPGrps.Controls.SetChildIndex(this.pnlchk, 0);
            this.pnlXPGrps.Controls.SetChildIndex(this.xppnlMenu, 0);
            this.pnlXPGrps.Controls.SetChildIndex(this.xppnlWinPwd, 0);
            // 
            // pnlIzq
            // 
            this.pnlIzq.Size = new System.Drawing.Size(200, 502);
            // 
            // xppnlMenu
            // 
            this.xppnlMenu.ImageItems.ImageSet = null;
            this.xppnlMenu.Location = new System.Drawing.Point(8, 157);
            this.xppnlMenu.Size = new System.Drawing.Size(167, 200);
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Equipo";
            columnHeader1.Width = 130;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Usuario";
            columnHeader3.Width = 130;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "IP";
            columnHeader4.Width = 90;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "";
            columnHeader2.Width = 30;
            // 
            // xppnlWinPwd
            // 
            this.xppnlWinPwd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xppnlWinPwd.BackColor = System.Drawing.Color.Transparent;
            this.xppnlWinPwd.Caption = "Usuarios Unix";
            this.xppnlWinPwd.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xppnlWinPwd.CaptionGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
            this.xppnlWinPwd.CaptionGradient.Start = System.Drawing.Color.White;
            this.xppnlWinPwd.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xppnlWinPwd.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xppnlWinPwd.Controls.Add(this.lnkView);
            this.xppnlWinPwd.Controls.Add(this.lnkDelete);
            this.xppnlWinPwd.Controls.Add(this.lnkModify);
            this.xppnlWinPwd.Controls.Add(this.lnkAdd);
            this.xppnlWinPwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.xppnlWinPwd.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xppnlWinPwd.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xppnlWinPwd.ImageItems.ImageSet = null;
            this.xppnlWinPwd.Location = new System.Drawing.Point(8, 8);
            this.xppnlWinPwd.Name = "xppnlWinPwd";
            this.xppnlWinPwd.PanelGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.xppnlWinPwd.PanelGradient.Start = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.xppnlWinPwd.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xppnlWinPwd.Size = new System.Drawing.Size(167, 141);
            this.xppnlWinPwd.TabIndex = 4;
            this.xppnlWinPwd.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.xppnlWinPwd.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.xppnlWinPwd.VertAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lnkView
            // 
            this.lnkView.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkView.AutoSize = true;
            this.lnkView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.lnkView.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkView.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkView.Location = new System.Drawing.Point(17, 113);
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
            this.lnkDelete.Location = new System.Drawing.Point(17, 92);
            this.lnkDelete.Name = "lnkDelete";
            this.lnkDelete.Size = new System.Drawing.Size(32, 13);
            this.lnkDelete.TabIndex = 10;
            this.lnkDelete.TabStop = true;
            this.lnkDelete.Text = "Baja";
            this.lnkDelete.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkDelete.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDelete_LinkClicked);
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
            // bwRefreshEntities
            // 
            this.bwRefreshEntities.WorkerSupportsCancellation = true;
            this.bwRefreshEntities.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwRefreshEntities_DoWork);
            this.bwRefreshEntities.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwRefreshEntities_RunWorkerCompleted);
            // 
            // statusbar
            // 
            this.statusbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pbDB,
            this.lblStatus,
            this.lnkCancelar});
            this.statusbar.Location = new System.Drawing.Point(200, 480);
            this.statusbar.Name = "statusbar";
            this.statusbar.Size = new System.Drawing.Size(527, 22);
            this.statusbar.TabIndex = 14;
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
            // pnlList
            // 
            this.pnlList.Controls.Add(this.lvLista);
            this.pnlList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlList.Location = new System.Drawing.Point(200, 92);
            this.pnlList.Name = "pnlList";
            this.pnlList.Size = new System.Drawing.Size(527, 410);
            this.pnlList.TabIndex = 16;
            this.pnlList.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlList_Paint);
            // 
            // lvLista
            // 
            this.lvLista.AllowColumnReorder = true;
            this.lvLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvLista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeader2,
            this.columnHeader5,
            columnHeader1,
            columnHeader3,
            columnHeader4,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.lvLista.FullRowSelect = true;
            this.lvLista.HideSelection = false;
            this.lvLista.Location = new System.Drawing.Point(18, 16);
            this.lvLista.MultiSelect = false;
            this.lvLista.Name = "lvLista";
            this.lvLista.Size = new System.Drawing.Size(485, 351);
            this.lvLista.SmallImageList = this.imageList;
            this.lvLista.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvLista.TabIndex = 1;
            this.lvLista.UseCompatibleStateImageBehavior = false;
            this.lvLista.View = System.Windows.Forms.View.Details;
            this.lvLista.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvLista_ColumnClick);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Folio";
            this.columnHeader5.Width = 35;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Tag = "Numeric";
            this.columnHeader6.Text = "Grupos";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Crítico";
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Active.jpg");
            this.imageList.Images.SetKeyName(1, "Desactivo.jpg");
            // 
            // pnlFilters
            // 
            this.pnlFilters.Controls.Add(this.groupBox1);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Location = new System.Drawing.Point(200, 0);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(527, 92);
            this.pnlFilters.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
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
            this.groupBox1.Size = new System.Drawing.Size(485, 78);
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
            this.cbCritico.Location = new System.Drawing.Point(215, 48);
            this.cbCritico.Name = "cbCritico";
            this.cbCritico.Size = new System.Drawing.Size(98, 21);
            this.cbCritico.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(174, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Crítico";
            // 
            // cboEstado
            // 
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Items.AddRange(new object[] {
            "Activas",
            "Inactivas",
            "Todas"});
            this.cboEstado.Location = new System.Drawing.Point(67, 47);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(98, 21);
            this.cboEstado.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 6;
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
            // columnHeader8
            // 
            this.columnHeader8.Tag = "ddMyyyyHHm";
            this.columnHeader8.Text = "Ult. Modificación";
            this.columnHeader8.Width = 110;
            // 
            // FUnixPwd
            // 
            this.AcceptButton = this.btnBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(727, 502);
            this.Controls.Add(this.statusbar);
            this.Controls.Add(this.pnlList);
            this.Controls.Add(this.pnlFilters);
            this.Name = "FUnixPwd";
            this.Load += new System.EventHandler(this.FUnixPwd_Load);
            this.Controls.SetChildIndex(this.pnlIzq, 0);
            this.Controls.SetChildIndex(this.pnlFilters, 0);
            this.Controls.SetChildIndex(this.pnlList, 0);
            this.Controls.SetChildIndex(this.statusbar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pnlXPGrps)).EndInit();
            this.pnlXPGrps.ResumeLayout(false);
            this.pnlIzq.ResumeLayout(false);
            this.xppnlWinPwd.ResumeLayout(false);
            this.xppnlWinPwd.PerformLayout();
            this.statusbar.ResumeLayout(false);
            this.statusbar.PerformLayout();
            this.pnlList.ResumeLayout(false);
            this.pnlFilters.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UIComponents.XPPanel xppnlWinPwd;
        protected System.Windows.Forms.LinkLabel lnkView;
        protected System.Windows.Forms.LinkLabel lnkDelete;
        protected System.Windows.Forms.LinkLabel lnkModify;
        protected System.Windows.Forms.LinkLabel lnkAdd;
        private System.ComponentModel.BackgroundWorker bwRefreshEntities;
        private System.Windows.Forms.StatusStrip statusbar;
        private System.Windows.Forms.ToolStripProgressBar pbDB;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lnkCancelar;
        private System.Windows.Forms.Panel pnlList;
        protected System.Windows.Forms.ListView lvLista;
        private System.Windows.Forms.Panel pnlFilters;
        protected System.Windows.Forms.GroupBox groupBox1;
        protected System.Windows.Forms.Button btnLimpiar;
        protected System.Windows.Forms.Button btnBuscar;
        protected System.Windows.Forms.TextBox txtFilNombre;
        protected System.Windows.Forms.Label label2;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ComboBox cboEstado;
        protected System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ComboBox cbCritico;
        protected System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader columnHeader8;
    }
}
