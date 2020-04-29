using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoCRUD.Models.ViewModels
{
    public class ListarPremios
    {
        public int ID { get; set; }
        public string Premio { get; set; }
        public string Description { get; set; }
    }
}