namespace PhalanxAdmin
{
    partial class FABMEquipo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FABMEquipo));
            this.panelDominio = new System.Windows.Forms.Panel();
            this.cbDominio = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cBoxActivo = new System.Windows.Forms.CheckBox();
            this.picDesactivo = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.picActivo = new System.Windows.Forms.PictureBox();
            this.tBPCDescript = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pNetFind = new System.Windows.Forms.PictureBox();
            this.tBIP4 = new System.Windows.Forms.TextBox();
            this.tBIP3 = new System.Windows.Forms.TextBox();
            this.tBIP2 = new System.Windows.Forms.TextBox();
            this.tBIP1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPCName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lvLista = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.panelDominio.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDesactivo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picActivo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pNetFind)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 301);
            this.groupBox1.Size = new System.Drawing.Size(426, 43);
            // 
            // btnAceptar
            // 
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.TabIndex = 8;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Usuario";
            columnHeader3.Width = 196;
            // 
            // panelDominio
            // 
            this.panelDominio.Controls.Add(this.cbDominio);
            this.panelDominio.Controls.Add(this.label5);
            this.panelDominio.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDominio.Location = new System.Drawing.Point(3, 3);
            this.panelDominio.Name = "panelDominio";
            this.panelDominio.Size = new System.Drawing.Size(388, 51);
            this.panelDominio.TabIndex = 28;
            // 
            // cbDominio
            // 
            this.cbDominio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDominio.FormattingEnabled = true;
            this.cbDominio.Location = new System.Drawing.Point(16, 23);
            this.cbDominio.Name = "cbDominio";
            this.cbDominio.Size = new System.Drawing.Size(284, 21);
            this.cbDominio.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Dominio";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cBoxActivo);
            this.panel4.Controls.Add(this.picDesactivo);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.picActivo);
            this.panel4.Controls.Add(this.tBPCDescript);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.pNetFind);
            this.panel4.Controls.Add(this.tBIP4);
            this.panel4.Controls.Add(this.tBIP3);
            this.panel4.Controls.Add(this.tBIP2);
            this.panel4.Controls.Add(this.tBIP1);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.txtPCName);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(388, 240);
            this.panel4.TabIndex = 29;
            // 
            // cBoxActivo
            // 
            this.cBoxActivo.AutoSize = true;
            this.cBoxActivo.Checked = true;
            this.cBoxActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxActivo.Location = new System.Drawing.Point(282, 160);
            this.cBoxActivo.Name = "cBoxActivo";
            this.cBoxActivo.Size = new System.Drawing.Size(56, 17);
            this.cBoxActivo.TabIndex = 40;
            this.cBoxActivo.Text = "Activo";
            this.cBoxActivo.UseVisualStyleBackColor = true;
            this.cBoxActivo.CheckedChanged += new System.EventHandler(this.cBoxActivo_CheckedChanged);
            // 
            // picDesactivo
            // 
            this.picDesactivo.ErrorImage = null;
            this.picDesactivo.Image = ((System.Drawing.Image)(resources.GetObject("picDesactivo.Image")));
            this.picDesactivo.Location = new System.Drawing.Point(332, 133);
            this.picDesactivo.Name = "picDesactivo";
            this.picDesactivo.Size = new System.Drawing.Size(20, 17);
            this.picDesactivo.TabIndex = 43;
            this.picDesactivo.TabStop = false;
            this.picDesactivo.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(279, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 42;
            this.label4.Text = "Estado:";
            // 
            // picActivo
            // 
            this.picActivo.ErrorImage = null;
            this.picActivo.Image = ((System.Drawing.Image)(resources.GetObject("picActivo.Image")));
            this.picActivo.Location = new System.Drawing.Point(332, 133);
            this.picActivo.Margin = new System.Windows.Forms.Padding(0);
            this.picActivo.Name = "picActivo";
            this.picActivo.Size = new System.Drawing.Size(22, 17);
            this.picActivo.TabIndex = 41;
            this.picActivo.TabStop = false;
            // 
            // tBPCDescript
            // 
            this.tBPCDescript.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tBPCDescript.Location = new System.Drawing.Point(17, 70);
            this.tBPCDescript.MaxLength = 199;
            this.tBPCDescript.Multiline = true;
            this.tBPCDescript.Name = "tBPCDescript";
            this.tBPCDescript.Size = new System.Drawing.Size(325, 54);
            this.tBPCDescript.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Descripción";
            // 
            // pNetFind
            // 
            this.pNetFind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pNetFind.Image = ((System.Drawing.Image)(resources.GetObject("pNetFind.Image")));
            this.pNetFind.Location = new System.Drawing.Point(317, 20);
            this.pNetFind.Name = "pNetFind";
            this.pNetFind.Size = new System.Drawing.Size(25, 26);
            this.pNetFind.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pNetFind.TabIndex = 34;
            this.pNetFind.TabStop = false;
            this.pNetFind.Visible = false;
            // 
            // tBIP4
            // 
            this.tBIP4.AcceptsTab = true;
            this.tBIP4.Location = new System.Drawing.Point(114, 153);
            this.tBIP4.MaxLength = 3;
            this.tBIP4.Name = "tBIP4";
            this.tBIP4.Size = new System.Drawing.Size(26, 20);
            this.tBIP4.TabIndex = 6;
            this.tBIP4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tBIP4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tBIP4_KeyPress);
            // 
            // tBIP3
            // 
            this.tBIP3.AcceptsTab = true;
            this.tBIP3.Location = new System.Drawing.Point(82, 153);
            this.tBIP3.MaxLength = 3;
            this.tBIP3.Name = "tBIP3";
            this.tBIP3.Size = new System.Drawing.Size(26, 20);
            this.tBIP3.TabIndex = 5;
            this.tBIP3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tBIP3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tBIP3_KeyPress);
            // 
            // tBIP2
            // 
            this.tBIP2.AcceptsTab = true;
            this.tBIP2.Location = new System.Drawing.Point(50, 153);
            this.tBIP2.MaxLength = 3;
            this.tBIP2.Name = "tBIP2";
            this.tBIP2.Size = new System.Drawing.Size(26, 20);
            this.tBIP2.TabIndex = 4;
            this.tBIP2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tBIP2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tBIP2_KeyPress);
            // 
            // tBIP1
            // 
            this.tBIP1.AcceptsTab = true;
            this.tBIP1.Location = new System.Drawing.Point(18, 153);
            this.tBIP1.MaxLength = 3;
            this.tBIP1.Name = "tBIP1";
            this.tBIP1.Size = new System.Drawing.Size(26, 20);
            this.tBIP1.TabIndex = 3;
            this.tBIP1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tBIP1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tBIP1_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Dirección IP";
            // 
            // txtPCName
            // 
            this.txtPCName.Location = new System.Drawing.Point(17, 21);
            this.txtPCName.Name = "txtPCName";
            this.txtPCName.Size = new System.Drawing.Size(284, 20);
            this.txtPCName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Nombre de Equipo";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(13, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(402, 272);
            this.tabControl1.TabIndex = 30;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panelDominio);
            this.tabPage1.Controls.Add(this.panel4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(394, 246);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lvLista);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(394, 246);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Contraseñas";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lvLista
            // 
            this.lvLista.AllowColumnReorder = true;
            this.lvLista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            columnHeader3,
            this.columnHeader7});
            this.lvLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvLista.FullRowSelect = true;
            this.lvLista.HideSelection = false;
            this.lvLista.Location = new System.Drawing.Point(3, 3);
            this.lvLista.MultiSelect = false;
            this.lvLista.Name = "lvLista";
            this.lvLista.Size = new System.Drawing.Size(388, 240);
            this.lvLista.SmallImageList = this.imageList;
            this.lvLista.TabIndex = 4;
            this.lvLista.UseCompatibleStateImageBehavior = false;
            this.lvLista.View = System.Windows.Forms.View.Details;
            this.lvLista.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvLista_ColumnClick);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "";
            this.columnHeader5.Width = 30;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Tag = "Numeric";
            this.columnHeader6.Text = "Folio";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader6.Width = 53;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Tag = "";
            this.columnHeader7.Text = "Crítico";
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Active.jpg");
            this.imageList.Images.SetKeyName(1, "Desactivo.jpg");
            // 
            // FABMEquipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(426, 344);
            this.Controls.Add(this.tabControl1);
            this.Name = "FABMEquipo";
            this.Load += new System.EventHandler(this.FABMEquipo_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.panelDominio.ResumeLayout(false);
            this.panelDominio.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDesactivo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picActivo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pNetFind)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDominio;
        private System.Windows.Forms.ComboBox cbDominio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        protected System.Windows.Forms.TextBox tBPCDescript;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pNetFind;
        protected System.Windows.Forms.TextBox tBIP4;
        protected System.Windows.Forms.TextBox tBIP3;
        protected System.Windows.Forms.TextBox tBIP2;
        protected System.Windows.Forms.TextBox tBIP1;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.TextBox txtPCName;
        protected System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cBoxActivo;
        private System.Windows.Forms.PictureBox picDesactivo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox picActivo;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        protected System.Windows.Forms.ListView lvLista;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ImageList imageList;
    }
}
