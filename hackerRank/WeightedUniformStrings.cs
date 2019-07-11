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
            //string s = "abccddde";
            //int[] queries = { 1, 3, 12, 5, 9, 10 };
            //string[] resExp = { "Yes", "Yes", "Yes", "Yes", "No", "No" };

            string s = "aaabbbbcccddd";
            //string s = "acaaabzbbbccwcddadaa";
            int[] queries = { 9, 7, 8, 12, 5 };
            string[] resExp = { "Yes", "No", "Yes", "Yes", "No" };

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

        static string[] weightedUniformStrings(string s, int[] queries)
        {
            string[] res = new string[queries.Length];
            string a = "abcdefghijklmnopqrstuvwxyz";
            Dictionary<char, int> dAlph = a.Select((e, ind) => new KeyValuePair<char, int>(e, ind + 1)).ToDictionary(p => p.Key, p => p.Value);
            int pr = 0;
            bool[] arrT = new bool[99999999];
            int w = 0;
            int totPr = 0;

            for (int i = 0; i < s.Length; i++)
            {
                w = dAlph[s[i]];

                if (w.Equals(pr))
                {
                    arrT[totPr + w] = true;
                }
                else
                {
                    arrT[w] = true;
                    totPr = 0;
                }

                totPr += w;
                pr = w;
            }

            for (int i = 0; i < queries.Length; i++)
            {
                if (arrT[queries[i]])
                {
                    res[i] = "Yes";
                }
                else
                {
                    res[i] = "No";
                }
            } 

            return res;
        }

        static string[] weightedUniformStrings_SLOW(string s, int[] queries)
        {
            string[] res = new string[queries.Length];

            string a = "abcdefghijklmnopqrstuvwxyz";
            char[] alp = a.ToCharArray();

            Dictionary<char, int> dAlph = a.Select((e, ind) => new KeyValuePair<char, int>(e, ind + 1)).ToDictionary(p => p.Key, p => p.Value);

            int[] sW = s.Select(e => dAlph[e]).ToArray();

            var oDis = sW.Distinct();

            int[] oDup = sW.Where((e, ind) => ctrlDup(e, ind, sW)).ToArray();
            int[] oDupR = new int[oDup.Length];

            int i = 0;
            foreach (int e in oDup)
            {
                if (i == 0)
                {
                    oDupR[i] = oDup[i] * 2;
                }
                else
                {
                    if (oDup[i].Equals(oDup[i - 1]))
                    {
                        oDupR[i] = oDupR[i - 1] + oDup[i];
                    }
                    else
                    {
                        oDupR[i] = oDup[i] * 2;
                    }
                }

                i += 1;
            }

            int[] o = oDis.Concat(oDupR).Distinct().ToArray();

            res = queries.Select(n => o.Contains(n) ? "Yes" : "No").ToArray();

            return res;
        }

        static bool ctrlDup(int e, int ind, int[] sW)
        {
            if (ind == 0)
            {
                return false;
            }

            if (e.Equals(sW[ind - 1]))
            {
                return true;
            }

            return false;
        }

        //static bool ctrlDis(int e, int ind, int[] sW)
        //{
        //    if (ind == 0)
        //    {
        //        return true;
        //    }

        //    if (!e.Equals(sW[ind - 1]))
        //    {
        //        if (ind + 1 < sW.Length)
        //        {
        //            if (!e.Equals(sW[ind + 1]))
        //            {
        //                return true;
        //            }
        //            return false;
        //        }
        //        return true;
        //    }

        //    return false;
        //}

        //static List<int[]> calc(List<int[]> prev, char val, char[] alp)
        //{
        //    int w = 0;
        //    w = Array.FindIndex(alp, m => m.Equals(val)) + 1;

        //    if (prev.Count == 0)
        //    {
        //        prev.Add(new int[2] { w, w });
        //        return prev;
        //    }

        //    if (w.Equals(prev[prev.Count - 1][0]))
        //    {
        //        prev.Add(new int[2] { w, w + prev[prev.Count - 1][1] });
        //        return prev;
        //    }

        //    prev.Add(new int[2] { w, w });

        //    return prev;
        //}

    }
}
