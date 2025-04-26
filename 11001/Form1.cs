using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _11001
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        List<int> x;
        List<int> y;
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //7個點
            Random rd= new Random();
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(BackColor);
            x = new List<int>();
            y= new List<int>();
            Pen p = new Pen(Color.Black);
            for (int i = 0; i < 10; i++)
            {
                g.DrawLine(p, 0, 20 * i, 180, 20 * i);//橫線
            }
            for (int j = 0; j < 10; j++)
            {
                g.DrawLine(p, 20 * j, 0, 20 * j, 180);//直線
            }
            Brush brush = new SolidBrush(Color.Black);
            for (int i=0;i<7;i++)
            {
                while(true)
                {
                    int x1=rd.Next(1,9);
                    int y1=rd.Next(1,9);
                    if(!x.Contains(x1)||!y.Contains(y1))
                    {
                        x.Add(x1);
                        y.Add(y1);
                        break;
                    }
                }
                g.FillEllipse(brush, x[i] * 20 - 5, y[i] * 20 - 5, 10, 10);
            }
            pictureBox1.Image = bmp;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp=new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);
            Pen p=new Pen(Color.Black);
            for (int i = 0; i < 10; i++)
            {
                g.DrawLine(p,0,20*i,180,20*i);//橫線
            }
            for(int j=0;j<10;j++)
            {
                g.DrawLine(p, 20*j, 0, 20*j, 180);//直線
            }
            pictureBox1.Image = bmp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //red
            int x1,x2, yy;
            x1 = x.Max();
            x2 = x.Min();
            int all = 0;
            for(int i = 0;i<7;i++)
            {
                all += y[i];
            }
            yy = all / 7;
            Graphics g = Graphics.FromImage(bmp);
            Pen pen = new Pen(Color.Red,3);
            int al = x1 - x2;
            g.DrawLine(pen, x2*20, yy*20, x1 * 20, yy * 20);
            for (int i = 0; i < 7; i++)
            {
                al +=Math.Abs( y[i] - yy);
                g.DrawLine(pen, x[i] * 20, y[i] * 20, x[i] * 20, yy * 20);
            }
            pictureBox1.Image= bmp;
            label3.Text = "" + al;
        }
    }
}
