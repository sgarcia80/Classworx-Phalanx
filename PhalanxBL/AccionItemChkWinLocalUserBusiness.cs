using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using PhalanxDAL.Factories;

namespace PhalanxBL
{
    public class AccionItemChkWinLocalUserBusiness
    {
        public AccionItemChkWinLocalUserEntity GetDesactivarEquipo()
        {
            return this.Load(1);
        }
        public AccionItemChkWinLocalUserEntity GetSacarMarcaChkEquipo()
        {
            return this.Load(2);
        }
        public AccionItemChkWinLocalUserEntity GetRepararPwd()
        {
            return this.Load(3);
        }
        public AccionItemChkWinLocalUserEntity GetSacarMarcaChkUsr()
        {
            return this.Load(4);
        }
        public AccionItemChkWinLocalUserEntity Load(int Id)
        {
            return new AccionItemChkWinLocalUserFactory().Load(Id);
        }
    }
}
