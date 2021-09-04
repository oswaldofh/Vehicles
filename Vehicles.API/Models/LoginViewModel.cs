using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicles.API.Models
{
    public class LoginViewModel
    {

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Debes ingresar un Email valido")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        [MaxLength(6, ErrorMessage = "El campo {0} no puede tener mas de {1} carácteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Password { get; set; }

        [Display(Name = "Recordrme")]
        public bool RememberMe { get; set; }
    }
}
