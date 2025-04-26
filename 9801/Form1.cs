using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _9801
{
    public partial class Form1 : Form
    {
        int En = 0;
        Button[] button=new Button[4];
        public Form1()
        {
            InitializeComponent();
            for(int i=0;i<4; i++) { button[i] = new Button(); }
            for (int i = 0; i < 4; i++)
            {
                button[i] = (Button)Controls["button" + (i + 1)];
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button b=(Button)sender;
            if (b.Text == "Ih") b.Text = "Ld";
            else if (b.Text == "Ld") b.Text = "En";
            else if (b.Text == "En") b.Text = "Ih";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string s = "";
            Random rnd = new Random();
            for(int i=1;i<=8;i++)
            {
                s = s + rnd.Next(0, 2);
            }
            textBox1.Text = s;
            s = "";
            for (int i = 1; i <= 8; i++)
            {
                s = s + rnd.Next(0, 2);
            }
            textBox2.Text = s;
            s = "";
            for (int i = 1; i <= 8; i++)
            {
                s = s + rnd.Next(0, 2);
            }
            textBox3.Text = s;
            s = "";
            for (int i = 1; i <= 8; i++)
            {
                s = s + rnd.Next(0, 2);
            }
            textBox4.Text = s;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            En = 0;
            for (int i = 0; i < 4; i++)
            {
                if (button[i].Text == "En")
                    En++;
            }
            if (En != 1) MessageBox.Show("僅有一個En才能執行，請調整");
            else
            {
                string s="";
                if (button[0].Text == "En") s = textBox1.Text;
                if(button[1].Text =="En") s= textBox4.Text;
                if(button[2].Text =="En") s= textBox2.Text;
                if( button[3].Text =="En") s= textBox3.Text;
                if (button[0].Text=="Ld") textBox1.Text=s;
                if (button[1].Text == "Ld") textBox4.Text=s;
                if (button[2].Text == "Ld") textBox2.Text=s;
                if (button[3].Text == "Ld") textBox3.Text=s;
            }
        }
    }
}
