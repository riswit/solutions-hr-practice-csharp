using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class SortingBubbleSort
    {
        public void Execute()
        {
            int[] a = { 3, 2, 1 }; 

            countSwaps(a);
        }

        static void countSwaps(int[] a)
        {
            int n = a.Length;
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - 1; j++)
                {
                    if (a[j] > a[j + 1])
                    {
                        a = swap(a, j, j + 1);
                        count += 1;
                    }
                }
            }

            Console.WriteLine("Array is sorted in " + count.ToString() + " swaps.");
            Console.WriteLine("First Element: " + a[0].ToString());
            Console.WriteLine("Last Element: " + a[a.Length - 1].ToString());
        }

        static int[] swap(int[] a, int n1, int n2)
        {
            int temp = a[n1];
            a[n1] = a[n2];
            a[n2] = temp;

            return a;
        }
    }
}
