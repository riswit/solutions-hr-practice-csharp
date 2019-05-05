using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class CircularArrayRotation
    {
        public void Execute()
        {
            //int[] a = { 3, 4, 5 };
            //int k = 2;
            //int[] queries = { 1, 2 };
            //int[] resExp = { 5, 3 };

            //int[] a = { 1, 2, 3 };
            //int k = 1;
            //int[] queries = { 0, 1, 2 };
            //int[] resExp = { 3, 1, 2 };

            //int[] a = { 1, 2, 3 };
            //int k = 2;
            //int[] queries = { 0, 1, 2 };
            //int[] resExp = { 2, 3, 1 };

            //int[] a = { 1, 2, 3 };
            //int k = 4;
            //int[] queries = { 0, 1, 2 };
            //int[] resExp = { 3, 1, 2 };

            int[] a = { 1, 2, 3 };
            int k = 5;
            int[] queries = { 0, 1, 2 };
            int[] resExp = { 2, 3, 1 };

            int[] result = circularArrayRotation(a, k, queries);

            if (string.Join(" ", resExp) != string.Join(" ", result))
            {
                Console.WriteLine("Errore - Expected: " + string.Join(" ", resExp) + " - now: " + string.Join(" ", result));
            }
            else
            {
                Console.WriteLine("Perfetto!!!");
            }
        }

        static int[] circularArrayRotation(int[] a, int k, int[] queries)
        {
            List<int> res = new List<int>();
            int x = 0;
            int r = 0;

            foreach (int m in queries)
            {
                if (k > a.Length)
                {
                    k = (k % a.Length);
                }

                if ((m - k) >= 0)
                {
                    x = m - k;
                }
                else
                {
                    x = (a.Length) - (k - m);
                }

                res.Add(a[x]);
            }

            return res.ToArray();
        }

    }
}
