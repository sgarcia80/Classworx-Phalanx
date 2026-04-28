using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using PhalanxDAL.Factories;

namespace PhalanxBL
{
    public class UserSubTypeBusiness
    {
        public UserSubTypeEntityCollection GetAll()
        {
            UserSubTypesFactory DTF = new UserSubTypesFactory();

            return DTF.GetAll();

        }
        public UserSubTypeEntityCollection FillFilter()
        {
            UserSubTypeEntityCollection DBTypeEC = this.GetAll();
            UserSubTypeEntity Todos = new UserSubTypeEntity();
            Todos.Desc = "Todos";
            Todos.Id = 0;
            DBTypeEC.Insert(0, Todos);
            return DBTypeEC;
        }

        public UserSubTypeEntityCollection FillSelect()
        {
            UserSubTypeEntityCollection DBTypeEC = this.GetAll();
            UserSubTypeEntity Todos = new UserSubTypeEntity();
            Todos.Desc = "-- Seleccione --";
            Todos.Id = 0;
            DBTypeEC.Insert(0, Todos);
            return DBTypeEC;
        }        
    }
}
