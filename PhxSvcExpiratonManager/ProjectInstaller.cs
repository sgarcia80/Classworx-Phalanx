using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;

namespace PhxSvcExpirationManager
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        /*public override void Install(IDictionary savedState)
        {
            base.Install(savedState);
            //Add custom code here
        }

        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);
            //Add custom code here
        }

        public override void Rollback(IDictionary savedState)
        {
            base.Rollback(savedState);
            //Add custom code here
        }

        public override void Commit(IDictionary savedState)
        {
            base.Commit(savedState);
            //Add custom code here
        }

        static void Main()
        {

        }*/

        public ProjectInstaller()
        {
            InitializeComponent();
        }
    }
}