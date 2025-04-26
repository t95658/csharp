using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _9401
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<char,List<int>> dic= new Dictionary<char,List<int>>();
            Dictionary<char,int> id= new Dictionary<char,int>();
            dic['a']=new List<int>(); dic['b'] = new List<int>(); dic['c']=new List<int>(); dic['d']=new List<int>(); dic['e'] = new List<int>();
            dic['f']=new List<int>(); dic['g'] = new List<int>(); dic['h']=new List<int>(); dic['j'] = new List<int>(); dic['i'] = new List<int>();
            dic['a'].Add(9); dic['a'].Add(12); dic['a'].Add(33); dic['a'].Add(47); dic['a'].Add(53); dic['a'].Add(67); dic['a'].Add(78); dic['a'].Add(92);
            dic['b'].Add(48); dic['b'].Add(81);
            dic['c'].Add(13); dic['c'].Add(41); dic['c'].Add(62);
            dic['d'].Add(1); dic['d'].Add(3); dic['d'].Add(45); dic['d'].Add(79);
            dic['e'].Add(14); dic['e'].Add(16); dic['e'].Add(24); dic['e'].Add(44); dic['e'].Add(46); dic['e'].Add(55); dic['e'].Add(57); dic['e'].Add(64); dic['e'].Add(74); dic['e'].Add(82); dic['e'].Add(87); dic['e'].Add(98);
            dic['f'].Add(10); dic['f'].Add(31);
            dic['g'].Add(6); dic['g'].Add(25);
            dic['h'].Add(23); dic['h'].Add(39); dic['h'].Add(50); dic['h'].Add(56); dic['h'].Add(65); dic['h'].Add(68);
            dic['i'].Add(32); dic['i'].Add(70); dic['i'].Add(73); dic['i'].Add(83); dic['i'].Add(88); dic['i'].Add(93);
            dic['j'].Add(15);
            string s = textBox1.Text;
            string ans = "";
            for(int i=0;i<s.Length;i++)
            {

                if (!id.TryGetValue(s[i], out int value))
                {
                    id[s[i]] = 0;
                }
                else id[s[i]]++;
                if (id[s[i]] >= dic[s[i]].Count) id[s[i]] = 0;
                ans += dic[s[i]][id[s[i]]].ToString().PadLeft(2,'0')+" ";
            }
            textBox2.Text = ans;
        }
    }
}
