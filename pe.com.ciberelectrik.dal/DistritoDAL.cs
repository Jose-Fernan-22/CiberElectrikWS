using pe.com.ciberelectrik.bo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.ciberelectrik.dal //[cite: 5]
{
    public class DistritoDAL
    {
        private ConexionDAL objConexion = new ConexionDAL();
        private SqlCommand cmd;
        private SqlDataReader dr;

        public List<DistritoBO> MostrarDistrito()
        {
            List<DistritoBO> lista = new List<DistritoBO>();
            try
            {
                cmd = new SqlCommand("SP_MostrarDistrito", objConexion.Conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DistritoBO obj = new DistritoBO();
                    obj.codigo = Convert.ToInt32(dr["coddis"]); //[cite: 3]
                    obj.nombre = dr["nomdis"].ToString(); //[cite: 3]
                    obj.estado = Convert.ToBoolean(dr["estdis"]); //[cite: 3]
                    lista.Add(obj);
                }
                dr.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { objConexion.CerrarConexion(); }
            return lista;
        }

        public List<DistritoBO> MostrarDistritoTodo()
        {
            List<DistritoBO> lista = new List<DistritoBO>();
            try
            {
                cmd = new SqlCommand("SP_MostrarDistritoTodo", objConexion.Conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DistritoBO obj = new DistritoBO();
                    obj.codigo = Convert.ToInt32(dr["coddis"]); //[cite: 3]
                    obj.nombre = dr["nomdis"].ToString(); //[cite: 3]
                    obj.estado = Convert.ToBoolean(dr["estdis"]); //[cite: 3]
                    lista.Add(obj);
                }
                dr.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { objConexion.CerrarConexion(); }
            return lista;
        }

        public bool RegistrarDistrito(DistritoBO d)
        {
            bool res = false;
            try
            {
                cmd = new SqlCommand("SP_RegistrarDistrito", objConexion.Conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", d.nombre);
                cmd.Parameters.AddWithValue("@estado", d.estado);
                if (cmd.ExecuteNonQuery() > 0) res = true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { objConexion.CerrarConexion(); }
            return res;
        }

        public DistritoBO BuscarDistritoXCodigo(DistritoBO d)
        {
            DistritoBO obj = null;
            try
            {
                cmd = new SqlCommand("SP_BuscarDistritoXCodigo", objConexion.Conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", d.codigo);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    obj = new DistritoBO();
                    obj.codigo = Convert.ToInt32(dr["coddis"]); //[cite: 3]
                    obj.nombre = dr["nomdis"].ToString(); //[cite: 3]
                    obj.estado = Convert.ToBoolean(dr["estdis"]); //[cite: 3]
                }
                dr.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { objConexion.CerrarConexion(); }
            return obj;
        }

        public bool ActualizarDistrito(DistritoBO d)
        {
            bool res = false;
            try
            {
                cmd = new SqlCommand("SP_ActualizarDistrito", objConexion.Conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", d.codigo);
                cmd.Parameters.AddWithValue("@nombre", d.nombre);
                cmd.Parameters.AddWithValue("@estado", d.estado);
                if (cmd.ExecuteNonQuery() > 0) res = true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { objConexion.CerrarConexion(); }
            return res;
        }

        public bool EliminarDistrito(DistritoBO d)
        {
            bool res = false;
            try
            {
                cmd = new SqlCommand("SP_EliminarDistrito", objConexion.Conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", d.codigo);
                if (cmd.ExecuteNonQuery() > 0) res = true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { objConexion.CerrarConexion(); }
            return res;
        }

        public bool HabilitarDistrito(DistritoBO d)
        {
            bool res = false;
            try
            {
                cmd = new SqlCommand("SP_HabilitarDistrito", objConexion.Conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", d.codigo);
                if (cmd.ExecuteNonQuery() > 0) res = true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { objConexion.CerrarConexion(); }
            return res;
        }

        public int MostrarCodigoDistrito()
        {
            int codigo = 0;
            try
            {
                cmd = new SqlCommand("SP_CodigoDistrito", objConexion.Conectar());
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