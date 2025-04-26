using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _9503
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(700, 400);
            Graphics g = Graphics.FromImage(bmp);
            pictureBox1.Image= bmp;
            g.DrawLine(Pens.Black,0, 200, 700, 200);
            g.TranslateTransform(0, 200);
            double x = 0, y = 0;
            List<PointF>pts = new List<PointF>();
            
            if(radioButton1.Checked)//Sin
            {
                
                for(double i=0;i<=360;i=i+0.01)
                {
                    //x += Math.Sin(3.14 / 180.0 * i)*10;
                    y = Math.Sin(3.14 / 180.0 * i)*100;
                    pts.Add(new PointF((float)(i*1.5), -(float)y));
                }
            }
            if(radioButton2.Checked) //Cos
            {
                for (double i = 0; i <= 360; i=i+0.01)
                {
                    //x += Math.Sin(3.14 / 180.0 * i)*10;
                    y = Math.Cos(3.14 / 180.0 * i) * 100;
                    pts.Add(new PointF((float)(i * 1.5), -(float)y));
                }
            }
            g.DrawLines(Pens.Red,pts.ToArray());
        }
    }
}
