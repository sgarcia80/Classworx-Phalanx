namespace PhalanxAdmin
{
    partial class FRptTicketsClaves
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
            System.Windows.Forms.ColumnHeader columnHeader1;
            System.Windows.Forms.ColumnHeader columnHeader2;
            System.Windows.Forms.ColumnHeader columnHeader4;
            System.Windows.Forms.ColumnHeader columnHeader5;
            System.Windows.Forms.ColumnHeader columnHeader6;
            System.Windows.Forms.ColumnHeader columnHeader7;
            System.Windows.Forms.ColumnHeader columnHeader9;
            System.Windows.Forms.ColumnHeader columnHeader8;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRptTicketsClaves));
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFilDominio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFilUsuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFilApp = new System.Windows.Forms.ComboBox();
            this.txtFHasta = new System.Windows.Forms.MaskedTextBox();
            this.txtFDesde = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.bwRefreshEntities = new System.ComponentModel.BackgroundWorker();
            this.statusbar = new System.Windows.Forms.StatusStrip();
            this.pbDB = new System.Windows.Forms.ToolStripProgressBar();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lnkCancelar = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlList = new System.Windows.Forms.Panel();
            this.btnVer = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.lvLista = new System.Windows.Forms.ListView();
            this.imglstTickets = new System.Windows.Forms.ImageList(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.pnlXPGrps)).BeginInit();
            this.pnlXPGrps.SuspendLayout();
            this.pnlIzq.SuspendLayout();
            this.pnlFilters.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusbar.SuspendLayout();
            this.pnlList.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlXPGrps
            // 
            this.pnlXPGrps.Size = new System.Drawing.Size(200, 524);
            // 
            // pnlIzq
            // 
            this.pnlIzq.Size = new System.Drawing.Size(200, 524);
            // 
            // xppnlMenu
            // 
            this.xppnlMenu.ImageItems.ImageSet = null;
            // 
            // columnHeader3
            // 
            columnHeader3.Tag = "ddMMyyyyHHmss";
            columnHeader3.Text = "Fecha";
            columnHeader3.Width = 130;
            // 
            // columnHeader1
            // 
            columnHeader1.Tag = "Numeric";
            columnHeader1.Text = "Nro Doc";
            columnHeader1.Width = 90;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Usuario";
            columnHeader2.Width = 120;
            // 
            // columnHeader4
            // 
            columnHeader4.Tag = "ddMMyyyyHHmss";
            columnHeader4.Text = "Fecha de Notificación";
            columnHeader4.Width = 137;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Aplicación";
            columnHeader5.Width = 104;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Usuario Dominio";
            columnHeader6.Width = 125;
            // 
            // columnHeader7
            // 
            columnHeader7.Tag = "Numeric";
            columnHeader7.Text = "Legajo";
            // 
            // columnHeader9
            // 
            columnHeader9.Tag = "Numeric";
            columnHeader9.Text = "Nro. Tkt. BPM";
            columnHeader9.Width = 66;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Corregido";
            // 
            // pnlFilters
            // 
            this.pnlFilters.Controls.Add(this.groupBox1);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Location = new System.Drawing.Point(200, 0);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(520, 143);
            this.pnlFilters.TabIndex = 21;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtFilDominio);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtFilUsuario);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbFilApp);
            this.groupBox1.Controls.Add(this.txtFHasta);
            this.groupBox1.Controls.Add(this.txtFDesde);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Location = new System.Drawing.Point(18, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(490, 129);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de búsqueda";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(211, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Dominio";
            // 
            // txtFilDominio
            // 
            this.txtFilDominio.Location = new System.Drawing.Point(273, 94);
            this.txtFilDominio.Name = "txtFilDominio";
            this.txtFilDominio.Size = new System.Drawing.Size(112, 20);
            this.txtFilDominio.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Usuario";
            // 
            // txtFilUsuario
            // 
            this.txtFilUsuario.Location = new System.Drawing.Point(73, 94);
            this.txtFilUsuario.Name = "txtFilUsuario";
            this.txtFilUsuario.Size = new System.Drawing.Size(112, 20);
            this.txtFilUsuario.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Aplicación";
            // 
            // cbFilApp
            // 
            this.cbFilApp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilApp.FormattingEnabled = true;
            this.cbFilApp.Location = new System.Drawing.Point(73, 58);
            this.cbFilApp.Name = "cbFilApp";
            this.cbFilApp.Size = new System.Drawing.Size(312, 21);
            this.cbFilApp.TabIndex = 17;
            // 
            // txtFHasta
            // 
            this.txtFHasta.Location = new System.Drawing.Point(273, 23);
            this.txtFHasta.Mask = "00/00/0000";
            this.txtFHasta.Name = "txtFHasta";
            this.txtFHasta.Size = new System.Drawing.Size(90, 20);
            this.txtFHasta.TabIndex = 5;
            this.txtFHasta.ValidatingType = typeof(System.DateTime);
            // 
            // txtFDesde
            // 
            this.txtFDesde.Location = new System.Drawing.Point(73, 23);
            this.txtFDesde.Mask = "00/00/0000";
            this.txtFDesde.Name = "txtFDesde";
            this.txtFDesde.Size = new System.Drawing.Size(90, 20);
            this.txtFDesde.TabIndex = 4;
            this.txtFDesde.ValidatingType = typeof(System.DateTime);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(211, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Hasta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Desde";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.SystemColors.Control;
            this.btnLimpiar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnLimpiar.Location = new System.Drawing.Point(408, 23);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(76, 21);
            this.btnLimpiar.TabIndex = 6;
            this.btnLimpiar.Text = "&Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.SystemColors.Control;
            this.btnBuscar.Location = new System.Drawing.Point(408, 50);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(76, 21);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
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
            this.statusbar.Location = new System.Drawing.Point(200, 502);
            this.statusbar.Name = "statusbar";
            this.statusbar.Size = new System.Drawing.Size(520, 22);
            this.statusbar.TabIndex = 22;
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
            this.pnlList.Controls.Add(this.btnVer);
            this.pnlList.Controls.Add(this.btnExportar);
            this.pnlList.Controls.Add(this.lvLista);
            this.pnlList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlList.Location = new System.Drawing.Point(200, 143);
            this.pnlList.Name = "pnlList";
            this.pnlList.Size = new System.Drawing.Size(520, 359);
            this.pnlList.TabIndex = 23;
            // 
            // btnVer
            // 
            this.btnVer.BackColor = System.Drawing.SystemColors.Control;
            this.btnVer.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnVer.Location = new System.Drawing.Point(178, 6);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(76, 21);
            this.btnVer.TabIndex = 7;
            this.btnVer.Text = "Ver";
            this.btnVer.UseVisualStyleBackColor = false;
            this.btnVer.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(18, 6);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(132, 21);
            this.btnExportar.TabIndex = 2;
            this.btnExportar.Text = "Exportar Listado a CSV";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // lvLista
            // 
            this.lvLista.AllowColumnReorder = true;
            this.lvLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvLista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeader9,
            columnHeader5,
            columnHeader2,
            columnHeader6,
            columnHeader3,
            columnHeader7,
            columnHeader1,
            columnHeader4,
            columnHeader8});
            this.lvLista.FullRowSelect = true;
            this.lvLista.HideSelection = false;
            this.lvLista.Location = new System.Drawing.Point(18, 33);
            this.lvLista.MultiSelect = false;
            this.lvLista.Name = "lvLista";
            this.lvLista.Size = new System.Drawing.Size(490, 319);
            this.lvLista.SmallImageList = this.imglstTickets;
            this.lvLista.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvLista.TabIndex = 1;
            this.lvLista.UseCompatibleStateImageBehavior = false;
            this.lvLista.View = System.Windows.Forms.View.Details;
            this.lvLista.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvLista_ColumnClick);
            // 
            // imglstTickets
            // 
            this.imglstTickets.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglstTickets.ImageStream")));
            this.imglstTickets.TransparentColor = System.Drawing.Color.Transparent;
            this.imglstTickets.Images.SetKeyName(0, "IconWarning.gif");
            // 
            // FRptTicketsClaves
            // 
            this.AcceptButton = this.btnBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(720, 524);
            this.Controls.Add(this.pnlList);
            this.Controls.Add(this.statusbar);
            this.Controls.Add(this.pnlFilters);
            this.Name = "FRptTicketsClaves";
            this.Load += new System.EventHandler(this.FRptTicketsClaves_Load);
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
        private System.Windows.Forms.MaskedTextBox txtFHasta;
        private System.Windows.Forms.MaskedTextBox txtFDesde;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        protected System.Windows.Forms.Button btnLimpiar;
        protected System.Windows.Forms.Button btnBuscar;
        private System.ComponentModel.BackgroundWorker bwRefreshEntities;
        private System.Windows.Forms.StatusStrip statusbar;
        private System.Windows.Forms.ToolStripProgressBar pbDB;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lnkCancelar;
        private System.Windows.Forms.Panel pnlList;
        protected System.Windows.Forms.ListView lvLista;
        private System.Windows.Forms.Label label5;
        protected System.Windows.Forms.TextBox txtFilDominio;
        private System.Windows.Forms.Label label2;
        protected System.Windows.Forms.TextBox txtFilUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbFilApp;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ImageList imglstTickets;
        protected System.Windows.Forms.Button btnVer;
    }
}
