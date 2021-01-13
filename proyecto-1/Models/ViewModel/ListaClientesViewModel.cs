using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto_1.Models.ViewModel
{
    public class ListaClientesViewModel
    {
        public int id_cliente { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public char estado { get; set; }
        public string CUIT { get; set; }
        public int id_IVA { get; set; }
        public string descripcion { get; set; }
    }
}