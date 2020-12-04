using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace proyecto_1.Models.ViewModel
{
    public class EmpleadoViewModel
    {
        [Required]
        [Display(Name ="tipo de cargo: 1 - gerente | 2 - empleado")]
       public int id_tipo { get; set; }

        [Required]
        [StringLength(20,ErrorMessage ="El {0} debe tener al menos {1} caracteres ", MinimumLength = 3)]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {1} caracteres ", MinimumLength = 3)]
        [Display(Name = "Apellido")]
       public string apellido { get; set; }

        [Required]
        [Display(Name = "Numero de documento")]
        public int dni { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string password { get; set; }



        [Display(Name = "Confirmar contraseña")]
        [DataType(DataType.Password)]
        [Compare("password",ErrorMessage = "No coinciden las contraseñas")]
        public string Confirmarpassword { get; set; }


      

    }






    public class EditarEmpleadoViewModel
    {
       public int id_empleado { get; set; }

        [Required]
        [Display(Name = "tipo de cargo: 1 - getente | 2 - empleado")]
        public int id_tipo { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {1} caracteres ", MinimumLength = 3)]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {1} caracteres ", MinimumLength = 3)]
        [Display(Name = "Apellido")]
        public string apellido { get; set; }

        [Required]
        [Display(Name = "Numero de documento")]
        public int dni { get; set; }

        
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string password { get; set; }



        [Display(Name = "Confirmar contraseña")]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "No coinciden las contraseñas")]
        public string Confirmarpassword { get; set; }




    }
}