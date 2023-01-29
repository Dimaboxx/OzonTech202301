using System;


namespace Ex3.Commands
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ns = int.Parse(Console.ReadLine());

            for (int s = 0; s < ns; s++)
            {
                int np = int.Parse(Console.ReadLine());
                var sp = Console.ReadLine().Split(" ");
                int[] ap = new int[np];
                ap = Array.ConvertAll(sp, e => int.Parse(e));
                for (int p = 0; p < np-1; p++)
                {
                    if (ap[p] < 0)
                    {
                        continue;
                    }
                    int pdiff = p+1;
                    while ((ap[pdiff] < 0) && (pdiff < np))
                        pdiff++;
                    int diff = Math.Abs(ap[p] - ap[pdiff]);
                    
                    int tempdiff;

                    for (int i = p+1; i < np; i++)
                    {
                        if (ap[i] < 0)
                        {
                            continue;
                        }
                        tempdiff = Math.Abs(ap[p] - ap[i]);
                        if (tempdiff < diff)
                        {
                            diff = tempdiff;
                            pdiff = i;
                        }

                    }
                    Console.WriteLine($"{p+1} {pdiff+1}");
                    ap[pdiff] = -1;

                }
               if(s<ns-1) Console.WriteLine();
            }
        }
    }
}