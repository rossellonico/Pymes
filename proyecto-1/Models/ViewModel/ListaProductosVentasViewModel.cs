using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto_1.Models.ViewModel
{
    public class ListaProductosVentasViewModel
    {
     

            public int id { get; set; }
            public string descripcion { get; set; }
            public int stock { get; set; }
            public decimal precio { get; set; }
            public int cantidad{ get; set; }



    }
}