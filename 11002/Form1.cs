using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _11002
{
    public partial class Form1 : Form
    {
        int tr = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            label2.Text = "";
            label3.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //int n=Convert.ToInt32(textBox1.Text);
            string s=textBox1.Text;
            int num1=0, num2=0;//eng,num
            for(int i=0;i<s.Length;i++)
            {
                if (s[i] >= 'a' && s[i]<='z')
                {
                    num1++;
                }
                if (s[i] >= '0' && s[i] <= '9') num2++;
            }
            if (s.Length >= 12 && num1 != 0 && num2 != 0 && num1 > num2) tr = 2; else tr=1;
            label2.Text = num1 + "," + num2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tr == 1)
                label3.Text = "weak";
            if (tr == 2) label3.Text = "strong";
        }
    }
}
