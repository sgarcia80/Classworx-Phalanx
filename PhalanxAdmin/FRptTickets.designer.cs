namespace PhalanxAdmin
{
    partial class FRptTickets
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
            System.Windows.Forms.ColumnHeader colhdrDetail;
            System.Windows.Forms.ColumnHeader columnHeader1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRptTickets));
            this.statusbar = new System.Windows.Forms.StatusStrip();
            this.pbDB = new System.Windows.Forms.ToolStripProgressBar();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lnkCancelar = new System.Windows.Forms.ToolStripStatusLabel();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.bwRefreshEntities = new System.ComponentModel.BackgroundWorker();
            this.pnlList = new System.Windows.Forms.Panel();
            this.btnExportar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lvSolicitudes = new System.Windows.Forms.ListView();
            this.colhdrSolicitante = new System.Windows.Forms.ColumnHeader();
            this.colhdrFechaSolic = new System.Windows.Forms.ColumnHeader();
            this.colhdrFechaUltEstado = new System.Windows.Forms.ColumnHeader();
            this.colhdrEstado = new System.Windows.Forms.ColumnHeader();
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtFilNroSolic = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboEstados = new System.Windows.Forms.ComboBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            colhdrDetail = new System.Windows.Forms.ColumnHeader();
            columnHeader1 = new System.Windows.Forms.ColumnHeader();
            ((System.ComponentModel.ISupportInitialize)(this.pnlXPGrps)).BeginInit();
            this.pnlXPGrps.SuspendLayout();
            this.pnlIzq.SuspendLayout();
            this.statusbar.SuspendLayout();
            this.pnlList.SuspendLayout();
            this.pnlFilters.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.xppnlMenu.Location = new System.Drawing.Point(8, 8);
            // 
            // colhdrDetail
            // 
            colhdrDetail.Text = "Detalle de la contraseña";
            colhdrDetail.Width = 149;
            // 
            // columnHeader1
            // 
            columnHeader1.Tag = "Numeric";
            columnHeader1.Text = "Nro. Sol.";
            // 
            // statusbar
            // 
            this.statusbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pbDB,
            this.lblStatus,
            this.lnkCancelar});
            this.statusbar.Location = new System.Drawing.Point(200, 514);
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
            this.imageList.Images.SetKeyName(0, "apppwd.ico");
            this.imageList.Images.SetKeyName(1, "dbpwd.ico");
            this.imageList.Images.SetKeyName(2, "linuxpwd.ico");
            this.imageList.Images.SetKeyName(3, "winpwd.ico");
            this.imageList.Images.SetKeyName(4, "icono as400.png");
            this.imageList.Images.SetKeyName(5, "eqcom.png");
            // 
            // bwRefreshEntities
            // 
            this.bwRefreshEntities.WorkerSupportsCancellation = true;
            this.bwRefreshEntities.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwRefreshEntities_DoWork);
            this.bwRefreshEntities.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwRefreshEntities_RunWorkerCompleted);
            // 
            // pnlList
            // 
            this.pnlList.Controls.Add(this.btnExportar);
            this.pnlList.Controls.Add(this.button1);
            this.pnlList.Controls.Add(this.lvSolicitudes);
            this.pnlList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlList.Location = new System.Drawing.Point(200, 108);
            this.pnlList.Name = "pnlList";
            this.pnlList.Size = new System.Drawing.Size(535, 428);
            this.pnlList.TabIndex = 22;
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(156, 7);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(132, 21);
            this.btnExportar.TabIndex = 1;
            this.btnExportar.Text = "Exportar Listado a CSV";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 21);
            this.button1.TabIndex = 0;
            this.button1.Text = "Reporte de Uso";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lvSolicitudes
            // 
            this.lvSolicitudes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvSolicitudes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            colhdrDetail,
            columnHeader1,
            this.colhdrSolicitante,
            this.colhdrFechaSolic,
            this.colhdrFechaUltEstado,
            this.colhdrEstado});
            this.lvSolicitudes.FullRowSelect = true;
            this.lvSolicitudes.HideSelection = false;
            this.lvSolicitudes.Location = new System.Drawing.Point(18, 34);
            this.lvSolicitudes.Name = "lvSolicitudes";
            this.lvSolicitudes.Size = new System.Drawing.Size(485, 362);
            this.lvSolicitudes.SmallImageList = this.imageList;
            this.lvSolicitudes.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvSolicitudes.TabIndex = 2;
            this.lvSolicitudes.UseCompatibleStateImageBehavior = false;
            this.lvSolicitudes.View = System.Windows.Forms.View.Details;
            this.lvSolicitudes.DoubleClick += new System.EventHandler(this.lvSolicitudes_DoubleClick);
            this.lvSolicitudes.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvSolicitudes_ColumnClick);
            // 
            // colhdrSolicitante
            // 
            this.colhdrSolicitante.Text = "Solicitante";
            this.colhdrSolicitante.Width = 77;
            // 
            // colhdrFechaSolic
            // 
            this.colhdrFechaSolic.Text = "Fecha Solicitud";
            this.colhdrFechaSolic.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colhdrFechaSolic.Width = 91;
            // 
            // colhdrFechaUltEstado
            // 
            this.colhdrFechaUltEstado.Text = "Fecha Ultimo Estado";
            this.colhdrFechaUltEstado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colhdrFechaUltEstado.Width = 113;
            // 
            // colhdrEstado
            // 
            this.colhdrEstado.Text = "Estado";
            // 
            // pnlFilters
            // 
            this.pnlFilters.Controls.Add(this.groupBox1);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Location = new System.Drawing.Point(200, 0);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(535, 108);
            this.pnlFilters.TabIndex = 21;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtFilNroSolic);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboEstados);
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(18, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(485, 79);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de búsqueda";
            // 
            // txtFilNroSolic
            // 
            this.txtFilNroSolic.Location = new System.Drawing.Point(67, 48);
            this.txtFilNroSolic.MaxLength = 10;
            this.txtFilNroSolic.Name = "txtFilNroSolic";
            this.txtFilNroSolic.Size = new System.Drawing.Size(105, 20);
            this.txtFilNroSolic.TabIndex = 1;
            this.txtFilNroSolic.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilNroSolic_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Solicitud";
            // 
            // cboEstados
            // 
            this.cboEstados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstados.FormattingEnabled = true;
            this.cboEstados.Location = new System.Drawing.Point(67, 21);
            this.cboEstados.Name = "cboEstados";
            this.cboEstados.Size = new System.Drawing.Size(304, 21);
            this.cboEstados.TabIndex = 0;
            this.cboEstados.Tag = "0";
            this.cboEstados.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cboEstados_DrawItem);
            this.cboEstados.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboEstados_KeyDown);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.SystemColors.Control;
            this.btnLimpiar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnLimpiar.Location = new System.Drawing.Point(388, 22);
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
            this.btnBuscar.Location = new System.Drawing.Point(389, 50);
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
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Estados";
            // 
            // FRptTickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(735, 536);
            this.Controls.Add(this.statusbar);
            this.Controls.Add(this.pnlList);
            this.Controls.Add(this.pnlFilters);
            this.Name = "FRptTickets";
            this.Load += new System.EventHandler(this.FSolicitudes_Load);
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
        protected System.Windows.Forms.ListView lvSolicitudes;
        private System.Windows.Forms.Panel pnlFilters;
        protected System.Windows.Forms.GroupBox groupBox1;
        protected System.Windows.Forms.Button btnLimpiar;
        protected System.Windows.Forms.Button btnBuscar;
        protected System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader colhdrSolicitante;
        private System.Windows.Forms.ColumnHeader colhdrFechaSolic;
        private System.Windows.Forms.ColumnHeader colhdrFechaUltEstado;
        private System.Windows.Forms.ColumnHeader colhdrEstado;
        private System.Windows.Forms.ComboBox cboEstados;
        private System.Windows.Forms.Button button1;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.TextBox txtFilNroSolic;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}
