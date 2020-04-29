using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoCRUD.Models.ViewModels
{
    public class MantenimientoViewModel
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Descripción")]
        [StringLength(25)]
        public string Descripcion { get; set; }
        [Required]
        [Display(Name = "KM")]
        public int KM { get; set; }
    }
}