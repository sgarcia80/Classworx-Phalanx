namespace PhalanxAdmin
{
    partial class FEquiposCom
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
            System.Windows.Forms.ColumnHeader columnHeader2;
            System.Windows.Forms.ColumnHeader columnHeader1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FEquiposCom));
            this.xppnlPCs = new UIComponents.XPPanel(141);
            this.lnkView = new System.Windows.Forms.LinkLabel();
            this.lnkDelete = new System.Windows.Forms.LinkLabel();
            this.lnkModify = new System.Windows.Forms.LinkLabel();
            this.lnkAdd = new System.Windows.Forms.LinkLabel();
            this.bwRefreshEntities = new System.ComponentModel.BackgroundWorker();
            this.statusbar = new System.Windows.Forms.StatusStrip();
            this.pbDB = new System.Windows.Forms.ToolStripProgressBar();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lnkCancelar = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbTipoEC = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtFilNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlList = new System.Windows.Forms.Panel();
            this.lvLista = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            columnHeader2 = new System.Windows.Forms.ColumnHeader();
            columnHeader1 = new System.Windows.Forms.ColumnHeader();
            ((System.ComponentModel.ISupportInitialize)(this.pnlXPGrps)).BeginInit();
            this.pnlXPGrps.SuspendLayout();
            this.pnlIzq.SuspendLayout();
            this.xppnlPCs.SuspendLayout();
            this.statusbar.SuspendLayout();
            this.pnlFilters.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlList.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlXPGrps
            // 
            this.pnlXPGrps.Controls.Add(this.xppnlPCs);
            this.pnlXPGrps.Size = new System.Drawing.Size(200, 522);
            this.pnlXPGrps.Controls.SetChildIndex(this.xppnlMenu, 0);
            this.pnlXPGrps.Controls.SetChildIndex(this.xppnlPCs, 0);
            // 
            // pnlIzq
            // 
            this.pnlIzq.Size = new System.Drawing.Size(200, 522);
            // 
            // xppnlMenu
            // 
            this.xppnlMenu.ImageItems.ImageSet = null;
            this.xppnlMenu.Location = new System.Drawing.Point(8, 157);
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Nombre";
            columnHeader2.Width = 158;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Tipo";
            columnHeader1.Width = 100;
            // 
            // xppnlPCs
            // 
            this.xppnlPCs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xppnlPCs.BackColor = System.Drawing.Color.Transparent;
            this.xppnlPCs.Caption = "Equipos de Comunicación";
            this.xppnlPCs.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xppnlPCs.CaptionGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
            this.xppnlPCs.CaptionGradient.Start = System.Drawing.Color.White;
            this.xppnlPCs.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xppnlPCs.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xppnlPCs.Controls.Add(this.lnkView);
            this.xppnlPCs.Controls.Add(this.lnkDelete);
            this.xppnlPCs.Controls.Add(this.lnkModify);
            this.xppnlPCs.Controls.Add(this.lnkAdd);
            this.xppnlPCs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.xppnlPCs.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xppnlPCs.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xppnlPCs.ImageItems.ImageSet = null;
            this.xppnlPCs.Location = new System.Drawing.Point(8, 8);
            this.xppnlPCs.Name = "xppnlPCs";
            this.xppnlPCs.PanelGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.xppnlPCs.PanelGradient.Start = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.xppnlPCs.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xppnlPCs.Size = new System.Drawing.Size(184, 141);
            this.xppnlPCs.TabIndex = 4;
            this.xppnlPCs.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.xppnlPCs.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.xppnlPCs.VertAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lnkView
            // 
            this.lnkView.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkView.AutoSize = true;
            this.lnkView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.lnkView.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkView.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkView.Location = new System.Drawing.Point(17, 92);
            this.lnkView.Name = "lnkView";
            this.lnkView.Size = new System.Drawing.Size(61, 13);
            this.lnkView.TabIndex = 11;
            this.lnkView.TabStop = true;
            this.lnkView.Text = "Visualizar";
            this.lnkView.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkView.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkView_LinkClicked);
            // 
            // lnkDelete
            // 
            this.lnkDelete.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkDelete.AutoSize = true;
            this.lnkDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.lnkDelete.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkDelete.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkDelete.Location = new System.Drawing.Point(17, 113);
            this.lnkDelete.Name = "lnkDelete";
            this.lnkDelete.Size = new System.Drawing.Size(51, 13);
            this.lnkDelete.TabIndex = 10;
            this.lnkDelete.TabStop = true;
            this.lnkDelete.Text = "Eliminar";
            this.lnkDelete.Visible = false;
            this.lnkDelete.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            // 
            // lnkModify
            // 
            this.lnkModify.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkModify.AutoSize = true;
            this.lnkModify.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.lnkModify.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkModify.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkModify.Location = new System.Drawing.Point(17, 71);
            this.lnkModify.Name = "lnkModify";
            this.lnkModify.Size = new System.Drawing.Size(59, 13);
            this.lnkModify.TabIndex = 9;
            this.lnkModify.TabStop = true;
            this.lnkModify.Text = "Modificar";
            this.lnkModify.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkModify.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkModify_LinkClicked);
            // 
            // lnkAdd
            // 
            this.lnkAdd.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkAdd.AutoSize = true;
            this.lnkAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.lnkAdd.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkAdd.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkAdd.Location = new System.Drawing.Point(18, 50);
            this.lnkAdd.Name = "lnkAdd";
            this.lnkAdd.Size = new System.Drawing.Size(51, 13);
            this.lnkAdd.TabIndex = 8;
            this.lnkAdd.TabStop = true;
            this.lnkAdd.Text = "Agregar";
            this.lnkAdd.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAdd_LinkClicked);
            // 
            // bwRefreshEntities
            // 
            this.bwRefreshEntities.WorkerReportsProgress = true;
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
            this.statusbar.Location = new System.Drawing.Point(200, 500);
            this.statusbar.Name = "statusbar";
            this.statusbar.Size = new System.Drawing.Size(522, 22);
            this.statusbar.TabIndex = 11;
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
            // pnlFilters
            // 
            this.pnlFilters.Controls.Add(this.groupBox1);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Location = new System.Drawing.Point(200, 0);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(522, 96);
            this.pnlFilters.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbTipoEC);
            this.groupBox1.Controls.Add(this.label5);
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
            // cbTipoEC
            // 
            this.cbTipoEC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoEC.FormattingEnabled = true;
            this.cbTipoEC.Location = new System.Drawing.Point(67, 56);
            this.cbTipoEC.Name = "cbTipoEC";
            this.cbTipoEC.Size = new System.Drawing.Size(143, 21);
            this.cbTipoEC.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Tipo";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.SystemColors.Control;
            this.btnLimpiar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnLimpiar.Location = new System.Drawing.Point(388, 22);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(76, 21);
            this.btnLimpiar.TabIndex = 4;
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
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtFilNombre
            // 
            this.txtFilNombre.Location = new System.Drawing.Point(67, 22);
            this.txtFilNombre.Name = "txtFilNombre";
            this.txtFilNombre.Size = new System.Drawing.Size(267, 20);
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
            this.pnlList.Controls.Add(this.lvLista);
            this.pnlList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlList.Location = new System.Drawing.Point(200, 96);
            this.pnlList.Name = "pnlList";
            this.pnlList.Size = new System.Drawing.Size(522, 404);
            this.pnlList.TabIndex = 13;
            // 
            // lvLista
            // 
            this.lvLista.AllowColumnReorder = true;
            this.lvLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvLista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeader2,
            columnHeader1,
            this.columnHeader3,
            this.columnHeader4});
            this.lvLista.HideSelection = false;
            this.lvLista.Location = new System.Drawing.Point(18, 16);
            this.lvLista.MultiSelect = false;
            this.lvLista.Name = "lvLista";
            this.lvLista.Size = new System.Drawing.Size(482, 323);
            this.lvLista.SmallImageList = this.imageList;
            this.lvLista.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvLista.TabIndex = 1;
            this.lvLista.UseCompatibleStateImageBehavior = false;
            this.lvLista.View = System.Windows.Forms.View.Details;
            this.lvLista.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvLista_ColumnClick);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "IP";
            this.columnHeader3.Width = 90;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Descripción";
            this.columnHeader4.Width = 200;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Active.jpg");
            this.imageList.Images.SetKeyName(1, "Desactivo.jpg");
            // 
            // FEquiposCom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(722, 522);
            this.Controls.Add(this.pnlList);
            this.Controls.Add(this.pnlFilters);
            this.Controls.Add(this.statusbar);
            this.Name = "FEquiposCom";
            this.Load += new System.EventHandler(this.FEquiposCom_Load);
            this.Controls.SetChildIndex(this.pnlIzq, 0);
            this.Controls.SetChildIndex(this.statusbar, 0);
            this.Controls.SetChildIndex(this.pnlFilters, 0);
            this.Controls.SetChildIndex(this.pnlList, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pnlXPGrps)).EndInit();
            this.pnlXPGrps.ResumeLayout(false);
            this.pnlIzq.ResumeLayout(false);
            this.xppnlPCs.ResumeLayout(false);
            this.xppnlPCs.PerformLayout();
            this.statusbar.ResumeLayout(false);
            this.statusbar.PerformLayout();
            this.pnlFilters.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UIComponents.XPPanel xppnlPCs;
        protected System.Windows.Forms.LinkLabel lnkView;
        protected System.Windows.Forms.LinkLabel lnkDelete;
        protected System.Windows.Forms.LinkLabel lnkModify;
        protected System.Windows.Forms.LinkLabel lnkAdd;
        private System.ComponentModel.BackgroundWorker bwRefreshEntities;
        private System.Windows.Forms.StatusStrip statusbar;
        private System.Windows.Forms.ToolStripProgressBar pbDB;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lnkCancelar;
        private System.Windows.Forms.Panel pnlFilters;
        protected System.Windows.Forms.GroupBox groupBox1;
        protected System.Windows.Forms.Button btnLimpiar;
        protected System.Windows.Forms.Button btnBuscar;
        protected System.Windows.Forms.TextBox txtFilNombre;
        protected System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlList;
        protected System.Windows.Forms.ListView lvLista;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ComboBox cbTipoEC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}
