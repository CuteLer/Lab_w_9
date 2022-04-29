using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_w_9
{
    public partial class Form1 : Form
    {
        double xmin, xmax, st;
        double[] x, y_1, y_2;

        public void val(double x_m, int count, double st)
        {
            x = new double[count];
            y_1 = new double[count];
            y_2 = new double[count];

            for (int i = 0; i < count; i++)
            {
                x[i] = x_m + st * i;
                y_1[i] = func_1(x[i]);
                y_2[i] = func_2(x[i]);
            }
        }

        public double func_1(double x)
        {
            return 9 * Math.Pow(x, 4) + Math.Sin(57.2 + x);
        }
        public double func_2(double x)
        {
            return 95 * Math.Sin(5 * x);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = ("-2,05").ToString();
            textBox2.Text = ("-0,75").ToString();
            textBox3.Text = ("0,2").ToString();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                xmin = Convert.ToDouble(textBox1.Text);
                xmax = Convert.ToDouble(textBox2.Text);
                st = Convert.ToDouble(textBox3.Text);

                st = Math.Abs(st);
                (xmin, xmax) = (Math.Min(xmax, xmin), Math.Max(xmax, xmin));

                int count = Math.Abs((int)Math.Ceiling((xmax - xmin) / (st * 1.0))) + 1;

                val(xmin, count, st);


                chart1.ChartAreas[0].AxisX.Minimum = xmin;
                chart1.ChartAreas[0].AxisX.Maximum = xmax;

                chart1.ChartAreas[0].AxisX.MajorGrid.Interval = st;


                chart1.Series[0].Points.DataBindXY(x, y_1);
                chart1.Series[1].Points.DataBindXY(x, y_2);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}