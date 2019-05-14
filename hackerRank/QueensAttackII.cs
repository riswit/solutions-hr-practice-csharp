using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class QueensAttackII
    {
        public void Execute()
        {
            int n = 8;
            int k = 0;
            int r_q = 4;
            int c_q = 7;
            int[][] obstacles = new int[][] {
                new int[] { 5, 5 },
                new int[] { 4, 2 },
                new int[] { 2, 3 }
            };
            int resExp = 27;

            //int n = 5;
            //int k = 3;
            //int r_q = 4;
            //int c_q = 3;
            //int[][] obstacles = new int[][] {
            //    new int[] { 5, 5 },
            //    new int[] { 4, 2 },
            //    new int[] { 2, 3 }
            //};
            //int resExp = 10;

            //int n = 4;
            //int k = 0;
            //int r_q = 4;
            //int c_q = 4;
            //int[][] obstacles = new int[][] {
            //    new int[] { 1, 5 },
            //    new int[] { 2, 4 },
            //    new int[] { 3, 3 },
            //    new int[] { 4, 2 },
            //    new int[] { 5, 1 }
            //};
            //int resExp = 9;

            int result = queensAttack(n, k, r_q, c_q, obstacles);

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

        static int queensAttack(int n, int k, int r_q, int c_q, int[][] obstacles)
        {
            if (n == 1)
            {
                return 0;
            }

            int totSquares = 0;
            int rowQ = n - r_q;
            int colQ = c_q - 1;

            if (k > 0)
            {
                for (int r = 0; r < obstacles.Length; r++)
                {
                    obstacles[r][0] = n - obstacles[r][0];
                    obstacles[r][1] = obstacles[r][1] - 1;
                }
            }

            totSquares = calcTop(n, k, rowQ, colQ, obstacles);
            totSquares += calcTopLeft(n, k, rowQ, colQ, obstacles);
            totSquares += calcTopRight(n, k, rowQ, colQ, obstacles);

            totSquares += calcBottom(n, k, rowQ, colQ, obstacles);
            totSquares += calcBottomLeft(n, k, rowQ, colQ, obstacles);
            totSquares += calcBottomRight(n, k, rowQ, colQ, obstacles);

            totSquares += calcLeft(n, k, rowQ, colQ, obstacles);
            totSquares += calcRight(n, k, rowQ, colQ, obstacles);

            return totSquares;
        }

        static int calcTop(int n, int k, int rowQ, int colQ, int[][] obstacles)
        {
            if (rowQ == 0)
            {
                return 0;
            }
            int totSquares = 0;
            int[] s;

            if (k > 0)
            {
                s = obstacles.Where((row, index) => row[0] < rowQ && row[1] == colQ).Max();
                totSquares += ((rowQ - s[0]) - 1);
            }
            else
            {
                totSquares += rowQ;
            }

            return totSquares;
        }

        static int calcBottom(int n, int k, int rowQ, int colQ, int[][] obstacles)
        {
            if (rowQ == (n - 1))
            {
                return 0;
            }
            int totSquares = 0;
            int[] s;

            if (k > 0)
            {
                s = obstacles.Where((row, index) => row[0] > rowQ && row[1] == colQ).Min();
                totSquares += ((s[0] - rowQ) - 1);
            }
            else
            {
                totSquares += ((n - 1) - rowQ);
            }

            return totSquares;
        }

        static int calcLeft(int n, int k, int rowQ, int colQ, int[][] obstacles)
        {
            if (colQ == 0)
            {
                return 0;
            }
            int totSquares = 0;
            int[] s;

            if (k > 0)
            {
                s = obstacles.Where((row, index) => row[0] == rowQ && row[1] < colQ).Max();
                totSquares += ((colQ - s[0]) - 1);
            }
            else
            {
                totSquares += colQ;
            }

            return totSquares;
        }

        static int calcRight(int n, int k, int rowQ, int colQ, int[][] obstacles)
        {
            if (colQ == (n - 1))
            {
                return 0;
            }
            int totSquares = 0;
            int[] s;

            if (k > 0)
            {
                s = obstacles.Where((row, index) => row[0] == rowQ && row[1] > colQ).Min();
                totSquares += ((s[0] - colQ) - 1);
            }
            else
            {
                totSquares += ((n - 1) - colQ);
            }

            return totSquares;
        }

        static int calcTopLeft(int n, int k, int rowQ, int colQ, int[][] obstacles)
        {
            if (rowQ == 0 || colQ == 0)
            {
                return 0;
            }
            int totSquares = 0;
            int[] s;

            int diff = Math.Abs(colQ - rowQ);

            if (k > 0)
            {
                s = obstacles.Where((row, index) => row[0] < rowQ && row[1] < colQ 
                                        && row[0] == row[1] + diff)
                                        .Max();

                totSquares += ((rowQ - s[0]) - 1);
            }
            else
            {
                if (rowQ > colQ)
                {
                    totSquares += (rowQ - diff);
                }
                else
                {
                    if (rowQ < colQ)
                    {
                        totSquares += (colQ - diff);
                    }
                    else
                    {
                        totSquares += rowQ;
                    }
                }
            }

            return totSquares;
        }

        static int calcTopRight(int n, int k, int rowQ, int colQ, int[][] obstacles)
        {
            if (rowQ == 0 || colQ == (n - 1))
            {
                return 0;
            }
            int totSquares = 0;
            int[] s;

            int diff = Math.Abs(colQ - rowQ);
            int diffC = 0;
            int diffR = 0;

            if (k > 0)
            {
                s = obstacles.Where((row, index) => row[0] < rowQ && row[1] > colQ 
                                        && row[0] == row[1] + diff)
                                        .Min();
                totSquares += ((rowQ - s[0]) - 1);
            }
            else
            {
                diffC = (n - 1) - colQ;
                if (rowQ < diffC)
                {
                    totSquares += rowQ;
                }
                else
                {
                    totSquares += diffC;
                }
            }

            return totSquares;
        }

        static int calcBottomLeft(int n, int k, int rowQ, int colQ, int[][] obstacles)
        {
            if (rowQ == (n - 1) || colQ == 0)
            {
                return 0;
            }
            int totSquares = 0;
            int[] s;

            int diff = Math.Abs(colQ - rowQ);
            int diffC = 0;
            int diffR = 0;

            if (k > 0)
            {
                s = obstacles.Where((row, index) => row[0] > rowQ && row[1] < colQ
                                        && row[0] == row[1] + diff)
                                        .Min();
                totSquares += ((rowQ - s[0]) - 1);
            }
            else
            {
                diffR = (n - 1) - rowQ;
                if (colQ < diffR)
                {
                    totSquares += colQ;
                }
                else
                {
                    totSquares += diffR;
                }
            }

            return totSquares;
        }

        static int calcBottomRight(int n, int k, int rowQ, int colQ, int[][] obstacles)
        {
            if (rowQ == (n - 1) || colQ == (n - 1))
            {
                return 0;
            }
            int totSquares = 0;
            int[] s;

            int diff = Math.Abs(colQ - rowQ);
            int diffC = 0;
            int diffR = 0;

            if (k > 0)
            {
                s = obstacles.Where((row, index) => row[0] > rowQ && row[1] > colQ
                                        && row[0] == row[1] + diff)
                                        .Min();
                totSquares += ((rowQ - s[0]) - 1);
            }
            else
            {
                diffC = (n - 1) - colQ;
                diffR = (n - 1) - rowQ;
                if (diffR < diffC)
                {
                    totSquares += diffR;
                }
                else
                {
                    totSquares += diffC;
                }
            }

            return totSquares;
        }

    }
}
