using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class miBBDD
    {
        static SqlConnection Conexion = new SqlConnection("Data Source=SERVERACP;DataBase=Produccion ACP;;Integrated Security=True");

        private static void abrir_Conexion() //METODO PARA ABRIR CONEXION
        {
            if (Conexion.State == ConnectionState.Closed)
                Conexion.Open();
        }

        private static void Cerrar_Conexion() //METODO PARA CERRAR CONEXION
        {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();
        }

        /// <summary>
        /// Método que ejecuta una Consulta SQL devolviendo un DataTable con un listado.
        /// </summary>
        /// <param name="Consulta SQL"></param>
        public static DataTable ConsultaSQL(String miSQL)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da;

            try
            {
                abrir_Conexion();
                da = new SqlDataAdapter(miSQL, Conexion);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR BUSCANDO DATOS POR SQL. \n" + ex.Message);
            }
            finally
            {
                Cerrar_Conexion();
            }
        }

        /// <summary>
        /// Método que ejecuta una Consulta SQL y devuelve True si se ha realizado sin errores.
        /// </summary>
        /// <param name="Consulta SQL"></param>
        public static Boolean EjecutarOrdenSQL(String miSQL)
        {
            SqlCommand cmd;

            try
            {
                abrir_Conexion();
                cmd = new SqlCommand(miSQL, Conexion);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR EJECUTANDO UN SCRIPT SQL. \n" + ex.Message);
            }
            finally
            {
                Cerrar_Conexion();
            }

        }

    }
}
