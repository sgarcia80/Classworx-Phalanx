using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxDAL.Factories;
using PhalanxCommon.Entities;

namespace PhalanxBL
{
    public class BuildingBusiness
    {
        BuildingFactory m_building_fac;
        public string FilNombre
        {
            set { m_building_fac.FilNombre = value; }
        }
        public BuildingBusiness()
        {
            m_building_fac = new BuildingFactory();
        }
        public BuildingEntityCollection GetAll()
        {
            return m_building_fac.GetAll();
        }


        public int Save(BuildingEntity Building)
        {
            return new BuildingFactory().Save(Building);
        }

        public bool Delete(BuildingEntity Building)
        {
            return new BuildingFactory().Delete(Building);
        }
    }
}
