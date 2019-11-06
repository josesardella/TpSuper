using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class GFG 
{

    // Calcula u que se usa al final en la formula
    static double calculoDeU(double u, int n)
    {
        double temp = u;
        for (int i = 1; i < n; i++) 
        temp = temp * (u + i); 
    return temp; 
}

    // calcula factorial para la cantidad de puntos
    static int factorial(int n) 
{ 
    int f = 1; 
    for (int i = 2; i <= n; i++) 
        f *= i; 
    return f; 
} 
  
 
static void Main() 
{
        // Los puntos ha interpolar
        int n = 4; 
    double[] x = { 1, 2, 3, 4 };

        // y[,] se usa para la tablea
        // y[,0] para el primer valor
        double[,] y = new double[n,n];
        y[0, 0] = 4;
        y[1, 0] = 15;
        y[2, 0] = 40;
        y[3, 0] = 85;

        // Calculo de las diferencias respecto a y
        for (int i = 1; i < n; i++)  
    { 
        for (int j = n - 1; j >= i; j--) 
            y[j,i] = y[j,i - 1] - y[j - 1,i - 1]; 
    }

        // Muestra la tabla de los puntos y las diferencias con y
        Console.Write("\n NEWTON GREGORY BACKWARD \n");
        Console.Write(" X       Y      Las diferencias entre las imagenes \n");
        for (int i = 0; i < n; i++) 
    {
            Console.Write(x[i] + "\t");
            for (int j = 0; j <= i; j++) 
            Console.Write(y[i,j]+"\t"); 
        Console.WriteLine(""); 
    } 
  
    // lo que queremos interpolar 
    double incognita = 16; 
  
    // Usa la u y el factorial
    double sum = y[n - 1,0]; 
    double u = (incognita - x[n - 1]) / (x[1] - x[0]); 
    for (int i = 1; i < n; i++)  
    { 
        sum = sum + (calculoDeU(u, i) * y[n - 1,i]) / 
                                    factorial(i); 
    } 
  
    Console.WriteLine("\n El valor de " + incognita + " es " + Math.Round(sum,4));
    Console.ReadKey();
    } 
} 
 