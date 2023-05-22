using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDGS903_Tema1.Models
{
    public class Distancia
    {
        public double X1 { get; set; }
        public double Y1 { get; set; }
        public double X2 { get; set; }
        public double Y2 { get; set; }
        public double Resultado { get; set; }


        public void calcularDistancia()
        {
            this.Resultado = Math.Sqrt(Math.Pow((this.X2 - this.X1),2) + Math.Pow((this.Y2 - this.Y1),2));
        }
    }
}