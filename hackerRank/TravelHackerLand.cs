using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class TravelHackerLand
    {
        public void Execute()
        {
            int[] t = new int[] { 1, 1, 4, 5, 1, 3, 2 };

            int[][] roads = new int[][] {
                new int[] { 1, 2, 3 },
                new int[] { 2, 6, 2 },
                new int[] { 2, 3, 4 },
                new int[] { 3, 4, 3 },
                new int[] { 2, 4, 9 },
                new int[] { 5, 7, 9 }
            };

            int[][] queries = new int[][] {
                new int[] { 1, 2, 4 }
            };

            int resExp = 60;

            int result = travel(t, roads, queries);

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

        static int travel(int[] t, int[][] roads, int[][] queries)
        {
            int res = 0;



            return res;
        }
    }
}
