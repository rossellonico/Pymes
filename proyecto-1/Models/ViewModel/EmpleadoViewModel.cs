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
        [Display(Name = "Tipo de cargo:")]
        public int id_tipo { get; set; }
        public string tipo { get; set; }

        [Required]
        [StringLength(maximumLength: 20, ErrorMessage = "El {0} debe tener como maximo {1} caracteres y como minimo {2}", MinimumLength = 3)]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required]
        [StringLength(maximumLength: 20, ErrorMessage = "El {0} debe tener como maximo {1} caracteres y como minimo {2}", MinimumLength = 3)]
        [Display(Name = "Apellido")]
        public string apellido { get; set; }

        [Required]
        [Display(Name = "Numero de documento")]
        public int dni { get; set; }

        [Required]
        [Display(Name = "Comercio")]
        public int comercio { get; set; }
        public string razon_social { get; set; }


    }

    public class EditarEmpleadoViewModel
    {
        public int id_empleado { get; set; }

        [Required]
        [Display(Name = "Tipo de cargo: 1.Gerente - 2.Empleado ")]
        public int id_tipo { get; set; }

        [Required]
        [StringLength(maximumLength: 20, ErrorMessage = "El {0} debe tener como maximo {1} caracteres y como minimo {2}", MinimumLength = 3)]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required]
        [StringLength(maximumLength: 20, ErrorMessage = "El {0} debe tener como maximo {1} caracteres y como minimo {2}", MinimumLength = 3)]
        [Display(Name = "Apellido")]
        public string apellido { get; set; }

        [Required]
        [Display(Name = "Numero de documento")]
        public int dni { get; set; }

        /*
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string password { get; set; }



        [Display(Name = "Confirmar contraseña")]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "No coinciden las contraseñas")]
        public string Confirmarpassword { get; set; }
        */
    }
    public class EditarEmpleadoPropioViewModel
    {
        public int id_empleado { get; set; }

        [Required]
        [Display(Name = "tipo de cargo: 1- Gerente | 2- Empleado")]
        public int id_tipo { get; set; }

        [Required]
        [StringLength(maximumLength: 20, ErrorMessage = "El {0} debe tener como maximo {1} caracteres y como minimo {2}", MinimumLength = 3)]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required]
        [StringLength(maximumLength: 20, ErrorMessage = "El {0} debe tener como maximo {1} caracteres y como minimo {2}", MinimumLength = 3)]
        [Display(Name = "Apellido")]
        public string apellido { get; set; }

        [Required]
        [Display(Name = "Numero de documento")]
        public int dni { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string password { get; set; }

        
        [Required]
        [Display(Name = "Confirmar contraseña")]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "No coinciden las contraseñas")]
        public string Confirmarpassword { get; set; }
        

    }
   
}
    