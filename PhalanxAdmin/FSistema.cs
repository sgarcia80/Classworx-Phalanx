using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PhalanxAdmin
{
    public partial class FSistema : PhalanxAdmin.FBaseSistema
    {
        public FSistema()
        {
            InitializeComponent();
        }
        public override string Id
        {
            get
            {
                return "Sistema";
            }
        }

        private void FSistema_Load(object sender, EventArgs e)
        {

        }
    }
}

