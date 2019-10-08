using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class GridChallenge
    {
        public void Execute()
        {
            //string[] grid = { "ebacd", "fghij", "olmkn", "trpqs", "xywuv" };
            //string resExp = "YES";
            string[] grid = { "abc", "hjk", "mpq", "rtv" };
            string resExp = "YES";

            string result = gridChallenge(grid);

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

        static string gridChallenge(string[] grid)
        {
            string res = "";
            char[][] t = new char[grid.Length][];

            for (int i = 0; i < grid.Length; i++)
            {
                char[] ar = grid[i].ToCharArray().OrderBy(x => x).ToArray();
                t[i] = ar.ToArray();
            }

            int len = t[0].Count();

            for (int j = 0; j < len; j++)
            {
                for (int i = 1; i < t.Length; i++)
                {
                    if (t[i][j].CompareTo(t[i - 1][j]) < 0)
                    {
                        return "NO";
                    }
                }
            }

            return "YES";
        }
    }
}
