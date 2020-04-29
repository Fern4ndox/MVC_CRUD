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
    public class TipoProductoController : Controller
    {
        // GET: TipoProducto
        public ActionResult Index()
        {
            List<ListarTipoProducto> list;
            using (DB_Parcial2Entities1 bd = new DB_Parcial2Entities1())
            {
                list = (from b in bd.TB_TipoProductos
                        select new ListarTipoProducto
                        {
                            ID = b.TipoP_ID,
                            TipoProducto = b.TipoP_Tipo
                        }).ToList();
            }
            return View(list);
        }
        public ActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(TipoProductoViewModel TP)
        {
            try
            {
                //Validación Datos
                if (ModelState.IsValid)
                {
                    //Almacenamiento DATOS DB
                    using (DB_Parcial2Entities1 bd = new DB_Parcial2Entities1())
                    {
                        var tprod = new TB_TipoProductos();
                        tprod.TipoP_Tipo = TP.TipoProducto;
                        bd.TB_TipoProductos.Add(tprod);
                        bd.SaveChanges();
                    }
                    return Redirect("~/TipoProducto/");
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
            TipoProductoViewModel model = new TipoProductoViewModel();
            using (DB_Parcial2Entities1 bd = new DB_Parcial2Entities1())
            {
                var Tprod = bd.TB_TipoProductos.Find(id);//obtenemos registro por medio de id
                model.ID = Tprod.TipoP_ID;
                model.TipoProducto = Tprod.TipoP_Tipo;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Editar(TipoProductoViewModel TP)
        {
            try
            {
                //validar datos
                if (ModelState.IsValid)
                {
                    //guardamos datos en bd
                    using (DB_Parcial2Entities1 bd = new DB_Parcial2Entities1())
                    {
                        var Tprod = bd.TB_TipoProductos.Find(TP.ID);//obtenemos registro por medio de id
                        Tprod.TipoP_Tipo = TP.TipoProducto;
                        //editamos registro
                        bd.Entry(Tprod).State = EntityState.Modified;
                        bd.SaveChanges();
                    }

                    return Redirect("~/TipoProducto/");
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

            TipoProductoViewModel model = new TipoProductoViewModel();
            using (DB_Parcial2Entities1 bd = new DB_Parcial2Entities1())
            {
                var tProd = bd.TB_TipoProductos.Find(id);//obtengo entidad con id

                bd.TB_TipoProductos.Remove(tProd);

                bd.SaveChanges();

            }
            return Content("ok");
        }
    }
}