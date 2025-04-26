using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _9703
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int st=-1, end;
            string s=textBox1.Text;
            end = s.Length - 1;
            for (int i = 0; i < s.Length; i++)
            {
                if (st == -1 && s[i] <= '9' && s[i] >= '0') st = i;
                if (s[i]=='.') end = i-1;
            }
            int num;
            string snum="";
            for (int i = st; i <= end; i++)
            {
                snum += s[i];
            }
            num=Convert.ToInt32(snum);
            string two;
            two=Convert.ToString(num,2);
            if (two.Length > 15)
            {
                label1.Text = "overflow";
            }
            else
            {
                string ans = "";
                if (st == 0) ans += '0';
                else ans += '1';
                int tmp = 0;
                for(int i=15;i>=1;i--)
                {
                    if(i>two.Length) ans += "0";
                    else
                    {
                        ans += two[tmp];
                        tmp++;
                    }
                }
                ans += '.';
                //小數部分
                int tr = 0;
                for(int i=0;i<s.Length;i++)
                {
                    if (s[i] != '.'&&tr==0) continue;
                    tr = 1;
                    if (s[i]=='.')
                        st = i + 1;
                    end = i;
                }
                string sdouble = "0.";
                for(int i=st; i<=end; i++) sdouble += s[i];
                double dou=Convert.ToDouble(sdouble);
                string anss = "";
                tr = 1;
                for(int i=1;i<=8;i++)
                {
                    double d=1.0/Math.Pow(2,i);
                    if(dou>=d)
                    {
                        dou -= d;
                        anss += '1';
                        if (i == 8 && dou != 0) tr = 0;
                    }
                    else anss+= "0";
                }
                ans += anss;
                if (tr == 1)
                    label1.Text = ans;
                else label1.Text = "overflow";
            }
            
        }
    }
}
