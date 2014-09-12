namespace PhalanxAdmin
{
    partial class FConfiguracion
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSaveAuth1 = new System.Windows.Forms.Button();
            this.cbAuth1 = new System.Windows.Forms.ComboBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpMailExpPwd = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.bGuardarConexion = new System.Windows.Forms.Button();
            this.tBPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tBUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tBBase = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tBServer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.pnlXPGrps)).BeginInit();
            this.pnlXPGrps.SuspendLayout();
            this.pnlIzq.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlXPGrps
            // 
            this.pnlXPGrps.Size = new System.Drawing.Size(200, 519);
            // 
            // pnlIzq
            // 
            this.pnlIzq.Size = new System.Drawing.Size(200, 519);
            // 
            // xppnlMenu
            // 
            this.xppnlMenu.ImageItems.ImageSet = null;
            this.xppnlMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.xppnlMenu_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSaveAuth1);
            this.groupBox1.Controls.Add(this.cbAuth1);
            this.groupBox1.Location = new System.Drawing.Point(79, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(346, 117);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Usuario Autorizador de Solicitudes";
            // 
            // btnSaveAuth1
            // 
            this.btnSaveAuth1.BackColor = System.Drawing.SystemColors.Control;
            this.btnSaveAuth1.Enabled = false;
            this.btnSaveAuth1.Location = new System.Drawing.Point(123, 78);
            this.btnSaveAuth1.Name = "btnSaveAuth1";
            this.btnSaveAuth1.Size = new System.Drawing.Size(88, 23);
            this.btnSaveAuth1.TabIndex = 10;
            this.btnSaveAuth1.Text = "Guardar";
            this.btnSaveAuth1.UseVisualStyleBackColor = false;
            this.btnSaveAuth1.Click += new System.EventHandler(this.btnSaveAuth1_Click);
            // 
            // cbAuth1
            // 
            this.cbAuth1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAuth1.FormattingEnabled = true;
            this.cbAuth1.Location = new System.Drawing.Point(44, 39);
            this.cbAuth1.Name = "cbAuth1";
            this.cbAuth1.Size = new System.Drawing.Size(264, 21);
            this.cbAuth1.TabIndex = 9;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tpMailExpPwd);
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Location = new System.Drawing.Point(202, 1);
            this.tabControl.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(523, 518);
            this.tabControl.TabIndex = 3;
            this.tabControl.Visible = false;
            // 
            // tpMailExpPwd
            // 
            this.tpMailExpPwd.Location = new System.Drawing.Point(4, 22);
            this.tpMailExpPwd.Name = "tpMailExpPwd";
            this.tpMailExpPwd.Size = new System.Drawing.Size(515, 492);
            this.tpMailExpPwd.TabIndex = 2;
            this.tpMailExpPwd.Text = "Mails de Expiración de Contraseñas";
            this.tpMailExpPwd.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.bGuardarConexion);
            this.tabPage1.Controls.Add(this.tBPassword);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.tBUser);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.tBBase);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.tBServer);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(515, 492);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Base de Datos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // bGuardarConexion
            // 
            this.bGuardarConexion.Location = new System.Drawing.Point(246, 171);
            this.bGuardarConexion.Name = "bGuardarConexion";
            this.bGuardarConexion.Size = new System.Drawing.Size(75, 23);
            this.bGuardarConexion.TabIndex = 17;
            this.bGuardarConexion.Text = "Guardar";
            this.bGuardarConexion.UseVisualStyleBackColor = true;
            this.bGuardarConexion.Click += new System.EventHandler(this.bGuardarConexion_Click);
            // 
            // tBPassword
            // 
            this.tBPassword.Location = new System.Drawing.Point(110, 129);
            this.tBPassword.Name = "tBPassword";
            this.tBPassword.Size = new System.Drawing.Size(212, 20);
            this.tBPassword.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Password";
            // 
            // tBUser
            // 
            this.tBUser.Location = new System.Drawing.Point(110, 95);
            this.tBUser.Name = "tBUser";
            this.tBUser.Size = new System.Drawing.Size(212, 20);
            this.tBUser.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Usuario";
            // 
            // tBBase
            // 
            this.tBBase.Location = new System.Drawing.Point(110, 62);
            this.tBBase.Name = "tBBase";
            this.tBBase.Size = new System.Drawing.Size(212, 20);
            this.tBBase.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Base de Datos";
            // 
            // tBServer
            // 
            this.tBServer.Location = new System.Drawing.Point(110, 29);
            this.tBServer.Name = "tBServer";
            this.tBServer.Size = new System.Drawing.Size(212, 20);
            this.tBServer.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Server";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(515, 492);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Solicitudes";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // FConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(723, 519);
            this.Controls.Add(this.tabControl);
            this.Name = "FConfiguracion";
            this.Load += new System.EventHandler(this.FConfiguracion_Load);
            this.Controls.SetChildIndex(this.tabControl, 0);
            this.Controls.SetChildIndex(this.pnlIzq, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pnlXPGrps)).EndInit();
            this.pnlXPGrps.ResumeLayout(false);
            this.pnlIzq.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbAuth1;
        private System.Windows.Forms.Button btnSaveAuth1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button bGuardarConexion;
        private System.Windows.Forms.TextBox tBPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tBUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tBBase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tBServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tpMailExpPwd;
    }
}
