using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace proyecto_1.Models.ViewModel
{
    public class ProductoViewModel
    {
        

        [Required]
        [StringLength(maximumLength:100,ErrorMessage ="La descripcion debe tener como maximo {0} caracteres ")]
        [Display(Name = "Descripcion")]
        public string descripcion { get; set; }

        [Required]
        [Display(Name = "Stock")]
        public int stock { get; set; }

        [Required]
        [Display(Name = "Precio")]
        public decimal precio { get; set; }

        [Required]
        [Display(Name = "Numero de proveedor")]
        public int id_provedor { get; set; }
    }

    public class EditarProductoViewModel
    {
        public int id { get; set; }

        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "La descripcion debe tener como maximo {0} caracteres ")]
        [Display(Name = "Descripcion")]
        public string descripcion { get; set; }

        [Required]
        [Display(Name = "Stock")]
        public int stock { get; set; }

        [Required]
        [Display(Name = "Precio")]
        public decimal precio { get; set; }

        [Required]
        [Display(Name = "Numero de proveedor")]
        public int id_provedor { get; set; }
    }


}