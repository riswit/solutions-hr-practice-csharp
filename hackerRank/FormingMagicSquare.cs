using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class FormingMagicSquare
    {
        public void Execute()
        {
            //int[][] s = new int[][] { 
            //    new int[] { 4, 9, 2 },
            //    new int[] { 3, 5, 7 },
            //    new int[] { 8, 1, 5 }
            //};
            //int resExp = 1;

            int[][] s = new int[][] {
                new int[] { 5, 3, 4 },
                new int[] { 1, 5, 8 },
                new int[] { 6, 4, 2 }
            };
            int resExp = 7;

            int result = formingMagicSquare(s);

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

        static int formingMagicSquare(int[][] s)
        {
            int[][][] c = new int[][][]{
                new int[][] {
                    new int[] { 8, 1, 6 },
                    new int[] { 3, 5, 7 },
                    new int[] { 4, 9, 2 }
                },
                new int[][] {
                    new int[] { 6, 1, 8 },
                    new int[] { 7, 5, 3 },
                    new int[] { 2, 9, 4 }
                },
                new int[][] {
                    new int[] { 2, 7, 6 },
                    new int[] { 9, 5, 1 },
                    new int[] { 4, 3, 8 }
                },
                new int[][] {
                    new int[] { 4, 3, 8 },
                    new int[] { 9, 5, 1 },
                    new int[] { 2, 7, 6 }
                },
                new int[][] {
                    new int[] { 2, 9, 4 },
                    new int[] { 7, 5, 3 },
                    new int[] { 6, 1, 8 }
                },
                new int[][] {
                    new int[] { 4, 9, 2 },
                    new int[] { 3, 5, 7 },
                    new int[] { 8, 1, 6 }
                },
                new int[][] {
                    new int[] { 6, 7, 2 },
                    new int[] { 1, 5, 9 },
                    new int[] { 8, 3, 4 }
                },
                new int[][] {
                    new int[] { 8, 3, 4 },
                    new int[] { 1, 5, 9 },
                    new int[] { 6, 7, 2 }
                }
            };

            int costMin = 0;
            int actualCost = 0;

            for (int i = 0; i < c.Length; i++) 
            {
                actualCost = verifyAndChange(c[i], s);

                if (actualCost < costMin || i == 0)
                {
                    costMin = actualCost;
                }
            }

            return costMin;
        }

        static int verifyAndChange(int[][] model, int[][] s)
        {
            int cost = 0;
            int[][] sOut = s;

            for (int j = 0; j < s.Length; j++)
            {
                for (int jj = 0; jj < s.Length; jj++)
                {
                    cost += Math.Abs(model[j][jj] - s[j][jj]);
                }
            }

            return cost;
        }



        static int[] getNumMissing(int[][] s)
        {
            List<int> listMissing = new List<int>();

            bool f = false;
            int j = 0;
            int jj = 0;

            for (int i = 1; i <= 9; i++)
            {
                f = false;

                for (j = 0; j < s.Length && !f; j++)
                {
                    for (jj = 0; jj < s.Length && !f; jj++)
                    {
                        if (i == s[j][jj])
                        {
                            f = true;
                        }
                    }
                }

                if (!f)
                {
                    listMissing.Add(i);
                }
            }

            return listMissing.ToArray();
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

        static bool isCorrect(int[][] s)
        {
            int magicSum = 15;

            int line1 = sumLines(s, 0);
            int line2 = sumLines(s, 1);
            int line3 = sumLines(s, 2);
            int col1 = sumCols(s, 0);
            int col2 = sumCols(s, 0);
            int col3 = sumCols(s, 0);
            int diagSx = sumDiag(s, "sx");
            int diagDx = sumDiag(s, "dx");

            if (line1 == magicSum 
                && line2 == magicSum 
                && line3 == magicSum
                && col1 == magicSum
                && col2 == magicSum
                && col3 == magicSum
                && diagSx == magicSum
                && diagDx == magicSum)
            {
                return true;
            }

            return false;
        }

        //static List<int> loadSquareInList(int[][] s)
        //{
        //    List<int> list = new List<int>();

        //    for (int i = 0; i < s.Length; i++)
        //    {
        //        for (int j = 0; j < s.Length; j++)
        //        {
        //            list.Add(s[i][j]);
        //        }
        //    }

        //    return list;
        //}


    }
}
