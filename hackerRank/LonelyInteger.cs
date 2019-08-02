using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class LonelyInteger
    {
        public void Execute()
        {
            int[] a = { 0, 0, 1, 2, 1 };
            int resExp = 2;

            int total = lonelyinteger(a);

            if (resExp != total)
            {
                Console.WriteLine("Errore - Expected: " + resExp + " - now: " + total);
            }
            else
            {
                Console.WriteLine("Perfetto!!!");
                Console.WriteLine(total);
            }
        }

        static int lonelyinteger(int[] a)
        {
            int res = a.GroupBy(x => x).Where(e => e.Count() == 1).Select(b => b.Key).First();

            return res;
        }
    }
}
