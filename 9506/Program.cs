using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9506
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string all=Console.ReadLine();
            List<char> lis=new List<char>();
            int[] appear = new int[3005];
            for (int i = 0; i < 3005; i++) appear[i] = 1;
            for(int i=0;i<all.Length;i++)
            {
                int tr = 0;
                int idx = 0;
                for(int j=0;j<lis.Count;j++)
                {
                    if (lis[j] == all[i])
                    {
                        idx = j;
                        tr = 1;
                    }
                }
                if(tr==0) lis.Add(all[i]);
                else
                {
                    appear[idx]++;
                }
            }
            char[] c=lis.ToArray();
            Array.Sort(appear, c,0,c.Length);
            string ans = "";
            for(int i=c.Length-1;i>=0;i--)
            {
                ans += "\"" + c[i] + "\"=" + appear[i];
                if (i != 0) ans += ";";
            }
            Console.WriteLine(ans);
            Console.ReadKey();
        }
    }
}
