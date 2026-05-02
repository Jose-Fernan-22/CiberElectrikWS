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
        //creamos una funcion para buscar
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
    }
}
