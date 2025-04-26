using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10505
{
    
    public partial class Form1 : Form
    {
        TextBox[] text=new TextBox[4];
        TextBox[] appear = new TextBox[4];
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int[] num=new int[26];
            int[] num2 = new int[1000];
            for (int i=0;i<26;i++)
            {
                num[i] = i;
            }
            for(int i=1;i<1000;i++)
            {
                num2[i] = i;
            }
            for (int i = 0; i < 26; i++)
            {
                int rd = rnd.Next(0, 26);
                int chg = num[i];
                num[i]=rd;
                num[rd]=chg;
            }
            for(int i = 1;i<1000;i++)
            {
                int rd = rnd.Next(1, 1000);
                int chg = num2[i];
                num2[i] = rd;
                num2[rd] = chg;
            }
            for(int i=0;i<4;i++)
            {
                text[i].Text = Convert.ToChar( num[i]+97).ToString();
                appear[i].Text = num2[i+1].ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for(int i = 0;i<4;i++)
            {
                text[i] = new TextBox();
                appear[i] = new TextBox();
            }
            for(int i=0;i<4;i++)
            {
                text[i] = (TextBox)Controls["textBox" + (i+1)];
            }
            for (int i = 5; i <=8 ; i++)
            {
                appear[i-5] = (TextBox)Controls["textBox" + i ];
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label7.Text = "";
            label8.Text = "";
            label9.Text = "";
            int ori=0;
            //int per = 0;//%
            //int huff = 0;
            int a= Convert.ToInt32(textBox5.Text), b= Convert.ToInt32(textBox6.Text), c= Convert.ToInt32(textBox7.Text), d= Convert.ToInt32(textBox8.Text);
            ori=2*(Convert.ToInt32(textBox5.Text)+ Convert.ToInt32(textBox6.Text) + Convert.ToInt32(textBox7.Text) +Convert.ToInt32(textBox8.Text));
            label7.Text=""+ori;
            List<int> lis = new List<int>();
            lis.Add(a);
            lis.Add(b);
            lis.Add(c);
            lis.Add(d);
            int all = 0;
            while(true)
            {
                if (lis.Count <= 1) break;
                lis.Sort();
                int min1 = lis[0], min2 = lis[1];
                lis.RemoveRange(0, 2);
                int total=min1 + min2;
                all += total;
                lis.Insert(0, total);
            }
            label8.Text = "" + all;
            double per=(double)ori/(double)all;
            label9.Text=per.ToString("0.####");
        }
    }
}
