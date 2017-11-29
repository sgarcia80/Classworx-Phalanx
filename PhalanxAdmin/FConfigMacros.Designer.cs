namespace PhalanxAdmin
{
    partial class FConfigMacros
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
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbMacros = new System.Windows.Forms.ComboBox();
            this.labelDom = new System.Windows.Forms.Label();
            this.pnlList = new System.Windows.Forms.Panel();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnClave = new System.Windows.Forms.Button();
            this.btnUsuario = new System.Windows.Forms.Button();
            this.btnAdminClave2 = new System.Windows.Forms.Button();
            this.btnAdminClave1 = new System.Windows.Forms.Button();
            this.btnAdminUsuario2 = new System.Windows.Forms.Button();
            this.btnAdminUsuario1 = new System.Windows.Forms.Button();
            this.txtFooter = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBody = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHeader = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.xppnlMacros = new UIComponents.XPPanel(115);
            this.lnkDelete = new System.Windows.Forms.LinkLabel();
            this.lnkModify = new System.Windows.Forms.LinkLabel();
            this.lnkAdd = new System.Windows.Forms.LinkLabel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.xppnlTC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlXPGrps)).BeginInit();
            this.pnlXPGrps.SuspendLayout();
            this.pnlIzq.SuspendLayout();
            this.pnlFilters.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlList.SuspendLayout();
            this.xppnlMacros.SuspendLayout();
            this.SuspendLayout();
            // 
            // xppnlTC
            // 
            this.xppnlTC.ImageItems.ImageSet = null;
            this.xppnlTC.Location = new System.Drawing.Point(8, 342);
            // 
            // pnlXPGrps
            // 
            this.pnlXPGrps.Controls.Add(this.xppnlMacros);
            this.pnlXPGrps.Size = new System.Drawing.Size(200, 600);
            this.pnlXPGrps.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlXPGrps_Paint);
            this.pnlXPGrps.Controls.SetChildIndex(this.xppnlTC, 0);
            this.pnlXPGrps.Controls.SetChildIndex(this.xppnlMenu, 0);
            this.pnlXPGrps.Controls.SetChildIndex(this.xppnlMacros, 0);
            // 
            // pnlIzq
            // 
            this.pnlIzq.Size = new System.Drawing.Size(200, 600);
            // 
            // xppnlMenu
            // 
            this.xppnlMenu.ImageItems.ImageSet = null;
            this.xppnlMenu.Location = new System.Drawing.Point(8, 131);
            this.xppnlMenu.TabIndex = 1;
            // 
            // pnlFilters
            // 
            this.pnlFilters.Controls.Add(this.groupBox1);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Location = new System.Drawing.Point(200, 0);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(712, 77);
            this.pnlFilters.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.cbMacros);
            this.groupBox1.Controls.Add(this.labelDom);
            this.groupBox1.Location = new System.Drawing.Point(18, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(510, 64);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Macros Emuladores";
            // 
            // cbMacros
            // 
            this.cbMacros.DisplayMember = "Name";
            this.cbMacros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMacros.FormattingEnabled = true;
            this.cbMacros.Location = new System.Drawing.Point(100, 25);
            this.cbMacros.Name = "cbMacros";
            this.cbMacros.Size = new System.Drawing.Size(373, 21);
            this.cbMacros.TabIndex = 1;
            this.cbMacros.ValueMember = "Id";
            this.cbMacros.SelectedValueChanged += new System.EventHandler(this.cbParams_SelectedValueChanged);
            // 
            // labelDom
            // 
            this.labelDom.AutoSize = true;
            this.labelDom.Location = new System.Drawing.Point(17, 28);
            this.labelDom.Name = "labelDom";
            this.labelDom.Size = new System.Drawing.Size(42, 13);
            this.labelDom.TabIndex = 0;
            this.labelDom.Text = "Macros";
            // 
            // pnlList
            // 
            this.pnlList.Controls.Add(this.btnTest);
            this.pnlList.Controls.Add(this.btnClave);
            this.pnlList.Controls.Add(this.btnUsuario);
            this.pnlList.Controls.Add(this.btnAdminClave2);
            this.pnlList.Controls.Add(this.btnAdminClave1);
            this.pnlList.Controls.Add(this.btnAdminUsuario2);
            this.pnlList.Controls.Add(this.btnAdminUsuario1);
            this.pnlList.Controls.Add(this.txtFooter);
            this.pnlList.Controls.Add(this.label4);
            this.pnlList.Controls.Add(this.txtBody);
            this.pnlList.Controls.Add(this.label3);
            this.pnlList.Controls.Add(this.txtHeader);
            this.pnlList.Controls.Add(this.btnCancel);
            this.pnlList.Controls.Add(this.btnSave);
            this.pnlList.Controls.Add(this.label2);
            this.pnlList.Controls.Add(this.txtName);
            this.pnlList.Controls.Add(this.label1);
            this.pnlList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlList.Location = new System.Drawing.Point(200, 77);
            this.pnlList.Name = "pnlList";
            this.pnlList.Size = new System.Drawing.Size(712, 523);
            this.pnlList.TabIndex = 1;
            // 
            // btnTest
            // 
            this.btnTest.BackColor = System.Drawing.SystemColors.Control;
            this.btnTest.Location = new System.Drawing.Point(35, 493);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(95, 21);
            this.btnTest.TabIndex = 14;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnClave
            // 
            this.btnClave.Location = new System.Drawing.Point(494, 248);
            this.btnClave.Name = "btnClave";
            this.btnClave.Size = new System.Drawing.Size(91, 23);
            this.btnClave.TabIndex = 11;
            this.btnClave.Text = "Clave";
            this.btnClave.UseVisualStyleBackColor = true;
            this.btnClave.Click += new System.EventHandler(this.btnClave_Click);
            // 
            // btnUsuario
            // 
            this.btnUsuario.Location = new System.Drawing.Point(494, 219);
            this.btnUsuario.Name = "btnUsuario";
            this.btnUsuario.Size = new System.Drawing.Size(91, 23);
            this.btnUsuario.TabIndex = 10;
            this.btnUsuario.Text = "Usuario";
            this.btnUsuario.UseVisualStyleBackColor = true;
            this.btnUsuario.Click += new System.EventHandler(this.btnUsuario_Click);
            // 
            // btnAdminClave2
            // 
            this.btnAdminClave2.Location = new System.Drawing.Point(494, 174);
            this.btnAdminClave2.Name = "btnAdminClave2";
            this.btnAdminClave2.Size = new System.Drawing.Size(91, 23);
            this.btnAdminClave2.TabIndex = 7;
            this.btnAdminClave2.Text = "Clave Secundario";
            this.btnAdminClave2.UseVisualStyleBackColor = true;
            this.btnAdminClave2.Click += new System.EventHandler(this.btnAdminClave2_Click);
            // 
            // btnAdminClave1
            // 
            this.btnAdminClave1.Location = new System.Drawing.Point(494, 103);
            this.btnAdminClave1.Name = "btnAdminClave1";
            this.btnAdminClave1.Size = new System.Drawing.Size(91, 23);
            this.btnAdminClave1.TabIndex = 5;
            this.btnAdminClave1.Text = "Clave Principal";
            this.btnAdminClave1.UseVisualStyleBackColor = true;
            this.btnAdminClave1.Click += new System.EventHandler(this.btnAdminClave1_Click);
            // 
            // btnAdminUsuario2
            // 
            this.btnAdminUsuario2.Location = new System.Drawing.Point(494, 145);
            this.btnAdminUsuario2.Name = "btnAdminUsuario2";
            this.btnAdminUsuario2.Size = new System.Drawing.Size(91, 23);
            this.btnAdminUsuario2.TabIndex = 6;
            this.btnAdminUsuario2.Text = "Secundario";
            this.btnAdminUsuario2.UseVisualStyleBackColor = true;
            this.btnAdminUsuario2.Click += new System.EventHandler(this.btnAdminUsuario2_Click);
            // 
            // btnAdminUsuario1
            // 
            this.btnAdminUsuario1.Location = new System.Drawing.Point(494, 74);
            this.btnAdminUsuario1.Name = "btnAdminUsuario1";
            this.btnAdminUsuario1.Size = new System.Drawing.Size(91, 23);
            this.btnAdminUsuario1.TabIndex = 4;
            this.btnAdminUsuario1.Text = "Principal";
            this.btnAdminUsuario1.UseVisualStyleBackColor = true;
            this.btnAdminUsuario1.Click += new System.EventHandler(this.btnAdminUsuario1_Click);
            // 
            // txtFooter
            // 
            this.txtFooter.BackColor = System.Drawing.Color.White;
            this.txtFooter.Location = new System.Drawing.Point(35, 364);
            this.txtFooter.Multiline = true;
            this.txtFooter.Name = "txtFooter";
            this.txtFooter.ReadOnly = true;
            this.txtFooter.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtFooter.Size = new System.Drawing.Size(453, 123);
            this.txtFooter.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 348);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Footer";
            // 
            // txtBody
            // 
            this.txtBody.BackColor = System.Drawing.Color.White;
            this.txtBody.Location = new System.Drawing.Point(35, 219);
            this.txtBody.Multiline = true;
            this.txtBody.Name = "txtBody";
            this.txtBody.ReadOnly = true;
            this.txtBody.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBody.Size = new System.Drawing.Size(453, 123);
            this.txtBody.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Body";
            // 
            // txtHeader
            // 
            this.txtHeader.BackColor = System.Drawing.Color.White;
            this.txtHeader.Location = new System.Drawing.Point(35, 74);
            this.txtHeader.Multiline = true;
            this.txtHeader.Name = "txtHeader";
            this.txtHeader.ReadOnly = true;
            this.txtHeader.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHeader.Size = new System.Drawing.Size(453, 123);
            this.txtHeader.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancel.Location = new System.Drawing.Point(393, 490);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 21);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.Location = new System.Drawing.Point(292, 490);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 21);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Header";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.White;
            this.txtName.Location = new System.Drawing.Point(35, 32);
            this.txtName.MaxLength = 250;
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(453, 20);
            this.txtName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // xppnlMacros
            // 
            this.xppnlMacros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xppnlMacros.BackColor = System.Drawing.Color.Transparent;
            this.xppnlMacros.Caption = "Macros";
            this.xppnlMacros.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xppnlMacros.CaptionGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
            this.xppnlMacros.CaptionGradient.Start = System.Drawing.Color.White;
            this.xppnlMacros.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xppnlMacros.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xppnlMacros.Controls.Add(this.lnkDelete);
            this.xppnlMacros.Controls.Add(this.lnkModify);
            this.xppnlMacros.Controls.Add(this.lnkAdd);
            this.xppnlMacros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.xppnlMacros.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xppnlMacros.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xppnlMacros.ImageItems.ImageSet = null;
            this.xppnlMacros.Location = new System.Drawing.Point(8, 8);
            this.xppnlMacros.Name = "xppnlMacros";
            this.xppnlMacros.PanelGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.xppnlMacros.PanelGradient.Start = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.xppnlMacros.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xppnlMacros.Size = new System.Drawing.Size(184, 115);
            this.xppnlMacros.TabIndex = 0;
            this.xppnlMacros.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.xppnlMacros.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.xppnlMacros.VertAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lnkDelete
            // 
            this.lnkDelete.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkDelete.AutoSize = true;
            this.lnkDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.lnkDelete.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkDelete.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkDelete.Location = new System.Drawing.Point(17, 85);
            this.lnkDelete.Name = "lnkDelete";
            this.lnkDelete.Size = new System.Drawing.Size(51, 13);
            this.lnkDelete.TabIndex = 2;
            this.lnkDelete.TabStop = true;
            this.lnkDelete.Text = "Eliminar";
            this.lnkDelete.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkDelete.Click += new System.EventHandler(this.lnkDelete_Click);
            // 
            // lnkModify
            // 
            this.lnkModify.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkModify.AutoSize = true;
            this.lnkModify.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.lnkModify.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkModify.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkModify.Location = new System.Drawing.Point(17, 64);
            this.lnkModify.Name = "lnkModify";
            this.lnkModify.Size = new System.Drawing.Size(59, 13);
            this.lnkModify.TabIndex = 1;
            this.lnkModify.TabStop = true;
            this.lnkModify.Text = "Modificar";
            this.lnkModify.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkModify.Click += new System.EventHandler(this.lnkModify_Click);
            // 
            // lnkAdd
            // 
            this.lnkAdd.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkAdd.AutoSize = true;
            this.lnkAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.lnkAdd.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkAdd.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkAdd.Location = new System.Drawing.Point(17, 43);
            this.lnkAdd.Name = "lnkAdd";
            this.lnkAdd.Size = new System.Drawing.Size(51, 13);
            this.lnkAdd.TabIndex = 0;
            this.lnkAdd.TabStop = true;
            this.lnkAdd.Text = "Agregar";
            this.lnkAdd.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkAdd.Click += new System.EventHandler(this.lnkAdd_Click);
            // 
            // FConfigMacros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 600);
            this.Controls.Add(this.pnlList);
            this.Controls.Add(this.pnlFilters);
            this.Name = "FConfigMacros";
            this.Text = "FConfigMailsExpPwd";
            this.Load += new System.EventHandler(this.FConfigMailsExpPwd_Load);
            this.Controls.SetChildIndex(this.pnlIzq, 0);
            this.Controls.SetChildIndex(this.pnlFilters, 0);
            this.Controls.SetChildIndex(this.pnlList, 0);
            this.xppnlTC.ResumeLayout(false);
            this.xppnlTC.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlXPGrps)).EndInit();
            this.pnlXPGrps.ResumeLayout(false);
            this.pnlIzq.ResumeLayout(false);
            this.pnlFilters.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlList.ResumeLayout(false);
            this.pnlList.PerformLayout();
            this.xppnlMacros.ResumeLayout(false);
            this.xppnlMacros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFilters;
        protected System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbMacros;
        private System.Windows.Forms.Label labelDom;
        private System.Windows.Forms.Panel pnlList;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        protected System.Windows.Forms.Button btnCancel;
        protected System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtHeader;
        private System.Windows.Forms.TextBox txtFooter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBody;
        private System.Windows.Forms.Label label3;
        private UIComponents.XPPanel xppnlMacros;
        protected System.Windows.Forms.LinkLabel lnkDelete;
        protected System.Windows.Forms.LinkLabel lnkModify;
        private System.Windows.Forms.Button btnAdminClave2;
        private System.Windows.Forms.Button btnAdminClave1;
        private System.Windows.Forms.Button btnAdminUsuario2;
        private System.Windows.Forms.Button btnAdminUsuario1;
        private System.Windows.Forms.Button btnClave;
        private System.Windows.Forms.Button btnUsuario;
        protected System.Windows.Forms.LinkLabel lnkAdd;
        protected System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}