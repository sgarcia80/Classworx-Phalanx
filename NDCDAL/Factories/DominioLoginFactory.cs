using System;
using System.Collections.Generic;
using System.Text;
using NDCCommon.Collections;
using System.Configuration;
using NDCCommon.Entities;

namespace NDCDAL.Factories
{
    public class DominioLoginFactory
    {
        public DominioLoginEntityCollection GetAllFromConfig()
        {
            DominioLoginEntityCollection LstDominios = new DominioLoginEntityCollection();
            string DominiosParaLogin = ConfigurationManager.AppSettings["DominiosLogin"];

            if (DominiosParaLogin != null)
            {
                string[] strlstDoms = DominiosParaLogin.Split(',');
                for(int i =0 ; i < strlstDoms.Length; i++)
                {
                    string[] lstDominioComp = strlstDoms[i].Split('|');
                    if (lstDominioComp.Length == 2)
                    {
                        DominioLoginEntity newdom = new DominioLoginEntity();
                        newdom.Nombre = lstDominioComp[0];
                        newdom.DireccionAD = lstDominioComp[1];
                        LstDominios.Add(newdom);
                    }
                }

            
            }

            return LstDominios;

        }
    }
}
