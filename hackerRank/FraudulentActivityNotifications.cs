using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace hackerRank
{
    class FraudulentActivityNotifications
    {
        public void Execute()
        {
            int d = 3;
            int[] expenditure = { 10, 20, 30, 40, 50 };
            int resExp = 1;

            //int d = 4;
            //int[] expenditure = { 1, 2, 3, 4, 4 };
            //int resExp = 0;

            //int d = 4;
            //int[] expenditure = { 1, 2, 3, 4, 4 };
            //int resExp = 633;

            bool testFile = false;
            int[] S = { };
            string dir = "";
            int n = 0;
            List<int> listElem = new List<int>();

            if (testFile)
            {
                dir = @"F:\test\hr\hackerRank\hackerRank\testFraudulentActivityNotifications\";
                var fileStream = new FileStream(dir + "input01.txt", FileMode.Open, FileAccess.Read);

                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    string line;
                    int i = 0;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (i == 0)
                        {
                            S = line.Split(' ').Select(Int32.Parse).ToArray();

                            d = S[1];
                        }
                        else if (i >= 1)
                        {
                            expenditure = line.Split(' ').Select(Int32.Parse).ToArray();
                            break;
                        }
                        i++;
                    }
                }

            }

            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            int result = activityNotifications(expenditure, d);

            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

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

        static int activityNotifications(int[] expenditure, int d)
        {
            int res = 0;
            int i = d;
            int ind = 0;
            int[] arrOrd = new int[d];

            Array.Copy(expenditure, arrOrd, d);
            arrOrd = sortArrUni(arrOrd);

            while (i < expenditure.Length)
            {
                if (expenditure[i] >= arrOrd[d / 2] + arrOrd[(d - 1) / 2])
                {
                    res += 1;
                }

                ind = Array.BinarySearch(arrOrd, expenditure[i - d]);
                Array.Copy(arrOrd, ind + 1, arrOrd, ind, d - ind - 1);
                ind = Array.BinarySearch(arrOrd, 0, d - 1, expenditure[i]);
                ind = ind >= 0 ? ind : ~ind;
                Array.Copy(arrOrd, ind, arrOrd, ind + 1, d - ind - 1);
                arrOrd[ind] = expenditure[i];

                i += 1;
            }

            return res;
        }

        static int[] sortArrUni(int[] arr)
        {
            int[] t = new int[arr.Length];
            return mergeSortUni(arr, t, 0, arr.Length - 1);
        }

        static int[] mergeSortUni(int[] arr, int[] t, int l, int r)
        {
            int m = 0;

            if (r > l)
            {
                m = (r + l) / 2;
                arr = mergeSortUni(arr, t, l, m);
                arr = mergeSortUni(arr, t, m + 1, r);

                arr = mergeUni(arr, t, l, m + 1, r);
            }
            return arr;
        }

        static int[] mergeUni(int[] arr, int[] t, int sx, int m, int rx)
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


        
        static int[][] sortArr2D(int[][] arr, int indexSort)
        {
            int[] t = new int[arr.Length];
            return mergeSort2D(arr, t, 0, arr.Length - 1, indexSort);
        }

        static int[][] mergeSort2D(int[][] arr, int[] t, int l, int r, int indexSort)
        {
            int m = 0;

            if (r > l)
            {
                m = (r + l) / 2;
                arr = mergeSort2D(arr, t, l, m, indexSort);
                arr = mergeSort2D(arr, t, m + 1, r, indexSort);

                arr = merge2D(arr, t, l, m + 1, r, indexSort);
            }
            return arr;
        }

        static int[][] merge2D(int[][] arr, int[] t, int sx, int m, int rx, int indexSort)
        {
            int i = sx;
            int j = m;
            int k = sx;

            while ((i <= m - 1) && (j <= rx))
            {
                if (arr[i][indexSort] <= arr[j][indexSort])
                {
                    t[k++] = arr[i++][indexSort];
                }
                else
                {
                    t[k++] = arr[j++][indexSort];
                }
            }

            while (i <= m - 1)
            {
                t[k++] = arr[i++][indexSort];
            }

            while (j <= rx)
            {
                t[k++] = arr[j++][indexSort];
            }

            for (i = sx; i <= rx; i++)
            {
                arr[i][indexSort] = t[i];
            }

            return arr;
        }
        


    }
}
