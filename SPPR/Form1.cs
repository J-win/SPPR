using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace SPPR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private double f(double x)
        {
            double a = Convert.ToDouble(textBox1.Text);
            double b = Convert.ToDouble(textBox2.Text);
            double c = Convert.ToDouble(textBox3.Text);
            double d = Convert.ToDouble(textBox4.Text);

            return (a * Math.Sin(b * x) + c * Math.Cos(d * x));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(textBox5.Text);
            double ee = Convert.ToDouble(textBox6.Text);
            double r = Convert.ToDouble(textBox7.Text);
            double a = Convert.ToDouble(textBox8.Text);
            double b = Convert.ToDouble(textBox9.Text);

            LinkList p = new LinkList();

            if (radioButton1.Checked)
            {
                AGP metod = new Strongin();

                MinPoint minp = metod.minSearch(p, a, b, ee, n, r, f);

                label1.Text = "Min x = " + Convert.ToString(minp.x);
                label2.Text = "Min z = " + Convert.ToString(minp.z);
                label8.Text = "n = " + Convert.ToString(minp.k);
                label14.Text = "ee = " + Convert.ToString(minp.ee);
            }

            if (radioButton2.Checked)
            {
                AGP metod = new Piyavsky();

                MinPoint minp = metod.minSearch(p, a, b, ee, n, r, f);

                label1.Text = "Min x = " + Convert.ToString(minp.x);
                label2.Text = "Min z = " + Convert.ToString(minp.z);
                label8.Text = "n = " + Convert.ToString(minp.k);
                label14.Text = "ee = " + Convert.ToString(minp.ee);
            }

            if (radioButton3.Checked)
            {
                AGP metod = new Scan();

                MinPoint minp = metod.minSearch(p, a, b, ee, n, r, f);

                label1.Text = "Min x = " + Convert.ToString(minp.x);
                label2.Text = "Min z = " + Convert.ToString(minp.z);
                label8.Text = "n = " + Convert.ToString(minp.k);
                label14.Text = "ee = " + Convert.ToString(minp.ee);
            }

            p.art(zedGraphControl1);

            PointPairList list_zz = new PointPairList();

            double h = (b - a) / (double)n;

            for (int i = 0; i < n - 1; i++)
            {
                double x = a + i * h;
                double z = f(x);

                list_zz.Add(x, z);
            }

            list_zz.Add(b, f(b));

            LineItem Curve3 = zedGraphControl1.GraphPane.AddCurve("fun", list_zz, Color.Gray, SymbolType.None);

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }
    }
}
