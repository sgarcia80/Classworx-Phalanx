using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using PhalanxDAL.Factories;

namespace PhalanxBL
{
    public class MailTypeBusiness
    {
        public MailTypeEntityCollection FillFilter()
        {
            MailTypeEntityCollection MailTypeEC = this.GetAll();
            MailTypeEntity Todos = new MailTypeEntity();
            Todos.Name = "Todos";
            Todos.Id = 0;
            MailTypeEC.Insert(0, Todos);
            return MailTypeEC;
        }

        private MailTypeEntityCollection GetAll()
        {
            return new MailTypeFactory().GetAll();
        }

    }
}
