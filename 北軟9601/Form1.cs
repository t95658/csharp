using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
namespace 北軟9601
{
    public partial class Form1 : Form
    {
        public Form1()
        {           
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id=textBox1.Text;
            string nb=textBox3.Text;
            string date = textBox2.Text;
            string s1 = "";
            string ans = "";
            string two = "";
            for (int i = 2; i < textBox3.Text.Length; i++) s1 += nb[i];
            int a=int.Parse(s1);
            two=Convert.ToString(a,2);
            ans += two.PadLeft(27, '0');
            s1 = "";
            //學歷
            int point=comboBox2.SelectedIndex;
            two=Convert.ToString(point,2);
            ans+= two.PadLeft(3,'0');
            point=comboBox1.SelectedIndex;
            ans+= point;
            //7 年分
            for(int i=0;i<4;i++) s1+= date[i];
            int num = int.Parse(s1);
            two=Convert.ToString(num-1900,2);
            ans+= two.PadLeft(7,'0');
            //4 月份
            s1 = "";
            for(int i=4;i<6;i++) s1+= date[i];
            num= int.Parse(s1);
            two = Convert.ToString(num, 2);
            ans += two.PadLeft(4,'0');
            //5 日
            s1 = "";
            for(int i=6;i<8;i++) s1+= date[i];
            num=int.Parse(s1);
            two = Convert.ToString(num, 2);
            ans += two.PadLeft(5, '0');
            //5 A
            num = id[0]-65;
            two= Convert.ToString(num, 2);
            ans += two.PadLeft(5, '0');
            //boy
            if (id[1] == '1') ans += 0;
            else ans += 1;
            s1 = "";
            for (int i=2;i<id.Length;i++)
            {
                s1+= id[i];
            } 
            num=int.Parse(s1);
            two=Convert.ToString(num, 2);
            ans += two.PadLeft(27, '0');
            string six = "";
            for (int i = 0; i < 20; i++)
            {
                string ss = "";
                for(int j=i*4;j<i*4+4;j++)
                {
                    ss += ans[j];
                }
                num = Convert.ToInt32(ss, 2);
                string c=Convert.ToString(num, 16);
                char[] ch =c.ToCharArray();
                if (c[0] <= 'f' && c[0] >= 'a')
                {
                    int asi = ch[0];
                    asi -= 32;
                    ch[0] = (char)asi;
                    c = "";
                    for (int j = 0; j < ch.Length; j++) c += ch[j];
                }
                six += c;
            }
            textBox4.Text = six;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = textBox4.Text;
            string two = "";
            for(int i=0;i<s.Length;i++)
            {
                char c = s[i];
                if(c<='F'&&c>='A')
                {
                    int a = c;
                    a += 32;
                    c=(char)a;
                }
                string cc = ""+c;
                int num = Convert.ToInt32(cc, 16);
                two +=Convert.ToString(num, 2).PadLeft(4,'0');

            }
            //number
            string twoo = "";
            for(int i=0;i<27;i++)
            {
                twoo += two[i];
            }
            int n=Convert.ToInt32(twoo, 2);
            textBox3.Text = "09" + n.ToString().PadLeft(8,'0');
            twoo = "";
            for(int i=27;i<30;i++) { twoo += two[i]; }
            n=Convert.ToInt32(twoo, 2);
            comboBox2.SelectedIndex = n;
            if (two[30] == '1') comboBox1.SelectedIndex = 1;
            else comboBox1.SelectedIndex = 0;
            twoo = "";
            for(int i=31;i<38;i++) twoo+=two[i];
            n = Convert.ToInt32(twoo, 2);
            textBox2.Text = "";
            textBox2.Text += (n+1900);
            twoo = "";
            for(int i=38;i<42;i++) { twoo+=two[i]; }
            n = Convert.ToInt32(twoo, 2);
            textBox2.Text += n.ToString().PadLeft(2, '0');
            twoo = "";
            for (int i = 42; i < 47; i++) { twoo += two[i]; }
            n = Convert.ToInt32(twoo, 2);
            textBox2.Text += n.ToString().PadLeft(2, '0');
            textBox1.Text = "";
            twoo = "";
            for(int i=47;i<52;i++) { twoo += two[i]; }
            n = Convert.ToInt32(twoo, 2)+65;
            textBox1.Text += (char)n;
            if (two[52] == '0') textBox1.Text += "1";
            else textBox1.Text += "2";
            twoo = "";
            for (int i = 53; i < 80; i++) twoo += two[i];
            n = Convert.ToInt32(twoo, 2);
            textBox1.Text += n.ToString().PadLeft(8, '0');
        }
    }
}
