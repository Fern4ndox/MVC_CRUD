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
    public class MatenimientoController : Controller
    {
            // GET: TipoProducto
            public ActionResult Index()
            {
                List<ListarMantenimiento> list;
                using (DB_Parcial2Entities1 bd = new DB_Parcial2Entities1())
                {
                    list = (from b in bd.TB_Mantenimientos
                            select new ListarMantenimiento
                            {
                                ID = b.Mantenimiento_ID,
                                Descripcion= b.Mantenimiento_Descripcion,
                                KM = b.Mantenimiento_KM,
                            }).ToList();
                }
                return View(list);
            }
            public ActionResult Nuevo()
            {
                return View();
            }
        [HttpPost]
        public ActionResult Nuevo(MantenimientoViewModel TP)
        {
            try
            {
                //Validación Datos
                if (ModelState.IsValid)
                {
                    //Almacenamiento DATOS DB
                    using (DB_Parcial2Entities1 bd = new DB_Parcial2Entities1())
                    {
                        var tprod = new TB_Mantenimientos();
                        tprod.Mantenimiento_Descripcion= TP.Descripcion;
                        tprod.Mantenimiento_KM = TP.KM;
                        bd.TB_Mantenimientos.Add(tprod);
                        bd.SaveChanges();
                    }
                    return Redirect("~/Matenimiento/");
                }

                return View(TP);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        public ActionResult Editar(int id)
        {
            MantenimientoViewModel model = new MantenimientoViewModel();
            using (DB_Parcial2Entities1 bd = new DB_Parcial2Entities1())
            {
                var Tprod = bd.TB_Mantenimientos.Find(id);//obtenemos registro por medio de id
                model.ID = Tprod.Mantenimiento_ID;
                model.Descripcion = Tprod.Mantenimiento_Descripcion;
                model.KM= Tprod.Mantenimiento_KM;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Editar(MantenimientoViewModel TP)
        {
            try
            {
                //validar datos
                if (ModelState.IsValid)
                {
                    //guardamos datos en bd
                    using (DB_Parcial2Entities1 bd = new DB_Parcial2Entities1())
                    {
                        var Tprod = bd.TB_Mantenimientos.Find(TP.ID);//obtenemos registro por medio de id
                        Tprod.Mantenimiento_Descripcion = TP.Descripcion;
                        Tprod.Mantenimiento_KM = TP.KM;
                        //editamos registro
                        bd.Entry(Tprod).State = EntityState.Modified;
                        bd.SaveChanges();
                    }

                    return Redirect("~/Matenimiento/");
                }

                return View(TP);
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        [HttpPost]
        public ActionResult Eliminar(int id)
        {

            MantenimientoViewModel model = new MantenimientoViewModel();
            using (DB_Parcial2Entities1 bd = new DB_Parcial2Entities1())
            {
                var tProd = bd.TB_Mantenimientos.Find(id);//obtengo entidad con id

                bd.TB_Mantenimientos.Remove(tProd);

                bd.SaveChanges();

            }
            return Content("ok");
        }
    }
}