using System;
using System.Collections.Generic;
using System.Text;

namespace PhalanxCommon.Entities
{
    [Serializable]
    public class ReporteDeUsoEntity : BaseEntity
    {
        private PasswordRequestEntity _pwd_rqst;
        public ReporteDeUsoEntity(PasswordRequestEntity PwdRqst)
        {
            _pwd_rqst = PwdRqst;
        }
        public string PasswordDesc
        {
            get
            {
                string tmpString = "";

                if (_pwd_rqst.User is WinLocalUserEntity)
                {
                    tmpString = ((WinLocalUserEntity)_pwd_rqst.User).Domain + @"\" + ((WinLocalUserEntity)_pwd_rqst.User).WinPc.Name + @"\" + _pwd_rqst.User.Username;
                }

                if (_pwd_rqst.User is ApplicationUserEntity)
                {
                    tmpString = ((ApplicationUserEntity)_pwd_rqst.User).ApplicationName + @"\" + _pwd_rqst.User.Username;
                }

                if (_pwd_rqst.User is DatabaseUserEntity)
                {
                    tmpString = ((DatabaseUserEntity)_pwd_rqst.User).Db.Type.Name + @"\" + ((DatabaseUserEntity)_pwd_rqst.User).DBName + @"\" + _pwd_rqst.User.Username;
                }

                if (_pwd_rqst.User is UnixUserEntity)
                {
                    tmpString = ((UnixUserEntity)_pwd_rqst.User).Unix.ServerName + @"\" + _pwd_rqst.User.Username;
                }
                if (_pwd_rqst.User is AS400UserEntity)
                {
                    tmpString = ((AS400UserEntity)_pwd_rqst.User).AS400.ServerName + @"\" + _pwd_rqst.User.Username;
                }
                if (_pwd_rqst.User is CommunicationDeviceUserEntity)
                {
                    tmpString = ((CommunicationDeviceUserEntity)_pwd_rqst.User).CommunicationDeviceName + @"\" + _pwd_rqst.User.Username;
                }
                if (_pwd_rqst.User is ATMUserEntity)
                {
                    tmpString = ((ATMUserEntity)_pwd_rqst.User).ATMName + @"\" + _pwd_rqst.User.Username;
                }
                return tmpString;
            }
        }
        public string Ambiente
        {
            get
            {
                return _pwd_rqst.User.UserType.Desc;
            }
        }
        public string Solicitante
        {
            get
            {
                return _pwd_rqst.RqstUsrFullName;
            }
        }
        public string LegajoSolic
        {
            get { return this._pwd_rqst.RqstUser.FileNumber; }
        }
        public string FuncionSolic
        {
            get { return this._pwd_rqst.RqstUser.Function; }
        }
        public string InternoSolic
        {
            get { return this._pwd_rqst.RqstUser.ExtensionNumber; }
        }
        public string EdifPisoSolic
        {
            get
            {
                return this._pwd_rqst.RqstUser.BuildingAdress + " "
                    + this._pwd_rqst.RqstUser.BuildingFloor;
            }
        }
        public string SectorSolic
        {
            get { return this._pwd_rqst.RqstUser.Branch; }
        }
        public string RelacionLabSolic
        {
            get
            {
                string Relacion = "";
                if (this._pwd_rqst.RqstUser.RelationType != null)
                {
                    // I=interno - E=Externo - P=Proveedor
                    switch (this._pwd_rqst.RqstUser.RelationType)
                    {
                        case "E":
                            Relacion = "Externo";
                            break;
                        case "I":
                            Relacion = "Interno";
                            break;
                        case "P":
                            Relacion = "Proveedor";
                            break;
                        default:
                            Relacion = "";
                            break;
                    }
                }
                return Relacion;
            }
        }
        public string SolicDir
        {
            get { return _pwd_rqst.RqstUser.BuildingAdress + _pwd_rqst.RqstUser.BuildingFloor; }
        }
        public string FolioPwd
        {
            get
            {
                return this._pwd_rqst.UserPassword.Id.ToString();
            }
        }
        public string FechaHoraSolicitud
        {
            get { return _pwd_rqst.RequestDate.ToString("dd/MM/yyyy HH:mm:ss"); }
        }
        public string Autorizador
        {
            get
            {
                if (_pwd_rqst.Auth1Usr == null)
                {
                    return "";
                }
                else { return _pwd_rqst.Auth1Usr.Fullname; }
            }
        }
        public string FechaHoraAutorizacion
        {
            get
            {
                if (_pwd_rqst.Auth1Date == null)
                {
                    return "";
                }
                else
                {
                    return _pwd_rqst.Auth1Date.Value.ToString("dd/MM/yyyy HH:mm:ss");
                }
            }
        }
        public string AutorizadorDesc
        {
            get
            {
                if (_pwd_rqst.AuthDesc == null)
                {
                    return "";
                }
                else
                { return _pwd_rqst.AuthDesc; }
            }
        }
        public string SolicDesc
        {
            get
            {
                if (_pwd_rqst.RequestDesc == null)
                {
                    return "";
                }
                else
                { return _pwd_rqst.RequestDesc; }
            }
        }
        public string DevolDesc
        {
            get
            {
                if (_pwd_rqst.ReturnNote == null)
                {
                    return "";
                }
                else
                { return _pwd_rqst.ReturnNote; }
            }
        }
        public string CierreDesc
        {
            get
            {
                if (_pwd_rqst.CloseNote == null)
                {
                    return "";
                }
                else
                { return _pwd_rqst.CloseNote; }
            }
        }
        public string FechaHoraCierre
        {
            get
            {
                if (_pwd_rqst.CloseDate == null)
                {
                    return "";
                }
                else
                {
                    return _pwd_rqst.CloseDate.Value.ToString("dd/MM/yyyy HH:mm:ss");
                }
            }
        }
        public string UsuarioCierre
        {
            get
            {
                if (_pwd_rqst.CloseUser == null)
                {
                    return "";
                }
                else
                { return _pwd_rqst.CloseUser.Fullname; }
            }
        }
        public string FechaHoraExpiracion
        {
            get
            {
                if (_pwd_rqst.ExpirationDate == null)
                {
                    return "";
                }
                else
                {
                    return _pwd_rqst.ExpirationDate.Value.ToString("dd/MM/yyyy HH:mm:ss");
                }
            }
        }
        public string FechaHoraDevolucion
        {
            get
            {
                if (_pwd_rqst.ReturnDate == null)
                {
                    return "";
                }
                else
                {
                    return _pwd_rqst.ReturnDate.Value.ToString("dd/MM/yyyy HH:mm:ss");
                }
            }
        }
        public string UsuarioDevolucion
        {
            get
            {
                if (_pwd_rqst.ReturnUser == null)
                {
                    return "";
                }
                else
                {
                    return _pwd_rqst.ReturnUser.Fullname;
                }
            }
        }
        public string EstadoSolicitud
        {
            get
            {
                return _pwd_rqst.RqstState.RqstStateDesc;
            }
        }
        public string TiempoDado
        {
            get
            {
                if (_pwd_rqst.HoursGiven == 0)
                {
                    return "";
                }
                else
                {
                    string tiempodado = _pwd_rqst.HoursGiven.ToString() + " ";
                    switch (_pwd_rqst.UnitGiven)
                    {
                        case "H":
                            tiempodado += "horas";
                            break;
                        case "D":
                            tiempodado += "días";
                            break;
                        default:
                            tiempodado += "";
                            break;
                    }
                    return tiempodado;
                }
            }
        }
        public string TiempoSolicitado
        {
            get
            {
                if (_pwd_rqst.HoursRequested == 0)
                {
                    return "";
                }
                else
                {
                    string tiempodado = _pwd_rqst.HoursRequested.ToString() + " ";
                    switch (_pwd_rqst.UnitRequested)
                    {
                        case "H":
                            tiempodado += "horas";
                            break;
                        case "D":
                            tiempodado += "días";
                            break;
                        default:
                            tiempodado += "";
                            break;
                    }
                    return tiempodado;
                }
            }
        }
        public string FechaHoraCambio
        {
            get
            {
                if (_pwd_rqst.CambioLoaded = false || _pwd_rqst.ChangePostReturn == null)
                {
                    return "";
                }
                else
                {
                    return _pwd_rqst.ChangePostReturn.DChange.ToString("dd/MM/yyyy HH:mm:ss");
                }
            }
        }
        public string UsuarioCambio
        {
            get
            {
                if (_pwd_rqst.CambioLoaded = false || _pwd_rqst.ChangePostReturn == null)
                {
                    return "";
                }
                else
                { return _pwd_rqst.ChangePostReturn.PhxUser.Fullname; }
            }
        }
        /*public string 
        {
            get { return _pwd_rqst.; }
        }*/
        /*public string 
        {
            get { return _pwd_rqst.; }
        }*/

        public override string Key
        {
            get
            {
                return this._pwd_rqst.Id.ToString();
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }
    }
}
