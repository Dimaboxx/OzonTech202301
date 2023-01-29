using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            for(int i = 0 ; i < n; i++)
            {
                var l = Console.ReadLine();
                var la = l.Split(" ");
                Console.WriteLine(int.Parse(la[0]) + int.Parse(la[1]));
            }
        }
    }
}