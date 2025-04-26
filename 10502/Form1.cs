using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10502
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        double manx=0, many=1000,manxend=0,manyend=0;

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            label1.Text=(manyend-many).ToString("0.##");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            label2.Text = (manxend - manx).ToString("0.##");
        }

        public Form1()
        {
            InitializeComponent();
        }
        int cxbegin=0,cxend=0;//右圖初始和結束位置
        private void button1_Click(object sender, EventArgs e)
        {
            manx = 0; many = 1000; manxend = 0;
            manyend = 0;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                bmp=new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = bmp;
                //求cx
                int tr2 = 0;//是否為連續白色區塊
                for(int i=0;i<bmp.Width;i++)
                {
                    int tr = 1;
                    for(int j=0;j<bmp.Height;j++)
                    {
                        Color col= bmp.GetPixel(i, j);
                        double colorvalue = col.R * 0.3 + col.G * 0.59 + col.B * 0.11;
                        if (colorvalue < 200) tr = 0;
                    }
                    if (tr == 1 && tr2 == 0)//全白且之前不是連續白色區塊
                    {
                        cxbegin = cxend;
                        cxend = i;
                        tr2 = 1;
                    }
                    else if (tr == 0)//有顏色
                        tr2 = 0;
                }
                //MessageBox.Show("" + cxbegin + " " + cxend);
                //處理左圖
                int chairx = 0,chairy=1000,chairendx=0,chairendy=0;
                for(int i=0;i<cxbegin;i++)
                {
                    for(int j=0;j<bmp.Height;j++)
                    {
                        Color col = bmp.GetPixel(i, j);
                        double colorvalue = col.R * 0.3 + col.G * 0.59 + col.B * 0.11;
                        if(colorvalue < 200)
                        {
                            if (chairx == 0) chairx = i;
                            chairendx = i;
                            chairy=Math.Min(chairy,j);
                            chairendy=Math.Max(chairendy,j);
                        }

                    }
                }
                double k = (double)830 / (double)(chairendy - chairy);//比例倍數
                //處理右圖
                for(int i=cxbegin;i<cxend;i++)
                {
                    for(int j=0;j<bmp.Height ;j++)
                    {
                        Color col = bmp.GetPixel(i, j);
                        double colorvalue = col.R * 0.3 + col.G * 0.59 + col.B * 0.11;
                        if (colorvalue < 200)
                        {
                            if(manx == 0) manx = i;
                            manxend = i;
                            many=Math.Min(many,j);
                            manyend=Math.Max(manyend,j);
                        }
                    }
                }
                manx = manx * k;
                many*= k;
                manxend *= k;
                manyend *= k;
            }
        }
    }
}
