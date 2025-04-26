using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2022_01
{
    public partial class Form1 : Form
    {
        long[] dp=new long[100];
        public Form1()
        {
            InitializeComponent();
                      
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dp[1] = 1;
            dp[2] = 1;
            for (int i = 3; i < 100; i++) dp[i] = dp[i - 1] + dp[i - 2];
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(textBox1.Text);
            label3.Text = dp[n+1].ToString();
            label4.Text = dp[n].ToString();
            label5.Text = dp[n].ToString();
            label6.Text = dp[n - 1].ToString();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
