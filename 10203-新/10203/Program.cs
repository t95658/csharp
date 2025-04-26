using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10203
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("輸入邊數:");
                int n =Convert.ToInt32( Console.ReadLine());
                Console.WriteLine("輸入點數:");
                int n2=Convert.ToInt32( Console.ReadLine());
                List<List<int>> chdpoint=new List<List<int>>();
                List<List<int>> chdvalue=new List<List<int>>();
                int[,] ansv = new int[10, 10];
                for(int i=0;i<10;i++) chdpoint.Add(new List<int>());
                for(int i=0;i<10;i++) chdvalue.Add(new List<int>());
                for(int i=0;i<n;i++)
                {
                    string s3 = Console.ReadLine();
                    string[] s2 = s3.Split(' ');
                    int a = Convert.ToInt32(s2[0]), b = Convert.ToInt32(s2[1]), c = Convert.ToInt32(s2[2]);
                    chdpoint[a].Add(b);
                    chdvalue[a].Add(c);
                    ansv[a, b] = c;
                }
                Console.Write("輸入起點:");
                int s = Convert.ToInt32(Console.ReadLine());
                Console.Write("輸入終點:");
                int t = Convert.ToInt32(Console.ReadLine());
                Console.Write("最低成本值總和:");
                List<int> minn = new List<int>();
                List<int> point = new List<int>();
                List<int> lastpoint = new List<int>();
                int[] visit = new int[10];
                int oldvalue = 0;
                Queue<int> q = new Queue<int>();
                int[] par=new int[10];
                int[] d = new int[10];
                
                q.Enqueue(s);
                visit[s] = 1;
                while(q.Count>0)
                {
                    int front=q.Dequeue();
                    int tr = 0;//走到底了
                    for(int i = 0; i < chdpoint[front].Count;i++)
                    {
                        if (visit[chdpoint[front][i]]==0)
                        {
                            tr = 1;//還可走
                            minn.Add(chdvalue[front][i] + d[front]);
                            point.Add(chdpoint[front][i]);
                            
                            lastpoint.Add(front);
                        }                       
                    }
                    int[] minnarr=minn.ToArray();
                    int[] pointarr=point.ToArray();
                    int[] lastpointarr=lastpoint.ToArray();
                    int[] minnarr2=minn.ToArray();
                    Array.Sort(minnarr,pointarr);
                    Array.Sort(minnarr2, lastpointarr);
                    //oldvalue= minnarr[0];
                    /* (pointarr[0] ==5)
                            {
                                tr = 1;
                            }*/
                    //if (tr == 1)
                    //{
                        d[pointarr[0]] = minnarr[0];
                        visit[pointarr[0]] = 1;
                        q.Enqueue(pointarr[0]);
                        if (par[pointarr[0]]==0)
                            par[pointarr[0]] = lastpointarr[0];
                        minn=minnarr.ToList();
                        point=pointarr.ToList();
                        lastpoint = lastpointarr.ToList();
                        if (pointarr[0] == t) break;  
                        minn.RemoveAt(0);
                        point.RemoveAt(0);
                        lastpoint.RemoveAt(0);
                    //}                                 
                }
                Console.WriteLine(d[t]);
                int[] up = new int[10];
                int tt = t;
                while (par[tt]!=0)
                {
                    int lastp = par[tt];
                    up[lastp] = tt;
                    tt=par[tt];
                }
                int ss = s;
                Console.Write("路徑次序:");
                while(ss!=0)
                {
                    Console.Write(ss+" ");
                    ss = up[ss];
                }
                Console.WriteLine();
                Console.Write("連線數值:");
                ss = s;
                while (ss != 0)
                {
                    int lastpoi = par[ss];
                    if (ss == s) Console.Write(0 + " ");
                    else
                    {
                        Console.Write(ansv[lastpoi, ss] + " ");
                    }
                    ss = up[ss];
                }
                Console.WriteLine();
            }
        }
    }
}
