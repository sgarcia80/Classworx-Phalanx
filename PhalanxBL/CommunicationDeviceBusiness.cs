using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using PhalanxCommon.Collections;
using PhalanxDAL.Factories;

namespace PhalanxBL
{
    public class CommunicationDeviceBusiness
    {
        private string _filNombre = "";
        private CommunicationDeviceTypeEntity _filTipoCD;
        
        public string FilNombre
        {
            set { _filNombre = value; }
        }


        public CommunicationDeviceTypeEntity FilTipoCD
        {
            set { _filTipoCD = value; }
        }

        public CommunicationDeviceEntityCollection GetAll()
        {
            CommunicationDeviceFactory CDF = new CommunicationDeviceFactory();
            CDF.FilNombre = _filNombre;
            CDF.FilTipoCD = _filTipoCD;

            return CDF.GetAll();
        }

        public int Save(CommunicationDeviceEntity CommunicationDevice)
        {
            return Save(CommunicationDevice, null);
        }

        public int Save(CommunicationDeviceEntity CommunicationDevice, IEnumerable<CommunicationDeviceProtocolEntity> protocolsToRemove)
        {
            return new CommunicationDeviceFactory().Save(CommunicationDevice, protocolsToRemove);
        }

        public bool Exists(string name, int id)
        {
            CommunicationDeviceEntity cd = new CommunicationDeviceFactory().GetByName(name);

            return cd != null && cd.Id != id;
        }
    }
}
