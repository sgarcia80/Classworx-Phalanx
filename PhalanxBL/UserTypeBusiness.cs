using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using PhalanxDAL.Factories;

namespace PhalanxBL
{
    public class UserTypeBusiness
    {
        public UserTypeEntityCollection GetAll()
        {
            UserTypesFactory DTF = new UserTypesFactory();

            return DTF.GetAll();

        }
        public UserTypeEntityCollection FillFilter()
        {
            UserTypeEntityCollection DBTypeEC = this.GetAll();
            UserTypeEntity Todos = new UserTypeEntity();
            Todos.Desc = "Todas";
            Todos.Id = 0;
            DBTypeEC.Insert(0, Todos);
            return DBTypeEC;
        }

        public UserTypeEntityCollection FillSelect()
        {
            UserTypeEntityCollection DBTypeEC = this.GetAll();
            UserTypeEntity Todos = new UserTypeEntity();
            Todos.Desc = "-- Seleccione --";
            Todos.Id = 0;
            DBTypeEC.Insert(0, Todos);
            return DBTypeEC;
        }

        public UserTypeEntity GetUserTypeATM()
        {
            return new UserTypesFactory().GetATMUserType();
        }
    }
}
