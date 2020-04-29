using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoCRUD.Models.ViewModels
{
    public class ListarCliente
    {
        public int ID { get; set; }     
        public string Nombre { get; set; }    
        public string Direccion { get; set; }
        public decimal Tel { get; set; }
    }
}