using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9605
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("A:");
                long A=Convert.ToInt32( Console.ReadLine());
                Console.Write("B:");
                long B = Convert.ToInt32(Console.ReadLine());
                Console.Write("C:");
                long C = Convert.ToInt32(Console.ReadLine());
                long s = 1;
                string b=Convert.ToString(B,2);
                for (int i = 0; i < b.Length; i++)
                {
                    s = s * s % C;
                    if (b[i] == '1')
                    {
                        s = A * s % C;
                    }
                }
                Console.WriteLine(s);
            }          
        }
    }
}
