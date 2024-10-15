using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCalc;

namespace ProyectoFinal
{
     class Program
     {
        public static void Main(string[] args)
        {
            int opcionMenuPrincipal = 0;

            do
            {
                //voy a poner un try catch para el manejo de errores
                try
                {
                    //Menu Princial
                    Console.Clear();
                    Console.WriteLine("\t\t\t----------Bienvenido-----------\n\t\t\t------------MENU---------------\n");
                    Console.WriteLine("\t\t1.Metodo de Euler.");
                    Console.WriteLine("\t\t2.Metodo de Regresion Lineal Simple.");
                    Console.WriteLine("\t\t3.Salir.\n");
                    Console.Write("\n\t\tSeleccione un Metodo: ");
                    //mando a llamar la variable opcion para escoger un metodo
                    opcionMenuPrincipal = Convert.ToInt32(Console.ReadLine());

                    //opciones del menu

                    switch (opcionMenuPrincipal)
                    {
                        case 1:
                            Euler();
                            break;
                        case 2:
                            RegresionLineal();
                            break;
                        case 3:
                            Console.WriteLine("adios");
                            return;

                        default:
                            Console.WriteLine("\n\n\t\tOpcion incorrecta");
                            break;
                    }
                    Console.ReadLine();

                }
                catch (Exception)
                {
                    Console.WriteLine("\n\n\t\tOpcion Incorrecta");
                    Console.ReadLine();
                }


            } while (opcionMenuPrincipal != 3);//Fin del Bucle While

        }//Fin del Metodo Ejecutable 




        //Metodo de Euler
        public static void Euler()
        {
             try
             {
               //Variables que voy a ocupar
                string function;
                double Xn, X0, Y0, h;
                int N;
                
                bool opcion=true;

                   while (opcion)
                   {
                                Console.Clear();
                                Console.WriteLine("Escriba la funcion diferencial a evaluar: "+ "\t\tNOTA: para calcular Ln, se evualua con Log y poner de base el valor de euler 2.7182818284");

                                function = Console.ReadLine();


                                if (string.IsNullOrWhiteSpace(function))
                                {
                                    break; // Salir del bucle si el usuario presiona Enter sin ingresar una función
                                }


                                Console.WriteLine("");
                                Console.WriteLine("A CONTINUACION DIGITE LOS VALORES INICIALES");

                                Console.Write("Escribe el valor de X0:  ");
                                X0 = double.Parse(Console.ReadLine());

                                Console.Write("Escribe el valor de Y0:  ");
                                Y0 = double.Parse(Console.ReadLine());

                                Console.Write("Escribe el valor de Xn:  ");
                                Xn = double.Parse(Console.ReadLine());

                                Console.Write("Escribe el valor de N:  ");
                                N = int.Parse(Console.ReadLine());
                                Console.WriteLine("");

                                Console.WriteLine("---- CALCULAR VALOR DE H ----");
                                h = (Xn - X0) / N;
                                Console.WriteLine("VALOR DE H = " + h);
                                Console.WriteLine();

                                Console.WriteLine("\nTabla de Resultados:");
                                Console.WriteLine("___________________________________________________________");
                                Console.WriteLine("i\t\tXi\t\tYi\t\tXi,Yi");

                                for (int i = 0; i <= N; i++)
                                {

                                    var expr = new Expression(function);
                                    expr.Parameters["x"] = X0;
                                    expr.Parameters["y"] = Y0;
                                    double XiYi = Convert.ToDouble(expr.Evaluate());

                                    string DecX0 = $"{X0:F2}"; //Cree esta variable para almacenar el valor de X0 y solo muestre 2 decimales
                                    Console.WriteLine($"{i}\t\t{DecX0:F4}\t\t{Y0:F4}\t\t{XiYi:F4}");

                                    //Procedimiento para calcular EULER
                                    Y0 += h * XiYi; //Esto representa la formula --Yi = Yi-1 + h(Xi-1, Yi-1)--
                                    X0 += h; // --Xi = Xo + ih--

                                }
                                Console.WriteLine("");
                                Console.WriteLine("----------Presione ENTER para evaluar otra funcion o Presione 0 Para Salir----------");
                                Console.WriteLine("------AL PRESIONAR ENTER SE BORRARA LA TABLA ENTERIOR-------");

                                string input = Console.ReadLine().Trim();
                                if (input == "0")
                                {
                                    Console.WriteLine("\n\n\t\t\tHa salido del Metodo.\n\t\t\tPresione ENTER.");
                                    return;
                                }

                   }      
             }
             catch (Exception ex)
             {
                ex.ToString();   
                   
             }
        }//fin del metodo Euler


