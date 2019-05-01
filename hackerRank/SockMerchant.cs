using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class SockMerchant
    {
        public void Execute()
        {
            int n = 0;
            int[] ar = { 10, 20, 20, 10, 10, 30, 50, 10, 20 };

            int resExp = 3;

            int result = sockMerchant(n, ar);

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

        static int sockMerchant(int n, int[] ar)
        {
            int numPairs = 0;

            for (int i = 0; i < ar.Length - 1; i++)
            {
                for (int j = i + 1; j < ar.Length; j++)
                {
                    if (ar[i] == ar[j] && ar[i] != -1 && ar[j] != -1)
                    {
                        numPairs++;
                        ar[i] = -1;
                        ar[j] = -1;
                    }
                }
            }

            return numPairs;
        }

    }
}
