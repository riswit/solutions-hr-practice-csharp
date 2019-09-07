using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    //https://www.hackerrank.com/challenges/count-luck/problem
    class CountLuck
    {
        public void Execute()
        {
            //string[] matrix = { ".X.X......X", ".X*.X.XXX.X", ".XX.X.XM...", "......XXXX." };
            //int k = 3;
            //string resExp = "Impressed";

            //string[] matrix = { "*.X", "X.X", "X.M" };
            //int k = 0;
            //string resExp = "Impressed";

            //string[] matrix = { "*..", "X.X", "..M" };
            //int k = 1;
            //string resExp = "Impressed";

            //string[] matrix = { "XXXXXXXXXXXXXXXXX", "XXX.XX.XXXXXXXXXX", "XX.*..M.XXXXXXXXX", "XXX.XX.XXXXXXXXXX", "XXXXXXXXXXXXXXXXX" };
            //int k = 1;
            //string resExp = "Impressed";

            //string[] matrix = { "", "", "", "", "" };

            string[] matrix = { ".X.XXXXXXXXXXXXXXXXXXX.X.X.X.X.X.X.X.X.X.", "...XXXXXXXXXXXXXXXXXXX...................", ".X..X.X.X.X.X.X.X..XXXX*X.X.X.X.X.X.X.XX.", ".XXXX.X.X.X.X.X.X.XX.X.X.X.X.X.X.X.X.X.X.", ".........................................", ".XX.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X", ".X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.", ".........................................", "X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.XX.", ".X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.", ".........................................", ".XX.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X", ".X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.", ".........................................", "X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.XX.", ".X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.", ".........................................", ".XX.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X", ".X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.", ".........................................", "X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.XX.", ".X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.", ".........................................", ".XX.X.X.X.XX.X.XX.X.X.X.X.X.X.X.X.X.X.X.X", ".X.X.X.X.X.XXX.X.X.X.X.X.X.X.X.X.X.X.X.X.", "X........................................", "X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.XX.", ".X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.", ".........................................", ".X.XX.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.XX.XX", ".X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.XMX.", ".X....................................X..", "..X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.XX.", ".X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.", ".X...................................X...", ".XX.X.X.X.X.X.X.X.X.X.X.X.X.X.XX.XX.XXXX.", ".X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.", ".........................................", "X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.XX.", ".X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.", "........................................." };
            int k = 294;
            string resExp = "Impressed";

            string result = countLuck(matrix, k);

            if (resExp != result)
            {
                Console.WriteLine("Errore - Expected: " + resExp + " - now: " + result);
            }
            else
            {
                Console.WriteLine(result);
                Console.WriteLine("Perfetto!!!");
            }
        }

        private static int rows;
        private static int cols;

        static string countLuck(string[] matrix, int k)
        {
            rows = matrix.Length;
            cols = matrix[0].Length;
            char[,] grid = new char[rows,cols];
            int x = 0;
            int y = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    grid[i,j] = matrix[i][j];

                    if (matrix[i][j] == 'M')
                    {
                        x = i;
                        y = j;
                    }
                }
            }

            int count = 0;
            bool foundPath = false;

            int f = hasStreets(grid, x, y, '.');
            if (f == 0)
            {
                return "Oops!";
            }
            if (f > 1)
            {
                count += 1;
            }

            for (int r = x - 1; r <= x + 1 && !foundPath; r++)
            {
                for (int c = y - 1; c <= y + 1 && !foundPath; c++)
                {
                    if ((r == x + 1 && c == y) || (r == x - 1 && c == y)
                        || (r == x && c == y + 1) || (r == x && c == y - 1))
                    {
                        find(grid, r, c, ref count, ref foundPath);
                    }
                }
            }

            if (!foundPath)
            {
                return "Oops!";
            }

            if (count == k)
            {
                return "Impressed";
            }

            return "Oops!";
        }

        static int hasStreets(char[,] matrix, int row, int col, char ch)
        {
            int res = 0;

            for (int r = row - 1; r <= row + 1; r++)
            {
                for (int c = col - 1; c <= col + 1; c++)
                {
                    if (r >= 0 && r < rows
                        && c >= 0 && c < cols)
                    {
                        if ((r == row + 1 && c == col) || (r == row - 1 && c == col)
                            || (r == row && c == col + 1) || (r == row && c == col - 1))
                        {
                            if (matrix[r, c] == ch)
                            {
                                res += 1;
                            }
                        }
                    }
                }
            }

            return res;
        }

        static void find(char[,] matrix, int row, int col, ref int count, ref bool foundPath)
        {
            if (foundPath)
            {
                return;
            }

            if (row < 0 || row >= rows || col < 0 || col >= cols)
            {
                return;
            }
            else if (matrix[row, col] == 'X' || matrix[row, col] == 'M')
            {
                return;
            }
            else if (matrix[row, col] == 'V')
            {
                return;
            }
            else if (matrix[row, col] == '.')
            {
                matrix[row, col] = 'V';
            }

            int fp = hasStreets(matrix, row, col, '.');
            int f = hasStreets(matrix, row, col, '*');
            if (f > 0)
            {
                if (fp > 0)
                {
                    count += 1;
                }
                foundPath = true;
                return;
            }
            if (fp > 1)
            {
                count += 1;
            }
            if (fp == 0)
            {
                return;
            }
            int countC = count;

            for (int r = row - 1; r <= row + 1 && !foundPath; r++)
            {
                for (int c = col - 1; c <= col + 1 && !foundPath; c++)
                {
                    if ((r == row + 1 && c == col) || (r == row - 1 && c == col)
                        || (r == row && c == col + 1) || (r == row && c == col - 1))
                    {
                        find(matrix, r, c, ref count, ref foundPath);
                        if (!foundPath && count > countC)
                        {
                            count = countC;
                        }
                    }
                }
            }
        }



    }
}
