using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 北軟9802
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string file = textBox2.Text;
            string oput = textBox3.Text;
            Bitmap bmp=new Bitmap(Image.FromFile(file));
            int test = 0,tmp=64;
            int len=textBox1.Text.Length;
            string twolen = Convert.ToString(len, 2);
            string value = textBox1.Text;
            string twovalue = "";
            //twovalue要從最後面
            for(int i=len-1; i>=0; i--)
            {
                int a = value[i];
                twovalue = Convert.ToString(a, 2).PadLeft(8,'0')+twovalue;
            }
            int br = 0;
            for(int i=0;i<bmp.Height;i++)
            {
                if (br == 1) break;
                for (int j = 0; j < bmp.Width; j++) {
                    test++;
                    if(test<=21) continue;
                    Color c=bmp.GetPixel(j,i);
                    int B = c.B;int G = c.G;int R = c.R;
                    //64B開始
                    if(tmp<=95)
                    {                    
                        string two=Convert.ToString(B, 2);
                        if(tmp%2==0)
                        {
                            two=two.Substring(0,two.Length-1)+"0";
                        }
                        else two = two.Substring(0, two.Length - 1) + "1";
                        B=Convert.ToInt32(two, 2);
                        tmp++;
                        two=Convert.ToString(G, 2);
                        if (tmp % 2 == 0)
                        {
                            two = two.Substring(0, two.Length - 1) + "0";
                        }
                        else two = two.Substring(0, two.Length - 1) + "1";
                        G=Convert.ToInt32(two, 2);
                        tmp++;
                        if(tmp<=95)
                        {
                            two = Convert.ToString(R, 2);
                            if (tmp % 2 == 0)
                            {
                                two = two.Substring(0, two.Length - 1) + "0";
                            }
                            else two = two.Substring(0, two.Length - 1) + "1";
                            R=Convert.ToInt32(two, 2);
                        }
                        else
                        {
                            //96
                            if (twolen[twolen.Length-1]=='0') two = two.Substring(0, two.Length - 1) + "0";
                            else two = two.Substring(0, two.Length - 1) + "1";
                            twolen=twolen.Substring(0,twolen.Length-1);
                            R = Convert.ToInt32(two, 2);
                        }
                        tmp++;
                        Color cc = Color.FromArgb(R,G,B);
                        bmp.SetPixel(j, i, cc);
                        continue;
                    }
                    if(tmp<=111)
                    {
                        string two=Convert.ToString(B, 2);
                        string low = "";
                        if (twolen == "") low = "0";
                        else if (twolen[twolen.Length - 1] == '0') low = "0";
                        else low = "1";
                        if (twolen != "")
                        {
                            twolen = twolen.Substring(0, twolen.Length - 1);
                        }
                        two = two.Substring(0, two.Length - 1) + low;
                        B = Convert.ToInt32(two, 2);
                        two=Convert.ToString(G, 2);
                        if (twolen == "") low = "0";
                        else if (twolen[twolen.Length - 1] == '0') low = "0";
                        else low = "1";
                        if (twolen != "")
                        {
                            twolen = twolen.Substring(0, twolen.Length - 1);
                        }
                        two = two.Substring(0, two.Length - 1) + low;
                        G= Convert.ToInt32(two, 2);
                        two = Convert.ToString(R, 2);
                        if (twolen == "") low = "0";
                        else if (twolen[twolen.Length - 1] == '0') low = "0";
                        else low = "1";
                        if (twolen != "")
                        {
                            twolen = twolen.Substring(0, twolen.Length - 1);
                        }
                        two = two.Substring(0, two.Length - 1) + low;
                        R = Convert.ToInt32(two, 2);
                        Color cc=Color.FromArgb(R, G, B);
                        bmp.SetPixel(j,i, cc);
                        tmp+=3;
                        continue;
                    }
                    string tw=Convert.ToString(B, 2);
                    if (twovalue[twovalue.Length-1]=='0') tw=tw.Substring(0, tw.Length - 1)+"0";
                    else tw = tw.Substring(0, tw.Length - 1) + "1";
                    twovalue=twovalue.Substring(0,twovalue.Length - 1);
                    B = Convert.ToInt32(tw, 2);
                    Color ccv = Color.FromArgb(R, G, B);
                    if (twovalue == "")
                    {
                        br = 1;
                        bmp.SetPixel(j, i, ccv);
                        break;
                    }
                    tw = Convert.ToString(G, 2);
                    if (twovalue[twovalue.Length - 1] == '0') tw = tw.Substring(0, tw.Length - 1) + "0";
                    else tw = tw.Substring(0, tw.Length - 1) + "1";
                    twovalue = twovalue.Substring(0, twovalue.Length - 1);
                    G = Convert.ToInt32(tw, 2);
                    ccv = Color.FromArgb(R, G, B);
                    if (twovalue == "")
                    {
                        br = 1;
                        bmp.SetPixel(j, i, ccv);
                        break;
                    }
                    tw = Convert.ToString(R, 2);
                    if (twovalue[twovalue.Length - 1] == '0') tw = tw.Substring(0, tw.Length - 1) + "0";
                    else tw = tw.Substring(0, tw.Length - 1) + "1";
                    twovalue = twovalue.Substring(0, twovalue.Length - 1);
                    R = Convert.ToInt32(tw, 2);
                    ccv = Color.FromArgb(R, G, B);
                    tmp += 3;
                    bmp.SetPixel(j, i, ccv);
                    if (twovalue == "")
                    {
                        br = 1;
                        break;
                    }
                }
            }

            bmp.Save(oput);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string lens = "";
            int len = 0;
            string ans = "";
            int eight = 0;
            string last = "";
            Bitmap bmp =new Bitmap( Image.FromFile(textBox3.Text));
            int test = 0,tmp=64,tr=1;
            int br = 0;
            for (int i = 0; i < bmp.Height; i++)
            {
                if (br == 1) break;
                for (int j = 0; j < bmp.Width; j++)
                {
                    if (tr == 0) break;
                    test++;
                    if (test <= 21) continue;
                    Color c = bmp.GetPixel(j, i);
                    int B = c.B; int G = c.G; int R = c.R;
                    //64B開始
                    string two = "";
                    if (tmp <= 95)
                    {
                        two=Convert.ToString(B, 2);
                        if(tmp%2==0)//0
                        {
                            if (two[two.Length - 1] == '1') tr = 0;
                        }
                        else
                        {
                            if (two[two.Length - 1] == '0') tr = 0;
                        }
                        two = Convert.ToString(G, 2);
                        tmp++;
                        if (tmp % 2 == 0)//0
                        {
                            if (two[two.Length - 1] == '1') tr = 0;
                        }
                        else
                        {
                            if (two[two.Length - 1] == '0') tr = 0;
                        }
                        two = Convert.ToString(R, 2);
                        tmp++;
                        if(tmp<=95)
                        {
                            if (tmp % 2 == 0)//0
                            {
                                if (two[two.Length - 1] == '1') tr = 0;
                            }
                            else
                            {
                                if (two[two.Length - 1] == '0') tr = 0;
                            }
                        }
                        else
                        {
                            lens = two[two.Length - 1] + lens;
                        }
                        tmp++;
                        continue;
                    }
                    if (tmp <= 111)
                    {
                        two = Convert.ToString(B, 2);
                        lens = two[two.Length - 1] + lens;
                        two = Convert.ToString(G, 2);
                        lens = two[two.Length - 1] + lens;
                        two = Convert.ToString(R, 2);
                        lens = two[two.Length - 1] + lens;
                        tmp += 3;
                        continue;
                    }
                    if(tmp==112)
                        len = Convert.ToInt32(lens, 2);
                    two = Convert.ToString(B, 2);
                    last = two[two.Length - 1] + last;
                    if(last.Length==8)
                    {
                        len--;
                        ans =(char)Convert.ToInt32(last, 2)+ans;
                        last = "";
                    }
                    two = Convert.ToString(G, 2);
                    last = two[two.Length - 1] + last;
                    if (last.Length == 8)
                    {
                        len--;
                        ans = (char)Convert.ToInt32(last, 2) + ans;
                        last = "";
                    }
                    two = Convert.ToString(R, 2);
                    last = two[two.Length - 1] + last;
                    if (last.Length == 8)
                    {
                        len--;
                        ans = (char)Convert.ToInt32(last, 2) + ans;
                        last = "";
                    }
                    tmp += 3;
                    if (len == 0)
                    {
                        br = 1;
                        break;
                    }
                }
            }
            if (tr == 0) textBox4.Text = "" + textBox3.Text + "圖檔未被嵌入任何隱藏資訊";
            else
            {
                textBox4.Text = ans;
            }
        }
    }
}
