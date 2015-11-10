namespace PhalanxAdmin
{
    partial class FAplicativosBPM
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
            System.Windows.Forms.ColumnHeader columnHeader2;
            this.xppnlDBs = new UIComponents.XPPanel(84);
            this.lnkModificar = new System.Windows.Forms.LinkLabel();
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.btnSetAppRed = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtFilNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlList = new System.Windows.Forms.Panel();
            this.statusbar = new System.Windows.Forms.StatusStrip();
            this.pbDB = new System.Windows.Forms.ToolStripProgressBar();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lnkCancelar = new System.Windows.Forms.ToolStripStatusLabel();
            this.lvLista = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bwRefreshEntities = new System.ComponentModel.BackgroundWorker();
            this.btnSetAppCobis = new System.Windows.Forms.Button();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.pnlXPGrps)).BeginInit();
            this.pnlXPGrps.SuspendLayout();
            this.pnlIzq.SuspendLayout();
            this.xppnlDBs.SuspendLayout();
            this.pnlFilters.SuspendLayout();
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
            this.xppnlMenu.Location = new System.Drawing.Point(8, 100);
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Código";
            columnHeader2.Width = 162;
            // 
            // xppnlDBs
            // 
            this.xppnlDBs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xppnlDBs.BackColor = System.Drawing.Color.Transparent;
            this.xppnlDBs.Caption = "Aplicativos BMP";
            this.xppnlDBs.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xppnlDBs.CaptionGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
            this.xppnlDBs.CaptionGradient.Start = System.Drawing.Color.White;
            this.xppnlDBs.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xppnlDBs.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xppnlDBs.Controls.Add(this.lnkModificar);
            this.xppnlDBs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.xppnlDBs.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xppnlDBs.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xppnlDBs.ImageItems.ImageSet = null;
            this.xppnlDBs.Location = new System.Drawing.Point(8, 8);
            this.xppnlDBs.Name = "xppnlDBs";
            this.xppnlDBs.PanelGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.xppnlDBs.PanelGradient.Start = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.xppnlDBs.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xppnlDBs.Size = new System.Drawing.Size(184, 84);
            this.xppnlDBs.TabIndex = 6;
            this.xppnlDBs.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.xppnlDBs.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.xppnlDBs.VertAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lnkModificar
            // 
            this.lnkModificar.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkModificar.AutoSize = true;
            this.lnkModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.lnkModificar.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkModificar.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkModificar.Location = new System.Drawing.Point(18, 50);
            this.lnkModificar.Name = "lnkModificar";
            this.lnkModificar.Size = new System.Drawing.Size(59, 13);
            this.lnkModificar.TabIndex = 8;
            this.lnkModificar.TabStop = true;
            this.lnkModificar.Text = "Modificar";
            this.lnkModificar.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkModificar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkModificar_LinkClicked);
            // 
            // pnlFilters
            // 
            this.pnlFilters.Controls.Add(this.btnSetAppCobis);
            this.pnlFilters.Controls.Add(this.btnSetAppRed);
            this.pnlFilters.Controls.Add(this.groupBox1);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Location = new System.Drawing.Point(200, 0);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(692, 98);
            this.pnlFilters.TabIndex = 14;
            // 
            // btnSetAppRed
            // 
            this.btnSetAppRed.BackColor = System.Drawing.SystemColors.Control;
            this.btnSetAppRed.Location = new System.Drawing.Point(509, 44);
            this.btnSetAppRed.Name = "btnSetAppRed";
            this.btnSetAppRed.Size = new System.Drawing.Size(171, 21);
            this.btnSetAppRed.TabIndex = 4;
            this.btnSetAppRed.Text = "&Setear como Aplicación de Red";
            this.btnSetAppRed.UseVisualStyleBackColor = false;
            this.btnSetAppRed.Click += new System.EventHandler(this.btnSetAppRed_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.txtFilNombre);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(18, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(485, 84);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de búsqueda";
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
            // pnlList
            // 
            this.pnlList.Controls.Add(this.statusbar);
            this.pnlList.Controls.Add(this.lvLista);
            this.pnlList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlList.Location = new System.Drawing.Point(200, 98);
            this.pnlList.Name = "pnlList";
            this.pnlList.Size = new System.Drawing.Size(692, 497);
            this.pnlList.TabIndex = 15;
            // 
            // statusbar
            // 
            this.statusbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pbDB,
            this.lblStatus,
            this.lnkCancelar});
            this.statusbar.Location = new System.Drawing.Point(0, 475);
            this.statusbar.Name = "statusbar";
            this.statusbar.Size = new System.Drawing.Size(692, 22);
            this.statusbar.TabIndex = 12;
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
            columnHeader2,
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvLista.HideSelection = false;
            this.lvLista.Location = new System.Drawing.Point(18, 16);
            this.lvLista.MultiSelect = false;
            this.lvLista.Name = "lvLista";
            this.lvLista.Size = new System.Drawing.Size(662, 443);
            this.lvLista.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvLista.TabIndex = 1;
            this.lvLista.UseCompatibleStateImageBehavior = false;
            this.lvLista.View = System.Windows.Forms.View.Details;
            this.lvLista.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvLista_ColumnClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Nombre";
            this.columnHeader1.Width = 175;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Notificable";
            this.columnHeader3.Width = 173;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Aplicación de Red";
            this.columnHeader4.Width = 160;
            // 
            // bwRefreshEntities
            // 
            this.bwRefreshEntities.WorkerSupportsCancellation = true;
            this.bwRefreshEntities.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwRefreshEntities_DoWork);
            this.bwRefreshEntities.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwRefreshEntities_RunWorkerCompleted);
            // 
            // btnSetAppCobis
            // 
            this.btnSetAppCobis.BackColor = System.Drawing.SystemColors.Control;
            this.btnSetAppCobis.Location = new System.Drawing.Point(509, 71);
            this.btnSetAppCobis.Name = "btnSetAppCobis";
            this.btnSetAppCobis.Size = new System.Drawing.Size(171, 21);
            this.btnSetAppCobis.TabIndex = 5;
            this.btnSetAppCobis.Text = "Setear como Aplicación &Cobis";
            this.btnSetAppCobis.UseVisualStyleBackColor = false;
            this.btnSetAppCobis.Click += new System.EventHandler(this.btnSetAppCobis_Click);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Aplicación Cobis";
            this.columnHeader5.Width = 160;
            // 
            // FAplicativosBPM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(892, 595);
            this.Controls.Add(this.pnlList);
            this.Controls.Add(this.pnlFilters);
            this.Name = "FAplicativosBPM";
            this.Load += new System.EventHandler(this.FAplicativosBPM_Load);
            this.Controls.SetChildIndex(this.pnlIzq, 0);
            this.Controls.SetChildIndex(this.pnlFilters, 0);
            this.Controls.SetChildIndex(this.pnlList, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pnlXPGrps)).EndInit();
            this.pnlXPGrps.ResumeLayout(false);
            this.pnlIzq.ResumeLayout(false);
            this.xppnlDBs.ResumeLayout(false);
            this.xppnlDBs.PerformLayout();
            this.pnlFilters.ResumeLayout(false);
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
        protected System.Windows.Forms.LinkLabel lnkModificar;
        private System.Windows.Forms.Panel pnlFilters;
        protected System.Windows.Forms.GroupBox groupBox1;
        protected System.Windows.Forms.Button btnLimpiar;
        protected System.Windows.Forms.Button btnBuscar;
        protected System.Windows.Forms.TextBox txtFilNombre;
        protected System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlList;
        private System.Windows.Forms.StatusStrip statusbar;
        private System.Windows.Forms.ToolStripProgressBar pbDB;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lnkCancelar;
        protected System.Windows.Forms.ListView lvLista;
        private System.ComponentModel.BackgroundWorker bwRefreshEntities;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        protected System.Windows.Forms.Button btnSetAppRed;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        protected System.Windows.Forms.Button btnSetAppCobis;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}
