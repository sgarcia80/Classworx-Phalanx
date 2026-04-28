using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PhalanxAdmin
{
    public partial class frmBaseMaxMdiChilds : FBase
    {
        private string _FormTitle = "";
        protected string SetFormTitle
        { set { _FormTitle = value; } }
        public string FormTitle
        {
            get { return _FormTitle; }
        }
        protected bool HabilitaMenuContextualModificar = false;
        public frmBaseMaxMdiChilds()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            //this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }
        protected bool _FormEditMode = false;
        public bool IsEditMode
        { get { return _FormEditMode; } }

        //protected void OpenForm<T>() where T : new()
        //{

        //    Form frmParent = this.MdiParent;

        //    foreach (Form f in this.MdiParent.MdiChildren)
        //    {
        //        if (f.GetType() != typeof(T))
        //        {
        //            if (((frmBaseMaxMdiChilds)f).IsEditMode)
        //            {
        //                if (MessageBox.Show("No se han guardado los datos. Desea continuar?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.No)
        //                {
        //                    return;
        //                }
        //            }
        //            f.Close();
        //        }
        //    }
        //    if (this.MdiParent == null)
        //    {
        //        Form form1 = new T() as Form;
        //        form1.MdiParent = frmParent;
        //        form1.WindowState = FormWindowState.Maximized;
        //        form1.Show();
        //        ((frmMain)frmParent).pnlFormTitle.Visible = true;
        //        ((frmMain)frmParent).lblFormTitle.Text = (frmParent.MdiChildren[0] as frmBaseMaxMdiChilds).FormTitle;
        //    }
        //    else
        //    {
        //        if (this.MdiParent.MdiChildren.Length == 1)
        //        {
        //            (this.MdiParent.MdiChildren[0] as frmBaseMaxMdiChilds).Activate();
        //        }
        //        else
        //        {
        //            Form form1 = new T() as Form;
        //            form1.MdiParent = this.MdiParent;
        //            form1.WindowState = FormWindowState.Maximized;
        //            form1.Show();
        //        }
        //        //((frmMain)this.MdiParent).pnlFormTitle.Visible = true;
        //        //((frmMain)this.MdiParent).lblFormTitle.Text = (this.MdiParent.MdiChildren[0] as frmBaseMaxMdiChilds).FormTitle;
        //    }

        //}

        //public CwxWorkflowCommon.Entities.CwxUserEntity GetLoggedUser()
        //{
        //    CwxWorkflowCommon.Entities.CwxUserEntity user;

        //    frmMain main = this.MdiParent as frmMain;

        //    if (main != null)
        //    {
        //        user = main.LoggedUser;
        //    }
        //    else
        //    {
        //        user = new CwxWorkflowCommon.Entities.CwxUserEntity();
        //    }

        //    return user;
        //}

        protected string UserName
        {
            get { return Thread.CurrentPrincipal.Identity.Name; }
        }
    }
}
