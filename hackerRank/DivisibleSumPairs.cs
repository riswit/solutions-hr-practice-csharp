using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class DivisibleSumPairs
    {
        public void Execute()
        {

            //int n = 0;
            //int k = 5;
            //int[] ar = { 1, 2, 3, 4, 5, 6};

            int n = 0;
            int k = 3;
            int[] ar = { 1, 3, 2, 6, 1, 2 };

            int resExp = 5;

            int result = divisibleSumPairs(n, k, ar);

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

        static int divisibleSumPairs(int n, int k, int[] ar)
        {
            int numPairs = 0;

            for (int i = 0; i < ar.Length - 1; i++)
            {
                for (int j = i + 1; j < ar.Length; j++)
                {
                    if (i < j)
                    {
                        if ((ar[i] + ar[j]) % k == 0)
                        {
                            numPairs++;
                        }
                    }
                }
            }

            return numPairs;
        }

    }
}
