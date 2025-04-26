using new五子棋.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace new五子棋
{
    public partial class Form1 : Form
    {
        PictureBox[] p = new PictureBox[500];
        int black = 1, time = 0;
        int[,] visit = new int[30, 30];
        int[,] visitw = new int[30, 30];
        public void end()
        {
            button1.Enabled = true;
            button1.Visible = true;
            button2.Visible = true;
            button2.Enabled = true;
            BackgroundImage = null;
            for (int i = 0; i < 500; i++)
            {
                p[i].Image=null;
            }
            return;
        }
        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;
            button1.Visible = false;
            button2.Visible = false;
            button2.Enabled = false;
            black = 1; time = 0;
            p = new PictureBox[500];
            visit = new int[30, 30];
            int[,] visitw = new int[30, 30];
            for (int i = 0; i < 500; i++)
            {
                p[i] = new PictureBox();
            }
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    visit[i, j] = 0;
                    visitw[i, j] = 0;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        int tr = 0;

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            int newx = e.X - 75, newy = e.Y - 75;
            int timex = newx / 75, timey = newy / 75;
            if (e.X < 75 || e.Y < 75 || e.X > 75 * 9 || e.Y > 75 * 9) Cursor = Cursors.Default;
            else    if ((75 - newx % 75) <= 10 && (75 - newy % 75) <= 10)
            {
                Cursor = Cursors.Hand;
            }
            else if (newx % 75 <= 10 && 75 - newy % 75 <= 10 && visit[timex, timey + 1] == 0)
            {
                Cursor = Cursors.Hand;
            }
            else if (75 - newx % 75 <= 10 && newy % 75 <= 10 && visit[timex + 1, timey] == 0)
            {
                Cursor = Cursors.Hand;
            }
            else if (newx % 75 <= 10 && newy % 75 <= 10 && visit[timex, timey] == 0)
            {
                Cursor = Cursors.Hand;
            }
            else
                Cursor = Cursors.Default;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            //visit[1, 1] = 1;
            int newx = e.X - 75, newy = e.Y - 75;
            int timex = newx / 75, timey = newy / 75;
            p[time].BackColor = Color.Transparent;
            p[time].Size = new Size(50, 50);
            //p[time].Location = new Point(e.X,e.Y );
            //Controls.Add(p[time]);
            tr = 0;
            int tx = 0;
            int ty = 0;
            if (black == 1)
            {
                //MessageBox.Show("" + visit[1, 1]+" " + visit[2,1]);
                p[time].Image = Properties.Resources.black;
                if (e.X < 75 || e.Y < 75 || e.X > 75 * 9 || e.Y > 75 * 9) MessageBox.Show("這裡不能下");
                else if ((75 - newx % 75) <= 10 && (75 - newy % 75) <= 10)
                {
                    p[time].Location = new Point(75 + (timex + 1) * 75 - 25, 75 + (timey + 1) * 75 - 25);


                    if (visit[timex + 1, timey + 1] == 0)
                    {
                        Controls.Add(p[time]);
                        time++;
                        black = 0;
                        tr = 1;
                    }
                    visit[timex + 1, timey + 1] = 1;
                    //MessageBox.Show(visit[1,1]+" "+ (timex + 1)+" "+(timey+1));
                    tx = timex + 1;
                    ty = timey + 1;
                }
                else if (newx % 75 <= 10 && 75 - newy % 75 <= 10 && visit[timex, timey + 1] == 0)
                {
                    p[time].Location = new Point(75 + timex * 75 - 25, 75 + (timey + 1) * 75 - 25);
                    Controls.Add(p[time]);
                    time++;
                    black = 0;
                    tr = 1;
                    visit[timex, timey + 1] = 1;
                    tx = timex;
                    ty = timey + 1;
                }
                else if (75 - newx % 75 <= 10 && newy % 75 <= 10 && visit[timex + 1, timey] == 0)
                {
                    p[time].Location = new Point(75 + (timex + 1) * 75 - 25, 75 + timey * 75 - 25);
                    Controls.Add(p[time]);
                    time++;
                    black = 0;
                    tr = 1;
                    visit[timex + 1, timey] = 1;
                    tx = timex + 1;
                    ty = timey;
                }
                else if (newx % 75 <= 10 && newy % 75 <= 10 && visit[timex, timey] == 0)
                {
                    p[time].Location = new Point(75 + timex * 75 - 25, 75 + timey * 75 - 25);
                    Controls.Add(p[time]);
                    time++;
                    black = 0;
                    tr = 1;
                    visit[timex, timey] = 1;
                    tx = timex;
                    ty = timey;
                }

                if (tr == 1)
                {
                    int maxx = 0, a = 0, b = 0;
                    for (int i = 0; i < 9; i++)//左右
                    {

                        //MessageBox.Show("" + visit[i, ty]);
                        if (visit[i, ty] == 1)
                            a++;
                        else a = 0;
                        b = Math.Max(a, b);
                    }
                    maxx = Math.Max(maxx, b);
                    a = 0;
                    b = 0;

                    for (int i = 0; i < 9; i++)//上下
                    {
                        if (visit[tx, i] == 1)
                            a++;
                        else a = 0;
                        b = Math.Max(a, b);
                    }
                    maxx = Math.Max(maxx, b);
                    a = 0; b = 0;
                    int nn = tx + ty;
                    //右上到左下
                    for (int i = 0; i < 9; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            if (i + j == nn)
                            {
                                if (visit[i, j] == 1)
                                    a++;
                                else a = 0;
                                b = Math.Max(a, b);
                            }

                        }
                    }
                    maxx = Math.Max(maxx, b);
                    a = 0; b = 0;
                    nn = tx - ty;
                    for (int i = 0; i < 9; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            if (i - j == nn)
                            {
                                if (visit[i, j] == 1)
                                    a++;
                                else a = 0;
                                b = Math.Max(a, b);
                            }

                        }
                    }
                    maxx = Math.Max(maxx, b);
                    if (maxx == 5)
                    {
                        MessageBox.Show("黑棋勝利!");
                        end();
                    }
                    if (maxx > 5)
                    {
                        MessageBox.Show("Lose,連超過五顆");
                        end();
                    }
                }
            }
            else
            {
                p[time].Image = Properties.Resources.white;
                //black = 1;
                if (e.X < 75 || e.Y < 75 || e.X > 75 * 9 || e.Y > 75 * 9) MessageBox.Show("這裡不能下");
                else if ((75 - newx % 75) <= 10 && (75 - newy % 75) <= 10)
                {
                    p[time].Location = new Point(75 + (timex + 1) * 75 - 25, 75 + (timey + 1) * 75 - 25);
                    if (visitw[timex + 1, timey + 1] == 0)
                    {
                        Controls.Add(p[time]);
                        time++;
                        black = 1;
                        tr = 1;
                    }
                    visitw[timex + 1, timey + 1] = 1;
                    tx = timex + 1;
                    ty = timey + 1;
                }
                else if (newx % 75 <= 10 && 75 - newy % 75 <= 10 && visitw[timex, timey + 1] == 0)
                {
                    p[time].Location = new Point(75 + timex * 75 - 25, 75 + (timey + 1) * 75 - 25);
                    Controls.Add(p[time]);
                    time++;
                    black = 1;
                    tr = 1;
                    visitw[timex, timey + 1] = 1;
                    tx = timex;
                    ty = timey + 1;
                }
                else if (75 - newx % 75 <= 10 && newy % 75 <= 10 && visitw[timex + 1, timey] == 0)
                {
                    p[time].Location = new Point(75 + (timex + 1) * 75 - 25, 75 + timey * 75 - 25);
                    Controls.Add(p[time]);
                    time++;
                    black = 1;
                    tr = 1;
                    visitw[timex + 1, timey] = 1;
                    tx = timex + 1;
                    ty = timey;
                }
                else if (newx % 75 <= 10 && newy % 75 <= 10 && visitw[timex, timey] == 0)
                {
                    p[time].Location = new Point(75 + timex * 75 - 25, 75 + timey * 75 - 25);
                    Controls.Add(p[time]);
                    time++;
                    black = 1;
                    tr = 1;
                    visitw[timex, timey] = 1;
                    tx = timex;
                    ty = timey;
                }
                if (tr == 1)
                {
                    int maxx = 0, a = 0, b = 0;
                    for (int i = 0; i < 9; i++)//左右
                    {
                        if (visitw[i, ty] == 1)
                            a++;
                        else a = 0;
                        b = Math.Max(a, b);
                    }
                    maxx = Math.Max(maxx, b);
                    a = 0;
                    b = 0;

                    for (int i = 0; i < 9; i++)//上下
                    {
                        if (visitw[tx, i] == 1)
                            a++;
                        else a = 0;
                        b = Math.Max(a, b);
                    }
                    maxx = Math.Max(maxx, b);
                    a = 0; b = 0;
                    int nn = tx + ty;
                    //右上到左下
                    for (int i = 0; i < 9; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            if (i + j == nn)
                            {
                                if (visitw[i, j] == 1)
                                    a++;
                                else a = 0;
                                b = Math.Max(a, b);
                            }

                        }
                    }
                    maxx = Math.Max(maxx, b);
                    a = 0; b = 0;
                    nn = tx - ty;
                    for (int i = 0; i < 9; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            if (i - j == nn)
                            {
                                if (visitw[i, j] == 1)
                                    a++;
                                else a = 0;
                                b = Math.Max(a, b);
                            }

                        }
                    }
                    maxx = Math.Max(maxx, b);
                    if (maxx == 5)
                    {
                        MessageBox.Show("白棋勝利!");
                        end();
                    }
                    if (maxx > 5)
                    {
                        MessageBox.Show("Lose,連超過五顆");
                        end();
                    }
                }

            }

            
        }

    }
}


