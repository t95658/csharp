using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 北軟9803
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(600, 600);
            Graphics g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;
            //100,20
            //g.FillEllipse(Brushes.White, 10, 10, 20, 20);
            g.DrawEllipse(Pens.Black,90, 10, 20, 20);
            float orix = 0, oriy = 0;
            float x=(float)Math.Cos(Math.PI*(135.0/180.0)), y= (float)Math.Sin(Math.PI * (135.0 / 180.0));
            g.DrawLine(Pens.Black,100,20,100+x*40,20+y*40);
            g.FillEllipse(Brushes.White, 91, 11, 17, 17);
            orix = 100 + x * 40;oriy = 20 + y * 40;
            g.DrawEllipse(Pens.Black,orix-10,oriy-10,20,20);
            g.DrawLine(Pens.Black, orix, oriy, orix + x * 40, oriy + y * 40);
            g.FillEllipse(Brushes.White, orix-10+1, oriy-10+1, 17, 17);
            orix += x * 40; oriy += y * 40;
            g.DrawEllipse(Pens.Black, orix - 10, oriy - 10, 20, 20);
            g.DrawLine(Pens.Black, orix, oriy, orix + x * 40, oriy + y * 40);
            g.FillEllipse(Brushes.White, orix - 10 + 1, oriy - 10 + 1, 17, 17);
            orix += x * 40; oriy += y * 40;
            g.DrawEllipse(Pens.Black, orix - 10, oriy - 10, 20, 20);
            g.FillEllipse(Brushes.White, orix - 10 + 1, oriy - 10 + 1, 17, 17);
            //150,20
            orix = 150;oriy = 20;
            for(int i=0;i<3;i++)
            {
                g.DrawEllipse(Pens.Black, orix - 10, oriy - 10, 20, 20);
                if(i!=2)
                g.DrawLine(Pens.Black, orix, oriy, orix + x * 40, oriy + y * 40);
                g.FillEllipse(Brushes.White, orix - 10 + 1, oriy - 10 + 1, 17, 17);
                if (i != 2)
                { orix += x * 40; oriy += y * 40; }
            }
            x = (float)Math.Cos(Math.PI * (45.0 / 180.0)); y = (float)Math.Sin(Math.PI * (45.0 / 180.0));
            g.DrawLine(Pens.Black, orix, oriy, orix + x * 40, oriy + y * 40);
            g.FillEllipse(Brushes.White, orix - 10 + 1, oriy - 10 + 1, 17, 17);
            orix += x * 40; oriy += y * 40;
            g.DrawEllipse(Pens.Black, orix - 10, oriy - 10, 20, 20);
            g.FillEllipse(Brushes.White, orix - 10 + 1, oriy - 10 + 1, 17, 17);
            orix = 200;oriy = 20;
            x = (float)Math.Cos(Math.PI * (135.0 / 180.0)); y = (float)Math.Sin(Math.PI * (135.0 / 180.0));
            for (int i = 0; i < 2; i++)
            {
                g.DrawEllipse(Pens.Black, orix - 10, oriy - 10, 20, 20);
                if (i != 1)
                    g.DrawLine(Pens.Black, orix, oriy, orix + x * 40, oriy + y * 40);
                g.FillEllipse(Brushes.White, orix - 10 + 1, oriy - 10 + 1, 17, 17);
                if (i != 1)
                { orix += x * 40; oriy += y * 40; }
            }
            x = (float)Math.Cos(Math.PI * (45.0 / 180.0)); y = (float)Math.Sin(Math.PI * (45.0 / 180.0));
            g.DrawLine(Pens.Black, orix, oriy, orix + x * 40, oriy + y * 40);
            g.FillEllipse(Brushes.White, orix - 10 + 1, oriy - 10 + 1, 17, 17);
            orix += x * 40; oriy += y * 40;
            g.DrawEllipse(Pens.Black, orix - 10, oriy - 10, 20, 20);
            g.FillEllipse(Brushes.White, orix - 10 + 1, oriy - 10 + 1, 17, 17);
            //45->135
            x = (float)Math.Cos(Math.PI * (135.0 / 180.0)); y = (float)Math.Sin(Math.PI * (135.0 / 180.0));
            g.DrawLine(Pens.Black, orix, oriy, orix + x * 40, oriy + y * 40);
            g.FillEllipse(Brushes.White, orix - 10 + 1, oriy - 10 + 1, 17, 17);
            orix += x * 40; oriy += y * 40;
            g.DrawEllipse(Pens.Black, orix - 10, oriy - 10, 20, 20);
            g.FillEllipse(Brushes.White, orix - 10 + 1, oriy - 10 + 1, 17, 17);
            //
            //250 20
            orix = 250;oriy = 20;
            //O/
            g.DrawEllipse(Pens.Black, orix - 10, oriy - 10, 20, 20);
            g.DrawLine(Pens.Black, orix, oriy, orix + x * 40, oriy + y * 40);
            g.FillEllipse(Brushes.White, orix - 10 + 1, oriy - 10 + 1, 17, 17);
            orix += x * 40; oriy += y * 40;
            //
            g.DrawEllipse(Pens.Black, orix - 10, oriy - 10, 20, 20);
            x = (float)Math.Cos(Math.PI * (45.0 / 180.0)); y = (float)Math.Sin(Math.PI * (45.0 / 180.0));
            g.DrawLine(Pens.Black, orix, oriy, orix + x * 40, oriy + y * 40);
            g.FillEllipse(Brushes.White, orix - 10 + 1, oriy - 10 + 1, 17, 17);
            orix += x * 40; oriy += y * 40;
            g.DrawEllipse(Pens.Black, orix - 10, oriy - 10, 20, 20);
            g.DrawLine(Pens.Black, orix, oriy, orix + x * 40, oriy + y * 40);
            g.FillEllipse(Brushes.White, orix - 10 + 1, oriy - 10 + 1, 17, 17);
            orix += x * 40; oriy += y * 40;
            g.DrawEllipse(Pens.Black, orix - 10, oriy - 10, 20, 20);
            g.FillEllipse(Brushes.White, orix - 10 + 1, oriy - 10 + 1, 17, 17);
            //350 20
            orix = 350;oriy = 20;
            g.DrawEllipse(Pens.Black, orix - 10, oriy - 10, 20, 20);
            g.DrawLine(Pens.Black, orix, oriy, orix + x * 40, oriy + y * 40);
            g.FillEllipse(Brushes.White, orix - 10 + 1, oriy - 10 + 1, 17, 17);
            orix += x * 40; oriy += y * 40;
            g.DrawEllipse(Pens.Black, orix - 10, oriy - 10, 20, 20);
            g.FillEllipse(Brushes.White, orix - 10 + 1, oriy - 10 + 1, 17, 17);
            x = (float)Math.Cos(Math.PI * (135.0 / 180.0)); y = (float)Math.Sin(Math.PI * (135.0 / 180.0));
            
            g.DrawLine(Pens.Black, orix, oriy, orix + x * 40, oriy + y * 40);
            g.FillEllipse(Brushes.White, orix - 10 + 1, oriy - 10 + 1, 17, 17);
            orix += x * 40; oriy += y * 40;
            g.DrawEllipse(Pens.Black, orix - 10, oriy - 10, 20, 20);
            g.DrawLine(Pens.Black, orix, oriy, orix + x * 40, oriy + y * 40);
            g.FillEllipse(Brushes.White, orix - 10 + 1, oriy - 10 + 1, 17, 17);
            orix += x * 40; oriy += y * 40;
            g.DrawEllipse(Pens.Black, orix - 10, oriy - 10, 20, 20);
            g.FillEllipse(Brushes.White, orix - 10 + 1, oriy - 10 + 1, 17, 17);
            x = (float)Math.Cos(Math.PI * (45.0 / 180.0)); y = (float)Math.Sin(Math.PI * (45.0 / 180.0));
        }
    }
}
