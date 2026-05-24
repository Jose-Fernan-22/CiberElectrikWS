using pe.com.ciberelectrik.bo;
using pe.com.ciberelectrik.dal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace pe.com.ciberelectrik.wcf
{
    // implementar la interfaz
    public class WCFCiberElectrik : IWCFCiberElectrik    
    {

        //Creamos un objeto de la clase DAL
        /*
        CategoriaDAL dalcat = new CategoriaDAL();
        MarcaDAL dalmar = new MarcaDAL();
        DistritoDAL daldist = new DistritoDAL();
        RolDAL dalrol = new RolDAL();
        TipoDocumentoDAL daltd = new TipoDocumentoDAL();
        SexoDAL dalsex = new SexoDAL();

        EmpleadoDAL dalemp = new EmpleadoDAL();
        ClienteDAL dalcli = new ClienteDAL();
        ProductoDAL dalpro = new ProductoDAL();
        */
        //Creamos  un objeto
        bdciberelectrikapi20261Entities contexto = new bdciberelectrikapi20261Entities();


        //-------------------------------CATEGORIA-----------------------------------------------
        public List<CategoriaBO> categoriaFindAll()
        {
            try
            {
                return contexto.categoria.Select(c => new CategoriaBO
                {
                    codigo = c.codcat,
                    nombre = c.nomcat,
                    estado = c.estcat
                }).ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public List<CategoriaBO> categoriaFindAllCustom()
        {
            try
            {
                return contexto.categoria.Where(c => c.estcat).Select(c => new CategoriaBO
                {
                    codigo = c.codcat,
                    nombre = c.nomcat,
                    estado = c.estcat
                }).ToList();
            } catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public CategoriaBO categoriaFindById(CategoriaBO obj)
        {
            try
            {
                return contexto.categoria.Where(c => c.codcat == obj.codigo).Select(c => new CategoriaBO
                {
                    codigo = c.codcat,
                    nombre = c.nomcat,
                    estado = c.estcat
                }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
        public bool categoriaAdd(CategoriaBO obj)
        {
            try
            {
                categoria cat = new categoria
                {
                    nomcat = obj.nombre,
                    estcat = obj.estado
                };
                contexto.categoria.Add(cat);
                return contexto.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }
        public bool categoriaUpdate(CategoriaBO obj)
        {
            try
            {
                var cat = contexto.categoria.Find(obj.codigo);
                if (cat != null)
                {
                    cat.nomcat = obj.nombre;
                    cat.estcat = obj.estado;
                    return contexto.SaveChanges() == 1;
                }
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public bool categoriaDelete(CategoriaBO obj)
        {
            try
            {
                var cat = contexto.categoria.Find(obj.codigo);
                if (cat != null)
                {
                    cat.estcat = false;
                    return contexto.SaveChanges() == 1;
                }
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public bool categoriaEnable(CategoriaBO obj)
        {
            try
            {
                var cat = contexto.categoria.Find(obj.codigo);
                if (cat != null)
                {
                    cat.estcat = true;
                    return contexto.SaveChanges() == 1;
                }
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public int categoriaSetCode()
        {
            try
            {
                int siguiente = contexto.categoria.Any() ? contexto.categoria.Max(c => c.codcat +1 ) : 1;
                return siguiente;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return 0;
            }
        }


        //-------------------------------MARCA-----------------------------------------------
        public List<MarcaBO> marcaFindAll()
        {
            try
            {
                return contexto.marca.Select(m => new MarcaBO
                {
                    codigo = m.codmar,
                    nombre = m.nommar,
                    estado = m.estmar
                }).ToList();
            } catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public List<MarcaBO> marcaFindAllCustom()
        {
            try
            {
                return contexto.marca.Where(m => m.estmar).Select(m => new MarcaBO
                {
                    codigo = m.codmar,
                    nombre = m.nommar,
                    estado = m.estmar
                }).ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
        public MarcaBO marcaFindById(MarcaBO obj)
        {
            try
            {
                return contexto.marca.Where(m => m.codmar == obj.codigo).Select(m => new MarcaBO
                {
                    codigo = m.codmar,
                    nombre = m.nommar,
                    estado = m.estmar
                }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
        public bool marcaAdd(MarcaBO obj)
        {
            try
            {
                marca mar = new marca
                {
                    nommar = obj.nombre,
                    estmar = obj.estado
                };
                contexto.marca.Add(mar);
                return contexto.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }
        public bool marcaUpdate(MarcaBO obj)
        {
            try
            {
                var mar = contexto.marca.Find(obj.codigo);
                if (mar != null)
                {
                    mar.nommar = obj.nombre;
                    mar.estmar = obj.estado;
                    return contexto.SaveChanges() == 1;
                }
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public bool marcaDelete(MarcaBO obj)
        {
            try
            {
                var mar = contexto.marca.Find(obj.codigo);
                if(mar != null)
                {
                    mar.estmar = false;
                    return contexto.SaveChanges() == 1;
                }
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public bool marcaEnable(MarcaBO obj)
        {
            try
            {
                var mar = contexto.marca.Find(obj.codigo);
                if (mar != null)
                {
                    mar.estmar = true;
                    return contexto.SaveChanges() == 1;
                }
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }


        public int marcaSetCode()
        {
            try
            {
                int siguiente = contexto.marca.Any()? contexto.marca.Max(m => m.codmar + 1) : 1;
                return siguiente;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return 0;
            }
        }

        //-------------------------------DISTRITO--------------------

        public List<DistritoBO> distritoFindAll()
        {
            return daldist.MostrarDistritoTodo();
        }

        public List<DistritoBO> distritoFindAllCustom()
        {
            return daldist.MostrarDistrito();
        }

        public DistritoBO distritoFindById(DistritoBO obj)
        {
            return daldist.BuscarDistritoXCodigo(obj);
        }

        public bool distritoAdd(DistritoBO obj)
        {
            return daldist.RegistrarDistrito(obj);
        }

        public bool distritoUpdate(DistritoBO obj)
        {
            return daldist.ActualizarDistrito(obj);
        }

        public bool distritoDelete(DistritoBO obj)
        {
            return daldist.EliminarDistrito(obj);
        }

        public bool distritoEnable(DistritoBO obj)
        {
            return daldist.HabilitarDistrito(obj);
        }

        public int distritoSetCode()
        {
            return daldist.MostrarCodigoDistrito();
        }

        //-------------------------------ROL-------------------------
        public List<RolBO> rolFindAll()
        {
            return dalrol.MostrarRolTodo();
        }

        public List<RolBO> rolFindAllCustom()
        {
            return dalrol.MostrarRol();
        }

        public RolBO rolFindById(RolBO obj)
        {
            return dalrol.BuscarRolXCodigo(obj);
        }

        public bool rolAdd(RolBO obj)
        {
            return dalrol.RegistrarRol(obj);
        }

        public bool rolUpdate(RolBO obj)
        {
            return dalrol.ActualizarRol(obj);
        }

        public bool rolDelete(RolBO obj)
        {
            return dalrol.EliminarRol(obj);
        }

        public bool rolEnable(RolBO obj)
        {
            return dalrol.HabilitarRol(obj);
        }

        public int rolSetCode()
        {
            return dalrol.MostrarCodigoRol();
        }

        //-------------------------------TIPODOCUMENTO---------------

        public List<TipoDocumentoBO> tipoDocumentoFindAll()
        {
            return daltd.MostrarTipoDocumentoTodo();
        }

        public List<TipoDocumentoBO> tipoDocumentoFindAllCustom()
        {
            return daltd.MostrarTipoDocumento();
        }

        public TipoDocumentoBO tipoDocumentoFindById(TipoDocumentoBO obj)
        {
            return daltd.BuscarTipoDocumentoXCodigo(obj);
        }

        public bool tipoDocumentoAdd(TipoDocumentoBO obj)
        {
            return daltd.RegistrarTipoDocumento(obj);
        }

        public bool tipoDocumentoUpdate(TipoDocumentoBO obj)
        {
            return daltd.ActualizarTipoDocumento(obj);
        }

        public bool tipoDocumentoDelete(TipoDocumentoBO obj)
        {
            return daltd.EliminarTipoDocumento(obj);
        }

        public bool tipoDocumentoEnable(TipoDocumentoBO obj)
        {
            return daltd.HabilitarTipoDocumento(obj);
        }

        public int tipoDocumentoSetCode()
        {
            return daltd.MostrarCodigoTipoDocumento();
        }
        //-------------------------------SEXO------------------------
        public List<SexoBO> sexoFindAll()
        {
            return dalsex.MostrarSexoTodo();
        }

        public List<SexoBO> sexoFindAllCustom()
        {
            return dalsex.MostrarSexo();
        }

        public SexoBO sexoFindById(SexoBO obj)
        {
            return dalsex.BuscarSexoXCodigo(obj);
        }

        public bool sexoAdd(SexoBO obj)
        {
            return dalsex.RegistrarSexo(obj);
        }

        public bool sexoUpdate(SexoBO obj)
        {
            return dalsex.ActualizarSexo(obj);
        }

        public bool sexoDelete(SexoBO obj)
        {
            return dalsex.EliminarSexo(obj);
        }

        public bool sexoEnable(SexoBO obj)
        {
            return dalsex.HabilitarSexo(obj);
        }

        public int sexoSetCode()
        {
            return dalsex.MostrarCodigoSexo();
        }

        //-------------------------------EMPLEADO--------------------
        public List<EmpleadoBO> empleadoFindAll()
        {
            return dalemp.MostrarEmpleadoTodo();
        }

        public List<EmpleadoBO> empleadoFindAllCustom()
        {
            return dalemp.MostrarEmpleado();
        }

        public EmpleadoBO empleadoFindById(EmpleadoBO obj)
        {
            return dalemp.BuscarEmpleadoXCodigo(obj);
        }

        public bool empleadoAdd(EmpleadoBO obj)
        {
            return dalemp.RegistrarEmpleado(obj);
        }

        public bool empleadoUpdate(EmpleadoBO obj)
        {
            return dalemp.ActualizarEmpleado(obj);
        }

        public bool empleadoDelete(EmpleadoBO obj)
        {
            return dalemp.EliminarEmpleado(obj);
        }

        public bool empleadoEnable(EmpleadoBO obj)
        {
            return dalemp.HabilitarEmpleado(obj);
        }

        public int empleadoSetCode()
        {
            return dalemp.MostrarCodigoEmpleado();
        }

        //-------------------------------CLIENTE---------------------
        public List<ClienteBO> clienteFindAll()
        {
            return dalcli.MostrarClienteTodo();
        }

        public List<ClienteBO> clienteFindAllCustom()
        {
            return dalcli.MostrarCliente();
        }

        public ClienteBO clienteFindById(ClienteBO obj)
        {
            return dalcli.BuscarClienteXCodigo(obj);
        }

        public bool clienteAdd(ClienteBO obj)
        {
            return dalcli.RegistrarCliente(obj);
        }

        public bool clienteUpdate(ClienteBO obj)
        {
            return dalcli.ActualizarCliente(obj);
        }

        public bool clienteDelete(ClienteBO obj)
        {
            return dalcli.EliminarCliente(obj);
        }

        public bool clienteEnable(ClienteBO obj)
        {
            return dalcli.HabilitarCliente(obj);
        }

        public int clienteSetCode()
        {
            return dalcli.MostrarCodigoCliente();
        }

        //-------------------------------PRODUCTO--------------------

        public List<ProductoBO> productoFindAll()
        {
            try
            {
                return contexto.producto.Select(p => new ProductoBO
                {
                    codigo = p.codpro,
                    nombre = p.nompro,
                    descripcion = p.despro,
                    fechaingreso = p.fecing,
                    precio = p.prepro,
                    cantidad = p.canpro,
                    
                    marca = new MarcaBO
                    {
                        codigo = p.codmar,
                        nombre = p.marca.nommar,
                    },
                    categoria = new CategoriaBO
                    {
                        codigo = p.codcat,
                        nombre = p.categoria.nomcat,
                    },
                    estado = p.estpro
                }).ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public List<ProductoBO> productoFindAllCustom()
        {
            try
            {
                return contexto.producto.Where(p => p.estpro).Select(p => new ProductoBO
                {
                    codigo = p.codpro,
                    nombre = p.nompro,
                    descripcion = p.despro,
                    fechaingreso = p.fecing,
                    precio = p.prepro,
                    cantidad = p.canpro,
                    marca = new MarcaBO
                    {
                        codigo = p.codmar,
                        nombre = p.marca.nommar,
                    },
                    categoria = new CategoriaBO
                    {
                        codigo = p.codcat,
                        nombre = p.categoria.nomcat,
                    },
                    estado = p.estpro
                }).ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public ProductoBO productoFindById(ProductoBO obj)
        {
            try
            {
                return contexto.producto.Where(p => p.codpro == obj.codigo).Select(p => new ProductoBO
                {
                    codigo = p.codpro,
                    nombre = p.nompro,
                    descripcion = p.despro,
                    fechaingreso = p.fecing,
                    precio = p.prepro,
                    cantidad = p.canpro,
                    marca = new MarcaBO
                    {
                        codigo = p.codmar,
                        nombre = p.marca.nommar,
                    },
                    categoria = new CategoriaBO
                    {
                        codigo = p.codcat,
                        nombre = p.categoria.nomcat,
                    },
                    estado = p.estpro
                }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
        public bool productoAdd(ProductoBO obj)
        {
            try
            {
                producto pro = new producto
                {
                    nompro = obj.nombre,
                    despro = obj.descripcion,
                    fecing = obj.fechaingreso,
                    prepro = obj.precio,
                    canpro = obj.cantidad,
                    codmar = obj.marca.codigo,
                    codcat = obj.categoria.codigo,
                    estpro = obj.estado
                };
                contexto.producto.Add(pro);
                return contexto.SaveChanges() == 1;
            }
            catch(Exception ex) { 
                Debug.WriteLine(ex.Message);
                return false;
            }
        }
        public bool productoUpdate(ProductoBO obj)
        {
            try
            {
                var pro = contexto.producto.Find(obj.codigo);
                if(pro != null)
                {
                    pro.nompro = obj.nombre;
                    pro.despro = obj.descripcion;
                    pro.fecing = obj.fechaingreso;
                    pro.prepro = obj.precio;
                    pro.canpro = obj.cantidad;
                    pro.codmar = obj.marca.codigo;
                    pro.codcat = obj.categoria.codigo;
                    pro.estpro = obj.estado;
                    return contexto.SaveChanges() == 1;
                }
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public bool productoDelete(ProductoBO obj)
        {
            try
            {
                var pro = contexto.producto.Find(obj.codigo);
                if (pro !=null)
                {
                    pro.estpro = false;
                    return contexto.SaveChanges() == 1;
                }
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }
        public bool productoEnable(ProductoBO obj)
        {
            try
            {
                var pro = contexto.producto.Find(obj.codigo);
                if (pro != null)
                {
                    pro.estpro = true;
                    return contexto.SaveChanges() == 1;
                }
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }
        public int productoSetCode()
        {
            try
            {
                int siguiente = contexto.producto.Any() ? contexto.producto.Max(p => p.codpro + 1) : 1;
                return siguiente;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return 0;
            }
        }
    }
}
