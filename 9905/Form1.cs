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

namespace _9905
{
    public partial class Form1 : Form
    {
        FileInfo f;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f=new FileInfo("C:\\Users\\USER\\Desktop\\"+textBox1.Text);
            StreamReader read=f.OpenText();
            label3.Text = read.ReadToEnd();
            string s=label3.Text;
            //MessageBox.Show(""+s[6]);
            read.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int d=0;
            string s=label3.Text;
            string search=textBox2.Text;
            int tmp = 0;
            int tr = 0;
            int many = 0;
            //MessageBox.Show(""+s.Length);
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '\n')
                {
                    many++;
                    continue;
                }
                int tr2 = 0;
                tmp = 0;
                if (s[i] == search[tmp] || (search[tmp]==' ' && s[i]=='\r'))
                {
                    d = i + 1;
                    tmp++;
                    for(int j=i+1;j<i+search.Length;j++)
                    {
                        if(tmp>=5)
                        {
                            tmp = tmp;
                        }
                        if (j >= s.Length) break;
                        if (s[j] == '\n')
                        {
                            i++;
                            continue;
                        }
                        if (s[j] == search[tmp] || (search[tmp] == ' ' && s[j] == '\r')) tmp++;
                    }
                    if (tmp == search.Length) tr2 = 1;
                }
                if(tr2==1)
                {
                    label5.Text =""+ (d-many);
                    break;
                }
            }
        }
    }
}
