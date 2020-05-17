using System;

namespace GUI
{
    public class Municipio
    {
        //att
        private double latitud;
        private double longitud;
        private String departamento;
        private String nombre_del_municipio;

        public double Latitud
        {
            get => latitud;
            set => latitud = value;
        }

        public double Longitud
        {
            get => longitud;
            set => longitud = value;
        }

        public string Departamento
        {
            get => departamento;
            set => departamento = value;
        }

        public string NombreDelMunicipio
        {
            get => nombre_del_municipio;
            set => nombre_del_municipio = value;
        }
    }
}