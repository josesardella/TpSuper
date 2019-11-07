using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tp_Super_Posta
{
    public partial class Interpolador : Form
    {
        List<double> Abscisas = new List<double>();
        List<double> Ordenadas = new List<double>();

        public Interpolador()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs fila)
        {
            int n = fila.RowIndex;
            if (n != -1)
            {
                Abscisas[n] = Convert.ToDouble(dataGridView1.Rows[n].Cells[0].Value);
                Ordenadas[n] = Convert.ToDouble(dataGridView1.Rows[n].Cells[1].Value);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label12.Text = "Pasos:";
            if (radioButton1.Checked)
            {
                //LaGrange();
            }
            else if (radioButton2.Checked)
            {
                //NGP();
            }
            //else if (radioButton3.Checked)
            //{

            //}
        }

        private void LaGrange(double k)
        {
            //FALTA HACER QUE LA PERSONA INGRESE LOS PUNTOS POR PANTALLA
            int cantidadElementos = Abscisas.Count; //CALCULE SOLO
            double incognita = k; //el valor para verificar el polinomio
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
                        L = L * ((incognita - Abscisas[j]) / (Abscisas[i] - Abscisas[j]));
                    }
                    j++;
                }
                //Printeamos los L
                label12.Text = label12.Text + "\n" + "L es: " + L + " en x = " + Abscisas[i] + "P(x)= " + resultado + " + ( " + L + " *  " + Ordenadas[i] + ") ";
                resultado = resultado + (L * Ordenadas[i]);

                i++;
            }
            label13.Text = "Polinomio:\n" + "El resultado es: " + resultado;
            //Console.ReadKey();
        }

        static double calculoDeU(double u, int n)
        {
            double temp = u;
            for (int i = 1; i < n; i++)
                temp = temp * (u - i);
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

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs fila)
        {
            int n = fila.RowIndex;
            if (n != -1)
            {
                Abscisas.Add(Convert.ToDouble(dataGridView1.Rows[n].Cells[0].Value));
                Ordenadas.Add(Convert.ToDouble(dataGridView1.Rows[n].Cells[1].Value));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label12.Text = "Pasos:";
            label13.Text = "Resultado:";
            if (radioButton4.Checked)
            {
                LaGrange(Convert.ToDouble(textBox4.Text));
            }
            else if (radioButton5.Checked)
            {
                NGP(Convert.ToDouble(textBox4.Text));
            }
            else if (radioButton6.Checked)
            {
                NGR(Convert.ToDouble(textBox4.Text));
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "(opcional)" || textBox3.Text == "")
            {
                int n = dataGridView2.Rows.Add();
                dataGridView2.Rows[n].Cells[0].Value = Convert.ToDouble(textBox2.Text);
                dataGridView2.Rows[n].Cells[1].Value = Convert.ToDouble(textBox1.Text);
                Abscisas.Add(Convert.ToDouble(textBox2.Text));
                Ordenadas.Add(Convert.ToDouble(textBox1.Text));
                textBox1.Text = "";
                textBox2.Text = "";
            }
            else
            {
                dataGridView2.Rows[Convert.ToInt32(textBox3.Text)].Cells[0].Value = Convert.ToDouble(textBox2.Text);
                dataGridView2.Rows[Convert.ToInt32(textBox3.Text)].Cells[1].Value = Convert.ToDouble(textBox1.Text);
                Abscisas[Convert.ToInt32(textBox3.Text)] = Convert.ToDouble(textBox2.Text);
                Ordenadas[Convert.ToInt32(textBox3.Text)] = Convert.ToDouble(textBox1.Text);
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void NGP(double k)
        {
            // Los puntos ha interpolar
            int n = Abscisas.Count;

            // y[,] se usa para la tablea
            // y[,0] para el primer valor
            double[,] y = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                y[i, 0] = Ordenadas[i];
            }

            // Calculo de las diferencias respecto a y
            // tabla
            label12.Text = label12.Text + '\n';
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < n - i; j++)
                {
                    y[j, i] = (y[j + 1, i - 1] - y[j, i - 1]);/// (Abscisas[i + j] - Abscisas[j]);
                    label12.Text = label12.Text + y[j, i] + " ";
                }
                label12.Text = label12.Text + '\n';
            }

            // Muestra la tabla de los puntos y las diferencias con y
            /*for (int i = 0; i < n; i++)
            {
                Console.Write(Abscisas[i] + "\t");
                for (int j = 0; j < n - i; j++)
                    Console.Write(y[i, j] + "\t");
                Console.WriteLine();
            }*/

            //  lo que queremos interpolar
            double incognita = k;

            // Usa u  y el factorial
            double sum = y[0, 0];
            double u = (incognita - Abscisas[0]) / (Abscisas[1] - Abscisas[0]);
            for (int i = 1; i < n; i++)
            {
                sum = sum + (calculoDeU(u, i) * y[0, i]) /
                                        factorial(i);
            }

            label13.Text = label13.Text + "\n El valor de " + incognita + " es " + Math.Round(sum, 6);
            //Console.ReadKey();
        }

        public void NGR(double k)
        {
            // Los puntos ha interpolar
            int n = Abscisas.Count;
            
            // y[,] se usa para la tablea
            // y[,0] para el primer valor
            double[,] y = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                y[i, 0] = Ordenadas[i];
            }

            // Calculo de las diferencias respecto a y
            label12.Text = label12.Text + '\n';
            for (int i = 1; i < n; i++)
            {
                for (int j = n - 1; j >= i; j--)
                {
                    y[j, i] = (y[j, i - 1] - y[j - 1, i - 1]);/// (Abscisas[i + j] - Abscisas[j]);
                    label12.Text = label12.Text + y[j, i] + " ";
                }
                label12.Text = label12.Text + '\n';
            }

            // Muestra la tabla de los puntos y las diferencias con y

            // lo que queremos interpolar 
            double incognita = k;

            // Usa la u y el factorial
            double sum = y[n - 1, 0];
            double u = (incognita - Abscisas[n - 1]) / (Abscisas[1] - Abscisas[0]);
            for (int i = 1; i < n; i++)
            {
                sum = sum + (calculoDeU(u, i) * y[n - 1, i]) /
                                            factorial(i);
            }

            label13.Text = label13.Text + "\n El valor de " + incognita + " es " + Math.Round(sum, 6);
            //Console.ReadKey();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
