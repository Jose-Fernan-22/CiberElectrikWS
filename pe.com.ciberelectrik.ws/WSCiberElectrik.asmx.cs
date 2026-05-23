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

        //------------Instancias simples faltantes-----------------
        private DistritoBAL baldis = new DistritoBAL();
        private RolBAL balrol = new RolBAL();
        private SexoBAL balsex = new SexoBAL();
        private TipoDocumentoBAL baltipd = new TipoDocumentoBAL();

        //------------Instancias cruzadas faltantes-----------------
        private EmpleadoBAL balemp = new EmpleadoBAL();
        private ClienteBAL balcli = new ClienteBAL();

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

        [WebMethod]
        public int MostrarCodigoCategoria()
        {
            return balcat.MostrarCodigoCategoria();
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
        [WebMethod]
        public bool RegistrarMarca(MarcaBO m)
        {
            return balmar.RegistrarMarca(m);
        }
        [WebMethod]
        public bool ActualizarMarca(MarcaBO m)
        {
            return balmar.ActualizarMarca(m);
        }
        [WebMethod]
        public bool EliminarMarca(MarcaBO m)
        {
            return balmar.EliminarMarca(m);
        }
        [WebMethod]
        public bool HabilitarMarca(MarcaBO m)
        {
            return balmar.HabilitarMarca(m);
        }
        [WebMethod]
        public int MostrarCodigoMarca()
        {
            return balmar.MostrarCodigoMarca();
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

        [WebMethod]
        public int MostrarCodigoProducto()
        {
            return balpro.MostrarCodigoProducto();
        }
        //------------------ Distrito --------------------------------------------
        [WebMethod]
        public List<DistritoBO> MostrarDistrito() { return baldis.MostrarDistrito(); }

        [WebMethod]
        public List<DistritoBO> MostrarDistritoTodo() { return baldis.MostrarDistritoTodo(); }

        [WebMethod]
        public bool RegistrarDistrito(DistritoBO d) { return baldis.RegistrarDistrito(d); }

        [WebMethod]
        public DistritoBO BuscarDistritoXCodigo(DistritoBO d) { return baldis.BuscarDistritoXCodigo(d); }

        [WebMethod]
        public bool ActualizarDistrito(DistritoBO d) { return baldis.ActualizarDistrito(d); }

        [WebMethod]
        public bool EliminarDistrito(DistritoBO d) { return baldis.EliminarDistrito(d); }

        [WebMethod]
        public bool HabilitarDistrito(DistritoBO d) { return baldis.HabilitarDistrito(d); }

        [WebMethod]
        public int MostrarCodigoDistrito() { return baldis.MostrarCodigoDistrito(); }

        //------------------ Rol --------------------------------------------

        [WebMethod]
        public List<RolBO> MostrarRol() { return balrol.MostrarRol(); }

        [WebMethod]
        public List<RolBO> MostrarRolTodo() { return balrol.MostrarRolTodo(); }

        [WebMethod]
        public bool RegistrarRol(RolBO r) { return balrol.RegistrarRol(r); }

        [WebMethod]
        public RolBO BuscarRolXCodigo(RolBO r) { return balrol.BuscarRolXCodigo(r); }

        [WebMethod]
        public bool ActualizarRol(RolBO r) { return balrol.ActualizarRol(r); }

        [WebMethod]
        public bool EliminarRol(RolBO r) { return balrol.EliminarRol(r); }

        [WebMethod]
        public bool HabilitarRol(RolBO r) { return balrol.HabilitarRol(r); }

        [WebMethod]
        public int MostrarCodigoRol() { return balrol.MostrarCodigoRol(); }

        //------------------ Sexo --------------------------------------------
        [WebMethod]
        public List<SexoBO> MostrarSexo() { return balsex.MostrarSexo(); }

        [WebMethod]
        public List<SexoBO> MostrarSexoTodo() { return balsex.MostrarSexoTodo(); }

        [WebMethod]
        public bool RegistrarSexo(SexoBO s) { return balsex.RegistrarSexo(s); }

        [WebMethod]
        public SexoBO BuscarSexoXCodigo(SexoBO s) { return balsex.BuscarSexoXCodigo(s); }

        [WebMethod]
        public bool ActualizarSexo(SexoBO s) { return balsex.ActualizarSexo(s); }

        [WebMethod]
        public bool EliminarSexo(SexoBO s) { return balsex.EliminarSexo(s); }

        [WebMethod]
        public bool HabilitarSexo(SexoBO s) { return balsex.HabilitarSexo(s); }

        [WebMethod]
        public int MostrarCodigoSexo() { return balsex.MostrarCodigoSexo(); }

        //------------------ TipoDocumento --------------------------------------------

        [WebMethod]
        public List<TipoDocumentoBO> MostrarTipoDocumento() { return baltipd.MostrarTipoDocumento(); }

        [WebMethod]
        public List<TipoDocumentoBO> MostrarTipoDocumentoTodo() { return baltipd.MostrarTipoDocumentoTodo(); }

        [WebMethod]
        public bool RegistrarTipoDocumento(TipoDocumentoBO t) { return baltipd.RegistrarTipoDocumento(t); }

        [WebMethod]
        public TipoDocumentoBO BuscarTipoDocumentoXCodigo(TipoDocumentoBO t) { return baltipd.BuscarTipoDocumentoXCodigo(t); }

        [WebMethod]
        public bool ActualizarTipoDocumento(TipoDocumentoBO t) { return baltipd.ActualizarTipoDocumento(t); }

        [WebMethod]
        public bool EliminarTipoDocumento(TipoDocumentoBO t) { return baltipd.EliminarTipoDocumento(t); }

        [WebMethod]
        public bool HabilitarTipoDocumento(TipoDocumentoBO t) { return baltipd.HabilitarTipoDocumento(t); }

        [WebMethod]
        public int MostrarCodigoTipoDocumento() { return baltipd.MostrarCodigoTipoDocumento(); }

        //------------------ Empleado --------------------------------------------

        [WebMethod]
        public List<EmpleadoBO> MostrarEmpleado() { return balemp.MostrarEmpleado(); }

        [WebMethod]
        public List<EmpleadoBO> MostrarEmpleadoTodo() { return balemp.MostrarEmpleadoTodo(); }

        [WebMethod]
        public bool RegistrarEmpleado(EmpleadoBO e) { return balemp.RegistrarEmpleado(e); }

        [WebMethod]
        public EmpleadoBO BuscarEmpleadoXCodigo(EmpleadoBO e) { return balemp.BuscarEmpleadoXCodigo(e); }

        [WebMethod]
        public bool ActualizarEmpleado(EmpleadoBO e) { return balemp.ActualizarEmpleado(e); }

        [WebMethod]
        public bool EliminarEmpleado(EmpleadoBO e) { return balemp.EliminarEmpleado(e); }

        [WebMethod]
        public bool HabilitarEmpleado(EmpleadoBO e) { return balemp.HabilitarEmpleado(e); }

        [WebMethod]
        public int MostrarCodigoEmpleado() { return balemp.MostrarCodigoEmpleado(); }

        //------------------ Cliente --------------------------------------------
        [WebMethod]
        public List<ClienteBO> MostrarCliente() { return balcli.MostrarCliente(); }

        [WebMethod]
        public List<ClienteBO> MostrarClienteTodo() { return balcli.MostrarClienteTodo(); }

        [WebMethod]
        public bool RegistrarCliente(ClienteBO c) { return balcli.RegistrarCliente(c); }

        [WebMethod]
        public ClienteBO BuscarClienteXCodigo(ClienteBO c) { return balcli.BuscarClienteXCodigo(c); }

        [WebMethod]
        public bool ActualizarCliente(ClienteBO c) { return balcli.ActualizarCliente(c); }

        [WebMethod]
        public bool EliminarCliente(ClienteBO c) { return balcli.EliminarCliente(c); }

        [WebMethod]
        public bool HabilitarCliente(ClienteBO c) { return balcli.HabilitarCliente(c); }

        [WebMethod]
        public int MostrarCodigoCliente() { return balcli.MostrarCodigoCliente(); }
    }
}
