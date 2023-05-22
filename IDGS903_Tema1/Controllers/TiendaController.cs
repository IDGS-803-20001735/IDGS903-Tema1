using IDGS903_Tema1.Models;
using IDGS903_Tema1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace IDGS903_Tema1.Controllers
{
    public class TiendaController : Controller
    {
        // GET: Tienda
        public ActionResult MuestraPulques()
        {
            var pulquesVenta = new PulquesService();
            var model = pulquesVenta.ObtenerPulque();

            return View(model);
        }

        public ActionResult MuestraPulques2()
        {
            TempData["nombres"] = "Mario Lopez";
            var pulquesVenta = new PulquesService();
            var model = pulquesVenta.ObtenerPulque();

            return View(model);
        }

        public JsonResult Index()
        {
            var pulque1 = new Pulques() { Nombre = "PulqueMango", Descripcion = "Mango" };

            return Json(pulque1, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Vista()
        {
            var pulque1 = new Pulques() { 
                Nombre = "PulqueMango", 
                Descripcion = "Mango",
                Caducidad = new DateTime(2023, 11, 3),
                Litros = 12
            };

            ViewBag.pulques = pulque1;
            return View();
        }

        public ActionResult Vista2()
        {
            ViewBag.Saludo = "Hola Mundo";
            ViewBag.Fecha = new DateTime(2023, 11, 2);
            ViewData["Nombre"] = "Diego Alexis";

            string nombre = "";
            if (TempData.ContainsKey("nombre"))
            {
                nombre = TempData["nombres"] as string;
            }
            ViewBag.nombreNuevo = nombre;
            return View();
        }


    }
}
