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
        List<MarcaBO> findAll();
        [OperationContract]
        List<MarcaBO> findAllCustom();
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
