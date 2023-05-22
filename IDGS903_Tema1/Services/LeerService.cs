using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace IDGS903_Tema1.Services
{
    public class LeerService
    {
        public Array LeerArchivo()
        {
            Array maesData = null;
            var archivo = HttpContext.Current.Server.MapPath("~/App_Data/datos.txt");
            if (File.Exists(archivo))
            {
                maesData = File.ReadAllLines(archivo);
            }
            return maesData;
        }
    }
}