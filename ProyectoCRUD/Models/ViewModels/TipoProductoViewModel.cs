using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoCRUD.Models.ViewModels
{
    public class TipoProductoViewModel
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Tipo Producto")]
        //valida el numero de caracteres igual a varchar(50) de nuestra bd
        [StringLength(25)]
        public string TipoProducto { get; set; }
    }
}