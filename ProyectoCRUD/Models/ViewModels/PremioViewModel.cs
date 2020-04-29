using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoCRUD.Models.ViewModels
{
    public class PremioViewModel
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Premio")]
        //valida el numero de caracteres igual a varchar(50) de nuestra bd
        public string Premio { get; set; }
        [Required]
        [Display(Name = "Descripción")]
        //valida el numero de caracteres igual a varchar(50) de nuestra bd
        [StringLength(75)]
        public string Description { get; set; }
    }
}