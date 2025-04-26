using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10403
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            Random rd = new Random();
            textBox1.Text += rd.Next(0, 2);
            for(int i = 0;i<8;i++)
            {
                textBox2.Text += rd.Next(0, 2);
            }
            for(int i = 0;i<23; i++)
            {
                textBox3.Text += rd.Next(0, 2);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s1 = textBox1.Text,s2=textBox2.Text,s3=textBox3.Text;
            if(s1=="0")
            {
                int n1=Convert.ToInt32(s2,2)-127;
                double item=Math.Pow(2,n1);
                //MessageBox.Show("" + item);
                double point=0;
                for(int i=0;i<s3.Length;i++)
                {
                    if (s3[i] == '1') point += 1.0 / Math.Pow(2, i + 1);
                }
                double total=item+item*point;
                label3.Text = total.ToString();
            }
            else
            {
                int n1 = Convert.ToInt32(s2, 2) - 127;
                double item = Math.Pow(2, n1);
                //MessageBox.Show("" + item);
                double point = 0;
                for (int i = 0; i < s3.Length; i++)
                {
                    if (s3[i] == '1') point += 1.0 / Math.Pow(2, i + 1);
                }
                double total = -item - item * point;
                label3.Text = total.ToString();
            }
        }
    }
}
