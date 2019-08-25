using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class MinimumSwaps2
    {
        public void Execute()
        {
            int[] arr = { 4, 3, 1, 2 };
            int resExp = 3;

            int result = minimumSwaps(arr);

            if (resExp != result)
            {
                Console.WriteLine("Errore - Expected: " + resExp + " - now: " + result);
            }
            else
            {
                Console.WriteLine(result);
                Console.WriteLine("Perfetto!!!");
            }

            Console.WriteLine(result);
        }

        static int minimumSwaps(int[] arr)
        {
            int res = 0;
            int sw = 0;
            int i = 0;

            for (i = 0; i < arr.Length; i++)
            {
                if (arr[i] == (i + 1))
                {
                    continue;
                }
                sw = arr[i];
                arr[i] = arr[arr[i] - 1];
                arr[arr[i] - 1] = sw;

                res += 1;
                i--;
            }

            return res;
        }
    }
}
