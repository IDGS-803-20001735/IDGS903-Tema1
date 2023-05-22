using IDGS903_Tema1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace IDGS903_Tema1.Services
{
    public class DatosDiccionario
    {
        public void RegistrarPalabra(Diccionario dic)
        {
            var esp = dic.PalabraEsp;
            var ing = dic.PalabraIng;

            var datos = esp + ',' + ing + Environment.NewLine;

            var limpio = datos.ToLower();

            var archivo = HttpContext.Current.Server.MapPath("~/App_Data/palabras.txt");
            File.AppendAllText(archivo, limpio);
        }

        public Array LeerDiccionario()
        {
            Array diccionarioData = null;
            var archivo = HttpContext.Current.Server.MapPath("~/App_Data/palabras.txt");

            if (File.Exists(archivo))
            {
                diccionarioData = File.ReadAllLines(archivo);
            }

            return diccionarioData;
        }
    }
}