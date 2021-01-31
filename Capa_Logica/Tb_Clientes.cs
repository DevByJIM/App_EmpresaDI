using System;
using System.Collections.Generic;
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
        public static List<Cliente> listadoClientes()
        {         
            return null;
        }

        /// <summary>
        /// Clase que nos indica si el cliente ya existe en la tabla CLIENTES.
        /// </summary>
        public static Boolean siExisteCliente(Cliente cliente)
        {
            return false;
        }

        /// <summary>
        /// Clase que inserta un nuevo cliente en la tabla CLIENTES.
        /// </summary>
        static Boolean addCliente(Cliente cliente)
        {
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
