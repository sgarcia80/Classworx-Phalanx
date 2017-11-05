namespace PhalanxAdmin
{
    partial class FSelMacroError
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FSelMacroError));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.lblFolioNro = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbError = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 68);
            this.groupBox1.Size = new System.Drawing.Size(538, 43);
            this.groupBox1.TabIndex = 16;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Active.jpg");
            this.imageList.Images.SetKeyName(1, "Desactivo.jpg");
            // 
            // lblFolioNro
            // 
            this.lblFolioNro.AutoSize = true;
            this.lblFolioNro.Location = new System.Drawing.Point(92, 198);
            this.lblFolioNro.Name = "lblFolioNro";
            this.lblFolioNro.Size = new System.Drawing.Size(0, 13);
            this.lblFolioNro.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Error";
            // 
            // cbError
            // 
            this.cbError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbError.DisplayMember = "Descripcion";
            this.cbError.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbError.FormattingEnabled = true;
            this.cbError.Location = new System.Drawing.Point(67, 30);
            this.cbError.Name = "cbError";
            this.cbError.Size = new System.Drawing.Size(447, 21);
            this.cbError.Sorted = true;
            this.cbError.TabIndex = 17;
            this.cbError.ValueMember = "Id";
            // 
            // FSelMacroError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(538, 111);
            this.Controls.Add(this.cbError);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblFolioNro);
            this.Name = "FSelMacroError";
            this.Load += new System.EventHandler(this.FSelMacroError_Load);
            this.Controls.SetChildIndex(this.lblFolioNro, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.cbError, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList;
        protected System.Windows.Forms.Label lblFolioNro;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbError;


    }
}
