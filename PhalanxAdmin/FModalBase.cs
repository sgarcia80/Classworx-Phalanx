using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PhalanxAdmin
{
    public partial class FModalBase : Form
    {

        private int XPos = 0;
        private int YPos = 0;
        public FModalBase()
        {
            InitializeComponent();
            lInfo.Text = "";
        }

        public string Title
        {
            set { lTitle.Text = value; }
            
        }

        public string Info
        {
            set { lInfo.Text = value; }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point p = new Point(this.Location.X + (e.X - this.XPos), this.Location.Y + (e.Y - this.YPos));
                this.Location = p;
            }
        }

        private void lTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point p = new Point(this.Location.X + (e.X - this.XPos), this.Location.Y + (e.Y - this.YPos));
                this.Location = p;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            this.XPos = e.X;
            this.YPos = e.Y;
        }

        private void lTitle_MouseDown(object sender, MouseEventArgs e)
        {
            this.XPos = e.X;
            this.YPos = e.Y;
        }

    }
}