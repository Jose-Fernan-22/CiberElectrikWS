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
    public class ClienteDAL
    {
        private ConexionDAL objConexion = new ConexionDAL();
        private SqlCommand cmd;
        private SqlDataReader dr;

        public List<ClienteBO> MostrarCliente()
        {
            List<ClienteBO> lista = new List<ClienteBO>();
            try
            {
                cmd = new SqlCommand("SP_MostrarCliente", objConexion.Conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ClienteBO obj = new ClienteBO();
                    // Mapeo de datos propios
                    obj.codigo = Convert.ToInt32(dr["codcli"]);
                    obj.nombre = dr["nomcli"].ToString();
                    obj.apellidoPaterno = dr["apepcli"].ToString();
                    obj.apellidoMaterno = dr["apemcli"].ToString();
                    obj.documento = dr["doccli"].ToString();
                    obj.direccion = dr["dircli"].ToString();
                    obj.telefono = dr["telcli"].ToString();
                    obj.celular = dr["celcli"].ToString();
                    obj.correo = dr["corcli"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estcli"]);

                    // Mapeo de llaves foráneas
                    obj.codigoDistrito = Convert.ToInt32(dr["coddis"]);
                    obj.codigoTipoDocumento = Convert.ToInt32(dr["codtipd"]);
                    obj.codigoSexo = Convert.ToInt32(dr["codsex"]);

                    // Mapeo de nombres traídos por los INNER JOIN
                    obj.nombreDistrito = dr["nomdis"].ToString();
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

        public List<ClienteBO> MostrarClienteTodo()
        {
            List<ClienteBO> lista = new List<ClienteBO>();
            try
            {
                cmd = new SqlCommand("SP_MostrarClienteTodo", objConexion.Conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ClienteBO obj = new ClienteBO();
                    obj.codigo = Convert.ToInt32(dr["codcli"]);
                    obj.nombre = dr["nomcli"].ToString();
                    obj.apellidoPaterno = dr["apepcli"].ToString();
                    obj.apellidoMaterno = dr["apemcli"].ToString();
                    obj.documento = dr["doccli"].ToString();
                    obj.direccion = dr["dircli"].ToString();
                    obj.telefono = dr["telcli"].ToString();
                    obj.celular = dr["celcli"].ToString();
                    obj.correo = dr["corcli"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estcli"]);

                    obj.codigoDistrito = Convert.ToInt32(dr["coddis"]);
                    obj.codigoTipoDocumento = Convert.ToInt32(dr["codtipd"]);
                    obj.codigoSexo = Convert.ToInt32(dr["codsex"]);

                    obj.nombreDistrito = dr["nomdis"].ToString();
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

        public bool RegistrarCliente(ClienteBO c)
        {
            bool res = false;
            try
            {
                cmd = new SqlCommand("SP_RegistrarCliente", objConexion.Conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nomcli", c.nombre);
                cmd.Parameters.AddWithValue("@apepcli", c.apellidoPaterno);
                cmd.Parameters.AddWithValue("@apemcli", c.apellidoMaterno);
                cmd.Parameters.AddWithValue("@doccli", c.documento);
                cmd.Parameters.AddWithValue("@dircli", c.direccion);
                cmd.Parameters.AddWithValue("@telcli", c.telefono);
                cmd.Parameters.AddWithValue("@celcli", c.celular);
                cmd.Parameters.AddWithValue("@corcli", c.correo);
                cmd.Parameters.AddWithValue("@estcli", c.estado);
                cmd.Parameters.AddWithValue("@coddis", c.codigoDistrito);
                cmd.Parameters.AddWithValue("@codtipd", c.codigoTipoDocumento);
                cmd.Parameters.AddWithValue("@codsex", c.codigoSexo);

                if (cmd.ExecuteNonQuery() > 0) res = true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { objConexion.CerrarConexion(); }
            return res;
        }

        public ClienteBO BuscarClienteXCodigo(ClienteBO c)
        {
            ClienteBO obj = null;
            try
            {
                cmd = new SqlCommand("SP_BuscarClienteXCodigo", objConexion.Conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", c.codigo);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    obj = new ClienteBO();
                    obj.codigo = Convert.ToInt32(dr["codcli"]);
                    obj.nombre = dr["nomcli"].ToString();
                    obj.apellidoPaterno = dr["apepcli"].ToString();
                    obj.apellidoMaterno = dr["apemcli"].ToString();
                    obj.documento = dr["doccli"].ToString();
                    obj.direccion = dr["dircli"].ToString();
                    obj.telefono = dr["telcli"].ToString();
                    obj.celular = dr["celcli"].ToString();
                    obj.correo = dr["corcli"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estcli"]);

                    obj.codigoDistrito = Convert.ToInt32(dr["coddis"]);
                    obj.codigoTipoDocumento = Convert.ToInt32(dr["codtipd"]);
                    obj.codigoSexo = Convert.ToInt32(dr["codsex"]);

                    obj.nombreDistrito = dr["nomdis"].ToString();
                    obj.nombreTipoDocumento = dr["nomtipd"].ToString();
                    obj.nombreSexo = dr["nomsex"].ToString();
                }
                dr.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { objConexion.CerrarConexion(); }
            return obj;
        }

        public bool ActualizarCliente(ClienteBO c)
        {
            bool res = false;
            try
            {
                cmd = new SqlCommand("SP_ActualizarCliente", objConexion.Conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", c.codigo);
                cmd.Parameters.AddWithValue("@nomcli", c.nombre);
                cmd.Parameters.AddWithValue("@apepcli", c.apellidoPaterno);
                cmd.Parameters.AddWithValue("@apemcli", c.apellidoMaterno);
                cmd.Parameters.AddWithValue("@doccli", c.documento);
                cmd.Parameters.AddWithValue("@dircli", c.direccion);
                cmd.Parameters.AddWithValue("@telcli", c.telefono);
                cmd.Parameters.AddWithValue("@celcli", c.celular);
                cmd.Parameters.AddWithValue("@corcli", c.correo);
                cmd.Parameters.AddWithValue("@estcli", c.estado);
                cmd.Parameters.AddWithValue("@coddis", c.codigoDistrito);
                cmd.Parameters.AddWithValue("@codtipd", c.codigoTipoDocumento);
                cmd.Parameters.AddWithValue("@codsex", c.codigoSexo);

                if (cmd.ExecuteNonQuery() > 0) res = true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { objConexion.CerrarConexion(); }
            return res;
        }

        public bool EliminarCliente(ClienteBO c)
        {
            bool res = false;
            try
            {
                cmd = new SqlCommand("SP_EliminarCliente", objConexion.Conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", c.codigo);
                if (cmd.ExecuteNonQuery() > 0) res = true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { objConexion.CerrarConexion(); }
            return res;
        }

        public bool HabilitarCliente(ClienteBO c)
        {
            bool res = false;
            try
            {
                cmd = new SqlCommand("SP_HabilitarCliente", objConexion.Conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", c.codigo);
                if (cmd.ExecuteNonQuery() > 0) res = true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { objConexion.CerrarConexion(); }
            return res;
        }

        public int MostrarCodigoCliente()
        {
            int codigo = 0;
            try
            {
                cmd = new SqlCommand("SP_CodigoCliente", objConexion.Conectar());
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