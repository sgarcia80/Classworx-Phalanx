namespace PhalanxAdmin
{
    partial class FBaseAdmin
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
            this.lnkBD = new System.Windows.Forms.LinkLabel();
            this.lnkAplicativos = new System.Windows.Forms.LinkLabel();
            this.lnkEqUnix = new System.Windows.Forms.LinkLabel();
            this.lnkEqAS400 = new System.Windows.Forms.LinkLabel();
            this.lnkEqWin = new System.Windows.Forms.LinkLabel();
            this.lnkUsuarios = new System.Windows.Forms.LinkLabel();
            this.lnkGrpsSol = new System.Windows.Forms.LinkLabel();
            this.lnkGrpsSeguimSol = new System.Windows.Forms.LinkLabel();
            this.linkEqCom = new System.Windows.Forms.LinkLabel();
            this.lnkPerfiles = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pnlXPGrps)).BeginInit();
            this.pnlXPGrps.SuspendLayout();
            this.pnlIzq.SuspendLayout();
            this.xppnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlXPGrps
            // 
            this.pnlXPGrps.Size = new System.Drawing.Size(200, 469);
            // 
            // pnlIzq
            // 
            this.pnlIzq.Size = new System.Drawing.Size(200, 469);
            // 
            // xppnlMenu
            // 
            this.xppnlMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.xppnlMenu.Caption = "Administración";
            this.xppnlMenu.Controls.Add(this.lnkPerfiles);
            this.xppnlMenu.Controls.Add(this.linkEqCom);
            this.xppnlMenu.Controls.Add(this.lnkGrpsSeguimSol);
            this.xppnlMenu.Controls.Add(this.lnkGrpsSol);
            this.xppnlMenu.Controls.Add(this.lnkUsuarios);
            this.xppnlMenu.Controls.Add(this.lnkEqWin);
            this.xppnlMenu.Controls.Add(this.lnkEqAS400);
            this.xppnlMenu.Controls.Add(this.lnkEqUnix);
            this.xppnlMenu.Controls.Add(this.lnkAplicativos);
            this.xppnlMenu.Controls.Add(this.lnkBD);
            this.xppnlMenu.ImageItems.ImageSet = null;
            this.xppnlMenu.Size = new System.Drawing.Size(184, 278);
            // 
            // lnkBD
            // 
            this.lnkBD.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkBD.AutoSize = true;
            this.lnkBD.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkBD.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkBD.Location = new System.Drawing.Point(18, 108);
            this.lnkBD.Name = "lnkBD";
            this.lnkBD.Size = new System.Drawing.Size(96, 13);
            this.lnkBD.TabIndex = 4;
            this.lnkBD.TabStop = true;
            this.lnkBD.Text = "Bases de Datos";
            this.lnkBD.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkBD.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkBD_LinkClicked);
            // 
            // lnkAplicativos
            // 
            this.lnkAplicativos.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkAplicativos.AutoSize = true;
            this.lnkAplicativos.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkAplicativos.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkAplicativos.Location = new System.Drawing.Point(18, 129);
            this.lnkAplicativos.Name = "lnkAplicativos";
            this.lnkAplicativos.Size = new System.Drawing.Size(69, 13);
            this.lnkAplicativos.TabIndex = 5;
            this.lnkAplicativos.TabStop = true;
            this.lnkAplicativos.Text = "Aplicativos";
            this.lnkAplicativos.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkAplicativos.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAplicativos_LinkClicked);
            // 
            // lnkEqUnix
            // 
            this.lnkEqUnix.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkEqUnix.AutoSize = true;
            this.lnkEqUnix.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkEqUnix.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkEqUnix.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkEqUnix.Location = new System.Drawing.Point(18, 66);
            this.lnkEqUnix.Name = "lnkEqUnix";
            this.lnkEqUnix.Size = new System.Drawing.Size(81, 13);
            this.lnkEqUnix.TabIndex = 2;
            this.lnkEqUnix.TabStop = true;
            this.lnkEqUnix.Text = "Equipos Unix";
            this.lnkEqUnix.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkEqUnix.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkEqUnix_LinkClicked);
            // 
            // lnkEqAS400
            // 
            this.lnkEqAS400.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkEqAS400.AutoSize = true;
            this.lnkEqAS400.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkEqAS400.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkEqAS400.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkEqAS400.Location = new System.Drawing.Point(18, 87);
            this.lnkEqAS400.Name = "lnkEqAS400";
            this.lnkEqAS400.Size = new System.Drawing.Size(93, 13);
            this.lnkEqAS400.TabIndex = 3;
            this.lnkEqAS400.TabStop = true;
            this.lnkEqAS400.Text = "Equipos AS400";
            this.lnkEqAS400.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkEqAS400.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkEqAS400_LinkClicked);
            // 
            // lnkEqWin
            // 
            this.lnkEqWin.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkEqWin.AutoSize = true;
            this.lnkEqWin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkEqWin.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkEqWin.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkEqWin.Location = new System.Drawing.Point(18, 45);
            this.lnkEqWin.Name = "lnkEqWin";
            this.lnkEqWin.Size = new System.Drawing.Size(107, 13);
            this.lnkEqWin.TabIndex = 1;
            this.lnkEqWin.TabStop = true;
            this.lnkEqWin.Text = "Equipos Windows";
            this.lnkEqWin.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkEqWin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkEqWin_LinkClicked);
            // 
            // lnkUsuarios
            // 
            this.lnkUsuarios.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkUsuarios.AutoSize = true;
            this.lnkUsuarios.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkUsuarios.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkUsuarios.Location = new System.Drawing.Point(18, 173);
            this.lnkUsuarios.Name = "lnkUsuarios";
            this.lnkUsuarios.Size = new System.Drawing.Size(56, 13);
            this.lnkUsuarios.TabIndex = 7;
            this.lnkUsuarios.TabStop = true;
            this.lnkUsuarios.Text = "Usuarios";
            this.lnkUsuarios.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkUsuarios.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkUsuarios_LinkClicked);
            // 
            // lnkGrpsSol
            // 
            this.lnkGrpsSol.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkGrpsSol.AutoSize = true;
            this.lnkGrpsSol.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkGrpsSol.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkGrpsSol.Location = new System.Drawing.Point(18, 195);
            this.lnkGrpsSol.Name = "lnkGrpsSol";
            this.lnkGrpsSol.Size = new System.Drawing.Size(131, 13);
            this.lnkGrpsSol.TabIndex = 9;
            this.lnkGrpsSol.TabStop = true;
            this.lnkGrpsSol.Text = "Grupos de Solicitudes";
            this.lnkGrpsSol.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkGrpsSol.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkGrpsSol_LinkClicked);
            // 
            // lnkGrpsSeguimSol
            // 
            this.lnkGrpsSeguimSol.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkGrpsSeguimSol.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkGrpsSeguimSol.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkGrpsSeguimSol.Location = new System.Drawing.Point(18, 217);
            this.lnkGrpsSeguimSol.Name = "lnkGrpsSeguimSol";
            this.lnkGrpsSeguimSol.Size = new System.Drawing.Size(161, 31);
            this.lnkGrpsSeguimSol.TabIndex = 10;
            this.lnkGrpsSeguimSol.TabStop = true;
            this.lnkGrpsSeguimSol.Text = "Grupos de Seguimientos de Solicitudes";
            this.lnkGrpsSeguimSol.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkGrpsSeguimSol.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkGrpsSeguimSol_LinkClicked);
            // 
            // linkEqCom
            // 
            this.linkEqCom.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.linkEqCom.AutoSize = true;
            this.linkEqCom.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkEqCom.LinkColor = System.Drawing.Color.MidnightBlue;
            this.linkEqCom.Location = new System.Drawing.Point(18, 151);
            this.linkEqCom.Name = "linkEqCom";
            this.linkEqCom.Size = new System.Drawing.Size(152, 13);
            this.linkEqCom.TabIndex = 11;
            this.linkEqCom.TabStop = true;
            this.linkEqCom.Text = "Equipos de comunicación";
            this.linkEqCom.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.linkEqCom.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkEqCom_LinkClicked);
            // 
            // lnkPerfiles
            // 
            this.lnkPerfiles.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkPerfiles.AutoSize = true;
            this.lnkPerfiles.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkPerfiles.LinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkPerfiles.Location = new System.Drawing.Point(18, 248);
            this.lnkPerfiles.Name = "lnkPerfiles";
            this.lnkPerfiles.Size = new System.Drawing.Size(49, 13);
            this.lnkPerfiles.TabIndex = 12;
            this.lnkPerfiles.TabStop = true;
            this.lnkPerfiles.Text = "Perfiles";
            this.lnkPerfiles.VisitedLinkColor = System.Drawing.Color.MidnightBlue;
            this.lnkPerfiles.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPerfiles_LinkClicked);
            // 
            // FBaseAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(657, 469);
            this.Name = "FBaseAdmin";
            this.Load += new System.EventHandler(this.FBaseAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlXPGrps)).EndInit();
            this.pnlXPGrps.ResumeLayout(false);
            this.pnlIzq.ResumeLayout(false);
            this.xppnlMenu.ResumeLayout(false);
            this.xppnlMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnkBD;
        private System.Windows.Forms.LinkLabel lnkAplicativos;
        private System.Windows.Forms.LinkLabel lnkEqWin;
        private System.Windows.Forms.LinkLabel lnkEqAS400;
        private System.Windows.Forms.LinkLabel lnkEqUnix;
        private System.Windows.Forms.LinkLabel lnkUsuarios;
        private System.Windows.Forms.LinkLabel lnkGrpsSol;
        private System.Windows.Forms.LinkLabel lnkGrpsSeguimSol;
        private System.Windows.Forms.LinkLabel linkEqCom;
        private System.Windows.Forms.LinkLabel lnkPerfiles;
    }
}
