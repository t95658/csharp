using System;
using System.Collections.Generic;
using System.IO;
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
                Console.WriteLine("請輸入檔名:");
                string f=Console.ReadLine();
                FileInfo file = new FileInfo("C:\\Users\\USER\\Desktop\\"+f);
                StreamReader read=file.OpenText();
                Console.Write("輸入起點:");
                int s=Convert.ToInt32(Console.ReadLine());
                Console.Write("輸入終點:");
                int t=Convert.ToInt32(Console.ReadLine());
                List<List<int>> chdpoint = new List<List<int>>();
                List<List<int>> chdvalue = new List<List<int>>();
                List<int> minn = new List<int>();
                for(int i=0;i<10;i++) chdvalue.Add(new List<int>());
                for (int i = 0; i < 10; i++) chdpoint.Add(new List<int>());
                int[] parpoint=new int[10];
                int[] parvalue=new int[10];
                int[] visit=new int[10];
                int[] d=new int[10];
                visit[s] = 1;
                d[s] = 0;
                while(read.Peek()!=-1)
                {
                    string s2=read.ReadLine();
                    string[] s3 = s2.Split(' ');
                    int a = Convert.ToInt32(s3[0]);
                    int b = Convert.ToInt32(s3[1]), c = Convert.ToInt32(s3[2]);
                    chdpoint[a].Add(b);
                    chdvalue[a].Add(c);
                }
                read.Close();
                //dag
                Queue<int> q = new Queue<int>();
                q.Enqueue(s);
                while (q.Count > 0)
                {
                    int front=q.Dequeue();
                    for (int i = 0; i < chdpoint[front].Count; i++)
                    {
                        int nextpoint = chdpoint[front][i];
                        q.Enqueue(chdpoint[front][i]);
                        if (d[nextpoint] == 0 || d[front] + chdvalue[front][i] < d[nextpoint])//更新
                        {
                            d[nextpoint] = d[front] + chdvalue[front][i];
                            q.Enqueue(nextpoint);
                            parpoint[nextpoint] = front;
                            parvalue[nextpoint] = chdvalue[front][i];
                        }
                    }
                }
                int[] ans= new int[10];
                int[] ansvalue= new int[10];
                int tt = t;
                while (parpoint[tt]!=0)
                {
                    int lastpoint=parpoint[tt];
                    ans[lastpoint] = tt;
                    ansvalue[lastpoint] = parvalue[tt];
                    tt=lastpoint;
                }
                Console.WriteLine("最低成本值:" + d[t]);
                Console.Write("路徑次序:");
                int ss = s;
                while (ss!=0)
                {
                    Console.Write(ss + " ");
                    ss = ans[ss];
                }
                Console.WriteLine();    
                Console.Write("連線數值:0 ");
                ss = s;
                while(ansvalue[ss]!=0)
                {
                    Console.Write(ansvalue[ss] + " ");
                    ss = ans[ss];
                }
                Console.WriteLine();
            }
        }
    }
}
