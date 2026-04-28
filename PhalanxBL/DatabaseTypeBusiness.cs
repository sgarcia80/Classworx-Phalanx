using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using PhalanxDAL.Factories;

namespace PhalanxBL
{
    public class DatabaseTypeBusiness
    {
        public DatabaseTypeEntityCollection GetAll()
        {
            DatabaseTypesFactory DTF = new DatabaseTypesFactory();

            return DTF.GetAll();

        }
        public DatabaseTypeEntityCollection GetAllWithDatabases()
        {
            DatabaseTypesFactory DTF = new DatabaseTypesFactory();
            DTF.FilCargaDatabases = true;
            return DTF.GetAll();

        }
        public DatabaseTypeEntityCollection FillFilter()
        {
            DatabaseTypeEntityCollection DBTypeEC = this.GetAll();
            DatabaseTypeEntity Todos = new DatabaseTypeEntity();
            Todos.Name = "Todas";
            Todos.Id = 0;
            DBTypeEC.Insert(0, Todos);
            return DBTypeEC;
        }
    }
}
