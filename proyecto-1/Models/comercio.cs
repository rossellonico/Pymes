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
    
    public partial class comercio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public comercio()
        {
            this.cliente_comercio = new HashSet<cliente_comercio>();
            this.empleado = new HashSet<empleado>();
            this.productos = new HashSet<productos>();
            this.ventas = new HashSet<ventas>();
            this.proveedores_comercios = new HashSet<proveedores_comercios>();
        }
    
        public int id_comercio { get; set; }
        public string razon_social { get; set; }
        public string CUIT { get; set; }
        public string IVA { get; set; }
        public string Ingresos_brutos { get; set; }
        public Nullable<System.DateTime> fecha_inicio { get; set; }
        public string estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cliente_comercio> cliente_comercio { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<empleado> empleado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<productos> productos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ventas> ventas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<proveedores_comercios> proveedores_comercios { get; set; }
    }
}
