using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 北軟9903
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label5.Text = "";
            pictureBox1.Image = Image.FromFile(textBox1.Text);
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            int sx = int.MaxValue, sy = 0,tx=-1,ty=0;
            for(int i=0;i<bmp.Height;i++)
            {
                int y = bmp.Height - 1 - i;
                for(int j=0;j<bmp.Width;j++)
                {
                    Color c= bmp.GetPixel(j,i);
                    if(c.R==0&&c.G==0&&c.B==0)
                    {
                        if(j<sx)
                        {
                            sx = j;
                            sy = y;
                        }
                        if(j>tx)
                        {
                            tx = j;
                            ty= y;
                        }
                    }
                }
            }
            label2.Text = $"線段左邊端({sx},{sy})點坐標";
            label3.Text = $"線段右邊端({tx},{ty})點坐標";
            double ans = 0;
            if (sx != tx)
            {
                ans = (ty - sy) / (double)(tx - sx);
                label5.Text = "" + ans.ToString("0.00");
            }
            else label5.Text = "斜率不存在";
        }
    }
}
