using Capa_Datos;
using LibreriasByJIM.Controles_JIM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica
{
    public class Tb_Pedidos
    {


        /// <summary>
        /// Clase que nos devuelve un listado con los pedidos de la tabla PEDIDOS.
        /// </summary>
        public static DataTable listadoPedidos()
        {
            return miBBDD.ConsultaSQL("SELECT * FROM TBPEDIDOS");

        }

        /// <summary>
        /// Clase que nos indica si el pedido ya existe en la tabla PEDIDOS.
        /// </summary>
        public static Boolean siExistePedido(Pedido pedido)
        {
            DataTable dt = miBBDD.ConsultaSQL("SELECT * FROM TBPEDIDOS WHERE PED_CODIGO = " + pedido.Codigo);
            if (dt.Rows.Count > 0) return true;
            return false;
        }

        /// <summary>
        /// Clase que inserta un nuevo pedido en la tabla PEDIDOS.
        /// </summary>
        public static Boolean addPedido(Pedido pedido)
        {
            try
            {
                string MISQL = String.Format("INSERT INTO TBPEDIDOS ("
                     + " PED_NUMPEDIDO, PED_CODCLIENTE, PED_FECHA, PED_ESTADO, PED_OBSERV)"
                     + " VALUES ('{0}','{1}','{2}','{3}','{4}')",
                         pedido.NumPedido, pedido.CodCliente, pedido.Fecha.ToString("yyyy/MM/dd"), pedido.Estado, pedido.Observaciones);

                if (miBBDD.EjecutarOrdenSQL(MISQL)) return true;

                return false;
            }
            catch (Exception ex)
            {
                new MensajeBox("ERROR AL AÑADIR PEDIDO", ex);
                return false;
            }

        }

        /// <summary>
        /// Clase que elimina un pedido de la tabla PEDIDOS.
        /// </summary>
        public static Boolean delPedido(Pedido pedido)
        {
            try
            {
                string MISQL = "DELETE FROM TBPEDIDOS  WHERE PED_CODIGO = " + pedido.Codigo;

                if (miBBDD.EjecutarOrdenSQL(MISQL)) return true;

                return false;
            }
            catch (Exception ex)
            {
                new MensajeBox("ERROR AL ELIMINAR PEDIDO", ex);
                return false;
            }

        }

        /// <summary>
        /// Clase que actualiza un pedido de la tabla PEDIDOS.
        /// </summary>
        public static Boolean updatePedido(Pedido pedido)
        {
            try
            {
                string MISQL = String.Format("UPDATE TBPEDIDOS  SET "
                     + " PED_NUMPEDIDO, PED_CODCLIENTE, PED_FECHA, PED_ESTADO, PED_OBSERV)"
                     + " VALUES ('{0}','{1}','{2}','{3}','{4}')",
                         pedido.NumPedido, pedido.CodCliente, pedido.Fecha, pedido.Estado, pedido.Observaciones);
                if (miBBDD.EjecutarOrdenSQL(MISQL)) return true;
                return false;
            }
            catch (Exception ex)
            {
                new MensajeBox("ERROR AL ACTUALIZAR PEDIDO", ex);
                return false;
            }

        }
    }
}
