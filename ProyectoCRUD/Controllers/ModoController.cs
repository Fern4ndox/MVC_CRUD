using ProyectoCRUD.Models;
using ProyectoCRUD.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoCRUD.Controllers
{
    public class ModoController : Controller
    {
        // GET: TipoProducto
        public ActionResult Index()
        {
            List<ListarModo> list;
            using (DB_Parcial2Entities1 bd = new DB_Parcial2Entities1())
            {
                list = (from b in bd.TB_Modo
                        select new ListarModo
                        {
                            ID = b.Modo_ID,
                            Modo = b.Modo_Modo
                        }).ToList();
            }
            return View(list);
        }
        public ActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(ModoViewModel Mod)
        {
            try
            {
                //Validación Datos
                if (ModelState.IsValid)
                {
                    //Almacenamiento DATOS DB
                    using (DB_Parcial2Entities1 bd = new DB_Parcial2Entities1())
                    {
                        var Md = new TB_Modo();
                        Md.Modo_Modo = Mod.Modo;
                        bd.TB_Modo.Add(Md);
                        bd.SaveChanges();
                    }
                    return Redirect("~/Modo/");
                }

                return View(Mod);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        public ActionResult Editar(int id)
        {
            ModoViewModel model = new ModoViewModel();
            using (DB_Parcial2Entities1 bd = new DB_Parcial2Entities1())
            {
                var Mod = bd.TB_Modo.Find(id);//obtenemos registro por medio de id
                model.ID = Mod.Modo_ID;
                model.Modo = Mod.Modo_Modo;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Editar(ModoViewModel MD)
        {
            try
            {
                //validar datos
                if (ModelState.IsValid)
                {
                    //guardamos datos en bd
                    using (DB_Parcial2Entities1 bd = new DB_Parcial2Entities1())
                    {
                        var Mod = bd.TB_Modo.Find(MD.ID);//obtenemos registro por medio de id
                        Mod.Modo_Modo= MD.Modo;
                        //editamos registro
                        bd.Entry(Mod).State = EntityState.Modified;
                        bd.SaveChanges();
                    }

                    return Redirect("~/Modo/");
                }

                return View(MD);
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        [HttpPost]
        public ActionResult Eliminar(int id)
        {

            ModoViewModel model = new ModoViewModel();
            using (DB_Parcial2Entities1 bd = new DB_Parcial2Entities1())
            {
                var Mod = bd.TB_Modo.Find(id);//obtengo entidad con id

                bd.TB_Modo.Remove(Mod);

                bd.SaveChanges();

            }
            return Content("ok");
        }
    }
}