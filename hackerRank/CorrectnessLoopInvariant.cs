using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class CorrectnessLoopInvariant
    {
        public void Execute()
        {
            int n = 6;
            int[] A = new int[] { 4, 1, 3, 5, 6, 2 };

            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            insertionSort(A);

            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
        }

        public static void insertionSort(int[] A)
        {
            var j = 0;
            for (var i = 1; i < A.Length; i++)
            {
                var value = A[i];
                j = i - 1;
                while (j >= 0 && value < A[j])
                {
                    A[j + 1] = A[j];

                    j = j - 1;
                }
                A[j + 1] = value;
            }
            Console.WriteLine(string.Join(" ", A));
        }
    }
}
