using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dfs_1
{
    internal class Program
    {
        static int[,] map = new int[50, 50];
        static int rol = 0, col = 0;
        static int[,] visit= new int[50, 50];
        static int tr = 1;
        static void dfs(int r, int c)
        {
            visit[r, c] = 1;
            if(tr==1)
                Console.Write("(" + r + "," + c + ")");
            if(r==rol-1&&c==col-1)
            {
                tr = 0;
                return;
            }
            if (r - 1 >= 0 && visit[r - 1, c] == 0 && map[r-1,c]==0) dfs(r - 1, c);
            if(r-1 >= 0 && c + 1 < col && visit[r - 1, c + 1] == 0 && map[r-1,c+1]==0) dfs(r-1, c+1);
            if(c + 1 < col && visit[r, c + 1] == 0&&map[r, c+1] == 0) dfs(r, c + 1);
            if (r + 1 < rol && c + 1 < col && visit[r+1,c+1]==0 && map[r+1, c+1] == 0) dfs(r+1, c+1);
            if (r + 1 < rol && visit[r + 1, c] == 0 && map[r+1, c] == 0) dfs(r + 1, c);
            if (r + 1 < rol && c - 1 >= 0 && visit[r + 1, c - 1] == 0 && map[r+1, c-1] == 0) dfs(r + 1, c - 1);
            if (c - 1 >= 0 && visit[r,c-1]==0 && map[r, c-1] == 0) dfs(r, c-1);
            if (c - 1 >= 0 && r - 1 >= 0 && visit[r-1,c-1]==0 && map[r - 1, c-1] == 0) dfs(r-1, c-1);
            return;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("請輸入檔名:");
            string fname=Console.ReadLine();
            FileInfo f=new FileInfo(fname);
            StreamReader read=f.OpenText();
            string all=read.ReadToEnd();
            string[] ss=all.Split('\n');
            rol = ss.Length;
            for(int i=0;i<ss.Length;i++)
            {
                string[] s2 = ss[i].Split(' ');
                col = s2.Length;
                for(int j=0;j<s2.Length;j++)
                {
                    map[i,j]= int.Parse(s2[j]);
                }
            }
            dfs(0, 0);
            Console.ReadKey();
        }
    }
}
