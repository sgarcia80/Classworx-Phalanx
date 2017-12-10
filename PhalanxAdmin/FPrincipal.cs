using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhalanxBL;
using PhalanxCommon.Entities;
using PhalanxDAL;

namespace PhalanxAdmin
{
    public partial class FPrincipal : Form
    {
        private string Usuario { get; set; }

        private FBienvenida formBienvenida;
        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SendMessageA")]
        static extern int SendMessage(System.IntPtr hwnd, int wMsg, int wParam, ref Point lParam);
        const int LVM_SETITEMPOSITION32 = (0x1000 + 49);
        //const int LVM_GETITEMTEXTW		 = (0x1000 + 115);
        
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(FPrincipal));

        PhxUserEntity _loggedUser;
        PhxUserBusiness _phxUsrBL = new PhxUserBusiness();
        public FPrincipal()
        {
            InitializeComponent();

            log4net.Config.XmlConfigurator.Configure();
            log.Info("Logging has been configured");

        }

        public FPrincipal(string usuario) : this()
        {
            this.Usuario = usuario;
        }

        private void FPrincipal_Load(object sender, EventArgs e)
        {
            string Version = "3.17.9.17";
            this.Text += " v" + Version;
            try
            {
                this.lblTitulo.Text = string.Empty;
                //DBMgr.Application = App.Phalanx;
                //DBMgr.NHAssembly = typeof(DBMgr).Assembly;
                //DBMgr.Inicializar();

                if (formBienvenida == null || formBienvenida.IsDisposed)
                {
                    formBienvenida = new FBienvenida( //this.panelLeft.Width, 
                        this.panelIcons.Height,
                        this.ClientSize.Width,
                        this.ClientSize.Height);
                    this.AddOwnedForm(formBienvenida);
                    formBienvenida.MdiParent = this;
                }
                formBienvenida.Show();
                formBienvenida.BringToFront();
                this.MdiChildResize();
                // chequea si el usuario de windows loggeado está autorizado en el sistema
                PhxContingenciaBusiness ContBL = new PhxContingenciaBusiness();
                bool PruebaOtroEsquema = true;
                bool ConexionIniViva = false;
                if (ContBL.CheckConnection())
                {
                    ConexionIniViva = true;
                    // la conexion por defecto esta viva, hay que verificar si esta habilitada por sistema
                    if (ContBL.VerificaSiConexionUsadaEstaActiva())
                    {
                        // entra al sistema
                        PruebaOtroEsquema = false;
                    }
                    else
                    {
                        PruebaOtroEsquema = true;
                        /*
                        // el esquema tiene acceso pero no esta activado en el sistema
                        PhxContingenciaEntity ContE = ContBL.EsquemaActualHabilitado();
                        if (ContE.EsProduccion)
                        {
                            // hay acceso a contingencia pero el activo es produccion, pregunta si quiere intentar conectar
                            if (MessageBox.Show("El esquema de Contingencia no está habilitado, desea intentar conectar a Producción?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                PruebaOtroEsquema = true;
                            }
                            else
                            {
                                Application.Exit();
                            }
                        }
                        else if (ContE.EsContingencia)
                        {
                            // hay acceso a produccion pero el activo es contingencia, pregunta si intenta conectar a contingencia
                            if (MessageBox.Show("El esquema de Producción no está habilitado, desea intentar conectar a Contingencia?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                PruebaOtroEsquema = true;
                            }
                            else
                            {
                                Application.Exit();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Hubo un error al conectar al sistema");
                            Application.Exit();
                        }*/
                    }
                }
                if (PruebaOtroEsquema)
                {
                    if (ContBL.CheckAlternateConnection())
                    {
                        if (ContBL.VerificaSiConexionUsadaEstaActiva())
                        {
                            // cambia el ini a la conexion alternativa
                            bool ActivarProduccion = false;
                            if (ContBL.EsAmbienteActualProduccion())
                            {
                                ActivarProduccion = true;
                            }
                            PhxContingenciaBusiness ContB = new PhxContingenciaBusiness();
                            ContB.SetearEsquemaActivo(ActivarProduccion);
                        }
                        else
                        {
                            PhxUserBusiness UsrBL = new PhxUserBusiness();
                            //lnk.Enabled = UsrBL.AccPwd(this.Usuario);
                            //if (UsrBL.PermisoActivacionEsquema(this.Usuario))
                            if (UsrBL.PermisoActivacionEsquema(this.Usuario))
                            {
                                bool ActivarProduccion = false;
                                string ConexionConectada = "Contingencia";
                                if (ContBL.EsAmbienteActualProduccion())
                                {
                                    ActivarProduccion = true;
                                    ConexionConectada = "Producción";
                                }
                                if (MessageBox.Show("Se conectó a " + ConexionConectada + " y no es la conexión activa en el sistema. Desea establecerla?"
                                    , "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    // activar conexion en uso y cambiar ini
                                    PhxContingenciaBusiness ContB = new PhxContingenciaBusiness();
                                    ContB.ActivarEsquema(ActivarProduccion);

                                }
                                else
                                {
                                    Application.Exit();
                                    return;
                                }

                            }
                            else
                            {
                                MessageBox.Show("No se puede tener acceso a la Base de Datos de Phalanx. Solicite intervención de un administrador");
                                Application.Exit();
                                return;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se puede tener acceso a la Base de Datos de Phalanx." + Environment.NewLine +
                            "Acceda a PhalanxConfig para configurar dicho acceso");
                        Application.Exit();
                        return;
                    }
                }
                if (!ContBL.EsAmbienteActualProduccion())
                {
                    this.Text += " - Contingencia";
                }
                if (new PhxVersionBusiness().CheckLastVersion(Version) == false)
                {
                    MessageBox.Show("Versión incorrecta");
                    Application.Exit();
                    //OpenForm(new FConfiguracion());
                    return;
                }
                //_loggedUser = _phxUsrBL.IsActiveSysUser(this.Usuario);
                //_loggedUser = _phxUsrBL.AdmLogin(this.Usuario);
                _loggedUser = _phxUsrBL.AdmLogin(this.Usuario);
                if (_loggedUser == null)
                //if (!SecurityMgr.AuthenticateLoggedWinUser() || !SecurityMgr.CheckAccessToAdminSystem())
                {
                    MessageBox.Show("No está autorizado para usar el sistema");
                    Application.Exit();
                    return;
                }
                this.MakeMenu();
                this.lvIconsAdjust();
                // temita de tiempos
                /*
                TimeSpan prue = DateTime.Now - new DateTime(2013, 4, 1);
                int cantdias = Convert.ToInt32(prue.TotalDays);
                bool pasara = true;
                if (cantdias >= 30)
                {
                    if (cantdias > 60)
                    {
                        cantdias = 60;
                    }
                    Random random = new Random();
                    int randomNumber = random.Next(cantdias, 80);
                    if (randomNumber >= 65)
                    {
                        pasara = false;
                        MessageBox.Show("Attempted to read or write protected memory. This is often an indication that other memory is corrupt. The application was unable to complete an operation.");
                        Application.Exit();
                        return;
                    }
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un problema al incializar el sistema. La aplicación se cerrará./nError: " + ex.Message);
                Application.Exit();
                return;
            }

        }

        private void MdiChildResize()
        {
            if (this.MdiChildren.Length > 0) //para saber si hay algun form hijo para resiziar
            {
                this.ActiveMdiChild.Height = this.ClientSize.Height - this.panelIcons.Height - 4 - this.pnlTitle.Height;
                this.ActiveMdiChild.Width = this.ClientSize.Width - 4;
            }
        }

        private void MakeMenu()
        {
            /*
            IList MenuOptions = new ArrayList();

            if (SecurityMgr.ChkAccAdminMenu())
            {
                // menu administración
                System.Windows.Forms.ListViewItem LVIAdmin = new System.Windows.Forms.ListViewItem(new string[] {
																													"Administración"}, 0, System.Drawing.Color.Black, System.Drawing.Color.Empty, new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))));
                LVIAdmin.StateImageIndex = 0;
                LVIAdmin.Tag = "1";
                MenuOptions.Add(LVIAdmin);
            }

            if (SecurityMgr.ChkAccUsersMenu())
            {
                // menu Usuarios
                System.Windows.Forms.ListViewItem LVIUsuarios = new System.Windows.Forms.ListViewItem(new string[] {
																													   "Usuarios"}, 1, System.Drawing.Color.Black, System.Drawing.Color.Empty, new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))));
                LVIUsuarios.StateImageIndex = 0;
                LVIUsuarios.Tag = "2";
                MenuOptions.Add(LVIUsuarios);
            }

            if (SecurityMgr.ChkAccDomainsMenu())
            {
                // menu Dominios
                System.Windows.Forms.ListViewItem LVIDominios = new System.Windows.Forms.ListViewItem(new string[] {
																													   "Dominios"}, 2, System.Drawing.Color.Black, System.Drawing.Color.Empty, new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))));
                LVIDominios.StateImageIndex = 0;
                LVIDominios.Tag = "3";
                MenuOptions.Add(LVIDominios);
            }

            if (SecurityMgr.ChkAccPCsMenu())
            {
                // menu PCs
                System.Windows.Forms.ListViewItem LVIPCs = new System.Windows.Forms.ListViewItem(new string[] {
																												  "PCs"}, 3, System.Drawing.Color.Black, System.Drawing.Color.Empty, new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))));
                LVIPCs.StateImageIndex = 0;
                LVIPCs.Tag = "4";
                MenuOptions.Add(LVIPCs);
            }

            if (SecurityMgr.ChkAccPwdsMenu())
            {
                // menu Contraseñas
                System.Windows.Forms.ListViewItem LVIPwds = new System.Windows.Forms.ListViewItem(new string[] {
																												   "Contraseñas"}, 4, System.Drawing.Color.Black, System.Drawing.Color.Empty, new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))));
                LVIPwds.StateImageIndex = 0;
                LVIPwds.Tag = "5";
                MenuOptions.Add(LVIPwds);
            }

            if (SecurityMgr.ChkAccGroupsMenu())
            {
                // menu Grupos
                System.Windows.Forms.ListViewItem LVIGrupos = new System.Windows.Forms.ListViewItem(new string[] {
																													 "Grupos"}, 5, System.Drawing.Color.Black, System.Drawing.Color.Empty, new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))));
                LVIGrupos.StateImageIndex = 0;
                LVIGrupos.Tag = "6";
                MenuOptions.Add(LVIGrupos);
            }

            // agrega los items al LV del menu
            System.Windows.Forms.ListViewItem[] LVIMenu = new System.Windows.Forms.ListViewItem[MenuOptions.Count];
            int i = 0;
            foreach (System.Windows.Forms.ListViewItem auxLVI in MenuOptions)
            {
                LVIMenu[i] = auxLVI;
                i++;
            }
            this.lVIcons.Items.AddRange(LVIMenu);*/

            ListView.ListViewItemCollection LVItmCol = new ListView.ListViewItemCollection(lVIcons);

            //if (_phxUsrBL.ChkMenuSistema(_loggedUser))
            //{
                System.Windows.Forms.ListViewItem LVISist = new System.Windows.Forms.ListViewItem(
                    new string[] { "Parametría" }, 0, System.Drawing.Color.Black, System.Drawing.Color.Empty, new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))));
                LVISist.StateImageIndex = 0;
                LVISist.Tag = 1;
                LVItmCol.Add(LVISist);
            //}

            System.Windows.Forms.ListViewItem LVIAdmin = new System.Windows.Forms.ListViewItem(
                new string[] { "Administración" }, 1, System.Drawing.Color.Black, System.Drawing.Color.Empty, new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))));
            LVIAdmin.StateImageIndex = 0;
            LVIAdmin.Tag = 2;
            LVItmCol.Add(LVIAdmin);

            System.Windows.Forms.ListViewItem LVIPwd = new System.Windows.Forms.ListViewItem(
                new string[] { "Contraseñas" }, 2, System.Drawing.Color.Black, System.Drawing.Color.Empty, new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))));
            LVIPwd.StateImageIndex = 0;
            LVIPwd.Tag = 3;
            LVItmCol.Add(LVIPwd);

            System.Windows.Forms.ListViewItem LVINotifClaves = new System.Windows.Forms.ListViewItem(
                new string[] { "Notif. Claves" }, 2, System.Drawing.Color.Black, System.Drawing.Color.Empty, new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))));
            LVINotifClaves.StateImageIndex = 0;
            LVINotifClaves.Tag = 7;
            LVItmCol.Add(LVINotifClaves);

            System.Windows.Forms.ListViewItem LVIReports = new System.Windows.Forms.ListViewItem(
                new string[] { "Reportes" }, 3, System.Drawing.Color.Black, System.Drawing.Color.Empty, new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))));
            LVIReports.StateImageIndex = 0;
            LVIReports.Tag = 4;
            LVItmCol.Add(LVIReports);

            System.Windows.Forms.ListViewItem LVIAudit = new System.Windows.Forms.ListViewItem(
                new string[] { "Auditoría" }, 4, System.Drawing.Color.Black, System.Drawing.Color.Empty, new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))));
            LVIAudit.StateImageIndex = 0;
            LVIAudit.Tag = 5;
            LVItmCol.Add(LVIAudit);

            System.Windows.Forms.ListViewItem LVIExit = new System.Windows.Forms.ListViewItem(
                new string[] { "Salir" }, 5, System.Drawing.Color.Black, System.Drawing.Color.Empty, new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))));
            LVIExit.StateImageIndex = 0;
            LVIExit.Tag = 6;
            LVItmCol.Add(LVIExit);

        }
        private void panelIcons_Resize(object sender, EventArgs e)
        {
            lvIconsAdjust();
        }

        private void lvIconsAdjust()
        {
            int IconsWidth = 0; //lVIcons.Width / lVIcons.Items.Count;
            //int lvwidth = 0;
            for (int i = 0; i < lVIcons.Items.Count; i++)
            {
                IconsWidth += lVIcons.Items[i].Bounds.Width;
                if (i == 3)
                {
                    //lVIcons.Items[i].Position = new Point(lVIcons.Items[i-1].Position.X + 95, lVIcons.Items[i].Position.Y);
                }
            }
            if (panelIcons.Width - 230 > IconsWidth + 50)
            {
                lVIcons.Width = panelIcons.Width - 280;
                //pictureBox3.Width = panelIcons.Width - 145;
            }

            //this.lVIcons_Resize(lVIcons, System.EventArgs.Empty);


        }

        private void lVIcons_Resize(object sender, EventArgs e)
        {
            return;
            Control thisLV = (Control)sender;

            int anchototal = 0;
            for (int i = 0; i < lVIcons.Items.Count; i++)
            {
                System.Drawing.Rectangle auxRect = lVIcons.Items[i].Bounds;

                anchototal += auxRect.Width;
            }

            if (thisLV.Width < anchototal)
            {
                thisLV.Width = anchototal;
                return;
            }

            int anchoLV = lVIcons.Width;

            int IconsWidth = 0; //lVIcons.Width / lVIcons.Items.Count;
            //int lvwidth = 0;
            for (int i = 0; i < lVIcons.Items.Count; i++)
            {
                IconsWidth += lVIcons.Items[i].Bounds.Width;
            }
            int IconsSpace = Convert.ToInt32(System.Math.Floor((lVIcons.Width - IconsWidth) / (lVIcons.Items.Count - 0.5)));
            int IconPosition = Convert.ToInt32(System.Math.Floor((double)IconsSpace / 2));

            for (int i = 0; i < lVIcons.Items.Count; i++)
            {
                //lVIcons.Items[i].Bounds.Location = new System.Drawing.Point(IconPosition + IconsSpace,lVIcons.Items[i].Bounds.Location.Y); //new Rectangle( new System.Drawing.Point(IconPosition + IconsSpace,lVIcons.Items[i].Bounds.Location.Y), new Size(lVIcons.Items[i].Bounds.Size.Width, lVIcons.Items[i].Bounds.Size.Height));
                //lVIcons.Items[i].Bounds. = new System.Drawing.Point(IconPosition + IconsSpace,lVIcons.Items[i].Bounds.Location.Y); //new Rectangle( new System.Drawing.Point(IconPosition + IconsSpace,lVIcons.Items[i].Bounds.Location.Y), new Size(lVIcons.Items[i].Bounds.Size.Width, lVIcons.Items[i].Bounds.Size.Height));
                int AnchoTexto = lVIcons.Items[i].GetBounds(ItemBoundsPortion.Label).Width;
                int AnchoIcono = lVIcons.Items[i].GetBounds(ItemBoundsPortion.Icon).Width;

                int TextSpace = 0;

                if (AnchoTexto > AnchoIcono)
                {
                    TextSpace = Convert.ToInt32(System.Math.Floor((double)((AnchoTexto - AnchoIcono)) / 2));
                }
                Point pnt = new Point(IconPosition + TextSpace, 0);
                SendMessage(lVIcons.Handle, LVM_SETITEMPOSITION32, i, ref pnt);
                int Ancho2 = lVIcons.Items[i].Bounds.Width;
                IconPosition += Ancho2 + IconsSpace;

            }

        }

        private void lVIcons_Click(object sender, EventArgs e)
        {

            int currTag;
            currTag = Convert.ToInt32(
                                (sender as ListView).Items[(sender as ListView).SelectedIndices[0]].Tag
                                    );
            switch (currTag)
            {
                case 1:
                    FSistema formSistema = new FSistema();
                    //this.pnlBack.Visible = false;
                    this.OpenForm(formSistema);
                    break;
                case 2:
                    FAdmin formAdmin = new FAdmin();
                    //this.pnlBack.Visible = false;
                    this.OpenForm(formAdmin);
                    break;
                case 3:
                    FContrasenas formContrasenas = new FContrasenas();
                    this.OpenForm(formContrasenas);
                    break;
                case 4:
                    FReportes formReportes = new FReportes();
                    this.OpenForm(formReportes);
                    break;
                case 5:
                    FBaseAuditoria formAudit = new FBaseAuditoria();
                    this.OpenForm(formAudit);
                    break;
                case 6:
                    if (MessageBox.Show("Va a salir de la aplicación. Desea continuar?", "Phalanx Security Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        this.Close();
                    }
                    break;
                case 7:
                    FNotifClaves formNotifClaves = new FNotifClaves();
                    this.OpenForm(formNotifClaves);
                    break;
                /*
            case FORM_CONFIG:
                foreach (Form auxfrm in this.MdiChildren)
                {
                    if ((auxfrm as FAdministracion) == null)
                    {
                        auxfrm.Close();
                    }
                }
                if (formAdministracion == null || formAdministracion.IsDisposed)
                {
                    formAdministracion = new FAdministracion( //this.panelLeft.Width, 
                        this.panelIcons.Height,
                        this.ClientSize.Width,
                        this.ClientSize.Height);
                    this.AddOwnedForm(formAdministracion);
                    formAdministracion.MdiParent = this;
                }
                formAdministracion.Show();
                formAdministracion.BringToFront();
                this.MdiChildResize();
                this.lvIconsAdjust();
                break;
            case FORM_DOMINIOS:
                foreach (Form auxfrm in this.MdiChildren)
                {
                    if ((auxfrm as FDominios) == null)
                    {
                        auxfrm.Close();
                    }
                }
                if (formDominios == null || formDominios.IsDisposed)
                {
                    formDominios = new FDominios( //this.panelLeft.Width, 
                        this.panelIcons.Height,
                        this.ClientSize.Width,
                        this.ClientSize.Height);
                    this.AddOwnedForm(formDominios);
                    formDominios.MdiParent = this;
                }
                formDominios.Show();
                formDominios.BringToFront();
                this.MdiChildResize();
                this.lvIconsAdjust();
                break;
            case FORM_USUARIOS:
                foreach (Form auxfrm in this.MdiChildren)
                {
                    if ((auxfrm as FUsuarios) == null)
                    {
                        auxfrm.Close();
                    }
                }
                if (formUsuarios == null || formUsuarios.IsDisposed)
                {
                    formUsuarios = new FUsuarios( //this.panelLeft.Width, 
                        this.panelIcons.Height,
                        this.ClientSize.Width,
                        this.ClientSize.Height);
                    this.AddOwnedForm(formUsuarios);
                    formUsuarios.MdiParent = this;
                }
                formUsuarios.Show();
                formUsuarios.BringToFront();
                this.MdiChildResize();
                this.lvIconsAdjust();
                break;
            case FORM_PCS:
                foreach (Form auxfrm in this.MdiChildren)
                {
                    if ((auxfrm as FPCs) == null)
                    {
                        auxfrm.Close();
                    }
                }
                if (formPCs == null || formPCs.IsDisposed)
                {
                    formPCs = new FPCs( //this.panelLeft.Width, 
                        this.panelIcons.Height,
                        this.ClientSize.Width,
                        this.ClientSize.Height);
                    this.AddOwnedForm(formPCs);
                    formPCs.MdiParent = this;
                }
                formPCs.Show();
                formPCs.BringToFront();
                this.MdiChildResize();
                this.lvIconsAdjust();
                break;
            case FORM_PASSWORDS:
                foreach (Form auxfrm in this.MdiChildren)
                {
                    if ((auxfrm as FPasswords) == null)
                    {
                        auxfrm.Close();
                    }
                }
                if (formPasswords == null || formPasswords.IsDisposed)
                {
                    formPasswords = new FPasswords( //this.panelLeft.Width, 
                        this.panelIcons.Height,
                        this.ClientSize.Width,
                        this.ClientSize.Height);
                    this.AddOwnedForm(formPasswords);
                    formPasswords.MdiParent = this;
                }
                formPasswords.Show();
                formPasswords.BringToFront();
                this.MdiChildResize();
                this.lvIconsAdjust();
                break;
            case FORM_GRUPOS:
                foreach (Form auxfrm in this.MdiChildren)
                {
                    if ((auxfrm as FGrupos) == null)
                    {
                        auxfrm.Close();
                    }
                }
                if (formGrupos == null || formGrupos.IsDisposed)
                {
                    formGrupos = new FGrupos( //this.panelLeft.Width, 
                        this.panelIcons.Height,
                        this.ClientSize.Width,
                        this.ClientSize.Height);
                    this.AddOwnedForm(formGrupos);
                    formGrupos.MdiParent = this;
                }
                formGrupos.Show();
                formGrupos.BringToFront();
                this.MdiChildResize();
                this.lvIconsAdjust();
                break;*/
            }

        }

        private void FPrincipal_Resize(object sender, EventArgs e)
        {
            MdiChildResize();

        }

        public void OpenForm(FBase FormToOpen)
        {
            bool FormAlreadyLoaded = false;
            foreach (FBase auxfrm in this.MdiChildren)
            {
                if (auxfrm.Id != FormToOpen.Id)
                {
                    auxfrm.Close();
                }
                else
                {
                    FormAlreadyLoaded = true;
                    //auxfrm.Visible = false;
                    auxfrm.Show();
                    this.MdiChildResize();
                    //auxfrm.BringToFront();
                    //auxfrm.Visible = true;
                }
            }
            if (!FormAlreadyLoaded)
            {
                lblTitulo.Text = string.Empty;

                this.AddOwnedForm(FormToOpen);
                FormToOpen.Height = this.ClientSize.Height - this.panelIcons.Height - 4 - this.pnlTitle.Height;
                FormToOpen.Width = this.ClientSize.Width - 4;
                FormToOpen.MdiParent = this;

                FormToOpen.Usuario = this.Usuario;
                
                lblTitulo.Text = FormToOpen.Titulo;

                FormToOpen.Show();
                this.MdiChildResize();
                FormToOpen.BringToFront();
            }
        }

    }
}