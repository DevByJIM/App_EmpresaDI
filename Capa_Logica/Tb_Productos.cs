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
    public class Tb_Productos
    {
        List<Producto> lstProductos = null;

        /// <summary>
        /// Clase que nos devuelve un listado con los prodcutos de la tabla PRODUCTOS.
        /// </summary>
        public static DataTable listadoProductos()
        {
            return miBBDD.ConsultaSQL("SELECT * FROM TBPRODUCTOS");
        }

        /// <summary>
        /// Clase que nos indica si el producto ya existe en la tabla PRODUCTOS.
        /// </summary>
        public static Boolean siExisteProducto(Producto producto)
        {
                DataTable dt = miBBDD.ConsultaSQL("SELECT * FROM TBPRODUCTOS WHERE PRD_CODIGO = " + producto.Codigo);
                if (dt.Rows.Count > 0) return true;
                return false;
        }

        /// <summary>
        /// Clase que inserta un nuevo producto en la tabla PRODUCTOS.
        /// </summary>
        public static Boolean addProducto(Producto producto)
        {
            try
            {
                string MISQL = String.Format("INSERT INTO TBPRODUCTOS ("
        + " PRD_NSERIE, PRD_DENOMINACION, PRD_STOCK, PRD_PRECIO, PRD_OBSERV)"
        + " VALUES ('{0}','{1}','{2}','{3}','{4}')",
         producto.NSerie, producto.Descripcion, producto.Stock, producto.Precio, producto.Observaciones);

                if (miBBDD.EjecutarOrdenSQL(MISQL)) return true;

                return false;
            }
            catch (Exception ex)
            {
                new MensajeBox("ERROR AL AÑADIR PRODUCTO", ex);
                return false;
            }

        }

        /// <summary>
        /// Clase que elimina un producto de la tabla PRODUCTOS.
        /// </summary>
        public static Boolean delProducto(Producto producto)
        {
            try
            {
            string MISQL = "DELETE FROM TBPRODUCTOS  WHERE PRD_CODIGO = " + producto.Codigo;

            if (miBBDD.EjecutarOrdenSQL(MISQL)) return true;

            return false;
            }
            catch (Exception ex)
            {
                new MensajeBox("ERROR AL ELIMINAR PRODUCTO", ex);
                return false;
            }

        }

        /// <summary>
        /// Clase que actualiza un producto de la tabla PRODUCTOS.
        /// </summary>
        public static Boolean updateProducto(Producto producto)
        {
            try
            {
                string MISQL = String.Format("UPDATE TBPRODUCTOS  SET PRD_NSERIE = '{0}', PRD_DENOMINACION = '{1}',"
    + " PRD_STOCK = '{2}', PRD_PRECIO = '{3}', PRD_OBSERV = '{4}' WHERE PRD_CODIGO = '{5}'",
    producto.NSerie, producto.Descripcion, producto.Stock, producto.Precio, producto.Observaciones, producto.Codigo);

                if (miBBDD.EjecutarOrdenSQL(MISQL)) return true;
                return false;
            }
            catch (Exception ex)
            {
                new MensajeBox("ERROR AL ACTUALIZAR PRODUCTO", ex);
                return false;
            }

        }
    }
}
