using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 大數減法
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("輸入a b(a-b)");
            string[] s=Console.ReadLine().Split(' ');
            int[] a = new int[105];
            int[] b = new int[105];
            int tmpa = 0, tmpb = 0;
            for(int i = s[0].Length-1; i >= 0; i--)
            {
                a[tmpa] = s[0][i] - '0';
                tmpa++;
            }
            for (int i = s[1].Length - 1; i >= 0; i--) b[tmpb++] = s[1][i] - '0';
            int maxx=Math.Max(tmpa, tmpb);
            int tr = 1;//a-b
            if(tmpa<tmpb)//b-a
            {
                tr = 0;//b-a
            }
            if(tmpa==tmpb)
            {
                int aa=tmpa-1, bb=tmpb-1;
                while(true)
                {
                    if (a[aa] < b[bb])
                    {
                        tr = 0;
                        break;
                    }
                    if (a[aa] > b[bb]) break;
                    if (aa == 0 && bb == 0) break;//完全相等正常a-b
                    aa--;bb--;
                }
            }
            int[] ans = new int[105];
            for(int i=0;i<maxx;i++)
            {
                int a1=0,b1=0;
                if (i < tmpa) a1 = a[i];
                if (i < tmpb) b1 = b[i];
                if (tr == 0)
                {
                    ans[i] += b1 - a1;
                    if (ans[i] < 0)
                    {
                        ans[i] += 10;
                        ans[i + 1]--;
                    }
                }
                if(tr==1)
                {
                    ans[i] += a1 - b1;
                    if (ans[i] < 0)
                    {
                        ans[i] += 10;
                        ans[i + 1]--;
                    }
                }
            }
            string anss = "";
            if (tr == 0) anss = "-";
            int start = 0;
            for (int i = maxx - 1; i >= 0; i--)
            {
                if (ans[i] > 0)
                {
                    start = i;
                    break;
                }
            }
            for(int i=start; i>=0; i--) anss += ans[i];
            
            Console.WriteLine(anss);
            Console.ReadKey();
        }
    }
}
