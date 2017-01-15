using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using PhalanxCommon.Entities;
using PhalanxBL;
using System.DirectoryServices;
using PhalanxCommon.Collections;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

public class UsuarioService : System.Web.Services.WebService
{
    public UsuarioService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public Resultado AltaGrupoSeguimiento(GrupoSeguimientoRequest request)
    {
        Resultado resultado = new Resultado();

        bool autorizado = ValidarCadenaSeguridad(request.StringAutenticacion, resultado);

        //Si pasó los controles de seguridad (autenticación y autorización)
        if (autorizado)
        {
            ProcesarGrupoSeguimiento(request, true, resultado);
        }

        return resultado;
    }

    [WebMethod]
    public Resultado AltaGrupoSolicitudes(GrupoSolicitudesRequest request)
    {
        Resultado resultado = new Resultado();

        bool autorizado = ValidarCadenaSeguridad(request.StringAutenticacion, resultado);

        //Si pasó los controles de seguridad (autenticación y autorización)
        if (autorizado)
        {
            ProcesarGrupoSolicitudes(request, true, resultado);
        }

        return resultado;
    }

    [WebMethod]
    public Resultado AltaPerfil(PerfilRequest request)
    {
        Resultado resultado = new Resultado();

        bool autorizado = ValidarCadenaSeguridad(request.StringAutenticacion, resultado);

        //Si pasó los controles de seguridad (autenticación y autorización)
        if (autorizado)
        {
            ProcesarPerfil(request, true, resultado);
        }

        return resultado;
    }

    [WebMethod]
    public Resultado AltaUsuario(AltaUsuarioRequest request)
    {
        Resultado resultado = new Resultado();

        bool autorizado = ValidarCadenaSeguridad(request.StringAutenticacion, resultado);

        //Si pasó los controles de seguridad (autenticación y autorización)
        if (autorizado)
        {
            //Se validan los datos recibidos
            bool datosValidos = ValidarDatosAlta(request, resultado);

            if (datosValidos)
            {
                PhalanxBL.PhxUserBusiness usuarioBL = new PhalanxBL.PhxUserBusiness();
                string usuario = string.Format("{0}\\{1}", request.Dominio, request.Usuario);

                //Se valida si existe el usuario
                PhxUserEntity user = usuarioBL.GetUserByDomUsr(usuario);

                if (user != null)
                {
                    //resultado.Mensaje = string.Format("El usuario {0} ya está registrado", usuario);
                    user.Active = true;
                }
                else
                {
                    //Si es un A
                    user = new PhxUserEntity();

                    user.Username = request.Usuario;
                    user.Fullname = request.NombreCompleto;
                    user.Domain = request.Dominio;
                    user.Email = request.Email;
                    user.Active = true;

                    user.FileNumber = request.Legajo;
                }

                try
                {
                    user.Id = usuarioBL.Save(user);

                    resultado.Exito = true;
                }
                catch (Exception ex)
                {
                    resultado.Mensaje = string.Format("Ha ocurrido un error al procesar el Alta del usuario. Detalle: {0}", ex.Message);
                }
            }
        }

        return resultado;
    }

    [WebMethod]
    public Resultado BajaGrupoSeguimiento(GrupoSeguimientoRequest request)
    {
        Resultado resultado = new Resultado();

        bool autorizado = ValidarCadenaSeguridad(request.StringAutenticacion, resultado);

        //Si pasó los controles de seguridad (autenticación y autorización)
        if (autorizado)
        {
            ProcesarGrupoSeguimiento(request, false, resultado);
        }

        return resultado;
    }

    [WebMethod]
    public Resultado BajaGrupoSolicitudes(GrupoSolicitudesRequest request)
    {
        Resultado resultado = new Resultado();

        bool autorizado = ValidarCadenaSeguridad(request.StringAutenticacion, resultado);

        //Si pasó los controles de seguridad (autenticación y autorización)
        if (autorizado)
        {
            ProcesarGrupoSolicitudes(request, false, resultado);
        }

        return resultado;
    }

    [WebMethod]
    public Resultado BajaPerfil(PerfilRequest request)
    {
        Resultado resultado = new Resultado();

        bool autorizado = ValidarCadenaSeguridad(request.StringAutenticacion, resultado);

        //Si pasó los controles de seguridad (autenticación y autorización)
        if (autorizado)
        {
            ProcesarPerfil(request, false, resultado);
        }

        return resultado;
    }

