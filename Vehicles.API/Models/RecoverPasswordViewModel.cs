using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicles.API.Models
{
    public class RecoverPasswordViewModel
    {
       
        [EmailAddress(ErrorMessage = "Debes ingresar un Email valido")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Email { get; set; }
    }
}
