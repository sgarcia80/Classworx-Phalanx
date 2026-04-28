namespace PhalanxAdmin
{
    partial class FABMEquiposCom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FABMEquiposCom));
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("ListViewGroup1", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ColumnHeader columnHeader3;
            this.cbCDType = new System.Windows.Forms.ComboBox();
            this.txtCDName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIP4 = new System.Windows.Forms.TextBox();
            this.txtIP3 = new System.Windows.Forms.TextBox();
            this.txtIP2 = new System.Windows.Forms.TextBox();
            this.txtIP1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cBoxActivo = new System.Windows.Forms.CheckBox();
            this.picDesactivo = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.picActivo = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.clbCDProtocols = new System.Windows.Forms.ListView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lvLista = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            columnHeader3 = new System.Windows.Forms.ColumnHeader();
            ((System.ComponentModel.ISupportInitialize)(this.picDesactivo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picActivo)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 421);
            this.groupBox1.Size = new System.Drawing.Size(503, 43);
            this.groupBox1.TabIndex = 9;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cbCDType
            // 
            this.cbCDType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCDType.FormattingEnabled = true;
            this.cbCDType.Location = new System.Drawing.Point(91, 44);
            this.cbCDType.Name = "cbCDType";
            this.cbCDType.Size = new System.Drawing.Size(217, 21);
            this.cbCDType.TabIndex = 1;
            // 
            // txtCDName
            // 
            this.txtCDName.Location = new System.Drawing.Point(91, 18);
            this.txtCDName.Name = "txtCDName";
            this.txtCDName.Size = new System.Drawing.Size(217, 20);
            this.txtCDName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Tipo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Nombre";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(91, 97);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(217, 50);
            this.txtDesc.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Descripción";
            // 
            // txtIP4
            // 
            this.txtIP4.AcceptsTab = true;
            this.txtIP4.Location = new System.Drawing.Point(187, 71);
            this.txtIP4.MaxLength = 3;
            this.txtIP4.Name = "txtIP4";
            this.txtIP4.Size = new System.Drawing.Size(26, 20);
            this.txtIP4.TabIndex = 5;
            this.txtIP4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIP4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIP4_KeyPress);
            // 
            // txtIP3
            // 
            this.txtIP3.AcceptsTab = true;
            this.txtIP3.Location = new System.Drawing.Point(155, 71);
            this.txtIP3.MaxLength = 3;
            this.txtIP3.Name = "txtIP3";
            this.txtIP3.Size = new System.Drawing.Size(26, 20);
            this.txtIP3.TabIndex = 4;
            this.txtIP3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIP3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIP3_KeyPress);
            // 
            // txtIP2
            // 
            this.txtIP2.AcceptsTab = true;
            this.txtIP2.Location = new System.Drawing.Point(123, 71);
            this.txtIP2.MaxLength = 3;
            this.txtIP2.Name = "txtIP2";
            this.txtIP2.Size = new System.Drawing.Size(26, 20);
            this.txtIP2.TabIndex = 3;
            this.txtIP2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIP2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIP2_KeyPress);
            // 
            // txtIP1
            // 
            this.txtIP1.AcceptsTab = true;
            this.txtIP1.Location = new System.Drawing.Point(91, 71);
            this.txtIP1.MaxLength = 3;
            this.txtIP1.Name = "txtIP1";
            this.txtIP1.Size = new System.Drawing.Size(26, 20);
            this.txtIP1.TabIndex = 2;
            this.txtIP1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIP1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIP1_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Dirección IP";
            // 
            // cBoxActivo
            // 
            this.cBoxActivo.AutoSize = true;
            this.cBoxActivo.Checked = true;
            this.cBoxActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxActivo.Location = new System.Drawing.Point(14, 304);
            this.cBoxActivo.Name = "cBoxActivo";
            this.cBoxActivo.Size = new System.Drawing.Size(56, 17);
            this.cBoxActivo.TabIndex = 8;
            this.cBoxActivo.Text = "Activo";
            this.cBoxActivo.UseVisualStyleBackColor = true;
            this.cBoxActivo.CheckedChanged += new System.EventHandler(this.cBoxActivo_CheckedChanged);
            // 
            // picDesactivo
            // 
            this.picDesactivo.ErrorImage = null;
            this.picDesactivo.Image = ((System.Drawing.Image)(resources.GetObject("picDesactivo.Image")));
            this.picDesactivo.Location = new System.Drawing.Point(64, 277);
            this.picDesactivo.Name = "picDesactivo";
            this.picDesactivo.Size = new System.Drawing.Size(20, 17);
            this.picDesactivo.TabIndex = 43;
            this.picDesactivo.TabStop = false;
            this.picDesactivo.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(11, 281);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 42;
            this.label7.Text = "Estado:";
            // 
            // picActivo
            // 
            this.picActivo.ErrorImage = null;
            this.picActivo.Image = ((System.Drawing.Image)(resources.GetObject("picActivo.Image")));
            this.picActivo.Location = new System.Drawing.Point(64, 277);
            this.picActivo.Margin = new System.Windows.Forms.Padding(0);
            this.picActivo.Name = "picActivo";
            this.picActivo.Size = new System.Drawing.Size(22, 17);
            this.picActivo.TabIndex = 41;
            this.picActivo.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 45;
            this.label5.Text = "Protocolos";
            // 
            // clbCDProtocols
            // 
            this.clbCDProtocols.AllowColumnReorder = true;
            this.clbCDProtocols.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.clbCDProtocols.CheckBoxes = true;
            this.clbCDProtocols.FullRowSelect = true;
            listViewGroup2.Header = "ListViewGroup1";
            listViewGroup2.Name = "listViewGroup1";
            this.clbCDProtocols.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup2});
            this.clbCDProtocols.HideSelection = false;
            this.clbCDProtocols.Location = new System.Drawing.Point(91, 153);
            this.clbCDProtocols.MultiSelect = false;
            this.clbCDProtocols.Name = "clbCDProtocols";
            this.clbCDProtocols.Size = new System.Drawing.Size(378, 190);
            this.clbCDProtocols.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.clbCDProtocols.TabIndex = 7;
            this.clbCDProtocols.UseCompatibleStateImageBehavior = false;
            this.clbCDProtocols.View = System.Windows.Forms.View.List;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(483, 391);
            this.tabControl1.TabIndex = 46;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtCDName);
            this.tabPage1.Controls.Add(this.clbCDProtocols);
            this.tabPage1.Controls.Add(this.cbCDType);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtDesc);
            this.tabPage1.Controls.Add(this.cBoxActivo);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.picDesactivo);
            this.tabPage1.Controls.Add(this.txtIP2);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.picActivo);
            this.tabPage1.Controls.Add(this.txtIP3);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtIP4);
            this.tabPage1.Controls.Add(this.txtIP1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(475, 365);
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
            this.tabPage2.Size = new System.Drawing.Size(475, 365);
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
            this.lvLista.Size = new System.Drawing.Size(469, 359);
            this.lvLista.SmallImageList = this.imageList;
            this.lvLista.TabIndex = 5;
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
            // columnHeader3
            // 
            columnHeader3.Text = "Usuario";
            columnHeader3.Width = 196;
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
            // FABMEquiposCom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(503, 464);
            this.Controls.Add(this.tabControl1);
            this.Name = "FABMEquiposCom";
            this.Load += new System.EventHandler(this.FABMEquiposCom_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picDesactivo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picActivo)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbCDType;
        private System.Windows.Forms.TextBox txtCDName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label3;
        protected System.Windows.Forms.TextBox txtIP4;
        protected System.Windows.Forms.TextBox txtIP3;
        protected System.Windows.Forms.TextBox txtIP2;
        protected System.Windows.Forms.TextBox txtIP1;
        protected System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cBoxActivo;
        private System.Windows.Forms.PictureBox picDesactivo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox picActivo;
        private System.Windows.Forms.Label label5;
        protected System.Windows.Forms.ListView clbCDProtocols;
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
