using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ExI.TasksManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] values = Array.ConvertAll(Console.ReadLine().Split(" "), e => int.Parse(e));
            int nprocessor = values[0];
            int ntasks = values[1];
            long totalenergy = 0;
            int[] procpower = Array.ConvertAll(Console.ReadLine().Split(" "), e => int.Parse(e));
            Array.Sort(values);
            PriorityQueue<Processor,long> processorWorkSet = new PriorityQueue<Processor,long>();
            PriorityQueue<Processor,long> processorFreeSet = new PriorityQueue<Processor,long>();

            for (int i = 0; i < nprocessor; i++)
            {
                Processor processor = new Processor { Id = i, Power = procpower[i] };
                processorFreeSet.Enqueue(processor, procpower[i]);
            }
            int[][] Tasks = new int[ntasks][];

            ///получается можно совместить
            for (int i = 0; i < ntasks; i++)
            {
                Tasks[i] = Array.ConvertAll(Console.ReadLine().Split(" "), e => int.Parse(e));
            }
            Processor currentProcessor;
            ;
            for (int ti = 0; ti < ntasks; ti++)
            {
                SystemTime.CurrentTime = Tasks[ti][0];
                //if (processorWorkSet.Count > 0) 
                while ( (processorWorkSet.Count > 0)&&(processorWorkSet.Peek().TimeEndTask <= SystemTime.CurrentTime) )
                {
                    Processor p = processorWorkSet.Dequeue();
                    processorFreeSet.Enqueue(p, p.Power);
                }
                if (processorFreeSet.Count > 0)
                {
                 currentProcessor = processorFreeSet.Dequeue();
                 currentProcessor.NextTaskTime = Tasks[ti][1];
                 processorWorkSet.Enqueue(currentProcessor, currentProcessor.TimeEndTask);   
                }
            }
            while (processorWorkSet.Count > 0)
            {
                Processor p = processorWorkSet.Dequeue();
                totalenergy += (p.Power * p.Totalworktime);
            }
            while (processorFreeSet.Count > 0)
            {
                Processor p = processorFreeSet.Dequeue();
                totalenergy += (p.Power * p.Totalworktime);
            }
            Console.WriteLine(totalenergy);

        }
    }

    public static class SystemTime
    {
        public static long CurrentTime;
    }




    public class Processor
    {
        public long Id { get; set; }
        public long Totalworktime { get; set; }

        public long TimeEndTask { get; set; }

        public bool Busy => !(TimeEndTask < SystemTime.CurrentTime);

        public long Power { get; set; }
        public Processor() 
        {
            TimeEndTask = -1;
        }

        public long NextTaskTime
        {
            set
            {
                TimeEndTask = SystemTime.CurrentTime + value;
                Totalworktime += value;
            }
        }
        public override string ToString()
        {
            return $" Id: {Id,3}, Power: {Power,6}, TimeEndTask: {TimeEndTask,7}, Totalworktime: {Totalworktime,7}"; 
        }
    }


    public class Task
    {
        public long TimeStart { get; set; }
        public long TimeWork { get; set; }

        public long TimeEnd => TimeStart + TimeWork;
    }

    public class myProcessorComparer : IComparer<Processor>
    {
        public int Compare(Processor? x, Processor? y)
        {

            if (x.TimeEndTask != y.TimeEndTask)
                return (int)(x.TimeEndTask - y.TimeEndTask);
            else
                return (int)(x.Power - y.Power);
       }
    }

}




//            long[] times = new long[nprocessor];
//            long currenttime = 0;
//            long totalenergy = 0;

//            long[] proctimer = new long[nprocessor];

//            int[][] Q = new int[ntasks][];
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