using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class FindMedian
    {
        public void Execute()
        {
            int[] arr = { 0, 1, 2, 4, 6, 5, 3 };
            int resExp = 3;

            int result = findMedian(arr);

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

        static int findMedian(int[] arr)
        {
            int m = arr.Count() / 2;

            int res = (from a in arr orderby a select a).ElementAt(m);

            return res;
        }
    }
}
