using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class TwoDArrayDS
    {
        public void Execute()
        {
            //int[][] arr = new int[][] {
            //    new int[] { 1, 1, 1, 0, 0, 0 },
            //    new int[] { 0, 1, 0, 0, 0, 0 },
            //    new int[] { 1, 1, 1, 0, 0, 0 },
            //    new int[] { 0, 0, 2, 4, 4, 0 },
            //    new int[] { 0, 0, 0, 2, 0, 0 },
            //    new int[] { 0, 0, 1, 2, 4, 0 }
            //};
            //int resExp = 19;

            int[][] arr = new int[][] {
                new int[] { -1, -1, 0, -9, -2, -2 },
                new int[] { -2, -1, -6, -8, -2, -5 },
                new int[] { -1, -1, -1, -2, -3, -4 },
                new int[] { -1, -9, -2, -4, -4, -5 },
                new int[] { -7, -3, -3, -2, -9, -9 },
                new int[] { -1, -3, -1, -2, -4, -5 }
            };
            int resExp = -6;

            int result = hourglassSum(arr);

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

        static int hourglassSum(int[][] arr)
        {
            int max = 0;
            int c = 0;

            for (int i = 1; i <= 4; i++)
            {
                for (int j = 1; j <= 4; j++)
                {
                    c = arr[i - 1][j - 1] + arr[i - 1][j] + arr[i - 1][j + 1]
                        + arr[i][j]
                        + arr[i + 1][j - 1] + arr[i + 1][j] + arr[i + 1][j + 1];

                    if (i == 1 && j == 1)
                    {
                        max = c;
                    }
                    if (c > max)
                    {
                        max = c;
                    }
                }
            }

            return max;
        }
    }
}
