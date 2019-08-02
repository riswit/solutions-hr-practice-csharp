using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class SumVsXOR
    {
        public void Execute()
        {
            long n = 50;
            long resExp = 8;

            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            long result = sumXor(n);

            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

            if (resExp != result)
            {
                Console.WriteLine("Errore - Expected: " + resExp + " - now: " + result);
            }
            else
            {
                Console.WriteLine(result);
                Console.WriteLine("Perfetto!!!");
            }
        }

        static long sumXor(long n)
        {
            if (n == 0)
            {
                return 1;
            }
            double res = 0;

            string binary = Convert.ToString(n, 2);

            res = binary.Where(e => e == '0').Count();

            res = Math.Pow(2, res);

            return Convert.ToInt64(res);
        }
    }
}
