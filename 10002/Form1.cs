using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10002
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string num = "";
            string s=textBox1.Text;
            int[] ip = new int[10];
            int tmp = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '.' || s[i] == '/')
                {
                    ip[tmp]=Convert.ToInt32(num);
                    tmp++;
                    num = "";
                    continue;
                }
                num += s[i];
            }
            ip[tmp]=Convert.ToInt32(num);
            int a=32-ip[tmp];
            a = (int)Math.Pow(2,a) - 2;
            label7.Text = ""+a;
            int t = ip[tmp];
            //網路位址
            string two = "";
            for(int i=0;i<tmp;i++)
            {
                string t2=Convert.ToString(ip[i],2);
                t2=t2.PadLeft(8,'0');
                two += t2;
            }
            two=two.Substring(0,t);
            for(int i=t+1;i<=32;i++) two += "0";
            int[] net = new int[10];
            int tmp2 = 0;
            net[0]=Convert.ToInt32(two.Substring(0,8),2);
            net[1] = Convert.ToInt32(two.Substring(8, 8), 2);
            net[2] = Convert.ToInt32(two.Substring(16, 8), 2);
            net[3]=Convert.ToInt32(two.Substring(24, 8), 2);
            label3.Text = "";
            for (int i = 0; i < 3; i++) label3.Text += net[i] + ".";
            label3.Text += net[3];
            //廣播
            label5.Text = "";
            int m = 32 - t;
            string bo = "";
            for(int i=0;i<m;i++)
            {
                bo+= "1";
            }
            bo = bo.PadLeft(32, '0');
            int[] gunbo = new int[10];
            gunbo[0] = Convert.ToInt32(bo.Substring(0, 8), 2);
            gunbo[1] = Convert.ToInt32(bo.Substring(8, 8), 2);
            gunbo[2] = Convert.ToInt32(bo.Substring(16, 8), 2);
            gunbo[3] = Convert.ToInt32(bo.Substring(24, 8), 2);
            for (int i = 0; i < 3; i++) label5.Text += (net[i] + gunbo[i]) + ".";
            label5.Text += (net[3] + gunbo[3]);
        }
    }
}
