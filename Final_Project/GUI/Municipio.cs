using System.Collections.Generic;

namespace GUI
{
    public class Municipio
    {
        //att
        private double latitud;
        private double longitud;
        private string departamento;
        private string nombre_del_municipio;
        private List<Variable_Registrada> variables;

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

        public string Nombre_del_municipio
        {
            get => nombre_del_municipio;
            set => nombre_del_municipio = value;
        }

        public List<Variable_Registrada> Variables
        {
            get => variables;
            set => variables = value;
        }
    }
}