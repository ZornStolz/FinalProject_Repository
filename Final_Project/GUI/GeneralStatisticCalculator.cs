using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace GUI
{
    /// <summary>
    /// This is a class meant to calculate general statistic operations to be displayed on the Statistics Tab. Written here to not bloat the MainFrame file, which is already bloated enough.
    /// </summary>
    class GeneralStatisticCalculator
    {
        private List<Variable_Registrada> variables_Set;

        private String units;

        private String variable;

        private List<Double> values;

        private double av;

        private double desv;

        public GeneralStatisticCalculator(List<Variable_Registrada> vars)
        {
            variables_Set = vars;
            units = vars[0].Unidades;
            variable = vars[0].Variable;
            values = new List<double>();
            for(int i = 0; i < variables_Set.Capacity; i++)
            {
                values[i] = variables_Set[i].Concentracion;
            }

            av = values.Average();
            desv = desviation(values);
        }
         
        public String Average()
        {
            return "La media de " + variable + " es de " + av + " "+units;
        }

        public String Max()
        {
            return "Se encontró un valor máximo de " + values.Max() + " "+units;
        }

        public String Min()
        {
            return "Se encontró un valor mínimo de " + values.Min() + " " + units;
        }

        public String desvit()
        {
            return "Se encontró una desviación estándar de " + desv + " " + units;
        }

        public String hProof()
        {
            //Con una probabilidad de 90%, quiero probar que av es menor o mayor que X
            if (variable.Equals("PM10"))
            {
                return hProofPM10();
            } else if (variable.Equals("O3")){
                return hProofO3();
            }
            else
            {
                return hProofSolarRadiation();
            }
        }

        private double desviation(List<double> vs)
        {
            double sumOfDerivation = 0;
            foreach(double value in vs)
            {
                sumOfDerivation += value * value;
            }
            double sumOfDerivationAverage = sumOfDerivation / (vs.Count - 1);
            return Math.Sqrt(sumOfDerivationAverage - (av * av));
        }

        private String hProofPM10()
        {
            String r = "A un nivel de error de 95%, se concluye que";
            double wishedVal = 100;
            //H0: U = wishedVal | H1: U > wishedVal
            double pVal = (av - wishedVal) / (desv / Math.Sqrt(values.Count));
            if(pVal < -1.64) //No rechazo H0
            {
                r += " el nivel de PM10 encontrado puede ser peligroso por fuera de las zonas del filtro.";
            }
            else //Rechazo H0
            {
                r += " el nivel de PM10 puede ser aceptable por fuera de las zonas del filtro.";
            }
            return r;
        }

        private String hProofO3()
        {
            String r = "A un nivel de error de 95%, se concluye que";
            double wishedVal = 100;
            //H0: U = wishedVal | H1: U > wishedVal
            double pVal = (av - wishedVal) / (desv / Math.Sqrt(values.Count));
            if (pVal < -1.64) //No rechazo H0
            {
                r += " el nivel de O3 encontrado puede ser peligroso por fuera de las zonas del filtro.";
            }
            else //Rechazo H0
            {
                r += " el nivel de O3 puede ser aceptable por fuera de las zonas del filtro.";
            }
            return r;
        }
        private String hProofSolarRadiation()
        {
            String r = "A un nivel de error de 95%, se concluye que";
            double wishedVal = 100;
            //H0: U = wishedVal | H1: U > wishedVal
            double pVal = (av - wishedVal) / (desv / Math.Sqrt(values.Count));
            if (pVal < -1.64) //No rechazo H0
            {
                r += " el nivel de Radiación Solar encontrado puede ser peligroso por fuera de las zonas del filtro.";
            }
            else //Rechazo H0
            {
                r += " el nivel de Radiación Solar puede ser aceptable por fuera de las zonas del filtro.";
            }
            return r;
        }
    }
}
