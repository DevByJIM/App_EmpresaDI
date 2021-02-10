using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica
{
    class LineaPedido
    {
        private int id;
        private int codpedido;
        private int codProducto;
        private int cantidad;
        private double precio;
        private int numLin;

        public int Id { get => id; set => id = value; }
        public int Codpedido { get => codpedido; set => codpedido = value; }
        public int CodProducto { get => codProducto; set => codProducto = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public double Precio { get => precio; set => precio = value; }
        public int NumLin { get => numLin; set => numLin = value; }
    }
}
