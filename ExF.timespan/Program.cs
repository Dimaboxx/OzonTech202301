using System;
using System.Collections;

namespace Ex6.F
{
    public class Programm
    {
        public static void Main(string[] args) 
        {
            int ns = int.Parse(Console.ReadLine());
            for (int i = 0; i < ns; i++)
            {
                var s = Console.ReadLine();
                int nts = int.Parse(s);
                bool valid = true;
                TimeOnly[][] toaTs = new TimeOnly[nts][];
                for (int its = 0; its < nts; its++)
                {
                    if (valid)
                        toaTs[its] = Array.ConvertAll(Console.ReadLine().Split("-"), (e) => { TimeOnly r; valid = valid && MyTOTryParse(e, out r); return r; });
                    else
                        Console.ReadLine();
                }
                if (valid)
                {
                    Array.Sort(toaTs, new CompareTOA() );

                    for (int jts = 0; jts < nts-1; jts++)
                    {
                         valid = toaTs[jts][0] <= toaTs[jts][1] && toaTs[jts][1] < toaTs[jts+1][0];
                        if (!valid) break;
                    }
                    if(valid)
                    valid = toaTs[nts-1][0] <= toaTs[nts-1][1] ;

                }
                if (valid)
                    Console.WriteLine("YES");
                else
                    Console.WriteLine("NO");

            }
        }

        public static bool MyTOTryParse(string s, out TimeOnly t)
        {
            bool valid ;
            int[] tp = Array.ConvertAll(s.Split(":"), e => int.Parse(e));
            valid = (tp[0] >= 0 && tp[0] < 24) && 
                    (tp[1] >= 0 && tp[1] < 60) && 
                    (tp[2] >= 0 && tp[2] < 60);
            if (valid)
                t = new TimeOnly(tp[0], tp[1], tp[2]);
            else 
                t = TimeOnly.MinValue;
            return valid;
        }
    }

    public class CompareTOA : IComparer
    {
        public int Compare(object? x, object? y)
        {
            return ((TimeOnly[])x)[0].CompareTo(((TimeOnly[])y)[0]);
        }
    }

    


}


