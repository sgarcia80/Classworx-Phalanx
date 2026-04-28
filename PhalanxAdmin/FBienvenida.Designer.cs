namespace PhalanxAdmin
{
    partial class FBienvenida
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FBienvenida));
            this.picPresent = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picPresent)).BeginInit();
            this.SuspendLayout();
            // 
            // picPresent
            // 
            this.picPresent.Image = ((System.Drawing.Image)(resources.GetObject("picPresent.Image")));
            this.picPresent.Location = new System.Drawing.Point(16, 60);
            this.picPresent.Name = "picPresent";
            this.picPresent.Size = new System.Drawing.Size(668, 256);
            this.picPresent.TabIndex = 0;
            this.picPresent.TabStop = false;
            // 
            // FBienvenida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(688, 358);
            this.Controls.Add(this.picPresent);
            this.Name = "FBienvenida";
            this.Resize += new System.EventHandler(this.FBienvenida_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picPresent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picPresent;
    }
}