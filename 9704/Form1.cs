using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _9704
{
    public partial class Form1 : Form
    {
        string[] seed = new string[] { "64","73","66","64","3b","6b","66","6f","41","2c","2e","69","79","65","77","72","6b","6c","64","4a","4b","44","48","53","55","42"};
        public Form1()
        {
            InitializeComponent();
            /*int a = Convert.ToInt32("41", 16);
            int b = Convert.ToInt32("2", 16);
            int c = a ^ 'A';
            string s=Convert.ToString(c,16);
            MessageBox.Show(""+s);*/
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ans = "";
            string p=textBox1.Text;
            int s = int.Parse(textBox2.Text);
            string ss=Convert.ToString(s,16);
            if (ss[0] >= 'a' && ss[0] <= 'z') ss = "" +(char) (ss[0] - 32);
            ans += "0" + ss;
            textBox3.Text = "";
            
            int i = s;
            for(int j=0;j<p.Length;j++)
            {
                string six = seed[i];
                char c = p[j];
                i++;
                int ten=Convert.ToInt32(six,16);
                int anss = ten ^ (int)c;
                six=Convert.ToString(anss,16);
                six = six.PadLeft(2, '0');
                six=six.ToUpper();
                ans+= six;
            }
            textBox3.Text += ans;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = textBox3.Text;
            string ans = "";
            int i=int.Parse(textBox2.Text);
            int step = 0;
            string test = "";
            for (int j = 2; j < s.Length; j++)
            {
                test += s[j];
                if(test.Length==2)
                {
                    test=test.ToLower();
                    int a =Convert.ToInt32( seed[i],16),b=Convert.ToInt32(test,16),c=0;
                    c = a ^ b;
                    test = "";
                    ans += (char)c;
                    i++;
                }
            }
            label5.Text = "" + ans;
        }
    }
}
