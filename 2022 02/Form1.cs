using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2022_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string turn(string k)
        {
            string ss = "0x";
            long[] a = new long[3];
            long all = 0, nn = 0;
            int    fp=0;
           
             for(int i=k.Length-1;i>=0;i--)
                { 
                    int all2 = 1;//次方
                    if (k[i] =='1')
                    {
                        for(int j=0;j<nn;j++) {
                            all2 = all2 * 2;
                        }
                        all += all2;              
                    }
                    nn++;
                    a[fp] = all;//a[0]最右邊的16進制
                    if(nn==4)
                    {
                        nn = 0;
                        
                        fp++;
                        all = 0;
                    }
                    
                }
             for(int i=fp;i>=0;i--)
            {
                if (i == fp && a[i] == 0) continue;//第一位是0
                if (a[i] < 10) ss += a[i];
                if (a[i] >= 10)
                {
                    if (a[i] == 10) ss += 'a';
                    if (a[i] == 11) ss += 'b';
                    if (a[i] == 12) ss += 'c';
                    if (a[i] == 13) ss += 'd';
                    if (a[i] == 14) ss += 'e';
                    if (a[i] == 15) ss += 'f';
                }
            }
            return k+'='+ss;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //1
            long key=Convert.ToInt64(textBox1.Text);
            long k = key;
            string ss1=textBox1.Text;
            //轉16進制
                           
            
            s1.Text = turn(ss1);
            //2
            ss1=s1.Text;
            char[] ch2 = new char[11];//answer
            ch2[7] = ss1[0];
            ch2[3] = ss1[1];
            ch2[1] = ss1[2];
            ch2[5] = ss1[3];
            ch2[2] = ss1[4];
            ch2[10] = ss1[5];
            ch2[4] = ss1[6];
            ch2[9] = ss1[7];
            ch2[8] = ss1[8];
            ch2[6] = ss1[9];
            ss1 = "";
            for(int i = 1;i<=10;i++)
            {
                ss1+= ch2[i];
            }
            s2.Text = turn(ss1);
            //3
            //ss1 = s1.Text;
            char[] ch3 = new char[11];//answer
            ch2[1] = ss1[1];
            ch2[2] = ss1[2];
            ch2[3] = ss1[3];
            ch2[4] = ss1[4];
            ch2[5] = ss1[0];
            ch2[6] = ss1[6];
            ch2[7] = ss1[7];
            ch2[8] = ss1[8];
            ch2[9] = ss1[9];
            ch2[10] = ss1[5];
            ss1 = "";
            for (int i = 1; i <= 10; i++)
            {
                ss1 += ch2[i];
            }
            s3.Text = turn(ss1);
            string sss1 = ss1;
            ss1 = "";
            //4
            ch3[1] = ch2[6];
            ch3[2] = ch2[3];
            ch3[3] = ch2[7];
            ch3[4] = ch2[4];
            ch3[5] = ch2[8];
            ch3[6] = ch2[5];
            ch3[7] = ch2[10];
            ch3[8] = ch2[9];
            for (int i = 1; i <= 8; i++)
            {
                ss1 += ch3[i];
            }
            s4.Text = turn(ss1);
            //3to5
            ch2[1] = sss1[2];
            ch2[2] = sss1[3];
            ch2[3] = sss1[4];
            ch2[4] = sss1[0];
            ch2[5] = sss1[1];
            ch2[6] = sss1[7];
            ch2[7] = sss1[8];
            ch2[8] = sss1[9];
            ch2[9] = sss1[5];
            ch2[10] = sss1[6];
            ss1 = "";
            for (int i = 1; i <= 10; i++)
            {
                ss1 += ch2[i];
            }
            s5.Text = turn(ss1);
            //6
            ch2[1] = ss1[5];
            ch2[2] = ss1[2];
            ch2[3] = ss1[6];
            ch2[4] = ss1[3];
            ch2[5] = ss1[7];
            ch2[6] = ss1[4];
            ch2[7] = ss1[9];
            ch2[8] = ss1[8];
            ss1 = "";
            for (int i = 1; i <= 8; i++)
            {
                ss1 += ch2[i];
            }
            s6.Text = turn(ss1);
        }
    }
}
