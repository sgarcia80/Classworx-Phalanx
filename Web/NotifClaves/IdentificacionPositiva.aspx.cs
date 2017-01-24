using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using NDCBL;
using NDCCommon.Entities;
using System.Collections.Generic;

public partial class IdentificacionPositiva : System.Web.UI.Page
{
    private Random random;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int ticketId = 0;

            if (Session["ticketId"] != null)
            {
                int.TryParse(Session["ticketId"].ToString(), out ticketId);
            }

            //Si no se recibió un ticket de NOTIFICACIÓN DE CLAVE es de BLANQUEO.
            bool esNotif = (Session["externo"] != null);
            string tipodocumento = string.Empty;
            string nrodocumento = string.Empty;

            if (esNotif)
            {
                Meta4ClassWorxUsuariosBusiness m4ub = new Meta4ClassWorxUsuariosBusiness();
                string usuario = Session["Usuario"].ToString();

                IList<Meta4ClassWorxUsuariosEntity> usuarios = m4ub.GetUser(usuario);
                if (usuarios != null && usuarios.Count > 0)
                {
                    tipodocumento = usuarios[0].TipoDocumento;
                    nrodocumento = usuarios[0].Num_Documento;
                }

                btnVolver.PostBackUrl = Request.UrlReferrer.AbsolutePath;
            }
            else
            {
                TicketNotificacionClaveBusiness tncb = new TicketNotificacionClaveBusiness();
                TicketNotificacionClaveEntity ticket = tncb.GetById(ticketId);

                if (ticket.Errado)
                {
                    Response.Redirect(FormsAuthentication.LoginUrl);

                    return;
                }

                tipodocumento = ticket.TipoDocumento;
                nrodocumento = ticket.Documento;
            }

            if (string.IsNullOrEmpty(tipodocumento) && string.IsNullOrEmpty(nrodocumento))
            {
                lbMensaje.Text = esNotif ? "No se ha encontrado la información del Empleado en RRHH" : 
                    "No se ha encontrado el ticket de notificacion de clave";

                pnlIdentificacion.Visible = false;
                btnAceptar.Visible = false;

                return;
            }
            
            Meta4LegajoBusiness m4lb = new Meta4LegajoBusiness();
            Meta4LegajoEntity legajo = m4lb.GetByDocumento(tipodocumento, nrodocumento);

            if (legajo == null)
            {
                lbMensaje.Text = "No se ha encontrado la información del Empleado en RRHH";

                pnlIdentificacion.Visible = false;
                btnAceptar.Visible = false;

                btnVolver.PostBackUrl = Request.UrlReferrer.AbsolutePath;
                return;
            }

            //random = new Random(int.Parse(legajo.Documento));
            random = new Random((int)Session["seed"]);

