using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class ConnectedCellsGrid
    {
        public void Execute()
        {
            //int[][] matrix = new int[][] {
            //    new int[] { 1, 1, 0, 0 },
            //    new int[] { 0, 1, 1, 0 },
            //    new int[] { 0, 0, 1, 0 },
            //    new int[] { 1, 0, 0, 0 }
            //};
            //int resExp = 5;

            int[][] matrix = new int[][] {
                new int[] { 0, 0, 1, 1 },
                new int[] { 0, 0, 1, 0 },
                new int[] { 0, 1, 1, 0 },
                new int[] { 0, 1, 0, 0 },
                new int[] { 1, 1, 0, 0 }
            };
            int resExp = 8;

            int result = connectedCell(matrix);

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

        private static int rows;
        private static int cols;

        static int connectedCell(int[][] matrix)
        {
            int res = 0;
            int c = 0;
            rows = matrix.GetLength(0);
            cols = matrix[0].GetLength(0);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i][j] == 1)
                    {
                        c = find(matrix, i, j);

                        if (c > res)
                        {
                            res = c;
                        }
                    }
                }
            }

            return res;
        }

        static int find(int[][] matrix, int row, int col)
        {
            if (row < 0 || row >= rows || col < 0 || col >= cols)
            {
                return 0;
            }
            else if (matrix[row][col] == 0)
            {
                return 0;
            }

            matrix[row][col] = 0; 
            int count = 1;      

            for (int r = row - 1; r <= row + 1; r++)
            {
                for (int c = col - 1; c <= col + 1; c++)
                {
                    count += find(matrix, r, c);
                }
            }

            return count;
        }

        static int connectedCell_NotCorrect(int[][] matrix)
        {
            int res = 0;
            int c = 0;
            int rows = matrix.GetLength(0);
            int cols = matrix[0].GetLength(0);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i][j] == 1)
                    {
                        c = 1;

                        if (i > 0)
                        {
                            //top
                            if (matrix[i - 1][j] == 1)
                            {
                                c += 1;
                            }
                            //top left
                            if (j > 0)
                            {
                                if (matrix[i - 1][j - 1] == 1)
                                {
                                    c += 1;
                                }
                            }
                            //top right
                            if (j < cols - 1)
                            {
                                if (matrix[i - 1][j + 1] == 1)
                                {
                                    c += 1;
                                }
                            }
                        }
                        //left
                        if (j > 0)
                        {
                            if (matrix[i][j - 1] == 1)
                            {
                                c += 1;
                            }
                        }
                        //right
                        if (j < cols - 1)
                        {
                            if (matrix[i][j + 1] == 1)
                            {
                                c += 1;
                            }
                        }
                        if (i < rows - 1)
                        {
                            //bottom
                            if (matrix[i + 1][j] == 1)
                            {
                                c += 1;
                            }
                            //bottom left
                            if (j > 0)
                            {
                                if (matrix[i + 1][j - 1] == 1)
                                {
                                    c += 1;
                                }
                            }
                            //bottom right
                            if (j < cols - 1)
                            {
                                if (matrix[i + 1][j + 1] == 1)
                                {
                                    c += 1;
                                }
                            }
                        }

                        if (c > res)
                        {
                            res = c;
                        }
                    }
                }
            }

            return res;
        }

    }
}
