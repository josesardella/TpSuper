using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Lagrange
{
    class Program
    {
        static void Main(string[] args)
        {
            //FALTA HACER QUE LA PERSONA INGRESE LOS PUNTOS POR PANTALLA
            int cantidadElementos = 3; //CALCULE SOLO
            double[] abscisas = { 1, 2, 3 };
            double[] ordenada = { 3, 7, 13 };
            double incognita = 7; //el valor para verificar el polinomio
            double resultado = 0;
            //el polinomio que pusimos de ejemplo es x^2 + x + 1
            //int[] lx = new int[cantidadElementos];//no sirve
            int i = 0;


            while (i < cantidadElementos)
            {
                int j = 0;
                double L = 1;
                while (j < cantidadElementos)
                {
                    if (i != j)
                    {
                        L = L * ((incognita - abscisas[j]) / (abscisas[i] - abscisas[j]));
                    }
                    j++;
                }
                //Printeamos los L
                Console.WriteLine("L es: " + L + " en x = " + abscisas[i]);
                Console.WriteLine("P(x)= " + resultado + " + ( " + L + " *  " + ordenada[i] + ") ");
                resultado = resultado + (L * ordenada[i]);

                i++;
            }
            Console.WriteLine("El resultado es: " + resultado);
            Console.ReadKey();
        }
    }
}
