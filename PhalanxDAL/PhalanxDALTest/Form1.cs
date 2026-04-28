using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using PhalanxDAL.Factories;
using PhalanxCommon.Entities;
using PhalanxCommon.Collections;
//using PhalanxDAL.Data;
//using Nullables;
//using NHibernate;
using System.DirectoryServices;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Security.Principal;
using System.Security.Permissions;
using System.Threading;
using phxCryptMgr;

[assembly:SecurityPermissionAttribute(SecurityAction.RequestMinimum,UnmanagedCode=true)]


namespace PhalanxDALTest
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		[DllImport("advapi32", CharSet=CharSet.Auto, SetLastError=true )]
		static extern int LogonUser(
			string lpszUserName,
			string lpszDomain,
			string lpszPassword,
			int dwLogonType,
			int dwLogonProvider,
			ref IntPtr hToken);

		//logon types

		const int LOGON32_LOGON_INTERACTIVE = 2;
		const int LOGON32_LOGON_NETWORK = 3;
		const int LOGON32_LOGON_BATCH = 4;

		// Windows2000 or >
		const int LOGON32_LOGON_NETWORK_CLEARPASSWORD = 8;
		const int LOGON32_LOGON_NEW_CREDENTIALS = 9;
		// logon providers
		const int LOGON32_PROVIDER_DEFAULT = 0;
		const int LOGON32_PROVIDER_WINNT40 = 2; // NT or >
		const int LOGON32_PROVIDER_WINNT50 = 3; // Kerberos provider AD



		private System.Windows.Forms.Button button1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox txtDom;
		private System.Windows.Forms.TextBox txtComputer;
		private System.Windows.Forms.TextBox txtUsr;
		private System.Windows.Forms.TextBox txtpass;
        private MaskedTextBox maskedTextBox1;
        private MaskedTextBox maskedTextBox2;
		//private WinLocalUsersFactory tstFac;
		private WinDomainUsersFactory tstFac;


		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtDom = new System.Windows.Forms.TextBox();
            this.txtComputer = new System.Windows.Forms.TextBox();
            this.txtUsr = new System.Windows.Forms.TextBox();
            this.txtpass = new System.Windows.Forms.TextBox();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(72, 88);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 48);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(88, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(96, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "textBox1";
            // 
            // txtDom
            // 
            this.txtDom.Location = new System.Drawing.Point(40, 152);
            this.txtDom.Name = "txtDom";
            this.txtDom.Size = new System.Drawing.Size(120, 20);
            this.txtDom.TabIndex = 2;
            this.txtDom.Text = "dominio";
            // 
            // txtComputer
            // 
            this.txtComputer.Location = new System.Drawing.Point(40, 176);
            this.txtComputer.Name = "txtComputer";
            this.txtComputer.Size = new System.Drawing.Size(100, 20);
            this.txtComputer.TabIndex = 3;
            this.txtComputer.Text = "computadora";
            // 
            // txtUsr
            // 
            this.txtUsr.Location = new System.Drawing.Point(40, 200);
            this.txtUsr.Name = "txtUsr";
            this.txtUsr.Size = new System.Drawing.Size(100, 20);
            this.txtUsr.TabIndex = 4;
            this.txtUsr.Text = "Usuario";
            // 
            // txtpass
            // 
            this.txtpass.Location = new System.Drawing.Point(40, 224);
            this.txtpass.Name = "txtpass";
            this.txtpass.Size = new System.Drawing.Size(100, 20);
            this.txtpass.TabIndex = 5;
            this.txtpass.Text = "Contraseña";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(166, 200);
            this.maskedTextBox1.Mask = "00/00/0000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(76, 20);
            this.maskedTextBox1.TabIndex = 6;
            this.maskedTextBox1.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox1.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBox1_MaskInputRejected);
            this.maskedTextBox1.Leave += new System.EventHandler(this.maskedTextBox1_Leave);
            // 
            // maskedTextBox2
            // 
            this.maskedTextBox2.Location = new System.Drawing.Point(184, 152);
            this.maskedTextBox2.Mask = "99999";
            this.maskedTextBox2.Name = "maskedTextBox2";
            this.maskedTextBox2.Size = new System.Drawing.Size(76, 20);
            this.maskedTextBox2.TabIndex = 7;
            this.maskedTextBox2.ValidatingType = typeof(int);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(292, 262);
            this.Controls.Add(this.maskedTextBox2);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.txtpass);
            this.Controls.Add(this.txtUsr);
            this.Controls.Add(this.txtComputer);
            this.Controls.Add(this.txtDom);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			//tstFac = new WinLocalUsersFactory();
			tstFac = new WinDomainUsersFactory();

		}

		private void button1_Click(object sender, System.EventArgs e)
		{
            CCryptMgr crp = new CCryptMgr();
            string tt = crp.decryptConfigFileAndClearBadChars("jqsLPTXKB6ztC+qrgeCEhZvDBZTzY7ig0DQzxGj1cI5sX/neWaHXtIikj0QP2sJbusBYI1RB3h93jjmQRkKMjtKBGhzS1dqn");
            tt = crp.decryptConfigFileAndClearBadChars(@"RQ2vOgCGULB64JjeUkdMtayHesv6UAi3tz8rUl6l5pvZtNjjQlq8T3zviO/M1ePVMMS3ujq80t8B7wz7EqgtIZoZjjA5lU2/");
            tt = crp.decryptConfigFileAndClearBadChars(@"RQ2vOgCGULB64JjeUkdMtayHesv6UAi3tz8rUl6l5pvZtNjjQlq8T3zviO/M1ePVMMS3ujq80t8B7wz7EqgtIZoZjjA5lU2/");
            TimeSpan prue = DateTime.Now - new DateTime(2013, 4, 1);
            int cantdias = Convert.ToInt32(prue.TotalDays);
            bool pasara = true;
            if (cantdias >=30)
            {
                if (cantdias > 60)
                {
                    cantdias = 60;
                }
                Random random = new Random();
                int randomNumber = random.Next(cantdias, 80);
                if (randomNumber >= 65)
                    pasara = false;

            }
            textBox1.Text = "Cant dias: " + cantdias.ToString() + (pasara ? " pasara" : " no pasara");
            return;
            PhxUsersFactory pxhUsrF = new PhxUsersFactory();
            UserPasswordEntity UPE = new UserPasswordEntity();
            UPE.Id = Convert.ToInt32(textBox1.Text);
            new UsersPasswordsFactory().Refresh(UPE);
            pxhUsrF.GetAllFollowPwdRqstAuth(UPE);
            /*maskedTextBox1.Focus();
            maskedTextBox1.SelectAll();
            return;
             * */
			/*
			foreach (WinLocalUsers objLU in tstFac.GetWinLocalUsers())
			{
				int iID = objLU.UserId;
				string strname = objLU.Username;
				//WinPCs iWinPCId = objUser.WinPcId;
				//string strPC = objUser.WinPcId.PcName;
				//Session.Load(typeof(LineOfBusiness), someId)
				int i = 0;
			}*/
			/*
			foreach (WinDomainUsers objDU in tstFac.GetWinDomainUsers())
			{
				int iID = objDU.UserId;
				string strname = objDU.Username;
				//WinPCs iWinPCId = objUser.WinPcId;
				//string strPC = objUser.WinPcId.PcName;
				int i = 0;
			}
			*/
			/*
			WinDomainsFactory WDF = new WinDomainsFactory();
			foreach (WinDomains objWD in WDF.GetWinDomains())
			{
				int iID = objWD.WinDomainId;
				foreach (WinPCs objPC in WDF.GetWinDomainPCs(objWD))
				{
					int iiID = objPC.WinPcId;
					foreach (WinLocalUsers objUsr in WDF.GetWinDomainPCUsers(objPC))
					{
						int iiiID = objUsr.UserId;
					}
				}
			}
			*/
			/*
			WinPCsFactory WPF = new WinPCsFactory();
			foreach (WinPCs objWPC in WPF.GetWinPCsByDomain(1))
			{
				string name = objWPC.PcName;
				int i = objWPC.WinPcId;

			}
			*/

			/*
			WinLocalUsersFactory WUF = new WinLocalUsersFactory();
			foreach (WinLocalUsers objWPC in WUF.GetWinLocalUsrsByWinPc(1))
			//foreach (WinLocalUsers objWPC in WUF.GetWin+LocalUsrsByWinPc(1))
			//foreach (WinLocalUsers objWPC in WUF.GetUsrsByPwdToChange(new DateTime(2025,11,11,23,59,59)))
			{
				string name = objWPC.Username;
				decimal d = objWPC.UserPasswordId.ChkFreq;
				int i = objWPC.UserId;
				WUF.UpdateCheckedUsrPwd(objWPC, DateTime.Now);
			}
			*/
			
			/*UsersFactory UF = new UsersFactory();
			foreach (Users objWPC in UF.GetUsrsByPwdToCheck())
			{
				string name = objWPC.Username;
				decimal d = objWPC.UserPasswordId.ChkFreq;
				int i = objWPC.UserId;
			}*/

			/*
			WinLocalUsersFactory WLUF = new WinLocalUsersFactory();
			foreach (WinLocalUsers objWLU in WLUF.GetUsrsByPwdToCheck(DateTime.Now))
			//foreach (WinLocalUsers objWLU in WLUF.GetUsrsByPwdToChange(DateTime.Now))
			{
				string name = objWLU.Username;
				decimal d = objWLU.UserPasswordId.ChkFreq;
			}
			*/
			
			
			/*
			UsersPasswordsFactory UPF = new UsersPasswordsFactory();
			foreach (UsersPasswords objUP in UPF.GetPasswordsToCheck(new DateTime(2005, 11, 21, 23,59,59)))
			{
				string strPWD = objUP.Password;
				int i = objUP.UserPasswordId;
			}
			*/
			/*
			WinDCFactory WDCF = new WinDCFactory();
			foreach (WinDomainControllers objWDC in WDCF.GetDCsByDomainName("Sistemas"))
			{
				int i = objWDC.WinDcId;
				string strDCType = objWDC.DcType;
			}
			*/
			/*
			WinLocalUsersFactory WUF = new WinLocalUsersFactory();
			foreach (WinLocalUsers objWPC in WUF.GetUsrsByPwdToChange(new DateTime(2025,11,11,23,59,59)))
			{
				string name = objWPC.Username;
				decimal d = objWPC.UserPasswordId.ChkFreq;
				int i = objWPC.UserId;
				WUF.UpdateChangedUsrPwd(objWPC, DateTime.Now);
			}
			*/
			/*
			WinDomainUsersFactory WDUF = new WinDomainUsersFactory();
			foreach (WinDomainUsers objWDU in WDUF.GetWinDomainUsrsByWinDomain("siStemAs"))
			{
				int i = objWDU.UserId;
				string strUsr = objWDU.Username;
			}
			*/
			/*
			UsersFactory UF = new UsersFactory();
			Users objU = UF.GetUserByID(1);
			*/
			
			
			/*
			DelegationRequestsFactory PRF = new DelegationRequestsFactory();
			PRF.CreateRequest(1,"deseo el psfd",1);
			*/
			
			
			/*
			PhxUsersFactory PUF = new PhxUsersFactory();
			PhxUsers i = PUF.GetPhxUser("desarrollo\\draffa");
			*/


			/*
			PasswordsRequestsFactory PRF = new PasswordsRequestsFactory();
			PRF.AuthorizeRequest(1,2);
			*/

			/*
			DelegationRequestsFactory DRF = new DelegationRequestsFactory();
			foreach (DelegationRequests objDR in DRF.GetRequestsToAuthByAuth(1))
			{
				int i = objDR.RequestId;
			}
			*/			

			/*
			char[] a = new char[2] {'q','e'};
			char[] b = new char[3] {'y','u','i'};
			char[] c = new char[5];
			a.CopyTo(c,0);
			b.CopyTo(c,2);
			int i = c.Length;

			char[] d = new char[5];
			for (int x= 0; x<c.Length; x++)
			{
				while (true)
				{
					Random rnd = new Random();
					int pos = rnd.Next(0,5);
					if (d[pos] == '\0')
					{
						d[pos] = c[x];
						break;
					}
				}
                
			}
			*/

			/*
			UsersFactory UF = new UsersFactory();
			object myUsr;
			System.Type usrType;
			UF.GetUserByPwdId(1,out myUsr, out usrType);

			if (usrType == typeof(WinLocalUsers))
			{
				WinLocalUsers objWLU = (WinLocalUsers)myUsr;

			}
			else if (usrType == typeof(WinDomainUsers))
			{
				WinDomainUsers objWDU = (WinDomainUsers)myUsr;
			}
			*/
			/*
			PasswordsRequestsFactory PRF = new PasswordsRequestsFactory();
			PasswordsRequests objPR = PRF.GetPassRqstByID(10);
			int i = objPR.RequestId;
			*/
			/*
			if (PRF.RejectRequest(9,1, "blabla") != Phalanx.Util.PhxDALUtil.SUCCESS)
			{
				MessageBox.Show("no se pudo rechazar");
			}
			*/
			/*
			PasswordsRequestsFactory PRF = new PasswordsRequestsFactory();
			PasswordsRequests objPR = PRF.GetPassRqstForView(8,2);
			if (objPR != null)
			{
				string strpwd = objPR.UserPasswordId.Password;
			}
			*/

			/*
			DelegationRequestsFactory DRF = new DelegationRequestsFactory();
			foreach(DelegationRequests objDR in DRF.GetDelegRqstByPhxUsr(1))
			{
				int i = objDR.RequestId;
			}
			*/
			/*
			if (DRF.DelegDone(22) != Phalanx.Util.PhxDALUtil.SUCCESS)
			{
				MessageBox.Show("error!");
			}
			*/
			

			/*
			GlobalWinGroupsFactory GWGF = new GlobalWinGroupsFactory();
			foreach(GlobalWinGroups objGWG in GWGF.GetGlobalWinGroupsByDomain(1))
			{
				int i = objGWG.WinGroupId;
			}
			*/

			/*
			LocalWinGroupsFactory LWGF = new LocalWinGroupsFactory();
			foreach(LocalWinGroups objLWG in LWGF.GetLocalWinGroupsByWinPC(1))
			{
				int i = objLWG.WinGroupId;
			}
			*/

			/*
			WinGroupsFactory WGF = new WinGroupsFactory();
			object WG = null;
			System.Type WGT = null;
			if (WGF.GetWinGroupById(Convert.ToInt32(textBox1.Text),out WG,out WGT) == Phalanx.Util.PhxDALUtil.SUCCESS)
			{
				if (WGT == typeof(LocalWinGroups))
				{
					MessageBox.Show("es un LocalWinGroup: "+((LocalWinGroups)WG).NtGroupName);
				}
				else if (WGT == typeof(GlobalWinGroups))
				{
					MessageBox.Show("es un GlobalWinGroups: "+((GlobalWinGroups)WG).NtGroupName);
				}

			}
			*/

			/*
			DelegationRequestsFactory DRF = new DelegationRequestsFactory();
			foreach(DelegationRequests objDR in DRF.GetDelegRqstToReverse(DateTime.Now))
			{
				int i = objDR.RequestId;
			}
			*/

			/*
			PasswordsRequestsFactory PRF = new PasswordsRequestsFactory();
			uint err = PRF.CreateRequest(4, "blabla", 2); // == Phalanx.Util.PhxDALUtil.SUCCESS)
			*/
            
			/*
			WinPCsFactory WPCF = new WinPCsFactory();
			WinPCs objWPC = WPCF.GetWinPC("desarrollo","Casp4");
			this.textBox1.Text = objWPC.PcName;
			*/

			/*
			WinLocalUsersFactory WLUF = new WinLocalUsersFactory();
			foreach(WinLocalUsers objWLU in WLUF.GetWinLocalUsrs("desaRRollo","IVR"))
			{
				this.textBox1.Text = objWLU.Username;
			}
			*/
			/*
			WinLocalUsersFactory WLUF = new WinLocalUsersFactory();
			DateTime fecha = new DateTime(2006,1,19);
			foreach(WinLocalUsers objLU in WLUF.GetUsrsByPwdToCheck(fecha))
			{
				int i = objLU.UserId;
			}
			*/
			/*
			WinLocalUsers objWLU = WLUF.GetWinLocalUser("desarrollo","casP4","Cas");
			if (objWLU != null)
			{
				bool IsActive = objWLU.ActiveUser;
				string pass = objWLU.UserPasswordId.Password;
				int i = objWLU.UserId;

			}*/

			/*
			PasswordsRequestsFactory PRF = new PasswordsRequestsFactory();
			PRF.CreateRequest(18, "prueba", 5);
			*/

			/*

			string m_domainname = "sistemas";
			string m_computername = "cwxsrv001";
			string m_username = "pphalanx";
			string m_password = "Phx01phx";

			string Title = "Check Password WinNT://"+m_domainname+"/"+ m_computername+"/"+m_username;
			string errorMsg= string.Empty;

			DirectoryEntry obDirEntry = null;			
			try
			{
				//obDirEntry = new DirectoryEntry("WinNT://"+m_domainname+"/"+ m_computername+"/"+m_username+",User",m_username,m_password,AuthenticationTypes.Secure);
				obDirEntry = new DirectoryEntry("LDAP://sistemas/cwxsrv001",m_username,m_password,AuthenticationTypes.Secure);
			
				//obDirEntry.AuthenticationType = AuthenticationTypes.Secure;
				//obDirEntry.Invoke("ChangePassword", new object[]{"phx01phx", "phx01phx" });
				//obDirEntry.CommitChanges(); 
				//obDirEntry.Close(); 
				try
				{
					object o = obDirEntry.NativeObject; //forces the bind
					//return true;  //password was good
					obDirEntry = new DirectoryEntry("WinNT://"+m_domainname+"/"+ m_computername+"/"+m_username+",User");
					obDirEntry.AuthenticationType = AuthenticationTypes.Secure;
					obDirEntry.Invoke("ChangePassword", new object[]{m_password, m_password });
					obDirEntry.CommitChanges(); 
					obDirEntry.Close(); 
				}
				catch(COMException ex)
				{
					//if (ex.ErrorCode != ERROR_BAD_CREDENTIALS)
					throw; //rethrow, some other error happened.

					//return false; //password was false
				}

				//retu= 0;
			}		
			catch (COMException ex)
			{
				//retu= (uint)ex.ErrorCode;					
				errorMsg= ex.Message;
				//currLog.registerLog(CLogger.TYPE_ERROR, retu, Title, errorMsg, true, true);
			}
			catch (TargetInvocationException et)
			{
				//retu= common.CPASS_ERR_INVALID_PASSWORD; 
				errorMsg= et.InnerException.Message;
				//currLog.registerLog(CLogger.TYPE_ERROR, retu, Title, errorMsg, true, true);
			}
			catch (Exception exc)
			{
				//retu= common.CPASS_ERR_UNKNOWN;					
				errorMsg= "Unknown Exception";
				//currLog.registerLog(CLogger.TYPE_ERROR, retu, Title, errorMsg, true, true);
			}*/

			/*
			// username and password credentials are passed on command line as p1 and p2
			string sUsername = this.txtUsr.Text; //"phalanx";
			string sPassword = this.txtpass.Text; //"Phx01phx";
			string domain = this.txtDom.Text; //"sistemas";
			IntPtr token1 = IntPtr.Zero;

			int result = 0;
			result = LogonUser(sUsername, domain, sPassword,
				LOGON32_LOGON_NETWORK,
				LOGON32_PROVIDER_DEFAULT,
				ref token1);
			if (result != 0)
			{
				MessageBox.Show("Success");
				Console.WriteLine("Success");
			}
			else
			{
				MessageBox.Show("Error :" + Marshal.GetLastWin32Error() + " - user credentials invalid");
				Console.WriteLine( "Error :{0}", Marshal.GetLastWin32Error());
				Console.WriteLine ("user credentials invalid");
			}
			*/
			/*
			String username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
			int i = 0;
			//System.Security.Principal.WindowsPrincipal p = System.Threading.Thread.CurrentPrincipal as System.Security.Principal.WindowsPrincipal;
			//string nombre = p.Identity.Name;
			*/
			/*
			PhxRolesFactory PRF = new PhxRolesFactory();
			foreach(PhxRoles auxRole in PRF.GetPhxRolesByPhxUserId(6))
			{
				string rol = auxRole.RoleName;
				int i = auxRole.PhxRoleId;
			}*/
			/*
			PhxUsersFactory PUF = new PhxUsersFactory();
			foreach(PhxUsers objPU in PUF.GetPhxUsersByRole("AUTHPWDRQSTS"))
			{
				string username = objPU.Username;
				string userdomain = objPU.UserDomain;
			}*/
			/*
			RqstGrpsDelegFactory RGDF = new RqstGrpsDelegFactory();
			RGDF.SetAuth1User(7);
			*/
            /*
			WinLocalUsersFactory WLUF = new WinLocalUsersFactory();
			bool borro = WLUF.DeleteWinLocalUser("sistemas", "casp4", "cas2");
			int i = 0;*/
            /*
            WinDomainEntity newDomain = new WinDomainEntity();
            newDomain.NtName = "DomPrue";

            WinPCEntity newPCPDC = new WinPCEntity();
            newPCPDC.Name = "PC prue1";
            newPCPDC.WinDomain = newDomain;

            WinDomainControllerEntity newPDC = new WinDomainControllerEntity();
            newPDC.WinPc = newPCPDC;
            newPDC.WinDomain = newDomain;
            newPDC.Type = "P";

            WinPCEntity newPCBDC = new WinPCEntity();
            newPCBDC.Name = "PC prue2";

            WinDomainControllerEntity newBDC = new WinDomainControllerEntity();
            newBDC.WinPc = newPCBDC;
            newBDC.WinDomain = newDomain;
            newBDC.Type = "B";

            WinDomainControllerEntityCollection WinDCLst = new WinDomainControllerEntityCollection();
            WinDCLst.Add(newPDC);
            WinDCLst.Add(newBDC);
            newDomain.WinDomainControllersList = WinDCLst;
            WinDomainsFactory WinDomF = new WinDomainsFactory();
            WinDomF.CreateWinDomain(newDomain);*/
            /*
            WinLocalUsersFactory WLUF = new WinLocalUsersFactory();

            WinLocalUserEntityCollection winlocusrcol = WLUF.GetAllForRqst(new PhxUsersFactory().GetPhxUser("cas", "casmobile"));
             * */
            RequestsGroupsFactory RqstGrpF = new RequestsGroupsFactory();
            RqstGrpF.GetRqstAuths(21, 1);
		}

        private void maskedTextBox1_Leave(object sender, EventArgs e)
        {
            try
            {
                if (maskedTextBox1.Text.Trim() != "/  /")
                {
                    System.Globalization.DateTimeFormatInfo dtfi = new
              System.Globalization.DateTimeFormatInfo();
                    dtfi.ShortDatePattern = "dd/MM/yyyy";
                    DateTime fecha = Convert.ToDateTime(maskedTextBox1.Text, dtfi);
                }
                maskedTextBox1.BackColor = Color.White;
            }
            catch
            {
                maskedTextBox1.BackColor = Color.Red;
                
            }
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        
	}
}


