using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxDAL.Factories;
using PhalanxCommon.Entities;

namespace PhalanxBL
{
    public class CommunicationDeviceProtocolBusiness
    {
        public CommunicationDeviceProtocolEntityCollection GetAll()
        {
            CommunicationDeviceProtocolFactory CDPF = new CommunicationDeviceProtocolFactory();

            return CDPF.GetAll();
        }

        public CommunicationDeviceProtocolEntityCollection FillFilter()
        {
            CommunicationDeviceProtocolEntityCollection CDProtocolEC = this.GetAll();
            CommunicationDeviceProtocolEntity Todos = new CommunicationDeviceProtocolEntity();
            Todos.Name = "Todas";
            Todos.Id = 0;
            CDProtocolEC.Insert(0, Todos);
            return CDProtocolEC;
        }
    }
}
