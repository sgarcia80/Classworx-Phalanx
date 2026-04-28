using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using PhalanxDAL.Factories;

namespace PhalanxBL
{
    public class PhxVersionBusiness
    {
        public bool CheckLastVersion(string Version)
        {
            PhxVersionEntityCollection Versiones = new PhxVersionFactory().GetAll();
            if (Versiones.Count > 0 && Versiones[0].Version == Version)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
