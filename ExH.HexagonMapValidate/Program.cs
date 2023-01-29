using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace ExH.HexagonMapValidate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numset = int.Parse(Console.ReadLine());
            for (int set = 0; set < numset; set++)
            {
                int[] values = Array.ConvertAll(Console.ReadLine().Split(" "), e => int.Parse(e));
                int nmaprow = values[0];
                int nmapcol = values[1];
                char[][]map = new char[nmaprow][];
                HashSet<Char> mapFields= new HashSet<Char>();   
                for (int i = 0; i < nmaprow; i++)
                {
                    map[i] = Console.ReadLine().ToCharArray();
                }
                bool valid = true;
                for (int r = 0; r < nmaprow; r++)
                {
                    for (int c = r % 2; c < nmapcol; c += 2)
                    {
                        if (map[r][c] != '5')
                        {
                            if (valid)
                            {
                                var f = map[r][c]  ;
                                valid = mapFields.Add(f);
                                Validate(r, c, map, map[r][c]);
                             }

                            
                         }

                    }

                }
                if(valid)
                {
                    Console.WriteLine("YES");
                }
                else 
                {
                    Console.WriteLine("NO");
                }


            }
    

        }

 
        private static void Validate(int r, int c, char[][] map, char color)
        {
            if(map[r][c] != color)
            {
                return;
            }
            map[r][c] = '5';
            /// Rigth
            if (c < map[0].Length -2)
            {
              Validate(r, c + 2, map, color);
            }
            //Ritgh-Down
            if (r < map.Length - 1 && c < map[0].Length - 1)
            {
                Validate(r + 1, c + 1, map, color); 
            }
            //Left-Down
            if (r < map.Length - 1 && c > 0)
            {
                Validate(r + 1, c - 1, map, color);
            }
            //Rigth-Up
            if (r > 0 && c < map[0].Length - 1)
            {
                Validate(r - 1, c + 1, map, color);
            }
            //Left-Up
            if (r > 0 && c >  0)
            {
                Validate(r - 1, c - 1, map, color);
            }
            //Left
            if (c > 1)
            {
                Validate(r, c - 2, map, color);
            }
        }
    }
}