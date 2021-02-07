using MySqlConnector;
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
        //static SqlConnection Conexion = new SqlConnection("Data Source=SERVERACP;DataBase=Produccion ACP;;Integrated Security=True");
        static MySqlConnection Conexion =
            new MySqlConnection("Data source =127.0.0.1;port=3306;username=root;database=EmpresaDI;");


        /// <summary>
        /// Método que ejecuta una Consulta SQL que crea la base de datos si no existe.
        /// </summary>
        public static Boolean CrearBaseDatos()
        {
            MySqlConnection Conex = new MySqlConnection("Data source =127.0.0.1;port=3306;username=root;");
            MySqlCommand cmd;
            try
            {
                if (Conex.State == ConnectionState.Closed)
                    Conex.Open();
                cmd = new MySqlCommand(CREATEDB, Conex);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd = new MySqlCommand(USEDDBB, Conex);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd = new MySqlCommand(CREATEtbCLIENTES, Conex);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd = new MySqlCommand(CREATEtbPEDIDOS, Conex);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd = new MySqlCommand(CREATEtbPRODUCTO, Conex);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd = new MySqlCommand(CREATEtbLINPEDIDOS, Conex);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery();

                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("ERROR AL CREAR LA BASE DE DATOS POR SQL. \n" + ex.Message);
                return false;
            }
            finally
            {
                if (Conex.State == ConnectionState.Open)
                    Conex.Close();
            }
        }

  


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
            MySqlDataAdapter da;

            try
            {
                abrir_Conexion();
                da = new MySqlDataAdapter(miSQL, Conexion);
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
            MySqlCommand cmd;

            try
            {
                abrir_Conexion();
                cmd = new MySqlCommand(miSQL, Conexion);
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




        #region SENTENCIAS SQL PARA CREAR BBDD

        private static String CREATEDB = "CREATE DATABASE IF NOT EXISTS EMPRESADI";
        private static String USEDDBB = "USE EMPRESADI";
        private static String CREATEtbCLIENTES = "CREATE TABLE IF NOT EXISTS TBCLIENTES ("
            + " CLI_CODIGO INT(11) PRIMARY KEY AUTO_INCREMENT,"
            + " CLI_NOMBRE VARCHAR(128)UNIQUE NOT NULL,"
            + " CLI_TELEFONO VARCHAR(16),"
            + " CLI_DIRECCION VARCHAR(256),"
            + " CLI_CIUDAD VARCHAR(64),"
            + " CLI_OBSERV VARCHAR(512));";

        private static String CREATEtbPEDIDOS = "CREATE TABLE IF NOT EXISTS TBPEDIDOS ("
            + " PED_CODIGO INT(11) PRIMARY KEY AUTO_INCREMENT,"
            + "	PED_NUMPEDIDO INT(16) NOT NULL,"
            + " PED_CODCLIENTE INT(11),"
            + "	PED_FECHA DATE NOT NULL,"
            + " PED_ESTADO INT(4),"
            + "	PED_OBSERV VARCHAR(512),"
            + " CONSTRAINT PEDIDO_FK_CLIENTE FOREIGN KEY(PED_CODCLIENTE)"
            + " REFERENCES TBCLIENTES(CLI_CODIGO)"
            + " ON UPDATE CASCADE"
            + "	ON DELETE SET NULL);";

        private static String CREATEtbLINPEDIDOS = "CREATE TABLE IF NOT EXISTS TBLINEAS_PEDIDO("
            + " LIN_CODIGO INT(11) PRIMARY KEY  AUTO_INCREMENT, "
            + "	LIN_CODPEDIDO INT(11) NOT NULL,"
            + " LIN_CODPRODUCTO INT(11) NOT NULL,"
            + " LIN_CANTIDAD INT(16) NOT NULL,"
            + " LIN_PRECIO FLOAT NOT NULL,"
            + "	LIN_NUMLIN INT(4) NOT NULL,"
            + " CONSTRAINT LINEAS_FK_PEDIDO FOREIGN KEY(LIN_CODPEDIDO)"
            + " REFERENCES TBPEDIDOS(PED_CODIGO)"
            + "	ON UPDATE CASCADE"
            + "	ON DELETE CASCADE,"
            + " CONSTRAINT LINEAS_FK_PRODUCTO FOREIGN KEY(LIN_CODPRODUCTO)"
            + " REFERENCES TBPRODUCTOS(PRD_CODIGO)"
            + " ON UPDATE CASCADE"
            + " ON DELETE NO ACTION);";

        private static String CREATEtbPRODUCTO = "CREATE TABLE IF NOT EXISTS TBPRODUCTOS("
            + " PRD_CODIGO INT(11) PRIMARY KEY  AUTO_INCREMENT,"
            + "	PRD_NSERIE VARCHAR(16) NOT NULL,"
            + " PRD_DENOMINACION VARCHAR(256) NOT NULL,"
            + " PRD_STOCK INT(10) NOT NULL,"
            + " PRD_PRECIO FLOAT NOT NULL,"
            + "	PRD_OBSERV VARCHAR(512));";





        #endregion
    }
}
