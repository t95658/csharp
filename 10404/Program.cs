using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10404
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] up = new int[105];
            int[] mid = new int[105];
            int[] down = new int[105];
            double[] same = new double[105];
            int n=0;
            while(true)
            {
                Console.WriteLine("請選擇操作項目:");
                Console.WriteLine("\t<1>輸入模型資料:");
                Console.WriteLine("\t<2>計算平均相似度:");
                Console.WriteLine("\t<3>顯示各資料相似度");
                Console.Write("請選擇:");
                
                
                
                int a = Convert.ToInt32(Console.ReadLine());
                if(a==1)
                {
                    Console.Write("輸入模型資料 總筆數為:");
                    n=Convert.ToInt32( Console.ReadLine());
                    Console.Write("序列(x軸):");
                    string[] s=Console.ReadLine().Split(new string[] {" "},StringSplitOptions.RemoveEmptyEntries);
                    Console.Write("數值串列(上限):");
                    string[] s1= Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    Console.Write("數值串列(中心):");
                    string[] s2 = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    Console.Write("數值串列(下限):");
                    string[] s3 = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    for(int i=0;i<n;i++)
                    {
                        int num = Convert.ToInt32(s[i]);
                        up[num]=Convert.ToInt32(s1[i]);
                        mid[num]=Convert.ToInt32(s2[i]);
                        down[num]=Convert.ToInt32(s3[i]);
                    }
                }
                if(a==2)
                {
                    Console.Write("請輸入「資料串列」檔名:");
                    string file=Console.ReadLine();
                    FileInfo f=new FileInfo(file);
                    Console.WriteLine("已開啟「資料串列」檔名:"+file);
                    StreamReader read=f.OpenText();
                    string[] s=read.ReadToEnd().Split(' ');
                    read.Close();
                    int[] t = new int[105];//均
                    double all = 0;
                    for(int i=0;i<s.Length;i++)
                    {
                        t[i]=Convert.ToInt32(s[i]);
                        if (t[i] <= mid[i] && t[i] >= down[i])
                        {
                            same[i] = (double)(t[i] - down[i]) / (double)(mid[i] - down[i]);
                        }
                        if (t[i] > mid[i] && t[i] <= up[i])
                        {
                            same[i] = (double)(up[i] - t[i]) / (double)(up[i]-mid[i]);
                        }
                        all += same[i];
                    }
                    all /= s.Length;
                    Console.WriteLine("平均相似度為:" + all.ToString("0.######"));
                }
                if(a==3)
                {
                    Console.WriteLine("各資料相似度:");
                    for(int i=0;i<n;i++)
                    {
                        Console.Write(same[i].ToString("0.######") + " ");
                    }
                    Console.WriteLine();
                }
                Console.Write("繼續請按1，結束請按0:");
                string end=Console.ReadLine();
                if (end == "0") break;
            }
            Console.ReadKey();
        }
    }
}
