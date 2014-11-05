namespace PhalanxAdmin
{
	partial class FRptListadoDePwd
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
			System.Windows.Forms.ColumnHeader columnHeader9;
			System.Windows.Forms.ColumnHeader columnHeader5;
			System.Windows.Forms.ColumnHeader columnHeader2;
			System.Windows.Forms.ColumnHeader columnHeader3;
			System.Windows.Forms.ColumnHeader columnHeader7;
			System.Windows.Forms.ColumnHeader columnHeader8;
			this.statusbar = new System.Windows.Forms.StatusStrip();
			this.pbDB = new System.Windows.Forms.ToolStripProgressBar();
			this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.lnkCancelar = new System.Windows.Forms.ToolStripStatusLabel();
			this.pnlFilters = new System.Windows.Forms.Panel();
			this.button1 = new System.Windows.Forms.Button();
			this.btnBuscar = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.rbOrderUsrPath = new System.Windows.Forms.RadioButton();
			this.rbOrderFolio = new System.Windows.Forms.RadioButton();
			this.rbOrderUsrName = new System.Windows.Forms.RadioButton();
			this.pnlList = new System.Windows.Forms.Panel();
			this.lvLista = new System.Windows.Forms.ListView();
			this.bwRefreshEntities = new System.ComponentModel.BackgroundWorker();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			((System.ComponentModel.ISupportInitialize)(this.pnlXPGrps)).BeginInit();
			this.pnlXPGrps.SuspendLayout();
			this.pnlIzq.SuspendLayout();
			this.statusbar.SuspendLayout();
			this.pnlFilters.SuspendLayout();
			this.groupBox2.SuspendLayout();
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
			// columnHeader9
			// 
			columnHeader9.Text = "Folio";
			columnHeader9.Width = 66;
			// 
			// columnHeader5
			// 
			columnHeader5.Text = "Ambiente";
			// 
			// columnHeader2
			// 
			columnHeader2.Text = "Usuario";
			columnHeader2.Width = 120;
			// 
			// columnHeader3
			// 
			columnHeader3.Tag = "ddMMyyyyHHmss";
			columnHeader3.Text = "Contraseña";
			columnHeader3.Width = 130;
			// 
			// columnHeader7
			// 
			columnHeader7.Text = "Estado";
			// 
			// columnHeader8
			// 
			columnHeader8.Tag = "ddMMyyyyHHmss";
			columnHeader8.Text = "Fecha de última modificación";
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
			this.statusbar.TabIndex = 23;
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
			// pnlFilters
			// 
			this.pnlFilters.Controls.Add(this.button1);
			this.pnlFilters.Controls.Add(this.btnBuscar);
			this.pnlFilters.Controls.Add(this.groupBox2);
			this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlFilters.Location = new System.Drawing.Point(200, 0);
			this.pnlFilters.Name = "pnlFilters";
			this.pnlFilters.Size = new System.Drawing.Size(520, 75);
			this.pnlFilters.TabIndex = 24;
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.SystemColors.Control;
			this.button1.Location = new System.Drawing.Point(400, 45);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(117, 21);
			this.button1.TabIndex = 18;
			this.button1.Text = "&Exportar a PDF";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// btnBuscar
			// 
			this.btnBuscar.BackColor = System.Drawing.SystemColors.Control;
			this.btnBuscar.Location = new System.Drawing.Point(400, 12);
			this.btnBuscar.Name = "btnBuscar";
			this.btnBuscar.Size = new System.Drawing.Size(117, 21);
			this.btnBuscar.TabIndex = 1;
			this.btnBuscar.Text = "&Visualizar";
			this.btnBuscar.UseVisualStyleBackColor = false;
			this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click_1);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.rbOrderUsrPath);
			this.groupBox2.Controls.Add(this.rbOrderFolio);
			this.groupBox2.Controls.Add(this.rbOrderUsrName);
			this.groupBox2.Location = new System.Drawing.Point(18, 8);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(319, 44);
			this.groupBox2.TabIndex = 17;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Ordenar por";
			// 
			// rbOrderUsrPath
			// 
			this.rbOrderUsrPath.AutoSize = true;
			this.rbOrderUsrPath.Location = new System.Drawing.Point(201, 19);
			this.rbOrderUsrPath.Name = "rbOrderUsrPath";
			this.rbOrderUsrPath.Size = new System.Drawing.Size(102, 17);
			this.rbOrderUsrPath.TabIndex = 2;
			this.rbOrderUsrPath.Text = "Ruta de Usuario";
			this.rbOrderUsrPath.UseVisualStyleBackColor = true;
			// 
			// rbOrderFolio
			// 
			this.rbOrderFolio.AutoSize = true;
			this.rbOrderFolio.Checked = true;
			this.rbOrderFolio.Location = new System.Drawing.Point(6, 19);
			this.rbOrderFolio.Name = "rbOrderFolio";
			this.rbOrderFolio.Size = new System.Drawing.Size(47, 17);
			this.rbOrderFolio.TabIndex = 0;
			this.rbOrderFolio.TabStop = true;
			this.rbOrderFolio.Text = "Folio";
			this.rbOrderFolio.UseVisualStyleBackColor = true;
			// 
			// rbOrderUsrName
			// 
			this.rbOrderUsrName.AutoSize = true;
			this.rbOrderUsrName.Location = new System.Drawing.Point(70, 19);
			this.rbOrderUsrName.Name = "rbOrderUsrName";
			this.rbOrderUsrName.Size = new System.Drawing.Size(116, 17);
			this.rbOrderUsrName.TabIndex = 1;
			this.rbOrderUsrName.Text = "Nombre de Usuario";
			this.rbOrderUsrName.UseVisualStyleBackColor = true;
			// 
			// pnlList
			// 
			this.pnlList.Controls.Add(this.lvLista);
			this.pnlList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlList.Location = new System.Drawing.Point(200, 75);
			this.pnlList.Name = "pnlList";
			this.pnlList.Size = new System.Drawing.Size(520, 427);
			this.pnlList.TabIndex = 25;
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
            columnHeader3,
            columnHeader7,
            columnHeader8});
			this.lvLista.FullRowSelect = true;
			this.lvLista.HideSelection = false;
			this.lvLista.Location = new System.Drawing.Point(18, 6);
			this.lvLista.MultiSelect = false;
			this.lvLista.Name = "lvLista";
			this.lvLista.Size = new System.Drawing.Size(485, 414);
			this.lvLista.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.lvLista.TabIndex = 1;
			this.lvLista.UseCompatibleStateImageBehavior = false;
			this.lvLista.View = System.Windows.Forms.View.Details;
			this.lvLista.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvLista_ColumnClick);
			// 
			// bwRefreshEntities
			// 
			this.bwRefreshEntities.WorkerSupportsCancellation = true;
			this.bwRefreshEntities.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwRefreshEntities_DoWork);
			this.bwRefreshEntities.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwRefreshEntities_RunWorkerCompleted);
			// 
			// FRptListadoDePwd
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(720, 524);
			this.Controls.Add(this.pnlList);
			this.Controls.Add(this.pnlFilters);
			this.Controls.Add(this.statusbar);
			this.Name = "FRptListadoDePwd";
			this.Load += new System.EventHandler(this.FRptABMPerfiles_Load);
			this.Controls.SetChildIndex(this.pnlIzq, 0);
			this.Controls.SetChildIndex(this.statusbar, 0);
			this.Controls.SetChildIndex(this.pnlFilters, 0);
			this.Controls.SetChildIndex(this.pnlList, 0);
			((System.ComponentModel.ISupportInitialize)(this.pnlXPGrps)).EndInit();
			this.pnlXPGrps.ResumeLayout(false);
			this.pnlIzq.ResumeLayout(false);
			this.statusbar.ResumeLayout(false);
			this.statusbar.PerformLayout();
			this.pnlFilters.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.pnlList.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusbar;
        private System.Windows.Forms.ToolStripProgressBar pbDB;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lnkCancelar;
		private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.Panel pnlList;
        protected System.Windows.Forms.ListView lvLista;
		private System.ComponentModel.BackgroundWorker bwRefreshEntities;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		protected System.Windows.Forms.Button button1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton rbOrderUsrPath;
		private System.Windows.Forms.RadioButton rbOrderFolio;
		private System.Windows.Forms.RadioButton rbOrderUsrName;
		protected System.Windows.Forms.Button btnBuscar;

    }
}
