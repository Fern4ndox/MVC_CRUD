using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoCRUD.Models.ViewModels
{
    public class PrecioViewModel
    {
        public int ID { get; set; }
        //valida el numero de caracteres igual a varchar(50) de nuestra bd
        [Required]
        [Display(Name = "Precio")]
        public int Precio { get; set; }
    }
}