    [WebMethod]
    public Resultado BajaUsuario(BajaUsuarioRequest request)
    {
        Resultado resultado = new Resultado();

        bool autorizado = ValidarCadenaSeguridad(request.StringAutenticacion, resultado);

        //Si pasó los controles de seguridad (autenticación y autorización)
        if (autorizado)
        {
            //Se validan los datos recibidos
            bool datosValidos = ValidarDatosBaja(request, resultado);

            if (datosValidos)
            {
                PhalanxBL.PhxUserBusiness usuarioBL = new PhalanxBL.PhxUserBusiness();
                string usuario = string.Format("{0}\\{1}", request.Dominio, request.Usuario);

                //Se valida si existe el usuario
                PhxUserEntity user = usuarioBL.GetUserByDomUsr(usuario);

                if (user == null)
                {
                    resultado.Mensaje = string.Format("El usuario {0} no está registrado", usuario);
                }
                else
                {
                    //Si es un B
                    user.Active = false;

                    try
                    {
                        user.Id = usuarioBL.Save(user);
                    }
                    catch (Exception ex)
                    {
                        resultado.Mensaje = string.Format("Ha ocurrido un error al procesar la Baja del usuario. Detalle: {0}", ex.Message);
                    }

                    resultado.Exito = true;
                }
            }
        }

        return resultado;
    }

    #region Private Methods

    private bool Autenticar(string dominio, string usuario, string password)
    {
        bool authentic = false;

        string nombreUsuario = string.Format(@"{0}\{1}", dominio, usuario);

        try
        {
            string provider = "LDAP";

            PhxConfigBusiness pcb = new PhxConfigBusiness();

            PhxConfigEntity config = pcb.GetConfigParam(ConfigCodes.AutenticacionUsuariosAutorizadosWSConectores);

            if (config.ShortTxtValue == "WINNT")
                provider = "WinNT";

            DirectoryEntry entry = new DirectoryEntry(provider + "://" + dominio, usuario, password);

            object nativeObject = entry.NativeObject;
            authentic = true;
        }
        catch (Exception ex)
        {

        }

        return authentic;
    }

    private DatosAutenticacion ObtenerDatosAutenticacion(string stringAutenticacion)
    {
        DatosAutenticacion datosAutenticacion = new DatosAutenticacion();

        string autenticacion = (new phxCryptMgr.CCryptMgr()).decryptAndClearBadChars(stringAutenticacion);

        foreach (string dato in autenticacion.Split(';'))
        {
            if (dato.StartsWith("usuario=", StringComparison.InvariantCultureIgnoreCase))
                datosAutenticacion.Usuario = dato.Substring(8);
            else if (dato.StartsWith("dominio=", StringComparison.InvariantCultureIgnoreCase))
                datosAutenticacion.Dominio = dato.Substring(8);
            else if (dato.StartsWith("password=", StringComparison.InvariantCultureIgnoreCase))
                datosAutenticacion.Password = dato.Substring(9);
        }

        return datosAutenticacion;
    }

    private void ProcesarGrupoSeguimiento(GrupoSeguimientoRequest request, bool isNew, Resultado resultado)
    {
        PhalanxBL.PhxUserBusiness usuarioBL = new PhalanxBL.PhxUserBusiness();
        string usuario = string.Format("{0}\\{1}", request.Dominio, request.Usuario);

        //Se valida si existe el usuario
        PhxUserEntity user = usuarioBL.GetUserByDomUsr(usuario);

        if (user == null)
        {
            resultado.Mensaje = string.Format("El usuario {0} no está registrado", usuario);
        }
        else
        {
            FollowupRequestGroupBusiness groupBL = new FollowupRequestGroupBusiness();
            FollowupRequestGroupEntityCollection list = groupBL.GetAll();
            FollowupRequestGroupEntity entity = null;

            string[] grupos = request.IdGrupos.Split(',');

            FollowupRequestGroupEntityCollection gruposAsignados = new FollowupRequestGroupEntityCollection();
            //Se cargan los roles del usuario

            foreach (FollowupRequestGroupUserEntity r in user.PhxUsersFollowupGroupsList)
            {
                gruposAsignados.Add(r.FollowupRqstGrp);
            }

            //Si es un nuevo rol
            if (isNew)
            {
                foreach (string grupo in grupos)
                {
                    //Se busca el role recibido
                    FollowupRequestGroupEntity newGroup = list.Find(grupo);

                    //Si no existe
                    if (newGroup == null)
                    {
                        resultado.Mensaje = string.Format("El Grupo de Solicitudes {0} no existe", newGroup);
                    }
                    else
                    {
                        //Se busca si el role ya esta asignado
                        entity = gruposAsignados.Find(newGroup.Id.ToString());

                        //Si no se encontro
                        if (entity == null)
                        {
                            gruposAsignados.Add(newGroup);
                        }
                    }
                }

            }
            else //Si es una baja
            {
                foreach (string perfil in grupos)
                {
                    entity = gruposAsignados.Find(perfil);

                    if (entity == null)
                    {
                        //resultado.Mensaje = string.Format("El role {0} no existe", request.IdPerfil.ToString());
                    }
                    else
                    {
                        gruposAsignados.Remove(entity);
                    }
                }
            }

            if (!string.IsNullOrEmpty(resultado.Mensaje))
            {
                return;
            }

            try
            {
                usuarioBL.SetGruposSeguim(user, gruposAsignados);
            }
            catch (Exception ex)
            {
                resultado.Mensaje = string.Format("Ha ocurrido un error al procesar el Grupo de Seguimiento. Detalle: {0}", ex.Message);
            }

            resultado.Exito = true;
        }
    }

