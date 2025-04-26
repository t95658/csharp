using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10201
{
    public partial class Form1 : Form
    {
        //[x,y]
        TextBox[,] start = new TextBox[6, 6];
        TextBox[,] value = new TextBox[3, 3];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //6*6
            for (int i = 0; i < 6; i++) for(int j=0;j<6;j++) start[i,j]=new TextBox();
            for(int i=0;i<6;i++)
            {
                for(int j=0;j<6;j++)
                {
                    Controls.Add(start[i,j]);
                    start[i,j].Size=textBox1.Size;
                    start[i, j].Location = new Point(90+40*i,90+25*j);
                }
            }
            //3*3
            for(int i=0;i<3;i++) for(int j=0;j<3;j++) value[i,j]=new TextBox();
            for(int i=0;i<3;i++)
            {
                for(int j=0;j<3;j++)
                {
                    Controls.Add(value[i,j]);
                    value[i, j].Size = textBox1.Size;
                    value[i, j].Location = new Point(500 + 40 * i, 90 + 25 * j);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x=Convert.ToInt32(textBox1.Text);
            int y=Convert.ToInt32(textBox2.Text);
            int[,] num = new int[3, 3];
            int[,] ans = new int[3, 3];
            for (int i = x; i < x + 3; i++)
            {
                for (int j = y; j < y + 3; j++)
                {
                    num[i-x, j-y] =Convert.ToInt32( start[i, j].Text);
                }
            }
            int goal = num[1, 1];
            int all = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if(i==1&&j==1) ans[i, j] = 0;
                    int a=num[i, j]-goal;
                    if(a>=0) ans[i, j] = 1;
                    else ans[i, j] = 0;
                    all += ans[i, j] * Convert.ToInt32(value[i, j].Text);
                }
            }
            label5.Text = "" + all;
        }
    }
}
