﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDGS903_Tema1.Models
{
    public class Pulques
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set;}
        public int Litros { get; set; }
        public DateTime Caducidad { get; set; }
    }
}