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
            int k = 11;
            int r_q = 4;
            int c_q = 5;
            int[][] obstacles = new int[][] {
                new int[] { 8, 1 },
                new int[] { 8, 2 },
                new int[] { 8, 5 },
                new int[] { 7, 2 },
                new int[] { 7, 8 },
                new int[] { 6, 1 },
                new int[] { 6, 5 },
                new int[] { 6, 6 },
                new int[] { 6, 7 },
                new int[] { 5, 7 },
                new int[] { 4, 2 },
                new int[] { 4, 7 },
                new int[] { 3, 2 },
                new int[] { 2, 4 },
                new int[] { 2, 5 },
                new int[] { 2, 6 },
                new int[] { 2, 7 },
                new int[] { 2, 8 },
                new int[] { 1, 2 }
            };
            int resExp = 11;

            //int n = 8;
            //int k = 0;
            //int r_q = 4;
            //int c_q = 7;
            //int[][] obstacles = new int[][] {
            //    new int[] { 5, 5 },
            //    new int[] { 4, 2 },
            //    new int[] { 2, 3 }
            //};
            //int resExp = 27;

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

        static int G_rowQ = 0;
        static int G_colQ = 0;

        static int queensAttack(int n, int k, int r_q, int c_q, int[][] obstacles)
        {
            if (n == 1)
            {
                return 0;
            }

            int totSquares = 0;
            int rowQ = cRow(n, r_q);
            int colQ = cCol(c_q);

            G_rowQ = rowQ;
            G_colQ = colQ;

            if (k > 0)
            {
                for (int r = 0; r < obstacles.Length; r++)
                {
                    obstacles[r][0] = n - obstacles[r][0];
                    obstacles[r][1] = obstacles[r][1] - 1;
                }
            }

            totSquares = calcTop(n, k, rowQ, colQ, obstacles);
            totSquares += calcBottom(n, k, rowQ, colQ, obstacles);
            totSquares += calcLeft(n, k, rowQ, colQ, obstacles);
            totSquares += calcRight(n, k, rowQ, colQ, obstacles);

            totSquares += calcTopLeft(n, k, rowQ, colQ, obstacles);
            totSquares += calcTopRight(n, k, rowQ, colQ, obstacles);

            totSquares += calcBottomLeft(n, k, rowQ, colQ, obstacles);
            totSquares += calcBottomRight(n, k, rowQ, colQ, obstacles);


            return totSquares;
        }

        static int cRow(int n, int val)
        {
            return n - val;
        }

        static int cCol(int val)
        {
            return val - 1;
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
                s = Array.Find(obstacles, predTop);
                if (s != null)
                {
                    totSquares += ((rowQ - s[0]) - 1);
                    return totSquares;
                }
            }

            totSquares += rowQ;

            return totSquares;
        }

        static bool predTop(int[] e)
        {
            return e[0] < G_rowQ && e[1] == G_colQ;
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
                s = Array.Find(obstacles, predBottom);
                if (s != null)
                {
                    totSquares += ((s[0] - rowQ) - 1);
                    return totSquares;
                }
            }

            totSquares += ((n - 1) - rowQ);

            return totSquares;
        }

        static bool predBottom(int[] e)
        {
            return e[0] > G_rowQ && e[1] == G_colQ;
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
                s = Array.Find(obstacles, predLeft);
                if (s != null)
                {
                    totSquares += ((colQ - s[1]) - 1);
                    return totSquares;
                }
            }

            totSquares += colQ;

            return totSquares;
        }

        static bool predLeft(int[] e)
        {
            return e[0] == G_rowQ && e[1] < G_colQ;
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
                s = Array.Find(obstacles, predRight);
                if (s != null)
                {
                    totSquares += ((s[1] - colQ) - 1);
                    return totSquares;
                }
            }

            totSquares += ((n - 1) - colQ);

            return totSquares;
        }

        static bool predRight(int[] e)
        {
            return e[0] == G_rowQ && e[1] > G_colQ;
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
                s = Array.Find(obstacles, predTopLeft);
                if (s != null)
                {
                    totSquares += ((rowQ - s[0]) - 1);
                    return totSquares;
                }
            }

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

            return totSquares;
        }

        static bool predTopLeft(int[] e)
        {
            return e[0] < G_rowQ && e[1] < G_colQ && (G_colQ - e[1]) == (G_rowQ - e[0]);
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

            if (k > 0)
            {
                s = Array.Find(obstacles, predTopRight);
                if (s != null)
                {
                    totSquares += ((rowQ - s[0]) - 1);
                    return totSquares;
                }
            }

            diffC = (n - 1) - colQ;
            if (rowQ < diffC)
            {
                totSquares += rowQ;
            }
            else
            {
                totSquares += diffC;
            }

            return totSquares;
        }

        static bool predTopRight(int[] e)
        {
            return e[0] < G_rowQ && e[1] > G_colQ && (e[1] - G_colQ) == (G_rowQ - e[0]);
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
            int diffR = 0;

            if (k > 0)
            {
                s = Array.Find(obstacles, predBottomLeft);
                if (s != null)
                {
                    totSquares += ((s[0] - rowQ) - 1);
                    return totSquares;
                }
            }

            diffR = (n - 1) - rowQ;
            if (colQ < diffR)
            {
                totSquares += colQ;
            }
            else
            {
                totSquares += diffR;
            }

            return totSquares;
        }

        static bool predBottomLeft(int[] e)
        {
            return e[0] > G_rowQ && e[1] < G_colQ && (G_colQ - e[1]) == (e[0] - G_rowQ);
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
                s = Array.Find(obstacles, predBottomRight);
                if (s != null)
                {
                    totSquares += ((rowQ - s[0]) - 1);
                    return totSquares;
                }
            }

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

            return totSquares;
        }

        static bool predBottomRight(int[] e)
        {
            return e[0] > G_rowQ && e[1] > G_colQ && (e[1] - G_colQ) == (e[0] - G_rowQ);
        }

    }
}
