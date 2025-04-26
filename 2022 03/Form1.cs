using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2022_03
{
    public partial class Form1 : Form
    {
        Bitmap bmp = new Bitmap(200, 200);
        Graphics g;
        Brush[,] brusharray = new Brush[4, 4];
        Brush[,] brusharray2 = new Brush[4, 4];//左圖
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Point point = new Point(startpc.Width,startpc.Height);
            //MessageBox.Show(point.X.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g=Graphics.FromImage(bmp);
            Random rd = new Random();
            for(int i=0;i<4;i++)
            {
                for(int j=0;j<4;j++)
                {
                    Brush brush = new SolidBrush(Color.FromArgb(rd.Next(0, 256), rd.Next(0, 256), rd.Next(0, 256)));
                    brusharray[i,j] = brush;
                    g.FillRectangle(brusharray[i, j], 50*i,50*j,50,50);
                }
            }
            startpc.Image = bmp;
        }

        private void button2_Click(object sender, EventArgs e)//左右交換
        {
            g=Graphics.FromImage(bmp);
            for(int i=0;i<4;i++)
            {
                for(int j=0;j<4;j++)
                {
                    brusharray2[i, j] = brusharray[i,j];
                }
            }
            for(int i=0;i<2;i++)
            {
                for(int j = 0;j<4;j++)
                {
                    Brush chg = brusharray2[i,j];
                    brusharray2[i,j] = brusharray2[3-i,j];
                    brusharray2[3 - i, j]=chg;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    g.FillRectangle(brusharray2[i, j], 50 * i, 50 * j, 50, 50);
                }
            }
            endpc.Image = bmp;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            g = Graphics.FromImage(bmp);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    brusharray2[i, j] = brusharray[i, j];
                }
            }
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Brush chg = brusharray2[j, i];
                    brusharray2[j, i] = brusharray2[j, 3-i];
                    brusharray2[j, 3-i] = chg;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    g.FillRectangle(brusharray2[i, j], 50 * i, 50 * j, 50, 50);
                }
            }
            endpc.Image = bmp;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            g = Graphics.FromImage(bmp);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    brusharray2[i, j] = brusharray[i, j];
                }
            }
            for(int i=0; i < 4; i++) {//y 4321 >> x 1234
                for(int j = 0;j < 4; j++)
                {
                    brusharray2[j, i] = brusharray[i, 3 - j];
                }
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    g.FillRectangle(brusharray2[i, j], 50 * i, 50 * j, 50, 50);
                }
            }
            endpc.Image = bmp;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            g = Graphics.FromImage(bmp);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    brusharray2[i, j] = brusharray[i, j];
                }
            }
            for (int i = 0; i < 4; i++)
            {//x 4321 >> y 1234
                for (int j = 0; j < 4; j++)
                {
                    brusharray2[i, j] = brusharray[3-j, i];
                }
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    g.FillRectangle(brusharray2[i, j], 50 * i, 50 * j, 50, 50);
                }
            }
            endpc.Image = bmp;
        }
    }
}
