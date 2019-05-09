using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class AppendDelete
    {
        public void Execute()
        {
            string s = "abc";
            string t = "def";
            int k = 6;
            string resExp = "Yes";

            //string s = "hackerhappy";
            //string t = "hackerrank";
            //int k = 9;
            //string resExp = "Yes";

            //string s = "aba";
            //string t = "aba";
            //int k = 7;
            //string resExp = "Yes";

            //string s = "ashley";
            //string t = "ash";
            //int k = 2;
            //string resExp = "No";

            //string s = "h";
            //string t = "r";
            //int k = 2;
            //string resExp = "Yes";

            //string s = "y";
            //string t = "yu";
            //int k = 2;
            //string resExp = "No";

            //string s = "zzzzz";
            //string t = "zzzzzzz";
            //int k = 4;
            //string resExp = "Yes";

            //string s = "zzzzzzz";
            //string t = "zzzzz";
            //int k = 4;
            //string resExp = "Yes";

            string result = appendAndDelete(s, t, k);

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

        static string appendAndDelete(string s, string t, int k)
        {
            int start = 0;

            for (int i = 0; i < s.Length && i < t.Length; i++)
            {
                if (s.Substring(i, 1) != t.Substring(i, 1))
                {
                    start = i;
                    break;
                }
                if (i == (s.Length - 1) && i < t.Length
                    || i == (t.Length - 1) && i < s.Length)
                {
                    start = i + 1;
                }
            }

            int lens = s.Length - start;
            int lent = t.Length - start;
            int numDeleteMin = 0;

            if (lens < lent)
            {
                if ((lent % 2) == 0 && (k % 2) != 0)
                {
                    return "No";
                }
                if ((lent % 2) == 0 && (k % 2) == 0 && k < (lent * 2))
                {
                    return "No";
                }

                if ((lent % 2) != 0 && (k % 2) == 0)
                {
                    return "No";
                }
                if ((lent % 2) != 0 && (k % 2) != 0 && k < (lent * 2))
                {
                    return "No";
                }
            }

            if (lens == lent && (lens * 2) > k)
            {
                return "No";
            }

            if (lens > lent)
            {
                numDeleteMin = lens;
                if (k < numDeleteMin)
                {
                    return "No";
                }
            }

            return "Yes";
        }


    }
}
