using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
namespace 大數除法_2
{
    internal class Program
    {
        static string minus(string s1,string s2)
        {
            int[] a1=new int[s1.Length];
            int[] b1 = new int[s2.Length];
            int[] ans=new int[s1.Length];
            int idx1 = 0, idx2 = 0,old=0;
            for(int i=s1.Length-1;i>=0;i--) a1[idx1++]=s1[i]-'0';
            for (int i = s2.Length - 1; i >= 0; i--) b1[idx2++] = s2[i] - '0';
            for(int i=0;i<idx1;i++)
            {
                int a = a1[i], b = 0;
                if (i < idx2) b = b1[i];
                ans[i] = a - b - old;
                if (ans[i] < 0)
                {
                    ans[i] += 10;
                    old = 1;
                }
                else old = 0;
            }
            int s = 0;
            for(int i=idx1-1;i>=0;i--)
            {
                if (ans[i]!=0)
                {
                    s = i;
                    break;
                }
            }
            string anss = "";
            for (int i = s; i >= 0; i--) anss += ans[i];
            return anss;
        }
        static string mult(string s2,int num)
        {
            int[] a1 = new int[1505];
            int[] a2 = new int[1505];
            int idx1 = 0, idx2 = 0;
            int[] ans = new int[1505];
            for(int i=s2.Length-1;i>=0;i--) a2[idx2++] = s2[i]-'0';
            int old = 0;
            
            for(int i=0;i<idx2;i++)
            {
                int a = a2[i] * num;
                ans[i]+=a;
                while (ans[i]>=10)
                {
                    ans[i] -= 10;
                    ans[i + 1]++;
                }
            }
            int s = 0;
            for(int i=1502-1;i>=0;i--)
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
        static void Main(string[] args)
        {
            string s1=Console.ReadLine();
            string s2=Console.ReadLine();
            int[] ans=new int[s1.Length];//商
            string test = "";//部分s1，最後是餘數
            for(int i=0;i<s1.Length;i++)
            {
                int a = 0;
                test+= s1[i];
                while (test[0]=='0') test=test.Substring(1);
                for(int j=9;j>=0;j--)//測試商
                {
                    //b=s2(大數)*j(int)
                    //if b<=test (8*4<=35) a=j,test=test(大數)-b(大數)
                    string b = mult(s2, j);
                    int tr = 0;
                    if (b.Length < test.Length) tr = 1;
                    if (test == b) tr = 1;
                    if(b.Length==test.Length)
                    {
                        for(int k=0;k<test.Length;k++)
                        {
                            
                            if (b[k]<test[k])
                            {
                                tr = 1;
                                break;
                            }
                            if (b[k] > test[k]) break;
                        }
                    }
                    if(tr==1)//一定是大減小
                    {
                        a = j;
                        test = minus(test, b);
                        break;
                    }
                }
                ans[i] = a;
            }
            string anss = "";
            for(int i=0;i<ans.Length;i++) anss+=ans[i];
            while (anss[0]=='0'&&anss!="0") anss=anss.Substring(1);
            Console.WriteLine("商數="+anss+"，餘數="+test);
            BigInteger big1= BigInteger.Parse(s1);
            BigInteger big2= BigInteger.Parse(s2);
            Console.WriteLine("商數=" + (big1/big2) + "，餘數=" + (big1%big2));
            Console.ReadKey();
        }
    }
}
