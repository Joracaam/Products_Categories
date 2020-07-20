using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Products_Categories.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Description { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public string Note { get; set; }
        public DateTime CreationDate { get; set; }

    }
}