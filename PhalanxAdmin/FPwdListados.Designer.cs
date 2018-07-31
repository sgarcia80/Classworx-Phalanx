namespace PhalanxAdmin
{
    partial class FPwdListados
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FPwdListados));
            this.WinLocalUserEntityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bwRefreshEntities = new System.ComponentModel.BackgroundWorker();
            this.pnlList = new System.Windows.Forms.Panel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.btnExportar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbOrderUsrPath = new System.Windows.Forms.RadioButton();
            this.rbOrderFolio = new System.Windows.Forms.RadioButton();
            this.rbOrderUsrName = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CBGoups = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pnlXPGrps)).BeginInit();
            this.pnlXPGrps.SuspendLayout();
            this.pnlIzq.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WinLocalUserEntityBindingSource)).BeginInit();
            this.pnlList.SuspendLayout();
            this.pnlFilters.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlXPGrps
            // 
            this.pnlXPGrps.Size = new System.Drawing.Size(200, 502);
            // 
            // pnlIzq
            // 
            this.pnlIzq.Size = new System.Drawing.Size(200, 502);
            // 
            // xppnlMenu
            // 
            this.xppnlMenu.ImageItems.ImageSet = null;
            this.xppnlMenu.Size = new System.Drawing.Size(167, 502);
            // 
            // WinLocalUserEntityBindingSource
            // 
            this.WinLocalUserEntityBindingSource.DataSource = typeof(PhalanxCommon.Entities.WinLocalUserEntity);
            // 
            // bwRefreshEntities
            // 
            this.bwRefreshEntities.WorkerSupportsCancellation = true;
            // 
            // pnlList
            // 
            this.pnlList.Controls.Add(this.reportViewer1);
            this.pnlList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlList.Location = new System.Drawing.Point(200, 122);
            this.pnlList.Name = "pnlList";
            this.pnlList.Size = new System.Drawing.Size(527, 380);
            this.pnlList.TabIndex = 16;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "PhalanxCommon_Entities_WinLocalUserEntity";
            reportDataSource2.Value = this.WinLocalUserEntityBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "PhalanxAdmin.UsersPasswordList.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ShowBackButton = false;
            this.reportViewer1.ShowDocumentMapButton = false;
            this.reportViewer1.ShowExportButton = false;
            this.reportViewer1.ShowFindControls = false;
            this.reportViewer1.ShowRefreshButton = false;
            this.reportViewer1.ShowStopButton = false;
            this.reportViewer1.Size = new System.Drawing.Size(527, 380);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            this.reportViewer1.MarginChanged += new System.EventHandler(this.reportViewer1_MarginChanged);
            this.reportViewer1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.reportViewer1_PreviewKeyDown);
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
            this.pnlFilters.Controls.Add(this.btnExportar);
            this.pnlFilters.Controls.Add(this.groupBox2);
            this.pnlFilters.Controls.Add(this.groupBox1);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Location = new System.Drawing.Point(200, 0);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(527, 122);
            this.pnlFilters.TabIndex = 15;
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.SystemColors.Control;
            this.btnExportar.Location = new System.Drawing.Point(371, 82);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(117, 21);
            this.btnExportar.TabIndex = 15;
            this.btnExportar.Text = "&Exportar a PDF";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbOrderUsrPath);
            this.groupBox2.Controls.Add(this.rbOrderFolio);
            this.groupBox2.Controls.Add(this.rbOrderUsrName);
            this.groupBox2.Location = new System.Drawing.Point(18, 69);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(319, 44);
            this.groupBox2.TabIndex = 4;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CBGoups);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(18, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(485, 55);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reporte de Contraseñas";
            // 
            // CBGoups
            // 
            this.CBGoups.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CBGoups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBGoups.FormattingEnabled = true;
            this.CBGoups.Location = new System.Drawing.Point(122, 20);
            this.CBGoups.Name = "CBGoups";
            this.CBGoups.Size = new System.Drawing.Size(221, 21);
            this.CBGoups.TabIndex = 0;
            this.CBGoups.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.CBGoups_DrawItem);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.SystemColors.Control;
            this.btnBuscar.Location = new System.Drawing.Point(353, 20);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(117, 21);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "&Visualizar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Grupo de Solicitudes";
            // 
            // FPwdListados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(727, 502);
            this.Controls.Add(this.pnlList);
            this.Controls.Add(this.pnlFilters);
            this.Name = "FPwdListados";
            this.Load += new System.EventHandler(this.FWinPwd_Load);
            this.Controls.SetChildIndex(this.pnlIzq, 0);
            this.Controls.SetChildIndex(this.pnlFilters, 0);
            this.Controls.SetChildIndex(this.pnlList, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pnlXPGrps)).EndInit();
            this.pnlXPGrps.ResumeLayout(false);
            this.pnlIzq.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WinLocalUserEntityBindingSource)).EndInit();
            this.pnlList.ResumeLayout(false);
            this.pnlFilters.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker bwRefreshEntities;
        private System.Windows.Forms.Panel pnlList;
        private System.Windows.Forms.Panel pnlFilters;
        protected System.Windows.Forms.GroupBox groupBox1;
        protected System.Windows.Forms.Button btnBuscar;
        protected System.Windows.Forms.Label label2;
        private System.Windows.Forms.ImageList imageList;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource WinLocalUserEntityBindingSource;
        private System.Windows.Forms.ComboBox CBGoups;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbOrderUsrPath;
        private System.Windows.Forms.RadioButton rbOrderFolio;
        private System.Windows.Forms.RadioButton rbOrderUsrName;
        protected System.Windows.Forms.Button btnExportar;
    }
}