    private void ProcesarGrupoSolicitudes(GrupoSolicitudesRequest request, bool isNew, Resultado resultado)
    {
        PhalanxBL.PhxUserBusiness usuarioBL = new PhalanxBL.PhxUserBusiness();
        string usuario = string.Format("{0}\\{1}", request.Dominio, request.Usuario);

        //Se valida si existe el usuario
        PhxUserEntity user = usuarioBL.GetUserByDomUsr(usuario);

        if (user == null)
        {
            resultado.Mensaje = string.Format("El usuario {0} no está registrado", usuario);
        }
        else
        {
            RequestGroupBusiness groupBL = new RequestGroupBusiness();
            RequestGroupEntityCollection list = groupBL.GetAll();
            RequestGroupEntity entity = null;

            string[] grupos = request.IdGrupos.Split(',');

            RequestGroupEntityCollection gruposAsignados = new RequestGroupEntityCollection();
            //Se cargan los roles del usuario

            foreach (PhxUserGroupEntity r in user.PhxUsersGroupsList)
            {
                gruposAsignados.Add(r.RqstGrp);
            }

            //Si es un nuevo rol
            if (isNew)
            {
                foreach (string grupo in grupos)
                {
                    //Se busca el role recibido
                    RequestGroupEntity newGroup = list.Find(grupo);

                    //Si no existe
                    if (newGroup == null)
                    {
                        resultado.Mensaje = string.Format("El Grupo de Solicitudes {0} no existe", newGroup);
                    }
                    else
                    {
                        //Se busca si el role ya esta asignado
                        entity = gruposAsignados.Find(newGroup.Id.ToString());

                        //Si no se encontro
                        if (entity == null)
                        {
                            gruposAsignados.Add(newGroup);
                        }
                    }
                }

            }
            else //Si es una baja
            {
                foreach (string perfil in grupos)
                {
                    entity = gruposAsignados.Find(perfil);

                    if (entity == null)
                    {
                        //resultado.Mensaje = string.Format("El role {0} no existe", request.IdPerfil.ToString());
                    }
                    else
                    {
                        gruposAsignados.Remove(entity);
                    }
                }
            }

            if (!string.IsNullOrEmpty(resultado.Mensaje))
            {
                return;
            }

            try
            {
                usuarioBL.SetGrupos(user, gruposAsignados);
            }
            catch (Exception ex)
            {
                resultado.Mensaje = string.Format("Ha ocurrido un error al procesar el Grupo de Solicitudes. Detalle: {0}", ex.Message);
            }

            resultado.Exito = true;
        }
    }

