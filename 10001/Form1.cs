using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10001
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(pictureBox1.Width + " " + pictureBox1.Height);
            int N = Convert.ToInt32(textBox1.Text);
            string color=textBox2.Text;
            double[] x= new double[15];
            double[] y= new double[15];
            double b = 2.0 * Math.PI / (double)N;
            for(int i=1;i<=N;i++)
            {
                x[i] = 100.0 * Math.Cos(b*i) + 200;
                y[i] = 100.0 * Math.Sin(b * i) + 200;
            }
            Bitmap bmp=new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);
            Pen p=new Pen(BackColor);
            if(color=="B") p=new Pen(Color.Black);
            if(color=="G") p=new Pen(Color.Green);
            if(color=="R") p=new Pen(Color.Red);
            if(color=="L") p=new Pen(Color.Blue);
            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= N; j++)
                {
                    g.DrawLine(p, (float)x[i], (float)y[i], (float)x[j], (float)y[j]);
                }
            }
            pictureBox1.Image = bmp;
        }
    }
}
