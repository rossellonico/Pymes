﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class practicaprofesionalEntities1 : DbContext
    {
        public practicaprofesionalEntities1()
            : base("name=practicaprofesionalEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<cliente_comercio> cliente_comercio { get; set; }
        public virtual DbSet<clientes> clientes { get; set; }
        public virtual DbSet<comercio> comercio { get; set; }
        public virtual DbSet<empleado> empleado { get; set; }
        public virtual DbSet<factura_productos> factura_productos { get; set; }
        public virtual DbSet<facturas> facturas { get; set; }
        public virtual DbSet<productos> productos { get; set; }
        public virtual DbSet<proveedores> proveedores { get; set; }
        public virtual DbSet<proveedores_comercios> proveedores_comercios { get; set; }
        public virtual DbSet<proveedores_productos> proveedores_productos { get; set; }
        public virtual DbSet<situacion_iva> situacion_iva { get; set; }
        public virtual DbSet<tipo_empleado> tipo_empleado { get; set; }
        public virtual DbSet<ventas> ventas { get; set; }
    }
}
