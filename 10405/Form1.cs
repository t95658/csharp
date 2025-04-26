using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10405
{
    public partial class Form1 : Form
    {
        TextBox[,] start = new TextBox[7, 7];
        TextBox[,] end = new TextBox[7, 7];
        TextBox[,] set = new TextBox[3,3];
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for(int i=0;i<7;i++)
            {
                for(int j=0;j<7;j++)
                {
                    start[i,j]=new TextBox();
                    end[i,j]=new TextBox();
                }
            }
            for(int i=0;i<3;i++) for(int j=0;j<3;j++) set[i,j]=new TextBox();
            for(int i=0;i<7;i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    
                    start[i, j].Location = new Point(50 + j * 60, 50 + i * 60);//按照列行
                    start[i, j].Size = new Size(50, 50);
                    start[i, j].Text = "0";
                    end[i,j].Location = new Point(50 + j * 60, 50 + i * 60);
                    end[i, j].Size = new Size(50, 50);
                    end[i, j].Text = "0";
                    end[i, j].TextAlign = textBox4.TextAlign;
                    start[i, j].TextAlign = textBox4.TextAlign;
                    groupBox3.Controls.Add(end[i, j]);
                    groupBox1.Controls.Add(start[i, j]);
                }
            }
            for(int i=0;i<3;i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    set[i, j].Location = new Point(50 + j * 60, 50 + i * 60);
                    set[i, j].Size = new Size(50, 50);
                    set[i, j].Text= "0";
                    set[i,j].TextAlign=textBox4.TextAlign;
                    groupBox2.Controls.Add(set[i, j]);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double[,] I = new double[7, 7];//x y
            for(int i=0;i<7;i++)
            {
                for(int j=0;j<7;j++)
                {
                    I[j, i] = Convert.ToDouble(start[i,j].Text);

                }
            }
            Dictionary<int, Dictionary<int, double>> K = new Dictionary<int, Dictionary<int, double>>();
            int x = -1, y = -1;
            for (int i = -1; i <= 1; i++) K[i] = new Dictionary<int, double>();
            for(int i=2;i>=0;i--)//翻-1~1 -1~1
            {
                for(int j=2;j>=0;j--)
                {
                    double a =Convert.ToDouble( set[i,j].Text);
                    K[x][y] = a;
                    x++;
                }
                x = -1; y++;
            }
            for(int i=0;i<7;i++)//OUT 是列行
            {
                for(int j=0;j<7; j++)
                {
                    double all = 0;
                    x=-1; y= -1;
                    for(int k=i-1;k<=i+1;k++)
                    {
                        for(int r=j-1;r<=j+1;r++)
                        {
                            if(r<0||k<0||r>=7||k>=7) continue;
                            all += I[r, k] * K[x][y];
                            x++;
                        }
                        x = -1;y++;
                    }
                    end[i, j].Text = "" + all;
                }
            }
            double[,] O=new double[7,7];
            for(int i=0;i<7;i++) for(int j=0;j<7;j++) O[j, i] =Convert.ToDouble( end[i,j].Text);
            double mse = 0, mae = 0, psnr = 0;
            for(int i=0;i<7;i++)
            {
                for(int j = 0; j < 7; j++)
                {
                    mse += (I[j, i] - O[j, i]) * (I[j, i] - O[j, i]);
                    mae += Math.Abs(I[j, i] - O[j, i]);
                }
            }
            mse /= (7.0 * 7.0);
            mae /= (7.0 * 7.0);
            psnr = 10 * Math.Log10(255.0*255.0/mse);
            textBox1.Text = "" + mse;
            textBox2.Text = "" + mae;
            textBox3.Text = "" + psnr;
        }
    }
}
