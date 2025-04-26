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

namespace _10406
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileInfo file = new FileInfo(openFileDialog1.FileName);
                StreamReader read=file.OpenText();
                richTextBox1.Text = read.ReadToEnd();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string txt=richTextBox1.Text;
            string search=textBox1.Text;
            int index = 0, count = 0; ;
            if (search == "") MessageBox.Show("請輸入");
            else
            {
                //清空
                richTextBox1.Select(0, txt.Length);
                richTextBox1.SelectionBackColor = Color.White;
                while(index<=txt.LastIndexOf(search))
                {
                    //字首
                    index=txt.IndexOf(search,index);
                    richTextBox1.Select(index, search.Length);
                    richTextBox1.SelectionBackColor=Color.Yellow;
                    count++;
                    index += search.Length;
                }
                num.Text=count.ToString();
            }
            
        }
    }
}
