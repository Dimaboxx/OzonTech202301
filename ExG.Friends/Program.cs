using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ExG.Friends
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] envvar = Array.ConvertAll(Console.ReadLine().Split(" "), e => int.Parse(e));
            int npeople = envvar[0];
            int npair = envvar[1];
           SortedDictionary<int, int>[] posiblefrends = new SortedDictionary<int, int>[npeople];
            HashSet<int>[] peoples = new HashSet<int>[npeople];


            for (int i = 0; i < npeople; i++)
            {
                posiblefrends[i] = new SortedDictionary<int, int>();
                peoples[i] = new HashSet<int>(5);
            }
            for (int i = 0; i < npair; i++)
            {
                int[] pair = Array.ConvertAll(Console.ReadLine().Split(" "), e => int.Parse(e));
                peoples[pair[0].ToZeroBase()].Add(pair[1].ToZeroBase());
                peoples[pair[1].ToZeroBase()].Add(pair[0].ToZeroBase());
            }
           StringBuilder sb = new StringBuilder();
           
            for (int i = 0; i < npeople; i++)
            {
                foreach(int friends in peoples[i])
                {
                    foreach (int pf in peoples[friends])
                        addToDist(posiblefrends[i],(pf));
                }
                posiblefrends[i].Remove(i);
                foreach (int peoplefriends in peoples[i])
                    posiblefrends[i].Remove(peoplefriends); 

                if (posiblefrends[i].Count == 0)
                {
                    sb.AppendFormat("{0}", 0);
                }
                else
                {
                    if (posiblefrends[i].Count > 1)
                    {

                        var vls = posiblefrends[i].Values.Max();
                        foreach (var v in posiblefrends[i])
                        {
                            if (v.Value == vls)
                                sb.AppendFormat("{0} ", v.Key.ToOneBase());
                        }
                    }
                    else
                        foreach (var pf in posiblefrends[i])
                        {
                            sb.AppendFormat("{0} ", pf.Key.ToOneBase());
                        }
                }
                sb.AppendLine();
            }
            Console.Write(sb.ToString());
        }
 
        public static void addToDist(SortedDictionary<int, int> dict, int key)
        {

            if (dict.ContainsKey(key))
                dict[key] = dict[key] + 1;
            else
                dict.Add(key, 1);
        }   
    }



    public static class MyExtensions
    {
        public static int ToZeroBase(this int v)
        {
            return v - 1;
        }
        public static int ToOneBase(this int v)
        {
            return v + 1;
        }
    }
}
