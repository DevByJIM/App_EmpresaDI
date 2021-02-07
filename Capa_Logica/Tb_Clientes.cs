using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        static Boolean addCliente(Cliente cliente)
        {
            var cmd = new SqlCommand():
            return false;
        }

        /// <summary>
        /// Clase que elimina un cliente de la tabla CLIENTES.
        /// </summary>
        static Boolean delCliente(Cliente cliente)
        {
            return false;
        }

        /// <summary>
        /// Clase que actualiza un cliente de la tabla CLIENTES.
        /// </summary>
        static Boolean updateCliente(Cliente cliente)
        {
            return false;
        }
    }
}
