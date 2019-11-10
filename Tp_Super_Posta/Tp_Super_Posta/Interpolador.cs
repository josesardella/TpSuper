using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Tp_Super_Posta
{
    public partial class Interpolador : Form
    {
        List<double> Abscisas = new List<double>();
        List<double> Ordenadas = new List<double>();
        bool lg = false;
        bool ngp = false;
        bool ngr = false;
        bool eqesp = false;

        public Interpolador()
        {
            InitializeComponent();
        }

        public void Interpolador_KeyPress(object sender, KeyPressEventArgs Tecla)
        {
            if (Tecla.KeyChar == 6)
            {
                radioButton6.Checked = true;

                if (textBox2.SelectionStart == 0)
                    textBox1.SelectionStart = 0;

                else if (textBox1.SelectionStart == 0)
                    textBox2.SelectionStart = 0;

                else
                    textBox2.SelectionStart = 0;
            }
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

        private void LaGrange()
        {
            //FALTA HACER QUE LA PERSONA INGRESE LOS PUNTOS POR PANTALLA
            int cantidadElementos = Abscisas.Count; //CALCULE SOLO
            //double incognita = k; //el valor para verificar el polinomio
            //double resultado = 0;
            //el polinomio que pusimos de ejemplo es x^2 + x + 1
            //int[] lx = new int[cantidadElementos];//no sirve
            int i = 0;
            string String = "0";
            string Strin2 = "";

            label12.Text = label12.Text + " G(P) = " + cantidadElementos;

            while (i < cantidadElementos)
            {
                int j = 0;
                //double L = 1;
                while (j < cantidadElementos)
                {
                    if (i != j)
                    {
                        Strin2 = Strin2 + "[(x - " + Abscisas[j] + ") / (" + Abscisas[i] + " - " + Abscisas[j] + ")] ";
                    }
                    j++;
                }
                //Printeamos los L
                String = String + " + " + Ordenadas[i] + " * " + Strin2;
                label12.Text = label12.Text + "\n" + "L" + i + " es: " + Strin2;
                Strin2 = "";

                i++;
            }
            if (i > 0)
                label13.Text = "Polinomio:\n" + "P(x) = " + String;
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

            label13.Text = "Polinomio:";

            if (radioButton4.Checked)
            {
                LaGrange();
                lg = true;
            }
            else if (radioButton5.Checked)
            {
                NGP();
                ngp = true;
            }
            else if (radioButton6.Checked)
            {
                NGR();
                ngr = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private bool i (char caracter)
        {
            if (caracter == '0' || caracter == '1' || caracter == '2' || caracter == '3' || caracter == '4' || caracter == '5' || caracter == '6' || caracter == '7' || caracter == '8' || caracter == '9')
                return true;
            return false;
        }

        private bool digito (char caracter)
        {
            if (caracter == '0' || caracter == '1' || caracter == '2' || caracter == '3' || caracter == '4' || caracter == '5' || caracter == '6' || caracter == '7' || caracter == '8' || caracter == '9' || caracter == '.')
                return true;
            return false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "(opcional)" || textBox3.Text == "")
            {
                if (textBox1.Text.All(caracter => digito(caracter)) && textBox1.Text != "" && textBox2.Text.All(caracter => digito(caracter)) && textBox2.Text != "")
                {
                    int n = dataGridView2.Rows.Add();
                    dataGridView2.Rows[n].Cells[0].Value = Convert.ToDouble(textBox2.Text);
                    dataGridView2.Rows[n].Cells[1].Value = Convert.ToDouble(textBox1.Text);
                    Abscisas.Add(Convert.ToDouble(textBox2.Text));
                    Ordenadas.Add(Convert.ToDouble(textBox1.Text));
                    textBox1.Text = "";
                    textBox2.Text = "";
                    label12.Text = "Pasos:";
                }

                else
                    label12.Text = "Ingrese campos válidos";
            }
            else
            {
                if (textBox1.Text.All(caracter => digito(caracter)) && textBox1.Text != "" && textBox2.Text.All(caracter => digito(caracter)) && textBox2.Text != "" && textBox3.Text.All(caracter => i(caracter)) && Convert.ToDouble(textBox3.Text) < Abscisas.Count && Convert.ToDouble(textBox3.Text) >= 0)
                {
                    dataGridView2.Rows[Convert.ToInt32(textBox3.Text)].Cells[0].Value = Convert.ToDouble(textBox2.Text);
                    dataGridView2.Rows[Convert.ToInt32(textBox3.Text)].Cells[1].Value = Convert.ToDouble(textBox1.Text);
                    Abscisas[Convert.ToInt32(textBox3.Text)] = Convert.ToDouble(textBox2.Text);
                    Ordenadas[Convert.ToInt32(textBox3.Text)] = Convert.ToDouble(textBox1.Text);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    label12.Text = "Pasos:";
                }

                else
                    label12.Text = "Ingrese campos válidos";
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

        private void NGP()
        {
            eqesp = true;

            int n = Abscisas.Count;

            if (n == 0)
                return;

            if (n == 1)
            {
                label12.Text = label12.Text + "\n" + Ordenadas[0];

                label13.Text = label13.Text + "\nP(x) = 0 + " + Ordenadas[0];

                return;
            }

            double esp = Abscisas[1] - Abscisas[0];

            for (int i = 1; i < n; i++)
            {
                if (esp != Abscisas[i] - Abscisas[i - 1])
                    eqesp = false;
            }

            if (!eqesp)
                label12.Text = label12.Text + " (Los puntos no son equiespaciados)";

            label12.Text = label12.Text + " G(P) = " + n;

            double[,] y = new double[n, n];

            for (int i = 0; i < n; i++)
                y[i, 0] = Ordenadas[i];

            label12.Text = label12.Text + "\n";

            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < n - i; j++)
                {
                    y[j, i] = (y[j + 1, i - 1] - y[j, i - 1]) / (Abscisas[i + j] - Abscisas[j]);

                    label12.Text = label12.Text + y[j, i] + " ";
                }

                label12.Text = label12.Text + '\n';
            }

            label13.Text = label13.Text + "\nP(x) = 0";

            for (int i = n - 1; i >= 0; i--)
            {
                label13.Text = label13.Text + " + " + y[0, n - i - 1];

                for (int j = n - 1; j > i; j--)
                    label13.Text = label13.Text + "(x - " + Abscisas[n - j - 1] + ")";
            }
        }

        private void NGR()
        {
            int n = Abscisas.Count;

            if (n == 0)
                return;

            if (n == 1)
            {
                label12.Text = label12.Text + "\n" + Ordenadas[0];

                label13.Text = label13.Text + "\nP(x) = 0 + " + Ordenadas[0];

                return;
            }

            double esp = Abscisas[1] - Abscisas[0];

            for (int i = 1; i < n; i++)
            {
                if (esp != Abscisas[i] - Abscisas[i - 1])
                    eqesp = false;
            }

            if (!eqesp)
                label12.Text = label12.Text + " (Los puntos no son equiespaciados)";

            label12.Text = label12.Text + " G(P) = " + n;

            double[,] y = new double[n, n];

            for (int i = 0; i < n; i++)
                y[i, 0] = Ordenadas[i];

            label12.Text = label12.Text + "\n";

            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < n - i; j++)
                {
                    y[j, i] = (y[j + 1, i - 1] - y[j, i - 1]) / (Abscisas[i + j] - Abscisas[j]);

                    label12.Text = label12.Text + y[j, i] + " ";
                }

                label12.Text = label12.Text + '\n';
            }

            label13.Text = label13.Text + "\nP(x) = 0";

            for (int i = n - 1; i >= 0; i--)
            {
                label13.Text = label13.Text + " + " + y[i, n - i - 1];

                for (int j = n - 1; j > i; j--)
                    label13.Text = label13.Text + "(x - " + Abscisas[j] + ")";
            }
        }

        private void NGPReemplazado(double k)
        {
            // Los puntos ha interpolar
            int n = Abscisas.Count;

            if (n == 0)
                return;

            if (n == 1)
            {
                label13.Text = label13.Text + "\nEl resultado:\nP(" + k + ") = " + Ordenadas[0];

                return;
            }

            // y[,] se usa para la tablea
            // y[,0] para el primer valor
            double[,] y = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                y[i, 0] = Ordenadas[i];
            }

            // Calculo de las diferencias respecto a y
            // tabla
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < n - i; j++)
                {
                    y[j, i] = (y[j + 1, i - 1] - y[j, i - 1]);/// (Abscisas[i + j] - Abscisas[j]);
                }
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

            label13.Text = label13.Text + "\nEl resultado:\n" + "P(" + incognita + ") = " + Math.Round(sum, n);
            //Console.ReadKey();
        }

        static double calculoDeUR(double u, int n)
        {
            double temp = u;
            for (int i = 1; i < n; i++)
                temp = temp * (u + i);
            return temp;
        }

        public void NGRReemplazado(double k)
        {
            // Los puntos ha interpolar
            int n = Abscisas.Count;

            if (n == 0)
                return;

            if (n == 1)
            {
                label13.Text = label13.Text + "\nEl resultado:\nP(" + k + ") = " + Ordenadas[0];

                return;
            }
            
            // y[,] se usa para la tablea
            // y[,0] para el primer valor
            double[,] y = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                y[i, 0] = Ordenadas[i];
            }

            // Calculo de las diferencias respecto a y
            for (int i = 1; i < n; i++)
            {
                for (int j = n - 1; j >= i; j--)
                {
                    y[j, i] = (y[j, i - 1] - y[j - 1, i - 1]);/// (Abscisas[i + j] - Abscisas[j]);
                }
            }

            // Muestra la tabla de los puntos y las diferencias con y

            // lo que queremos interpolar 
            double incognita = k;

            // Usa la u y el factorial
            double sum = y[n - 1, 0];
            double u = (incognita - Abscisas[n - 1]) / (Abscisas[1] - Abscisas[0]);
            for (int i = 1; i < n; i++)
            {
                sum = sum + (calculoDeUR(u, i) * y[n - 1, i]) /
                                            factorial(i);
            }

            label13.Text = label13.Text + "\nEl resultado:\n" + "P(" + incognita + ") = " + Math.Round(sum, n);
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.All(caracter => digito(caracter)))
            {
                if (radioButton4.Checked && lg)
                {
                    LaGrangeReemplazado(Convert.ToDouble(textBox4.Text));
                    lg = false;
                }
                else if (radioButton5.Checked && ngp)
                {
                    NGPReemplazado(Convert.ToDouble(textBox4.Text));
                    ngp = false;
                }
                else if (radioButton6.Checked && ngr)
                {
                    NGRReemplazado(Convert.ToDouble(textBox4.Text));
                    ngr = false;
                }
            }
        }

        public void LaGrangeReemplazado(double k)
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
                //Printeamos los resultados
                resultado = resultado + (L * Ordenadas[i]);

                i++;
            }
            label13.Text = label13.Text + '\n' + "El resultado:\n" + "P(" + incognita + ") = " + resultado;
        }

        private void Interpolador_Load(object sender, EventArgs e)
        {
            
        }
    }
}
