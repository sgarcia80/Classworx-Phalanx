namespace PhxSvcExpirationManager
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PhxSvcPwdRqstExpSrvcProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.PhxSvcPwdRqstExpSrvcInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // PhxSvcPwdRqstExpSrvcProcessInstaller
            // 
            this.PhxSvcPwdRqstExpSrvcProcessInstaller.Account = System.ServiceProcess.ServiceAccount.NetworkService;
            this.PhxSvcPwdRqstExpSrvcProcessInstaller.Password = null;
            this.PhxSvcPwdRqstExpSrvcProcessInstaller.Username = null;
            // 
            // PhxSvcPwdRqstExpSrvcInstaller
            // 
            this.PhxSvcPwdRqstExpSrvcInstaller.Description = "Phalanx Service Password Request Expiration Installer";
            this.PhxSvcPwdRqstExpSrvcInstaller.DisplayName = "Phalanx Service Password Request Expiration Installer";
            this.PhxSvcPwdRqstExpSrvcInstaller.ServiceName = "PhxSvcPwdRqstExpInstaller";
            this.PhxSvcPwdRqstExpSrvcInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.PhxSvcPwdRqstExpSrvcProcessInstaller,
            this.PhxSvcPwdRqstExpSrvcInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller PhxSvcPwdRqstExpSrvcProcessInstaller;
        private System.ServiceProcess.ServiceInstaller PhxSvcPwdRqstExpSrvcInstaller;
    }
}