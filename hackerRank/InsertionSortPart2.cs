using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class InsertionSortPart2
    {
        public void Execute()
        {
            int n = 6;
            int[] arr = new int[] { 1, 4, 3, 5, 6, 2 };

            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            insertionSort2(n, arr);

            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
        }

        static void insertionSort2(int n, int[] arr)
        {
            if (arr.Length == 1)
            {
                Console.WriteLine(String.Join(" ", arr));
                return;
            }

            int c = 0;

            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (arr[j] < arr[j - 1])
                    {
                        c = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = c;
                    }
                }
                Console.WriteLine(String.Join(" ", arr));
            }
        }

    }
}
