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
    public class RolDAL
    {
        private ConexionDAL objConexion = new ConexionDAL();
        private SqlCommand cmd;
        private SqlDataReader dr;

        public List<RolBO> MostrarRol()
        {
            List<RolBO> lista = new List<RolBO>();
            try
            {
                cmd = new SqlCommand("SP_MostrarRol", objConexion.Conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    RolBO obj = new RolBO();
                    obj.codigo = Convert.ToInt32(dr["codrol"]); //[cite: 3]
                    obj.nombre = dr["nomrol"].ToString(); //[cite: 3]
                    obj.estado = Convert.ToBoolean(dr["estrol"]); //[cite: 3]
                    lista.Add(obj);
                }
                dr.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { objConexion.CerrarConexion(); }
            return lista;
        }

        public List<RolBO> MostrarRolTodo()
        {
            List<RolBO> lista = new List<RolBO>();
            try
            {
                cmd = new SqlCommand("SP_MostrarRolTodo", objConexion.Conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    RolBO obj = new RolBO();
                    obj.codigo = Convert.ToInt32(dr["codrol"]); //[cite: 3]
                    obj.nombre = dr["nomrol"].ToString(); //[cite: 3]
                    obj.estado = Convert.ToBoolean(dr["estrol"]); //[cite: 3]
                    lista.Add(obj);
                }
                dr.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { objConexion.CerrarConexion(); }
            return lista;
        }

        public bool RegistrarRol(RolBO r)
        {
            bool res = false;
            try
            {
                cmd = new SqlCommand("SP_RegistrarRol", objConexion.Conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", r.nombre);
                cmd.Parameters.AddWithValue("@estado", r.estado);
                if (cmd.ExecuteNonQuery() > 0) res = true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { objConexion.CerrarConexion(); }
            return res;
        }

        public RolBO BuscarRolXCodigo(RolBO r)
        {
            RolBO obj = null;
            try
            {
                cmd = new SqlCommand("SP_BuscarRolXCodigo", objConexion.Conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", r.codigo);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    obj = new RolBO();
                    obj.codigo = Convert.ToInt32(dr["codrol"]); //[cite: 3]
                    obj.nombre = dr["nomrol"].ToString(); //[cite: 3]
                    obj.estado = Convert.ToBoolean(dr["estrol"]); //[cite: 3]
                }
                dr.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { objConexion.CerrarConexion(); }
            return obj;
        }

        public bool ActualizarRol(RolBO r)
        {
            bool res = false;
            try
            {
                cmd = new SqlCommand("SP_ActualizarRol", objConexion.Conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", r.codigo);
                cmd.Parameters.AddWithValue("@nombre", r.nombre);
                cmd.Parameters.AddWithValue("@estado", r.estado);
                if (cmd.ExecuteNonQuery() > 0) res = true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { objConexion.CerrarConexion(); }
            return res;
        }

        public bool EliminarRol(RolBO r)
        {
            bool res = false;
            try
            {
                cmd = new SqlCommand("SP_EliminarRol", objConexion.Conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", r.codigo);
                if (cmd.ExecuteNonQuery() > 0) res = true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { objConexion.CerrarConexion(); }
            return res;
        }

        public bool HabilitarRol(RolBO r)
        {
            bool res = false;
            try
            {
                cmd = new SqlCommand("SP_HabilitarRol", objConexion.Conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", r.codigo);
                if (cmd.ExecuteNonQuery() > 0) res = true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { objConexion.CerrarConexion(); }
            return res;
        }

        public int MostrarCodigoRol()
        {
            int codigo = 0;
            try
            {
                cmd = new SqlCommand("SP_CodigoRol", objConexion.Conectar());
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