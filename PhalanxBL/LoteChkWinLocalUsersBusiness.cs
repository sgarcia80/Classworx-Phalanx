using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using PhalanxCommon.Collections;
using PhalanxDAL.Factories;
using PhalanxNAL;

namespace PhalanxBL
{
    public class LoteChkWinLocalUsersBusiness
    {
        private int? _filNroLote = null;
        public int FilNroLote
        {
            set { _filNroLote = value; }
        }
        public bool Save(LoteChkWinLocalUsersEntity Lote
            , WinLocalUserEntityCollection WinUsrs)
        {
            LoteChkWinLocalUsersFactory LoteF = new LoteChkWinLocalUsersFactory();
            return LoteF.Save(Lote, WinUsrs);
        }

        public LoteChkWinLocalUsersEntityCollection GetAll()
        {
            LoteChkWinLocalUsersFactory LoteF = new LoteChkWinLocalUsersFactory();
            if (_filNroLote != null)
            {
                LoteF.FilNroLote = this._filNroLote.Value;
            }
            return LoteF.GetAll();
        }
        public LoteChkWinLocalUsersEntityCollection BuscaLoteParaProcesar()
        {
            LoteChkWinLocalUsersFactory LoteF = new LoteChkWinLocalUsersFactory();
            LoteF.FilFProgramadaHasta = DateTime.Now;
            LoteF.FilFFinNull = true;
            return LoteF.GetAll();

        }
        public void ProcesarLote(LoteChkWinLocalUsersEntity Lote)
        {
            WinLocalUserBusiness WinLocUsrBL = new WinLocalUserBusiness();
            UsersPasswordBusiness UsrPwdBL = new UsersPasswordBusiness();
            ItemLoteChkWinLocalUsersBusiness ItmLoteBL = new ItemLoteChkWinLocalUsersBusiness();
            ItemLoteChkWinLocalUsersEntityCollection ItemsLote = ItmLoteBL.BuscarItemsParaProcesar(Lote);
            LoteChkWinLocalUsersFactory LoteF = new LoteChkWinLocalUsersFactory();
            NPc objNPC = new NPc();
            if (Lote.FechaInicioProceso == null)
            {
                Lote.FechaInicioProceso = DateTime.Now;
                LoteF.Update(Lote);
            }
            for (int i = 0; i < ItemsLote.Count; i++)
            {
                // chequea usr/pwd con datos guardados
                bool ChkPwdOK = true;
                bool? NombreEqOK = null;
                bool? IPEqOK = null;
                bool? UsrNameOK = null;
                string NombreEquipo = "";
                //string ResultadoChk = "Se verificó la contraseña";
                NUser NalUser = new NUser();
                string DomainName = ItemsLote[i].WinLocalUser.WinPc.WinDomain.NtName;
                string ComputerName = ItemsLote[i].WinLocalUser.WinPc.Name;
                string UserName = ItemsLote[i].WinLocalUser.Username;
                string Password = WinLocUsrBL.DecryptPassword(ItemsLote[i].WinLocalUser.UserPassword.Password);
                uint ChkResult = NalUser.validatePassword(DomainName, ComputerName, UserName, Password);
                switch (ChkResult)
                {
                    case common.CPASS_ERR_UNKNOWN:
                        //ResultadoChk = "Error desconocido";
                        ChkPwdOK = false;
                        break;
                    case common.CPASS_ERR_INVALID_COMPUTER:
                        //ResultadoChk = "Nombre de equipo inválido";
                        ChkPwdOK = false;
                        //NombreEqOK.Value = false;
                        break;
                    case common.CPASS_ERR_INVALID_PASSWORD:
                        //ResultadoChk = "Contraseña inválida";
                        ChkPwdOK = false;
                        break;
                    case common.CPASS_ERR_INVALID_USER:
                        //ResultadoChk = "El usuario no existe en el equipo";
                        ChkPwdOK = false;
                        break;
                }

                // si OK actualiza datos y listo
                // si NOK:
                if (!ChkPwdOK)
                {
                    // comprueba ping por nombre de equipo
                    NombreEqOK = objNPC.PingOK(ComputerName);
                    // si OK
                    if (NombreEqOK.Value)
                    {
                        // verificar si el nombre de usuario existe en el equipo
                        UsrNameOK = this.FindUser(ItemsLote[i].WinLocalUser.Domain, ItemsLote[i].WinLocalUser.PCName, ItemsLote[i].WinLocalUser.Username);
                    }
                    // si NOK:
                    else
                    {
                        string IPEquipo = ItemsLote[i].WinLocalUser.WinPc.PcIP;
                        // prueba ping por IP
                        if (IPEquipo != "")
                        {
                            IPEqOK = objNPC.PingOK(IPEquipo);
                            if (IPEqOK.Value)
                            {
                                // si OK busca nombre
                                NombreEquipo = objNPC.ResolveHostName(IPEquipo);
                            }
                            // si NOK actualiza datos
                        }
                    }
                }

                // actualizo los datos
                DateTime Ahora = DateTime.Now;
                ItemsLote[i].FechaChk = Ahora;
                ItemsLote[i].WinLocalUser.UserPassword.DLastChk = Ahora;
                ItemsLote[i].ChkPwd = ChkPwdOK;
                ItemsLote[i].ChkPingNombreEquipo = NombreEqOK;
                ItemsLote[i].ChkPingIPEquipo = IPEqOK;
                ItemsLote[i].ChkUsername = UsrNameOK;
                if (NombreEquipo != "")
                {
                    ItemsLote[i].NombreEquipoPingIP = NombreEquipo;
                }
                ItmLoteBL.Update(ItemsLote[i]);
                // si OK actualiza datos y listo
                if (ChkPwdOK)
                {
                    UsrPwdBL.Update(ItemsLote[i].WinLocalUser.UserPassword);
                }
            }
            if (Lote.FechaFinProceso == null && ItmLoteBL.BuscarItemsParaProcesar(Lote).Count == 0)
            {
                Lote.FechaFinProceso = DateTime.Now;
                LoteF.Update(Lote);
            }
        }
        public void Refresh(LoteChkWinLocalUsersEntity Lote)
        {
            new LoteChkWinLocalUsersFactory().Refresh(Lote);
        }

        public bool Baja(LoteChkWinLocalUsersEntity Lote)
        {
            return new LoteChkWinLocalUsersFactory().Baja(Lote);
            
        }

        public void ProcesarLotesAChequear()
        {
            LoteChkWinLocalUsersFactory LotesF = new LoteChkWinLocalUsersFactory();
            LotesF.FilFProgramadaHasta = DateTime.Now;
            LotesF.FilFFinNull = true;
            LoteChkWinLocalUsersEntityCollection LotesAProcesar = LotesF.GetAll();
            foreach (LoteChkWinLocalUsersEntity Lote in LotesAProcesar)
            {
                this.ProcesarLote(Lote);
            }
        }
        public bool FindUser(string domainname, string computername, string username)
        {
            NUser NalUser = new NUser();
            return NalUser.FindUser(domainname, computername, username);
        }
    }
}
