using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 大數乘法
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s1=textBox1.Text;
            string s2=textBox2.Text;
            int[] a1 = new int[1505];
            int[] a2 = new int[1505];
            int idx1 = 0, idx2 = 0;
            for (int i = s1.Length - 1; i >= 0; i--) a1[idx1++] = s1[i] - '0';
            for (int i = s2.Length - 1; i >= 0; i--) a2[idx2++] = s2[i] - '0';
            int[] ans = new int[1505];
            int old = 0;
            for(int i=0;i<idx1;i++)
            {
                for(int j=0;j<idx2;j++)
                {
                    int a = a1[i] * a2[j];
                    ans[i + j] += a % 10+old;
                    while(ans[i + j]>=10)
                    {
                        ans[i + j] -= 10;
                        ans[i + j + 1]++;
                    }
                    old = a / 10;
                }
                ans[i + idx2 ] += old;
                old = 0;
            }
            int s = 0;
            for(int i=1501;i>=0;i--)
            {
                if (ans[i]!=0)
                {
                    s = i;break;
                }
            }
            string anss = "";
            for (int i = s; i >= 0; i--) anss += ans[i];
            textBox3.Text = anss;
        }
    }
}
