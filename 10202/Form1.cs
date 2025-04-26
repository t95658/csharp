using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10202
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            double dou=random.NextDouble();
            int a = random.Next(0,10000);
            dou += a;
            textBox1.Text=dou.ToString("0.0#####");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int num;
            double dou;
            string s1=textBox1.Text;
            string s2="",s3="0.";
            int gh = 0;
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i]=='.')
                {
                    gh = 1;
                    continue;
                }
                if (gh == 0) s2 += s1[i];
                else s3+= s1[i];
            }
            num=Convert.ToInt32(s2);
            dou=Convert.ToDouble(s3);
            string ltwo = Convert.ToString(num,2);
            string rtwo = ".";
            int tmp = 1;
            while(true)
            {
                /*double test = 1.0/Math.Pow(2, tmp);
                if (dou==0)
                {
                    //rtwo += "0";
                    break;
                }
                if (dou >= test)
                {
                    dou -= test;
                    rtwo += "1";
                }
                else rtwo += "0";*/
                dou *= 2;
                if(dou >=1)
                {
                    dou -= 1;
                    rtwo += "1";
                }
                else rtwo += "0";
                if (dou == 0) break;
                if (tmp >= 10) break;
                tmp++;
                
            }
            label4.Text = ltwo + rtwo;
            string news="";
            string ss = label4.Text;
            int lastzero = ss.Length;
            for (int i = ss.Length - 1; i >= 0; i--)
            {
                if (ss[i] == '0') lastzero--;
                else break;
            }
            label5.Text=ss.Substring(0,lastzero);
        }
    }
}
