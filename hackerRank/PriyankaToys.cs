using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class PriyankaToys
    {
        public void Execute()
        {
            int[] w = new int[] { 1, 2, 3, 21, 7, 12, 14, 21 };
            int resExp = 4;

            int result = toys(w);

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

        static int toys(int[] w)
        {
            w = w.OrderBy(x => x).ToArray();

            int k = 4;
            int containers = 1;
            int range = w[0];

            for (int i = 1; i < w.Length; i++)
            {
                if (w[i] > range + k)
                {
                    containers += 1;
                    range = w[i];
                }
            }

            return containers;
        }
    }
}
