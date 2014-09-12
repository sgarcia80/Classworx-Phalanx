using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PhalanxAdmin
{
    public partial class FBase : Form
    {
        protected int m_PanelWidth;
        protected int m_PanelHeight;
        protected int m_ClientSizeWidth;
        protected int m_ClientSizeHeight;
 
        public FBase()
        {
            InitializeComponent();
        }
        public FBase(//int PanelWidth, 
            int PanelHeight, int ClientSizeWidth, int ClientSizeHeight)
        {
            InitializeComponent();
            //m_PanelWidth= PanelWidth;
            m_PanelHeight = PanelHeight;
            m_ClientSizeWidth = ClientSizeWidth;
            m_ClientSizeHeight = ClientSizeHeight;
            this.Top = 0;
            this.Left = 0;
        }
        public virtual string Id
        {
            get
            {
                return "";
            }
        }

        private void FBase_Load(object sender, EventArgs e)
        {
            this.Width = m_ClientSizeWidth - m_PanelWidth - 5;
            this.Height = m_ClientSizeHeight - m_PanelHeight - 5;

        }
    }
}