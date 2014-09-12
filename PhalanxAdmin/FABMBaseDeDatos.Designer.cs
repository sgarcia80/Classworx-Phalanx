namespace PhalanxAdmin
{
    partial class FABMBaseDeDatos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FABMBaseDeDatos));
            this.cbDBType = new System.Windows.Forms.ComboBox();
            this.txtDBName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIP4 = new System.Windows.Forms.TextBox();
            this.txtIP3 = new System.Windows.Forms.TextBox();
            this.txtIP2 = new System.Windows.Forms.TextBox();
            this.txtIP1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gbServer = new System.Windows.Forms.GroupBox();
            this.btnSelEquipo = new System.Windows.Forms.Button();
            this.txtEquipo = new System.Windows.Forms.TextBox();
            this.txtServerPort = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cBoxActivo = new System.Windows.Forms.CheckBox();
            this.picDesactivo = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.picActivo = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lvLista = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.gbServer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDesactivo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picActivo)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 358);
            this.groupBox1.Size = new System.Drawing.Size(357, 43);
            this.groupBox1.TabIndex = 5;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Usuario";
            columnHeader3.Width = 170;
            // 
            // cbDBType
            // 
            this.cbDBType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDBType.FormattingEnabled = true;
            this.cbDBType.Location = new System.Drawing.Point(87, 40);
            this.cbDBType.Name = "cbDBType";
            this.cbDBType.Size = new System.Drawing.Size(217, 21);
            this.cbDBType.TabIndex = 1;
            // 
            // txtDBName
            // 
            this.txtDBName.Location = new System.Drawing.Point(87, 14);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(217, 20);
            this.txtDBName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Tipo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Nombre";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(87, 67);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(217, 50);
            this.txtDesc.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Descripción";
            // 
            // txtIP4
            // 
            this.txtIP4.AcceptsTab = true;
            this.txtIP4.Location = new System.Drawing.Point(210, 97);
            this.txtIP4.MaxLength = 3;
            this.txtIP4.Name = "txtIP4";
            this.txtIP4.Size = new System.Drawing.Size(26, 20);
            this.txtIP4.TabIndex = 4;
            this.txtIP4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIP4.Visible = false;
            // 
            // txtIP3
            // 
            this.txtIP3.AcceptsTab = true;
            this.txtIP3.Location = new System.Drawing.Point(178, 97);
            this.txtIP3.MaxLength = 3;
            this.txtIP3.Name = "txtIP3";
            this.txtIP3.Size = new System.Drawing.Size(26, 20);
            this.txtIP3.TabIndex = 3;
            this.txtIP3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIP3.Visible = false;
            // 
            // txtIP2
            // 
            this.txtIP2.AcceptsTab = true;
            this.txtIP2.Location = new System.Drawing.Point(146, 97);
            this.txtIP2.MaxLength = 3;
            this.txtIP2.Name = "txtIP2";
            this.txtIP2.Size = new System.Drawing.Size(26, 20);
            this.txtIP2.TabIndex = 2;
            this.txtIP2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIP2.Visible = false;
            // 
            // txtIP1
            // 
            this.txtIP1.AcceptsTab = true;
            this.txtIP1.Location = new System.Drawing.Point(114, 97);
            this.txtIP1.MaxLength = 3;
            this.txtIP1.Name = "txtIP1";
            this.txtIP1.Size = new System.Drawing.Size(26, 20);
            this.txtIP1.TabIndex = 1;
            this.txtIP1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIP1.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Dirección IP";
            this.label4.Visible = false;
            // 
            // gbServer
            // 
            this.gbServer.Controls.Add(this.btnSelEquipo);
            this.gbServer.Controls.Add(this.txtEquipo);
            this.gbServer.Controls.Add(this.txtServerPort);
            this.gbServer.Controls.Add(this.label6);
            this.gbServer.Controls.Add(this.txtServerName);
            this.gbServer.Controls.Add(this.label5);
            this.gbServer.Controls.Add(this.label4);
            this.gbServer.Controls.Add(this.txtIP4);
            this.gbServer.Controls.Add(this.txtIP1);
            this.gbServer.Controls.Add(this.txtIP3);
            this.gbServer.Controls.Add(this.txtIP2);
            this.gbServer.Location = new System.Drawing.Point(10, 123);
            this.gbServer.Name = "gbServer";
            this.gbServer.Size = new System.Drawing.Size(295, 105);
            this.gbServer.TabIndex = 3;
            this.gbServer.TabStop = false;
            this.gbServer.Text = "Servidor";
            // 
            // btnSelEquipo
            // 
            this.btnSelEquipo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelEquipo.Location = new System.Drawing.Point(248, 44);
            this.btnSelEquipo.Name = "btnSelEquipo";
            this.btnSelEquipo.Size = new System.Drawing.Size(24, 23);
            this.btnSelEquipo.TabIndex = 2;
            this.btnSelEquipo.Text = "...";
            this.btnSelEquipo.UseVisualStyleBackColor = true;
            this.btnSelEquipo.Click += new System.EventHandler(this.btnSelEquipo_Click);
            // 
            // txtEquipo
            // 
            this.txtEquipo.BackColor = System.Drawing.Color.White;
            this.txtEquipo.Location = new System.Drawing.Point(43, 45);
            this.txtEquipo.Name = "txtEquipo";
            this.txtEquipo.ReadOnly = true;
            this.txtEquipo.Size = new System.Drawing.Size(199, 20);
            this.txtEquipo.TabIndex = 1;
            // 
            // txtServerPort
            // 
            this.txtServerPort.Location = new System.Drawing.Point(120, 71);
            this.txtServerPort.Name = "txtServerPort";
            this.txtServerPort.Size = new System.Drawing.Size(64, 20);
            this.txtServerPort.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "Puerto";
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(120, 19);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(122, 20);
            this.txtServerName.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "Nombre";
            // 
            // cBoxActivo
            // 
            this.cBoxActivo.AutoSize = true;
            this.cBoxActivo.Checked = true;
            this.cBoxActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxActivo.Location = new System.Drawing.Point(10, 260);
            this.cBoxActivo.Name = "cBoxActivo";
            this.cBoxActivo.Size = new System.Drawing.Size(56, 17);
            this.cBoxActivo.TabIndex = 4;
            this.cBoxActivo.Text = "Activo";
            this.cBoxActivo.UseVisualStyleBackColor = true;
            this.cBoxActivo.CheckedChanged += new System.EventHandler(this.cBoxActivo_CheckedChanged);
            // 
            // picDesactivo
            // 
            this.picDesactivo.ErrorImage = null;
            this.picDesactivo.Image = ((System.Drawing.Image)(resources.GetObject("picDesactivo.Image")));
            this.picDesactivo.Location = new System.Drawing.Point(60, 237);
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
            this.label7.Location = new System.Drawing.Point(7, 237);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 42;
            this.label7.Text = "Estado:";
            // 
            // picActivo
            // 
            this.picActivo.ErrorImage = null;
            this.picActivo.Image = ((System.Drawing.Image)(resources.GetObject("picActivo.Image")));
            this.picActivo.Location = new System.Drawing.Point(60, 237);
            this.picActivo.Margin = new System.Windows.Forms.Padding(0);
            this.picActivo.Name = "picActivo";
            this.picActivo.Size = new System.Drawing.Size(22, 17);
            this.picActivo.TabIndex = 41;
            this.picActivo.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(13, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(331, 324);
            this.tabControl1.TabIndex = 44;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cBoxActivo);
            this.tabPage1.Controls.Add(this.txtDBName);
            this.tabPage1.Controls.Add(this.picDesactivo);
            this.tabPage1.Controls.Add(this.cbDBType);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.gbServer);
            this.tabPage1.Controls.Add(this.picActivo);
            this.tabPage1.Controls.Add(this.txtDesc);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(323, 298);
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
            this.tabPage2.Size = new System.Drawing.Size(323, 298);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Contraseñas";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lvLista
            // 
            this.lvLista.AllowColumnReorder = true;
            this.lvLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvLista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            columnHeader3,
            this.columnHeader7});
            this.lvLista.FullRowSelect = true;
            this.lvLista.HideSelection = false;
            this.lvLista.Location = new System.Drawing.Point(6, 6);
            this.lvLista.MultiSelect = false;
            this.lvLista.Name = "lvLista";
            this.lvLista.Size = new System.Drawing.Size(311, 284);
            this.lvLista.SmallImageList = this.imageList;
            this.lvLista.TabIndex = 2;
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
            this.columnHeader6.Width = 44;
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
            // FABMBaseDeDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(357, 401);
            this.Controls.Add(this.tabControl1);
            this.Name = "FABMBaseDeDatos";
            this.Load += new System.EventHandler(this.FABMBaseDeDatos_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.gbServer.ResumeLayout(false);
            this.gbServer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDesactivo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picActivo)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbDBType;
        private System.Windows.Forms.TextBox txtDBName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label3;
        protected System.Windows.Forms.TextBox txtIP4;
        protected System.Windows.Forms.TextBox txtIP3;
        protected System.Windows.Forms.TextBox txtIP2;
        protected System.Windows.Forms.TextBox txtIP1;
        protected System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbServer;
        private System.Windows.Forms.TextBox txtServerPort;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEquipo;
        private System.Windows.Forms.Button btnSelEquipo;
        private System.Windows.Forms.CheckBox cBoxActivo;
        private System.Windows.Forms.PictureBox picDesactivo;
        private System.Windows.Forms.Label label7;
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
