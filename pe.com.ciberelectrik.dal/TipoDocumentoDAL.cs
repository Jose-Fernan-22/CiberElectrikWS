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
    public class TipoDocumentoDAL
    {
        private ConexionDAL objConexion = new ConexionDAL();
        private SqlCommand cmd;
        private SqlDataReader dr;

        public List<TipoDocumentoBO> MostrarTipoDocumento()
        {
            List<TipoDocumentoBO> lista = new List<TipoDocumentoBO>();
            try
            {
                cmd = new SqlCommand("SP_MostrarTipoDocumento", objConexion.Conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TipoDocumentoBO obj = new TipoDocumentoBO();
                    obj.codigo = Convert.ToInt32(dr["codtipd"]); //[cite: 3]
                    obj.nombre = dr["nomtipd"].ToString(); //[cite: 3]
                    obj.estado = Convert.ToBoolean(dr["esttipd"]); //[cite: 3]
                    lista.Add(obj);
                }
                dr.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { objConexion.CerrarConexion(); }
            return lista;
        }

        public List<TipoDocumentoBO> MostrarTipoDocumentoTodo()
        {
            List<TipoDocumentoBO> lista = new List<TipoDocumentoBO>();
            try
            {
                cmd = new SqlCommand("SP_MostrarTipoDocumentoTodo", objConexion.Conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TipoDocumentoBO obj = new TipoDocumentoBO();
                    obj.codigo = Convert.ToInt32(dr["codtipd"]); //[cite: 3]
                    obj.nombre = dr["nomtipd"].ToString(); //[cite: 3]
                    obj.estado = Convert.ToBoolean(dr["esttipd"]); //[cite: 3]
                    lista.Add(obj);
                }
                dr.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { objConexion.CerrarConexion(); }
            return lista;
        }

        public bool RegistrarTipoDocumento(TipoDocumentoBO t)
        {
            bool res = false;
            try
            {
                cmd = new SqlCommand("SP_RegistrarTipoDocumento", objConexion.Conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", t.nombre);
                cmd.Parameters.AddWithValue("@estado", t.estado);
                if (cmd.ExecuteNonQuery() > 0) res = true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { objConexion.CerrarConexion(); }
            return res;
        }

        public TipoDocumentoBO BuscarTipoDocumentoXCodigo(TipoDocumentoBO t)
        {
            TipoDocumentoBO obj = null;
            try
            {
                cmd = new SqlCommand("SP_BuscarTipoDocumentoXCodigo", objConexion.Conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", t.codigo);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    obj = new TipoDocumentoBO();
                    obj.codigo = Convert.ToInt32(dr["codtipd"]); //[cite: 3]
                    obj.nombre = dr["nomtipd"].ToString(); //[cite: 3]
                    obj.estado = Convert.ToBoolean(dr["esttipd"]); //[cite: 3]
                }
                dr.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { objConexion.CerrarConexion(); }
            return obj;
        }

        public bool ActualizarTipoDocumento(TipoDocumentoBO t)
        {
            bool res = false;
            try
            {
                cmd = new SqlCommand("SP_ActualizarTipoDocumento", objConexion.Conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", t.codigo);
                cmd.Parameters.AddWithValue("@nombre", t.nombre);
                cmd.Parameters.AddWithValue("@estado", t.estado);
                if (cmd.ExecuteNonQuery() > 0) res = true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { objConexion.CerrarConexion(); }
            return res;
        }

        public bool EliminarTipoDocumento(TipoDocumentoBO t)
        {
            bool res = false;
            try
            {
                cmd = new SqlCommand("SP_EliminarTipoDocumento", objConexion.Conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", t.codigo);
                if (cmd.ExecuteNonQuery() > 0) res = true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { objConexion.CerrarConexion(); }
            return res;
        }

        public bool HabilitarTipoDocumento(TipoDocumentoBO t)
        {
            bool res = false;
            try
            {
                cmd = new SqlCommand("SP_HabilitarTipoDocumento", objConexion.Conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", t.codigo);
                if (cmd.ExecuteNonQuery() > 0) res = true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { objConexion.CerrarConexion(); }
            return res;
        }

        public int MostrarCodigoTipoDocumento()
        {
            int codigo = 0;
            try
            {
                cmd = new SqlCommand("SP_CodigoTipoDocumento", objConexion.Conectar());
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