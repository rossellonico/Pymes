using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace proyecto_1.Models.ViewModel
{
    public class ClienteViewModel
    {
        [Required(ErrorMessage = "El nombre es un campo obligatorio")]
        [StringLength(maximumLength: 20, ErrorMessage = "El {0} debe tener como maximo {1} caracteres y como minimo {2} ", MinimumLength = 3)]
        [Display(Name = "Cliente")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "La dirección es un campo obligatorio")]
        [StringLength(maximumLength: 50, ErrorMessage = "La dirección debe tener como maximo 50 caracteres ")]
        [Display(Name = "Dirección")]
        public string direccion { get; set; }

        [Required]
        [Display(Name = "Telefono")]
        [ValidarTelefono]
        public string telefono { get; set; }

        [Required]
        [MinLengthAttribute(11, ErrorMessage = "El CUIL debe tener 11 numeros. No poner guiones")] 
        [StringLength(maximumLength : 11,  ErrorMessage = "El CUIL debe tener 11 numeros. No poner guiones")]
        [Display(Name = "CUIT")]
        public string CUIT { get; set; }

        [Required]
        [Display(Name = "Situación frente al IVA")]
        public int id_IVA { get; set; }
        public string descripcion { get; set; }

    }
    public class ValidarTelefono : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            long number;
            string telefono = (string)value;
            if (telefono.Length > 13)
                return new ValidationResult("No se puede ingresar más de 13 caracteres");
            else
            {
                
                if (Int64.TryParse(telefono, out number) && number > 0)
                {
                    
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Debe ingresar solo números");
                }
            }
        }
    }

    public class EditarClienteViewModel
    {
        public int id { get; set; }

        [Required]
        [StringLength(maximumLength: 20, ErrorMessage = "Nombre debe tener como maximo {0} caracteres ")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "{0} debe tener como maximo {1} caracteres ")]
        [Display(Name = "Direccion")]
        public string direccion { get; set; }

        [Required]
        [Display(Name = "Telefono")]
        [ValidarTelefono]
        public string telefono { get; set; }

        [Required]
        [StringLength(maximumLength: 11, ErrorMessage = "CUIT debe tener como maximo {0} caracteres ")]
        [Display(Name = "CUIT")]
        public string CUIT { get; set; }

        [Required]
        [Display(Name = "Situación frente al IVA")]
        public int id_IVA { get; set; }
        public string descripcion { get; set; }
    }
}