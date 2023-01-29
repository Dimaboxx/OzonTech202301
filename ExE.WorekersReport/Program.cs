using System;
using System.Collections.Generic;

namespace Ex5.Worekers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int ns = int.Parse(Console.ReadLine());
            for (int s = 0; s < ns; s++)
            {
                int nv = int.Parse(Console.ReadLine());

                int[] values = Array.ConvertAll(Console.ReadLine().Split(" "), e => int.Parse(e));
                HashSet<int> tmp = new HashSet<int>(nv);  
                bool resvalid = true;
                tmp.Add(values[0]);
                for (int i = 0; i < nv-1; i++)
                {
                    if (values[i] == values[i+1]) 
                    {
                        continue;
                    }
                    else
                    {
                        if (!tmp.Add(values[i+1]))
                        {
                            resvalid = false;
                            break;
                        }
                    }
                }

                if (resvalid)
                    Console.WriteLine("YES");
                else
                    Console.WriteLine("NO");

            }
        }
    }
}