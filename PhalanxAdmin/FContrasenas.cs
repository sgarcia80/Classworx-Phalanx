using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PhalanxAdmin
{
    public partial class FContrasenas : PhalanxAdmin.FBaseContrasenas
    {
        public FContrasenas()
        {
            InitializeComponent();
        }
        public override string Id
        {
            get { return "Passwords"; }
        }
    }
}

