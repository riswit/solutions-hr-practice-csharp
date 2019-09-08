using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    //https://www.hackerrank.com/challenges/minimum-loss/problem
    class MinimumLoss
    {
        public void Execute()
        {
            long[] price = { 20, 7, 8, 2, 5 };
            int resExp = 2;

            long result = minimumLoss(price);

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

        static long minimumLoss(long[] price)
        {
            long min = 1000000000;
            long c = 0;
            Dictionary<long, int> t = new Dictionary<long, int>();

            for (int i = 0; i < price.Length; i++)
            {
                t.Add(price[i], i);
            }

            long[] p = price.OrderBy(x => x).ToArray();

            for (int i = 0; i < p.Length - 1; i++)
            {
                if (t[p[i + 1]] < t[p[i]] && p[i + 1] > p[i])
                {
                    c = p[i + 1] - p[i];
                    if (c < min) { min = c; }
                }
            }


            return min;
        }

        static long minimumLoss_Slow_17Points(long[] price)
        {
            long min = 1000000000;
            long c = 0;

            for (int i = 0; i < price.Length - 1; i++)
            {
                for (int j = i + 1; j < price.Length; j++)
                {
                    if (price[i] > price[j])
                    {
                        c = price[i] - price[j];
                        if (c < min) { min = c; }
                    }
                }
            }

            return min;
        }
    }
}
