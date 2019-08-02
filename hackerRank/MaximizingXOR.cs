using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class MaximizingXOR
    {
        public void Execute()
        {
            int l = 10;
            int r = 15;
            int resExp = 7;

            int result = maximizingXor(l, r);

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

        static int maximizingXor(int l, int r)
        {
            int res = 0;
            int c = 0;

            for (int i = l; i <= r; i++)
            {
                for (int j = i; j <= r; j++)
                {
                    c = i ^ j;
                    if (c > res)
                    {
                        res = c;
                    }
                }
            }

            return res;
        }
    }
}
