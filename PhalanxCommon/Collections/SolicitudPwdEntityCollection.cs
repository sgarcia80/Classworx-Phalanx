using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using System.Collections;

namespace PhalanxCommon.Collections
{
    public class SolicitudPwdEntityCollection : BaseEntityCollection
    {
        public int Add(SolicitudPwdEntity entity)
        {
            return base.Add(entity);
        }
        public void Add(IList entityList)
        {
            foreach (object[] objEnt in entityList)
            {
                SolicitudPwdEntity Entity = new SolicitudPwdEntity();
                Entity.Id = (int)objEnt[0];
                Entity.IdAmbiente = (int)objEnt[1];
                Entity.Ambiente = objEnt[2].ToString();
                Entity.DetallePwd = objEnt[3].ToString();
                Entity.EstadoSolicitud = objEnt[4].ToString();
                Entity.FechaSolicitud = (DateTime)objEnt[5];
                if (objEnt[6] != null)
                {
                    Entity.FechaUltimoEstado = (DateTime)objEnt[6];
                }
                Entity.Solicitante = objEnt[7].ToString();
                if (objEnt[8] != null)
                {
                    Entity.SplitFechaUsrCambio(objEnt[8].ToString());
                }
                this.Add(Entity);
            }
        }

        public void Insert(int index, SolicitudPwdEntity myEntity)
        {
            base.Insert(index, myEntity);
        }
        public new SolicitudPwdEntity this[int index]
        {
            get { return (SolicitudPwdEntity)InnerList[index]; }
            set { InnerList[index] = value; }
        }
        public new SolicitudPwdEntity this[string entitykeyString]
        {
            get
            {
                return Find(entitykeyString);
            }
            set
            {
                SolicitudPwdEntity entity = Find(entitykeyString);
                int index = InnerList.BinarySearch(entity);
                this[index] = value;
            }
        }
        public new SolicitudPwdEntity Find(string entityKeyString)
        {
            foreach (SolicitudPwdEntity entity in InnerList)
            {
                if (entity.Key.ToString() == entityKeyString)
                    return entity;
            }
            return null;
        }
    }
}
