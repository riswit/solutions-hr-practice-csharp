using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class MarkToys
    {
        public void Execute()
        {
            int k = 50;
            int[] prices = { 1, 12, 5, 111, 200, 1000, 10 };
            int resExp = 4;

            int result = maximumToys(prices, k);

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

        static int maximumToys(int[] prices, int k)
        {
            int res = 0;

            prices = prices.OrderBy(x => x).ToArray();
            int cost = 0;

            for (int i = 0; i < prices.Length; i++)
            {
                cost += prices[i];
                if (cost > k)
                {
                    break;
                }
                res += 1;
            }

            return res;
        }
    }
}
