using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10402
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sname;
            string[] arraysname,arraysans=new string[50];
            int n;//n行
            sname=textBox1.Text;
            arraysname=sname.Split('\n');
            //MessageBox.Show(arraysname.Length + "");
            n=arraysname.Length;
            textBox2.Text = "";
            for(int i = 0; i < n; i++)
            {
                int tmp = 0,tmp2=0;
                for(int j = 0; j < arraysname[i].Length;j++)
                {
                    if (tmp2 >=4) break;
                    
                    if (arraysname[i][j] =='B'|| arraysname[i][j] == 'P'|| arraysname[i][j] == 'F'|| arraysname[i][j] == 'V')
                    { 
                        if(tmp==1)
                        {
                            tmp = 0;
                            continue;
                        }
                        if(j==0)
                        {
                            arraysans[i] += arraysname[i][j];
                            tmp2++;
                            tmp = 1;
                            continue;
                        }
                       
                        arraysans[i] += "1";
                        tmp2++;
                        tmp = 1;
                    }
                    else if (arraysname[i][j] == 'C' || arraysname[i][j] == 'S' || arraysname[i][j] == 'K' || arraysname[i][j] == 'G' || arraysname[i][j] == 'J' || arraysname[i][j] == 'Q' || arraysname[i][j] == 'X' || arraysname[i][j] == 'Z')
                    {
                        if (tmp == 2)
                        {
                            tmp = 0;
                            continue;
                        }
                        if (j == 0)
                        {
                            arraysans[i] += arraysname[i][j];
                            tmp2++;
                            tmp = 2;
                            continue;
                        }
                        arraysans[i] += "2";
                        tmp2++;
                        tmp = 2;
                    }
                    else if (arraysname[i][j] == 'D' || arraysname[i][j] == 'T' )
                    {
                        if (tmp == 3)
                        {
                            tmp = 0;
                            continue;
                        }
                        if (j == 0)
                        {
                            arraysans[i] += arraysname[i][j];
                            tmp2++;
                            tmp = 3;
                            continue;
                        }
                        arraysans[i] += "3";
                        tmp2++;
                        tmp = 3;
                    }
                    else if (arraysname[i][j] == 'L' )
                    {
                        if (tmp == 4)
                        {
                            tmp = 0;
                            continue;
                        }
                        if (j == 0)
                        {
                            arraysans[i] += arraysname[i][j];
                            tmp2++;
                            tmp = 4;
                            continue;
                        }
                        arraysans[i] += "4";
                        tmp2++;
                        tmp = 4;
                    }
                    else if (arraysname[i][j] == 'M' || arraysname[i][j] == 'N')
                    {
                        if (tmp == 5)
                        {
                            tmp = 0;
                            continue;
                        }
                        if (j == 0)
                        {
                            arraysans[i] += arraysname[i][j];
                            tmp2++;
                            tmp = 5;
                            continue;
                        }
                        arraysans[i] += "5";
                        tmp2++;
                        tmp = 5;
                    }
                    else if (arraysname[i][j] == 'R')
                    {
                        if (tmp == 6)
                        {
                            tmp = 0;
                            continue;
                        }
                        if (j == 0)
                        {
                            arraysans[i] += arraysname[i][j];
                            tmp2++;
                            tmp = 6;
                            continue;
                        }
                        arraysans[i] += "6";
                        tmp2++;
                        tmp = 6;
                    }
                    else tmp = 0;
                 
                }
            }
            for(int i=0;i<n;i++)
            {
                for(int  j=0;j<4;j++)
                {
                    if (arraysans[i].Length > j)
                        textBox2.Text += arraysans[i][j];
                    else textBox2.Text += "0";
                    
                }
                textBox2.Text += "\n";
            }
        }
    }
}
