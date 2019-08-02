using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class MaximumSubarraySum
    {
        public void Execute()
        {
            long[] a = { 3, 3, 9, 9, 5 };
            long m = 7;
            long resExp = 10;

            long result = maximumSum(a, m);

            if (resExp != result)
            {
                Console.WriteLine("Errore - Expected: " + resExp + " - now: " + result);
            }
            else
            {
                Console.WriteLine("Perfetto!!!");
                Console.WriteLine(result);
            }

        }

        static long maximumSum(long[] a, long m)
        {
            long res = 0;

            Array.Sort(a);

            long[] r = Array.FindAll(a, e => e <= m);

            for (int i = r.Length - 1; i >= 0; i--)
            {

            }

            return res;
        }
    }
}
