using System;
using System.Diagnostics;
using System.Security.AccessControl;
using Extreme.Mathematics;
using Extreme.Statistics.TimeSeriesAnalysis;

namespace GUI
{
    public class DataAnalysis
    {
        public double[] Arima(int forecast, double[] values)
        {
            Vector<double> tempValues = Vector.Create(values);

            //Find 'd'.
            var adf = new AugmentedDickeyFullerTest(values, 0);
            var p = adf.PValue;

            var acf = tempValues.AutocorrelationFunction(20);

            if (p > 0.05D)
            {
                p = 1;
            }

            tempValues = tempValues.Difference();
            
            // An integrated model (with differencing) is constructed
            // by supplying the degree of differencing. Note the order
            // of the orders is the traditional one for an ARIMA(p,d,q)
            // model (p, d, q).
            var model = new ArimaModel(values, (int) p, 3, 3);

            model.EstimateMean = true;

            // The Compute methods fits the model.
            model.Fit();

            //Predict a specified number of values:
            var nextValues = model.Forecast(forecast);

            //Cast to double[].
            var castedNextValues = new double[nextValues.Length];
            for (var i = 0; i < nextValues.Length; i++) castedNextValues[i] = nextValues[i];

            // return castedNextValues;
            return castedNextValues;
        }

        public double[] ArimaTest(int lag)
        {
            // The time series data is stored in a numerical variable:
            var sunspots = Vector.Create(100.8, 81.6, 66.5, 34.8, 30.6, 7, 19.8, 92.5,
                154.4, 125.9, 84.8, 68.1, 38.5, 22.8, 10.2, 24.1, 82.9, 132, 130.9, 118.1, 89.9, 66.6, 60, 46.9, 41,
                21.3, 16, 6.4, 4.1, 6.8, 14.5, 34, 45, 43.1, 47.5, 42.2, 28.1, 10.1, 8.1, 2.5, 0, 1.4, 5, 12.2, 13.9,
                35.4, 45.8, 41.1, 30.4, 23.9, 15.7, 6.6, 4, 1.8, 8.5, 16.6, 36.3, 49.7, 62.5, 67, 71, 47.8, 27.5, 8.5,
                13.2, 56.9, 121.5, 138.3, 103.2, 85.8, 63.2, 36.8, 24.2, 10.7, 15, 40.1, 61.5, 98.5, 124.3, 95.9, 66.5,
                64.5, 54.2, 39, 20.6, 6.7, 4.3, 22.8, 54.8, 93.8, 95.7, 77.2, 59.1, 44, 47, 30.5, 16.3, 7.3, 37.3,
                73.9);

            //Find 'd'.
            AugmentedDickeyFullerTest adf = new AugmentedDickeyFullerTest(sunspots, 0);
            double d = adf.Statistic;
            // Console.WriteLine(d);
            // Console.WriteLine(adf.PValue);

            // An integrated model (with differencing) is constructed
            // by supplying the degree of differencing. Note the order
            // of the orders is the traditional one for an ARIMA(p,d,q)
            // model (p, d, q).
            // The following constructs an ARIMA(0,1,1) model:
            ArimaModel model = new ArimaModel(sunspots, 2, 1);

            model.EstimateMean = true;

            // The Compute methods fits the model.
            model.Fit();

            //Predict a specified number of values:
            var nextValues = model.Forecast(5);

            //Cast to double[].
            var castedNextValues = new double[nextValues.Length];
            for (var i = 0; i < nextValues.Length; i++)
            {
                castedNextValues[i] = nextValues[i];
            }

            return castedNextValues;
        }
    }
}