            CrearMultipleChoice(legajo);
        }
    }

    private void CrearMultipleChoice(Meta4LegajoEntity legajo)
    {
        CrearOpcionesDireccion(legajo);
        CrearOpcionesFechaNacimiento(legajo.FechaNacimiento);
        CrearOpcionesDocumento(legajo.Documento);
    }

    private void CrearOpcionesDireccion(Meta4LegajoEntity legajo)
    {
        Meta4LegajoBusiness m4lb = new Meta4LegajoBusiness();

        IList<string> calles = m4lb.GetCalles();

        ArrayList opciones = new ArrayList(4);
        opciones.Add(legajo.Calle);

        while (opciones.Count < 4)
        {
            int index = random.Next(0, calles.Count);

            if (!opciones.Contains(calles[index]))
                opciones.Add(calles[index]);
        }

        //opciones.Sort(new RandomComparer());

        foreach(string calle in Shuffle(opciones.ToArray(), 10))
            rblCalle.Items.Add(new ListItem(calle, calle));

        ArrayList numeros = new ArrayList(4);

        numeros.Add(legajo.Numero);

        int numero = 0;

        int.TryParse(legajo.Numero, out numero);

        if (numero < 0)
            numero = 0;

        while (numeros.Count < 4)
        {
            int n = numero + (random.Next(1, 101) * (random.Next(2) == 0 ? -1 : 1));

            if (n > 0 && !numeros.Contains(n.ToString()))
                numeros.Add(n.ToString());
        }

        //numeros.Sort(new RandomComparer());

        foreach (string num in Shuffle(numeros.ToArray(), 20))        
            rblNumero.Items.Add(new ListItem(num, num));
    }

    private void CrearOpcionesFechaNacimiento(DateTime fecha)
    {
        //Random random = new Random(TimeSpan.FromTicks(fecha.Ticks).Seconds);

        ArrayList fechas = new ArrayList(4);
        //List<DateTime> fechas = new List<DateTime>(4);

        fechas.Add(fecha.ToString("dd/MM/yyyy"));

        int anio = fecha.Year + ( random.Next(1, 3) * ( random.Next(2) == 0 ? -1 : 1));

        int mes;

        while (true)
        {
            mes = random.Next(1, 13);

            if (mes != fecha.Month && DateTime.DaysInMonth(fecha.Year, mes) >= fecha.Day)
                break;
        }

        int dia;

        while (true)
        {
            dia = random.Next(1, 32);

            if (dia != fecha.Day && DateTime.DaysInMonth(anio, fecha.Month) >= dia && DateTime.DaysInMonth(anio, mes) >= dia)
                break;
        }

        fechas.Add(new DateTime(fecha.Year, mes, fecha.Day).ToString("dd/MM/yyyy"));
        fechas.Add(new DateTime(anio, fecha.Month, dia).ToString("dd/MM/yyyy"));
        fechas.Add(new DateTime(anio, mes, dia).ToString("dd/MM/yyyy"));

        //fechas.Sort(new RandomComparer());

        foreach (string date in Shuffle(fechas.ToArray(), 30))
            rblFechas.Items.Add(new ListItem(date, date));
    }

    private void CrearOpcionesDocumento(string documento)
    {
        Meta4LegajoBusiness m4lb = new Meta4LegajoBusiness();

        IList<string> tipos = m4lb.GetTiposDocumento();

        ArrayList opciones = new ArrayList();
        
        foreach (string tipo in tipos)
            opciones.Add(tipo);

        //opciones.Sort(new RandomComparer());

        foreach (string tipo in Shuffle(opciones.ToArray(), 40))
            rblTipoDocumento.Items.Add(new ListItem(tipo, tipo));

        ArrayList documentos = new ArrayList(4);

        documentos.Add(documento);

        int doc;

        doc = int.Parse(documento);

        while (documentos.Count < 4)
        {
            int n = doc + (random.Next(1, 101) * (random.Next(2) == 0 ? -1 : 1));

            if (n > 0 && !documentos.Contains(n.ToString()))
                documentos.Add(n.ToString());
        }

        foreach (string num in Shuffle(documentos.ToArray(), 50))
            rblDocumento.Items.Add(new ListItem(num, num));
    }
    
    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        int ticketId = (int) Session["ticketId"];

        string tipodocumento = string.Empty;
        string nrodocumento = string.Empty;

        //Si ingreso por Notificacion
        bool esNotif = (Session["externo"] != null);

        if (esNotif)
        {
            Meta4ClassWorxUsuariosBusiness m4ub = new Meta4ClassWorxUsuariosBusiness();
            string usuario = Session["Usuario"].ToString();

            IList<Meta4ClassWorxUsuariosEntity> usuarios = m4ub.GetUser(usuario);
            if (usuarios != null && usuarios.Count > 0)
            {
                tipodocumento = usuarios[0].TipoDocumento;
                nrodocumento = usuarios[0].Num_Documento;
            }
        }
        else
        {
            TicketNotificacionClaveBusiness tncb = new TicketNotificacionClaveBusiness();

            TicketNotificacionClaveEntity ticket = tncb.GetById(ticketId);

            tipodocumento = ticket.TipoDocumento;
            nrodocumento = ticket.Documento;
        }

        Meta4LegajoBusiness m4lb = new Meta4LegajoBusiness();
        Meta4LegajoEntity legajo = m4lb.GetByDocumento(tipodocumento, nrodocumento);

        if (VerificarRespuestas(legajo))
        {
            if (esNotif)
            {
                string url = string.Format("DetalleTicket.aspx?id={0}&tipo={1}", ticketId, "BLANQUEO");
                Response.Redirect(url);
            }
            else
            {
                Session["id"] = ticketId;

                Response.Redirect("tycip.aspx");
            }
        }
        else
        {
            TicketNotificacionBlanqueoEntity ticket = null;

            if (esNotif)
            {
                TicketNotificacionBlanqueoBusiness tnb = new TicketNotificacionBlanqueoBusiness();
                ticket = tnb.Cancelar(ticketId);
            }

            if (ticket != null && ticket.FechaCancelado.HasValue)
            {
                lbMensaje.Text = "Se ha superado los intentos. Debe solicitar el blanqueo nuevamente.";
                btnAceptar.Enabled = false;
            }
            else
            {
                lbMensaje.Text = "No se pudo realizar la identificación positiva con éxito";
            }

            btnAceptar.Visible = false;
        }
    }

    private bool VerificarRespuestas(Meta4LegajoEntity legajo)
    {
        DateTime fechaNacimiento;

        if (!DateTime.TryParse(rblFechas.SelectedValue, out fechaNacimiento))
            return false;

        return legajo.FechaNacimiento == fechaNacimiento
                && legajo.Calle == rblCalle.SelectedValue
                && legajo.Numero == rblNumero.SelectedValue
                && legajo.TipoDocumento == rblTipoDocumento.SelectedValue
                && legajo.Documento == rblDocumento.SelectedValue;
    }

    private T[] Shuffle<T>(T[] OriginalArray, int seed)
    {
        SortedList matrix = new SortedList();
        Random r = new Random(seed);

        for (int x = 0; x <= OriginalArray.GetUpperBound(0); x++)
        {
            int i = r.Next();

            while (matrix.ContainsKey(i)) { i = r.Next(); }

            matrix.Add(i, OriginalArray[x]);
        }

        T[] OutputArray = new T[OriginalArray.Length];

        matrix.Values.CopyTo(OutputArray, 0);

        return OutputArray;
    }

    /*
    private class RandomComparer : IComparer
    {
        private static Random random = new Random();

        #region IComparer Members

        public int Compare(object x, object y)
        {
            string xs = (string) x;
            string ys = (string)y;

            if (xs.Equals(ys))
                return 0;

            return random.Next(-1, 1);
        }

        #endregion
    }
     * */
    
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Response.Redirect("AltaTemprana.aspx"); 
    }
}
