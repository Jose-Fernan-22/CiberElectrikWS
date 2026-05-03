using pe.com.ciberelectrik.bo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace pe.com.ciberelectrik.dal
{
    public class EmpleadoDAL
    {
        private ConexionDAL objConexion = new ConexionDAL();
        private SqlCommand cmd;
        private SqlDataReader dr;

        public List<EmpleadoBO> MostrarEmpleado()
        {
            List<EmpleadoBO> lista = new List<EmpleadoBO>();
            try
            {
                cmd = new SqlCommand("SP_MostrarEmpleado", objConexion.Conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EmpleadoBO obj = new EmpleadoBO();
                    // Mapeo de datos propios
                    obj.codigo = Convert.ToInt32(dr["codemp"]);
                    obj.nombre = dr["nomemp"].ToString();
                    obj.apellidoPaterno = dr["apepemp"].ToString();
                    obj.apellidoMaterno = dr["apememp"].ToString();
                    obj.documento = dr["docemp"].ToString();
                    obj.direccion = dr["diremp"].ToString();
                    obj.telefono = dr["telemp"].ToString();
                    obj.celular = dr["celemp"].ToString();
                    obj.correo = dr["coremp"].ToString();
                    obj.usuario = dr["usuemp"].ToString();
                    // La clave (claemp) generalmente no se devuelve en los listados por seguridad, 
                    // pero si la necesitas, se agregaría aquí.
                    obj.estado = Convert.ToBoolean(dr["estemp"]);

                    // Mapeo de llaves foráneas
                    obj.codigoDistrito = Convert.ToInt32(dr["coddis"]);
                    obj.codigoRol = Convert.ToInt32(dr["codrol"]);
                    obj.codigoTipoDocumento = Convert.ToInt32(dr["codtipd"]);
                    obj.codigoSexo = Convert.ToInt32(dr["codsex"]);

                    // Mapeo de nombres traídos por los INNER JOIN
                    obj.nombreDistrito = dr["nomdis"].ToString();
                    obj.nombreRol = dr["nomrol"].ToString();
                    obj.nombreTipoDocumento = dr["nomtipd"].ToString();
                    obj.nombreSexo = dr["nomsex"].ToString();

                    lista.Add(obj);
                }
                dr.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { objConexion.CerrarConexion(); }
            return lista;
        }

        public List<EmpleadoBO> MostrarEmpleadoTodo()
        {
            List<EmpleadoBO> lista = new List<EmpleadoBO>();
            try
            {
                cmd = new SqlCommand("SP_MostrarEmpleadoTodo", objConexion.Conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EmpleadoBO obj = new EmpleadoBO();
                    obj.codigo = Convert.ToInt32(dr["codemp"]);
                    obj.nombre = dr["nomemp"].ToString();
                    obj.apellidoPaterno = dr["apepemp"].ToString();
                    obj.apellidoMaterno = dr["apememp"].ToString();
                    obj.documento = dr["docemp"].ToString();
                    obj.direccion = dr["diremp"].ToString();
                    obj.telefono = dr["telemp"].ToString();
                    obj.celular = dr["celemp"].ToString();
                    obj.correo = dr["coremp"].ToString();
                    obj.usuario = dr["usuemp"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estemp"]);

                    obj.codigoDistrito = Convert.ToInt32(dr["coddis"]);
                    obj.codigoRol = Convert.ToInt32(dr["codrol"]);
                    obj.codigoTipoDocumento = Convert.ToInt32(dr["codtipd"]);
                    obj.codigoSexo = Convert.ToInt32(dr["codsex"]);

                    obj.nombreDistrito = dr["nomdis"].ToString();
                    obj.nombreRol = dr["nomrol"].ToString();
                    obj.nombreTipoDocumento = dr["nomtipd"].ToString();
                    obj.nombreSexo = dr["nomsex"].ToString();

                    lista.Add(obj);
                }
                dr.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { objConexion.CerrarConexion(); }
            return lista;
        }

        public bool RegistrarEmpleado(EmpleadoBO e)
        {
            bool res = false;
            try
            {
                cmd = new SqlCommand("SP_RegistrarEmpleado", objConexion.Conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nomemp", e.nombre);
                cmd.Parameters.AddWithValue("@apepemp", e.apellidoPaterno);
                cmd.Parameters.AddWithValue("@apememp", e.apellidoMaterno);
                cmd.Parameters.AddWithValue("@docemp", e.documento);
                cmd.Parameters.AddWithValue("@diremp", e.direccion);
                cmd.Parameters.AddWithValue("@telemp", e.telefono);
                cmd.Parameters.AddWithValue("@celemp", e.celular);
                cmd.Parameters.AddWithValue("@coremp", e.correo);
                cmd.Parameters.AddWithValue("@usuemp", e.usuario);
                cmd.Parameters.AddWithValue("@claemp", e.clave); // Se envía la clave al registrar
                cmd.Parameters.AddWithValue("@estemp", e.estado);
                cmd.Parameters.AddWithValue("@coddis", e.codigoDistrito);
                cmd.Parameters.AddWithValue("@codrol", e.codigoRol);
                cmd.Parameters.AddWithValue("@codtipd", e.codigoTipoDocumento);
                cmd.Parameters.AddWithValue("@codsex", e.codigoSexo);

                if (cmd.ExecuteNonQuery() > 0) res = true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { objConexion.CerrarConexion(); }
            return res;
        }

        public EmpleadoBO BuscarEmpleadoXCodigo(EmpleadoBO e)
        {
            EmpleadoBO obj = null;
            try
            {
                cmd = new SqlCommand("SP_BuscarEmpleadoXCodigo", objConexion.Conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", e.codigo);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    obj = new EmpleadoBO();
                    obj.codigo = Convert.ToInt32(dr["codemp"]);
                    obj.nombre = dr["nomemp"].ToString();
                    obj.apellidoPaterno = dr["apepemp"].ToString();
                    obj.apellidoMaterno = dr["apememp"].ToString();
                    obj.documento = dr["docemp"].ToString();
                    obj.direccion = dr["diremp"].ToString();
                    obj.telefono = dr["telemp"].ToString();
                    obj.celular = dr["celemp"].ToString();
                    obj.correo = dr["coremp"].ToString();
                    obj.usuario = dr["usuemp"].ToString();
                    obj.clave = dr["claemp"].ToString(); // Recuperamos la clave al buscar por código específico
                    obj.estado = Convert.ToBoolean(dr["estemp"]);

                    obj.codigoDistrito = Convert.ToInt32(dr["coddis"]);
                    obj.codigoRol = Convert.ToInt32(dr["codrol"]);
                    obj.codigoTipoDocumento = Convert.ToInt32(dr["codtipd"]);
                    obj.codigoSexo = Convert.ToInt32(dr["codsex"]);

                    obj.nombreDistrito = dr["nomdis"].ToString();
                    obj.nombreRol = dr["nomrol"].ToString();
                    obj.nombreTipoDocumento = dr["nomtipd"].ToString();
                    obj.nombreSexo = dr["nomsex"].ToString();
                }
                dr.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { objConexion.CerrarConexion(); }
            return obj;
        }

        public bool ActualizarEmpleado(EmpleadoBO e)
        {
            bool res = false;
            try
            {
                cmd = new SqlCommand("SP_ActualizarEmpleado", objConexion.Conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", e.codigo);
                cmd.Parameters.AddWithValue("@nomemp", e.nombre);
                cmd.Parameters.AddWithValue("@apepemp", e.apellidoPaterno);
                cmd.Parameters.AddWithValue("@apememp", e.apellidoMaterno);
                cmd.Parameters.AddWithValue("@docemp", e.documento);
                cmd.Parameters.AddWithValue("@diremp", e.direccion);
                cmd.Parameters.AddWithValue("@telemp", e.telefono);
                cmd.Parameters.AddWithValue("@celemp", e.celular);
                cmd.Parameters.AddWithValue("@coremp", e.correo);
                cmd.Parameters.AddWithValue("@usuemp", e.usuario);
                cmd.Parameters.AddWithValue("@claemp", e.clave); // Se actualiza la clave
                cmd.Parameters.AddWithValue("@estemp", e.estado);
                cmd.Parameters.AddWithValue("@coddis", e.codigoDistrito);
                cmd.Parameters.AddWithValue("@codrol", e.codigoRol);
                cmd.Parameters.AddWithValue("@codtipd", e.codigoTipoDocumento);
                cmd.Parameters.AddWithValue("@codsex", e.codigoSexo);

                if (cmd.ExecuteNonQuery() > 0) res = true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { objConexion.CerrarConexion(); }
            return res;
        }

        public bool EliminarEmpleado(EmpleadoBO e)
        {
            bool res = false;
            try
            {
                cmd = new SqlCommand("SP_EliminarEmpleado", objConexion.Conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", e.codigo);
                if (cmd.ExecuteNonQuery() > 0) res = true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { objConexion.CerrarConexion(); }
            return res;
        }

        public bool HabilitarEmpleado(EmpleadoBO e)
        {
            bool res = false;
            try
            {
                cmd = new SqlCommand("SP_HabilitarEmpleado", objConexion.Conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", e.codigo);
                if (cmd.ExecuteNonQuery() > 0) res = true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { objConexion.CerrarConexion(); }
            return res;
        }

        public int MostrarCodigoEmpleado()
        {
            int codigo = 0;
            try
            {
                cmd = new SqlCommand("SP_CodigoEmpleado", objConexion.Conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.Read()) codigo = Convert.ToInt32(dr["SiguienteCodigo"]);
                dr.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { objConexion.CerrarConexion(); }
            return codigo;
        }
    }
}