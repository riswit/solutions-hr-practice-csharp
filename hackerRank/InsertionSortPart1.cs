using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class InsertionSortPart1
    {
        public void Execute()
        {
            //int n = 5;
            //int[] arr = new int[] { 1, 2, 4, 5, 3 };
            int n = 10;
            int[] arr = new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 1 };

            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            insertionSort1(n, arr);

            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
        }

        static void insertionSort1(int n, int[] arr)
        {
            int m = arr[arr.Length - 1];

            if (arr.Length == 1)
            {
                Console.WriteLine(String.Join(" ", arr));
                return;
            }

            for (int i = arr.Length - 2; i >= 0; i--)
            {
                if (m < arr[i])
                {
                    arr[i + 1] = arr[i];
                    Console.WriteLine(String.Join(" ", arr));
                    if (i == 0)
                    {
                        arr[i] = m;
                        Console.WriteLine(String.Join(" ", arr));
                    }
                }
                else
                {
                    arr[i + 1] = m;
                    Console.WriteLine(String.Join(" ", arr));
                    break;
                }

            }
        }
    }
}
