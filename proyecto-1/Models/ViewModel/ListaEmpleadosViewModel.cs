using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto_1.Models.ViewModel
{
    public class ListaEmpleadosViewModel
    {
        public int id_empleado { get; set; }
       
        public string nombre { get; set; }

        public string apellido{ get; set; }

        public string cargo { get; set; }

    }
}