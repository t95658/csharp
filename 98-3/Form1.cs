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

namespace _98_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }
        int maxx = 0;
        Bitmap bmp;
        private void button1_Click(object sender, EventArgs e)
        {
            
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                BinaryReader read=new BinaryReader(File.Open(openFileDialog1.FileName,FileMode.Open));
                Byte[] riff=read.ReadBytes(4);
                string riffs = "";
                for(int i=0;i<4;i++) riffs+=(char)riff[i];
                read.ReadBytes(4);
                Byte[] WAVEfmt=read.ReadBytes(7);
                string WAVEfmts = "";
                for (int i = 0; i < 7; i++) WAVEfmts += (char)WAVEfmt[i];
                read.ReadBytes(5);
                string PCMS = "";
                Byte[] PCM=read.ReadBytes(2);
                for (int i = 0; i < 2; i++) PCMS += PCM[i];//10
                string singles = "";
                Byte[] single=read.ReadBytes(2);
                for(int i=0; i < 2; i++) singles+=single[i];//10
                Byte[] SR=read.ReadBytes(4);
                string six = "";
                for(int i=SR.Length-1;i>=0;i--) six+=Convert.ToString(SR[i],16);
                int ten1=Convert.ToInt32(six,16);
                read.ReadBytes(6);
                Byte[] BPS=read.ReadBytes(2);
                string BPSS = "";
                for(int i=0;i<2;i++) BPSS += BPS[i];//80
                Byte[] data=read.ReadBytes(4);
                string datas = "";
                for(int i=0;i<4;i++) datas+=(char)data[i];
                Byte[] NS=read.ReadBytes(4);
                six = "";
                for (int i = NS.Length - 1; i >= 0; i--) six +=Convert.ToString(NS[i],16);
                int ten2=Convert.ToInt32(six,16);
                double time=ten2/(double)ten1;
                if(riffs!="RIFF"||WAVEfmts!="WAVEfmt"||PCMS!="10"||singles!="10"||BPSS!="80"||datas!="data")
                {
                    MessageBox.Show("輸入的檔案名稱不是RIFF、WAVEfmt、PCM格式、8位元及單聲道");
                    return;
                }
                label5.Text=time.ToString("0.#######");
                List<byte> drawsix= new List<byte>();
                while(true)
                {
                    try
                    {
                          byte b=read.ReadByte();
                    
                          drawsix.Add(b);
                    }
                    catch(Exception ex)
                    {
                        break;
                    }
                }
                maxx=drawsix.Count;
                bmp = new Bitmap(maxx, 300);//150
                Graphics g = Graphics.FromImage(bmp);
                pictureBox1.Image = bmp;
                double sy = 150 / 127.0;
                for(int i=0;i<maxx;i++)
                {
                    double top = 0, down = 0;
                    double d = Math.Abs(drawsix[i] - 128);
                    top = 128 + d;
                    down = 128 - d;
                    g.DrawLine(Pens.Green, i, (float)top, i, (float)down);
                }
                hScrollBar1.Maximum = maxx-500;
            }
            
        }
        int first = 1;
        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if(bmp != null)
            {
                int v = hScrollBar1.Value;
                //pictureBox1.CreateGraphics().DrawImage(bmp,-v,0);
                pictureBox1.Invalidate();
                label3.Text = "" + (double)v / maxx * double.Parse(label5.Text);
            }
            
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (bmp != null)
            {
                pictureBox1.Image = null;
                int v = hScrollBar1.Value;
                e.Graphics.DrawImage(bmp,-v,0); // 繪製可見區域
            }
        }

        private void hScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            /*if (bmp != null)
            {
                int v = hScrollBar1.Value;
                pictureBox1.Invalidate();
                label3.Text = "" + v / maxx * double.Parse(label5.Text);
                
            }*/
        }
    }
}
