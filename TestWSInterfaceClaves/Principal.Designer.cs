namespace TestWSInterfaceClaves
{
    partial class Principal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviciosMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.bpmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notificacionAltaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conectoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conectorUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conectorConsultaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.serviciosMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(869, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator5,
            this.exitToolStripMenuItem});
            this.fileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(60, 20);
            this.fileMenu.Text = "&Archivo";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(93, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.exitToolStripMenuItem.Text = "&Salir";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolsStripMenuItem_Click);
            // 
            // serviciosMenu
            // 
            this.serviciosMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bpmToolStripMenuItem,
            this.conectoresToolStripMenuItem,
            this.toolStripSeparator6});
            this.serviciosMenu.Name = "serviciosMenu";
            this.serviciosMenu.Size = new System.Drawing.Size(65, 20);
            this.serviciosMenu.Text = "&Servicios";
            // 
            // bpmToolStripMenuItem
            // 
            this.bpmToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.notificacionAltaToolStripMenuItem});
            this.bpmToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.bpmToolStripMenuItem.Name = "bpmToolStripMenuItem";
            this.bpmToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.bpmToolStripMenuItem.ShowShortcutKeys = false;
            this.bpmToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.bpmToolStripMenuItem.Text = "&BPM";
            // 
            // notificacionAltaToolStripMenuItem
            // 
            this.notificacionAltaToolStripMenuItem.Name = "notificacionAltaToolStripMenuItem";
            this.notificacionAltaToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.notificacionAltaToolStripMenuItem.Text = "Notificacion Alta";
            this.notificacionAltaToolStripMenuItem.Click += new System.EventHandler(this.notificacionAltaToolStripMenuItem_Click);
            // 
            // conectoresToolStripMenuItem
            // 
            this.conectoresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conectorUsuarioToolStripMenuItem,
            this.conectorConsultaToolStripMenuItem});
            this.conectoresToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.conectoresToolStripMenuItem.Name = "conectoresToolStripMenuItem";
            this.conectoresToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.conectoresToolStripMenuItem.ShowShortcutKeys = false;
            this.conectoresToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.conectoresToolStripMenuItem.Text = "&Conectores";
            // 
            // conectorUsuarioToolStripMenuItem
            // 
            this.conectorUsuarioToolStripMenuItem.Name = "conectorUsuarioToolStripMenuItem";
            this.conectorUsuarioToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.conectorUsuarioToolStripMenuItem.Text = "Alta/Baja";
            this.conectorUsuarioToolStripMenuItem.Click += new System.EventHandler(this.conectorUsuarioToolStripMenuItem_Click);
            // 
            // conectorConsultaToolStripMenuItem
            // 
            this.conectorConsultaToolStripMenuItem.Name = "conectorConsultaToolStripMenuItem";
            this.conectorConsultaToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.conectorConsultaToolStripMenuItem.Text = "Consulta Roles/Grupos";
            this.conectorConsultaToolStripMenuItem.Click += new System.EventHandler(this.conectorConsultaToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(124, 6);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 490);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(869, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel.Text = "Estado";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 512);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Principal";
            this.Text = "Principal";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serviciosMenu;
        private System.Windows.Forms.ToolStripMenuItem bpmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conectoresToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem notificacionAltaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conectorUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conectorConsultaToolStripMenuItem;
    }
}



