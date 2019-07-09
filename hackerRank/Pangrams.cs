using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class Pangrams
    {
        public void Execute()
        {
            //string s = "We promptly judged antique ivory buckles for the next prize";
            //string resExp = "pangram";

            string s = "We promptly judged antique ivory buckles for the prize";
            string resExp = "not pangram";

            string result = pangrams(s);

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

        static string pangrams(string s)
        {
            string a = "abcdefghijklmnopqrstuvwxyz";
            char[] alp = a.ToCharArray();
            char[] sArray = s.ToLower().ToCharArray();

            if (sArray.Intersect(alp).Count() >= a.Length)
            {
                return "pangram";
            }

            return "not pangram";
        }
    }
}
