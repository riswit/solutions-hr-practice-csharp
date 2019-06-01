using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class AbsolutePermutation
    {
        public void Execute()
        {
            //int n = 3;
            //int k = 2;
            //int[] resExp = { -1 };

            //int n = 4;
            //int k = 2;
            //int[] resExp = { 3, 4, 1, 2 };

            //int n = 3;
            //int k = 0;
            //int[] resExp = { 1, 2, 3 };

            //int n = 2;
            //int k = 1;
            //int[] resExp = { 2, 1 };

            //int n = 3;
            //int k = 2;
            //int[] resExp = { -1 };

            //int n = 10;
            //int k = 1;
            //int[] resExp = { 2, 1, 4, 3, 6, 5, 8, 7, 10, 9 };

            //int n = 8;
            //int k = 2;
            //int[] resExp = { 3, 4, 1, 2, 7, 8, 5, 6 };

            int n = 18;
            int k = 3;
            int[] resExp = { 4, 5, 6, 1, 2, 3, 10, 11, 12, 7, 8, 9, 16, 17, 18, 13, 14, 15 };

            int[] result = absolutePermutation(n, k);

            if (string.Join(" ", resExp) != string.Join(" ", result))
            {
                Console.WriteLine("Errore - Expected: " + string.Join(" ", resExp) + " - now: " + string.Join(" ", result));
            }
            else
            {
                Console.WriteLine("Perfetto!!!");
                Console.WriteLine(string.Join(" ", result));
            }
        }

        static int[] absolutePermutation(int n, int k)
        {
            if (n % 2 != 0 && k > 0)
            {
                return new int[] { -1 };
            }

            int[] res = { };
            if (k == 0)
            {
                res = new int[n];
                for (int i = 0; i < n; i++)
                {
                    res[i] = i + 1;
                }

                return res;
            }

            if (n % (k * 2) == 0)
            {
                res = new int[n];
                int range = k * 2;
                int c = 0;
                int j = 0;

                for (int i = 0; i < (n / range); i++)
                {
                    for (j = 1; j <= k; j++)
                    {
                        res[c] = j + (i * range) + k;
                        c++;
                    }
                    for (j = 1; j <= k; j++)
                    {
                        res[c] = j + (i * range);
                        c++;
                    }
                }

                return res;
            }

            return new int[] { -1 };
        }
    }
}
