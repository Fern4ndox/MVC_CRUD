using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoCRUD.Models.ViewModels
{
    public class ListarMantenimiento
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public int KM { get; set; }
    }
}