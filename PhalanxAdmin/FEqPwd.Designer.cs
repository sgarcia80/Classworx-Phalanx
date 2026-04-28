namespace PhalanxAdmin
{
    partial class FEqPwd
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
            System.Windows.Forms.ColumnHeader columnHeader3;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FEqPwd));
            this.lvLista = new System.Windows.Forms.ListView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.lblAmbiente = new System.Windows.Forms.Label();
            this.lblContenedorPwds = new System.Windows.Forms.Label();
            this.pnlBotChk = new System.Windows.Forms.Panel();
            this.lnkDesmarcarTodo = new System.Windows.Forms.LinkLabel();
            this.lnkMarcarTodo = new System.Windows.Forms.LinkLabel();
            this.lblDescDesact = new System.Windows.Forms.Label();
            this.lblDescAct = new System.Windows.Forms.Label();
            columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.pnlBotChk.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 434);
            this.groupBox1.Size = new System.Drawing.Size(340, 43);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Usuario";
            columnHeader3.Width = 245;
            // 
            // lvLista
            // 
            this.lvLista.AllowColumnReorder = true;
            this.lvLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvLista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeader3});
            this.lvLista.FullRowSelect = true;
            this.lvLista.HideSelection = false;
            this.lvLista.Location = new System.Drawing.Point(29, 104);
            this.lvLista.MultiSelect = false;
            this.lvLista.Name = "lvLista";
            this.lvLista.Size = new System.Drawing.Size(282, 324);
            this.lvLista.SmallImageList = this.imageList;
            this.lvLista.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvLista.TabIndex = 4;
            this.lvLista.UseCompatibleStateImageBehavior = false;
            this.lvLista.View = System.Windows.Forms.View.Details;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Active.jpg");
            this.imageList.Images.SetKeyName(1, "Desactivo.jpg");
            // 
            // lblAmbiente
            // 
            this.lblAmbiente.AutoSize = true;
            this.lblAmbiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmbiente.Location = new System.Drawing.Point(13, 28);
            this.lblAmbiente.Name = "lblAmbiente";
            this.lblAmbiente.Size = new System.Drawing.Size(50, 13);
            this.lblAmbiente.TabIndex = 5;
            this.lblAmbiente.Text = "Equipo:";
            // 
            // lblContenedorPwds
            // 
            this.lblContenedorPwds.AutoSize = true;
            this.lblContenedorPwds.Location = new System.Drawing.Point(70, 28);
            this.lblContenedorPwds.Name = "lblContenedorPwds";
            this.lblContenedorPwds.Size = new System.Drawing.Size(35, 13);
            this.lblContenedorPwds.TabIndex = 6;
            this.lblContenedorPwds.Text = "label1";
            // 
            // pnlBotChk
            // 
            this.pnlBotChk.Controls.Add(this.lnkDesmarcarTodo);
            this.pnlBotChk.Controls.Add(this.lnkMarcarTodo);
            this.pnlBotChk.Location = new System.Drawing.Point(29, 79);
            this.pnlBotChk.Name = "pnlBotChk";
            this.pnlBotChk.Size = new System.Drawing.Size(281, 20);
            this.pnlBotChk.TabIndex = 7;
            // 
            // lnkDesmarcarTodo
            // 
            this.lnkDesmarcarTodo.AutoSize = true;
            this.lnkDesmarcarTodo.Location = new System.Drawing.Point(73, 4);
            this.lnkDesmarcarTodo.Name = "lnkDesmarcarTodo";
            this.lnkDesmarcarTodo.Size = new System.Drawing.Size(82, 13);
            this.lnkDesmarcarTodo.TabIndex = 1;
            this.lnkDesmarcarTodo.TabStop = true;
            this.lnkDesmarcarTodo.Text = "Desmarcar todo";
            this.lnkDesmarcarTodo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDesmarcarTodo_LinkClicked);
            // 
            // lnkMarcarTodo
            // 
            this.lnkMarcarTodo.AutoSize = true;
            this.lnkMarcarTodo.Location = new System.Drawing.Point(0, 4);
            this.lnkMarcarTodo.Name = "lnkMarcarTodo";
            this.lnkMarcarTodo.Size = new System.Drawing.Size(64, 13);
            this.lnkMarcarTodo.TabIndex = 0;
            this.lnkMarcarTodo.TabStop = true;
            this.lnkMarcarTodo.Text = "Marcar todo";
            this.lnkMarcarTodo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkMarcarTodo_LinkClicked);
            // 
            // lblDescDesact
            // 
            this.lblDescDesact.AutoSize = true;
            this.lblDescDesact.Location = new System.Drawing.Point(29, 53);
            this.lblDescDesact.Name = "lblDescDesact";
            this.lblDescDesact.Size = new System.Drawing.Size(257, 13);
            this.lblDescDesact.TabIndex = 8;
            this.lblDescDesact.Text = "Al desactivar, se desactivarán los siguientes usuarios";
            // 
            // lblDescAct
            // 
            this.lblDescAct.AutoSize = true;
            this.lblDescAct.Location = new System.Drawing.Point(29, 53);
            this.lblDescAct.Name = "lblDescAct";
            this.lblDescAct.Size = new System.Drawing.Size(163, 13);
            this.lblDescAct.TabIndex = 9;
            this.lblDescAct.Text = "Seleccione los usuarios a Activar";
            // 
            // FEqPwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(340, 477);
            this.Controls.Add(this.lblDescAct);
            this.Controls.Add(this.lblDescDesact);
            this.Controls.Add(this.lblContenedorPwds);
            this.Controls.Add(this.lblAmbiente);
            this.Controls.Add(this.pnlBotChk);
            this.Controls.Add(this.lvLista);
            this.Name = "FEqPwd";
            this.Load += new System.EventHandler(this.FEqPwd_Load);
            this.Controls.SetChildIndex(this.lvLista, 0);
            this.Controls.SetChildIndex(this.pnlBotChk, 0);
            this.Controls.SetChildIndex(this.lblAmbiente, 0);
            this.Controls.SetChildIndex(this.lblContenedorPwds, 0);
            this.Controls.SetChildIndex(this.lblDescDesact, 0);
            this.Controls.SetChildIndex(this.lblDescAct, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.pnlBotChk.ResumeLayout(false);
            this.pnlBotChk.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.ListView lvLista;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Label lblAmbiente;
        private System.Windows.Forms.Label lblContenedorPwds;
        private System.Windows.Forms.Panel pnlBotChk;
        private System.Windows.Forms.LinkLabel lnkMarcarTodo;
        private System.Windows.Forms.LinkLabel lnkDesmarcarTodo;
        private System.Windows.Forms.Label lblDescDesact;
        private System.Windows.Forms.Label lblDescAct;
    }
}
