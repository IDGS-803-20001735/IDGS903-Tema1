using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDGS903_Tema1.Models
{
    public class Puntos
    {
        public double X1 { get; set; }
        public double Y1 { get; set; }
        public double X2 { get; set; }
        public double Y2 { get; set; }
        public double X3 { get; set; }
        public double Y3 { get; set; }
        public double DistanciaAB { get; set; }
        public double DistanciaAC { get; set; }
        public double DistanciaBC { get; set; }
        public string TipoTriangulo { get; set; }
        public double AreaTriangulo { get; set; }
        public double PerimetroTriangulo { get; set; }

        public void CalcularDistancia()
        {
            this.DistanciaAB = Math.Round(Math.Sqrt(Math.Pow((this.X1 - this.X2), 2) + Math.Pow((this.Y1 - this.Y2), 2)), 0);
            this.DistanciaAC = Math.Round(Math.Sqrt(Math.Pow((this.X1 - this.X3), 2) + Math.Pow((this.Y1 - this.Y3), 2)), 0);
            this.DistanciaBC = Math.Round(Math.Sqrt(Math.Pow((this.X2 - this.X3), 2) + Math.Pow((this.Y2 - this.Y3), 2)), 0);
        }

        public void DeterminarTriangulo()
        {
            var Condicion = (this.DistanciaAB + this.DistanciaBC > this.DistanciaAC && this.DistanciaAC + this.DistanciaBC > this.DistanciaAB && this.DistanciaAB + this.DistanciaAC > this.DistanciaBC);

            if (Condicion)
            {
                if (this.DistanciaAB == this.DistanciaBC && this.DistanciaAB == this.DistanciaAC)
                {
                    this.TipoTriangulo = "Equilatero";

                    double altura = Math.Sqrt(Math.Pow(this.DistanciaBC, 2) - Math.Pow(this.DistanciaAC / 2, 2));
                    this.AreaTriangulo = Math.Round((this.DistanciaAC * altura) / 2, 2);
                    this.PerimetroTriangulo = this.DistanciaAB + this.DistanciaAC + this.DistanciaBC;

                }
                else if (
                    this.DistanciaAB == this.DistanciaBC && this.DistanciaAB != this.DistanciaAC ||
                    this.DistanciaAC == this.DistanciaAB && this.DistanciaAC != this.DistanciaBC ||
                    this.DistanciaBC == this.DistanciaAC && this.DistanciaBC != this.DistanciaAB
                    )
                {
                    this.TipoTriangulo = "Isósceles";

                    double altura = Math.Sqrt(Math.Pow(this.DistanciaAC, 2) - (Math.Pow(this.DistanciaBC, 2) / 4));
                    this.AreaTriangulo = Math.Round((this.DistanciaBC * altura) / 2, 2);
                    this.PerimetroTriangulo = this.DistanciaAB + this.DistanciaAC + this.DistanciaBC;

                }
                else
                {
                    this.TipoTriangulo = "Escaleno";

                    double semiPerimetro = (this.DistanciaAB + this.DistanciaAC + this.DistanciaBC) / 2;
                    this.AreaTriangulo = Math.Round((Math.Sqrt(semiPerimetro * (semiPerimetro - this.DistanciaAB) * (semiPerimetro - this.DistanciaBC) * (semiPerimetro - this.DistanciaAC))), 2);
                    this.PerimetroTriangulo = this.DistanciaAB + this.DistanciaAC + this.DistanciaBC;
                }
            }
            else
            {
                this.TipoTriangulo = "No es un triangulo";
            }
        }
    }
}