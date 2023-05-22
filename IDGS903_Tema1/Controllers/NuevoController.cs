using IDGS903_Tema1.Models;
using IDGS903_Tema1.Services;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security.AntiXss;
using System.Web.Services.Description;

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
            var Traduccion = "";
            var dic = new DatosDiccionario();
            var palabras = dic.LeerDiccionario();

            bool TraduccionEncontrada = false;

            foreach (string item in palabras)
            {
                string[] tupla = item.Split(',');

                if (Lenguaje == "Ingles")
                {
                    if (Palabra.ToLower() == tupla[0])
                    {
                        Traduccion = tupla[1];
                        TraduccionEncontrada = true;
                    }
                } else if (Lenguaje == "Español")
                {
                    if (Palabra.ToLower() == tupla[1])
                    {
                        Traduccion = tupla[0];
                        TraduccionEncontrada = true;
                    }
                }

                if (TraduccionEncontrada == false)
                {
                    Traduccion = "No hay traducción para: " + Palabra;
                }
            }  
                
                
            ViewBag.Traduccion = Traduccion;
            return View();
        }

    }
}