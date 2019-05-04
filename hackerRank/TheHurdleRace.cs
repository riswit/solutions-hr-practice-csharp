using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class TheHurdleRace
    {
        public void Execute()
        {
            //int k = 4;
            //int[] height = { 1, 6, 3, 5, 2 };
            //int resExp = 2;

            //int k = 7;
            //int[] height = { 2, 5, 4, 5, 2 };
            //int resExp = 0;

            int k = 1;
            int[] height = { 1, 2, 3, 3, 2 };
            int resExp = 2;

            int result = hurdleRace(k, height);

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

        static int hurdleRace(int k, int[] height)
        {
            int minDoses = 0;
            int max = 0;

            for (int i = 0; i < height.Length; i++)
            {
                if (height[i] > max)
                {
                    max = height[i];
                }
            }

            if (max > k)
            {
                minDoses = max - k;
            }

            return minDoses;
        }

    }
}
