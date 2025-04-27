using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 北軟9904
{
    internal class Program
    {
        static string[] path = new string[1005];
        static string[] ansp = new string[1005];
        static Dictionary<string,int> visit=new Dictionary<string,int>();
        static int tr = 0;
        static int minn=int.MaxValue;
        static void dfs(int a,int b,int c,int d,int e,int f,int idx)
        {
            if ((a > b && b > 0) || (d > e && e > 0)) return;
            string test = "";
            test = ""+a+b+(c%2)+d+e+(f%2);
            if (test == "000331")
            {
                tr = 1;
                if(minn>idx)
                {
                    minn = idx;
                    for (int i = 0; i < idx; i++) ansp[i] = path[i];
                }
                return;
            }
            if (c%2==0)//船在對面
            {
                if(d>=1)
                {
                    string s = "" + (a + 1)+b+((c+1)%2)+(d-1)+e+((f+1)%2);
                    if (!visit.ContainsKey(s) || visit[s] == 0)
                    {
                        visit[s]=1;
                        path[idx] = s;
                        dfs(a + 1, b, c + 1, d-1, e, f + 1, idx + 1);
                        visit[s]=0;
                    }                   
                }
                if(e>=1)
                {
                    string s = "" + a + (b+1) + ((c + 1) % 2) + d  + (e-1) + ((f + 1) % 2);
                    if (!visit.ContainsKey(s) || visit[s] == 0)
                    {
                        visit[s] = 1;
                        path[idx] = s;
                        dfs(a , b+1, c + 1, d, e-1, f + 1, idx + 1);
                        visit[s] = 0;
                    }
                }
                if(d>=2)
                {
                    string s = "" + (a + 2) + b + ((c + 1) % 2) + (d - 2) + e + ((f + 1) % 2);
                    if (!visit.ContainsKey(s) || visit[s] == 0)
                    {
                        visit[s] = 1;
                        path[idx] = s;
                        dfs(a + 2, b, c + 1, d - 2, e, f + 1, idx + 1);
                        visit[s] = 0;
                    }
                }
                if(e>=2)
                {
                    string s = "" + a + (b + 2) + ((c + 1) % 2) + d + (e - 2) + ((f + 1) % 2);
                    if (!visit.ContainsKey(s) || visit[s] == 0)
                    {
                        visit[s] = 1;
                        path[idx] = s;
                        dfs(a, b + 2, c + 1, d, e - 2, f + 1, idx + 1);
                        visit[s] = 0;
                    }
                }
                if(d>=1&&e>=1)
                {
                    string s = "" + (a + 1) + (b + 1) + ((c + 1) % 2) + (d - 1) + (e - 1) + ((f + 1) % 2);
                    if (!visit.ContainsKey(s) || visit[s] == 0)
                    {
                        visit[s] = 1;
                        path[idx] = s;
                        dfs(a + 1, b + 1, c + 1, d - 1, e - 1, f + 1, idx + 1);
                        visit[s] = 0;
                    }
                }
            }
            else//船在自己家
            {
                if(a>=2)
                {
                    string s = "" + (a-2) + b + ((c + 1) % 2) + (d +2) + e + ((f + 1) % 2);
                    if (!visit.ContainsKey(s) || visit[s] == 0)
                    {
                        visit[s] = 1;
                        path[idx] = s;
                        dfs(a - 2, b, c + 1, d +2, e, f + 1, idx + 1);
                        visit[s] = 0;
                    }
                }
                if(b>=2)
                {
                    string s = "" + (a) + (b-2) + ((c + 1) % 2) + d  + (e+2) + ((f + 1) % 2);
                    if (!visit.ContainsKey(s) || visit[s] == 0)
                    {
                        visit[s] = 1;
                        path[idx] = s;
                        dfs(a, b-2, c + 1, d, e+2, f + 1, idx + 1);
                        visit[s] = 0;
                    }
                }
                if(a>=1&&b>=1)
                {
                    string s = "" + (a - 1) + (b-1) + ((c + 1) % 2) + (d + 1) + (e+1) + ((f + 1) % 2);
                    if (!visit.ContainsKey(s) || visit[s] == 0)
                    {
                        visit[s] = 1;
                        path[idx] = s;
                        dfs(a - 1, b-1, c + 1, d + 1, e+1, f + 1, idx + 1);
                        visit[s] = 0;
                    }
                }
            }
            return;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("請輸入起始狀態:");
            string[] s=Console.ReadLine().Split(',');
            string st = s[0] + s[1] + s[2] + s[3] + s[4] + s[5];
            int a = int.Parse(s[0]), b = int.Parse(s[1]), c = int.Parse(s[2]), d = int.Parse(s[3]), e = int.Parse(s[4]), f = int.Parse(s[5]);
            if((a>b&&b>0)||(d>e&&e>0))
            {
                Console.WriteLine("違反題意");
                Console.ReadKey();
                return;
            }
            //特殊情況
            if(a+b==1&&c==1)
            {
                Console.WriteLine("此成功路徑步驟為:");
                Console.WriteLine("0,0,0,3,3,1");
                Console.ReadKey();
                return;
            }
            dfs(a,b,c,d,e,f,0);
            if(tr==0)
            {
                Console.WriteLine("無解");
            }
            else
            {
                Console.WriteLine("此成功路徑步驟為:");
                Console.WriteLine($"{a},{b},{c},{d},{e},{f}");
                for(int i=0;i<minn;i++)
                {
                    Console.Write(ansp[i][0]);
                    for(int j = 1; j < ansp[i].Length;j++)
                    {
                        Console.Write(","+ansp[i][j]);
                    }
                    Console.WriteLine();
                }
                
            }
            Console.ReadKey();
        }
    }
}
