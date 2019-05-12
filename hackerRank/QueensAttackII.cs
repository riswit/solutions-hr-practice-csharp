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
            int n = 5;
            int k = 3;
            int r_q = 4;
            int c_q = 3;
            int[][] obstacles = new int[][] {
                new int[] { 5, 5 },
                new int[] { 4, 2 },
                new int[] { 2, 3 }
            };
            int resExp = 10;

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
            //totSquares = calcTopLeft(n, k, rowQ, colQ, obstacles);
            //totSquares = calcTopRight(n, k, rowQ, colQ, obstacles);

            //totSquares += calcBottom(n, k, rowQ, colQ, obstacles);
            //totSquares += calcBottomLeft(n, k, rowQ, colQ, obstacles);
            //totSquares += calcBottomRight(n, k, rowQ, colQ, obstacles);

            //totSquares += calcLeft(n, k, rowQ, colQ, obstacles);
            //totSquares += calcRight(n, k, rowQ, colQ, obstacles);

            return totSquares;
        }

        static int calcTop(int n, int k, int rowQ, int colQ, int[][] obstacles)
        {
            if (rowQ == 0)
            {
                return 0;
            }
            int totSquares = 0;
            int obstacle = 0;
            int squares = 0;
            int rowObs = 0;

            if (k > 0)
            {
                //int maxValue = Array.FindIndex(  obstacles.Max();
                //int maxIndex = obstacles.ToList().IndexOf(maxValue);
            }

            return totSquares;
        }

        static int sumLines(int[][] s, int line)
        {
            int sum = 0;

            for (int col = 0; col < s.Length; col++)
            {
                sum += s[line][col];
            }

            return sum;
        }

        static int sumCols(int[][] s, int col)
        {
            int sum = 0;

            for (int line = 0; line < s.Length; line++)
            {
                sum += s[line][col];
            }

            return sum;
        }

        static int sumDiag(int[][] s, string d = "sx")
        {
            int sum = 0;

            switch (d)
            {
                case "sx":
                    for (int i = 0; i < s.Length; i++)
                    {
                        sum += s[i][i];
                    }
                    break;
                case "dx":
                    int col = s.Length - 1;
                    for (int i = 0; i < s.Length; i++)
                    {
                        sum += s[i][col];
                        col--;
                    }
                    break;
            }

            return sum;
        }


    }
}
