using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class MissingNumbers
    {
        public void Execute()
        {
            int m = 0;
            int[] arr = { 203, 204, 205, 206, 207, 208, 203, 204, 205, 206 };
            int[] brr = { 200, 203, 204, 204, 205, 206, 207, 205, 208, 203, 206, 205, 206, 204 };
            int[] resExp = { 200, 204, 205, 206 };

            int[] result = missingNumbers(arr, brr);

            if (string.Join(" ", resExp) != string.Join(" ", result))
            {
                Console.WriteLine("Errore - Expected: " + string.Join(" ", resExp) + " - now: " + string.Join(" ", result));
            }
            else
            {
                Console.WriteLine("Perfetto!!!");
            }

            Console.WriteLine(string.Join(" ", result));
        }

        static int[] missingNumbers(int[] arr, int[] brr)
        {
            List<int> res = new List<int>(); ;

            Dictionary<int, int> t1 = (from a in arr.GroupBy(x => x) orderby a.Key select a).ToDictionary(
            p => p.Key,
            p => p.Count()
            );

            Dictionary<int, int> t2 = (from a in brr.GroupBy(x => x) orderby a.Key select a).ToDictionary(
            p => p.Key,
            p => p.Count()
            );

            int lent2 = t2.Count();
            int v = 0;
            int k = 0;
            for (int i = 0; i < lent2; i++)
            {
                k = t2.ElementAt(i).Key;
                t1.TryGetValue(k, out v);
                if (v > 0)
                {
                    if (t1[k] != t2[k])
                    {
                        res.Add(k);
                    }
                }
                else
                {
                    res.Add(k);
                }
            }


            return res.ToArray();
        }
    }
}
