namespace PhalanxAdmin
{
    partial class FMacroUsuarioTarjeta
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
            System.Windows.Forms.ColumnHeader colAplicacion;
            this.xppnlDBs = new UIComponents.XPPanel(145);
            this.lnkRefrescar = new System.Windows.Forms.LinkLabel();
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.txtArchivo = new System.Windows.Forms.TextBox();
            this.btnImportar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAplicacion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUsuarioTC = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsuarioRed = new System.Windows.Forms.TextBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlList = new System.Windows.Forms.Panel();
            this.statusbar = new System.Windows.Forms.StatusStrip();
            this.pbDB = new System.Windows.Forms.ToolStripProgressBar();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lnkCancelar = new System.Windows.Forms.ToolStripStatusLabel();
            this.lvLista = new System.Windows.Forms.ListView();
            this.colDominio = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUsuarioRed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUsuarioTC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bwRefreshEntities = new System.ComponentModel.BackgroundWorker();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.colObservaciones = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            colAplicacion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.pnlXPGrps)).BeginInit();
            this.pnlXPGrps.SuspendLayout();
            this.pnlIzq.SuspendLayout();
            this.xppnlDBs.SuspendLayout();
            this.pnlFilters.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlList.SuspendLayout();
            this.statusbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlXPGrps
            // 
            this.pnlXPGrps.Controls.Add(this.xppnlDBs);
            this.pnlXPGrps.Size = new System.Drawing.Size(200, 595);
            this.pnlXPGrps.Controls.SetChildIndex(this.xppnlMenu, 0);
            this.pnlXPGrps.Controls.SetChildIndex(this.xppnlDBs, 0);
            // 
            // pnlIzq
            // 
            this.pnlIzq.Size = new System.Drawing.Size(200, 595);
            // 
            // xppnlMenu
            // 
            this.xppnlMenu.ImageItems.ImageSet = null;
            this.xppnlMenu.Location = new System.Drawing.Point(8, 161);
            this.xppnlMenu.TabIndex = 1;
            // 
            // colAplicacion
            // 
            colAplicacion.Text = "Aplicación";
            colAplicacion.Width = 120;
            // 
            // xppnlDBs
            // 
            this.xppnlDBs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xppnlDBs.BackColor = System.Drawing.Color.Transparent;
            this.xppnlDBs.Caption = "Usuarios de Tarjetas";
            this.xppnlDBs.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xppnlDBs.CaptionGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
            this.xppnlDBs.CaptionGradient.Start = System.Drawing.Color.White;
            this.xppnlDBs.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xppnlDBs.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xppnlDBs.Controls.Add(this.lnkRefrescar);
            this.xppnlDBs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.xppnlDBs.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xppnlDBs.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xppnlDBs.ImageItems.ImageSet = null;
            this.xppnlDBs.Location = new System.Drawing.Point(8, 8);
            this.xppnlDBs.Name = "xppnlDBs";
            this.xppnlDBs.PanelGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.xppnlDBs.PanelGradient.Start = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.xppnlDBs.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xppnlDBs.Size = new System.Drawing.Size(184, 145);
            this.xppnlDBs.TabIndex = 0;
            this.xppnlDBs.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.xppnlDBs.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.xppnlDBs.VertAlignment = System.Drawing.StringAlignment.Center;
            this.xppnlDBs.Visible = false;
            // 
            // lnkRefrescar
            // 
            this.lnkRefrescar.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkRefrescar.AutoSize = true;
            this.lnkRefrescar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.lnkRefrescar.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkRefrescar.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkRefrescar.Location = new System.Drawing.Point(18, 50);
            this.lnkRefrescar.Name = "lnkRefrescar";
            this.lnkRefrescar.Size = new System.Drawing.Size(51, 13);
            this.lnkRefrescar.TabIndex = 0;
            this.lnkRefrescar.TabStop = true;
            this.lnkRefrescar.Text = "Agregar";
            this.lnkRefrescar.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            // 
            // pnlFilters
            // 
            this.pnlFilters.Controls.Add(this.groupBox2);
            this.pnlFilters.Controls.Add(this.groupBox1);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Location = new System.Drawing.Point(200, 0);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(692, 163);
            this.pnlFilters.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSeleccionar);
            this.groupBox2.Controls.Add(this.txtArchivo);
            this.groupBox2.Controls.Add(this.btnImportar);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(18, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(662, 55);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Carga Masiva";
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.BackColor = System.Drawing.SystemColors.Control;
            this.btnSeleccionar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSeleccionar.Location = new System.Drawing.Point(509, 19);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(30, 21);
            this.btnSeleccionar.TabIndex = 5;
            this.btnSeleccionar.Text = "...";
            this.btnSeleccionar.UseVisualStyleBackColor = false;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // txtArchivo
            // 
            this.txtArchivo.Location = new System.Drawing.Point(60, 20);
            this.txtArchivo.MaxLength = 50;
            this.txtArchivo.Name = "txtArchivo";
            this.txtArchivo.ReadOnly = true;
            this.txtArchivo.Size = new System.Drawing.Size(443, 20);
            this.txtArchivo.TabIndex = 4;
            // 
            // btnImportar
            // 
            this.btnImportar.BackColor = System.Drawing.SystemColors.Control;
            this.btnImportar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnImportar.Location = new System.Drawing.Point(580, 19);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(76, 21);
            this.btnImportar.TabIndex = 2;
            this.btnImportar.Text = "Importar";
            this.btnImportar.UseVisualStyleBackColor = false;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Archivo";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtAplicacion);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtUsuarioTC);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtUsuarioRed);
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(18, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(662, 84);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de búsqueda";
            // 
            // txtAplicacion
            // 
            this.txtAplicacion.Location = new System.Drawing.Point(288, 20);
            this.txtAplicacion.MaxLength = 50;
            this.txtAplicacion.Name = "txtAplicacion";
            this.txtAplicacion.Size = new System.Drawing.Size(100, 20);
            this.txtAplicacion.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(226, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Aplicación";
            // 
            // txtUsuarioTC
            // 
            this.txtUsuarioTC.Location = new System.Drawing.Point(96, 47);
            this.txtUsuarioTC.MaxLength = 50;
            this.txtUsuarioTC.Name = "txtUsuarioTC";
            this.txtUsuarioTC.Size = new System.Drawing.Size(100, 20);
            this.txtUsuarioTC.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Usuario Tarjeta";
            // 
            // txtUsuarioRed
            // 
            this.txtUsuarioRed.Location = new System.Drawing.Point(96, 21);
            this.txtUsuarioRed.MaxLength = 50;
            this.txtUsuarioRed.Name = "txtUsuarioRed";
            this.txtUsuarioRed.Size = new System.Drawing.Size(100, 20);
            this.txtUsuarioRed.TabIndex = 4;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.SystemColors.Control;
            this.btnLimpiar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnLimpiar.Location = new System.Drawing.Point(411, 19);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(76, 21);
            this.btnLimpiar.TabIndex = 2;
            this.btnLimpiar.Text = "&Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.SystemColors.Control;
            this.btnBuscar.Location = new System.Drawing.Point(412, 47);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(76, 21);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Usuario Red";
            // 
            // pnlList
            // 
            this.pnlList.Controls.Add(this.statusbar);
            this.pnlList.Controls.Add(this.lvLista);
            this.pnlList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlList.Location = new System.Drawing.Point(200, 163);
            this.pnlList.Name = "pnlList";
            this.pnlList.Size = new System.Drawing.Size(692, 432);
            this.pnlList.TabIndex = 1;
            // 
            // statusbar
            // 
            this.statusbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pbDB,
            this.lblStatus,
            this.lnkCancelar});
            this.statusbar.Location = new System.Drawing.Point(0, 410);
            this.statusbar.Name = "statusbar";
            this.statusbar.Size = new System.Drawing.Size(692, 22);
            this.statusbar.TabIndex = 1;
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
            // lvLista
            // 
            this.lvLista.AllowColumnReorder = true;
            this.lvLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvLista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDominio,
            this.colUsuarioRed,
            colAplicacion,
            this.colUsuarioTC,
            this.colObservaciones});
            this.lvLista.HideSelection = false;
            this.lvLista.Location = new System.Drawing.Point(18, 16);
            this.lvLista.MultiSelect = false;
            this.lvLista.Name = "lvLista";
            this.lvLista.Size = new System.Drawing.Size(662, 313);
            this.lvLista.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvLista.TabIndex = 0;
            this.lvLista.UseCompatibleStateImageBehavior = false;
            this.lvLista.View = System.Windows.Forms.View.Details;
            this.lvLista.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvLista_ColumnClick);
            // 
            // colDominio
            // 
            this.colDominio.Text = "Dominio";
            this.colDominio.Width = 110;
            // 
            // colUsuarioRed
            // 
            this.colUsuarioRed.Text = "Usuario Red";
            this.colUsuarioRed.Width = 110;
            // 
            // colUsuarioTC
            // 
            this.colUsuarioTC.Text = "Usuario TC";
            this.colUsuarioTC.Width = 150;
            // 
            // bwRefreshEntities
            // 
            this.bwRefreshEntities.WorkerSupportsCancellation = true;
            this.bwRefreshEntities.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwRefreshEntities_DoWork);
            this.bwRefreshEntities.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwRefreshEntities_RunWorkerCompleted);
            // 
            // colObservaciones
            // 
            this.colObservaciones.Text = "";
            this.colObservaciones.Width = 200;
            // 
            // FMacroUsuarioTarjeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(892, 595);
            this.Controls.Add(this.pnlList);
            this.Controls.Add(this.pnlFilters);
            this.Name = "FMacroUsuarioTarjeta";
            this.Load += new System.EventHandler(this.FMacroUsuarios_Load);
            this.Controls.SetChildIndex(this.pnlIzq, 0);
            this.Controls.SetChildIndex(this.pnlFilters, 0);
            this.Controls.SetChildIndex(this.pnlList, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pnlXPGrps)).EndInit();
            this.pnlXPGrps.ResumeLayout(false);
            this.pnlIzq.ResumeLayout(false);
            this.xppnlDBs.ResumeLayout(false);
            this.xppnlDBs.PerformLayout();
            this.pnlFilters.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlList.ResumeLayout(false);
            this.pnlList.PerformLayout();
            this.statusbar.ResumeLayout(false);
            this.statusbar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UIComponents.XPPanel xppnlDBs;
        private System.Windows.Forms.Panel pnlFilters;
        protected System.Windows.Forms.GroupBox groupBox1;
        protected System.Windows.Forms.Button btnLimpiar;
        protected System.Windows.Forms.Button btnBuscar;
        protected System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlList;
        private System.Windows.Forms.StatusStrip statusbar;
        private System.Windows.Forms.ToolStripProgressBar pbDB;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lnkCancelar;
        protected System.Windows.Forms.ListView lvLista;
        private System.ComponentModel.BackgroundWorker bwRefreshEntities;
        private System.Windows.Forms.ColumnHeader colDominio;
        private System.Windows.Forms.ColumnHeader colUsuarioRed;
        private System.Windows.Forms.ColumnHeader colUsuarioTC;
        protected System.Windows.Forms.LinkLabel lnkRefrescar;
        private System.Windows.Forms.TextBox txtUsuarioTC;
        protected System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsuarioRed;
        private System.Windows.Forms.TextBox txtAplicacion;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.GroupBox groupBox2;
        protected System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.TextBox txtArchivo;
        protected System.Windows.Forms.Button btnImportar;
        protected System.Windows.Forms.Label label6;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ColumnHeader colObservaciones;
    }
}
