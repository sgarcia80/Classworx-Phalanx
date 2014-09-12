namespace PhalanxAdmin
{
    partial class PrueFormSel
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
            this.txtPC = new System.Windows.Forms.TextBox();
            this.btnSel = new System.Windows.Forms.Button();
            this.cbDominio = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // txtPC
            // 
            this.txtPC.BackColor = System.Drawing.Color.White;
            this.txtPC.Location = new System.Drawing.Point(38, 73);
            this.txtPC.Name = "txtPC";
            this.txtPC.ReadOnly = true;
            this.txtPC.Size = new System.Drawing.Size(191, 20);
            this.txtPC.TabIndex = 0;
            // 
            // btnSel
            // 
            this.btnSel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSel.Location = new System.Drawing.Point(235, 72);
            this.btnSel.Name = "btnSel";
            this.btnSel.Size = new System.Drawing.Size(27, 23);
            this.btnSel.TabIndex = 1;
            this.btnSel.Text = "...";
            this.btnSel.UseVisualStyleBackColor = true;
            this.btnSel.Click += new System.EventHandler(this.btnSel_Click);
            // 
            // cbDominio
            // 
            this.cbDominio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDominio.FormattingEnabled = true;
            this.cbDominio.Location = new System.Drawing.Point(77, 35);
            this.cbDominio.Name = "cbDominio";
            this.cbDominio.Size = new System.Drawing.Size(143, 21);
            this.cbDominio.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Dominio";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(106, 150);
            this.maskedTextBox1.Mask = "99999";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBox1.TabIndex = 18;
            this.maskedTextBox1.ValidatingType = typeof(int);
            // 
            // PrueFormSel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 458);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.cbDominio);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSel);
            this.Controls.Add(this.txtPC);
            this.Name = "PrueFormSel";
            this.Text = "PrueFormSel";
            this.Load += new System.EventHandler(this.PrueFormSel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPC;
        private System.Windows.Forms.Button btnSel;
        private System.Windows.Forms.ComboBox cbDominio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
    }
}