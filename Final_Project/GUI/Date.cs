using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    class Date 
    {
        private Date fecha;
        private string dia;
        private string mes;
        private string año;
        private string sistemaH;

        public string Dia { get => dia; set => dia = value; }
        public string Mes { get => mes; set => mes = value; }
        public string Año { get => año; set => año = value; }
        public string SistemaH { get => sistemaH; set => sistemaH = value; }
        internal Date Fecha { get => fecha; set => fecha = value; }
    }
}

