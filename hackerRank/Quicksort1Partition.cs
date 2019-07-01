using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class Quicksort1Partition
    {
        public void Execute()
        {
            int[] arr = { 4, 5, 3, 7, 2 };
            int[] resExp = { 3, 2, 4, 5, 7, };

            int[] result = quickSort(arr);

            if (string.Join(" ", resExp) != string.Join(" ", result))
            {
                Console.WriteLine("Errore - Expected: " + string.Join(" ", resExp) + " - now: " + string.Join(" ", result));
            }
            else
            {
                Console.WriteLine("Perfetto!!!");
                Console.WriteLine(string.Join(" ", result));
            }
        }

        static int[] quickSort(int[] arr)
        {
            int p = arr[0];

            int[] arrLeft = arr.Where(e => e < p).ToArray();
            int[] arrEqual = arr.Where(e => e.Equals(p)).ToArray();
            int[] arrRight = arr.Where(e => e > p).ToArray();

            int[] res = arrLeft.Concat(arrEqual).Concat(arrRight).ToArray();

            return res;
        }
    }
}
