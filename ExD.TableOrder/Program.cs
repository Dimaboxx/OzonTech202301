using System;
using System.Collections;

namespace Ex4.TableOrder
{

    public class Program
    {
        static void Main(string[] args)
        {
            int NumSets = int.Parse(Console.ReadLine());
            int[] a = new int[NumSets];

            for (int s = 0; s < NumSets; s++)
            {
                Console.ReadLine();
                var arraydementions = Array.ConvertAll(Console.ReadLine().Split(" "), e => int.Parse(e));
                int nline = arraydementions[0];
                int nvalues = arraydementions[1]+1;

                int[][] table = new int[nline][];
                //Array.Fill(table, new int[arraydementions[0]]);
                for (int ea = 0; ea < nline; ea++)
                {
                    table[ea] = new int[nvalues];
                    table[ea][0] = ea;
                    Array.ConvertAll(Console.ReadLine().Split(" "), e => int.Parse(e)).CopyTo(table[ea],1);
                }
                int numclick = int.Parse(Console.ReadLine());
                int[] click = Array.ConvertAll(Console.ReadLine().Split(" "), e => int.Parse(e));

                for (int c = 0; c < numclick; c++)
                {
                    for (int ea = 0; ea < nline; ea++)
                    {
                        table[ea][0] = ea;
                    }
                    Array.Sort(table, new CompareLine(click[c]));
                }


                //Print

                for (int l = 0; l < nline; l++)
                {
                    for (int v = 1; v < nvalues; v++)
                    {
                        Console.Write(table[l][v]);
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();

            }
            //Array.Sort();
        }
    }


    public class CompareLine : IComparer
    {
        private int na;

        public int Compare(object? x, object? y)
        {
            if (((int[])x)[na] < ((int[])y)[na]) return -1;
            if (((int[])x)[na] > ((int[])y)[na]) return 1;
            return ((int[])x)[0] - ((int[])y)[0];
        }
        public CompareLine(int n)
        {
            na = n;
        }
    }
}