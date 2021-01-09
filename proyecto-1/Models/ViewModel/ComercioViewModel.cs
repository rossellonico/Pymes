using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace proyecto_1.Models.ViewModel
{
    public class ComercioViewModel
    {
        [Required]
        [StringLength(maximumLength:50,ErrorMessage ="La razon social debe tener como maximo {0} caracteres ")]
        [Display(Name = "Razon Social")]
        public string razon_social { get; set; }

        [Required]
        [StringLength(maximumLength: 2, ErrorMessage = "El IVA debe tener como maximo {0} caracteres ")]
        [Display(Name = "IVA")]
        public string IVA { get; set; }

        [Required]
        [StringLength(maximumLength: 16, ErrorMessage = "Ingresos Brutos debe tener como maximo {0} caracteres ")]
        [Display(Name = "Ingresos Brutos")]
        public string Ingresos_brutos { get; set; }

        [Required]
        [Display(Name = "Fecha Inicio")]
        public DateTime fecha_inicio { get; set; }

        [Required]
        [StringLength(maximumLength: 11, ErrorMessage = "El CUIT debe tener como maximo {0} caracteres ")]
        [Display(Name = "CUIT")]
        public string CUIT { get; set; }
    }

    public class EditarComercioViewModel
    {
        public int id { get; set; }

        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "La razon social debe tener como maximo {0} caracteres ")]
        [Display(Name = "Razon Social")]
        public string razon_social { get; set; }

        [Required]
        [StringLength(maximumLength: 2, ErrorMessage = "El IVA debe tener como maximo {0} caracteres ")]
        [Display(Name = "IVA")]
        public string IVA { get; set; }

        [Required]
        [StringLength(maximumLength: 16, ErrorMessage = "Ingresos Brutos debe tener como maximo {0} caracteres ")]
        [Display(Name = "Ingresos Brutos")]
        public string Ingresos_brutos { get; set; }

        [Required]
        [Display(Name = "Fecha Inicio")]
        public DateTime fecha_inicio { get; set; }

        [Required]
        [StringLength(maximumLength: 11, ErrorMessage = "El CUIT debe tener como maximo {0} caracteres ")]
        [Display(Name = "CUIT")]
        public string CUIT { get; set; }
    }


}