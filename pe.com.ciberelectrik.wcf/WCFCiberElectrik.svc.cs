using pe.com.ciberelectrik.bo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace pe.com.ciberelectrik.wcf
{
    // implementar la interfaz
    public class WCFCiberElectrik : IWCFCiberElectrik
    {
        //-------------------------------CATEGORIA-----------------------------------------------
        public List<CategoriaBO> categoriaFindAll()
        {
            throw new NotImplementedException();
        }

        public List<CategoriaBO> categoriaFindAllCustom()
        {
            throw new NotImplementedException();
        }

        public CategoriaBO categoriaFindById(CategoriaBO obj)
        {
            throw new NotImplementedException();
        }
        public bool categoriaAdd(CategoriaBO obj)
        {
            throw new NotImplementedException();
        }
        public bool categoriaUpdate(CategoriaBO obj)
        {
            throw new NotImplementedException();
        }

        public bool categoriaDelete(CategoriaBO obj)
        {
            throw new NotImplementedException();
        }

        public bool categoriaEnable(CategoriaBO obj)
        {
            throw new NotImplementedException();
        }

        public int categoriaSetCode()
        {
            throw new NotImplementedException();
        }


        //-------------------------------MARCA-----------------------------------------------
        public List<MarcaBO> findAll()
        {
            throw new NotImplementedException();
        }

        public List<MarcaBO> findAllCustom()
        {
            throw new NotImplementedException();
        }

        public bool marcaAdd(MarcaBO obj)
        {
            throw new NotImplementedException();
        }

        public bool marcaDelete(MarcaBO obj)
        {
            throw new NotImplementedException();
        }

        public bool marcaEnable(MarcaBO obj)
        {
            throw new NotImplementedException();
        }

        public MarcaBO marcaFindById(MarcaBO obj)
        {
            throw new NotImplementedException();
        }

        public int marcaSetCode()
        {
            throw new NotImplementedException();
        }

        public bool marcaUpdate(MarcaBO obj)
        {
            throw new NotImplementedException();
        }

        //-------------------------------PRODUCTO-----------------------------------------------

        public bool productoAdd(ProductoBO obj)
        {
            throw new NotImplementedException();
        }

        public bool productoDelete(ProductoBO obj)
        {
            throw new NotImplementedException();
        }

        public bool productoEnable(ProductoBO obj)
        {
            throw new NotImplementedException();
        }

        public List<ProductoBO> productoFindAll()
        {
            throw new NotImplementedException();
        }

        public List<ProductoBO> productoFindAllCustom()
        {
            throw new NotImplementedException();
        }

        public ProductoBO productoFindById(ProductoBO obj)
        {
            throw new NotImplementedException();
        }

        public int productoSetCode()
        {
            throw new NotImplementedException();
        }

        public bool productoUpdate(ProductoBO obj)
        {
            throw new NotImplementedException();
        }
    }
}
