using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Products_Categories.Models
{
    public class UserAccount
    {
        public int AccountId { get; set; }

        [Display(Name = "Correo electrónico")]
        [Required(ErrorMessage = "Este campo es requerido")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
            ErrorMessage = "Dirección de Correo electrónico incorrecta")]
        [StringLength(100, ErrorMessage = "Longitud máxima 100")]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(15, ErrorMessage = "Longitud entre 8 y 20 caracteres",
                      MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public int UserId { get; set; }
        public int Status { get; set; }
        public DateTime CreationDate { get; set; }

        [Display(Name = "Recordarme")]
        public bool RememberMe { get; set; }

    }
}