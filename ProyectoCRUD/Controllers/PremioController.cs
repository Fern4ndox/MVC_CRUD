using ProyectoCRUD.Models;
using ProyectoCRUD.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoCRUD.Controllers
{
    public class PremioController : Controller
    {
        // GET: Premio
        public ActionResult Index()
        {
            List<ListarPremios> list;
            using (DB_Parcial2Entities1 bd = new DB_Parcial2Entities1())
            {
                list = (from b in bd.TB_Premios
                        select new ListarPremios
                        {
                            ID = b.Premio_ID,
                            Premio = b.Premio_Premio,
                            Description = b.Premio_Descripcion
                        }).ToList();
            }
            return View(list);
        }
        public ActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(PremioViewModel premio)
        {
            try
            {
                //Validación Datos
                if (ModelState.IsValid)
                {
                    //Almacenamiento DATOS DB
                    using (DB_Parcial2Entities1 bd = new DB_Parcial2Entities1())
                    {
                        var prem = new TB_Premios();
                        prem.Premio_Premio = premio.Premio.ToString();
                        prem.Premio_Descripcion = premio.Description;
                        bd.TB_Premios.Add(prem);
                        bd.SaveChanges();
                    }
                    return Redirect("~/Premio/");
                }

                return View(premio);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
        }
        
    }
    }

}