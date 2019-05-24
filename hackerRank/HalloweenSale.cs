using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class HalloweenSale
    {
        public void Execute()
        {
            int p = 100;
            int d = 19;
            int m = 1;
            int s = 180;
            int resExp = 1;

            int result = howManyGames(p, d, m, s);

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

        static int howManyGames(int p, int d, int m, int s)
        {
            int numGames = 0;

            if (s < p)
            {
                return 0;
            }

            while (s > m)
            {
                if (s < p)
                {
                    break;
                }

                s -= p;

                if (p - d > m)
                {
                    p -= d;
                }
                else
                {
                    p = m;
                }

                numGames++;
            }

            if (s == m)
            {
                numGames++;
            }

            return numGames;
        }
    }
}
