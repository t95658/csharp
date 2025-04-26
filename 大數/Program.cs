using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
namespace 大數
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s1=Console.ReadLine(),s2=Console.ReadLine();
            string test = "";
            int[] a1 = new int[1505];
            int[] a2 = new int[1505];
            string anss = "";
            int idx = 0, idx2 = 0;
            for(int i=s1.Length-1;i>=0;i--) a1[idx++]=s1[i]-'0';
            for (int i = s2.Length - 1; i >= 0; i--) a2[idx2++] = s2[i] - '0';
            for(int i=0;i<s1.Length;i++)
            {
                test+= s1[i];
                while (test[0]=='0'&&test!="0") test=test.Substring(1);
                int a = 0;//商
                while(true)
                {
                    int tr = 0;//test>=s2 tr=1
                    if (test.Length > s2.Length) tr = 1;
                    if(test.Length == s2.Length)
                    {
                        for(int j=0;j<s2.Length;j++)
                        {
                            if (test[j]>s2[j])
                            {
                                tr = 1;
                                break;
                            }
                            if (test[j] < s2[j]) break;
                            if (j == s2.Length - 1) tr = 1;
                        }
                    }
                    if ((tr==0))
                    {
                        break;
                    }
                    test = minus(test, s2);
                    a++;
                }
                anss += a;
            }
            while (anss[0]=='0'&&anss!="0") anss=anss.Substring(1);
            Console.WriteLine(anss+","+test);
            BigInteger aa = BigInteger.Parse(s1);
            BigInteger bb = BigInteger.Parse(s2);
            Console.WriteLine(aa/bb+","+aa%bb);
            Console.ReadKey();
        }
        static string minus(string s1,string s2)
        {
            int[] a1 = new int[1505];
            int[] a2 = new int[1505];
            int[] ans = new int[1505];
            int idx = 0, idx2 = 0;
            for (int i = s1.Length - 1; i >= 0; i--) a1[idx++] = s1[i] - '0';
            for (int i = s2.Length - 1; i >= 0; i--) a2[idx2++] = s2[i] - '0';
            int old = 0;
            for(int i=0;i<s1.Length;i++)
            {
                int a=a1[i],b=0;
                if (i < idx2) b = a2[i];
                int c = a - b - old;
                if (c < 0)
                {
                    c += 10;
                    old = 1;
                }
                else old = 0;
                ans[i] = c;
            }
            int s = 0;
            for(int i=1501;i>=0;i--)
            {
                if (ans[i]!=0)
                {
                    s = i; break;
                }
            }
            string anss = "";
            for (int i = s; i >= 0; i--) anss += ans[i];
            return anss;
        }
    }
}
