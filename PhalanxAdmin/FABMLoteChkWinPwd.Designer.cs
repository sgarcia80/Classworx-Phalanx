namespace PhalanxAdmin
{
    partial class FABMLoteChkWinPwd
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtpFechaProgramada = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnDelItmsLote = new System.Windows.Forms.Button();
            this.lvWinPwdGrupo = new System.Windows.Forms.ListView();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnAddAllRoles = new System.Windows.Forms.Button();
            this.btnAddRole = new System.Windows.Forms.Button();
            this.lvWinPwdDB = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cbDominio = new System.Windows.Forms.ComboBox();
            this.lTitleDominio = new System.Windows.Forms.Label();
            columnHeader69 = new System.Windows.Forms.ColumnHeader();
            columnHeader4 = new System.Windows.Forms.ColumnHeader();
            columnHeader1 = new System.Windows.Forms.ColumnHeader();
            columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 493);
            this.groupBox1.Size = new System.Drawing.Size(817, 43);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // columnHeader69
            // 
            columnHeader69.Tag = "Numeric";
            columnHeader69.Text = "Folio";
            columnHeader69.Width = 40;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Usuario";
            columnHeader4.Width = 237;
            // 
            // columnHeader1
            // 
            columnHeader1.Tag = "Numeric";
            columnHeader1.Text = "Folio";
            columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Usuario";
            columnHeader2.Width = 237;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dtpFechaProgramada);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(0, 20);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(781, 40);
            this.panel3.TabIndex = 2;
            // 
            // dtpFechaProgramada
            // 
            this.dtpFechaProgramada.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpFechaProgramada.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaProgramada.Location = new System.Drawing.Point(114, 10);
            this.dtpFechaProgramada.Name = "dtpFechaProgramada";
            this.dtpFechaProgramada.Size = new System.Drawing.Size(129, 20);
            this.dtpFechaProgramada.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha programada";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Location = new System.Drawing.Point(0, 66);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(817, 427);
            this.panel4.TabIndex = 3;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnDelItmsLote);
            this.panel6.Controls.Add(this.lvWinPwdGrupo);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(431, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(386, 427);
            this.panel6.TabIndex = 1;
            // 
            // btnDelItmsLote
            // 
            this.btnDelItmsLote.BackColor = System.Drawing.SystemColors.Control;
            this.btnDelItmsLote.Location = new System.Drawing.Point(6, 38);
            this.btnDelItmsLote.Name = "btnDelItmsLote";
            this.btnDelItmsLote.Size = new System.Drawing.Size(75, 23);
            this.btnDelItmsLote.TabIndex = 17;
            this.btnDelItmsLote.Text = "Eliminar Sel.";
            this.btnDelItmsLote.UseVisualStyleBackColor = false;
            this.btnDelItmsLote.Click += new System.EventHandler(this.btnDelItmsLote_Click);
            // 
            // lvWinPwdGrupo
            // 
            this.lvWinPwdGrupo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvWinPwdGrupo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeader1,
            this.columnHeader6,
            this.columnHeader7,
            columnHeader2});
            this.lvWinPwdGrupo.FullRowSelect = true;
            this.lvWinPwdGrupo.HideSelection = false;
            this.lvWinPwdGrupo.Location = new System.Drawing.Point(6, 67);
            this.lvWinPwdGrupo.Name = "lvWinPwdGrupo";
            this.lvWinPwdGrupo.Size = new System.Drawing.Size(372, 354);
            this.lvWinPwdGrupo.TabIndex = 16;
            this.lvWinPwdGrupo.UseCompatibleStateImageBehavior = false;
            this.lvWinPwdGrupo.View = System.Windows.Forms.View.Details;
            this.lvWinPwdGrupo.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvWinPwdGrupo_ColumnClick);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Dominio";
            this.columnHeader6.Width = 88;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Equipo";
            this.columnHeader7.Width = 105;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnAddAllRoles);
            this.panel5.Controls.Add(this.btnAddRole);
            this.panel5.Controls.Add(this.lvWinPwdDB);
            this.panel5.Controls.Add(this.btnBuscar);
            this.panel5.Controls.Add(this.cbDominio);
            this.panel5.Controls.Add(this.lTitleDominio);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(431, 427);
            this.panel5.TabIndex = 0;
            // 
            // btnAddAllRoles
            // 
            this.btnAddAllRoles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddAllRoles.BackColor = System.Drawing.SystemColors.Control;
            this.btnAddAllRoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAllRoles.Location = new System.Drawing.Point(383, 221);
            this.btnAddAllRoles.Name = "btnAddAllRoles";
            this.btnAddAllRoles.Size = new System.Drawing.Size(42, 26);
            this.btnAddAllRoles.TabIndex = 17;
            this.btnAddAllRoles.Text = ">>";
            this.btnAddAllRoles.UseVisualStyleBackColor = false;
            this.btnAddAllRoles.Click += new System.EventHandler(this.btnAddAllRoles_Click);
            // 
            // btnAddRole
            // 
            this.btnAddRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddRole.BackColor = System.Drawing.SystemColors.Control;
            this.btnAddRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRole.Location = new System.Drawing.Point(383, 192);
            this.btnAddRole.Name = "btnAddRole";
            this.btnAddRole.Size = new System.Drawing.Size(42, 26);
            this.btnAddRole.TabIndex = 16;
            this.btnAddRole.Text = ">";
            this.btnAddRole.UseVisualStyleBackColor = false;
            this.btnAddRole.Click += new System.EventHandler(this.btnAddRole_Click);
            // 
            // lvWinPwdDB
            // 
            this.lvWinPwdDB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvWinPwdDB.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeader69,
            this.columnHeader3,
            this.columnHeader5,
            columnHeader4});
            this.lvWinPwdDB.FullRowSelect = true;
            this.lvWinPwdDB.HideSelection = false;
            this.lvWinPwdDB.Location = new System.Drawing.Point(6, 67);
            this.lvWinPwdDB.Name = "lvWinPwdDB";
            this.lvWinPwdDB.Size = new System.Drawing.Size(372, 354);
            this.lvWinPwdDB.TabIndex = 15;
            this.lvWinPwdDB.UseCompatibleStateImageBehavior = false;
            this.lvWinPwdDB.View = System.Windows.Forms.View.Details;
            this.lvWinPwdDB.DoubleClick += new System.EventHandler(this.lvWinPwdDB_DoubleClick);
            this.lvWinPwdDB.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvWinPwdDB_ColumnClick);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Dominio";
            this.columnHeader3.Width = 93;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Equipo";
            this.columnHeader5.Width = 99;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.SystemColors.Control;
            this.btnBuscar.Location = new System.Drawing.Point(6, 38);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 14;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cbDominio
            // 
            this.cbDominio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbDominio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDominio.FormattingEnabled = true;
            this.cbDominio.Location = new System.Drawing.Point(65, 11);
            this.cbDominio.Name = "cbDominio";
            this.cbDominio.Size = new System.Drawing.Size(320, 21);
            this.cbDominio.TabIndex = 10;
            // 
            // lTitleDominio
            // 
            this.lTitleDominio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lTitleDominio.AutoSize = true;
            this.lTitleDominio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTitleDominio.Location = new System.Drawing.Point(3, 14);
            this.lTitleDominio.Name = "lTitleDominio";
            this.lTitleDominio.Size = new System.Drawing.Size(56, 13);
            this.lTitleDominio.TabIndex = 13;
            this.lTitleDominio.Text = "Dominio:";
            // 
            // FABMLoteChkWinPwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(817, 536);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Name = "FABMLoteChkWinPwd";
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.panel4, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFechaProgramada;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox cbDominio;
        private System.Windows.Forms.Label lTitleDominio;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ListView lvWinPwdDB;
        private System.Windows.Forms.ListView lvWinPwdGrupo;
        private System.Windows.Forms.Button btnAddAllRoles;
        private System.Windows.Forms.Button btnAddRole;
        private System.Windows.Forms.Button btnDelItmsLote;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}