    private void ProcesarPerfil(PerfilRequest request, bool isNew, Resultado resultado)
    {
        PhalanxBL.PhxUserBusiness usuarioBL = new PhalanxBL.PhxUserBusiness();
        string usuario = string.Format("{0}\\{1}", request.Dominio, request.Usuario);

        //Se valida si existe el usuario
        PhxUserEntity user = usuarioBL.GetUserByDomUsr(usuario);

        if (user == null)
        {
            resultado.Mensaje = string.Format("El usuario {0} no está registrado", usuario);
        }
        else
        {
            PhxRoleBusiness roleBL = new PhxRoleBusiness();
            PhxRoleEntityCollection list = roleBL.GetAll();
            PhxRoleEntity rol = null;

            string[] perfiles = request.IdPerfiles.Split(',');

            PhxRoleEntityCollection roles = new PhxRoleEntityCollection();
            //Se cargan los roles del usuario

            foreach (PhxRoleUserEntity r in user.PhxRolesUsersList)
            {
                roles.Add(r.PhxRole);
            }

            //Si es un nuevo rol
            if (isNew)
            {
                foreach (string perfil in perfiles)
                {
                    //Se busca el role recibido
                    PhxRoleEntity newRole = list.Find(perfil);

                    //Si no existe
                    if (newRole == null)
                    {
                        resultado.Mensaje = string.Format("El role {0} no existe", perfil);
                    }
                    else
                    {
                        //Se busca si el role ya esta asignado
                        rol = roles.Find(newRole.Id.ToString());

                        //Si no se encontro
                        if (rol == null)
                        {
                            roles.Add(newRole);
                        }
                    }
                }

            }
            else //Si es una baja
            {
                foreach (string perfil in perfiles)
                {
                    rol = roles.Find(perfil);

                    if (rol == null)
                    {
                        //resultado.Mensaje = string.Format("El role {0} no existe", request.IdPerfil.ToString());
                    }
                    else
                    {
                        roles.Remove(rol);
                    }
                }
            }

            if (!string.IsNullOrEmpty(resultado.Mensaje))
            {
                return;
            }

            try
            {
                usuarioBL.SetRoles(user, roles);
            }
            catch (Exception ex)
            {
                resultado.Mensaje = string.Format("Ha ocurrido un error al procesar el Perfil. Detalle: {0}", ex.Message);
            }

            resultado.Exito = true;
        }
    }

    private bool ValidarCadenaSeguridad(string cadena, Resultado resultado)
    {
        DatosAutenticacion datosAutenticacion = ObtenerDatosAutenticacion(cadena);

        PhxConfigBusiness pcb = new PhxConfigBusiness();

        PhxConfigEntity configParam = pcb.GetConfigParam(ConfigCodes.UsuariosAutorizadosWSBPM);

        string usuariosAutorizados = configParam != null ? configParam.LongTxtValue : null;

        if (usuariosAutorizados == null || !new List<string>(usuariosAutorizados.Split(',')).Contains(datosAutenticacion.Usuario))
        {
            resultado.Exito = false;
            resultado.Mensaje = "Usuario no autorizado";

            return false;
        }

        if (!Autenticar(datosAutenticacion.Dominio, datosAutenticacion.Usuario, datosAutenticacion.Password))
        {
            resultado.Exito = false;
            resultado.Mensaje = "Error al autenticar";

            return false;
        }

        return true;
    }

    private bool ValidarDatosAlta(AltaUsuarioRequest request, Resultado response)
    {
        bool ok = false;

        if (string.IsNullOrEmpty(request.Dominio))
        {
            response.Mensaje = "Se debe informar el Dominio";
            return ok;
        }

        if (string.IsNullOrEmpty(request.Usuario))
        {
            response.Mensaje = "Se debe informar el Usuario";
            return ok;
        }

        if (string.IsNullOrEmpty(request.Legajo))
        {
            response.Mensaje = "Se debe informar el Legajo";
            return ok;
        }

        if (string.IsNullOrEmpty(request.NombreCompleto))
        {
            response.Mensaje = "Se debe informar el Nombre del Usuario";
            return ok;
        }

        if (string.IsNullOrEmpty(request.Email))
        {
            response.Mensaje = "Se debe informar el Email";
            return ok;
        }

        ok = true;
        return ok;
    }

    private bool ValidarDatosBaja(BajaUsuarioRequest request, Resultado response)
    {
        bool ok = false;

        if (string.IsNullOrEmpty(request.Dominio))
        {
            response.Mensaje = "Se debe informar el Dominio";
            return ok;
        }

        if (string.IsNullOrEmpty(request.Usuario))
        {
            response.Mensaje = "Se debe informar el Usuario";
            return ok;
        }

        ok = true;
        return ok;
    }

    private struct DatosAutenticacion
    {
        public string Dominio;
        public string Usuario;
        public string Password;
    }

    #endregion
}

public class Resultado
{
    private bool exito;
    private string mensaje;

    public bool Exito
    {
        set { exito = value; }
        get { return exito; }
    }

    public string Mensaje
    {
        set { mensaje = value; }
        get { return mensaje; }
    }
}

