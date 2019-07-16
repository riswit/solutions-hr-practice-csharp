using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class AlternatingCharacters
    {
        public void Execute()
        {
            //string s = "AAAA";
            //int resExp = 3;

            //string s = "AAABBB";
            //int resExp = 4;

            string s = "ABABABAB";
            int resExp = 0;

            int result = alternatingCharacters(s);

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

        static int alternatingCharacters(string s)
        {
            int res = 0;
            char[] t = s.ToCharArray();
            char ci = s[0];

            for (int i = 1; i < t.Length; i++)
            {
                if (ci.Equals(t[i]))
                {
                    res += 1;
                }
                else
                {
                    ci = t[i];
                }
            }

            return res;
        }
    }
}
