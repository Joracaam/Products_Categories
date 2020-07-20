using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Products_Categories.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string LastName { get; set; }
        public DateTime CreationDate { get; set; }
    }
}