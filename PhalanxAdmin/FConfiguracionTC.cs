using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhalanxBL;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;

namespace PhalanxAdmin
{
    public partial class FConfiguracionTC : PhalanxAdmin.FBaseConfiguracionTC
    {
        public FConfiguracionTC()
        {
            InitializeComponent();
        }

        public override string Id
        {
            get
            {
                return "Tarjetas de Crédito";
            }
        }

        private void FConfiguracion_Load(object sender, EventArgs e)
        {
            
        }
    }
}

