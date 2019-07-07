using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class TwoCharacters
    {
        public void Execute()
        {
            //string s = "beabeefeab";
            //int resExp = 5;

            //string s = "abaacdabd";
            //int resExp = 4;

            string s = "ab";
            int resExp = 1;

            int result = alternate(s);

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

        static int alternate(string s)
        {
            int res = 0;

            if (s.Length == 2)
            {
                if (!s[0].Equals(s[1]))
                {
                    return 2;
                }
                return 0;
            }

            //remove single
            var t = (from a in s.GroupBy(x => x) select a).Where(e => e.Count() <= 1).Select(e => e.Key);
            char[] t2 = s.Where(e => !t.Contains(e)).ToArray();

            //remove pairs
            int numPairs = 1;
            StringBuilder cPair;
            char[] strT;

            while (numPairs > 0)
            {
                cPair = t2.Aggregate(new StringBuilder(" "), (prev, val) => calc(prev, val));
                numPairs = cPair.ToString().IndexOf("_contain__pair_");
                if (numPairs > 0)
                {
                    strT = cPair.ToString().Where((e, i) => i >= numPairs + 15).ToArray();

                    t2 = t2.Where(e => !e.Equals(strT[0])).ToArray();
                }
            }

            //check valid string
            char[] elemD = t2.Distinct().ToArray();
            StringBuilder ctr;

            for (int i = 0; i < elemD.Length - 1; i++)
            {
                for (int j = i; j < elemD.Length; j++)
                {
                    var t3 = t2.Where(e => e.Equals(elemD[i]) || e.Equals(elemD[j]));
                    ctr = t3.Aggregate(new StringBuilder(" "), (prev, val) => check(prev, val));
                    if (ctr.ToString().IndexOf("_no_") < 0)
                    {
                        if (t3.Count() > res)
                        {
                            res = t3.Count();
                        }
                    }
                }

            }

            return res;
        }

        static StringBuilder calc(StringBuilder prev, char val)
        {
            if (prev.ToString().IndexOf("_contain__pair_") > -1)
            {
                return prev;
            }
            if ((prev[prev.Length - 1]).Equals(val))
            {
                prev.Append("_contain__pair_");
            }
            prev.Append(val);

            return prev;
        }

        static StringBuilder check(StringBuilder prev, char val)
        {
            if (prev.ToString().IndexOf("_no_") > -1)
            {
                return prev;
            }
            if ((prev[prev.Length - 1]).Equals(val))
            {
                prev.Append("_no_");
            }
            prev.Append(val);

            return prev;
        }

    }
}
