using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using PhalanxDAL.Factories;

namespace PhalanxBL
{
	public class PhxLogUsuarioInactivadoBusiness
    {
		public int Save(PhxLogUsuarioInactivado logUsuarioInactivado)
        {
			return new PhxLogUsuarioInactivadoFactory().Save(logUsuarioInactivado);
        }
    }    
}
