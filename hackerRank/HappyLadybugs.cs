using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class HappyLadybugs
    {
        public void Execute()
        {
            string b = "DD__FQ_QQF";
            string resExp = "YES";

            //string b = "A_TOJRPRW__JOJP__WAJT";
            //string resExp = "YES";

            string result = happyLadybugs(b);

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

        static string happyLadybugs(string b)
        {
            string c = b.Replace("_", "");

            if (c.Length == 0)
            {
                return "YES";
            }

            if (c.Length == 1)
            {
                return "NO";
            }

            if (!isNotHappy(c, true))
            {
                return "YES";
            }

            if (isNotHappy(c, false))
            {
                return "NO";
            }

            if (b.IndexOf("_") < 0)
            {
                return "NO";
            }

            return "YES";
        }

        static bool isNotHappy(string c, bool original)
        {
            List<char> t = c.ToList();
            if (!original)
            {
                t.Sort();
            }
            int r = 0;
            for (int i = 0; i < t.Count() - 1; i++)
            {
                if (t[i] == t[i + 1])
                {
                    r++;
                }
                else
                {
                    if (r == 0 || i == t.Count() - 2)
                    {
                        return true;
                    }
                    r = 0;
                }
            }

            return false;
        }

    }
}
