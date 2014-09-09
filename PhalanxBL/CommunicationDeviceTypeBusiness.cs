using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using PhalanxDAL.Factories;

namespace PhalanxBL
{
    public class CommunicationDeviceTypeBusiness
    {
        public CommunicationDeviceTypeEntityCollection GetAll()
        {
            CommunicationDeviceTypesFactory CDTF = new CommunicationDeviceTypesFactory();

            return CDTF.GetAll();

        }

        public CommunicationDeviceTypeEntityCollection FillFilter()
        {
            CommunicationDeviceTypeEntityCollection CDTypeEC = this.GetAll();
            
            CommunicationDeviceTypeEntity Todos = new CommunicationDeviceTypeEntity();
            Todos.Name = "Todos";
            Todos.Id = 0;

            CDTypeEC.Insert(0, Todos);

            return CDTypeEC;
        }
    }
}
