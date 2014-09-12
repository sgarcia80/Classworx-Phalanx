namespace PhalanxAdmin
{
    partial class FRptInventarioPwd
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.VwInventarioEntityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExportar = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rbFilCriticasNo = new System.Windows.Forms.RadioButton();
            this.rbFilCriticasSi = new System.Windows.Forms.RadioButton();
            this.rbFilCriticasTodas = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbOrderFolio = new System.Windows.Forms.RadioButton();
            this.rbOrderPwd = new System.Windows.Forms.RadioButton();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.chkAmbATM = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pnlXPGrps)).BeginInit();
            this.pnlXPGrps.SuspendLayout();
            this.pnlIzq.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VwInventarioEntityBindingSource)).BeginInit();
            this.pnlFilters.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlXPGrps
            // 
            this.pnlXPGrps.Size = new System.Drawing.Size(200, 497);
            // 
            // pnlIzq
            // 
            this.pnlIzq.Size = new System.Drawing.Size(200, 497);
            // 
            // VwInventarioEntityBindingSource
            // 
            this.VwInventarioEntityBindingSource.DataSource = typeof(PhalanxCommon.Entities.VwInventarioEntity);
            // 
            // pnlFilters
            // 
            this.pnlFilters.Controls.Add(this.groupBox1);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Location = new System.Drawing.Point(200, 0);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(551, 187);
            this.pnlFilters.TabIndex = 17;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExportar);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Location = new System.Drawing.Point(18, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(521, 173);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Inventario de Claves en Custodia";
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.SystemColors.Control;
            this.btnExportar.Location = new System.Drawing.Point(377, 106);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(117, 21);
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
            this.groupBox3.Text = "Estado";
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbOrderFolio);
            this.groupBox2.Controls.Add(this.rbOrderPwd);
            this.groupBox2.Location = new System.Drawing.Point(363, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(152, 44);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ordenar por";
            // 
            // rbOrderFolio
            // 
            this.rbOrderFolio.AutoSize = true;
            this.rbOrderFolio.Checked = true;
            this.rbOrderFolio.Location = new System.Drawing.Point(6, 19);
            this.rbOrderFolio.Name = "rbOrderFolio";
            this.rbOrderFolio.Size = new System.Drawing.Size(47, 17);
            this.rbOrderFolio.TabIndex = 11;
            this.rbOrderFolio.TabStop = true;
            this.rbOrderFolio.Text = "Folio";
            this.rbOrderFolio.UseVisualStyleBackColor = true;
            // 
            // rbOrderPwd
            // 
            this.rbOrderPwd.AutoSize = true;
            this.rbOrderPwd.Location = new System.Drawing.Point(70, 19);
            this.rbOrderPwd.Name = "rbOrderPwd";
            this.rbOrderPwd.Size = new System.Drawing.Size(61, 17);
            this.rbOrderPwd.TabIndex = 12;
            this.rbOrderPwd.Text = "Usuario";
            this.rbOrderPwd.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.SystemColors.Control;
            this.btnBuscar.Location = new System.Drawing.Point(377, 79);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(117, 21);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "&Visualizar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "PhalanxCommon_Entities_VwInventarioEntity";
            reportDataSource1.Value = this.VwInventarioEntityBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "PhalanxAdmin.RptInventarioDePwd.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(200, 187);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ShowBackButton = false;
            this.reportViewer1.ShowDocumentMapButton = false;
            this.reportViewer1.ShowExportButton = false;
            this.reportViewer1.ShowFindControls = false;
            this.reportViewer1.ShowRefreshButton = false;
            this.reportViewer1.ShowStopButton = false;
            this.reportViewer1.Size = new System.Drawing.Size(551, 310);
            this.reportViewer1.TabIndex = 18;
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
            // FRptInventarioPwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(751, 497);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.pnlFilters);
            this.Name = "FRptInventarioPwd";
            this.Load += new System.EventHandler(this.FRptInventarioPwd_Load);
            this.Controls.SetChildIndex(this.pnlIzq, 0);
            this.Controls.SetChildIndex(this.pnlFilters, 0);
            this.Controls.SetChildIndex(this.reportViewer1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pnlXPGrps)).EndInit();
            this.pnlXPGrps.ResumeLayout(false);
            this.pnlIzq.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.VwInventarioEntityBindingSource)).EndInit();
            this.pnlFilters.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFilters;
        protected System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbOrderFolio;
        private System.Windows.Forms.RadioButton rbOrderPwd;
        protected System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkAmbApp;
        private System.Windows.Forms.CheckBox chkAmbDB;
        private System.Windows.Forms.CheckBox chkAmbUnix;
        private System.Windows.Forms.CheckBox chkAmbWin;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource VwInventarioEntityBindingSource;
        private System.Windows.Forms.RadioButton rbFilActivasNo;
        private System.Windows.Forms.RadioButton rbFilActivasSi;
        private System.Windows.Forms.RadioButton rbFilActivasTodas;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rbFilCriticasNo;
        private System.Windows.Forms.RadioButton rbFilCriticasSi;
        private System.Windows.Forms.RadioButton rbFilCriticasTodas;
        private System.Windows.Forms.CheckBox chkAmbAS400;
        private System.Windows.Forms.CheckBox chkAmbEC;
        protected System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.CheckBox chkAmbATM;
        //Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();

    }
}
