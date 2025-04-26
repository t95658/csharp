using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11004
{
    internal class Program
    {
        static List<List<List<int>>> lis=new List<List<List<int>>>();
        static List<int> ans=new List<int>();
        static int maxx;
        static int maxy;
        static int[,] dp = new int[105, 105];
        static void dfs(int x,int y)
        {
            ans.Add(dp[y,x]);
            if (x == maxx && y == maxy)
            {
                Console.Write("[");
                for (int i = 0; i < ans.Count-1; i++)
                {
                    Console.Write(ans[i]+",");
                }
                Console.WriteLine(ans[ans.Count-1]+"]");
            }
            if(x+1<=maxx)
            {
                dfs(x+1,y);
                ans.RemoveAt(ans.Count - 1);
            }
            if (y + 1 <= maxy)
            {
                dfs(x,y+1);
                ans.RemoveAt(ans.Count-1);
            }
            return;
        }
        static void Main(string[] args)
        {
            
            Console.Write("請輸入一個二維陣列");
            //dp
            string s=Console.ReadLine();
            
            int temp = 1, temp2 = 1,fir=0;//temp2為列，fir為行
            for (int i = 1; i < s.Length-1; i++)
            {
                if (s[i]==']')
                {
                    temp2++;
                    fir = temp;
                    temp = 1;
                }
                if (s[i] >= '0' && s[i]<='9')
                {
                    dp[temp2,temp]=s[i]-'0';
                    temp++;
                }
            }
            Console.WriteLine("數字地圖：");
            
            for(int i=1;i<temp2;i++)
            {
                Console.Write("[");
                for(int j=1;j<fir;j++)
                {
                    if (j+1 == fir) Console.Write(dp[i, j]);
                    else 
                    Console.Write(dp[i, j] + ",");
                }
                Console.WriteLine("]");
            }
            maxy=temp2 - 1;
            maxx=fir-1;
            for(int i=0;i<=temp2;i++)
            {
                lis.Add(new List<List<int>>());
                for(int j=0;j<=fir;j++)
                    lis[i].Add(new List<int>());
            }
            int[,] arr = new int[105,105];
            for(int i=1;i<temp2;i++)
            {
                for(int j=1;j<fir; j++) arr[i,j] = dp[i,j];
            }
            /*for(int i=1;i<temp2 ;i++)//所有子節點
            {
                for(int j=1;j<fir;j++)
                {
                    if(i+1<temp2)
                        lis[i][j]
                }
            }*/
            Console.WriteLine("所有路徑：");
            if(maxx+maxy<8)
                dfs(1,1);
            Console.Write("最小路徑： [");
            int[,] parx = new int[300, 300];
            int[,] pary = new int[300, 300];
            for (int i = 0; i <= temp2; i++) dp[i, 0] = 100000;
            for(int i=0;i<=fir;i++) dp[0,i]=100000;
            
            for (int i = 1; i < temp2; i++)
            {
                for(int j=1;j<fir; j++)
                {
                    if(i==1&&j==1) continue;
                    if (dp[i, j - 1] + dp[i, j] < dp[i-1, j] + dp[i,j])
                    {
                        parx[i,j]=j-1; pary[i,j]=i;
                        dp[i,j]=dp[i, j - 1] + dp[i, j];
                        
                    }
                    else
                    {
                        parx[i,j]=j; pary[i,j]=i-1;
                        dp[i, j] = dp[i-1, j ] + dp[i, j];
                        
                    }
                }
            }
            int[] pathvalue = new int[300];
            int tmp = 0;
            int a=fir-1;
            int b=temp2-1;
            while(b!=0&&a!=0)
            {
                pathvalue[tmp] = arr[b,a];
                int test = a;
                a = parx[b,a] ;
                b=pary[b,test];
                tmp++;
            }
            for(int i=tmp-1; i>0; i--)
            {
                Console.Write(pathvalue[i]+",");
            }
            Console.WriteLine(pathvalue[0]+"]");
            Console.WriteLine("最小路徑和：" + dp[temp2 - 1, fir - 1]);
            Console.ReadKey();
        }
    }
}
