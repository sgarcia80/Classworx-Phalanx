namespace PhalanxAdmin
{
    partial class FAltaDominio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FAltaDominio));
            this.txtDomName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.labelComment = new System.Windows.Forms.Label();
            this.pNetFind = new System.Windows.Forms.PictureBox();
            this.toolTipNet = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pNetFind)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 164);
            this.groupBox1.Size = new System.Drawing.Size(414, 43);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtDomName
            // 
            this.txtDomName.Location = new System.Drawing.Point(15, 51);
            this.txtDomName.Name = "txtDomName";
            this.txtDomName.Size = new System.Drawing.Size(300, 20);
            this.txtDomName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nombre";
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(15, 92);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(300, 61);
            this.txtComment.TabIndex = 2;
            // 
            // labelComment
            // 
            this.labelComment.AutoSize = true;
            this.labelComment.Location = new System.Drawing.Point(12, 76);
            this.labelComment.Name = "labelComment";
            this.labelComment.Size = new System.Drawing.Size(60, 13);
            this.labelComment.TabIndex = 7;
            this.labelComment.Text = "Comentario";
            // 
            // pNetFind
            // 
            this.pNetFind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pNetFind.Image = ((System.Drawing.Image)(resources.GetObject("pNetFind.Image")));
            this.pNetFind.Location = new System.Drawing.Point(325, 49);
            this.pNetFind.Name = "pNetFind";
            this.pNetFind.Size = new System.Drawing.Size(25, 26);
            this.pNetFind.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pNetFind.TabIndex = 8;
            this.pNetFind.TabStop = false;
            this.toolTipNet.SetToolTip(this.pNetFind, "Buscar en la Red . . .");
            this.pNetFind.Click += new System.EventHandler(this.pNetFind_Click);
            // 
            // toolTipNet
            // 
            this.toolTipNet.AutomaticDelay = 1000;
            this.toolTipNet.ShowAlways = true;
            this.toolTipNet.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTipNet.ToolTipTitle = "Network";
            // 
            // FAltaDominio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(414, 207);
            this.Controls.Add(this.pNetFind);
            this.Controls.Add(this.labelComment);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.txtDomName);
            this.Controls.Add(this.label2);
            this.Name = "FAltaDominio";
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtDomName, 0);
            this.Controls.SetChildIndex(this.txtComment, 0);
            this.Controls.SetChildIndex(this.labelComment, 0);
            this.Controls.SetChildIndex(this.pNetFind, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pNetFind)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.TextBox txtDomName;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.TextBox txtComment;
        protected System.Windows.Forms.Label labelComment;
        private System.Windows.Forms.PictureBox pNetFind;
        private System.Windows.Forms.ToolTip toolTipNet;
    }
}
