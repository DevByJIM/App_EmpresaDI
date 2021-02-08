using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica
{
    public class Producto
    {
        private String codigo;
        private String nSerie;
        private String descripcion;
        private Int32 stock;
        private Double precio;
        private String observaciones;

        public Producto() { }
        public Producto(string codigo, string nserie, string descripcion, int stock, double precio, string observaciones)
        {
            this.codigo = codigo;
            this.descripcion = descripcion;
            this.stock = stock;
            this.precio = precio;
            this.Observaciones = observaciones;
        }

        #region PROPIEDADES DE LA CLASE
        public string Codigo
        {
            get
            {
                return codigo;
            }

            set
            {
                codigo = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }

        public int Stock
        {
            get
            {
                return stock;
            }

            set
            {
                stock = value;
            }
        }

        public double Precio
        {
            get
            {
                return precio;
            }

            set
            {
                precio = value;
            }
        }

        public string Observaciones
        {
            get
            {
                return observaciones;
            }

            set
            {
                observaciones = value;
            }
        }

        public string NSerie
        {
            get
            {
                return nSerie;
            }

            set
            {
                nSerie = value;
            }
        }
        #endregion
    }
}
