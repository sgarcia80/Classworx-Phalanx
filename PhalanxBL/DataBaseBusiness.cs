using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using PhalanxDAL.Factories;

namespace PhalanxBL
{
    public class DataBaseBusiness
    {
        private string _filNombre = "";
        public string FilNombre
        {
            set { _filNombre = value; }
            //get { return _filNombre; }
        }
        private bool? _filUsuariosActivos;
        public bool? FilUsuariosActivos
        {
            set { _filUsuariosActivos = value; }
        }

        private DatabaseTypeEntity _filTipoDB;
        public DatabaseTypeEntity FilTipoDB
        {
            set { _filTipoDB = value; }
        }
        public DataBaseEntityCollection GetAll()
        {
            DatabaseFactory DBF = new DatabaseFactory();
            DBF.FilNombre = _filNombre;
            DBF.FilTipoDB = _filTipoDB;
            DBF.FilUsuariosActivos = _filUsuariosActivos;
            return DBF.GetAll();

        }

        public int Save(DataBaseEntity Database)
        {
            return new DatabaseFactory().Save(Database);
        }
    }
}
