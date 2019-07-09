using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class HackerRankString
    {
        public void Execute()
        {
            string s = "hereiamstackerrank";
            string resExp = "YES";

            string result = hackerrankInString(s);

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

        static string hackerrankInString(string s)
        {
            string w = "hackerrank";
            if (s.Length < w.Length)
            {
                return "NO";
            }
            char[] c = w.ToCharArray();

            StringBuilder r = s.ToCharArray().Aggregate(new StringBuilder(""), (prev, val) => calc(prev, val, c));

            if (r.ToString().Trim().ToLower().Equals(w))
            {
                return "YES";
            }

            return "NO";
        }

        static StringBuilder calc(StringBuilder prev, char val, char[] c)
        {
            if (prev.Length == 10)
            {
                return prev;
            }

            if (val == c[prev.Length])
            {
                prev.Append(val);
            }

            return prev;
        }

    }
}
