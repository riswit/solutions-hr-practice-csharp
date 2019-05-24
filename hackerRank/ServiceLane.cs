using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class ServiceLane
    {
        public void Execute()
        {
            int[] widths = { 2, 3, 1, 2, 3, 2, 3, 3 };
            int[][] cases = new int[][] {
                new int[] { 0, 3 },
                new int[] { 4, 6 },
                new int[] { 6, 7 },
                new int[] { 3, 5 },
                new int[] { 0, 7 }
            };
            int[] resExp = { 1, 2, 3, 2, 1 };

            int[] result = serviceLane(widths, cases);

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

        static int[] serviceLane(int[] widths, int[][] cases)
        {
            int[] res = new int[cases.Length];
            int i = 0;
            int j = 0;
            int min = 0;

            for (int t = 0; t < cases.Length; t++)
            {
                i = cases[t][0];
                j = cases[t][1];

                min = 3;
                for (int y = i; y <= j; y++)
                {
                    if (widths[y] < min)
                    {
                        min = widths[y];
                    }
                }
                res[t] = min;
            }

            return res;
        }
    }
}
