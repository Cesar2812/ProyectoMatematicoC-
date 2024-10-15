using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    public class Regresion
    {
        // Función para calcular la regresión lineal
        public  void LinearRegression(double[] x, double[] y, out double m, out double b)
        {
            if (x.Length != y.Length)
            {
                throw new ArgumentException("Los arreglos X y Y deben tener la misma longitud.");
            }

            int n = x.Length;

            // Calculando sumatorias necesarias para la regresión lineal
            double sumX = 0, sumY = 0, sumXY = 0, sumXsq = 0;
            for (int i = 0; i < n; i++)
            {
                sumX += x[i];
                sumY += y[i];
                sumXY += x[i] * y[i];
                sumXsq += x[i] * x[i];
            }

            // Calculando la pendiente (m) y la intersección (b)
            m = (n * sumXY - sumX * sumY) / (n * sumXsq - sumX * sumX);
            b = (sumY - m * sumX) / n;
        }






    }
}
