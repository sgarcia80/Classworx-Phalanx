namespace PhalanxAdmin
{
    partial class FBaseSistema
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
            this.lnkConfiguracion = new System.Windows.Forms.LinkLabel();
            this.lnkEdificios = new System.Windows.Forms.LinkLabel();
            this.lnkSuperv = new System.Windows.Forms.LinkLabel();
            this.lnkDominios = new System.Windows.Forms.LinkLabel();
            this.lnkAplicativosBPM = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pnlXPGrps)).BeginInit();
            this.pnlXPGrps.SuspendLayout();
            this.pnlIzq.SuspendLayout();
            this.xppnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlXPGrps
            // 
            this.pnlXPGrps.Size = new System.Drawing.Size(200, 484);
            // 
            // pnlIzq
            // 
            this.pnlIzq.Size = new System.Drawing.Size(200, 484);
            // 
            // xppnlMenu
            // 
            this.xppnlMenu.Caption = "Parametría";
            this.xppnlMenu.Controls.Add(this.lnkAplicativosBPM);
            this.xppnlMenu.Controls.Add(this.lnkDominios);
            this.xppnlMenu.Controls.Add(this.lnkSuperv);
            this.xppnlMenu.Controls.Add(this.lnkEdificios);
            this.xppnlMenu.Controls.Add(this.lnkConfiguracion);
            this.xppnlMenu.ImageItems.ImageSet = null;
            this.xppnlMenu.Size = new System.Drawing.Size(184, 164);
            this.xppnlMenu.TabIndex = 2;
            // 
            // lnkConfiguracion
            // 
            this.lnkConfiguracion.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkConfiguracion.AutoSize = true;
            this.lnkConfiguracion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkConfiguracion.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkConfiguracion.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkConfiguracion.Location = new System.Drawing.Point(18, 45);
            this.lnkConfiguracion.Name = "lnkConfiguracion";
            this.lnkConfiguracion.Size = new System.Drawing.Size(85, 13);
            this.lnkConfiguracion.TabIndex = 5;
            this.lnkConfiguracion.TabStop = true;
            this.lnkConfiguracion.Text = "Configuración";
            this.lnkConfiguracion.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkConfiguracion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkConfiguracion_LinkClicked);
            // 
            // lnkEdificios
            // 
            this.lnkEdificios.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkEdificios.AutoSize = true;
            this.lnkEdificios.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkEdificios.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkEdificios.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkEdificios.Location = new System.Drawing.Point(18, 66);
            this.lnkEdificios.Name = "lnkEdificios";
            this.lnkEdificios.Size = new System.Drawing.Size(55, 13);
            this.lnkEdificios.TabIndex = 7;
            this.lnkEdificios.TabStop = true;
            this.lnkEdificios.Text = "Edificios";
            this.lnkEdificios.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkEdificios.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkEdificios_LinkClicked);
            // 
            // lnkSuperv
            // 
            this.lnkSuperv.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkSuperv.AutoSize = true;
            this.lnkSuperv.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkSuperv.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkSuperv.Location = new System.Drawing.Point(18, 86);
            this.lnkSuperv.Name = "lnkSuperv";
            this.lnkSuperv.Size = new System.Drawing.Size(80, 13);
            this.lnkSuperv.TabIndex = 9;
            this.lnkSuperv.TabStop = true;
            this.lnkSuperv.Text = "Supervisores";
            this.lnkSuperv.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkSuperv.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSuperv_LinkClicked);
            // 
            // lnkDominios
            // 
            this.lnkDominios.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkDominios.AutoSize = true;
            this.lnkDominios.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkDominios.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkDominios.Location = new System.Drawing.Point(18, 109);
            this.lnkDominios.Name = "lnkDominios";
            this.lnkDominios.Size = new System.Drawing.Size(58, 13);
            this.lnkDominios.TabIndex = 12;
            this.lnkDominios.TabStop = true;
            this.lnkDominios.Text = "Dominios";
            this.lnkDominios.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkDominios.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDominios_LinkClicked);
            // 
            // lnkAplicativosBPM
            // 
            this.lnkAplicativosBPM.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkAplicativosBPM.AutoSize = true;
            this.lnkAplicativosBPM.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkAplicativosBPM.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkAplicativosBPM.Location = new System.Drawing.Point(18, 132);
            this.lnkAplicativosBPM.Name = "lnkAplicativosBPM";
            this.lnkAplicativosBPM.Size = new System.Drawing.Size(99, 13);
            this.lnkAplicativosBPM.TabIndex = 13;
            this.lnkAplicativosBPM.TabStop = true;
            this.lnkAplicativosBPM.Text = "Aplicativos BPM";
            this.lnkAplicativosBPM.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkAplicativosBPM.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAplicativosBPM_LinkClicked);
            // 
            // FBaseSistema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(665, 484);
            this.Name = "FBaseSistema";
            this.Load += new System.EventHandler(this.FBaseSistema_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlXPGrps)).EndInit();
            this.pnlXPGrps.ResumeLayout(false);
            this.pnlIzq.ResumeLayout(false);
            this.xppnlMenu.ResumeLayout(false);
            this.xppnlMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnkConfiguracion;
        private System.Windows.Forms.LinkLabel lnkEdificios;
        private System.Windows.Forms.LinkLabel lnkSuperv;
        private System.Windows.Forms.LinkLabel lnkDominios;
        private System.Windows.Forms.LinkLabel lnkAplicativosBPM;
    }
}
