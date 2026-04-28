using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PhalanxAdmin
{
    public partial class FBasePanel : PhalanxAdmin.FBase
    {
        public FBasePanel()
        { 
            InitializeComponent();
        }

        private void FBasePanel_Load(object sender, EventArgs e)
        {
            // reordeno la posición del menu porque sino primero dibuja el menu de los hijos
            pnlXPGrps.MovePanel(0, xppnlMenu);

        }

        public string GetTitlePath(string parent, string child)
        {
            string path = parent;

            if (string.IsNullOrEmpty(parent.Trim()))
            {
                path = child;
            }
            else
            {
                path = string.Format("{0} / {1}", parent, child);
            }

            return path;
        }
    }
}

