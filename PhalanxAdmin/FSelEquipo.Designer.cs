namespace PhalanxAdmin
{
    partial class FSelEquipo
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
            System.Windows.Forms.ColumnHeader columnHeader1;
            this.rbWin = new System.Windows.Forms.RadioButton();
            this.rbUnix = new System.Windows.Forms.RadioButton();
            this.rbAS400 = new System.Windows.Forms.RadioButton();
            columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvLista
            // 
            this.lvLista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeader1});
            this.lvLista.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbAS400);
            this.groupBox2.Controls.Add(this.rbUnix);
            this.groupBox2.Controls.Add(this.rbWin);
            this.groupBox2.Controls.SetChildIndex(this.rbWin, 0);
            this.groupBox2.Controls.SetChildIndex(this.label2, 0);
            this.groupBox2.Controls.SetChildIndex(this.txtFilNombre, 0);
            this.groupBox2.Controls.SetChildIndex(this.btnBuscar, 0);
            this.groupBox2.Controls.SetChildIndex(this.btnLimpiar, 0);
            this.groupBox2.Controls.SetChildIndex(this.rbUnix, 0);
            this.groupBox2.Controls.SetChildIndex(this.rbAS400, 0);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.TabIndex = 4;
            // 
            // btnBuscar
            // 
            this.btnBuscar.TabIndex = 5;
            // 
            // txtFilNombre
            // 
            this.txtFilNombre.TabIndex = 0;
            // 
            // btnAceptar
            // 
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Equipo";
            columnHeader1.Width = 190;
            // 
            // rbWin
            // 
            this.rbWin.AutoSize = true;
            this.rbWin.Checked = true;
            this.rbWin.Location = new System.Drawing.Point(14, 50);
            this.rbWin.Name = "rbWin";
            this.rbWin.Size = new System.Drawing.Size(69, 17);
            this.rbWin.TabIndex = 1;
            this.rbWin.TabStop = true;
            this.rbWin.Text = "Windows";
            this.rbWin.UseVisualStyleBackColor = true;
            // 
            // rbUnix
            // 
            this.rbUnix.AutoSize = true;
            this.rbUnix.Location = new System.Drawing.Point(89, 50);
            this.rbUnix.Name = "rbUnix";
            this.rbUnix.Size = new System.Drawing.Size(46, 17);
            this.rbUnix.TabIndex = 2;
            this.rbUnix.Text = "Unix";
            this.rbUnix.UseVisualStyleBackColor = true;
            // 
            // rbAS400
            // 
            this.rbAS400.AutoSize = true;
            this.rbAS400.Location = new System.Drawing.Point(141, 50);
            this.rbAS400.Name = "rbAS400";
            this.rbAS400.Size = new System.Drawing.Size(57, 17);
            this.rbAS400.TabIndex = 3;
            this.rbAS400.Text = "AS400";
            this.rbAS400.UseVisualStyleBackColor = true;
            // 
            // FSelEquipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 440);
            this.Name = "FSelEquipo";
            this.Text = "Seleccione un equipo...";
            this.Load += new System.EventHandler(this.FSelEquipo_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbWin;
        private System.Windows.Forms.RadioButton rbUnix;
        private System.Windows.Forms.RadioButton rbAS400;
    }
}