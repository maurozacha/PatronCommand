using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Datos
    {
        private string cadenaConexion = @"Data Source=.;Initial Catalog=SistemaStreaming;Integrated Security=True";
        private SqlConnection conexion;

        public Datos()
        {
            conexion = new SqlConnection(cadenaConexion);
        }

        // Método para ejecutar comandos (Stored Procedures) que no devuelven resultados (Ej: Suscribir, Cancelar Suscripción)
        public bool EjecutarComando(string consulta, Hashtable parametros)
        {
            try
            {
                if (conexion.State == ConnectionState.Closed)
                    conexion.Open();

                SqlCommand comando = new SqlCommand(consulta, conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (parametros != null)
                {
                    foreach (DictionaryEntry param in parametros)
                    {
                        comando.Parameters.AddWithValue(param.Key.ToString(), param.Value);
                    }
                }

                comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        // Método para obtener datos de la base de datos (Ej: Obtener información de un usuario)
        public DataTable ObtenerDatos(string consulta, Hashtable parametros)
        {
            DataTable tabla = new DataTable();
            try
            {
                SqlCommand comando = new SqlCommand(consulta, conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (parametros != null)
                {
                    foreach (DictionaryEntry param in parametros)
                    {
                        comando.Parameters.AddWithValue(param.Key.ToString(), param.Value);
                    }
                }

                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                adaptador.Fill(tabla);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }

            return tabla;
        }

        // Método para ejecutar comandos que devuelven un valor escalar (Ej: Obtener una respuesta simple, como una validación)
        public object EjecutarScalar(string consulta, Hashtable parametros)
        {
            try
            {
                if (conexion.State == ConnectionState.Closed)
                    conexion.Open();

                SqlCommand comando = new SqlCommand(consulta, conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (parametros != null)
                {
                    foreach (DictionaryEntry param in parametros)
                    {
                        comando.Parameters.AddWithValue(param.Key.ToString(), param.Value);
                    }
                }

                return comando.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