        //Metodo de Regresion LinealSimple
        public static void RegresionLineal()
        {
            try
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Ingrese los datos para la regresión lineal:");
                    Console.Write("Número de puntos: ");
                    int n = int.Parse(Console.ReadLine());

                    double[] x = new double[n];
                    double[] y = new double[n];

                    for (int i = 0; i < n; i++)
                    {
                        Console.Write($"Ingrese el valor de x[{i + 1}]: ");
                        x[i] = double.Parse(Console.ReadLine());

                        Console.Write($"Ingrese el valor de y[{i + 1}]: ");
                        y[i] = double.Parse(Console.ReadLine());
                    }

                    // Mostrar la tabla de cálculos
                    Console.WriteLine("\nTabla de cálculos:");
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine("|   x   |   y   | x * y |  x^2  |  y^2  |");
                    Console.WriteLine("-----------------------------------------");

                    double sumX = 0, sumY = 0, sumXY = 0, sumXsq = 0, sumYsq = 0;

                    for (int i = 0; i < n; i++)
                    {
                        double xy = x[i] * y[i];
                        double xsq = x[i] * x[i];
                        double ysq = y[i] * y[i];

                        sumX += x[i];
                        sumY += y[i];
                        sumXY += xy;
                        sumXsq += xsq;
                        sumYsq += ysq;

                        Console.WriteLine($"| {x[i],5} | {y[i],5} | {xy,5} | {xsq,5} | {ysq,5} |");
                    }
                    Console.WriteLine("-----------------------------------------");

                    // Mostrar la sumatoria de los valores calculados
                    Console.WriteLine($"Sumatoria de Xi   : {sumX}");
                    Console.WriteLine($"Sumatoria de Yi   : {sumY}");
                    Console.WriteLine($"Sumatoria de XiYi : {sumXY}");
                    Console.WriteLine($"Sumatoria de Xi^2 : {sumXsq}");
                    Console.WriteLine($"Sumatoria de Yi^2 : {sumYsq}");

                    // Calculando la regresión lineal
                    Regresion regresion = new Regresion();
                    double m, b;
                    regresion.LinearRegression(x, y, out m, out b);
                    Console.WriteLine("----------------------------");
                    Console.WriteLine($"Valor de a0:{b}");
                    Console.WriteLine($"Valor de a1:{m}");

                    // Mostrando los resultados
                    Console.WriteLine($"\nLa ecuación de la línea de regresión es: Y' = {b} + {m} Xi");



                    // Calculando R^2
                    double r = (n * sumXY - sumX * sumY) / (Math.Sqrt((n * sumXsq - Math.Pow(sumX, 2))) * Math.Sqrt((n * sumYsq - Math.Pow(sumY, 2))));
                    double R = Math.Sqrt(r);

                    // Mostrar el coeficiente de determinación (R^2)
                    Console.WriteLine($"Coeficiente de determinación (R^2): {r}");
                    Console.WriteLine($"Coeficiente de determinación (R): {R}");

                    Console.WriteLine("");
                    Console.WriteLine("----------Presione ENTER para evaluar otros Datos o Presione 0 Para Salir----------");
                    Console.WriteLine("------AL PRESIONAR ENTER SE BORRARA LA TABLA ENTERIOR-------");

                    string input = Console.ReadLine().Trim();
                    if (input == "0")
                    {
                        Console.WriteLine("\n\n\t\t\tHa salido del Metodo.\n\t\t\tPresione ENTER.");
                        return;
                    }

                }
            }
            catch(Exception ex)
            {
                ex.ToString();
            } 
        }//fin del metodo de Regresion Lineal
     }
}
