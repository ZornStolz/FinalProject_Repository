using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{


    class ViewModel
    {
        /**
        * Atributes
        */
        private String fecha;
        private String autoridad_ambiental;
        private String nombre_de_la_estaci_n;
        private String tecnolog_a;
        private double latitud;
        private double longitud;
        private String c_digo_del_departamento;
        private String departamento;
        private String c_digo_del_municipio;
        private String nombre_del_municipio;
        private String tipo_de_estaci_n;
        private String tiempo_de_exposici_n;
        private String variable;
        private String unidades;
        private double concentraci_n;

        public string Fecha { get => fecha; set => fecha = value; }
        public string Autoridad_ambiental { get => autoridad_ambiental; set => autoridad_ambiental = value; }
        public string Nombre_de_la_estaci_n { get => nombre_de_la_estaci_n; set => nombre_de_la_estaci_n = value; }
        public string Tecnolog_a { get => tecnolog_a; set => tecnolog_a = value; }
        public double Latitud { get => latitud; set => latitud = value; }
        public double Longitud { get => longitud; set => longitud = value; }
        public string C_digo_del_departamento { get => c_digo_del_departamento; set => c_digo_del_departamento = value; }
        public string Departamento { get => departamento; set => departamento = value; }
        public string C_digo_del_municipio { get => c_digo_del_municipio; set => c_digo_del_municipio = value; }
        public string Nombre_del_municipio { get => nombre_del_municipio; set => nombre_del_municipio = value; }
        public string Tipo_de_estaci_n { get => tipo_de_estaci_n; set => tipo_de_estaci_n = value; }
        public string Tiempo_de_exposici_n { get => tiempo_de_exposici_n; set => tiempo_de_exposici_n = value; }
        public string Variable { get => variable; set => variable = value; }
        public string Unidades { get => unidades; set => unidades = value; }
        public double Concentraci_n { get => concentraci_n; set => concentraci_n = value; }
    }





}
