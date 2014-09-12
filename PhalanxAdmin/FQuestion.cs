
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PhalanxAdmin
{
    public partial class FQuestion : PhalanxAdmin.FModalBase
    {
        public FQuestion()
        {
            InitializeComponent();
        }

        public string Question
        {
            set { lQuestion.Text = value; }
        }
    }
}

