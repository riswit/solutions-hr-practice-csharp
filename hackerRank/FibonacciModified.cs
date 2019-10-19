using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace hackerRank
{
    class FibonacciModified
    {
        public void Execute()
        {
            int t1 = 0;
            int t2 = 1;
            int n = 10;
            string resExp = "84266613096281243382112";

            string result = fibonacciModified(t1, t2, n);

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

        static string fibonacciModified(BigInteger t1, BigInteger t2, int n)
        {
            BigInteger temp = new BigInteger();
            for (int i = 3; i <= n; i++)
            {
                temp = t2;
                t2 = t2 * t2;
                t2 = t2 + t1;
                t1 = temp;
            }
            return t2.ToString();
        }
    }
}
