using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using PhalanxDAL.Factories;

namespace PhalanxBL
{
    public class ApplicationBusiness
    {
        private string _filNombre = "";
        public string FilNombre
        {
            set { _filNombre = value; }
            //get { return _filNombre; }
        }
        public ApplicationEntityCollection GetAll()
        {
            ApplicationFactory AppFac = new ApplicationFactory();
            AppFac.FilNombre = _filNombre;

            return AppFac.GetAll();

        }
        /// <summary>
        /// Indica si existe una aplicacion con mismo nombre
        /// </summary>
        /// <param name="Application"></param>
        /// <returns></returns>
        public int Save(ApplicationEntity Application)
        {
            return new ApplicationFactory().Save(Application);
        }
        public bool Exists(string AppName)
        {
            ApplicationFactory AppF = new ApplicationFactory();
            if (AppF.GetApplication(AppName, 0).Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    
        /// <summary>
        /// Indica si existe una aplicación con el mismo nombre y distinto Id
        /// Esto es para updates o para ins pasando Id 0
        /// </summary>
        /// <param name="AppName"></param>
        /// <param name="IdApp"></param>
        /// <returns></returns>
        public bool Exists(string AppName, int IdApp)
        {
            ApplicationFactory AppF = new ApplicationFactory();
            if (AppF.GetApplication(AppName, IdApp).Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    
}
