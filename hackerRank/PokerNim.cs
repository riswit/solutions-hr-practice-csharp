using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class PokerNim
    {
        public void Execute()
        {
            int k = 2;
            int[] c = { 0, -1, 2, 1 };
            string resExp = "NO";

            string result = pokerNim(k, c);

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

        static string pokerNim(int k, int[] c)
        {
            string res = "";



            return res;
        }
    }
}
