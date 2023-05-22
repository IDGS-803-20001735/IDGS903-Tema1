using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace IDGS903_Tema1.Models
{
    public class OperasBas
    {
        public int Num1 { get; set; }
        public int Num2 { get; set; }
        public int Resultado { get; set; }

        public void Sumar()
        {
            this.Resultado = this.Num1 + this.Num2;
        }

        public void Restar()
        {
            this.Resultado = this.Num1 - this.Num2;
        }

        public void Multiplicar()
        {
            this.Resultado = this.Num1 * this.Num2;
        }

        public void Dividir()
        {
            this.Resultado= this.Num1 / this.Num2;
        }

        public void Operacion(string operacion) {
            switch (operacion)
            {
                case "SUMAR":
                    Sumar();
                    break;
                case "RESTAR":
                    Restar();
                    break;
                case "MULTIPLICAR":
                    Multiplicar();
                    break;
                case "DIVIDIR":
                    Dividir();
                    break;
            }
        }
    }
}