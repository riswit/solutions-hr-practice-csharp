using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class FraudulentActivityNotifications
    {
        public void Execute()
        {
            //int d = 5;
            //int[] expenditure = { 2, 3, 4, 2, 3, 6, 8, 4, 5 };
            //int resExp = 2;

            int d = 4;
            int[] expenditure = { 1, 2, 3, 4, 4 };
            int resExp = 0;

            int result = activityNotifications(expenditure, d);

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

        static int activityNotifications(int[] expenditure, int d)
        {
            int res = 0;
            int i = d;
            bool isOdd = false;

            if (d % 2 != 0)
            {
                isOdd = true;
            }

            int[] arr = sortArr(expenditure);
            int[][] t1 = arr.Select((e, ind) => new int[2] { e, ind }).ToArray();
            int[] arrM;
            int m = 0;

            while (i < expenditure.Length)
            {
                arrM = t1.Where((e, ind) => e[1] >= i - d && e[1] < i).Select(p => p[0]).ToArray();
                m = 0;

                if (isOdd)
                {
                    m = arrM[arrM.Length / 2];
                }
                else
                {
                    m = (arrM[(arrM.Length / 2) - 1] + arrM[(arrM.Length / 2) + 1]) / 2;
                }

                if (expenditure[i] >= m * 2)
                {
                    res += 1;
                }

                i += 1;
            }

            return res;
        }

        static int[] sortArr(int[] arr)
        {
            int[] t = new int[arr.Length];
            return mergeSort(arr, t, 0, arr.Length - 1);
        }

        static int[] mergeSort(int[] arr, int[] t, int l, int r)
        {
            int m = 0;

            if (r > l)
            {
                m = (r + l) / 2;
                arr = mergeSort(arr, t, l, m);
                arr = mergeSort(arr, t, m + 1, r);

                arr = merge(arr, t, l, m + 1, r);
            }
            return arr;
        }

        static int[] merge(int[] arr, int[] t, int sx, int m, int rx)
        {
            int i = sx;
            int j = m;
            int k = sx;

            while ((i <= m - 1) && (j <= rx))
            {
                if (arr[i] <= arr[j])
                {
                    t[k++] = arr[i++];
                }
                else
                {
                    t[k++] = arr[j++];
                }
            }

            while (i <= m - 1)
            {
                t[k++] = arr[i++];
            }

            while (j <= rx)
            {
                t[k++] = arr[j++];
            }

            for (i = sx; i <= rx; i++)
            {
                arr[i] = t[i];
            }

            return arr;
        }



    }
}
