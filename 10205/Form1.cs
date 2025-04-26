using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10205
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random rd= new Random();
            int pre=rd.Next(1,3);
            int a=rd.Next(1,10);
            int b=rd.Next(1,10);
            int all1 = pre * 10 + a;
            int all2 = pre * 10 + b;
            textBox1.Text = "" + all1;
            textBox2.Text = "" + all2;
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int m=Convert.ToInt32(textBox1.Text);
            int n=Convert.ToInt32(textBox2.Text);
            if(m*n==Convert.ToInt32(textBox3.Text))
            {
                label7.Text = "very good";
                label5.Text = "";
                label6.Text = "";
            }
            else
            {
                label7.Text = "";
                label5.Text = "is wrong";
                string sm=textBox1.Text;
                string sn=textBox2.Text;
                int ans = 0;
                int a = sn[1]-'0';
                int b = a + m;
                label6.Text = "";
                label6.Text += "(1)" + m + "+" + a + "="+b+"\n";
                int pre=m/10;
                int sum = pre * 10;
                int sum2 = sum * b;
                label6.Text += "(2)" + b + "X" + sum + "=" + sum2 + "\n";
                int aa = m % 10;
                int bb=n % 10;
                int cc = aa * bb;
                label6.Text += "(3)" + aa + "X" +bb + "=" + cc+ "\n";
                label6.Text += "(4)" + sum2 + "+" + cc + "=" + (sum2+cc) + "\n";
            }          
        }
    }
}
