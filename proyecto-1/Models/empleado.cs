//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace proyecto_1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class empleado
    {
        public int id_empleado { get; set; }
        public int id_comercio { get; set; }
        public int id_tipo { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int dni { get; set; }
        public string Contraseña { get; set; }
        public string estado { get; set; }
    
        public virtual comercio comercio { get; set; }
        public virtual tipo_empleado tipo_empleado { get; set; }
    }
}
