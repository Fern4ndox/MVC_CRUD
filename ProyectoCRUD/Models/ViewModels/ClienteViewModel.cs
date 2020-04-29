using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoCRUD.Models.ViewModels
{
    public class ClienteViewModel
    {
        public int ID { get; set; }
        //valida el numero de caracteres igual a varchar(50) de nuestra bd
        [Required]
        [Display(Name = "Nombre")]
        public string Nombre{ get; set; }
        [Required]
        [Display(Name = "Dirección")]
        public string Direccion{ get; set; }
        [Required]
        [Display(Name = "Teléfono")]
        public int Tel { get; set; }
    }
}