using pe.com.ciberelectrik.bo;
using pe.com.ciberelectrik.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.ciberelectrik.bal
{
    public class SexoBAL
    {
        SexoDAL dal = new SexoDAL();

        public List<SexoBO> MostrarSexo()
        {
            return dal.MostrarSexo();
        }

        public List<SexoBO> MostrarSexoTodo()
        {
            return dal.MostrarSexoTodo();
        }

        public bool RegistrarSexo(SexoBO s)
        {
            return dal.RegistrarSexo(s);
        }

        public SexoBO BuscarSexoXCodigo(SexoBO s)
        {
            return dal.BuscarSexoXCodigo(s);
        }

        public bool ActualizarSexo(SexoBO s)
        {
            return dal.ActualizarSexo(s);
        }

        public bool EliminarSexo(SexoBO s)
        {
            return dal.EliminarSexo(s);
        }

        public bool HabilitarSexo(SexoBO s)
        {
            return dal.HabilitarSexo(s);
        }

        public int MostrarCodigoSexo()
        {
            return dal.MostrarCodigoSexo();
        }


    }
}
