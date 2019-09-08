using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    //https://www.hackerrank.com/challenges/similarpair/problem
    //keys: dfs
    class SimilarPair
    {
        public void Execute()
        {
            int n = 6;
            int k = 2;
            int[][] edges = new int[][] {
                new int[] { 1, 2 },
                new int[] { 1, 3 },
                new int[] { 3, 4 },
                new int[] { 3, 5 },
                new int[] { 3, 6 }
            };
            //int resExp = 4;
            //int resExp = 642387;  //4
            //int resExp = 19976;   //5
            int resExp = 248;       //6

            bool testFile = true;
            int totQ = 0;
            int[] S = { };
            string dir = "";
            int numTest = 1;
            int t = 1;

            if (testFile)
            {
                dir = @"F:\test\hr\hackerRank\hackerRank\testSimilarPair\";
                var fileStream = new FileStream(dir + "input06.txt", FileMode.Open, FileAccess.Read);

                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    string line;
                    int i = 0;
                    int countQ = 0;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (i == 0)
                        {
                            S = line.Split(' ').Select(Int32.Parse).ToArray();
                            edges = new int[S[0] - 1][];
                            n = S[0];
                            k = S[1];
                        }
                        else if (i > 0)
                        {
                            S = line.Split(' ').Select(Int32.Parse).ToArray();
                            edges[countQ] = S;
                            countQ++;
                        }
                        i++;
                    }

                }
            }

            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            int result = similarPair(n, k, edges);

            watch.Stop();

            if (string.Join(" ", resExp) != string.Join(" ", result))
            {
                Console.WriteLine("Errore - Expected: " + string.Join(" ", resExp) + " - now: " + string.Join(" ", result));
            }
            else
            {
                Console.WriteLine("Expected: " + string.Join(" ", resExp));
                Console.WriteLine("Perfetto!!!");
            }
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
        }


        static int similarPair(int n, int k, int[][] edges)
        {
            if (k == 0 || n == 1) { return 0; }

            int res = 0;

            Dictionary<int, List<int>> t = new Dictionary<int, List<int>>();
            int v = 0;
            int w = 0;
            List<int> l0 = null;
            int a = 0;
            int b = 0;
            int numT = 0;

            Dictionary<int, Dictionary<int, bool>> arrView = new Dictionary<int, Dictionary<int, bool>>();

            //var e1 = edges.OrderBy(x => x[0]).ToArray();
            //int lene1 = e1.Count();

            for (int i = 0; i < edges.Length; i++)
            {
                a = edges[i][0];
                b = edges[i][1];

                l0 = getValueMap(t, a);

                if (l0 == null)
                {
                    l0 = new List<int>();
                    l0.Add(b);
                    t.Add(a, l0);
                    numT += 1;

                    Dictionary<int, bool> idb = new Dictionary<int, bool>();
                    idb.Add(b, false);
                    arrView.Add(a, idb);
                }
                else
                {
                    l0.Add(b);
                    t[a] = l0;
                    arrView[a].Add(b, false);
                }

                l0 = getValueMap(t, b);

                if (l0 == null)
                {
                    l0 = new List<int>();
                    l0.Add(a);
                    t.Add(b, l0);
                    numT += 1;

                    Dictionary<int, bool> idb = new Dictionary<int, bool>();
                    idb.Add(a, false);
                    arrView.Add(b, idb);
                }
                else
                {
                    l0.Add(a);
                    t[b] = l0;
                    arrView[b].Add(a, false);
                }

            }

            int tot = 0;
            int c = 0;
            Dictionary<int, HashSet<int>> dAnc = new Dictionary<int, HashSet<int>>();

            foreach (KeyValuePair<int, List<int>> row in t)
            {
                c = row.Key;
                res += findTot2(tot, c, 0, c, t, arrView, k, dAnc);
            }

            return res;
        }

        static int findTot2(int tot, int vfirst, int y, int vCaller, Dictionary<int, List<int>> t, 
                            Dictionary<int, Dictionary<int, bool>> arrView, 
                            int k, Dictionary<int, HashSet<int>> dAnc)
        {
            Dictionary<int, bool> idb = new Dictionary<int, bool>();

            bool p1 = false;
            bool p2 = false;
            if (y != 0)
            {
                if (arrView[vfirst][y] || arrView[y][vfirst])
                {
                    return tot;
                }

                arrView[vfirst][y] = true;
                arrView[y][vfirst] = true;
            }

            int b = 0;
            bool fx = false;
            bool fy = false;
            HashSet<int> hx = null;
            HashSet<int> hy = null;
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

                if (b == caller || b == vCaller) { continue; }

                fx = false;
                fy = false;
                if (isOk(vfirst, b, k))
                {
                    hx = getValueMap(dAnc, vfirst);
                    if (hx == null)
                    {
                        hx = new HashSet<int>();
                        hx.Add(b);
                        dAnc.Add(vfirst, hx);
                        fx = true;
                    }
                    else
                    {
                        if (hx.Add(b))
                        {
                            fx = true;
                        }
                        dAnc[vfirst] = hx;
                    }


                    hy = getValueMap(dAnc, b);
                    if (hy == null)
                    {
                        hy = new HashSet<int>();
                        hy.Add(vfirst);
                        dAnc.Add(b, hy);
                        fy = true;
                    }
                    else
                    {
                        if (hy.Add(vfirst))
                        {
                            fy = true;
                        }
                        dAnc[b] = hy;
                    }

                    if (fx && fy)
                    {
                        tot += 1;
                    }

                }

                tot = findTot2(tot, vfirst, b, caller, t, arrView, k, dAnc);
            }

            return tot;
        }



        static int similarPair_SLOW_31Points(int n, int k, int[][] edges)
        {
            if (k == 0 || n == 1) { return 0; }

            int res = 0;
            HashSet<HashSet<int>> hs = new HashSet<HashSet<int>>();

            Dictionary<int, List<int>> t = new Dictionary<int, List<int>>();
            int v = 0;
            int w = 0;
            HashSet<int> h0 = null;
            List<int> l0 = null;
            int a = 0;
            int b = 0;
            int numT = 0;
            bool[][] arrView = new bool[n + 1][];
            arrView[0] = new bool[n + 1];

            for (int i = 0; i < edges.Length; i++)
            {
                a = edges[i][0];
                b = edges[i][1];

                l0 = getValueMap(t, a);

                if (l0 == null)
                {
                    l0 = new List<int>();
                    l0.Add(b);
                    t.Add(a, l0);
                    numT += 1;
                    arrView[a] = new bool[n + 1];
                }
                else
                {
                    l0.Add(b);
                    t[a] = l0;
                }

                l0 = getValueMap(t, b);

                if (l0 == null)
                {
                    l0 = new List<int>();
                    l0.Add(a);
                    t.Add(b, l0);
                    numT += 1;
                    arrView[b] = new bool[n + 1];
                }
                else
                {
                    l0.Add(a);
                    t[b] = l0;
                }

            }

            //for (int i = 0; i < numT; i++)
            //{
            //    List<int> r = t.ElementAt(i).Value.OrderBy(x => x).ToList();
            //    t[t.ElementAt(i).Key] = r;
            //}
            //return res;

            int tot = 0;
            int c = 0;
            Dictionary<int, HashSet<int>> dAnc = new Dictionary<int, HashSet<int>>();
            for (int i = 0; i < numT; i++)
            {
                c = t.ElementAt(i).Key;
                res += findTot(tot, c, 0, c, t, arrView, k, dAnc);
            }

            return res;
        }

        static int findTot(int tot, int vfirst, int y, int vCaller, Dictionary<int, List<int>> t, bool[][] arrView, int k, Dictionary<int, HashSet<int>> dAnc)
        {
            if (arrView[vfirst][y] || arrView[y][vfirst])
            {
                return tot;
            }
            arrView[vfirst][y] = true;
            arrView[y][vfirst] = true;

            int b = 0;
            bool fx = false;
            bool fy = false;
            HashSet<int> hx = null;
            HashSet<int> hy = null;
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

                if (b == caller || b == vCaller) { continue; }

                fx = false;
                fy = false;
                if (isOk(vfirst, b, k))
                {
                    hx = getValueMap(dAnc, vfirst);
                    if (hx == null)
                    {
                        hx = new HashSet<int>();
                        hx.Add(b);
                        dAnc.Add(vfirst, hx);
                        fx = true;
                    }
                    else
                    {
                        if (hx.Add(b))
                        {
                            fx = true;
                        }
                        dAnc[vfirst] = hx;
                    }


                    hy = getValueMap(dAnc, b);
                    if (hy == null)
                    {
                        hy = new HashSet<int>();
                        hy.Add(vfirst);
                        dAnc.Add(b, hy);
                        fy = true;
                    }
                    else
                    {
                        if (hy.Add(vfirst))
                        {
                            fy = true;
                        }
                        dAnc[b] = hy;
                    }

                    if (fx && fy)
                    {
                        tot += 1;
                    }
                }

                tot = findTot(tot, vfirst, b, caller, t, arrView, k, dAnc);
            }

            return tot;
        }

        static bool isOk(int a, int b, int k)
        {
            if (Math.Abs(a - b) <= k)
            {
                return true;
            }
            return false;
        }

        static T getValueMap<T>(Dictionary<int, T> t, int e)
        {
            T v;
            t.TryGetValue(e, out v);
            return v;
        }

    }
}
