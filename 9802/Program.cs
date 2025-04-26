using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9802
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("輸入N:");
            int n=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(1);
            string s = "1";
            for(int i=0;i<n;i++)
            {
                int a = 0,num=0,tr=0;
                string ss = "";
                for(int  j=0;j<s.Length;j++)
                {
                    if (tr == 0)
                    {
                        tr = 1;
                        a = s[j] - '0'; num++;
                        //Console.WriteLine(a + " " + num);
                        continue;
                    }
                    if (s[j] - '0' == a) num++;
                    else//可以傳回字串
                    {
                        j--;
                        ss += num +""+ a;
                        tr = 0;
                        num = 0;
                    }
                }
                if (tr == 0)
                {
                    tr = 1;
                    a = s[s.Length-1] - '0'; 
                    num++;
                }
                ss += num +""+ a;
                s = "";
                s = ss;
                Console.WriteLine(s);
            }
            Console.ReadKey();
        }
    }
}
