using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10501
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            int n=Convert.ToInt32(textBox2.Text);
            int ten=Convert.ToInt32(textBox1.Text);
            string s="";
            //正
            
                while(ten!=0)
                {
                    if(ten>0)
                    {
                        int num = ten % n;
                        if (num == 10) s += "A";
                        else if (num == 11) s += "B";
                        else if (num == 12) s += "C";
                        else if (num == 13) s += "D";
                        else if (num == 14) s += "E";
                        else if (num == 15) s += "F";
                        else if (num == 16) s += "G";
                        else if (num == 17) s += "H";
                        else if (num == 18) s += "I";
                        else if (num == 19) s += "J";
                        else if (num == 20) s += "K";
                        else s +=num ;//最後要倒過來
                        ten=ten /= n;
                    }
                    else if(ten<0) 
                    {

                        if(ten%n==0)
                        {
                            s += "0";
                            ten = ten /= n;
                        }
                        else {
                        int newten = ten / n + 1;
                        int num = ten - (n * newten);//餘數
                        if (num == 10) s += "A";
                        else if (num == 11) s += "B";
                        else if (num == 12) s += "C";
                        else if (num == 13) s += "D";
                        else if (num == 14) s += "E";
                        else if (num == 15) s += "F";
                        else if (num == 16) s += "G";
                        else if (num == 17) s += "H";
                        else if (num == 18) s += "I";
                        else if (num == 19) s += "J";
                        else if (num == 20) s += "K";
                        else s += num;//最後要倒過來
                        ten=newten;
                        }
                    }
                }
            
            
            for(int i=s.Length-1; i>=0; i--)
            {
                textBox3.Text += s[i];
            }
        }
    }
}
