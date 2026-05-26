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
                return contexto.SP_MostrarCategoriaTodo().Select(c => new CategoriaBO
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
                return contexto.SP_MostrarCategoria().Where(c => c.estcat).Select(c => new CategoriaBO
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
                return contexto.SP_BuscarCategoriaXCodigo(obj.codigo).Select(c => new CategoriaBO
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
                int res = contexto.SP_RegistrarCategoria(obj.nombre, obj.estado);
                return res == 1;
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
                if (obj.codigo != 0)
                {
                    int res = contexto.SP_ActualizarCategoria(obj.codigo,obj.nombre, obj.estado);
                    return res == 1;
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
                if (obj.codigo != 0)
                {
                    int res = contexto.SP_EliminarCategoria(obj.codigo);
                    return res == 1;
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
                if (obj.codigo != 0)
                {
                    int res = contexto.SP_HabilitarCategoria(obj.codigo);
                    return res == 1;
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
                return Convert.ToInt32(contexto.SP_CodigoCategoria());
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
            try
            {
                return contexto.distrito.Select(d => new DistritoBO
                {
                    codigo = d.coddis,
                    nombre = d.nomdis,
                    estado = d.estdis
                }).ToList();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public List<DistritoBO> distritoFindAllCustom()
        {
            try
            {
                return contexto.distrito.Where(d => d.estdis).Select(d => new DistritoBO
                {
                    codigo = d.coddis,
                    nombre = d.nomdis,
                    estado = d.estdis
                }).ToList();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public DistritoBO distritoFindById(DistritoBO obj)
        {
            try
            {
                return contexto.distrito.Where(d => d.coddis == obj.codigo).Select(d => new DistritoBO
                {
                    codigo = d.coddis,
                    nombre = d.nomdis,
                    estado = d.estdis
                }).FirstOrDefault();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public bool distritoAdd(DistritoBO obj)
        {
            try
            {
                contexto.distrito.Add(new distrito { nomdis = obj.nombre, estdis = obj.estado });
                return contexto.SaveChanges() > 0;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool distritoUpdate(DistritoBO obj)
        {
            try
            {
                var d = contexto.distrito.Find(obj.codigo);
                if (d != null) { d.nomdis = obj.nombre; d.estdis = obj.estado; return contexto.SaveChanges() > 0; }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool distritoDelete(DistritoBO obj)
        {
            try
            {
                var d = contexto.distrito.Find(obj.codigo);
                if (d != null) { d.estdis = false; return contexto.SaveChanges() > 0; }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool distritoEnable(DistritoBO obj)
        {
            try
            {
                var d = contexto.distrito.Find(obj.codigo);
                if (d != null) { d.estdis = true; return contexto.SaveChanges() > 0; }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public int distritoSetCode()
        {
            try { return contexto.distrito.Any() ? contexto.distrito.Max(d => d.coddis) + 1 : 1; }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return 0; }
        }

        //-------------------------------ROL-------------------------
        public List<RolBO> rolFindAll()
        {
            try
            {
                return contexto.rol.Select(r => new RolBO
                {
                    codigo = r.codrol,
                    nombre = r.nomrol,
                    estado = r.estrol
                }).ToList();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public List<RolBO> rolFindAllCustom()
        {
            try
            {
                return contexto.rol.Where(r => r.estrol).Select(r => new RolBO
                {
                    codigo = r.codrol,
                    nombre = r.nomrol,
                    estado = r.estrol
                }).ToList();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public RolBO rolFindById(RolBO obj)
        {
            try
            {
                return contexto.rol.Where(r => r.codrol == obj.codigo).Select(r => new RolBO
                {
                    codigo = r.codrol,
                    nombre = r.nomrol,
                    estado = r.estrol
                }).FirstOrDefault();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public bool rolAdd(RolBO obj)
        {
            try
            {
                contexto.rol.Add(new rol { nomrol = obj.nombre, estrol = obj.estado });
                return contexto.SaveChanges() > 0;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool rolUpdate(RolBO obj)
        {
            try
            {
                var r = contexto.rol.Find(obj.codigo);
                if (r != null) { r.nomrol = obj.nombre; r.estrol = obj.estado; return contexto.SaveChanges() > 0; }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool rolDelete(RolBO obj)
        {
            try
            {
                var r = contexto.rol.Find(obj.codigo);
                if (r != null) { r.estrol = false; return contexto.SaveChanges() > 0; }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool rolEnable(RolBO obj)
        {
            try
            {
                var r = contexto.rol.Find(obj.codigo);
                if (r != null) { r.estrol = true; return contexto.SaveChanges() > 0; }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public int rolSetCode()
        {
            try { return contexto.rol.Any() ? contexto.rol.Max(r => r.codrol) + 1 : 1; }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return 0; }
        }

        //-------------------------------TIPODOCUMENTO---------------

        public List<TipoDocumentoBO> tipoDocumentoFindAll()
        {
            try
            {
                return contexto.tipodocumento.Select(t => new TipoDocumentoBO
                {
                    codigo = t.codtipd,
                    nombre = t.nomtipd,
                    estado = t.esttipd
                }).ToList();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public List<TipoDocumentoBO> tipoDocumentoFindAllCustom()
        {
            try
            {
                return contexto.tipodocumento.Where(t => t.esttipd).Select(t => new TipoDocumentoBO
                {
                    codigo = t.codtipd,
                    nombre = t.nomtipd,
                    estado = t.esttipd
                }).ToList();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public TipoDocumentoBO tipoDocumentoFindById(TipoDocumentoBO obj)
        {
            try
            {
                return contexto.tipodocumento.Where(t => t.codtipd == obj.codigo).Select(t => new TipoDocumentoBO
                {
                    codigo = t.codtipd,
                    nombre = t.nomtipd,
                    estado = t.esttipd
                }).FirstOrDefault();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public bool tipoDocumentoAdd(TipoDocumentoBO obj)
        {
            try
            {
                contexto.tipodocumento.Add(new tipodocumento { nomtipd = obj.nombre, esttipd = obj.estado });
                return contexto.SaveChanges() > 0;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool tipoDocumentoUpdate(TipoDocumentoBO obj)
        {
            try
            {
                var t = contexto.tipodocumento.Find(obj.codigo);
                if (t != null) { t.nomtipd = obj.nombre; t.esttipd = obj.estado; return contexto.SaveChanges() > 0; }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool tipoDocumentoDelete(TipoDocumentoBO obj)
        {
            try
            {
                var t = contexto.tipodocumento.Find(obj.codigo);
                if (t != null) { t.esttipd = false; return contexto.SaveChanges() > 0; }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool tipoDocumentoEnable(TipoDocumentoBO obj)
        {
            try
            {
                var t = contexto.tipodocumento.Find(obj.codigo);
                if (t != null) { t.esttipd = true; return contexto.SaveChanges() > 0; }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public int tipoDocumentoSetCode()
        {
            try { return contexto.tipodocumento.Any() ? contexto.tipodocumento.Max(t => t.codtipd) + 1 : 1; }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return 0; }
        }
        //-------------------------------SEXO------------------------
        public List<SexoBO> sexoFindAll()
        {
            try
            {
                return contexto.sexo.Select(s => new SexoBO
                {
                    codigo = s.codsex,
                    nombre = s.nomsex,
                    estado = s.estsex
                }).ToList();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public List<SexoBO> sexoFindAllCustom()
        {
            try
            {
                return contexto.sexo.Where(s => s.estsex).Select(s => new SexoBO
                {
                    codigo = s.codsex,
                    nombre = s.nomsex,
                    estado = s.estsex
                }).ToList();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public SexoBO sexoFindById(SexoBO obj)
        {
            try
            {
                return contexto.sexo.Where(s => s.codsex == obj.codigo).Select(s => new SexoBO
                {
                    codigo = s.codsex,
                    nombre = s.nomsex,
                    estado = s.estsex
                }).FirstOrDefault();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public bool sexoAdd(SexoBO obj)
        {
            try
            {
                contexto.sexo.Add(new sexo { nomsex = obj.nombre, estsex = obj.estado });
                return contexto.SaveChanges() > 0;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool sexoUpdate(SexoBO obj)
        {
            try
            {
                var s = contexto.sexo.Find(obj.codigo);
                if (s != null) { s.nomsex = obj.nombre; s.estsex = obj.estado; return contexto.SaveChanges() > 0; }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool sexoDelete(SexoBO obj)
        {
            try
            {
                var s = contexto.sexo.Find(obj.codigo);
                if (s != null) { s.estsex = false; return contexto.SaveChanges() > 0; }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool sexoEnable(SexoBO obj)
        {
            try
            {
                var s = contexto.sexo.Find(obj.codigo);
                if (s != null) { s.estsex = true; return contexto.SaveChanges() > 0; }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public int sexoSetCode()
        {
            try { return contexto.sexo.Any() ? contexto.sexo.Max(s => s.codsex) + 1 : 1; }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return 0; }
        }

        //-------------------------------EMPLEADO--------------------
        public List<EmpleadoBO> empleadoFindAll()
        {
            try
            {
                return contexto.empleado.Select(e => new EmpleadoBO
                {
                    codigo = e.codemp,
                    nombre = e.nomemp,
                    apellidoPaterno = e.apepemp,
                    apellidoMaterno = e.apememp,
                    documento = e.docemp,
                    direccion = e.diremp,
                    telefono = e.telemp,
                    celular = e.celemp,
                    correo = e.coremp,
                    usuario = e.usuemp,
                    estado = e.estemp,
                    codigoDistrito = e.coddis,
                    codigoRol = e.codrol,
                    codigoTipoDocumento = e.codtipd,
                    codigoSexo = e.codsex,
                    nombreDistrito = e.distrito.nomdis,
                    nombreRol = e.rol.nomrol,
                    nombreTipoDocumento = e.tipodocumento.nomtipd,
                    nombreSexo = e.sexo.nomsex
                }).ToList();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public List<EmpleadoBO> empleadoFindAllCustom()
        {
            try
            {
                return contexto.empleado.Where(e => e.estemp).Select(e => new EmpleadoBO
                {
                    codigo = e.codemp,
                    nombre = e.nomemp,
                    apellidoPaterno = e.apepemp,
                    apellidoMaterno = e.apememp,
                    documento = e.docemp,
                    direccion = e.diremp,
                    telefono = e.telemp,
                    celular = e.celemp,
                    correo = e.coremp,
                    usuario = e.usuemp,
                    estado = e.estemp,
                    codigoDistrito = e.coddis,
                    codigoRol = e.codrol,
                    codigoTipoDocumento = e.codtipd,
                    codigoSexo = e.codsex,
                    nombreDistrito = e.distrito.nomdis,
                    nombreRol = e.rol.nomrol,
                    nombreTipoDocumento = e.tipodocumento.nomtipd,
                    nombreSexo = e.sexo.nomsex
                }).ToList();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public EmpleadoBO empleadoFindById(EmpleadoBO obj)
        {
            try
            {
                return contexto.empleado.Where(e => e.codemp == obj.codigo).Select(e => new EmpleadoBO
                {
                    codigo = e.codemp,
                    nombre = e.nomemp,
                    apellidoPaterno = e.apepemp,
                    apellidoMaterno = e.apememp,
                    documento = e.docemp,
                    direccion = e.diremp,
                    telefono = e.telemp,
                    celular = e.celemp,
                    correo = e.coremp,
                    usuario = e.usuemp,
                    clave = e.claemp,
                    estado = e.estemp,
                    codigoDistrito = e.coddis,
                    codigoRol = e.codrol,
                    codigoTipoDocumento = e.codtipd,
                    codigoSexo = e.codsex,
                    nombreDistrito = e.distrito.nomdis,
                    nombreRol = e.rol.nomrol,
                    nombreTipoDocumento = e.tipodocumento.nomtipd,
                    nombreSexo = e.sexo.nomsex
                }).FirstOrDefault();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public bool empleadoAdd(EmpleadoBO obj)
        {
            try
            {
                empleado emp = new empleado
                {
                    nomemp = obj.nombre,
                    apepemp = obj.apellidoPaterno,
                    apememp = obj.apellidoMaterno,
                    docemp = obj.documento,
                    diremp = obj.direccion,
                    telemp = obj.telefono,
                    celemp = obj.celular,
                    coremp = obj.correo,
                    usuemp = obj.usuario,
                    claemp = obj.clave,
                    estemp = obj.estado,
                    coddis = obj.codigoDistrito,
                    codrol = obj.codigoRol,
                    codtipd = obj.codigoTipoDocumento,
                    codsex = obj.codigoSexo
                };
                contexto.empleado.Add(emp);
                return contexto.SaveChanges() > 0;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool empleadoUpdate(EmpleadoBO obj)
        {
            try
            {
                var e = contexto.empleado.Find(obj.codigo);
                if (e != null)
                {
                    e.nomemp = obj.nombre; e.apepemp = obj.apellidoPaterno; e.apememp = obj.apellidoMaterno;
                    e.docemp = obj.documento; e.diremp = obj.direccion; e.telemp = obj.telefono; e.celemp = obj.celular;
                    e.coremp = obj.correo; e.usuemp = obj.usuario; e.claemp = obj.clave; e.estemp = obj.estado;
                    e.coddis = obj.codigoDistrito; e.codrol = obj.codigoRol; e.codtipd = obj.codigoTipoDocumento; e.codsex = obj.codigoSexo;
                    return contexto.SaveChanges() > 0;
                }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool empleadoDelete(EmpleadoBO obj)
        {
            try
            {
                var e = contexto.empleado.Find(obj.codigo);
                if (e != null) { e.estemp = false; return contexto.SaveChanges() > 0; }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool empleadoEnable(EmpleadoBO obj)
        {
            try
            {
                var e = contexto.empleado.Find(obj.codigo);
                if (e != null) { e.estemp = true; return contexto.SaveChanges() > 0; }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public int empleadoSetCode()
        {
            try { return contexto.empleado.Any() ? contexto.empleado.Max(e => e.codemp) + 1 : 1; }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return 0; }
        }

        //-------------------------------CLIENTE---------------------
        public List<ClienteBO> clienteFindAll()
        {
            try
            {
                return contexto.cliente.Select(c => new ClienteBO
                {
                    codigo = c.codcli,
                    nombre = c.nomcli,
                    apellidoPaterno = c.apepcli,
                    apellidoMaterno = c.apemcli,
                    documento = c.doccli,
                    direccion = c.dircli,
                    telefono = c.telcli,
                    celular = c.celcli,
                    correo = c.corcli,
                    estado = c.estcli,
                    codigoDistrito = c.coddis,
                    codigoTipoDocumento = c.codtipd,
                    codigoSexo = c.codsex,
                    nombreDistrito = c.distrito.nomdis,
                    nombreTipoDocumento = c.tipodocumento.nomtipd,
                    nombreSexo = c.sexo.nomsex
                }).ToList();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public List<ClienteBO> clienteFindAllCustom()
        {
            try
            {
                return contexto.cliente.Where(c => c.estcli).Select(c => new ClienteBO
                {
                    codigo = c.codcli,
                    nombre = c.nomcli,
                    apellidoPaterno = c.apepcli,
                    apellidoMaterno = c.apemcli,
                    documento = c.doccli,
                    direccion = c.dircli,
                    telefono = c.telcli,
                    celular = c.celcli,
                    correo = c.corcli,
                    estado = c.estcli,
                    codigoDistrito = c.coddis,
                    codigoTipoDocumento = c.codtipd,
                    codigoSexo = c.codsex,
                    nombreDistrito = c.distrito.nomdis,
                    nombreTipoDocumento = c.tipodocumento.nomtipd,
                    nombreSexo = c.sexo.nomsex
                }).ToList();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public ClienteBO clienteFindById(ClienteBO obj)
        {
            try
            {
                return contexto.cliente.Where(c => c.codcli == obj.codigo).Select(c => new ClienteBO
                {
                    codigo = c.codcli,
                    nombre = c.nomcli,
                    apellidoPaterno = c.apepcli,
                    apellidoMaterno = c.apemcli,
                    documento = c.doccli,
                    direccion = c.dircli,
                    telefono = c.telcli,
                    celular = c.celcli,
                    correo = c.corcli,
                    estado = c.estcli,
                    codigoDistrito = c.coddis,
                    codigoTipoDocumento = c.codtipd,
                    codigoSexo = c.codsex,
                    nombreDistrito = c.distrito.nomdis,
                    nombreTipoDocumento = c.tipodocumento.nomtipd,
                    nombreSexo = c.sexo.nomsex
                }).FirstOrDefault();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public bool clienteAdd(ClienteBO obj)
        {
            try
            {
                cliente cli = new cliente
                {
                    nomcli = obj.nombre,
                    apepcli = obj.apellidoPaterno,
                    apemcli = obj.apellidoMaterno,
                    doccli = obj.documento,
                    dircli = obj.direccion,
                    telcli = obj.telefono,
                    celcli = obj.celular,
                    corcli = obj.correo,
                    estcli = obj.estado,
                    coddis = obj.codigoDistrito,
                    codtipd = obj.codigoTipoDocumento,
                    codsex = obj.codigoSexo
                };
                contexto.cliente.Add(cli);
                return contexto.SaveChanges() > 0;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool clienteUpdate(ClienteBO obj)
        {
            try
            {
                var c = contexto.cliente.Find(obj.codigo);
                if (c != null)
                {
                    c.nomcli = obj.nombre; c.apepcli = obj.apellidoPaterno; c.apemcli = obj.apellidoMaterno;
                    c.doccli = obj.documento; c.dircli = obj.direccion; c.telcli = obj.telefono; c.celcli = obj.celular;
                    c.corcli = obj.correo; c.estcli = obj.estado;
                    c.coddis = obj.codigoDistrito; c.codtipd = obj.codigoTipoDocumento; c.codsex = obj.codigoSexo;
                    return contexto.SaveChanges() > 0;
                }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool clienteDelete(ClienteBO obj)
        {
            try
            {
                var c = contexto.cliente.Find(obj.codigo);
                if (c != null) { c.estcli = false; return contexto.SaveChanges() > 0; }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool clienteEnable(ClienteBO obj)
        {
            try
            {
                var c = contexto.cliente.Find(obj.codigo);
                if (c != null) { c.estcli = true; return contexto.SaveChanges() > 0; }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public int clienteSetCode()
        {
            try { return contexto.cliente.Any() ? contexto.cliente.Max(c => c.codcli) + 1 : 1; }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return 0; }
        }

        //-------------------------------PRODUCTO--------------------

        public List<ProductoBO> productoFindAll()
        {
            try
            {
                return contexto.SP_MostrarProductoTodo().Select(p => new ProductoBO
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
                        nombre = p.nommar,
                    },
                    categoria = new CategoriaBO
                    {
                        codigo = p.codcat,
                        nombre = p.nomcat,
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
                return contexto.SP_MostrarProducto().Where(p => p.estpro).Select(p => new ProductoBO
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
                        nombre = p.nommar,
                    },
                    categoria = new CategoriaBO
                    {
                        codigo = p.codcat,
                        nombre = p.nomcat,
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
                return contexto.SP_BuscarProductoXCodigo(obj.codigo).Select(p => new ProductoBO
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
                        nombre = p.nommar,
                    },
                    categoria = new CategoriaBO
                    {
                        codigo = p.codcat,
                        nombre = p.nomcat,
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
                int res = contexto.SP_RegistrarProducto(obj.nombre,obj.descripcion, obj.precio, obj.cantidad,
                    obj.fechaingreso, obj.estado, obj.categoria.codigo, obj.marca.codigo);
                return res == 1;
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
                if(obj.codigo != 0)
                {
                    int res = contexto.SP_ActualizarProducto(obj.codigo,obj.nombre, obj.descripcion, obj.precio, obj.cantidad,
                    obj.fechaingreso, obj.estado, obj.categoria.codigo, obj.marca.codigo);
                    return res == 1;

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
                var pro = contexto.SP_BuscarProductoXCodigo(obj.codigo);
                if (pro != null)
                {
                    int res = contexto.SP_EliminarProducto(obj.codigo);
                    return res == 1;

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
                if (obj.codigo != 0)
                {
                    int res = contexto.SP_HabilitarProducto(obj.codigo);
                    return res == 1;

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
                return Convert.ToInt32(contexto.SP_CodigoProducto());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return 0;
            }
        }
    }
}
