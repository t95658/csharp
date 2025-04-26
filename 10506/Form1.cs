using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10506
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
            if(openFileDialog1.ShowDialog()==DialogResult.OK) 
            {
                pictureBox1.Image=Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bmp=new Bitmap(pictureBox1.Image);
            for(int i=0; i<bmp.Height; i++)
            {
                for(int j=0; j<bmp.Width; j++)
                {
                    Color color=bmp.GetPixel(j, i);
                    string sr=Convert.ToString(color.R, 2),sg=Convert.ToString(color.G, 2),sb=Convert.ToString(color.B,2);
                    int r,g,b;
                    if (sr[sr.Length - 1] == '1') r = 16;
                    else r = 235;
                    if (sg[sg.Length - 1] == '1') g = 16;
                    else g = 235;
                    if (sb[sb.Length - 1] == '1') b = 16;
                    else b = 235;
                    Color color1= Color.FromArgb(r,g,b);
                    bmp.SetPixel(j, i, color1);
                }
            }
            pictureBox1.Image = bmp;
        }
    }
}
