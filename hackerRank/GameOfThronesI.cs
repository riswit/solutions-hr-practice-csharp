using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class GameOfThronesI
    {
        public void Execute()
        {
            string s = "aaabbbb";
            string resExp = "YES";

            string result = gameOfThrones(s);

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

        static string gameOfThrones(string s)
        {
            Dictionary<char, int> t = s.GroupBy(x => x).ToDictionary(p => p.Key,
                                                                        p => p.Count()
                                                                    );

            int numPairs = t.Where(e => e.Value % 2 == 0).Count();
            if (numPairs == 0)
            {
                return "NO";
            }
            int numOdds = t.Count() - numPairs;

            if (numOdds > 1)
            {
                return "NO";
            }

            return "YES";
        }
    }
}
