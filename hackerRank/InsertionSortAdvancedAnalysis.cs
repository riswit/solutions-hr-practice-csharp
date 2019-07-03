using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class InsertionSortAdvancedAnalysis
    {
        public void Execute()
        {
            //int[] arr = { 1, 1, 1, 2, 2 };
            //int resExp = 0;

            //int[] arr = { 4, 3, 2, 1 };
            //int resExp = 6;

            int[] arr = { 2, 1, 3, 1, 2 };
            int resExp = 4;

            int result = insertionSort(arr);

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

        static int insertionSort(int[] arr)
        {
            var t = from a in arr orderby a select a;

            if (arr.SequenceEqual(t) || arr.Length <= 1)
            {
                return 0;
            }

            int res = 0;
            int i = 1;
            int j = 0;
            int nextM = 0;
            int val = 0;
            int[] arrInit;
            int[] arrChange;
            int[] arrRight;

            while (i < arr.Length)
            {
                j = i;

                if (arr[i] < arr[i - 1])
                {
                    nextM = arr.Where((e, ind) => ind < i && e > arr[i]).Select((e, ind) => ind).First();

                    if (nextM > 1)
                    {

                    }

                    res += nextM;
                }

/*
                while (j > 0)
                {
                    if (arr[j] < arr[j - 1])
                    {
                        res += 1;
                        sw = arr[j];
                        arr[j] = arr[j - 1];
                        arr[j - 1] = sw;
                    }
                    else
                    {
                        break;
                    }

                    j -= 1;
                }
*/
                i += 1;
            }

            return res;
        }

        static int insertionSort_SLOW(int[] arr)
        {
            var t = from a in arr orderby a select a;

            if (arr.SequenceEqual(t) || arr.Length <= 1)
            {
                return 0;
            }

            int res = 0;
            int i = 1;
            int j = 0;
            int sw = 0;
            int val = 0;

            while (i < arr.Length)
            {
                j = i;
                val = arr[i];

                while (j > 0)
                {
                    if (arr[j] < arr[j - 1])
                    {
                        res += 1;
                        sw = arr[j];
                        arr[j] = arr[j - 1];
                        arr[j - 1] = sw;
                    }
                    else
                    {
                        break;
                    }

                    j -= 1;
                }

                i += 1;
            }

            return res;
        }

    }
}
