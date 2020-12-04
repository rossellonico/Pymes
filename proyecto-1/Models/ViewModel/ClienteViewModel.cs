using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace proyecto_1.Models.ViewModel
{
    public class ClienteViewModel
    {
        [Required]
        [StringLength(maximumLength: 20, ErrorMessage = "Nombre debe tener como maximo {0} caracteres ")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Dirección debe tener como maximo {0} caracteres ")]
        [Display(Name = "Direccion")]
        public string direccion { get; set; }

        [Required]
        [Display(Name = "Telefono")]
        public int telefono { get; set; }

        [Required]
        [StringLength(maximumLength: 11, ErrorMessage = "CUIT debe tener como maximo {0} caracteres ")]
        [Display(Name = "CUIT")]
        public string CUIT { get; set; }

        [Required]
        [StringLength(maximumLength: 2, ErrorMessage = "IVA debe tener como maximo {0} caracteres ")]
        [Display(Name = "IVA")]
        public string IVA { get; set; }

    }


    public class EditarClienteViewModel
    {
        public int id { get; set; }

        [Required]
        [StringLength(maximumLength: 20, ErrorMessage = "Nombre debe tener como maximo {0} caracteres ")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Dirección debe tener como maximo {0} caracteres ")]
        [Display(Name = "Direccion")]
        public string direccion { get; set; }

        [Required]
        [Display(Name = "Telefono")]
        public int telefono { get; set; }

        [Required]
        [StringLength(maximumLength: 11, ErrorMessage = "CUIT debe tener como maximo {0} caracteres ")]
        [Display(Name = "CUIT")]
        public string CUIT { get; set; }

        [Required]
        [StringLength(maximumLength: 2, ErrorMessage = "IVA debe tener como maximo {0} caracteres ")]
        [Display(Name = "IVA")]
        public string IVA { get; set; }


    }
}