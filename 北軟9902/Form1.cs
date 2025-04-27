using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 北軟9902
{
    public partial class Form1 : Form
    {
        Bitmap bmp = new Bitmap(700, 700);
        Graphics g;
        int sx = 50, sy = 50;
        public Form1()
        {
            InitializeComponent();
            g= Graphics.FromImage(bmp);
            g.DrawLine(Pens.Black, 100, 100, 100, 600);
            g.DrawLine(Pens.Black, 100, 600, 600, 600);
            g.DrawLine(Pens.Black, 100, 100, 600, 100);
            g.DrawLine(Pens.Black, 600, 100, 600, 600);
            //500*500 每1隔為50
            int a = 0;
            int b = 500;
            for(int i=0;i<=10;i++)
            {
                g.DrawLine(Pens.Black, 100+i*50, 600, 100+i*50, 590);
                g.DrawLine(Pens.Black, 100 , 100+i*50, 110, 100+i*50);
                g.DrawString("" + a, Font, Brushes.Black, 100+i*50-8, 605);
                g.DrawString("" + b, Font, Brushes.Black, 70, 100 + i * 50-8);
                a += 50;
                b -= 50;
            }
            
            pictureBox1.Image = bmp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g = Graphics.FromImage(bmp);
            g.TranslateTransform(100, 600);//y=-
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                FileInfo f = new FileInfo(openFileDialog1.FileName);
                StreamReader read=f.OpenText();
                string ss=read.ReadToEnd();
                string[] s=ss.Split(' ');
                int tmp = 0;//0 x 1 y 2 '*'or'o'
                int x = 0, y = 0;
                for(int i=2;i<s.Length; i++)
                {
                    if(tmp%3==0)
                    {
                        x = int.Parse(s[i]);
                    }
                    if(tmp%3==1) y=int.Parse(s[i]);
                    if(tmp%3==2)
                    {
                        if (s[i]=="1")
                        {
                            //red o
                            g.DrawString("o", Font, Brushes.Red, x, -y);
                        }
                        else
                        {
                            g.DrawString("*" ,Font,Brushes.Blue, x, -y);
                        }
                    }
                    tmp++;
                }
                pictureBox1.Image=bmp;
            }
        }
    }
}
