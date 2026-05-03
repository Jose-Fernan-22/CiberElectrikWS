using pe.com.ciberelectrik.bo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.ciberelectrik.dal
    //falta completar
{
    public class MarcaDAL
    {
        private ConexionDAL objconexion = new ConexionDAL();
        private SqlCommand cmd;
        private SqlDataReader dr;
        int res = 0;

        //funcion para mostrar la categoria
        public List<MarcaBO> MostrarMarca()
        {
            List<MarcaBO> marcas = new List<MarcaBO>();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarMarca";
                cmd.Connection = objconexion.Conectar();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    MarcaBO obj = new MarcaBO();
                    obj.codigo = Convert.ToInt32(dr["codmar"].ToString());
                    obj.nombre = dr["nommar"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estmar"].ToString());
                    marcas.Add(obj);
                }
                return marcas;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                objconexion.CerrarConexion();
            }
        }

        //funcion para mostrar la categoria
        public List<MarcaBO> MostrarMarcaTodo()
        {
            List<MarcaBO> marcas = new List<MarcaBO>();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarMarcaTodo";
                cmd.Connection = objconexion.Conectar();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    MarcaBO obj = new MarcaBO();
                    obj.codigo = Convert.ToInt32(dr["codmar"].ToString());
                    obj.nombre = dr["nommar"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estmar"].ToString());
                    marcas.Add(obj);
                }
                return marcas;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                objconexion.CerrarConexion();
            }
        }
        // Registrar
        public bool RegistrarMarca(MarcaBO m)
        {
            bool res = false;
            try
            {
                cmd = new SqlCommand("SP_RegistrarMarca", objconexion.Conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", m.nombre); 
                cmd.Parameters.AddWithValue("@estado", m.estado); 
                int filas = cmd.ExecuteNonQuery();
                if (filas > 0) res = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                objconexion.CerrarConexion();
            }
            return res;
        }

        //creamos una funcion para buscar por codigo
        public MarcaBO BuscarMarcaXCodigo(MarcaBO c)
        {
            //creamos una objeto de tipo CategoriaBO
            MarcaBO marcas = new MarcaBO();
            try
            {
                //instanciamos el SQLCommand
                cmd = new SqlCommand();
                //especificamos el tipo de SQLCommand
                cmd.CommandType = CommandType.StoredProcedure;
                //especificamos el nombre del procedimiento
                cmd.CommandText = "SP_BuscarMarcaXCodigo";
                //instanciamos la conexion
                cmd.Connection = objconexion.Conectar();
                cmd.Parameters.AddWithValue("@codigo", c.codigo);
                //ejecutamos la consulta y guardamos el resultado en el SQLDataReader
                dr = cmd.ExecuteReader();
                //cargamos los datos del SQLDataReader en la lista
                while (dr.Read())
                {
                    //leemos los datos y los asignamos al objeto
                    marcas.codigo = Convert.ToInt32(dr["codcat"].ToString());
                    marcas.nombre = dr["nomcat"].ToString();
                    marcas.estado = Convert.ToBoolean(dr["estcat"].ToString());
                }
                //devolvemos la lista
                return marcas;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                objconexion.CerrarConexion();
            }
        }

        // Actualizar
        public bool ActualizarMarca(MarcaBO m)
        {
            bool res = false;
            try
            {
                cmd = new SqlCommand("SP_ActualizarMarca", objconexion.Conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", m.codigo); 
                cmd.Parameters.AddWithValue("@nombre", m.nombre); 
                cmd.Parameters.AddWithValue("@estado", m.estado); 
                int filas = cmd.ExecuteNonQuery();
                if (filas > 0) res = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                objconexion.CerrarConexion();
            }
            return res;
        }

        // Eliminar (Lógico)
        public bool EliminarMarca(MarcaBO m)
        {
            bool res = false;
            try
            {
                cmd = new SqlCommand("SP_EliminarMarca", objconexion.Conectar()); //[cite: 4]
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", m.codigo); //[cite: 4]
                int filas = cmd.ExecuteNonQuery();
                if (filas > 0) res = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                objconexion.CerrarConexion();
            }
            return res;
        }

        // Habilitar (Lógico)
        public bool HabilitarMarca(MarcaBO m)
        {
            bool res = false;
            try
            {
                cmd = new SqlCommand("SP_HabilitarMarca", objconexion.Conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", m.codigo); 
                int filas = cmd.ExecuteNonQuery();
                if (filas > 0) res = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                objconexion.CerrarConexion();
            }
            return res;
        }

        // Obtener el siguiente código (Identity)
        public int MostrarCodigoMarca()
        {
            int codigo = 0;
            try
            {
                cmd = new SqlCommand("SP_CodigoMarca", objconexion.Conectar()); 
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    // Capturamos el alias que le pusimos en el procedimiento almacenado
                    codigo = Convert.ToInt32(dr["SiguienteCodigo"]);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                objconexion.CerrarConexion();
            }
            return codigo;
        }

    }
}
