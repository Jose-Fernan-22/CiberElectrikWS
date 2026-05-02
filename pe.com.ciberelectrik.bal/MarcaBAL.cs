using pe.com.ciberelectrik.bo;
using pe.com.ciberelectrik.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.ciberelectrik.bal
{
    //aqui esta incompleto 
    public class MarcaBAL
    {
        MarcaDAL dal = new MarcaDAL();

        public List<MarcaBO> MostrarMarca()
        {
            return dal.MostrarMarca();
        }

        public List<MarcaBO> MostrarMarcaTodo()
        {
            return dal.MostrarMarcaTodo();
        }

        public MarcaBO BuscarMarcaXCodigo(MarcaBO m)
        {
            return dal.BuscarMarcaXCodigo(m);
        }
    }
}
