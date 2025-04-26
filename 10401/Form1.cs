using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10401
{
    public partial class Form1 : Form
    {
        Label[,] lbl = new Label[4, 4];
        int x, y,tr=1;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //
            tr = 1;
            for(int i = 0;i<4;i++)
            {
                for(int j=0;j<4;j++)
                {
                    int x1=j/2, y1=i/2;//哪個四宮格
                    if (lbl[i, j].Text == "") tr = 0;
                    if(i==j)
                    {
                        for(int k=0;k<4;k++)
                        {
                            if (i != k && lbl[i, j].Text == lbl[k, k].Text) tr = 0;
                        }
                    }
                    if(i+j==3)
                    {
                        for(int k=0;k<4;k++)
                        {
                            if (i != k && j != 3 - k && lbl[i, j].Text == lbl[k,3-k].Text) tr = 0;
                        }
                    }
                    
                    for(int k=0;k<4;k++)//橫線
                    {
                        if (k != j && lbl[i, k].Text == lbl[i, j].Text) tr = 0;
                    }
                    for(int k=0 ; k<4 ; k++)//直線
                    {
                        if (k != i && lbl[k,j].Text == lbl[i, j].Text) { tr = 0; }
                    }
                    //四公格
                    for(int k=2*y1 ; k<2*y1+2 ; k++)
                    {
                        for(int h=2*x1 ; h<2*x1+2; h++)
                        {
                            if ((i != k || j != h) && lbl[i, j].Text == lbl[k, h].Text) tr = 0;
                        }
                    }
                }
            }
            if(tr==1) truefalse.Text = "正確";
            else truefalse.Text = "錯誤";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i == j) continue;
                    lbl[i, j].Text = "";
                    string[] num = { "1", "2", "3", "4"};
                    num[i] = "";
                    num[j] = "";
                    int tmp = 0;
                    for (int k = 0; k < 4; k++)
                    {
                        if (num[k] != "")
                        {
                            lbl[i, j].Text +=num[k];
                            tmp = k;
                            break;
                        }

                    }
                    for (int k=tmp+1;k< 4; k++)
                    {
                        if (num[k]!="")
                        {
                            lbl[i, j].Text += ","+num[k];
                        }
                        
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int tmp = 1;
            for(int i=0;i<4;i++)
            {
                for(int j=0;j<4;j++) 
                    lbl[i,j] = new Label();
            }
            for(int i=0;i<4;i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    lbl[i, j] = (Label)Controls["label" + tmp];
                    tmp++;
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            y = 0;
            x = 2;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            y = 0;
            x = 3;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            y = 1;
            x = 0;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            y = 1;
            x = 2;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            y = 1;
            x = 3;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
        }

        private void label9_Click(object sender, EventArgs e)
        {
            y = 2;
            x = 0;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
        }

        private void label10_Click(object sender, EventArgs e)
        {
            y = 2;
            x = 1;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
        }

        private void label12_Click(object sender, EventArgs e)
        {
            y = 2;
            x = 3;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
        }

        private void label13_Click(object sender, EventArgs e)
        {
            y = 3;
            x = 0;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
        }

        private void label14_Click(object sender, EventArgs e)
        {
            y = 3;
            x = 1;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
        }

        private void label15_Click(object sender, EventArgs e)
        {
            y = 3;
            x = 2;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            lbl[y,x].Text=button.Text;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            y = 0;
            x = 1;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
        }
    }
}
