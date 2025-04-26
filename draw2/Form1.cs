using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace draw2
{
    public partial class Form1 : Form
    {
        Bitmap bmp=new Bitmap(410,410);
        Graphics g;
        int oldx = 0, oldy = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int x1 = 205, y1 = 205;//中心點
            g= Graphics.FromImage(bmp);
            Random rd = new Random();
            Pen pen = new Pen(Color.FromArgb(rd.Next(0,256), rd.Next(0,256), rd.Next(0,256)));
            g.DrawLine(pen, 205, 205, rd.Next(0,411),rd.Next(0,411));
            pictureBox1.Image = bmp;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //timer1.Enabled = false;
            g = Graphics.FromImage(bmp);
            g.Clear(BackColor);
            pictureBox1.Image = bmp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random rd = new Random();
            g = Graphics.FromImage(bmp);
            int x1 = rd.Next(0, 411), y1 = rd.Next(0, 411);
            g.DrawLine(Pens.Red, oldx, oldy,x1 ,y1 );
            oldx = x1;
            oldy = y1;
            pictureBox1.Image = bmp;
        }
    }
}
