using pe.com.ciberelectrik.bal;
using pe.com.ciberelectrik.bo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace pe.com.ciberelectrik.ws
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    /// Define el esoacio de nombres y en produccion se veria asi :
    /// [WebService(Namespace = "http://ciberelectrik.com.pe/servicio")]
    [WebService(Namespace = "http://tempuri.org/")]

    //indica qyue cumple con un perfil de interoperabilidad 
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

    //Indica que la clase no debe de aparecer como control disponible
    //en el cuadro de heramientas
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]

    //significa que la clase hereda de System.Web.Service.WebService
    public class WebService1 : System.Web.Services.WebService
    {
        //Utilizamos el BAL para interactuar con el DAL
        private CategoriaBAL balcat = new CategoriaBAL();
        private MarcaBAL balmar = new MarcaBAL();
        private ProductoBAL balpro = new ProductoBAL();

        //[WebMethod] -> define los metodos que se van a exponer 

        //-----------------categoria-----------------

        [WebMethod]
        public List<CategoriaBO> MostrarCategoria()
        {
            return balcat.MostrarCategoria();
        }

        [WebMethod]
        public List<CategoriaBO> MostrarCategoriaTodo()
        {
            return balcat.MostrarCategoriaTodo();

        }

        [WebMethod]
        public CategoriaBO BuscarCategoriaXCodigo(CategoriaBO c)
        {
            return balcat.BuscarCategoriaXCodigo(c);
        }

        [WebMethod]
        public bool RegistrarCategoria(CategoriaBO c)
        {
            return balcat.RegistrarCategoria(c);
        }
        [WebMethod]
        public bool ActualizarCategoria(CategoriaBO c)
        {
            return balcat.ActualizarCategoria(c);
        }

        [WebMethod]
        public bool EliminarCategoria(CategoriaBO c)
        {
            return balcat.EliminarCategoria(c);
        }

        [WebMethod]
        public bool HabilitarCategoria(CategoriaBO c)
        {
            return balcat.HabilitarCategoria(c);
        }

        //---------------------------------------------------------------------

        //------------------ Marca --------------------------------------------
        [WebMethod]
        public List<MarcaBO> MostrarMarca()
        {
            return balmar.MostrarMarca();
        }

        [WebMethod]
        public List<MarcaBO> MostrarMarcaTodo()
        {
            return balmar.MostrarMarcaTodo();
        }

        [WebMethod]
        public MarcaBO BuscarMarcaXCodigo(MarcaBO m)
        {
            return balmar.BuscarMarcaXCodigo(m);
        }

        //------------------- Producto --------------------------------------------
        [WebMethod]
        public List<ProductoBO> MostrarProducto()
        {
            return balpro.MostrarProducto();
        }

        [WebMethod]
        public List<ProductoBO> MostrarProductoTodo()
        {
            return balpro.MostrarProductoTodo();
        }

        [WebMethod]
        public ProductoBO BuscarProductoXCodigo(ProductoBO p)
        {
            return balpro.BuscarProductoXCodigo(p);
        }

        [WebMethod]
        public bool RegistrarProducto(ProductoBO p)
        {
            return balpro.RegistrarProducto(p);
        }

        [WebMethod]
        public bool ActualizarProducto(ProductoBO p)
        {
            return balpro.ActualizarProducto(p);
        }

        [WebMethod]
        public bool EliminarProducto(ProductoBO p)
        {
            return balpro.EliminarProducto(p);
        }

        [WebMethod]
        public bool HabilitarProducto(ProductoBO p)
        {
            return balpro.HabilitarProducto(p);
        }

        //---------------------------------------------------------------------
        //------------------ Distrito --------------------------------------------

    }
}
