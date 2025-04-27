using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 小數點運算式
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("請輸入運算式:");
            string s=Console.ReadLine();
            s = "0" + s;
            List<string> back=new List<string>();
            Stack<char> chars=new Stack<char>();
            Dictionary<char,int> d=new Dictionary<char,int>();
            d['-'] = 1; d['+'] = 1; d['*'] = 2; d['/'] = 2; d['('] = 0; d[')'] = 0;
            string test = "";
            for(int i=0;i<s.Length;i++)
            {
                if (s[i] <= '9' && s[i] >= '0' || s[i]=='.') test+= s[i];
                else if(test!="")
                {
                    back.Add(test);
                    test = "";
                }
                if (s[i] == '+' || s[i] == '*' || s[i] == '/' || s[i]=='-')
                {
                    while (chars.Count>0&&d[s[i]] <= d[chars.Peek()]) back.Add(""+chars.Pop());
                    chars.Push(s[i]);
                }
                else if (s[i]=='(') chars.Push(s[i]);
                else if (s[i]==')')
                {
                    while (chars.Peek() != '(') back.Add("" + chars.Pop());
                    chars.Pop();
                }
            }
            if(test!="") back.Add(test);
            while(chars.Count>0) back.Add(""+chars.Pop());
            double all = 0;
            List<double> dou=new List<double>();
            for(int i=0;i<back.Count;i++)
            {
                if (back[i]=="+")
                {
                    double a1 = dou[dou.Count-2],a2=dou[dou.Count-1];
                    dou.RemoveAt(dou.Count-1);
                    dou.RemoveAt(dou.Count-1);
                    dou.Add(a1+a2);
                }
                else if(back[i]=="-")
                {
                    double a1 = dou[dou.Count - 2], a2 = dou[dou.Count - 1];
                    dou.RemoveAt(dou.Count - 1);
                    dou.RemoveAt(dou.Count - 1);
                    dou.Add(a1 - a2);
                }
                else if (back[i]=="*")
                {
                    double a1 = dou[dou.Count - 2], a2 = dou[dou.Count - 1];
                    dou.RemoveAt(dou.Count - 1);
                    dou.RemoveAt(dou.Count - 1);
                    dou.Add(a1 * a2);
                }
                else if( back[i]=="/")
                {
                    double a1 = dou[dou.Count - 2], a2 = dou[dou.Count - 1];
                    dou.RemoveAt(dou.Count - 1);
                    dou.RemoveAt(dou.Count - 1);
                    dou.Add(a1 / a2);
                }
                else
                {
                    dou.Add(double.Parse( back[i]));
                }
            }
            Console.WriteLine("結果為:" + dou[0]);
            Console.ReadKey();
        }
    }
}
