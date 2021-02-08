using Capa_Datos;
using LibreriasByJIM.Controles_JIM;
using System;
using System.Collections.Generic;
using System.Data;


namespace Capa_Logica
{
    public class Tb_Clientes
    {
        List<Cliente> lstClientes = null;

        /// <summary>
        /// Clase que nos devuelve un listado con los clientes de la tabla CLIENTES.
        /// </summary>
        public static DataTable listadoClientes()
        {
            return miBBDD.ConsultaSQL("SELECT * FROM TBCLIENTES");

        }

        /// <summary>
        /// Clase que nos indica si el cliente ya existe en la tabla CLIENTES.
        /// </summary>
        public static Boolean siExisteCliente(Cliente cliente)
        {
            DataTable dt = miBBDD.ConsultaSQL("SELECT * FROM TBCLIENTES WHERE CLI_CODIGO = " + cliente.Id);
            if (dt.Rows.Count > 0) return true;
            return false;
        }

        /// <summary>
        /// Clase que inserta un nuevo cliente en la tabla CLIENTES.
        /// </summary>
        public static Boolean addCliente(Cliente cliente)
        {
            try
            {
                string MISQL = String.Format("INSERT INTO TBCLIENTES ("
    + " CLI_NOMBRE, CLI_TELEFONO, CLI_DIRECCION, CLI_CIUDAD, CLI_OBSERV)"
    + " VALUES ('{0}','{1}','{2}','{3}','{4}')",
    cliente.Nombre, cliente.Telefono, cliente.Direccion, cliente.Ciudad, cliente.Observaciones);

                if (miBBDD.EjecutarOrdenSQL(MISQL)) return true;

                return false;
            }
            catch (Exception ex)
            {
                new MensajeBox("ERROR AL AÑADIR CLIENTE", ex);
                return false;
            }

        }

        /// <summary>
        /// Clase que elimina un cliente de la tabla CLIENTES.
        /// </summary>
        public static Boolean delCliente(Cliente cliente)
        {
            try
            {
                string MISQL = "DELETE FROM TBCLIENTES  WHERE CLI_CODIGO = " + cliente.Id;

                if (miBBDD.EjecutarOrdenSQL(MISQL)) return true;

                return false;
            }
            catch (Exception ex)
            {
                new MensajeBox("ERROR AL ELIMINAR CLIENTE", ex);
                return false;
            }

        }

        /// <summary>
        /// Clase que actualiza un cliente de la tabla CLIENTES.
        /// </summary>
        public static Boolean updateCliente(Cliente cliente)
        {
            try
            {
                string MISQL = String.Format("UPDATE TBCLIENTES  SET CLI_NOMBRE = '{0}', CLI_TELEFONO = '{1}',"
    + " CLI_DIRECCION = '{2}', CLI_CIUDAD = '{3}', CLI_OBSERV = '{4}' WHERE CLI_CODIGO = '{5}'",
    cliente.Nombre, cliente.Telefono, cliente.Direccion, cliente.Ciudad, cliente.Observaciones, cliente.Id);

                if (miBBDD.EjecutarOrdenSQL(MISQL)) return true;
                return false;
            }
            catch (Exception ex)
            {
                new MensajeBox("ERROR AL ACTUALIZAR CLIENTE", ex);
                return false;
            }

        }
    }
}
