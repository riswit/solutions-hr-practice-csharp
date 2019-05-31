using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class _3DSurfaceArea
    {
        public void Execute()
        {
            //int[][] A = new int[][] {
            //    new int[] { 1 }
            //};
            //int resExp = 6;

            int[][] A = new int[][] {
                new int[] { 1, 3, 4 },
                new int[] { 2, 2, 3 },
                new int[] { 1, 2, 4 }
            };
            int resExp = 60;

            int result = surfaceArea(A);

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

        static int surfaceArea(int[][] A)
        {
            int res = 0;
            int sT = 0;
            int sR = 0;
            int sB = 0;
            int sL = 0;
            int sU = 0;
            int sD = 0;
            int rows = A.GetLength(0);
            int cols = 0;
            
            for (int i = 0; i < rows; i++)
            {
                cols = A[i].GetLength(0);

                for (int j = 0; j < cols; j++)
                {
                    sU = 1;
                    sD = 1;

                    sT = 0;
                    sR = 0;
                    sB = 0;
                    sL = 0;

                    if (i == 0)
                    {
                        sT = A[i][j];
                    }
                    else
                    {
                        if (A[i][j] > A[i - 1][j])
                        {
                            sT = A[i][j] - A[i - 1][j];
                        }
                    }

                    if (j == cols - 1)
                    {
                        sR = A[i][j];
                    }
                    else
                    {
                        if (A[i][j] > A[i][j + 1])
                        {
                            sR = A[i][j] - A[i][j + 1];
                        }
                    }

                    if (i == rows - 1)
                    {
                        sB = A[i][j];
                    }
                    else
                    {
                        if (A[i][j] > A[i + 1][j])
                        {
                            sB = A[i][j] - A[i + 1][j];
                        }
                    }

                    if (j == 0)
                    {
                        sL = A[i][j];
                    }
                    else
                    {
                        if (A[i][j] > A[i][j - 1])
                        {
                            sL = A[i][j] - A[i][j - 1];
                        }
                    }

                    res += (sU + sD + sT + sB + sR + sL);
                }
            }

            return res;
        }
    }
}
