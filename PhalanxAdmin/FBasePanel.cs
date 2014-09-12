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
    }
}

