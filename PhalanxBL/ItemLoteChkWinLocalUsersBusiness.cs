using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using PhalanxDAL.Factories;

namespace PhalanxBL
{
    public class ItemLoteChkWinLocalUsersBusiness
    {
        public ItemLoteChkWinLocalUsersEntityCollection GetAll(LoteChkWinLocalUsersEntity Lote)
        {
            ItemLoteChkWinLocalUsersFactory ItmLoteF = new ItemLoteChkWinLocalUsersFactory();
            ItmLoteF.FilLote = Lote;
            return ItmLoteF.GetAll();
        }
        public ItemLoteChkWinLocalUsersEntityCollection BuscaItemsDeLote(LoteChkWinLocalUsersEntity Lote, bool? ChkPwdOK
            ,bool? AccesoNombre, bool? AccesoIP)
        {
            ItemLoteChkWinLocalUsersFactory ItmLoteF = new ItemLoteChkWinLocalUsersFactory();
            ItmLoteF.FilLote = Lote;
            if (ChkPwdOK != null)
            {
                ItmLoteF.FilChkPwdOK = ChkPwdOK.Value;
            }
            if (AccesoIP != null)
            {
                ItmLoteF.FilAccesoIP = AccesoIP.Value;
            }
            if (AccesoNombre != null)
            {
                ItmLoteF.FilAccesoNombre = AccesoNombre.Value;
            }
            return ItmLoteF.GetAll();
        }
        public ItemLoteChkWinLocalUsersEntityCollection GetAll(LoteChkWinLocalUsersEntity Lote, bool FilFechaChkNull)
        {
            ItemLoteChkWinLocalUsersFactory ItmLoteF = new ItemLoteChkWinLocalUsersFactory();
            ItmLoteF.FilFechaChkNull = FilFechaChkNull;
            ItmLoteF.FilLote = Lote;
            return ItmLoteF.GetAll();
        }
        public ItemLoteChkWinLocalUsersEntityCollection BuscarItemsParaProcesar(LoteChkWinLocalUsersEntity Lote)
        {
            return GetAll(Lote, true);
        }

        internal void Update(ItemLoteChkWinLocalUsersEntity ItemLote)
        {
            ItemLoteChkWinLocalUsersFactory ItmLoteF = new ItemLoteChkWinLocalUsersFactory();
            ItmLoteF.Update(ItemLote);
        }
        public bool DesactivarEquipo(ItemLoteChkWinLocalUsersEntity ItemChkWLU)
        {
            WinPCEntity WinPC = ItemChkWLU.WinLocalUser.WinPc;
            WinPCsFactory WPCF = new WinPCsFactory();
            if (!WPCF.Refresh(WinPC))
            {
                return false;
            }
            if (!WinPC.Active)
            {
                return false;
            }
            WinPC.Active = false;
            if (!WPCF.Update(WinPC))
            {
                return false;
            }
            ItemChkWLU.Accion = new AccionItemChkWinLocalUserBusiness().GetDesactivarEquipo();
            ItemLoteChkWinLocalUsersFactory ItmLChkWLU = new ItemLoteChkWinLocalUsersFactory();
            ItmLChkWLU.Update(ItemChkWLU);
            return true;
        }
        public bool SacarChkPwd(ItemLoteChkWinLocalUsersEntity ItemChkWLU)
        {
            UserPasswordEntity UPE = ItemChkWLU.WinLocalUser.UserPassword;
            UsersPasswordsFactory UPF = new UsersPasswordsFactory();
            if (!UPF.Refresh(UPE))
            {
                return false;
            }
            if (!UPE.Checkeable)
            {
                return false;
            }
            UPE.Checkeable = false;
            if (!UPF.Update(UPE))
            {
                return false;
            }
            ItemChkWLU.Accion = new AccionItemChkWinLocalUserBusiness().GetSacarMarcaChkUsr();
            ItemLoteChkWinLocalUsersFactory ItmLChkWLUF = new ItemLoteChkWinLocalUsersFactory();
            ItmLChkWLUF.Update(ItemChkWLU);
            return true;

        }
        public bool SacarChkWinPC(ItemLoteChkWinLocalUsersEntity ItemChkWLU)
        {
            WinPCEntity UPE = ItemChkWLU.WinLocalUser.WinPc;
            WinPCsFactory UPF = new WinPCsFactory();
            if (!UPF.Refresh(UPE))
            {
                return false;
            }
            if (!UPE.Checkable)
            {
                return false;
            }
            UPE.Checkable = false;
            if (!UPF.Update(UPE))
            {
                return false;
            }
            ItemChkWLU.Accion = new AccionItemChkWinLocalUserBusiness().GetSacarMarcaChkEquipo();
            ItemLoteChkWinLocalUsersFactory ItmLChkWLUF = new ItemLoteChkWinLocalUsersFactory();
            ItmLChkWLUF.Update(ItemChkWLU);
            return true;

        }
        public bool RepararPwd(ItemLoteChkWinLocalUsersEntity ItemChkWLU)
        {
            WinLocalUserEntity WLUE = ItemChkWLU.WinLocalUser;
            WinLocalUserBusiness WLUB = new WinLocalUserBusiness();
            if (!WLUB.RepararPwd(WLUE))
            {
                return false;
            }
            ItemChkWLU.Accion = new AccionItemChkWinLocalUserBusiness().GetRepararPwd();
            ItemLoteChkWinLocalUsersFactory ItmLChkWLUF = new ItemLoteChkWinLocalUsersFactory();
            ItmLChkWLUF.Update(ItemChkWLU);
            return true;



        }
        public void Refresh(ItemLoteChkWinLocalUsersEntity ItemChk)
        {
            new ItemLoteChkWinLocalUsersFactory().Refresh(ItemChk);
        }
    }
}
