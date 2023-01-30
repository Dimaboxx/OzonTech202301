//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;

//namespace ExI.TasksManager
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] values = Array.ConvertAll(Console.ReadLine().Split(" "), e => int.Parse(e));
//            int nprocessor = values[0];
//            int ntasks = values[1];
//            int[] procpower = Array.ConvertAll(Console.ReadLine().Split(" "), e => int.Parse(e));
//            Array.Sort(procpower);
//            long[] times = new long[nprocessor];
//            long currenttime = 0;
//            int[][] Q = new int[ntasks][];
//            long totalenergy = 0;

//            long[] proctimer = new long[nprocessor];

//            for (int i = 0; i < ntasks; i++)
//            {
//                Q[i] = Array.ConvertAll(Console.ReadLine().Split(" "), e => int.Parse(e));
//            }

//            //if(nprocessor >= ntasks)
//            //{


//            //    int q = Q.Select(e => e[1]).OrderBy(e => e).First();
//            //    while
//            //    if(q < Q[ntasks][0])
//            //    {
//            //        totalenergy++;
//            //    }
//            //}






//            for (int t = 0; t < ntasks; t++)
//            {
//                 if (currenttime > Q[t][0])
//                    continue;
//                currenttime = Q[t][0];
//                for (int pr = 0; pr < nprocessor; pr++)
//                {
//                    if (proctimer[pr] <= currenttime)
//                    {
//                        proctimer[pr] = currenttime + Q[t][1];
//                        times[pr] += Q[t][1];
//                        break;
//                    }
//                }
//             }
//            for (int p = 0; p < nprocessor; p++)
//            {
//                totalenergy += times[p] * procpower[p];
//            }

//            Console.WriteLine(totalenergy);

//        }
//    }
//}