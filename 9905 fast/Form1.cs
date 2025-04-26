using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _9905_fast
{
    public partial class Form1 : Form
    {
        FileInfo f;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f=new FileInfo("C:\\Users\\USER\\Desktop\\"+textBox1.Text);
            StreamReader read = f.OpenText();
            label5.Text = read.ReadToEnd();
            read.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string search=textBox2.Text;
            string s=label5.Text;
            s=s.Replace("\r\n", " ");
            int a=s.IndexOf(search)+1;
            if (a == 0) label4.Text = "找不到";
            else label4.Text = ""+a;
        }
    }
}
