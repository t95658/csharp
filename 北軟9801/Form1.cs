using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 北軟9801
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics g;
        double m=0, c=0;
        double sx = 400.0 / 63, sy = 400.0 / 63;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            m = 0; c = 0;
            int[] x=new int[3];
            int[] y=new int[3];
            x[0]=int.Parse(textBox1.Text);
            x[1]=int.Parse(textBox2.Text);
            x[2]=int.Parse(textBox3.Text);
            y[0]=int.Parse(textBox4.Text);
            y[1]=int.Parse(textBox5.Text);
            y[2]=int.Parse(textBox6.Text);
            double xy = 0, xx = 0, x1=0, y1 = 0;
            for(int i=0;i<3;i++)
            {
                xy += x[i] * y[i];
                xx += x[i] * x[i];
                x1 += x[i];
                y1+= y[i];
            }
            m = (3 * xy - x1 * y1) / (3 * xx - x1 * x1);
            c = (xx * y1 - x1 * xy) / (3 * xx - x1 * x1);
            label10.Text = "m=" + m;
            label11.Text = "c=" + c;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            g=Graphics.FromImage(bmp);
            //y=mx+c
            //(y-c)/m=x
            double startx=0, endx = 0;
            startx = (0 - c) / m;
            endx=(63- c) / m;
            //g.DrawLine(Pens.Blue, 500, 500, 100,100);
            g.TranslateTransform(100, 500);
            g.DrawLine(Pens.Blue,(float) startx*(float)sx, 0, (float)endx * (float)sx, -63 * (float)sy);
            pictureBox1.Image = bmp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x1=int.Parse(textBox1.Text);
            int x2=int.Parse(textBox2.Text);
            int x3=int.Parse(textBox3.Text);
            int y1=int.Parse(textBox4.Text);
            int y2=int.Parse(textBox5.Text);
            int y3=int.Parse(textBox6.Text);
            bmp = new Bitmap(600, 600);
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;
            g.DrawLine(Pens.Black, 100, 90, 100, 500);
            g.DrawLine(Pens.Black, 100, 500, 510, 500);
            int step = 0;
            for(int i=0;i<=63;i++)
            {
                g.DrawLine(Pens.Black, 100 + i * (float)sx, 505, 100+i*(float)sx, 495);
                if(i%10==0)
                {
                    g.DrawString("" + step, Font, Brushes.Black, 100 + i * (float)sx-5, 505);
                    step += 10;
                }
            }
            step = 0;
            g.DrawString("x", Font, Brushes.Black, 500, 510);
            for (int i = 63; i >= 0; i--)
            {
                g.DrawLine(Pens.Black, 95, 100 + step * (float)sy, 105, 100 + step * (float)sy);
                if (i%10==0)
                {
                    g.DrawString("" + i, Font, Brushes.Black, 70, 100 + step * (float)sy);

                }
                step++;
            }
            g.DrawString("y", Font, Brushes.Black, 60 ,90);
            g.TranslateTransform(100, 500);
            g.DrawEllipse(Pens.Red,x1*(float)sx-5,-y1*(float)sy-5,10,10);
            g.DrawEllipse(Pens.Red, x2 * (float)sx - 5, -y2 * (float)sy - 5, 10, 10);
            g.DrawEllipse(Pens.Red, x3 * (float)sx - 5, -y3 * (float)sy - 5, 10, 10);
        }
    }
}
