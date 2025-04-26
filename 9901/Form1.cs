using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _9901
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
            Random rnd = new Random();
            textBox1.Text = "";
            textBox2.Text = "";
            int one = 0;
            for(int i=0;i<40;i++)
            {
                int a=rnd.Next(0,2);
                if (a == 1) one++;
                if (one > 4) a = 0;
                textBox1.Text += a;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            string ans = "";
            string s=textBox1.Text;
            int zero = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if(s[i] == '0') zero++;
                else
                {
                    string two=Convert.ToString(zero,2);
                    zero = 0;
                    ans += two + " ";
                }
            }
            if (zero != 0)
            {
                string two = Convert.ToString(zero, 2);
                ans += two + " ";
            }
            textBox2.Text = ans;
            //label4.Text = "" + ans.Length;
            double b=(double)(ans.Length-1)/ (double)s.Length;
            b = b * 100;
            label4.Text =""+ b+"%";
        }
    }
}
