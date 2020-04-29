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
    public class PrecioController : Controller
    {
        // GET: TipoProducto
        public ActionResult Index()
        {
            List<ListarPrecio> list;
            using (DB_Parcial2Entities1 bd = new DB_Parcial2Entities1())
            {
                list = (from b in bd.TB_Precios
                        select new ListarPrecio
                        {
                            ID = b.Precio_ID,
                            Precio = b.Precio_Precio
                        }).ToList();
            }
            return View(list);
        }
        public ActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(PrecioViewModel Mod)
        {
            try
            {
                //Validación Datos
                if (ModelState.IsValid)
                {
                    //Almacenamiento DATOS DB
                    using (DB_Parcial2Entities1 bd = new DB_Parcial2Entities1())
                    {
                        var Md = new TB_Precios();
                        Md.Precio_Precio = Mod.Precio;
                        bd.TB_Precios.Add(Md);
                        bd.SaveChanges();
                    }
                    return Redirect("~/Precio/");
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
            PrecioViewModel model = new PrecioViewModel();
            using (DB_Parcial2Entities1 bd = new DB_Parcial2Entities1())
            {
                var Mod = bd.TB_Precios.Find(id);//obtenemos registro por medio de id
                model.ID = Mod.Precio_ID;
                model.Precio = Mod.Precio_Precio;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Editar(PrecioViewModel MD)
        {
            try
            {
                //validar datos
                if (ModelState.IsValid)
                {
                    //guardamos datos en bd
                    using (DB_Parcial2Entities1 bd = new DB_Parcial2Entities1())
                    {
                        var Mod = bd.TB_Precios.Find(MD.ID);//obtenemos registro por medio de id
                        Mod.Precio_Precio = MD.Precio;
                        //editamos registro
                        bd.Entry(Mod).State = EntityState.Modified;
                        bd.SaveChanges();
                    }

                    return Redirect("~/Precio/");
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

            PrecioViewModel model = new PrecioViewModel();
            using (DB_Parcial2Entities1 bd = new DB_Parcial2Entities1())
            {
                var Mod = bd.TB_Precios.Find(id);//obtengo entidad con id

                bd.TB_Precios.Remove(Mod);

                bd.SaveChanges();

            }
            return Content("ok");
        }
    }
}