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

namespace _10504
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
            label2.Text = "";
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //MessageBox.Show(openFileDialog1.FileName);
                FileInfo f= new FileInfo(openFileDialog1.FileName);
                StreamReader read=f.OpenText();
                string s=read.ReadToEnd();
                label1.Text = s;
                int num = 0;//?數
                for(int i=s.Length-1;i>=0;i--) {
                    if (s[i] == '?')
                    {
                        num++;
                    }
                    else break;
                }
                s=s.Substring(0,s.Length-num);
                string[] arrays=s.Split(new string[]{" "}, StringSplitOptions.RemoveEmptyEntries);
                //MessageBox.Show("" + arrays[0]);
                
                for(int i=0; i<arrays.Length; i++)
                {
                    if(num==5)//in 1
                    {
                        if (i + 1 < arrays.Length && arrays[i+1].Contains("：")) {
                            label2.Text += arrays[i]+"\n";
                            continue;
                        }
                        label2.Text += arrays[i]+" ";
                    }
                    if(num==0)//in 2
                    {
                        string[] arrays2 = arrays[i].Split('/');
                        for(int j=0;j< arrays2.Length; j++)
                        {
                            for(int k = 0; k < arrays2[j].Length;k++)
                            {
                                if (arrays2[j][k] == '(')
                                    label2.Text += "\n";
                                else if (arrays2[j][k] == ')') continue;
                                else label2.Text += arrays2[j][k];
                            }
                            label2.Text += "\n";
                        }
                    }
                    if(num==4)//in 3
                    {
                        if (i + 1 < arrays.Length && arrays[i + 1].Contains("："))
                        {
                            label2.Text += arrays[i] + "\n";
                            continue;
                        }
                        label2.Text += arrays[i] + " ";
                    }
                    if(num==3)//in 4
                    {
                        if (arrays[i].Contains("：："))
                        {
                            int tr = 0;
                            for(int j=0;j< arrays[i].Length;j++)
                            {
                                if (tr == 0 || arrays[i][j]!='：')
                                    label2.Text+= arrays[i][j];
                                if (arrays[i][j]=='：')
                                {
                                    tr = 1;
                                    //label2.Text += arrays[i][j];
                                }
                                
                            }
                            label2.Text += "\n";
                            continue;
                        }
                        else if (i + 1 < arrays.Length && arrays[i + 1].Contains("："))
                        {
                            label2.Text += arrays[i] + "\n";
                            continue;
                        }
                        label2.Text += arrays[i] + " ";
                    }
                }
            }
        }
    }
}
