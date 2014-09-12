namespace PhalanxAdmin
{
    partial class FBaseSelect
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
            this.statusbar = new System.Windows.Forms.StatusStrip();
            this.pbDB = new System.Windows.Forms.ToolStripProgressBar();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lnkCancelar = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlList = new System.Windows.Forms.Panel();
            this.lvLista = new System.Windows.Forms.ListView();
            this.bwRefreshEntities = new System.ComponentModel.BackgroundWorker();
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtFilNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.statusbar.SuspendLayout();
            this.pnlList.SuspendLayout();
            this.pnlFilters.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 375);
            this.groupBox1.Size = new System.Drawing.Size(296, 43);
            // 
            // statusbar
            // 
            this.statusbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pbDB,
            this.lblStatus,
            this.lnkCancelar});
            this.statusbar.Location = new System.Drawing.Point(0, 418);
            this.statusbar.Name = "statusbar";
            this.statusbar.Size = new System.Drawing.Size(296, 22);
            this.statusbar.TabIndex = 5;
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
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // lnkCancelar
            // 
            this.lnkCancelar.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkCancelar.IsLink = true;
            this.lnkCancelar.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkCancelar.Name = "lnkCancelar";
            this.lnkCancelar.Size = new System.Drawing.Size(49, 17);
            this.lnkCancelar.Text = "Cancelar";
            this.lnkCancelar.ToolTipText = "Cancela la ejecución actual";
            this.lnkCancelar.Click += new System.EventHandler(this.lnkCancelar_Click);
            // 
            // pnlList
            // 
            this.pnlList.Controls.Add(this.lvLista);
            this.pnlList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlList.Location = new System.Drawing.Point(0, 119);
            this.pnlList.Name = "pnlList";
            this.pnlList.Size = new System.Drawing.Size(296, 321);
            this.pnlList.TabIndex = 7;
            // 
            // lvLista
            // 
            this.lvLista.AllowColumnReorder = true;
            this.lvLista.FullRowSelect = true;
            this.lvLista.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvLista.HideSelection = false;
            this.lvLista.Location = new System.Drawing.Point(13, 6);
            this.lvLista.MultiSelect = false;
            this.lvLista.Name = "lvLista";
            this.lvLista.Size = new System.Drawing.Size(267, 244);
            this.lvLista.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvLista.TabIndex = 1;
            this.lvLista.UseCompatibleStateImageBehavior = false;
            this.lvLista.View = System.Windows.Forms.View.Details;
            // 
            // bwRefreshEntities
            // 
            this.bwRefreshEntities.WorkerSupportsCancellation = true;
            this.bwRefreshEntities.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwRefreshEntities_DoWork);
            this.bwRefreshEntities.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwRefreshEntities_RunWorkerCompleted);
            // 
            // pnlFilters
            // 
            this.pnlFilters.Controls.Add(this.groupBox2);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Location = new System.Drawing.Point(0, 21);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(296, 98);
            this.pnlFilters.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnLimpiar);
            this.groupBox2.Controls.Add(this.btnBuscar);
            this.groupBox2.Controls.Add(this.txtFilNombre);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(13, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(267, 84);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtros de búsqueda";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpiar.Location = new System.Drawing.Point(207, 20);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(54, 21);
            this.btnLimpiar.TabIndex = 8;
            this.btnLimpiar.Text = "&Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(208, 48);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(54, 21);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtFilNombre
            // 
            this.txtFilNombre.Location = new System.Drawing.Point(61, 20);
            this.txtFilNombre.Name = "txtFilNombre";
            this.txtFilNombre.Size = new System.Drawing.Size(127, 20);
            this.txtFilNombre.TabIndex = 1;
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
            // FBaseSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(296, 440);
            this.Controls.Add(this.statusbar);
            this.Controls.Add(this.pnlList);
            this.Controls.Add(this.pnlFilters);
            this.Name = "FBaseSelect";
            this.Load += new System.EventHandler(this.FBaseSelect_Load);
            this.Controls.SetChildIndex(this.pnlFilters, 0);
            this.Controls.SetChildIndex(this.pnlList, 0);
            this.Controls.SetChildIndex(this.statusbar, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.statusbar.ResumeLayout(false);
            this.statusbar.PerformLayout();
            this.pnlList.ResumeLayout(false);
            this.pnlFilters.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripProgressBar pbDB;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Panel pnlList;
        protected System.Windows.Forms.ListView lvLista;
        private System.Windows.Forms.Panel pnlFilters;
        protected System.Windows.Forms.GroupBox groupBox2;
        protected System.Windows.Forms.Button btnLimpiar;
        protected System.Windows.Forms.Button btnBuscar;
        protected System.Windows.Forms.TextBox txtFilNombre;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.ToolStripStatusLabel lnkCancelar;
        protected System.ComponentModel.BackgroundWorker bwRefreshEntities;
        protected System.Windows.Forms.StatusStrip statusbar;

    }
}
