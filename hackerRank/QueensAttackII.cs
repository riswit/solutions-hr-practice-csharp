using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

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
                new int[] { 8, 5 },
                new int[] { 7, 2 },
                new int[] { 6, 1 },
                new int[] { 6, 5 },
                new int[] { 6, 6 },
                new int[] { 2, 7 },
                new int[] { 4, 7 },
                new int[] { 6, 7 },
                new int[] { 5, 7 },
                new int[] { 2, 6 },
                new int[] { 3, 2 },
                new int[] { 2, 4 },
                new int[] { 4, 2 },
                new int[] { 8, 2 },
                new int[] { 2, 5 },
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

        static int queensAttack(int n, int k, int r_q, int c_q, int[][] obstacles)
        {
            if (n == 1)
            {
                return 0;
            }

            int totSquares = 0;
            int rowQ = cRow(n, r_q);
            int colQ = cCol(c_q);

            DataTable dt = new DataTable();
            if (k > 0)
            {
                dt.Columns.Add("r", typeof(int));
                dt.Columns.Add("c", typeof(int));
                DataRow newRow;

                for (int r = 0; r < obstacles.Length; r++)
                {
                    newRow = dt.NewRow();
                    newRow[0] = cRow(n, obstacles[r][0]);
                    newRow[1] = cCol(obstacles[r][1]);
                    dt.Rows.Add(newRow);
                }
            }

            totSquares = calcTop(n, k, rowQ, colQ, dt);
            totSquares += calcBottom(n, k, rowQ, colQ, dt);
            totSquares += calcLeft(n, k, rowQ, colQ, dt);
            totSquares += calcRight(n, k, rowQ, colQ, dt);

            totSquares += calcTopLeft(n, k, rowQ, colQ, dt);
            totSquares += calcTopRight(n, k, rowQ, colQ, dt);

            totSquares += calcBottomLeft(n, k, rowQ, colQ, dt);
            totSquares += calcBottomRight(n, k, rowQ, colQ, dt);


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

        static int calcTop(int n, int k, int rowQ, int colQ, DataTable dt)
        {
            if (rowQ == 0)
            {
                return 0;
            }
            int totSquares = 0;
            int[] s;

            if (k > 0)
            {
                DataRow[] foundRows = dt.Select("r < " + rowQ + " and c = " + colQ, "r desc");
                if (foundRows.Length > 0)
                {
                    totSquares += ((rowQ - int.Parse(foundRows[0][0].ToString())) - 1);
                    return totSquares;
                }
            }

            totSquares += rowQ;

            return totSquares;
        }

        static int calcBottom(int n, int k, int rowQ, int colQ, DataTable dt)
        {
            if (rowQ == (n - 1))
            {
                return 0;
            }
            int totSquares = 0;
            int[] s;

            if (k > 0)
            {
                DataRow[] foundRows = dt.Select("r > " + rowQ + " and c = " + colQ, "r");
                if (foundRows.Length > 0)
                {
                    totSquares += ((int.Parse(foundRows[0][0].ToString()) - rowQ) - 1);
                    return totSquares;
                }
            }

            totSquares += ((n - 1) - rowQ);

            return totSquares;
        }

        static int calcLeft(int n, int k, int rowQ, int colQ, DataTable dt)
        {
            if (colQ == 0)
            {
                return 0;
            }
            int totSquares = 0;
            int[] s;

            if (k > 0)
            {
                DataRow[] foundRows = dt.Select("r = " + rowQ + " and c < " + colQ, "c desc");
                if (foundRows.Length > 0)
                {
                    totSquares += ((colQ - int.Parse(foundRows[0][1].ToString())) - 1);
                    return totSquares;
                }
            }

            totSquares += colQ;

            return totSquares;
        }

        static int calcRight(int n, int k, int rowQ, int colQ, DataTable dt)
        {
            if (colQ == (n - 1))
            {
                return 0;
            }
            int totSquares = 0;
            int[] s;

            if (k > 0)
            {
                DataRow[] foundRows = dt.Select("r = " + rowQ + " and c > " + colQ, "c");
                if (foundRows.Length > 0)
                {
                    totSquares += ((int.Parse(foundRows[0][1].ToString()) - colQ) - 1);
                    return totSquares;
                }
            }

            totSquares += ((n - 1) - colQ);

            return totSquares;
        }

        static int calcTopLeft(int n, int k, int rowQ, int colQ, DataTable dt)
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
                string op = "r < " + rowQ + " and c < " + colQ + " and (" + colQ + " - c) = (" + rowQ + " - r)";
                DataRow[] foundRows = dt.Select(op, "r desc, c desc");
                if (foundRows.Length > 0)
                {
                    totSquares += ((rowQ - int.Parse(foundRows[0][0].ToString())) - 1);
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

        static int calcTopRight(int n, int k, int rowQ, int colQ, DataTable dt)
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
                DataRow[] foundRows = dt.Select("r < " + rowQ + " and c > " + colQ + " and (c - " + colQ + ") = (" + rowQ + " - r)", "r desc, c");
                if (foundRows.Length > 0)
                {
                    totSquares += ((rowQ - int.Parse(foundRows[0][0].ToString())) - 1);
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

        static int calcBottomLeft(int n, int k, int rowQ, int colQ, DataTable dt)
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
                DataRow[] foundRows = dt.Select("r > " + rowQ + " and c < " + colQ + " and (" + colQ + " - c) = (r - " + rowQ + ")", "r, c desc");
                if (foundRows.Length > 0)
                {
                    totSquares += ((int.Parse(foundRows[0][0].ToString()) - rowQ) - 1);
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

        static int calcBottomRight(int n, int k, int rowQ, int colQ, DataTable dt)
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
                DataRow[] foundRows = dt.Select("r > " + rowQ + " and c > " + colQ + " and (c - " + colQ + ") = (r - " + rowQ + ")", "r, c");
                if (foundRows.Length > 0)
                {
                    totSquares += (Math.Abs(rowQ - int.Parse(foundRows[0][0].ToString())) - 1);
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

        /*
        static bool predTop(int[] e)
        {
            return e[0] < G_rowQ && e[1] == G_colQ;
        }

        static bool predBottom(int[] e)
        {
            return e[0] > G_rowQ && e[1] == G_colQ;
        }

        static bool predLeft(int[] e)
        {
            return e[0] == G_rowQ && e[1] < G_colQ;
        }

        static bool predRight(int[] e)
        {
            return e[0] == G_rowQ && e[1] > G_colQ;
        }

        static bool predTopLeft(int[] e)
        {
            return e[0] < G_rowQ && e[1] < G_colQ && (G_colQ - e[1]) == (G_rowQ - e[0]);
        }

        static bool predTopRight(int[] e)
        {
            return e[0] < G_rowQ && e[1] > G_colQ && (e[1] - G_colQ) == (G_rowQ - e[0]);
        }

        static bool predBottomLeft(int[] e)
        {
            return e[0] > G_rowQ && e[1] < G_colQ && (G_colQ - e[1]) == (e[0] - G_rowQ);
        }

        static bool predBottomRight(int[] e)
        {
            return e[0] > G_rowQ && e[1] > G_colQ && (e[1] - G_colQ) == (e[0] - G_rowQ);
        }

        */
    }
}
