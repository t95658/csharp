using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dfs_3
{
    internal class Program
    {
        static int n = 0,s=0,t=0;
        static int[] path = new int[50];
        static int[] anspath= new int[50];
        static int[] visit= new int[50];
        static double[,] value = new double[50, 50];
        static double v = 0,ansv=int.MaxValue;
        static List<List<int>> chd= new List<List<int>>();
        static void dfs(int p)
        {
            visit[p] = 1;
            if(p==t)
            {
                if(v<ansv)
                {
                    ansv = v;
                    for(int i=0;i<=n;i++) anspath[i] = path[i];
                }
                return;
            }
            for(int i = 0; i < chd[p].Count;i++ )
            {
                int next= chd[p][i];
                if (visit[next]==0)
                {
                    visit[next] = 1;
                    v += value[p, next];
                    path[p]= next;
                    dfs(next);
                    visit[next] = 0;
                    v -= value[p, next];
                    path[p] = 0;
                }
            }
            return;
        }
        static void Main(string[] args)
        {
            Console.Write("請輸入大地遊戲關卡文字檔檔名:");
            string fname=Console.ReadLine();    
            FileInfo f1=new FileInfo(fname);
            StreamReader read=f1.OpenText();
            string all=read.ReadToEnd();
            read.Close();
            Console.WriteLine("你輸入的檔名為'"+fname+"'");
            Console.WriteLine("大地遊戲關卡文字檔內容為:");
            Console.WriteLine(all);
            string[] ss=all.Split(new string[] {"\r\n"},StringSplitOptions.RemoveEmptyEntries);
            n =int.Parse( ss[0]);
            for(int i=0;i<=n;i++) chd.Add(new List<int>());
            for(int i=1;i<ss.Length-1;i++)
            {
                string[] s2 = ss[i].Split(' ');
                for (int j = 0; j < s2.Length; j++)
                {
                    double a=double.Parse(s2[j]);
                    if (a == 0) continue;
                    value[i, j + 1] = a;
                    chd[i].Add(j+1);
                }
            }
            string[] last = ss[ss.Length - 1].Split(' ');
            s=int.Parse( last[0]);t=int.Parse( last[1]);
            Console.Write("最快的闖關路線[" + s + "->" + t + "]:" + s);
            dfs(s);
            while(true)
            {
                s = anspath[s];
                if (s == 0) break;
                Console.Write("->" + s);
            }
            Console.WriteLine("(路途險峻程度 "+ansv+")");
            Console.ReadKey();
        }
    }
}
