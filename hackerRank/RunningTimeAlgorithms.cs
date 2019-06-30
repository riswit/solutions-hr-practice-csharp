using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class RunningTimeAlgorithms
    {
        public void Execute()
        {
            int[] arr = new int[] { 2, 1, 3, 1, 2 };
            int resExp = 4;

            int result = runningTime(arr);

            if (resExp != result)
            {
                Console.WriteLine("Errore - Expected: " + resExp + " - now: " + result);
            }
            else
            {
                Console.WriteLine("Perfetto!!!");
                Console.WriteLine(result);
            }
        }

        static int runningTime(int[] arr)
        {
            int res = 0;

            var j = 0;
            for (var i = 1; i < arr.Length; i++)
            {
                var value = arr[i];
                j = i - 1;
                while (j >= 0 && value < arr[j])
                {
                    arr[j + 1] = arr[j];

                    j = j - 1;
                    res++;
                }
                arr[j + 1] = value;
            }

            return res;
        }
    }
}
