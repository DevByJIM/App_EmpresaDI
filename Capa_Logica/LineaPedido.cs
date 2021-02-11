using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica
{
    public class LineaPedido
    {
        private int id;
        private int codpedido;
        private int codProducto;
        private int cantidad;
        private double precio;
        private int numLin;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public int Codpedido
        {
            get
            {
                return codpedido;
            }

            set
            {
                codpedido = value;
            }
        }

        public int CodProducto
        {
            get
            {
                return codProducto;
            }

            set
            {
                codProducto = value;
            }
        }

        public int Cantidad
        {
            get
            {
                return cantidad;
            }

            set
            {
                cantidad = value;
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

        public int NumLin
        {
            get
            {
                return numLin;
            }

            set
            {
                numLin = value;
            }
        }
    }
}
