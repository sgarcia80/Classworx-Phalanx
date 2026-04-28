using System;
using System.Collections.Generic;
using System.Text;

namespace PhalanxCommon.Entities
{
    public class SolicitudPwdEntity : BaseEntity
    {
        private int _Id;
        private int _IdAmbiente;
        private string _Ambiente;
        private string _DetallePwd;
        private string _EstadoSolicitud;
        private DateTime _FechaSolicitud;
        private DateTime? _FechaUltimoEstado;
        private string _Solicitante;
        private DateTime? _FechaCambio;
        private string _UsuarioCambio;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public int IdAmbiente
        {
            get { return _IdAmbiente; }
            set { _IdAmbiente = value; }
        }

        public string Ambiente
        {
            get { return _Ambiente; }
            set { _Ambiente = value; }
        }

        public string DetallePwd
        {
            get { return _DetallePwd; }
            set { _DetallePwd = value; }
        }

        public string EstadoSolicitud
        {
            get { return _EstadoSolicitud; }
            set { _EstadoSolicitud = value; }
        }
 
        public DateTime FechaSolicitud
        {
            get { return _FechaSolicitud; }
            set { _FechaSolicitud = value; }
        }

        public DateTime? FechaUltimoEstado
        {
            get { return _FechaUltimoEstado; }
            set { _FechaUltimoEstado = value; }
        }

        public string Solicitante
        {
            get { return _Solicitante; }
            set { _Solicitante = value; }
        }

        public DateTime? FechaCambio
        {
            get { return _FechaCambio; }
            set { _FechaCambio = value; }
        }

        public string UsuarioCambio
        {
            get { return _UsuarioCambio; }
            set { _UsuarioCambio = value; }
        }

        public void SplitFechaUsrCambio(string FechaUsrCambio)
        {
            string[] strFechaUsrCambio = FechaUsrCambio.Split('|');
            int i = 0;
            foreach (string cadena in strFechaUsrCambio)
            {
                if (i == 0)
                {
                    System.Globalization.DateTimeFormatInfo dtfi = new
    System.Globalization.DateTimeFormatInfo();
                    dtfi.ShortDatePattern = "dd/MM/yyyy HH:mm:ss";
                    this._FechaCambio = Convert.ToDateTime(cadena, dtfi);
                }
                else
                {
                    this._UsuarioCambio = cadena;
                }
                i++;
            }
        }
        public override string Key
        {
            get
            {
                return _Id.ToString();
            }
            set
            {
                _Id = Convert.ToInt32(value);
            }
        }
    }
}
