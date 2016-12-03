using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using PhalanxDAL.Factories;

namespace PhalanxBL
{
    public class vwHistPwdVisBusiness
    {
        /*
        public vwHistPwdVisEntityCollection GetAll(PhxUserEntity PhxUser)
        {
            vwHistPwdVisFactory HistFac = new vwHistPwdVisFactory();
            if (PhxUser != null)
            {
                HistFac.FilPhxUser = PhxUser;
            }
            return HistFac.GetAll();
        }
        */
        public vwHistPwdVisEntityCollection GetAll(PhxUserEntity PhxUser, int Folio, string FechaDesde, string FechaHasta, UserEntity User)
        {
            vwHistPwdVisFactory HistFac = new vwHistPwdVisFactory();
            if (PhxUser != null)
            {
                HistFac.FilPhxUser = PhxUser;
            }
            if (User != null)
            {
                HistFac.FilUser = User;
            }
            if (FechaDesde != "" && FechaDesde.Trim() != "/  /")
            {
                System.Globalization.DateTimeFormatInfo dtfi = new
                    System.Globalization.DateTimeFormatInfo();
                dtfi.ShortDatePattern = "dd/MM/yyyy";
                HistFac.FilFDesde = Convert.ToDateTime(FechaDesde, dtfi);
            }
            if (FechaHasta != "" && FechaHasta.Trim() != "/  /")
            {
                System.Globalization.DateTimeFormatInfo dtfi = new
                    System.Globalization.DateTimeFormatInfo();
                dtfi.ShortDatePattern = "dd/MM/yyyy";
                HistFac.FilFHasta = Convert.ToDateTime(FechaHasta, dtfi);
            }
            HistFac.FilFolio = Folio;
            return HistFac.GetAll();
        }
    }
}
