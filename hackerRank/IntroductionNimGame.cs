using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class IntroductionNimGame
    {
        public void Execute()
        {
            int[] pile = { 0, -1, 2, 1 };
            string resExp = "NO";

            string result = nimGame(pile);

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

        static string nimGame(int[] pile)
        {
            string res = "";



            return res;
        }
    }
}
