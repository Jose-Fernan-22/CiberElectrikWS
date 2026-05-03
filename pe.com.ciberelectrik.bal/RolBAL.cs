using pe.com.ciberelectrik.bo;
using pe.com.ciberelectrik.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.ciberelectrik.bal
{
    public class RolBAL
    {
        RolDAL dal = new RolDAL();
        public List<RolBO> MostrarRol()
        {
            return dal.MostrarRol();
        }
        public List<RolBO> MostrarRolTodo()
        {
            return dal.MostrarRolTodo();
        }

        public bool RegistrarRol(RolBO r)
        {
            return dal.RegistrarRol(r);
        }
        public RolBO BuscarRolXCodigo(RolBO r)
        {   return dal.BuscarRolXCodigo(r);
        }
        public bool ActualizarRol(RolBO r)
        {
            return dal.ActualizarRol(r);
        }

        public bool EliminarRol(RolBO r)
        {
            return dal.EliminarRol(r);
        }
        public bool HabilitarRol(RolBO r)
        {
            return dal.HabilitarRol(r);
        }
        public int MostrarCodigoRol()
        {
            return dal.MostrarCodigoRol();
        }

    }
}
