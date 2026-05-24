using pe.com.ciberelectrik.bo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace pe.com.ciberelectrik.wcf
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IWCFCiberElectrik" en el código y en el archivo de configuración a la vez.
    //[ServiceContract] -> marca a la interfaz como un contrato de servicio WCF, lo que significa que define las operaciones que el servicio expondrá a los clientes.
    [ServiceContract]
    public interface IWCFCiberElectrik
    {
        //[OperationContract] -> expone las operaciones en el servicio
        //----------------------------Categoria----------------------------
        [OperationContract]
        List<CategoriaBO> categoriaFindAll();
        [OperationContract]
        List<CategoriaBO> categoriaFindAllCustom();
        [OperationContract]
        CategoriaBO categoriaFindById(CategoriaBO obj);

        [OperationContract]
        bool categoriaAdd(CategoriaBO obj);
        [OperationContract]
        bool categoriaUpdate(CategoriaBO obj);
        [OperationContract]
        bool categoriaDelete(CategoriaBO obj);
        [OperationContract]
        bool categoriaEnable(CategoriaBO obj);
        [OperationContract]
        int categoriaSetCode();

        //----------------------------Marca-------------------------------
        [OperationContract]
        List<MarcaBO> marcaFindAll();
        [OperationContract]
        List<MarcaBO> marcaFindAllCustom();
        [OperationContract]
        MarcaBO marcaFindById(MarcaBO obj);

        [OperationContract]
        bool marcaAdd(MarcaBO obj);
        [OperationContract]
        bool marcaUpdate(MarcaBO obj);
        [OperationContract]
        bool marcaDelete(MarcaBO obj);
        [OperationContract]
        bool marcaEnable(MarcaBO obj);
        [OperationContract]
        int marcaSetCode();

        //----------------------------Distrito----------------------------
        [OperationContract]
        List<DistritoBO> distritoFindAll();
        [OperationContract]
        List<DistritoBO> distritoFindAllCustom();
        [OperationContract]
        DistritoBO distritoFindById(DistritoBO obj);
        [OperationContract]
        bool distritoAdd(DistritoBO obj);
        [OperationContract]
        bool distritoUpdate(DistritoBO obj);
        [OperationContract]
        bool distritoDelete(DistritoBO obj);
        [OperationContract]
        bool distritoEnable(DistritoBO obj);
        [OperationContract]
        int distritoSetCode();

        //----------------------------Rol---------------------------------
        [OperationContract]
        List<RolBO> rolFindAll();
        [OperationContract]
        List<RolBO> rolFindAllCustom();
        [OperationContract]
        RolBO rolFindById(RolBO obj);
        [OperationContract]
        bool rolAdd(RolBO obj);
        [OperationContract]
        bool rolUpdate(RolBO obj);
        [OperationContract]
        bool rolDelete(RolBO obj);
        [OperationContract]
        bool rolEnable(RolBO obj);
        [OperationContract]
        int rolSetCode();

        //----------------------------TipoDocumento-----------------------
        [OperationContract]
        List<TipoDocumentoBO> tipoDocumentoFindAll();
        [OperationContract]
        List<TipoDocumentoBO> tipoDocumentoFindAllCustom();
        [OperationContract]
        TipoDocumentoBO tipoDocumentoFindById(TipoDocumentoBO obj);
        [OperationContract]
        bool tipoDocumentoAdd(TipoDocumentoBO obj);
        [OperationContract]
        bool tipoDocumentoUpdate(TipoDocumentoBO obj);
        [OperationContract]
        bool tipoDocumentoDelete(TipoDocumentoBO obj);
        [OperationContract]
        bool tipoDocumentoEnable(TipoDocumentoBO obj);
        [OperationContract]
        int tipoDocumentoSetCode();

        //----------------------------Sexo--------------------------------
        [OperationContract]
        List<SexoBO> sexoFindAll();
        [OperationContract]
        List<SexoBO> sexoFindAllCustom();
        [OperationContract]
        SexoBO sexoFindById(SexoBO obj);
        [OperationContract]
        bool sexoAdd(SexoBO obj);
        [OperationContract]
        bool sexoUpdate(SexoBO obj);
        [OperationContract]
        bool sexoDelete(SexoBO obj);
        [OperationContract]
        bool sexoEnable(SexoBO obj);
        [OperationContract]
        int sexoSetCode();

        //----------------------------Empleado----------------------------
        [OperationContract]
        List<EmpleadoBO> empleadoFindAll();
        [OperationContract]
        List<EmpleadoBO> empleadoFindAllCustom();
        [OperationContract]
        EmpleadoBO empleadoFindById(EmpleadoBO obj);
        [OperationContract]
        bool empleadoAdd(EmpleadoBO obj);
        [OperationContract]
        bool empleadoUpdate(EmpleadoBO obj);
        [OperationContract]
        bool empleadoDelete(EmpleadoBO obj);
        [OperationContract]
        bool empleadoEnable(EmpleadoBO obj);
        [OperationContract]
        int empleadoSetCode();

        //----------------------------Cliente----------------------------
        [OperationContract]
        List<ClienteBO> clienteFindAll();
        [OperationContract]
        List<ClienteBO> clienteFindAllCustom();
        [OperationContract]
        ClienteBO clienteFindById(ClienteBO obj);
        [OperationContract]
        bool clienteAdd(ClienteBO obj);
        [OperationContract]
        bool clienteUpdate(ClienteBO obj);
        [OperationContract]
        bool clienteDelete(ClienteBO obj);
        [OperationContract]
        bool clienteEnable(ClienteBO obj);
        [OperationContract]
        int clienteSetCode();

        //----------------------------Producto----------------------------
        [OperationContract]
        List<ProductoBO> productoFindAll();
        [OperationContract]
        List<ProductoBO> productoFindAllCustom();
        [OperationContract]
        ProductoBO productoFindById(ProductoBO obj);

        [OperationContract]
        bool productoAdd(ProductoBO obj);
        [OperationContract]
        bool productoUpdate(ProductoBO obj);
        [OperationContract]
        bool productoDelete(ProductoBO obj);
        [OperationContract]
        bool productoEnable(ProductoBO obj);
        [OperationContract]
        int productoSetCode();
    }
}
