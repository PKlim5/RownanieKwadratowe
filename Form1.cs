using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RownanieKwadratowe
{
    public partial class Form1 : Form
    {
        double a, b, c, delta, x1, x2, x0;
        public Form1()
        {
            InitializeComponent();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void aplus_CheckedChanged(object sender, EventArgs e)
        {
            znaka.Text = "+";
        }

        private void aminus_CheckedChanged(object sender, EventArgs e)
        {
            znaka.Text = "-";
        }

        private void bplus_CheckedChanged(object sender, EventArgs e)
        {
            znakb.Text = "+";
        }

        private void bminus_CheckedChanged(object sender, EventArgs e)
        {
            znakb.Text = "-";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void znakc_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            chart1.Visible = true;
            chart1.Series[0].Points.Clear();

            if (delta > 0)
            {
                chart1.ChartAreas[0].AxisX.Minimum = (int)x2 - 15;
                chart1.ChartAreas[0].AxisX.Maximum = (int)x1 + 15;
                double w;
                for (double i = x2 - 15; i <= x1 + 15; i++)
                { 
                    w = a * i * i + b * i + c;
                    chart1.Series[0].Points.AddXY(i, w);
                }    
            }

            else if (delta == 0)
            {
                chart1.ChartAreas[0].AxisX.Minimum = (int)x0-6;
                chart1.ChartAreas[0].AxisX.Maximum = (int)x0 + 6;
                double w;
                for (double i = x0 - 6; i <= x0 + 6; i++)
                {
                    w = a * i * i + b * i + c;
                    chart1.Series[0].Points.AddXY(i, w);
                }
            }

            else
            {
                double p, q;
                p = -b / (2 * a);
                q = -delta / (4 * a);
                chart1.ChartAreas[0].AxisX.Minimum = (int)p - 7;
                chart1.ChartAreas[0].AxisX.Maximum = (int)p + 7;
                double w;
                for (double i = p - 7; i <= p + 7; i++)
                {
                    w = a * i * i + b * i + c;
                    chart1.Series[0].Points.AddXY(i, w);
                }
            }

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
            panel4.Visible = true;
            chart1.Visible = false;
        }

        private void cplus_CheckedChanged(object sender, EventArgs e)
        {
            znakc.Text = "+";
        }

        private void cminus_CheckedChanged(object sender, EventArgs e)
        {
            znakc.Text = "-";
        }

        private void btnOblicz_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Nie wszystkie współczynniki zostały uzupełnione!\nSprawdź, czy nie pominąłeś liczby 1 lub 0.", "Wystapił błąd.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                button1.Enabled = true;
                a = double.Parse(textBox1.Text) * zwrocZnakA();
                b = double.Parse(textBox2.Text) * zwrocZnakB();
                c = double.Parse(textBox3.Text) * zwrocZnakC() - double.Parse(textBox4.Text);


                delta = b * b - 4 * a * c;

                if (delta > 0)
                {
                    x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                    x2 = (-b - Math.Sqrt(delta)) / (2 * a);


                    label9.Text = "Rozwiązania tego równania to:";
                    label9.Visible = true; //rozwiazania to

                    label10.Visible = true; //x1
                    label12.Text = "1";
                    label12.Visible = true; //indeks1
                    label14.Text = "= " + x1.ToString();
                    label14.Visible = true; //=wynik


                    label11.Visible = true; //x2
                    label13.Text = "2";
                    label13.Visible = true; //indeks2
                    label15.Text = "= " + x2.ToString();
                    label15.Visible = true; //=wynik

                }

                else if (delta == 0)
                {
                    x0 = (-b) / (2 * a);

                    label9.Text = "Rozwiązanie tego równania to:";
                    label9.Visible = true; //rozwiazania to

                    label10.Visible = true; //x1
                    label12.Text = "0";
                    label12.Visible = true; //indeks1
                    label14.Text = "= " + x0.ToString();
                    label14.Visible = true; //=wynik
                }

                else
                {
                    label9.Visible = true;
                    label9.Text = "Równanie nie ma rozwiązania.";
                }

                panel4.Visible = false;
                panel5.Visible = true;



            }
        }

        private double zwrocZnakA()
        {
            if (znaka.Text == "-")
            {
                return -1;
            }
            else
                return 1;
        }

        private double zwrocZnakB()
        {
            if (znakb.Text == "-")
            {
                return -1;
            }
            else
                return 1;
        }

        private double zwrocZnakC()
        {
            if (znakc.Text == "-")
            {
                return -1;
            }
            else
                return 1;
        }

    }
}
