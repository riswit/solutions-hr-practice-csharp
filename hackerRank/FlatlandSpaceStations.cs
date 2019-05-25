using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class FlatlandSpaceStations
    {
        public void Execute()
        {
            int n = 5;
            int[] c = { 0, 4 };
            int resExp = 2;

            //int n = 6;
            //int[] c = { 0, 1, 2, 4, 3, 5 };
            //int resExp = 0;

            //int n = 5;
            //int[] c = { 0, 1, 2 };
            //int resExp = 2;

            //int n = 20;
            //int[] c = { 13, 1, 11, 10, 6 };
            //int resExp = 6;

            int result = flatlandSpaceStations(n, c);

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

        static int flatlandSpaceStations(int n, int[] c)
        {
            if (n == c.Length)
            {
                return 0;
            }
            if (n == 1)
            {
                return 1;
            }

            int maxDistance = 0;
            int center = 0;

            List<int> list = c.ToList();
            list.Sort();

            if (list[0] > 0)
            {
                maxDistance = list[0];
            }

            for (int i = 0; i < list.Count() - 1; i++)
            {
                if (list[i + 1] - list[i] > 1)
                {
                    center = (int)(Math.Abs((list[i + 1] - list[i]) / 2));

                    if (center > maxDistance)
                    {
                        maxDistance = center;
                    }
                }
                else
                {
                    if (maxDistance < 1)
                    {
                        maxDistance = 1;
                    }
                }
            }

            if (list[list.Count() - 1] < n - 1)
            {
                if (n - 1 - list[list.Count() - 1] > maxDistance)
                {
                    maxDistance = n - 1 - list[list.Count() - 1];
                }
            }

            return maxDistance;
        }
    }
}
