using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoCRUD.Models.ViewModels
{
    public class ModoViewModel
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Modo")]
        //valida el numero de caracteres igual a varchar(50) de nuestra bd
        [StringLength(25)]
        public string Modo { get; set; }
    }
}