using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DesencriptadorContrasenias
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

            var login = new frmLogin();
            var result = login.ShowDialog();

            if (result == DialogResult.OK)
            {
                Application.Run(new frmVisualizador());
            }
        }
    }
}
