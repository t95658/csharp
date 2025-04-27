using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 北軟9701
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n=int.Parse(textBox1.Text);
            textBox2.Text = "";
            for(int i=2;i<=n;i++)
            {
                int tr = 1;
                for(int j=2;j<i;j++)
                {
                    if (i % j == 0) tr = 0;
                }
                if (tr == 1) textBox2.Text += i+"\r\n";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (textBox1.Text == "-") return;
                int n = int.Parse(textBox1.Text);
                if (n < 1 || n > 1000)
                {
                    MessageBox.Show("輸入錯誤，請重新輸入");
                    textBox1.Text = "";
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int a1=int.Parse(textBox3.Text),a2=int.Parse(textBox4.Text);
            int a1ans=a1,a2ans=a2;
            string ss = "---------------------------------------------";
            textBox5.Text = "";
            textBox5.Text += "\t" + a1 + "\t" + a2 + "\r\n"+ss+"\r\n";
            int all = 1;
            while(true)
            {
                int minn=Math.Min(a1,a2);
                int tr = 0,loc=0;
                for(int i=2;i<=minn;i++)
                {
                    if(a1%i==0&&a2%i==0)
                    {
                        loc = i;
                        a1 /= i; a2/=i;
                        tr = 1;
                        break;
                    }
                }
                if (tr == 1)
                {
                    textBox5.Text += loc + "\t" + a1 + "\t" + a2 + "\r\n" + ss + "\r\n";
                    all *= loc;
                }
                else break;
            }
            label6.Text = "" + all;
            label7.Text=""+all*(a1ans/all)*(a2ans/all);
        }
    }
}
