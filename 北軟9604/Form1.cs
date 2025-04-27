using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 北軟9604
{
    public partial class Form1 : Form
    {
        Bitmap bmp = new Bitmap(500, 500);
        Graphics g;
        public Form1()
        {
            InitializeComponent();
        }
        double y = 400 / 20;
        double x = 400.0 / 60.0;
        private void Form1_Load(object sender, EventArgs e)
        {
            g=Graphics.FromImage(bmp);
            g.DrawLine(Pens.Black, 50, 50, 50, 450);
            g.DrawLine(Pens.Black, 50, 450, 450, 450);
            g.DrawString("Y", Font, Brushes.Black, 10, 10);
            double a = 1.5;
            
            for(int i=0;i<=20;i++)
            {
                if(i%5==0)
                {
                    g.DrawLine(Pens.Black, 50, (float)(50 + i * y), 40, (float)(50 + i * y));
                    g.DrawString( a.ToString("0.0"), Font, Brushes.Black, 10, (float)(50 + i * y)-10);
                    a -= 0.5;
                }
                else g.DrawLine(Pens.Black, 50, (float)(50 + i * y), 45, (float)(50 + i * y));
            }
            a = -3.0;
            for(int i=0;i<=60;i++)
            {
                if(i%5==0)
                {
                    g.DrawLine(Pens.Black,(float)(50+i*x),450, (float)(50 + i * x), 460);
                    g.DrawString(a.ToString("0.0"), Font, Brushes.Black, (float)(50 + i * x)-15, 460);
                    a += 0.5;
                }
                else g.DrawLine(Pens.Black, (float)(50 + i * x), 450, (float)(50 + i * x), 455);
            }
            //g.RotateTransform(180);
            g.DrawString("Time(秒)", Font, Brushes.Black, 250, 480);
            //g.ResetTransform();
            Pen p = new Pen(Brushes.Black);
            p.DashPattern = new float[] { 6,6 };
            g.DrawLine(p, 50, 350, 450, 350);
            pictureBox1.Image = bmp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image =null;
            bmp = new Bitmap(500, 500);
            g = Graphics.FromImage(bmp);
            g.DrawLine(Pens.Black, 50, 50, 50, 450);
            g.DrawLine(Pens.Black, 50, 450, 450, 450);
            g.DrawString("Y", Font, Brushes.Black, 10, 10);
            double a = 1.5;

            for (int i = 0; i <= 20; i++)
            {
                if (i % 5 == 0)
                {
                    g.DrawLine(Pens.Black, 50, (float)(50 + i * y), 40, (float)(50 + i * y));
                    g.DrawString(a.ToString("0.0"), Font, Brushes.Black, 10, (float)(50 + i * y) - 10);
                    a -= 0.5;
                }
                else g.DrawLine(Pens.Black, 50, (float)(50 + i * y), 45, (float)(50 + i * y));
            }
            a = -3.0;
            for (int i = 0; i <= 60; i++)
            {
                if (i % 5 == 0)
                {
                    g.DrawLine(Pens.Black, (float)(50 + i * x), 450, (float)(50 + i * x), 460);
                    g.DrawString(a.ToString("0.0"), Font, Brushes.Black, (float)(50 + i * x) - 15, 460);
                    a += 0.5;
                }
                else g.DrawLine(Pens.Black, (float)(50 + i * x), 450, (float)(50 + i * x), 455);
            }
            //g.RotateTransform(90);
            g.DrawString("Time(秒)", Font, Brushes.Black, 250, 480);
            //g.RotateTransform(0);
            Pen p = new Pen(Brushes.Black);
            p.DashPattern = new float[] { 6, 6 };
            g.DrawLine(p, 50, 350, 450, 350);
            pictureBox1.Image = bmp;
            //
            int n=int.Parse(textBox1.Text);
            List<PointF> pts = new List<PointF>();
            g=Graphics.FromImage(bmp);
            g.TranslateTransform(50+(float)x*30, 350);
            for(double i=-3;i<=3;i=i+0.01)
            {
                
                double all = 0.5;
                for(int k=1;k<=n;k++)
                {
                    if (k % 2 == 0) continue;
                    all += 2*Math.Cos(k * Math.PI * i + (Math.Pow(-1, (k - 1) / 2) - 1) * (Math.PI / 2))/(k*Math.PI);
                }
                
                pts.Add(new PointF((float)(i*10*x), -(float)(10*y*all)));
            }
            g.DrawLines(Pens.Blue,pts.ToArray());
            pictureBox1.Image=bmp;
        }
    }
}
