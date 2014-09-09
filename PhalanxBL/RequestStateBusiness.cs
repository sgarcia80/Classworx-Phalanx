using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using PhalanxDAL.Factories;

namespace PhalanxBL
{
    public class RequestStateBusiness
    {
        public RequestStateEntityCollection GetAll()
        {
            RequestStatesFactory reqstateFactory = new RequestStatesFactory();
            return reqstateFactory.GetAll();

        }
        public RequestStateEntityCollection FillFilter()
        {
            RequestStateEntityCollection RqstStateEC = this.GetAll();
            RequestStateEntity Todos = new RequestStateEntity();
            Todos.RqstStateDesc = "Todos";
            Todos.Id = 0;
            RqstStateEC.Insert(0, Todos);
            return RqstStateEC;
        }
    }
}
