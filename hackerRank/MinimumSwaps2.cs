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
            int sw = 0;

            int iR = arr.Length - 1;

            int i = 0;
            int res = 0;

            while (i < arr.Length)
            {
                int arrValue = i + 1;

                if (arr[i] == arrValue)
                {
                    i++;
                    continue;
                }

                while (arr[iR] != arrValue)
                {
                    iR--;
                }

                if (iR != i)
                {
                    sw = arr[i];
                    arr[i] = arr[iR];
                    arr[iR] = sw;
                    res++;
                }

                iR = arr.Length - 1;
                i++;
            }
            return res;
        }
    }
}
