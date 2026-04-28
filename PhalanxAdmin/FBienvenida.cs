using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PhalanxAdmin
{
    public partial class FBienvenida : FBase
    {
        public FBienvenida(//int PanelWidth, 
    int PanelHeight, int ClientSizeWidth, int ClientSizeHeight)
            : base(//PanelWidth, 
    PanelHeight, ClientSizeWidth, ClientSizeHeight)
        {

            InitializeComponent();
        }

        private void FBienvenida_Resize(object sender, EventArgs e)
        {
            CentrarImgPresent();

        }

        private void CentrarImgPresent()
        {
            picPresent.Top = Convert.ToInt32(Math.Floor(Convert.ToDouble((this.ClientRectangle.Height - picPresent.Height) / 2)));
            picPresent.Left = Convert.ToInt32(Math.Floor(Convert.ToDouble((this.ClientRectangle.Width - picPresent.Width) / 2)));

        }

    }
}