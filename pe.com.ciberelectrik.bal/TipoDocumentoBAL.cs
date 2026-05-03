using pe.com.ciberelectrik.bo;
using pe.com.ciberelectrik.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.ciberelectrik.bal
{
    public class TipoDocumentoBAL
    {
        TipoDocumentoDAL dal = new TipoDocumentoDAL();

        public List<TipoDocumentoBO> MostrarTipoDocumento()
        {
            return dal.MostrarTipoDocumento();
        }

        public List<TipoDocumentoBO> MostrarTipoDocumentoTodo()
        {
            return dal.MostrarTipoDocumentoTodo();
        }

        public bool RegistrarTipoDocumento(TipoDocumentoBO t)
        {
            return dal.RegistrarTipoDocumento(t);
        }

        public TipoDocumentoBO BuscarTipoDocumentoXCodigo(TipoDocumentoBO t)
        {
            return dal.BuscarTipoDocumentoXCodigo(t);
        }

        public bool ActualizarTipoDocumento(TipoDocumentoBO t)
        {
            return dal.ActualizarTipoDocumento(t);
        }

        public bool EliminarTipoDocumento(TipoDocumentoBO t)
        {
            return dal.EliminarTipoDocumento(t);
        }

        public bool HabilitarTipoDocumento(TipoDocumentoBO t)
        {
            return dal.HabilitarTipoDocumento(t);
        }

        public int MostrarCodigoTipoDocumento()
        {
            return dal.MostrarCodigoTipoDocumento();
        }

    }
}
