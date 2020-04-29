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
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            List<ListarCliente> list;
            using (DB_Parcial2Entities1 bd = new DB_Parcial2Entities1())
            {
                list = (from b in bd.TB_Clientes
                        select new ListarCliente
                        {
                            ID = b.Cliente_ID,
                            Nombre= b.Cliente_Nombre,
                            Direccion = b.Cliente_Direccion,
                            Tel= b.Cliente_Telefono,
                        }).ToList();
            }
            return View(list);
        }
        public ActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(ClienteViewModel TP)
        {
            try
            {
                //Validación Datos
                if (ModelState.IsValid)
                {
                    //Almacenamiento DATOS DB
                    using (DB_Parcial2Entities1 bd = new DB_Parcial2Entities1())
                    {
                        var tprod = new TB_Clientes();
                        tprod.Cliente_Nombre= TP.Nombre;
                        tprod.Cliente_Direccion= TP.Direccion;
                        tprod.Cliente_Telefono= TP.Tel;
                        bd.TB_Clientes.Add(tprod);
                        bd.SaveChanges();
                    }
                    return Redirect("~/Cliente/");
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
            ClienteViewModel model = new ClienteViewModel();
            using (DB_Parcial2Entities1 bd = new DB_Parcial2Entities1())
            {
                var Tprod = bd.TB_Clientes.Find(id);//obtenemos registro por medio de id
                model.ID = Tprod.Cliente_ID;
                model.Nombre = Tprod.Cliente_Nombre;
                model.Direccion = Tprod.Cliente_Direccion;
                model.Tel = Decimal.ToInt32(Tprod.Cliente_Telefono);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Editar(ClienteViewModel TP)
        {
            try
            {
                //validar datos
                if (ModelState.IsValid)
                {
                    //guardamos datos en bd
                    using (DB_Parcial2Entities1 bd = new DB_Parcial2Entities1())
                    {
                        var Tprod = bd.TB_Clientes.Find(TP.ID);//obtenemos registro por medio de id
                        Tprod.Cliente_Nombre = TP.Nombre;
                        Tprod.Cliente_Direccion= TP.Direccion;
                        Tprod.Cliente_Telefono = Decimal.ToInt32(TP.Tel);
                        //editamos registro
                        bd.Entry(Tprod).State = EntityState.Modified;
                        bd.SaveChanges();
                    }

                    return Redirect("~/Cliente/");
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