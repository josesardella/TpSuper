using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
namespace NewtonGregory
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
*/
// C# Program to interpolate using  
// newton forward interpolation 
  
class GFG
{
    // calculating u mentioned in the formula 
    static double u_cal(double u, int n)
    {
        double temp = u;
        for (int i = 1; i < n; i++)
            temp = temp * (u - i);
        return temp;
    }

    // calculating factorial of given number n 
    static int fact(int n)
    {
        int f = 1;
        for (int i = 2; i <= n; i++)
            f *= i;
        return f;
    }

    // Driver code 
    public static void Main()
    {
        // Number of values given 
        int n = 4;
        double[] x = { 1, 2, 3, 4 };

        // y[,] is used for difference table 
        // with y[,0] used for input 
        double[,] y = new double[n, n];
        y[0, 0] = 4;
        y[1, 0] = 15;
        y[2, 0] = 40;
        y[3, 0] = 85;

        // Calculating the forward difference 
        // table 
        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j < n - i; j++)
            {
                y[j, i] = y[j + 1, i - 1] - y[j, i - 1] / x[j + 1] - x[j];
                Console.Write("LA DIFERENCIA ES: " + (x[j + 1] - x[j]) );
                Console.Write(x[j + 1] + "\t");
                Console.Write(x[j] + "\t ");
            }
            Console.Write("\n");
        }

        // Displaying the forward difference table 
        for (int i = 0; i < n; i++)
        {
            Console.Write(x[i] + "\t");
            for (int j = 0; j < n - i; j++)
                Console.Write(y[i, j] + "\t");
            Console.WriteLine();
        }

        // Value to interpolate at 
        double value = 10;

        // initializing u and sum 
        double sum = y[0, 0];
        double u = (value - x[0]) / (x[1] - x[0]);
        for (int i = 1; i < n; i++)
        {
            sum = sum + (u_cal(u, i) * y[0, i]) /
                                    fact(i);
        }

        Console.WriteLine("\n Value at " + value + " is " + Math.Round(sum, 6));
        Console.ReadKey();
    }
}
// This
