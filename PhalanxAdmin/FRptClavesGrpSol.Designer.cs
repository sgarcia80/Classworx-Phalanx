namespace PhalanxAdmin
{
    partial class FRptClavesGrpSol
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
            System.Windows.Forms.ColumnHeader columnHeader10;
            System.Windows.Forms.ColumnHeader columnHeader11;
            System.Windows.Forms.ColumnHeader columnHeader1;
            System.Windows.Forms.ColumnHeader columnHeader2;
            System.Windows.Forms.ColumnHeader columnHeader3;
            System.Windows.Forms.ColumnHeader columnHeader4;
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbFilGrpActivosNo = new System.Windows.Forms.RadioButton();
            this.rbFilGrpActivosSi = new System.Windows.Forms.RadioButton();
            this.rbFilGrpActivosTodos = new System.Windows.Forms.RadioButton();
            this.btnExportar = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rbFilCriticasNo = new System.Windows.Forms.RadioButton();
            this.rbFilCriticasSi = new System.Windows.Forms.RadioButton();
            this.rbFilCriticasTodas = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkAmbATM = new System.Windows.Forms.CheckBox();
            this.chkAmbEC = new System.Windows.Forms.CheckBox();
            this.chkAmbAS400 = new System.Windows.Forms.CheckBox();
            this.chkAmbApp = new System.Windows.Forms.CheckBox();
            this.chkAmbDB = new System.Windows.Forms.CheckBox();
            this.chkAmbUnix = new System.Windows.Forms.CheckBox();
            this.chkAmbWin = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbFilActivasNo = new System.Windows.Forms.RadioButton();
            this.rbFilActivasSi = new System.Windows.Forms.RadioButton();
            this.rbFilActivasTodas = new System.Windows.Forms.RadioButton();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.statusbar = new System.Windows.Forms.StatusStrip();
            this.pbDB = new System.Windows.Forms.ToolStripProgressBar();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lnkCancelar = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlList = new System.Windows.Forms.Panel();
            this.lvLista = new System.Windows.Forms.ListView();
            this.bwRefreshEntities = new System.ComponentModel.BackgroundWorker();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.pnlXPGrps)).BeginInit();
            this.pnlXPGrps.SuspendLayout();
            this.pnlIzq.SuspendLayout();
            this.pnlFilters.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.statusbar.SuspendLayout();
            this.pnlList.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlXPGrps
            // 
            this.pnlXPGrps.Size = new System.Drawing.Size(200, 568);
            // 
            // pnlIzq
            // 
            this.pnlIzq.Size = new System.Drawing.Size(200, 568);
            // 
            // xppnlMenu
            // 
            this.xppnlMenu.ImageItems.ImageSet = null;
            // 
            // columnHeader9
            // 
            columnHeader9.Tag = "Numeric";
            columnHeader9.Text = "Folio";
            columnHeader9.Width = 44;
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "Ambiente";
            columnHeader10.Width = 81;
            // 
            // columnHeader11
            // 
            columnHeader11.Text = "Usuario";
            columnHeader11.Width = 201;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Crítico";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Estado";
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Grupo de Solicitud";
            columnHeader3.Width = 134;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Estado";
            // 
            // pnlFilters
            // 
            this.pnlFilters.Controls.Add(this.groupBox1);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Location = new System.Drawing.Point(200, 0);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(686, 187);
            this.pnlFilters.TabIndex = 18;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnExportar);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Location = new System.Drawing.Point(18, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(521, 173);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Claves por Grupos de Solicitudes";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbFilGrpActivosNo);
            this.groupBox2.Controls.Add(this.rbFilGrpActivosSi);
            this.groupBox2.Controls.Add(this.rbFilGrpActivosTodos);
            this.groupBox2.Location = new System.Drawing.Point(362, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(106, 91);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Estado Grupos";
            // 
            // rbFilGrpActivosNo
            // 
            this.rbFilGrpActivosNo.AutoSize = true;
            this.rbFilGrpActivosNo.Location = new System.Drawing.Point(7, 64);
            this.rbFilGrpActivosNo.Name = "rbFilGrpActivosNo";
            this.rbFilGrpActivosNo.Size = new System.Drawing.Size(92, 17);
            this.rbFilGrpActivosNo.TabIndex = 2;
            this.rbFilGrpActivosNo.Text = "Solo Inactivos";
            this.rbFilGrpActivosNo.UseVisualStyleBackColor = true;
            // 
            // rbFilGrpActivosSi
            // 
            this.rbFilGrpActivosSi.AutoSize = true;
            this.rbFilGrpActivosSi.Location = new System.Drawing.Point(7, 42);
            this.rbFilGrpActivosSi.Name = "rbFilGrpActivosSi";
            this.rbFilGrpActivosSi.Size = new System.Drawing.Size(84, 17);
            this.rbFilGrpActivosSi.TabIndex = 1;
            this.rbFilGrpActivosSi.Text = "Solo Activos";
            this.rbFilGrpActivosSi.UseVisualStyleBackColor = true;
            // 
            // rbFilGrpActivosTodos
            // 
            this.rbFilGrpActivosTodos.AutoSize = true;
            this.rbFilGrpActivosTodos.Checked = true;
            this.rbFilGrpActivosTodos.Location = new System.Drawing.Point(7, 19);
            this.rbFilGrpActivosTodos.Name = "rbFilGrpActivosTodos";
            this.rbFilGrpActivosTodos.Size = new System.Drawing.Size(55, 17);
            this.rbFilGrpActivosTodos.TabIndex = 0;
            this.rbFilGrpActivosTodos.TabStop = true;
            this.rbFilGrpActivosTodos.Text = "Todas";
            this.rbFilGrpActivosTodos.UseVisualStyleBackColor = true;
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.SystemColors.Control;
            this.btnExportar.Location = new System.Drawing.Point(362, 144);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(106, 21);
            this.btnExportar.TabIndex = 5;
            this.btnExportar.Text = "&Exportar a CSV";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rbFilCriticasNo);
            this.groupBox5.Controls.Add(this.rbFilCriticasSi);
            this.groupBox5.Controls.Add(this.rbFilCriticasTodas);
            this.groupBox5.Location = new System.Drawing.Point(122, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(111, 91);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Criticas";
            // 
            // rbFilCriticasNo
            // 
            this.rbFilCriticasNo.AutoSize = true;
            this.rbFilCriticasNo.Location = new System.Drawing.Point(7, 64);
            this.rbFilCriticasNo.Name = "rbFilCriticasNo";
            this.rbFilCriticasNo.Size = new System.Drawing.Size(100, 17);
            this.rbFilCriticasNo.TabIndex = 5;
            this.rbFilCriticasNo.Text = "Solo No Criticas";
            this.rbFilCriticasNo.UseVisualStyleBackColor = true;
            // 
            // rbFilCriticasSi
            // 
            this.rbFilCriticasSi.AutoSize = true;
            this.rbFilCriticasSi.Location = new System.Drawing.Point(7, 42);
            this.rbFilCriticasSi.Name = "rbFilCriticasSi";
            this.rbFilCriticasSi.Size = new System.Drawing.Size(83, 17);
            this.rbFilCriticasSi.TabIndex = 4;
            this.rbFilCriticasSi.Text = "Solo Criticas";
            this.rbFilCriticasSi.UseVisualStyleBackColor = true;
            // 
            // rbFilCriticasTodas
            // 
            this.rbFilCriticasTodas.AutoSize = true;
            this.rbFilCriticasTodas.Checked = true;
            this.rbFilCriticasTodas.Location = new System.Drawing.Point(7, 19);
            this.rbFilCriticasTodas.Name = "rbFilCriticasTodas";
            this.rbFilCriticasTodas.Size = new System.Drawing.Size(55, 17);
            this.rbFilCriticasTodas.TabIndex = 3;
            this.rbFilCriticasTodas.TabStop = true;
            this.rbFilCriticasTodas.Text = "Todas";
            this.rbFilCriticasTodas.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkAmbATM);
            this.groupBox4.Controls.Add(this.chkAmbEC);
            this.groupBox4.Controls.Add(this.chkAmbAS400);
            this.groupBox4.Controls.Add(this.chkAmbApp);
            this.groupBox4.Controls.Add(this.chkAmbDB);
            this.groupBox4.Controls.Add(this.chkAmbUnix);
            this.groupBox4.Controls.Add(this.chkAmbWin);
            this.groupBox4.Location = new System.Drawing.Point(239, 9);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(117, 158);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ambientes";
            // 
            // chkAmbATM
            // 
            this.chkAmbATM.AutoSize = true;
            this.chkAmbATM.Checked = true;
            this.chkAmbATM.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAmbATM.Location = new System.Drawing.Point(7, 137);
            this.chkAmbATM.Name = "chkAmbATM";
            this.chkAmbATM.Size = new System.Drawing.Size(49, 17);
            this.chkAmbATM.TabIndex = 12;
            this.chkAmbATM.Text = "ATM";
            this.chkAmbATM.UseVisualStyleBackColor = true;
            // 
            // chkAmbEC
            // 
            this.chkAmbEC.AutoSize = true;
            this.chkAmbEC.Checked = true;
            this.chkAmbEC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAmbEC.Location = new System.Drawing.Point(7, 117);
            this.chkAmbEC.Name = "chkAmbEC";
            this.chkAmbEC.Size = new System.Drawing.Size(84, 17);
            this.chkAmbEC.TabIndex = 11;
            this.chkAmbEC.Text = "Eq, de Com.";
            this.chkAmbEC.UseVisualStyleBackColor = true;
            // 
            // chkAmbAS400
            // 
            this.chkAmbAS400.AutoSize = true;
            this.chkAmbAS400.Checked = true;
            this.chkAmbAS400.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAmbAS400.Location = new System.Drawing.Point(7, 57);
            this.chkAmbAS400.Name = "chkAmbAS400";
            this.chkAmbAS400.Size = new System.Drawing.Size(58, 17);
            this.chkAmbAS400.TabIndex = 8;
            this.chkAmbAS400.Text = "AS400";
            this.chkAmbAS400.UseVisualStyleBackColor = true;
            // 
            // chkAmbApp
            // 
            this.chkAmbApp.AutoSize = true;
            this.chkAmbApp.Checked = true;
            this.chkAmbApp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAmbApp.Location = new System.Drawing.Point(7, 97);
            this.chkAmbApp.Name = "chkAmbApp";
            this.chkAmbApp.Size = new System.Drawing.Size(77, 17);
            this.chkAmbApp.TabIndex = 10;
            this.chkAmbApp.Text = "Aplicativos";
            this.chkAmbApp.UseVisualStyleBackColor = true;
            // 
            // chkAmbDB
            // 
            this.chkAmbDB.AutoSize = true;
            this.chkAmbDB.Checked = true;
            this.chkAmbDB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAmbDB.Location = new System.Drawing.Point(7, 77);
            this.chkAmbDB.Name = "chkAmbDB";
            this.chkAmbDB.Size = new System.Drawing.Size(101, 17);
            this.chkAmbDB.TabIndex = 9;
            this.chkAmbDB.Text = "Bases de Datos";
            this.chkAmbDB.UseVisualStyleBackColor = true;
            // 
            // chkAmbUnix
            // 
            this.chkAmbUnix.AutoSize = true;
            this.chkAmbUnix.Checked = true;
            this.chkAmbUnix.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAmbUnix.Location = new System.Drawing.Point(7, 38);
            this.chkAmbUnix.Name = "chkAmbUnix";
            this.chkAmbUnix.Size = new System.Drawing.Size(47, 17);
            this.chkAmbUnix.TabIndex = 7;
            this.chkAmbUnix.Text = "Unix";
            this.chkAmbUnix.UseVisualStyleBackColor = true;
            // 
            // chkAmbWin
            // 
            this.chkAmbWin.AutoSize = true;
            this.chkAmbWin.Checked = true;
            this.chkAmbWin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAmbWin.Location = new System.Drawing.Point(7, 20);
            this.chkAmbWin.Name = "chkAmbWin";
            this.chkAmbWin.Size = new System.Drawing.Size(70, 17);
            this.chkAmbWin.TabIndex = 6;
            this.chkAmbWin.Text = "Windows";
            this.chkAmbWin.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbFilActivasNo);
            this.groupBox3.Controls.Add(this.rbFilActivasSi);
            this.groupBox3.Controls.Add(this.rbFilActivasTodas);
            this.groupBox3.Location = new System.Drawing.Point(10, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(106, 91);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Estado claves";
            // 
            // rbFilActivasNo
            // 
            this.rbFilActivasNo.AutoSize = true;
            this.rbFilActivasNo.Location = new System.Drawing.Point(7, 64);
            this.rbFilActivasNo.Name = "rbFilActivasNo";
            this.rbFilActivasNo.Size = new System.Drawing.Size(92, 17);
            this.rbFilActivasNo.TabIndex = 2;
            this.rbFilActivasNo.Text = "Solo Inactivas";
            this.rbFilActivasNo.UseVisualStyleBackColor = true;
            // 
            // rbFilActivasSi
            // 
            this.rbFilActivasSi.AutoSize = true;
            this.rbFilActivasSi.Location = new System.Drawing.Point(7, 42);
            this.rbFilActivasSi.Name = "rbFilActivasSi";
            this.rbFilActivasSi.Size = new System.Drawing.Size(84, 17);
            this.rbFilActivasSi.TabIndex = 1;
            this.rbFilActivasSi.Text = "Solo Activas";
            this.rbFilActivasSi.UseVisualStyleBackColor = true;
            // 
            // rbFilActivasTodas
            // 
            this.rbFilActivasTodas.AutoSize = true;
            this.rbFilActivasTodas.Checked = true;
            this.rbFilActivasTodas.Location = new System.Drawing.Point(7, 19);
            this.rbFilActivasTodas.Name = "rbFilActivasTodas";
            this.rbFilActivasTodas.Size = new System.Drawing.Size(55, 17);
            this.rbFilActivasTodas.TabIndex = 0;
            this.rbFilActivasTodas.TabStop = true;
            this.rbFilActivasTodas.Text = "Todas";
            this.rbFilActivasTodas.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.SystemColors.Control;
            this.btnBuscar.Location = new System.Drawing.Point(362, 117);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(106, 21);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "&Visualizar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // statusbar
            // 
            this.statusbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pbDB,
            this.lblStatus,
            this.lnkCancelar});
            this.statusbar.Location = new System.Drawing.Point(200, 546);
            this.statusbar.Name = "statusbar";
            this.statusbar.Size = new System.Drawing.Size(686, 22);
            this.statusbar.TabIndex = 21;
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
            this.pnlList.Location = new System.Drawing.Point(200, 187);
            this.pnlList.Name = "pnlList";
            this.pnlList.Size = new System.Drawing.Size(686, 359);
            this.pnlList.TabIndex = 22;
            // 
            // lvLista
            // 
            this.lvLista.AllowColumnReorder = true;
            this.lvLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvLista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeader9,
            columnHeader10,
            columnHeader11,
            columnHeader1,
            columnHeader2,
            columnHeader3,
            columnHeader4});
            this.lvLista.FullRowSelect = true;
            this.lvLista.HideSelection = false;
            this.lvLista.Location = new System.Drawing.Point(18, 16);
            this.lvLista.MultiSelect = false;
            this.lvLista.Name = "lvLista";
            this.lvLista.Size = new System.Drawing.Size(656, 336);
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
            // FRptClavesGrpSol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(886, 568);
            this.Controls.Add(this.pnlList);
            this.Controls.Add(this.statusbar);
            this.Controls.Add(this.pnlFilters);
            this.Name = "FRptClavesGrpSol";
            this.Load += new System.EventHandler(this.FRptClavesGrpSol_Load);
            this.Controls.SetChildIndex(this.pnlIzq, 0);
            this.Controls.SetChildIndex(this.pnlFilters, 0);
            this.Controls.SetChildIndex(this.statusbar, 0);
            this.Controls.SetChildIndex(this.pnlList, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pnlXPGrps)).EndInit();
            this.pnlXPGrps.ResumeLayout(false);
            this.pnlIzq.ResumeLayout(false);
            this.pnlFilters.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.statusbar.ResumeLayout(false);
            this.statusbar.PerformLayout();
            this.pnlList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlFilters;
        protected System.Windows.Forms.GroupBox groupBox1;
        protected System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rbFilCriticasNo;
        private System.Windows.Forms.RadioButton rbFilCriticasSi;
        private System.Windows.Forms.RadioButton rbFilCriticasTodas;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkAmbATM;
        private System.Windows.Forms.CheckBox chkAmbEC;
        private System.Windows.Forms.CheckBox chkAmbAS400;
        private System.Windows.Forms.CheckBox chkAmbApp;
        private System.Windows.Forms.CheckBox chkAmbDB;
        private System.Windows.Forms.CheckBox chkAmbUnix;
        private System.Windows.Forms.CheckBox chkAmbWin;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbFilActivasNo;
        private System.Windows.Forms.RadioButton rbFilActivasSi;
        private System.Windows.Forms.RadioButton rbFilActivasTodas;
        protected System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.StatusStrip statusbar;
        private System.Windows.Forms.ToolStripProgressBar pbDB;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lnkCancelar;
        private System.Windows.Forms.Panel pnlList;
        protected System.Windows.Forms.ListView lvLista;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbFilGrpActivosNo;
        private System.Windows.Forms.RadioButton rbFilGrpActivosSi;
        private System.Windows.Forms.RadioButton rbFilGrpActivosTodos;
        private System.ComponentModel.BackgroundWorker bwRefreshEntities;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}
