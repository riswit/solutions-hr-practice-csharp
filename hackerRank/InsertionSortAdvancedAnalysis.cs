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

            //int[] arr = { 2, 1, 3, 1, 2 };
            //int resExp = 4;

            //int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 3 };
            //int resExp = 6;

            int[] arr = { 12, 15, 1, 5, 6, 14, 11 };
            int resExp = 10;

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

            int[] arrInit;
            int[] arrChange;
            int[] arrRight;
            int[] arrE = new int[1];

            while (i < arr.Length)
            {
                j = i;

                if (arr[i] < arr[i - 1])
                {
                    arrE[0] = arr[i];
                    arrChange = arr.Where((e, ind) => ind < i && e > arr[i]).ToArray();
                    //arrInit = arr.TakeWhile((e, ind) => ind < (i - arrChange.Count())).ToArray();
                    Array.Copy(arr, arrInit, arr.Length - )
                    arrRight = new int[arr.Count() - i - 1];
                    if (arr.Count() - i - 1 > 0)
                    {
                        Array.Copy(arr, i + 1, arrRight, 0, arrRight.Count());
                    }

                    arr = (arrInit.Concat(arrE).Concat(arrChange).Concat(arrRight)).ToArray();

                    res += arrChange.Count();
                }

                i += 1;
            }

            return res;
        }

        static int insertionSort_WIP(int[] arr)
        {
            var o = from a in arr orderby a select a;

            if (arr.SequenceEqual(o) || arr.Length <= 1)
            {
                return 0;
            }

            int res = 0;

            bool ordered = false;
            int m = arr.Count() / 2;
            int c = 0;
            List<int[]> listArrOrig = new List<int[]>();
            List<int[]> listArrOrd = new List<int[]>();

            var leftOrd = o.TakeWhile((e, i) => i < m);
            var leftOrig = arr.TakeWhile((e, i) => i < m);

            var RightOrd = o.Where((e, i) => i >= m);
            var RightOrig = arr.Where((e, i) => i >= m);

            listArrOrig.Add(leftOrig.ToArray());
            listArrOrd.Add(leftOrd.ToArray());

            while (m > 1)
            {

                if (leftOrig.SequenceEqual(leftOrd))
                {
                    break;
                }

                m = leftOrd.Count() / 2;
                c += 1;
            }

            return res;
        }

        static int getShiftsSortArray(int[] arr, int res = 0)
        {
            int i = 1;
            int j = 0;
            int sw = 0;
            int val = 0;
            int max = 0;

            while (i < arr.Length)
            {
                j = i;
                val = arr[i];

                if (val > max)
                {
                    max = val;
                }

                while (j > 0 && arr[j] < arr[j - 1])
                {
                    res += 1;

                    sw = arr[j];
                    arr[j] = arr[j - 1];
                    arr[j - 1] = sw;

                    j -= 1;
                }

                i += 1;
            }

            return res;
        }

        static int insertionSort_SLOW3(int[] arr)
        {
            var t = from a in arr orderby a select a;

            if (arr.SequenceEqual(t) || arr.Length <= 1)
            {
                return 0;
            }

            int res = 0;
            int i = 1;
            int j = 0;

            int[] arrE = new int[1];
            int ns = 0;

            List<int> lt = arr.ToList();
            int val = 0;

            while (i < lt.Count())
            {
                val = lt[i];

                if (val < lt[i - 1])
                {
                    ns = lt.Where((e, ind) => ind < i && e > val).Count();

                    lt.RemoveAt(i);
                    lt.Insert(i - ns, val);

                    res += ns;
                }

                i += 1;
            }

            return res;
        }

        static int insertionSort_SLOW2(int[] arr)
        {
            var t = from a in arr orderby a select a;

            if (arr.SequenceEqual(t) || arr.Length <= 1)
            {
                return 0;
            }

            int res = 0;
            int i = 1;
            int j = 0;

            int[] arrInit;
            int[] arrChange;
            int[] arrRight;
            int[] arrE = new int[1];

            while (i < arr.Length)
            {
                j = i;

                if (arr[i] < arr[i - 1])
                {
                    arrE[0] = arr[i];
                    arrChange = arr.Where((e, ind) => ind < i && e > arr[i]).ToArray();
                    arrInit = arr.TakeWhile((e, ind) => ind < (i - arrChange.Count())).ToArray();
                    arrRight = new int[arr.Count() - i - 1];
                    if (arr.Count() - i - 1 > 0)
                    {
                        Array.Copy(arr, i + 1, arrRight, 0, arrRight.Count());
                    }

                    arr = (arrInit.Concat(arrE).Concat(arrChange).Concat(arrRight)).ToArray();

                    res += arrChange.Count();
                }

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
