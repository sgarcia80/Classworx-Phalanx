using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using PhalanxDAL.Factories;

namespace PhalanxBL
{
    public class HistPasswordChangeBusiness
    {
        public HistPasswordChangeEntityCollection GetAll()
        {
            HistPasswordChangeFactory HPCF = new HistPasswordChangeFactory();
            return HPCF.GetAll();
        }
        public HistPasswordChangeEntity GetChangePostReturn(int UserID, DateTime ReturnDate, DateTime? ClosingDate)
        {
            HistPasswordChangeFactory HPCF = new HistPasswordChangeFactory();
            HPCF.SoloPrimerRegistro = true;
            HPCF.FilUserID = UserID;
            HPCF.FilFechaCambioDesde = ReturnDate;
            if (ClosingDate != null)
            { HPCF.FilFechaCambioHasta = ClosingDate.Value; }
            HistPasswordChangeEntityCollection HistPwdChgEC = HPCF.GetAll();
            if (HistPwdChgEC.Count == 0)
            { return null; }
            else
            { return HistPwdChgEC[0]; }
        }

        public void Depurar(DateTime fecha)
        {
            new HistPasswordChangeFactory().Depurar(fecha);
        }
    }
}
