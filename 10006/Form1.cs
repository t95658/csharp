using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10006
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rd = new Random();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox1.Text = "" + rd.Next(16, 53);
            textBox3.Text = "" + rd.Next(1, 9)+"B";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Random rd=new Random();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox5.Text = "" + rd.Next(1, 9) + "B";
            string[] ran = new string[] { "KB", "MB", "GB", "TB" };
            int tmp=rd.Next(0,4);
            if (tmp == 0)
                textBox6.Text = "" + rd.Next(512, 1024) + ran[tmp];
            else if (tmp == 3)
                textBox6.Text = "" + rd.Next(1, 32769) + ran[tmp];
            else textBox6.Text =""+rd.Next(1,1024)+ran[tmp];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int a=Convert.ToInt32(textBox1.Text);
            string s=textBox3.Text;
            s=s.Substring(0, s.Length-1);
            int b=Convert.ToInt32(s);
            long all =(long) Math.Pow(2, a) * b;
            string[] B = new string[] { "KB", "MB", "GB", "TB" };
            int tmp = 0;
            all /= 1024;
            while(true)
            {
                if (all / 1024 == 0||tmp==3) break;
                all /= 1024;
                tmp++;
            }
            textBox4.Text=""+all+B[tmp];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string s = textBox6.Text;
            char c = s[s.Length-2];
            string s2 = textBox5.Text;
            s2=s2.Substring(0, s2.Length-1);
            int a=Convert.ToInt32(s2);
            s=s.Substring(0,s.Length-2);
            long b=Convert.ToInt32(s);
            if(c=='K') b=b*(int)Math.Pow(2,10);
            if (c == 'M') b *= (long)Math.Pow(2, 20);
            if (c == 'G') b *= (long)Math.Pow(2, 30);
            if (c == 'T') b *= (long)Math.Pow(2, 40);
            long all = b / a;
            int num = 0;
            while(true)
            {
                num++;
                long al = (long)Math.Pow(2, num);
                if (al >= all) break;
            }
            textBox2.Text = "" + num;
        }
    }
}
