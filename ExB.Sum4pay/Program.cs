using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ns = int.Parse(Console.ReadLine());
            for (int i = 0; i < ns; i++)
            {
                int sum = 0;
                var nd = int.Parse(Console.ReadLine());
                var d = Console.ReadLine();
                var da = d.Split(" ");
                int[] aint = new int[nd];
                for (int j = 0; j < nd; j++)
                {
                    aint[j] = int.Parse(da[j]);
                }
                Array.Sort(aint);
                int k = 1;

                int prev = 0;
                for (int s = 0; s < nd; s++)
                {
                    if (aint[s] == prev)
                    {
                        k++;
                    }
                    else
                    {
                        k = 1;
                    }

                    if (k < 3)
                    {
                        sum = sum + aint[s];
                        prev = aint[s];
                    }
                    else
                    {
                        k = 1;
                        prev = 0;
                    }
                }
                Console.WriteLine(sum);
            }



        }
    }
}
