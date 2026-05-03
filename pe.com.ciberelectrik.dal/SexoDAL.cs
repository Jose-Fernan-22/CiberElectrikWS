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
    public class SexoDAL
    {
        private ConexionDAL objConexion = new ConexionDAL();
        private SqlCommand cmd;
        private SqlDataReader dr;

        public List<SexoBO> MostrarSexo()
        {
            List<SexoBO> lista = new List<SexoBO>();
            try
            {
                cmd = new SqlCommand("SP_MostrarSexo", objConexion.Conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    SexoBO obj = new SexoBO();
                    obj.codigo = Convert.ToInt32(dr["codsex"]); //[cite: 3]
                    obj.nombre = dr["nomsex"].ToString(); //[cite: 3]
                    obj.estado = Convert.ToBoolean(dr["estsex"]); //[cite: 3]
                    lista.Add(obj);
                }
                dr.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { objConexion.CerrarConexion(); }
            return lista;
        }

        public List<SexoBO> MostrarSexoTodo()
        {
            List<SexoBO> lista = new List<SexoBO>();
            try
            {
                cmd = new SqlCommand("SP_MostrarSexoTodo", objConexion.Conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    SexoBO obj = new SexoBO();
                    obj.codigo = Convert.ToInt32(dr["codsex"]); //[cite: 3]
                    obj.nombre = dr["nomsex"].ToString(); //[cite: 3]
                    obj.estado = Convert.ToBoolean(dr["estsex"]); //[cite: 3]
                    lista.Add(obj);
                }
                dr.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { objConexion.CerrarConexion(); }
            return lista;
        }

        public bool RegistrarSexo(SexoBO s)
        {
            bool res = false;
            try
            {
                cmd = new SqlCommand("SP_RegistrarSexo", objConexion.Conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", s.nombre);
                cmd.Parameters.AddWithValue("@estado", s.estado);
                if (cmd.ExecuteNonQuery() > 0) res = true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { objConexion.CerrarConexion(); }
            return res;
        }

        public SexoBO BuscarSexoXCodigo(SexoBO s)
        {
            SexoBO obj = null;
            try
            {
                cmd = new SqlCommand("SP_BuscarSexoXCodigo", objConexion.Conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", s.codigo);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    obj = new SexoBO();
                    obj.codigo = Convert.ToInt32(dr["codsex"]); //[cite: 3]
                    obj.nombre = dr["nomsex"].ToString(); //[cite: 3]
                    obj.estado = Convert.ToBoolean(dr["estsex"]); //[cite: 3]
                }
                dr.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { objConexion.CerrarConexion(); }
            return obj;
        }

        public bool ActualizarSexo(SexoBO s)
        {
            bool res = false;
            try
            {
                cmd = new SqlCommand("SP_ActualizarSexo", objConexion.Conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", s.codigo);
                cmd.Parameters.AddWithValue("@nombre", s.nombre);
                cmd.Parameters.AddWithValue("@estado", s.estado);
                if (cmd.ExecuteNonQuery() > 0) res = true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { objConexion.CerrarConexion(); }
            return res;
        }

        public bool EliminarSexo(SexoBO s)
        {
            bool res = false;
            try
            {
                cmd = new SqlCommand("SP_EliminarSexo", objConexion.Conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", s.codigo);
                if (cmd.ExecuteNonQuery() > 0) res = true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { objConexion.CerrarConexion(); }
            return res;
        }

        public bool HabilitarSexo(SexoBO s)
        {
            bool res = false;
            try
            {
                cmd = new SqlCommand("SP_HabilitarSexo", objConexion.Conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", s.codigo);
                if (cmd.ExecuteNonQuery() > 0) res = true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { objConexion.CerrarConexion(); }
            return res;
        }

        public int MostrarCodigoSexo()
        {
            int codigo = 0;
            try
            {
                cmd = new SqlCommand("SP_CodigoSexo", objConexion.Conectar());
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