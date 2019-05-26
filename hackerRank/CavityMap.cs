using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class CavityMap
    {
        public void Execute()
        {
            string[] grid = { "1112", "1912", "1892", "1234" };
            string[] resExp = { "1112", "1X12", "18X2", "1234" };

            string[] result = cavityMap(grid);

            if (string.Join(" ", resExp) != string.Join(" ", result))
            {
                Console.WriteLine("Errore - Expected: " + string.Join(" ", resExp) + " - now: " + string.Join(" ", result));
            }
            else
            {
                Console.WriteLine("Perfetto!!!");
            }

            Console.WriteLine(string.Join(" ", result));
        }

        static string[] cavityMap(string[] grid)
        {
            char[] rowT;
            char[] rowC;
            char[] rowB;
            char[] rowR;
            List<char[]> listCh = new List<char[]>();

            listCh.Add(grid[0].ToCharArray());

            for (int i = 1; i < grid.Length - 1; i++)
            {
                listCh.Add(grid[i].ToCharArray());

                rowT = grid[i - 1].ToCharArray();
                rowC = grid[i].ToCharArray();
                rowB = grid[i + 1].ToCharArray();
                rowR = rowC;

                for (int j = 1; j < rowC.Length - 1; j++)
                {
                    if (rowC[j] > rowT[j] 
                        && rowC[j] > rowB[j] 
                        && rowC[j] > rowC[j - 1] 
                        && rowC[j] > rowC[j + 1])
                    {
                        rowR[j] = 'X';
                    }
                }
                listCh[i] = rowR;
            }

            if (grid.Length > 1)
            {
                listCh.Add(grid[grid.Length - 1].ToCharArray());
            }


            for (int i = 1; i < grid.Length - 1; i++)
            {
                grid[i] = new string (listCh[i]);
            }

            return grid;
        }
    }
}
