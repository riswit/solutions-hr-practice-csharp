using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class TwoStrings
    {
        public void Execute()
        {
            string s1 = "hello";
            string s2 = "world";
            string resExp = "YES";

            string result = twoStrings(s1, s2);

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

        static string twoStrings(string s1, string s2)
        {
            int c = s1.Intersect(s2).Count();

            if (c > 0)
            {
                return "YES";
            }

            return "NO";
        }
    }
}
