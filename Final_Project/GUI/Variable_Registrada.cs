using System;

namespace GUI
{
    public class Variable_Registrada
    {
        private string variable;
        private string unidades;
        private double concentracion;
        
        public string Variable { get => variable; set => variable = value; }
        public string Unidades { get => unidades; set => unidades = value; }
        public double Concentracion { get => concentracion; set => concentracion = value; }
    }
}