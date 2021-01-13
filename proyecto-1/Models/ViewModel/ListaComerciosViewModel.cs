using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto_1.Models.ViewModel
{
    public class ListaComerciosViewModel
    {
        public int id_comercio { get; set; }
        public string razon_social { get; set; }
        public string CUIT { get; set; }
        public int IVA { get; set; }
        public string ingresos_brutos { get; set; }
        public DateTime fecha_inicio { get; set; }
        public string fecha_inicios { get; set; }

    }
}