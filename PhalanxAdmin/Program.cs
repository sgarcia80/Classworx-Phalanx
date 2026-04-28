using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PhalanxDAL;
using PhalanxCommon.Entities;

namespace PhalanxAdmin
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DBMgr.Application = App.Phalanx;
            DBMgr.NHAssembly = typeof(DBMgr).Assembly;
            DBMgr.Inicializar();

            FLogin frmlogin = new FLogin();

            DialogResult result = frmlogin.ShowDialog();

            if (result == DialogResult.OK)
            {
                Application.Run(new FPrincipal(frmlogin.Usuario));
            }
        }
    }
}