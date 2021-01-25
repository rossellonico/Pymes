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
        [Display(Name = "Situacion frente al IVA")]
        public int id_IVA { get; set; }
        public string descripcion { get; set; }


        [Required]
        [StringLength(maximumLength: 16, ErrorMessage = "Ingresos Brutos debe tener como maximo {0} caracteres ")]
        [Display(Name = "Ingresos Brutos")]
        public string Ingresos_brutos { get; set; }

        [Required]
        [Display(Name = "Fecha Inicio - dd/mm/aaaa")]
        [ValidarFecha]
        public string fecha_inicios { get; set; }

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
        [Display(Name = "Situación frente al IVA")]
        public int id_IVA { get; set; }
        public string descripcion { get; set; }

        [Required]
        [StringLength(maximumLength: 16, ErrorMessage = "Ingresos Brutos debe tener como maximo {0} caracteres ")]
        [Display(Name = "Ingresos Brutos")]
        public string Ingresos_brutos { get; set; }

        [Required]
        [Display(Name = "Fecha Inicio - dd/mm/aaaa")]
        [ValidarFecha]
        public string fecha_inicios { get; set; }
        public DateTime fecha_inicio { get; set; }

        [Required]
        [StringLength(maximumLength: 11, ErrorMessage = "El CUIT debe tener como maximo {0} caracteres ")]
        [Display(Name = "CUIT")]
        public string CUIT { get; set; }
    }

        public class ValidarFecha : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                string fecha = (string)value;
                DateTime fechavalidada;
                if (fecha.Length != 10)
                    return new ValidationResult("El formato debe ser dd/mm/aaaa");
            
                if (! Int32.TryParse(fecha.Substring(0, 2), out int dia) )
                    return new ValidationResult("El formato debe ser dd/mm/aaaa");
                if (!Int32.TryParse(fecha.Substring(3, 2), out int mes))
                    return new ValidationResult("El formato debe ser dd/mm/aaaa");
                if (!Int32.TryParse(fecha.Substring(6, 4), out int anio))
                    return new ValidationResult("El formato debe ser dd/mm/aaaa");
                if (fecha.Substring(2,1) != "/" && fecha.Substring(5, 1) != "/")
                    return new ValidationResult("El formato debe ser dd/mm/aaaa");
                if (!DateTime.TryParse(fecha, out fechavalidada))
                {
                    return new ValidationResult("Fecha invalida");
                }

                DateTime fechahoy = DateTime.Now;
                if (fechahoy < fechavalidada)
                {
                    return new ValidationResult("La fecha no puede ser mayor al dia de hoy");
                }


                return ValidationResult.Success;

            }
        }
}