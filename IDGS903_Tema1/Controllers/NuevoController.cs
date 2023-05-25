using IDGS903_Tema1.Models;
using IDGS903_Tema1.Services;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Security.AntiXss;
using System.Web.Services.Description;
using System.Web.UI.WebControls;

namespace IDGS903_Tema1.Controllers
{
    public class NuevoController : Controller
    {
        // GET: Nuevo
        public ActionResult Ventana()
        {
            return View();
        }

        public ActionResult Calculos(string n1, string n2)
        {
            int resultado = Convert.ToInt16(n1) + Convert.ToInt16(n2);
            ViewBag.Res = Convert.ToString(resultado);
            return View();
        }

        public ActionResult Ventana2(OperasBas op, string operacion)
        {
            var model = new OperasBas();

            op.Operacion(operacion);
            model.Resultado = op.Resultado;

            return View(model);
        }

        public ActionResult Distancia()
        {
            return View();
        }

        public ActionResult Resultado(Distancia dis)
        {
            var model = new Distancia();

            dis.calcularDistancia();
            model.Resultado = dis.Resultado;

            return View(model);
        }

        public ActionResult RegistrarTraduccion()
        {
            var dd = new DatosDiccionario();
            ViewBag.Palabras = dd.LeerDiccionario();

            ViewBag.Tabla = false;

            return View();
        }
        [HttpPost]
        public ActionResult RegistrarTraduccion(Diccionario dic)
        {
            var op = new DatosDiccionario();

            op.RegistrarPalabra(dic);

            ViewBag.Palabras = op.LeerDiccionario();

            ViewBag.Tabla = false;

            return View();
        }

        public ActionResult MosrarPalabras()
        {
            var dic = new DatosDiccionario();
            ViewBag.Palabras = dic.LeerDiccionario();

            return View();
        }

        public ActionResult Traductor(string Palabra, string Lenguaje)
        {
            var dic = new DatosDiccionario();
            var palabras = dic.LeerDiccionario();
            var traduccion = "";

            foreach (string item in palabras)
            {
                string[] tupla = item.Split(',');

                switch (Lenguaje)
                {
                    case "ingles":
                        if (Palabra.ToLower() == tupla[0])
                        {
                            traduccion = tupla[1];
                        }
                    break;
                    case "español":
                        if (Palabra.ToLower() == tupla[1])
                        {
                            traduccion = tupla[0];
                        }
                    break;
                }
            }

            if (traduccion == "")
            {
                traduccion = "No se encontro traducción";
            }

            ViewBag.Traduccion = traduccion;

            return View();
        }

        public ActionResult RegistrarDistancia(Puntos puntos)
        {
            puntos.CalcularDistancia();
            puntos.DeterminarTriangulo();

            var model = new Puntos();

            model.DistanciaAB = puntos.DistanciaAB;
            model.DistanciaAC = puntos.DistanciaAC;
            model.DistanciaBC = puntos.DistanciaBC;

            model.TipoTriangulo = puntos.TipoTriangulo;

            model.AreaTriangulo = puntos.AreaTriangulo;
            model.PerimetroTriangulo = puntos.PerimetroTriangulo;

            return View(model);
        }

    }
}