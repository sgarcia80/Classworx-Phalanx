using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using PhalanxCommon.Entities;

namespace PhalanxBL
{
    public class FreqUnitsMgr
    {
        private ArrayList m_FreqUnits = new ArrayList();

        public FreqUnitsMgr()
        {
            this.GenerateFreqUnits();
        }

        private void GenerateFreqUnits()
        {
            m_FreqUnits.Add(new FreqUnitEntity("H", "Horas"));
            m_FreqUnits.Add(new FreqUnitEntity("D", "Días"));
            m_FreqUnits.Add(new FreqUnitEntity("W", "Semanas"));
            m_FreqUnits.Add(new FreqUnitEntity("M", "Meses"));
            m_FreqUnits.Add(new FreqUnitEntity("Y", "Años"));
        }

        public ArrayList FreqUnits
        {
            get
            {
                return this.m_FreqUnits;
            }
        }
        public FreqUnitEntity GetUnit(string UnitId)
        {
            foreach (FreqUnit objFU in this.m_FreqUnits)
            {
                if (UnitId == objFU.Id)
                {
                    return objFU;
                }
            }
            return null;
        }
    }
}
