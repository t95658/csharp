using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 北軟9602
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "";
            label6.Text = "";
            label7.Text = "";
            label8.Text = "";
            label9.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "10 30 50 60 80 100";
            label6.Text = ""+55;
            label7.Text = "" + 100;
            label8.Text = "" + 10;
            label9.Text = "" + 29.8607881119482;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            label6.Text = "" ;
            label7.Text = "" ;
            label8.Text = "";
            label9.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string test=textBox1.Text;
            int tr = 1;
            for(int i=0;i<test.Length;i++)
            {
                if (test[i]==' ' || (test[i] <= '9' && test[i]>='0')) continue;
                tr = 0;
            }
            string[] s=test.Split(' ');
            int all = 0,n=s.Length,maxx=0,minn=int.MaxValue;
            double last = 0;
            for(int i=0;i<s.Length;i++)
            {
                int a=int.Parse(s[i]);
                all += a;
                if (a > 100) tr = 0;
                maxx = Math.Max(maxx, a);
                minn = Math.Min(minn, a);
                double mx = 0;
                for(int j=0;j<s.Length;j++)
                {
                    int b=int.Parse(s[j]);
                    mx += b;
                }
                mx /= n;
                last += (a-mx) * (a-mx);
            }
            last /= n;
            last=Math.Sqrt(last);
            if (tr == 0) MessageBox.Show("輸入有問題，請重新輸入");
            else
            {
                double a1 = (double)all / n;
                label6.Text = "" + a1;
                label7.Text = "" + maxx;
                label8.Text = "" + minn;
                label9.Text = "" + last;
            }
        }
    }
}
