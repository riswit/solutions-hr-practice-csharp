using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class LilyHomework
    {
        public void Execute()
        {
            //long[] arr = { 7, 3, 0, 4, 1, 6, 5, 2 };
            //int resExp = 5;

            long[] arr = { 3, 4, 2, 5, 1 };
            int resExp = 2;

            int result = lilysHomework(arr);

            if (resExp != result)
            {
                Console.WriteLine("Errore - Expected: " + resExp + " - now: " + result);
            }
            else
            {
                Console.WriteLine(result);
                Console.WriteLine("Perfetto!!!");
            }
        }

        static int lilysHomework(long[] arr)
        {
            int res = 0;
            int resRev = 0;
            long[] arrR = new long[arr.Length];
            long[] ordered = new long[arr.Length];
            long[] orderedRev = new long[arr.Length];
            arr.CopyTo(arrR, 0);
            arr.CopyTo(ordered, 0);
            arr.CopyTo(orderedRev, 0);
            Array.Sort(ordered);
            orderedRev = orderedRev.OrderByDescending(c => c).ToArray();
            long ind = 0;
            long temp = 0;
            Dictionary<long, long> dict = new Dictionary<long, long>();
            Dictionary<long, long> dictRev = new Dictionary<long, long>();

            for (int i = 0; i < arr.Length; i++)
            {
                dict.Add(arr[i], i);
                dictRev.Add(arr[i], i);
            }

            for (int i = 0; i < ordered.Length; i++)
            {
                if (!arr[i].Equals(ordered[i]))
                {
                    res += 1;

                    dict.TryGetValue(ordered[i], out ind);
                    dict[arr[i]] = ind;

                    temp = arr[i];
                    arr[i] = arr[ind];
                    arr[ind] = temp;
                }
            }

            for (int i = 0; i < orderedRev.Length; i++)
            {
                if (!arrR[i].Equals(orderedRev[i]))
                {
                    resRev += 1;

                    dictRev.TryGetValue(orderedRev[i], out ind);
                    dictRev[arrR[i]] = ind;

                    temp = arrR[i];
                    arrR[i] = arrR[ind];
                    arrR[ind] = temp;
                }
            }

            if (resRev < res)
            {
                return resRev;
            }
            return res;
        }

        static int lilysHomework_SLOW(long[] arr)
        {
            int resMin = 0;
            long min = 0;
            int resMax = 0;
            long max = 0;
            long t = 0;
            long[] arrR = new long[arr.Length];
            arr.CopyTo(arrR, 0);

            for (int i = 0; i < arr.Length - 1; i++)
            {
                min = arr.Where((e, ind) => ind >= i).Min();

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] == min)
                    {
                        t = arr[i];
                        arr[i] = min;
                        arr[j] = t;
                        resMin += 1;
                        break;
                    }
                }
            }

            for (int i = 0; i < arrR.Length - 1; i++)
            {
                max = arrR.Where((e, ind) => ind >= i).Max();

                for (int j = i + 1; j < arrR.Length; j++)
                {
                    if (arrR[j] == max)
                    {
                        t = arrR[i];
                        arrR[i] = max;
                        arrR[j] = t;
                        resMax += 1;
                        break;
                    }
                }
            }

            if (resMax < resMin)
            {
                return resMax;
            }
            return resMin;
        }
    }
}
