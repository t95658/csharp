using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _11003
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long[] dp=new long[95];
            dp[1] = 1;
            dp[2] = 1;
            Console.WriteLine(1+" " + dp[1]);
            Console.WriteLine(2 + " " + dp[2]);
            for (int i=3;i<=92;i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
                Console.WriteLine(i + " " + dp[i]);
            }
            //大數加法
            Console.Write("從費事數列中選擇第一個數：");
            string n1=dp[Convert.ToInt64( Console.ReadLine())].ToString();
            Console.Write("從費事數列中選擇第二個數：");
            string n2= dp[Convert.ToInt64(Console.ReadLine())].ToString();
            int a=n1.Length-1,b= n2.Length-1;
            Console.Write("相加結果為：");
            int[] ans = new int[25];
            int max=Math.Max(a, b);
            max++;
            int pre = 0;
            int st = 0;
            for (int i = 0; i <= max; i++)
            {
                int c = 0, d = 0;
                if(a>=0) c = n1[a]-'0';
                if(b>=0) d=n2[b]-'0';
                a--;b--;
                int al = c + d + pre;
                int m = al % 10;
                pre = al / 10;
                ans[i] = m;
                
            }
            string last = "";
            for (int i = ans.Length - 1; i >= 0; i--)
            {
                if (ans[i]!=0)
                {
                    st=i; break;
                }
            }
            for (int i = st; i >= 0; i--)
            {
                last += ans[i];
            }
            Console.WriteLine(last);
            Console.ReadKey();
        }
    }
}
