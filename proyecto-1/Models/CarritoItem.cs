using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto_1.Models
{
    public class CarritoItem
    {
        private productos producto;
        private int cantidad;

        public productos Producto { get => producto; set => producto = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }

        public CarritoItem()
        {

        }
        public CarritoItem(productos prod, int cant)
        {
            this.producto = prod;
            this.Cantidad = cant;
        }
    }
}