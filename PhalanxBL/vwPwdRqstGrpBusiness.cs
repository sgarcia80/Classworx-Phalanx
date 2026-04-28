using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using PhalanxDAL.Factories;
namespace PhalanxBL
{
    public class vwPwdRqstGrpBusiness
    {
        public vwPwdRqstGrpEntityCollection GetAll(bool Activos, bool NoActivos, bool Criticos, bool NoCriticos,
            bool Windows, bool Unix, bool AS400, bool Aplicativos, bool DB, bool EC, bool ATM, bool? GrupoActivo)
        {
            vwPwdRqstGrpFactory InventFac = new vwPwdRqstGrpFactory();
            InventFac.FilActivos = Activos;
            InventFac.FilCriticos = Criticos;
            InventFac.FilNoCriticos = NoCriticos;
            InventFac.FilNoActivos = NoActivos;
            InventFac.FilAmbWin = Windows;
            InventFac.FilAmbUnix = Unix;
            InventFac.FilAmbAS400 = AS400;
            InventFac.FilAmbApp = Aplicativos;
            InventFac.FilAmbDB = DB;
            InventFac.FilAmbEC = EC;
            InventFac.FilAmbATM = ATM;
            InventFac.FilGrupoActivo = GrupoActivo;
            return InventFac.GetAll();

        }
        public vwPwdRqstGrpEntityCollection GetAll(string Nombre, UserTypeEntity UserType)
        {
            vwPwdRqstGrpFactory InventFac = new vwPwdRqstGrpFactory();
            InventFac.FilUsername = Nombre;
            InventFac.FilActivos = true;
            InventFac.FilCriticos = true;
            InventFac.FilNoCriticos = true;
            InventFac.FilNoActivos = true;
            bool Windows = false;
            bool Unix = false;
            bool Aplicativos = false;
            bool DB = false;
            bool EC = false;
            bool ATM = false;
            bool AS400 = false;
            switch (UserType.Desc)
            {
                case "Windows":
                    Windows = true;
                    break;
                case "Unix":
                    Unix = true;
                    break;
                case "Bases De Datos":
                    DB = true;
                    break;
                case "Aplicativos":
                    Aplicativos = true;
                    break;
                case "Equipos de Comunicación":
                    EC = true;
                    break;
                case "ATM":
                    ATM = true;
                    break;
                case "AS400":
                    AS400 = true;
                    break;
                default:
                    break;
            }
            InventFac.FilAmbWin = Windows;
            InventFac.FilAmbUnix = Unix;
            InventFac.FilAmbApp = Aplicativos;
            InventFac.FilAmbDB = DB;
            InventFac.FilAmbEC = EC;
            InventFac.FilAmbATM = ATM;
            InventFac.FilAmbAS400 = AS400;
            InventFac.OrderByFolio = false;
            return InventFac.GetAll();

        }

    }
}
