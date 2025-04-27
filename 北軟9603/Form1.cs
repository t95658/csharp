using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 北軟9603
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "KLLN") textBox2.Text = "KLLN不是正確密碼文字";
            if (textBox1.Text == "LOML") textBox2.Text = "LOML不是正確密碼文字";
            if (textBox1.Text == "MLLO") textBox2.Text = "MLLO是正確密碼文字";
            if (textBox1.Text == "NMKO") textBox2.Text = "NMKO不是正確密碼文字";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "NMKO") textBox4.Text = "本輸入密碼無法滿足第6條件";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox5.Text=="XLKO"&&textBox6.Text=="OMXK")
            {
                textBox7.Text = "LLKO";
                textBox8.Text = "OMNK";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox9.Text = "2種";
            textBox10.Text = "LLL、NNN";
        }
    }
}
