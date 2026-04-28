namespace PhalanxAdmin
{
    partial class FViewLoteChkWinPwd
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
            System.Windows.Forms.ColumnHeader columnHeader69;
            System.Windows.Forms.ColumnHeader columnHeader4;
            System.Windows.Forms.ColumnHeader columnHeader1;
            System.Windows.Forms.ColumnHeader columnHeader2;
            System.Windows.Forms.ColumnHeader columnHeader3;
            System.Windows.Forms.ColumnHeader columnHeader5;
            System.Windows.Forms.ColumnHeader columnHeader6;
            System.Windows.Forms.ColumnHeader columnHeader10;
            this.lTitleDominio = new System.Windows.Forms.Label();
            this.lblNroLote = new System.Windows.Forms.Label();
            this.lblFGeneracion = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFProgramada = new System.Windows.Forms.Label();
            this.lblFInicio = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblFFin = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lvItmsLote = new System.Windows.Forms.ListView();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.grpFiltros = new System.Windows.Forms.GroupBox();
            this.cbAccesoIP = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbAccesoNombre = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbChkPwd = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnBorrarLote = new System.Windows.Forms.Button();
            this.statusbar = new System.Windows.Forms.StatusStrip();
            this.pbDB = new System.Windows.Forms.ToolStripProgressBar();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.bwRefreshEntities = new System.ComponentModel.BackgroundWorker();
            this.btnAccion = new System.Windows.Forms.Button();
            this.btnExportCSV = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnCerrar = new System.Windows.Forms.Button();
            columnHeader69 = new System.Windows.Forms.ColumnHeader();
            columnHeader4 = new System.Windows.Forms.ColumnHeader();
            columnHeader1 = new System.Windows.Forms.ColumnHeader();
            columnHeader2 = new System.Windows.Forms.ColumnHeader();
            columnHeader3 = new System.Windows.Forms.ColumnHeader();
            columnHeader5 = new System.Windows.Forms.ColumnHeader();
            columnHeader6 = new System.Windows.Forms.ColumnHeader();
            columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.groupBox1.SuspendLayout();
            this.grpFiltros.SuspendLayout();
            this.statusbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCerrar);
            this.groupBox1.Controls.Add(this.btnExportCSV);
            this.groupBox1.Controls.Add(this.btnAccion);
            this.groupBox1.Controls.Add(this.btnBorrarLote);
            this.groupBox1.Controls.Add(this.btnProcesar);
            this.groupBox1.Location = new System.Drawing.Point(0, 527);
            this.groupBox1.Size = new System.Drawing.Size(856, 43);
            this.groupBox1.Controls.SetChildIndex(this.btnProcesar, 0);
            this.groupBox1.Controls.SetChildIndex(this.btnBorrarLote, 0);
            this.groupBox1.Controls.SetChildIndex(this.btnAccion, 0);
            this.groupBox1.Controls.SetChildIndex(this.btnExportCSV, 0);
            this.groupBox1.Controls.SetChildIndex(this.btnCerrar, 0);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(13, 0);
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Visible = false;
            // 
            // columnHeader69
            // 
            columnHeader69.Text = "Folio";
            columnHeader69.Width = 40;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Usuario";
            columnHeader4.Width = 97;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Fecha";
            columnHeader1.Width = 126;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Contraseña";
            columnHeader2.Width = 78;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Acceso Nombre";
            columnHeader3.Width = 96;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Acceso IP";
            columnHeader5.Width = 75;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Nombre Equipo";
            columnHeader6.Width = 117;
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "Acción";
            // 
            // lTitleDominio
            // 
            this.lTitleDominio.AutoSize = true;
            this.lTitleDominio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTitleDominio.Location = new System.Drawing.Point(10, 30);
            this.lTitleDominio.Name = "lTitleDominio";
            this.lTitleDominio.Size = new System.Drawing.Size(82, 13);
            this.lTitleDominio.TabIndex = 14;
            this.lTitleDominio.Text = "Nro. de Lote:";
            // 
            // lblNroLote
            // 
            this.lblNroLote.AutoSize = true;
            this.lblNroLote.Location = new System.Drawing.Point(98, 30);
            this.lblNroLote.Name = "lblNroLote";
            this.lblNroLote.Size = new System.Drawing.Size(55, 13);
            this.lblNroLote.TabIndex = 15;
            this.lblNroLote.Text = "lblNroLote";
            // 
            // lblFGeneracion
            // 
            this.lblFGeneracion.AutoSize = true;
            this.lblFGeneracion.Location = new System.Drawing.Point(645, 30);
            this.lblFGeneracion.Name = "lblFGeneracion";
            this.lblFGeneracion.Size = new System.Drawing.Size(78, 13);
            this.lblFGeneracion.TabIndex = 17;
            this.lblFGeneracion.Text = "lblFGeneracion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(506, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Fecha de Generación:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(208, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Fecha Programada:";
            // 
            // lblFProgramada
            // 
            this.lblFProgramada.AutoSize = true;
            this.lblFProgramada.Location = new System.Drawing.Point(331, 30);
            this.lblFProgramada.Name = "lblFProgramada";
            this.lblFProgramada.Size = new System.Drawing.Size(80, 13);
            this.lblFProgramada.TabIndex = 19;
            this.lblFProgramada.Text = "lblFProgramada";
            // 
            // lblFInicio
            // 
            this.lblFInicio.AutoSize = true;
            this.lblFInicio.Location = new System.Drawing.Point(115, 49);
            this.lblFInicio.Name = "lblFInicio";
            this.lblFInicio.Size = new System.Drawing.Size(48, 13);
            this.lblFInicio.TabIndex = 21;
            this.lblFInicio.Text = "lblFInicio";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Fecha de Inicio:";
            // 
            // lblFFin
            // 
            this.lblFFin.AutoSize = true;
            this.lblFFin.Location = new System.Drawing.Point(299, 49);
            this.lblFFin.Name = "lblFFin";
            this.lblFFin.Size = new System.Drawing.Size(37, 13);
            this.lblFFin.TabIndex = 23;
            this.lblFFin.Text = "lblFFin";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(208, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Fecha de Fin:";
            // 
            // lvItmsLote
            // 
            this.lvItmsLote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvItmsLote.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeader69,
            this.columnHeader7,
            this.columnHeader8,
            columnHeader4,
            columnHeader1,
            columnHeader2,
            columnHeader3,
            columnHeader5,
            this.columnHeader9,
            columnHeader6,
            columnHeader10});
            this.lvItmsLote.FullRowSelect = true;
            this.lvItmsLote.HideSelection = false;
            this.lvItmsLote.Location = new System.Drawing.Point(12, 137);
            this.lvItmsLote.Name = "lvItmsLote";
            this.lvItmsLote.Size = new System.Drawing.Size(830, 351);
            this.lvItmsLote.TabIndex = 24;
            this.lvItmsLote.UseCompatibleStateImageBehavior = false;
            this.lvItmsLote.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Dominio";
            this.columnHeader7.Width = 86;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Equipo";
            this.columnHeader8.Width = 82;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Nombre Usuario";
            this.columnHeader9.Width = 88;
            // 
            // btnProcesar
            // 
            this.btnProcesar.BackColor = System.Drawing.SystemColors.Control;
            this.btnProcesar.Location = new System.Drawing.Point(13, 14);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(75, 23);
            this.btnProcesar.TabIndex = 25;
            this.btnProcesar.Text = "Procesar";
            this.btnProcesar.UseVisualStyleBackColor = false;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // grpFiltros
            // 
            this.grpFiltros.Controls.Add(this.cbAccesoIP);
            this.grpFiltros.Controls.Add(this.label7);
            this.grpFiltros.Controls.Add(this.cbAccesoNombre);
            this.grpFiltros.Controls.Add(this.label4);
            this.grpFiltros.Controls.Add(this.cbChkPwd);
            this.grpFiltros.Controls.Add(this.label1);
            this.grpFiltros.Controls.Add(this.btnBuscar);
            this.grpFiltros.Location = new System.Drawing.Point(13, 76);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Size = new System.Drawing.Size(829, 55);
            this.grpFiltros.TabIndex = 25;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "Filtros de búsqueda";
            // 
            // cbAccesoIP
            // 
            this.cbAccesoIP.FormattingEnabled = true;
            this.cbAccesoIP.Items.AddRange(new object[] {
            "Todos",
            "Correcto",
            "Incorrecto"});
            this.cbAccesoIP.Location = new System.Drawing.Point(520, 23);
            this.cbAccesoIP.Name = "cbAccesoIP";
            this.cbAccesoIP.Size = new System.Drawing.Size(121, 21);
            this.cbAccesoIP.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(429, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 28);
            this.label7.TabIndex = 17;
            this.label7.Text = "Acceso Nombre Equipo:";
            // 
            // cbAccesoNombre
            // 
            this.cbAccesoNombre.FormattingEnabled = true;
            this.cbAccesoNombre.Items.AddRange(new object[] {
            "Todos",
            "Correcto",
            "Incorrecto"});
            this.cbAccesoNombre.Location = new System.Drawing.Point(291, 23);
            this.cbAccesoNombre.Name = "cbAccesoNombre";
            this.cbAccesoNombre.Size = new System.Drawing.Size(121, 21);
            this.cbAccesoNombre.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(206, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 31);
            this.label4.TabIndex = 15;
            this.label4.Text = "Acceso Nombre Equipo:";
            // 
            // cbChkPwd
            // 
            this.cbChkPwd.FormattingEnabled = true;
            this.cbChkPwd.Items.AddRange(new object[] {
            "Todos",
            "Correcto",
            "Incorrecto"});
            this.cbChkPwd.Location = new System.Drawing.Point(70, 23);
            this.cbChkPwd.Name = "cbChkPwd";
            this.cbChkPwd.Size = new System.Drawing.Size(121, 21);
            this.cbChkPwd.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 29);
            this.label1.TabIndex = 13;
            this.label1.Text = "Chequeo contraseña:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.SystemColors.Control;
            this.btnBuscar.Location = new System.Drawing.Point(732, 19);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(76, 21);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnBorrarLote
            // 
            this.btnBorrarLote.BackColor = System.Drawing.SystemColors.Control;
            this.btnBorrarLote.Location = new System.Drawing.Point(101, 14);
            this.btnBorrarLote.Name = "btnBorrarLote";
            this.btnBorrarLote.Size = new System.Drawing.Size(75, 23);
            this.btnBorrarLote.TabIndex = 26;
            this.btnBorrarLote.Text = "Borrar Lote";
            this.btnBorrarLote.UseVisualStyleBackColor = false;
            this.btnBorrarLote.Click += new System.EventHandler(this.btnBorrarLote_Click);
            // 
            // statusbar
            // 
            this.statusbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pbDB,
            this.lblStatus});
            this.statusbar.Location = new System.Drawing.Point(0, 505);
            this.statusbar.Name = "statusbar";
            this.statusbar.Size = new System.Drawing.Size(856, 22);
            this.statusbar.TabIndex = 26;
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
            this.lblStatus.Size = new System.Drawing.Size(104, 17);
            this.lblStatus.Text = "Procesando Lote...";
            // 
            // bwRefreshEntities
            // 
            this.bwRefreshEntities.WorkerReportsProgress = true;
            this.bwRefreshEntities.WorkerSupportsCancellation = true;
            this.bwRefreshEntities.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwRefreshEntities_DoWork);
            this.bwRefreshEntities.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwRefreshEntities_RunWorkerCompleted);
            this.bwRefreshEntities.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwRefreshEntities_ProgressChanged);
            // 
            // btnAccion
            // 
            this.btnAccion.BackColor = System.Drawing.SystemColors.Control;
            this.btnAccion.Location = new System.Drawing.Point(246, 14);
            this.btnAccion.Name = "btnAccion";
            this.btnAccion.Size = new System.Drawing.Size(114, 23);
            this.btnAccion.TabIndex = 27;
            this.btnAccion.Text = "Realizar Acción";
            this.btnAccion.UseVisualStyleBackColor = false;
            this.btnAccion.Click += new System.EventHandler(this.btnAccion_Click);
            // 
            // btnExportCSV
            // 
            this.btnExportCSV.BackColor = System.Drawing.SystemColors.Control;
            this.btnExportCSV.Location = new System.Drawing.Point(445, 14);
            this.btnExportCSV.Name = "btnExportCSV";
            this.btnExportCSV.Size = new System.Drawing.Size(114, 23);
            this.btnExportCSV.TabIndex = 28;
            this.btnExportCSV.Text = "Exportar csv";
            this.btnExportCSV.UseVisualStyleBackColor = false;
            this.btnExportCSV.Click += new System.EventHandler(this.btnExportCSV_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.SystemColors.Control;
            this.btnCerrar.Location = new System.Drawing.Point(760, 14);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(82, 23);
            this.btnCerrar.TabIndex = 29;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FViewLoteChkWinPwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(856, 570);
            this.Controls.Add(this.statusbar);
            this.Controls.Add(this.grpFiltros);
            this.Controls.Add(this.lvItmsLote);
            this.Controls.Add(this.lblFFin);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblFInicio);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lTitleDominio);
            this.Controls.Add(this.lblNroLote);
            this.Controls.Add(this.lblFGeneracion);
            this.Controls.Add(this.lblFProgramada);
            this.Controls.Add(this.label3);
            this.Name = "FViewLoteChkWinPwd";
            this.Load += new System.EventHandler(this.FViewLoteChkWinPwd_Load);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.lblFProgramada, 0);
            this.Controls.SetChildIndex(this.lblFGeneracion, 0);
            this.Controls.SetChildIndex(this.lblNroLote, 0);
            this.Controls.SetChildIndex(this.lTitleDominio, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.lblFInicio, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.lblFFin, 0);
            this.Controls.SetChildIndex(this.lvItmsLote, 0);
            this.Controls.SetChildIndex(this.grpFiltros, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.statusbar, 0);
            this.groupBox1.ResumeLayout(false);
            this.grpFiltros.ResumeLayout(false);
            this.statusbar.ResumeLayout(false);
            this.statusbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lTitleDominio;
        private System.Windows.Forms.Label lblNroLote;
        private System.Windows.Forms.Label lblFGeneracion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFProgramada;
        private System.Windows.Forms.Label lblFInicio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblFFin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView lvItmsLote;
        private System.Windows.Forms.Button btnProcesar;
        protected System.Windows.Forms.GroupBox grpFiltros;
        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cbChkPwd;
        private System.Windows.Forms.ComboBox cbAccesoIP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbAccesoNombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBorrarLote;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.StatusStrip statusbar;
        private System.Windows.Forms.ToolStripProgressBar pbDB;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.ComponentModel.BackgroundWorker bwRefreshEntities;
        private System.Windows.Forms.Button btnAccion;
        private System.Windows.Forms.Button btnExportCSV;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnCerrar;

    }
}
