using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class WeightedUniformStrings
    {
        public void Execute()
        {
            string s = "abccddde";
            int[] queries = { 1, 3, 12, 5, 9, 10 };
            string[] resExp = { "Yes", "Yes", "Yes", "Yes", "No", "No" };

            //string s = "aaabbbbcccddd";
            ////string s = "acaaabzbbbccwcddadaa";
            //int[] queries = { 9, 7, 8, 12, 5 };
            //string[] resExp = { "Yes", "No", "Yes", "Yes", "No"};

            string[] result = weightedUniformStrings(s, queries);

            if (string.Join(" ", resExp) != string.Join(" ", result))
            {
                Console.WriteLine("Errore - Expected: " + string.Join(" ", resExp) + " - now: " + string.Join(" ", result));
            }
            else
            {
                Console.WriteLine("Perfetto!!!");
                Console.WriteLine(string.Join(" ", result));
            }
        }

        static bool ctrlDup(char e, int ind, string s)
        {
            if (ind == 0)
            {
                if (ind < s.Length + 1)
                {
                    if (e.Equals(s[ind + 1]))
                    {
                        return true;
                    }
                    return false;
                }
            }

            if (e.Equals(s[ind - 1]))
            {
                return true;
            }

            return false;
        }

        static bool ctrlDis(char e, int ind, string s)
        {
            if (ind == 0)
            {
                return true;
            }

            if (!e.Equals(s[ind - 1]))
            {
                return true;
            }

            return false;
        }

        static string[] weightedUniformStrings(string s, int[] queries)
        {
            string[] res = new string[queries.Length];

            string a = "abcdefghijklmnopqrstuvwxyz";
            char[] alp = a.ToCharArray();

            var oDup = s.Where((e, ind) => ctrlDup(e, ind, s));

            var oDis = s.Where((e, ind) => ctrlDis(e, ind, s)).Distinct();

            int[] rdup = oDup.Aggregate(new List<int[]>(), (prev, val) => calc(prev, val, alp)).Select(e => e[1]).ToArray();
            int[] rdis = oDis.Aggregate(new List<int[]>(), (prev, val) => calc(prev, val, alp)).Select(e => e[1]).ToArray();

            int i = 0;
            int c = 0;
            foreach (int q in queries)
            {
                c = Array.Find(rdis, e => e.Equals(q));

                if (c > 0)
                {
                    res[i] = "Yes";
                }
                else
                {
                    c = Array.Find(rdup, e => e.Equals(q));

                    if (c > 0)
                    {
                        res[i] = "Yes";
                    }
                    else
                    {
                        res[i] = "No";
                    }
                }
                i += 1;
            }

            return res;
        }

        static List<int[]> calc(List<int[]> prev, char val, char[] alp)
        {
            int w = 0;
            w = Array.FindIndex(alp, m => m.Equals(val)) + 1;

            if (prev.Count == 0)
            {
                prev.Add(new int[2] { w, w });
                return prev;
            }

            if (w.Equals(prev[prev.Count - 1][0]))
            {
                prev.Add(new int[2] { w, w + prev[prev.Count - 1][1] });
                return prev;
            }

            prev.Add(new int[2] { w, w });

            return prev;
        }

    }
}
