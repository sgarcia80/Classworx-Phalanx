namespace PhalanxAdmin
{
	partial class FUsuariosGruposSeguimiento
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
			System.Windows.Forms.ColumnHeader columnHeader3;
			System.Windows.Forms.ColumnHeader columnHeader1;
			System.Windows.Forms.ColumnHeader columnHeader2;
			System.Windows.Forms.ColumnHeader columnHeader4;
			this.pnlFilters = new System.Windows.Forms.Panel();
			this.btnExportar = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cboEstadoUsuario = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cboEstadoGrupo = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnLimpiar = new System.Windows.Forms.Button();
			this.btnBuscar = new System.Windows.Forms.Button();
			this.txtFilNombre = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.statusbar = new System.Windows.Forms.StatusStrip();
			this.pbDB = new System.Windows.Forms.ToolStripProgressBar();
			this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.lnkCancelar = new System.Windows.Forms.ToolStripStatusLabel();
			this.pnlList = new System.Windows.Forms.Panel();
			this.lvLista = new System.Windows.Forms.ListView();
			this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.bwRefreshEntities = new System.ComponentModel.BackgroundWorker();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
			this.pnlXPGrps.Size = new System.Drawing.Size(200, 508);
			// 
			// pnlIzq
			// 
			this.pnlIzq.Size = new System.Drawing.Size(200, 508);
			// 
			// xppnlMenu
			// 
			this.xppnlMenu.ImageItems.ImageSet = null;
			// 
			// columnHeader3
			// 
			columnHeader3.Text = "Id Grupo";
			columnHeader3.Width = 130;
			// 
			// columnHeader1
			// 
			columnHeader1.Text = "Nombre Grupo";
			columnHeader1.Width = 90;
			// 
			// columnHeader2
			// 
			columnHeader2.Tag = "";
			columnHeader2.Text = "Estado Grupo";
			columnHeader2.Width = 120;
			// 
			// columnHeader4
			// 
			columnHeader4.Text = "ID Usuario";
			columnHeader4.Width = 100;
			// 
			// pnlFilters
			// 
			this.pnlFilters.Controls.Add(this.btnExportar);
			this.pnlFilters.Controls.Add(this.groupBox1);
			this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlFilters.Location = new System.Drawing.Point(200, 0);
			this.pnlFilters.Name = "pnlFilters";
			this.pnlFilters.Size = new System.Drawing.Size(650, 118);
			this.pnlFilters.TabIndex = 19;
			// 
			// btnExportar
			// 
			this.btnExportar.BackColor = System.Drawing.SystemColors.Control;
			this.btnExportar.Location = new System.Drawing.Point(509, 91);
			this.btnExportar.Name = "btnExportar";
			this.btnExportar.Size = new System.Drawing.Size(117, 21);
			this.btnExportar.TabIndex = 6;
			this.btnExportar.Text = "Exportar a CSV";
			this.btnExportar.UseVisualStyleBackColor = false;
			this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cboEstadoUsuario);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.cboEstadoGrupo);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.btnLimpiar);
			this.groupBox1.Controls.Add(this.btnBuscar);
			this.groupBox1.Controls.Add(this.txtFilNombre);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Location = new System.Drawing.Point(18, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(485, 104);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Filtros de búsqueda";
			// 
			// cboEstadoUsuario
			// 
			this.cboEstadoUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboEstadoUsuario.FormattingEnabled = true;
			this.cboEstadoUsuario.Items.AddRange(new object[] {
            "Activos",
            "Inactivos",
            "Todos"});
			this.cboEstadoUsuario.Location = new System.Drawing.Point(94, 78);
			this.cboEstadoUsuario.Name = "cboEstadoUsuario";
			this.cboEstadoUsuario.Size = new System.Drawing.Size(98, 21);
			this.cboEstadoUsuario.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(11, 82);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(77, 13);
			this.label3.TabIndex = 16;
			this.label3.Text = "Estado usuario";
			// 
			// cboEstadoGrupo
			// 
			this.cboEstadoGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboEstadoGrupo.FormattingEnabled = true;
			this.cboEstadoGrupo.Items.AddRange(new object[] {
            "Activos",
            "Inactivos",
            "Todos"});
			this.cboEstadoGrupo.Location = new System.Drawing.Point(94, 50);
			this.cboEstadoGrupo.Name = "cboEstadoGrupo";
			this.cboEstadoGrupo.Size = new System.Drawing.Size(98, 21);
			this.cboEstadoGrupo.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(11, 54);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(70, 13);
			this.label1.TabIndex = 11;
			this.label1.Text = "Estado grupo";
			// 
			// btnLimpiar
			// 
			this.btnLimpiar.BackColor = System.Drawing.SystemColors.Control;
			this.btnLimpiar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnLimpiar.Location = new System.Drawing.Point(388, 22);
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
			this.btnBuscar.Location = new System.Drawing.Point(389, 50);
			this.btnBuscar.Name = "btnBuscar";
			this.btnBuscar.Size = new System.Drawing.Size(76, 21);
			this.btnBuscar.TabIndex = 7;
			this.btnBuscar.Text = "&Buscar";
			this.btnBuscar.UseVisualStyleBackColor = false;
			this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
			// 
			// txtFilNombre
			// 
			this.txtFilNombre.BackColor = System.Drawing.Color.White;
			this.txtFilNombre.Location = new System.Drawing.Point(94, 20);
			this.txtFilNombre.Name = "txtFilNombre";
			this.txtFilNombre.Size = new System.Drawing.Size(243, 20);
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
			// statusbar
			// 
			this.statusbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pbDB,
            this.lblStatus,
            this.lnkCancelar});
			this.statusbar.Location = new System.Drawing.Point(200, 486);
			this.statusbar.Name = "statusbar";
			this.statusbar.Size = new System.Drawing.Size(650, 22);
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
			// pnlList
			// 
			this.pnlList.Controls.Add(this.lvLista);
			this.pnlList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlList.Location = new System.Drawing.Point(200, 118);
			this.pnlList.Name = "pnlList";
			this.pnlList.Size = new System.Drawing.Size(650, 368);
			this.pnlList.TabIndex = 21;
			// 
			// lvLista
			// 
			this.lvLista.AllowColumnReorder = true;
			this.lvLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lvLista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeader3,
            columnHeader1,
            columnHeader2,
            columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
			this.lvLista.FullRowSelect = true;
			this.lvLista.HideSelection = false;
			this.lvLista.Location = new System.Drawing.Point(18, 16);
			this.lvLista.MultiSelect = false;
			this.lvLista.Name = "lvLista";
			this.lvLista.Size = new System.Drawing.Size(485, 345);
			this.lvLista.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.lvLista.TabIndex = 1;
			this.lvLista.UseCompatibleStateImageBehavior = false;
			this.lvLista.View = System.Windows.Forms.View.Details;
			this.lvLista.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvLista_ColumnClick);
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Dominio usuario";
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Usuario Red";
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "Nombre completo";
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "Estado Usuario";
			// 
			// bwRefreshEntities
			// 
			this.bwRefreshEntities.WorkerSupportsCancellation = true;
			this.bwRefreshEntities.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwRefreshEntities_DoWork);
			this.bwRefreshEntities.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwRefreshEntities_RunWorkerCompleted);
			// 
			// FUsuariosGrupos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(850, 508);
			this.Controls.Add(this.pnlList);
			this.Controls.Add(this.statusbar);
			this.Controls.Add(this.pnlFilters);
			this.Name = "FUsuariosGrupos";
			this.Load += new System.EventHandler(this.FHistPwdChg_Load);
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
        protected System.Windows.Forms.TextBox txtFilNombre;
        protected System.Windows.Forms.Label label2;
        private System.Windows.Forms.StatusStrip statusbar;
        private System.Windows.Forms.ToolStripProgressBar pbDB;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lnkCancelar;
        private System.Windows.Forms.Panel pnlList;
        protected System.Windows.Forms.ListView lvLista;
		private System.ComponentModel.BackgroundWorker bwRefreshEntities;
		protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.ComboBox cboEstadoGrupo;
		private System.Windows.Forms.ComboBox cboEstadoUsuario;
		protected System.Windows.Forms.Label label3;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader8;

    }
}
