using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    // https://www.hackerrank.com/challenges/journey-to-the-moon/problem
    class JourneyMoon
    {
        public void Execute()
        {
            //int n = 5;
            //int[][] astronaut = new int[][] {
            //    new int[] { 0, 1 },
            //    new int[] { 2, 3 },
            //    new int[] { 0, 4 }
            //};
            //int resExp = 6;

            int n = 100000;
            int[][] astronaut = new int[][] {
                new int[] { 1, 2 },
                new int[] { 3, 4 }
            };
            long resExp = 4999949998;

            long result = journeyToMoon(n, astronaut);

            if (resExp != result)
            {
                Console.WriteLine("Errore - Expected: " + resExp + " - now: " + result);
            }
            else
            {
                Console.WriteLine(result);
                Console.WriteLine("Perfetto!!!");
            }
        }

        static long journeyToMoon(int n, int[][] astronaut)
        {
            long res = 0;

            bool[] arrb = new bool[n];
            Dictionary<int, Dictionary<int, bool>> arrView = new Dictionary<int, Dictionary<int, bool>>();
            HashSet<int> l0 = null;
            int a = 0;
            int b = 0;
            int x = 0;
            int y = 0;
            int numT = 0;
            Dictionary<int, HashSet<int>> t = new Dictionary<int, HashSet<int>>();

            for (int i = 0; i < astronaut.Length; i++)
            {
                x = astronaut[i][0];
                y = astronaut[i][1];

                if (y < x) { a = y; b = x; } else { a = x; b = y; }

                l0 = getValueMap(t, a);

                if (l0 == null)
                {
                    l0 = new HashSet<int>();
                    l0.Add(b);
                    t.Add(a, l0);
                    numT += 1;

                    Dictionary<int, bool> idb = new Dictionary<int, bool>();
                    idb.Add(b, false);
                    arrView.Add(a, idb);
                }
                else
                {
                    if (l0.Add(b)) { arrView[a].Add(b, false); }
                    t[a] = l0;
                }

                l0 = getValueMap(t, b);

                if (l0 == null)
                {
                    l0 = new HashSet<int>();
                    l0.Add(a);
                    t.Add(b, l0);
                    numT += 1;

                    Dictionary<int, bool> idb = new Dictionary<int, bool>();
                    idb.Add(a, false);
                    arrView.Add(b, idb);
                }
                else
                {
                    if (l0.Add(a)) { arrView[b].Add(a, false); }
                    t[b] = l0;
                }
            }

            int c = 0;
            List<List<int>> listCo = new List<List<int>>();
            List<int> astrC = null;

            foreach (KeyValuePair<int, HashSet<int>> row in t)
            {
                c = row.Key;
                if (!arrb[c])
                {
                    astrC = new List<int>();
                    astrC = findTot(astrC, c, 0, t, arrb);
                    listCo.Add(astrC);
                }
            }

            List<int> astrCT = new List<int>();
            int len = listCo.Count();
            long d = n - t.Count();
            long sum = 0;

            for (int i = 0; i < len; i++)
            {
                List<int> astrC1 = listCo[i];
                int len2 = astrC1.Count();

                res += (sum * len2);
                sum += len2;
            }

            if (d > 0)
            {
                for (int i = 1; i <= d; i++)
                {
                    res += (sum * 1);
                    sum += 1;
                }
            }

            return res;
        }

        static List<int> findTot(List<int> astrC, int vfirst, int y, Dictionary<int, HashSet<int>> t, bool[] arrb)
        {
            if (y == 0)
            {
                if (arrb[vfirst])
                {
                    return astrC;
                }
                arrb[vfirst] = true;
                astrC.Add(vfirst);
            }
            else
            {
                if (arrb[y])
                {
                    return astrC;
                }
                arrb[y] = true;
                astrC.Add(y);
            }

            Dictionary<int, bool> idb = new Dictionary<int, bool>();
            int b = 0;
            List<int> l1 = null;
            int caller = 0;

            if (y == 0)
            {
                l1 = new List<int>(t[vfirst]);
                caller = vfirst;
            }
            else
            {
                l1 = new List<int>(t[y]);
                caller = y;
            }
            int lenL1 = l1.Count();

            for (int i = 0; i < lenL1; i++)
            {
                b = l1[i];

                if (b == caller) { continue; }

                astrC = findTot(astrC, vfirst, b, t, arrb);
            }

            return astrC;
        }

        static T getValueMap<T>(Dictionary<int, T> t, int e)
        {
            T v;
            t.TryGetValue(e, out v);
            return v;
        }

    }
}
