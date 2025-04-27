using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 中轉前
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("輸入運算式:");
            string s=Console.ReadLine();
            string reans = "";
            Dictionary<char,int> d= new Dictionary<char,int>();
            d['+'] = 1; d['-'] = 1; d['*'] = 2; d['/'] = 2; d['('] = 0; d[')'] = 0;
            List<char> chars= new List<char>();
            for(int i=s.Length-1; i>=0; i--)
            {
                if (s[i] == '+' || s[i] == '-' || s[i] == '*' || s[i] == '/')
                {
                    while (chars.Count > 0 && d[s[i]] < d[chars[chars.Count-1]])
                    {
                        reans+= chars[chars.Count-1];
                        chars.RemoveAt(chars.Count-1);
                    }
                    chars.Add(s[i]);
                }
                else if (s[i]==')') chars.Add(s[i]);
                else if (s[i]=='(')
                {
                    while (chars[chars.Count-1]!=')')
                    {
                        reans+= chars[chars.Count-1];
                        chars.RemoveAt(chars.Count-1);
                    }
                    chars.RemoveAt(chars.Count-1);
                }
                else
                {
                    reans += s[i];
                }
            }
            while(chars.Count > 0)
            {
                reans += chars[chars.Count - 1];
                chars.RemoveAt(chars.Count-1);
            }
            string ans = "";
            for(int i=reans.Length-1; i>=0; i--) ans+=reans[i];
            Console.WriteLine(ans);
            Console.ReadKey();
        }
    }
}
