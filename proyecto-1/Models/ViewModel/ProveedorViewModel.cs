using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace proyecto_1.Models.ViewModel
{
    public class ProveedorViewModel
    {
        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Razon Social debe tener como maximo {0} caracteres ")]
        [Display(Name = "Razon Social")]
        public string razon_social { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Required]

        [Display(Name = "Telefono")]
        public int telefono { get; set; }


    }


    public class EditarProveedorViewModel
    {
        public int id { get; set; }
        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Razon Social debe tener como maximo {0} caracteres ")]
        [Display(Name = "Razon Social")]
        public string razon_social { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Required]
        [Display(Name = "Telefono")]
        public int telefono { get; set; }


    }
}