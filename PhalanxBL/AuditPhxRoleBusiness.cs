using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using PhalanxDAL.Factories;

namespace PhalanxBL
{
    public class AuditPhxRoleBusiness
    {
        public PhalanxCommon.Collections.AuditPhxRoleEntityCollection GetAll(string FechaDesde, string FechaHasta)
        {
            AuditPhxRoleFactory AudLogFac = new AuditPhxRoleFactory();
            if (FechaDesde != "" && FechaDesde.Trim() != "/  /")
            {
                System.Globalization.DateTimeFormatInfo dtfi = new
                    System.Globalization.DateTimeFormatInfo();
                dtfi.ShortDatePattern = "dd/MM/yyyy";
                AudLogFac.FilFDesde = Convert.ToDateTime(FechaDesde, dtfi);
            }
            if (FechaHasta != "" && FechaHasta.Trim() != "/  /")
            {
                System.Globalization.DateTimeFormatInfo dtfi = new
                    System.Globalization.DateTimeFormatInfo();
                dtfi.ShortDatePattern = "dd/MM/yyyy";
                AudLogFac.FilFHasta = Convert.ToDateTime(FechaHasta, dtfi);
            }
            return AudLogFac.GetAll();
        }
    }
}
