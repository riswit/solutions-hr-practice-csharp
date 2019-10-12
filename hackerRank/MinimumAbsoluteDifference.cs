using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class MinimumAbsoluteDifference
    {
        public void Execute()
        {
            int[] arr = { -59, -36, -13, 1, -53, -92, -2, -96, -54, 75 };
            int resExp = 1;

            int result = minimumAbsoluteDifference(arr);

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

        static int minimumAbsoluteDifference(int[] arr)
        {
            int min = 2000000000;
            arr = arr.OrderBy(x => x).ToArray();
            for (int i = 1; i < arr.Length; i++)
            {
                int a = Math.Abs(arr[i] - arr[i - 1]);
                if (a < min)
                {
                    min = a;
                }
            }

            return min;
        }

        static int minimumAbsoluteDifference_7points(int[] arr)
        {
            int min = 2000000000;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    int a = Math.Abs(arr[i] - arr[j]);
                    if (a < min)
                    {
                        min = a;
                    }
                }
            }

            return min;
        }
    }
}
