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

namespace _2022_04
{
    public partial class Form1 : Form
    {
        FileInfo f ;
        string[,] s=new string[10,10];
        int tmp = 0;//n
        int tr = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f = new FileInfo(@"C:\Users\USER\Desktop\"+textBox1.Text);
            StreamReader read=f.OpenText();
            
            while(read.Peek() != -1) {
                string ss=read.ReadLine();
                string[] s2=ss.Split(' ');
                for(int i=0;i<s2.Length; i++)
                {
                    s[tmp, i] = s2[i];
                }
                tmp++;
            }
            for(int i=0;i<tmp;i++) 
                {
                    for(int j=0;j<tmp;j++)
                    {
                        innum.Text += s[i, j] + "   ";
                    }
                    innum.Text += "\n";
                }
            while(tr==1)
            {
                tr = 0;
                
                string[,] ans=new string[10,10];
                for(int i=1;i<tmp;i++)
                {
                    for(int j=i;j<tmp;j++)//y=i-1
                    {
                        double maxx = 0;
                        for(int k=0;k<tmp;k++)
                        {
                            double min1 = Convert.ToDouble(s[i-1,k]);
                            double min2 = Convert.ToDouble(s[k,j]);
                            maxx= Math.Max(maxx, Math.Min( min1,min2));
                        }
                        string smaxx = maxx.ToString("0.00");
                        if (s[i-1,j]!=smaxx)
                        {
                            tr = 1;
                            s[i - 1,j] = smaxx;
                            s[j,i - 1] = smaxx;
                        }
                    }
                }
            
                
            }
            for (int i = 0; i < tmp; i++)
                {
                    for (int j = 0; j < tmp; j++)
                    {
                        outnum.Text += s[i, j] + "   ";
                    }
                    outnum.Text += "\n";
                }
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void innum_Click(object sender, EventArgs e)
        {

        }
    }
}
