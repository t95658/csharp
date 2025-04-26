using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dfs_2
{
    internal class Program
    {
        static int rol = 0, col = 0, value = 0,oldvalue=0,s=0,change=0;//s為答案的起點
        static int[] path = new int[50];
        static int[] anspath = new int[50];
        static int[,] map=new int[50,50];
        static void dfs(int r,int c)
        {
            
            value += map[r, c];
            if (map[r, c + 1] != -1 && map[r,c+1]>map[r,c])
            {
                path[map[r,c]] = map[r,c+1];
                dfs(r,c+1);
                value -= map[r, c+1];
            }
            if(map[r, c - 1] != -1 && map[r, c - 1] > map[r, c])
            {
                path[map[r, c]] = map[r, c - 1];
                dfs(r,c-1);
                value -= map[r , c-1];
            }
            if (map[r+1, c] != -1 && map[r+1, c] > map[r, c])
            {
                path[map[r, c]] = map[r+1,c];
                dfs(r+1,c);
                value -= map[r + 1, c];
            }
            if (map[r-1, c] != -1 && map[r-1, c] > map[r, c])
            {
                path[map[r, c]] = map[r-1, c];
                dfs(r-1,c);
                value -= map[r-1, c];
            }
            if(value>oldvalue)
            {
                change = 1;
                for(int i=0;i<50;i++) anspath[i]=path[i];
                oldvalue = value;
            }
            return;
        }
        static void Main(string[] args)
        {
            Console.Write("請輸入檔名:");
            string fname=Console.ReadLine();
            FileInfo f=new FileInfo(fname);
            StreamReader read=f.OpenText();
            string all=read.ReadToEnd();
            string[] a=all.Split(new string[] { "\r\n" },StringSplitOptions.RemoveEmptyEntries);
            for(int i=0;i<a.Length;i++)
            {
                string[] a2 = a[i].Split(' ');
                if (i == 0)
                {
                    rol=int.Parse(a2[0]);
                    col=int.Parse(a2[1]);
                    for(int j=0;j<=rol+1;j++)
                    {
                        for(int k=0;k<=col+1;k++)
                        {
                            map[j, k] = -1;
                        }    
                    }
                    continue;
                }
                for(int j=0;j< a2.Length;j++)
                {
                    map[i,j+1]=int.Parse(a2[j]);
                }
            }
            for(int i=0;i<rol;i++)
            {
                for(int j=0;j<col;j++)
                {
                    value = 0;change = 0;
                    for (int k = 0; k < 50; k++) path[k] = 0;
                      
                    dfs(i+1, j+1);
                    if(change==1)
                        s = map[i+1,j+1]; 

                }
            }
            Console.WriteLine("加權最大路徑:");
            Console.Write(s);
            int al = 1;
            while (true) {
                s = anspath[s];
                if(s==0) break;
                al++;
                Console.Write("->" + s);               
            }
            Console.WriteLine();
            Console.WriteLine(al);
            Console.ReadKey();
        }
    }
}
