using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using PhalanxDAL.Factories;

namespace PhalanxBL
{
    public class PhxUserSuperiorBusiness
    {
        PhxUserSuperiorFactory m_superv_fac = new PhxUserSuperiorFactory();
        public string FilNombre
        {
            set { m_superv_fac.FilNombre = value; }
        }

        public PhxUserSuperiorEntityCollection GetAll()
        {
            return m_superv_fac.GetAll();
        }
        public PhxUserSuperiorEntityCollection ArmaCombo()
        {
            PhxUserSuperiorFactory SupFac = new PhxUserSuperiorFactory();
            PhxUserSuperiorEntityCollection SupEC = new PhxUserSuperiorEntityCollection();
            SupEC = SupFac.GetAll();
            PhxUserSuperiorEntity supNinguno = new PhxUserSuperiorEntity();
            supNinguno.Name = "Ninguno";
            SupEC.Insert(0, supNinguno);
            return SupEC;
        }
        public bool IsDeleteable(PhxUserSuperiorEntity Superior)
        {
            return m_superv_fac.IsDeleteable(Superior);
        }
        public int Save(PhxUserSuperiorEntity Superior)
        {
            return m_superv_fac.Save(Superior);
            
        }

        public bool Delete(PhxUserSuperiorEntity Superior)
        {
            return m_superv_fac.Delete(Superior);
        }

    }
}
