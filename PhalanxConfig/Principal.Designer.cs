namespace PhalanxConfig
{
    partial class Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.bGenerarConexion = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tipo = new System.Windows.Forms.GroupBox();
            this.radioButtonWeb = new System.Windows.Forms.RadioButton();
            this.radioButtonAdmin = new System.Windows.Forms.RadioButton();
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
            this.button1 = new System.Windows.Forms.Button();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tBUsuario = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tBDominio = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtDescencTxt = new System.Windows.Forms.TextBox();
            this.btnDesencriptar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEncTxt = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bSalir = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tipo.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(477, 283);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.bGenerarConexion);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.tipo);
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
            this.tabPage1.Size = new System.Drawing.Size(469, 257);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Conexión Base de Datos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // bGenerarConexion
            // 
            this.bGenerarConexion.Location = new System.Drawing.Point(91, 184);
            this.bGenerarConexion.Name = "bGenerarConexion";
            this.bGenerarConexion.Size = new System.Drawing.Size(130, 23);
            this.bGenerarConexion.TabIndex = 12;
            this.bGenerarConexion.Text = "Copiar al Portapapeles";
            this.bGenerarConexion.UseVisualStyleBackColor = true;
            this.bGenerarConexion.Click += new System.EventHandler(this.bGenerarConexion_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(310, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "(nombre de servidor)[, puerto]";
            // 
            // tipo
            // 
            this.tipo.Controls.Add(this.radioButtonWeb);
            this.tipo.Controls.Add(this.radioButtonAdmin);
            this.tipo.Location = new System.Drawing.Point(11, 6);
            this.tipo.Name = "tipo";
            this.tipo.Size = new System.Drawing.Size(292, 44);
            this.tipo.TabIndex = 10;
            this.tipo.TabStop = false;
            this.tipo.Text = "Tipo de Aplicación a Configurar";
            this.tipo.Visible = false;
            // 
            // radioButtonWeb
            // 
            this.radioButtonWeb.AutoSize = true;
            this.radioButtonWeb.Location = new System.Drawing.Point(156, 19);
            this.radioButtonWeb.Name = "radioButtonWeb";
            this.radioButtonWeb.Size = new System.Drawing.Size(118, 17);
            this.radioButtonWeb.TabIndex = 10;
            this.radioButtonWeb.Text = "Phalanx Web Client";
            this.radioButtonWeb.UseVisualStyleBackColor = true;
            // 
            // radioButtonAdmin
            // 
            this.radioButtonAdmin.AutoSize = true;
            this.radioButtonAdmin.Checked = true;
            this.radioButtonAdmin.Location = new System.Drawing.Point(6, 19);
            this.radioButtonAdmin.Name = "radioButtonAdmin";
            this.radioButtonAdmin.Size = new System.Drawing.Size(95, 17);
            this.radioButtonAdmin.TabIndex = 9;
            this.radioButtonAdmin.TabStop = true;
            this.radioButtonAdmin.Text = "Phalanx Admin";
            this.radioButtonAdmin.UseVisualStyleBackColor = true;
            // 
            // bGuardarConexion
            // 
            this.bGuardarConexion.Location = new System.Drawing.Point(227, 184);
            this.bGuardarConexion.Name = "bGuardarConexion";
            this.bGuardarConexion.Size = new System.Drawing.Size(75, 23);
            this.bGuardarConexion.TabIndex = 8;
            this.bGuardarConexion.Text = "Guardar";
            this.bGuardarConexion.UseVisualStyleBackColor = true;
            this.bGuardarConexion.Visible = false;
            this.bGuardarConexion.Click += new System.EventHandler(this.bGuardarConexion_Click);
            // 
            // tBPassword
            // 
            this.tBPassword.Location = new System.Drawing.Point(91, 147);
            this.tBPassword.Name = "tBPassword";
            this.tBPassword.Size = new System.Drawing.Size(212, 20);
            this.tBPassword.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Password";
            // 
            // tBUser
            // 
            this.tBUser.Location = new System.Drawing.Point(91, 120);
            this.tBUser.Name = "tBUser";
            this.tBUser.Size = new System.Drawing.Size(212, 20);
            this.tBUser.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Usuario";
            // 
            // tBBase
            // 
            this.tBBase.Location = new System.Drawing.Point(91, 93);
            this.tBBase.Name = "tBBase";
            this.tBBase.Size = new System.Drawing.Size(212, 20);
            this.tBBase.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Base de Datos";
            // 
            // tBServer
            // 
            this.tBServer.Location = new System.Drawing.Point(91, 66);
            this.tBServer.Name = "tBServer";
            this.tBServer.Size = new System.Drawing.Size(212, 20);
            this.tBServer.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.tbPass);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.tBUsuario);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.tBDominio);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(469, 257);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Inteface BPM";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(100, 115);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "Copiar al Portapapeles";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(100, 78);
            this.tbPass.Name = "tbPass";
            this.tbPass.Size = new System.Drawing.Size(212, 20);
            this.tbPass.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Password";
            // 
            // tBUsuario
            // 
            this.tBUsuario.Location = new System.Drawing.Point(100, 51);
            this.tBUsuario.Name = "tBUsuario";
            this.tBUsuario.Size = new System.Drawing.Size(212, 20);
            this.tBUsuario.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Usuario";
            // 
            // tBDominio
            // 
            this.tBDominio.Location = new System.Drawing.Point(100, 24);
            this.tBDominio.Name = "tBDominio";
            this.tBDominio.Size = new System.Drawing.Size(212, 20);
            this.tBDominio.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Dominio";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtDescencTxt);
            this.tabPage3.Controls.Add(this.btnDesencriptar);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.txtEncTxt);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(469, 257);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Desencriptador";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtDescencTxt
            // 
            this.txtDescencTxt.BackColor = System.Drawing.Color.White;
            this.txtDescencTxt.Location = new System.Drawing.Point(19, 129);
            this.txtDescencTxt.Multiline = true;
            this.txtDescencTxt.Name = "txtDescencTxt";
            this.txtDescencTxt.ReadOnly = true;
            this.txtDescencTxt.Size = new System.Drawing.Size(426, 79);
            this.txtDescencTxt.TabIndex = 3;
            // 
            // btnDesencriptar
            // 
            this.btnDesencriptar.Location = new System.Drawing.Point(19, 97);
            this.btnDesencriptar.Name = "btnDesencriptar";
            this.btnDesencriptar.Size = new System.Drawing.Size(75, 23);
            this.btnDesencriptar.TabIndex = 2;
            this.btnDesencriptar.Text = "Desencriptar";
            this.btnDesencriptar.UseVisualStyleBackColor = true;
            this.btnDesencriptar.Click += new System.EventHandler(this.btnDesencriptar_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Texto encriptado";
            // 
            // txtEncTxt
            // 
            this.txtEncTxt.Location = new System.Drawing.Point(19, 27);
            this.txtEncTxt.Multiline = true;
            this.txtEncTxt.Name = "txtEncTxt";
            this.txtEncTxt.Size = new System.Drawing.Size(426, 62);
            this.txtEncTxt.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bSalir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 244);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(477, 39);
            this.panel1.TabIndex = 1;
            // 
            // bSalir
            // 
            this.bSalir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.bSalir.Location = new System.Drawing.Point(391, 9);
            this.bSalir.Name = "bSalir";
            this.bSalir.Size = new System.Drawing.Size(75, 23);
            this.bSalir.TabIndex = 0;
            this.bSalir.Text = "Salir";
            this.bSalir.UseVisualStyleBackColor = true;
            this.bSalir.Click += new System.EventHandler(this.button1_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 283);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Principal";
            this.Text = "Phalanx Config";
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tipo.ResumeLayout(false);
            this.tipo.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bSalir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tBBase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tBServer;
        private System.Windows.Forms.TextBox tBPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bGuardarConexion;
        private System.Windows.Forms.GroupBox tipo;
        private System.Windows.Forms.RadioButton radioButtonWeb;
        private System.Windows.Forms.RadioButton radioButtonAdmin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bGenerarConexion;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tBUsuario;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tBDominio;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtEncTxt;
        private System.Windows.Forms.TextBox txtDescencTxt;
        private System.Windows.Forms.Button btnDesencriptar;
        private System.Windows.Forms.Label label9;
    }
}

