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
    public class Tb_Lineas
    {
        /// <summary>
        /// Clase que nos devuelve un listado con las lineas de la tabla TBLINEAS_PEDIDO.
        /// </summary>
        public static DataTable listadoLineas(Int32 CodPedido)
        {
            return miBBDD.ConsultaSQL("SELECT * FROM TBLINEAS_PEDIDO WHERE " + CodPedido);

        }

        /// <summary>
        /// Clase que nos indica si la linea ya existe en la tabla TBLINEAS_PEDIDO.
        /// </summary>
        public static Boolean siExisteCliente(LineaPedido linea)
        {
            DataTable dt = miBBDD.ConsultaSQL("SELECT * FROM TBLINEAS_PEDIDO WHERE LIN_CODIGO = " + linea.Id);
            if (dt.Rows.Count > 0) return true;
            return false;
        }


        /// <summary>
        /// Clase que inserta un nuevo cliente en la tabla CLIENTES.
        /// </summary>
        public static Boolean addLineaPedido(LineaPedido linea)
        {
            try
            {
                string MISQL = String.Format("INSERT INTO TBLINEAS_PEDIDO ("
    + " LIN_CODPEDIDO, LIN_CODPRODUCTO, LIN_CANTIDAD, LIN_PRECIO, LIN_NUMLIN)"
    + " VALUES ('{0}','{1}','{2}','{3}','{4}')",
    linea.Codpedido, linea.CodProducto, linea.Cantidad, linea.Precio, linea.NumLin);

                if (miBBDD.EjecutarOrdenSQL(MISQL)) return true;

                return false;
            }
            catch (Exception ex)
            {
                new MensajeBox("ERROR AL AÑADIR LINEA", ex);
                return false;
            }

        }

        /// <summary>
        /// Clase que elimina un cliente de la tabla CLIENTES.
        /// </summary>
        public static Boolean delCliente(LineaPedido linea)
        {
            try
            {
                string MISQL = "DELETE FROM TBLINEAS_PEDIDO  WHERE LIN_CODIGO = " + linea.Id;

                if (miBBDD.EjecutarOrdenSQL(MISQL)) return true;

                return false;
            }
            catch (Exception ex)
            {
                new MensajeBox("ERROR AL ELIMINAR LINEA", ex);
                return false;
            }

        }

        /// <summary>
        /// Clase que actualiza un cliente de la tabla CLIENTES.
        /// </summary>
        public static Boolean updateCliente(LineaPedido linea)
        {
            try
            {
                string MISQL = String.Format("UPDATE TBLINEAS_PEDIDO  SET LIN_CODPEDIDO = '{0}', LIN_CODPRODUCTO = '{1}',"
                     + " LIN_CANTIDAD = '{2}', LIN_PRECIO = '{3}', LIN_NULIN = '{4}' WHERE LIN_CODIGO = '{5}'",
                    linea.Codpedido, linea.CodProducto, linea.Cantidad, linea.Precio, linea.NumLin, linea.Id);

                if (miBBDD.EjecutarOrdenSQL(MISQL)) return true;
                return false;
            }
            catch (Exception ex)
            {
                new MensajeBox("ERROR AL ACTUALIZAR LINEAS", ex);
                return false;
            }

        }
    }

}

