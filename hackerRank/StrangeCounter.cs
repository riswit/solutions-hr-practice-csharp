using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class StrangeCounter
    {
        public void Execute()
        {
            //long t = 4;
            //long resExp = 6;

            long t = 14;
            long resExp = 8;

            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            long result = strangeCounter(t);

            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

            if (resExp != result)
            {
                Console.WriteLine("Errore - Expected: " + resExp + " - now: " + result);
            }
            else
            {
                Console.WriteLine("Perfetto!!!");
            }

            Console.WriteLine(result);
        }

        static long strangeCounter(long t)
        {
            bool isOk = false;
            long res = 0;
            int n = 1;
            long min = 1;
            long max = 3;

            while (!isOk)
            {
                if (t >= min && t <= max)
                {
                    res = (min + 2) - (t - min);
                    isOk = true;
                }
                else
                {
                    n++;
                    min = max + 1;
                    max = min + multTwo(n) - 1;
                }
            }

            return res;
        }

        static long multTwo(int n)
        {
            long res = 3;

            for (int i = 1; i < n; i++)
            {
                res = res * 2;
            }

            return res;
        }

        //long c = (long)(t / 3);
        //long initCol = (c * 3) - 2;
        //long diff = t - initCol;
        //res = (c * 3) - diff;

    }
}
