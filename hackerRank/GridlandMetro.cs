using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class GridlandMetro
    {
        public void Execute()
        {
            long n = 4;
            long m = 4;
            int k = 3;

            long[][] track = new long[][] {
                new long[] { 2, 2, 3 },
                new long[] { 3, 1, 4 },
                new long[] { 4, 4, 4 }
            };
            int resExp = 9;

            bool testFile = false;
            long[] S = { };
            string dir = "";
            if (testFile)
            {
                dir = @"F:\test\hr\hackerRank\hackerRank\testGridlandMetro\";
                var fileStream = new FileStream(dir + "input07.txt", FileMode.Open, FileAccess.Read);

                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    string line;
                    int i = 0;
                    int countQ = 0;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (i == 0)
                        {
                            S = line.Split(' ').Select(Int64.Parse).ToArray();
                            n = S[0];
                            m = S[1];
                            //k = S[2];
                            track = new long[S[1]][];
                        }
                        else if (i > 0)
                        {
                            S = line.Split(' ').Select(Int64.Parse).ToArray();
                            track[countQ] = S;
                            countQ++;
                        }
                        i++;
                    }
                }
            }

            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            long result = gridlandMetro(n, m, k, track);

            watch.Stop();

            if (resExp != result)
            {
                Console.WriteLine("Errore - Expected: " + resExp + " - now: " + result);
            }
            else
            {
                Console.WriteLine(result);
                Console.WriteLine("Perfetto!!!");
            }
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
        }

        static long gridlandMetro(long n, long m, int k, long[][] track)
        {
            long res = 0;

            if (k == 0) { return 0; }

            long[] arrT = new long[n + 1];

            long r = 0;
            long c1 = 0;
            long c2 = 0;
            long cc1 = 0;
            long cc2 = 0;
            Dictionary<long, List<long[]>> t = new Dictionary<long, List<long[]>>();
            Dictionary<long, long> tSucc = new Dictionary<long, long>();
            //Dictionary<long, List<long[]>> lampposts = new Dictionary<long, List<long[]>>();
            Dictionary<long, long> lamppostsTot = new Dictionary<long, long>();
            Dictionary<long, bool> tFreeUp = new Dictionary<long, bool>();
            Dictionary<long, bool> tFreeBottom = new Dictionary<long, bool>();
            //Dictionary<long, long> tTot = new Dictionary<long, long>();

            long[] l0 = null;
            List<long[]> l1 = null;
            List<long[]> lUp = null;
            //List<long[]> list1 = new List<long[]>();
            List<long[]> listT;
            List<long[]> listFree = new List<long[]>();
            long tot = 0;
            long maxR = track.Max(e => e[0]);
            int nRow = 0;
            bool upFree = false;
            bool bottomFree = false;
            long rPrev = 0;
            long minC = 0;
            long maxC = 0;
            long lim1 = 0;
            long lim2 = 0;
            int count = 0;
            int count2 = 0;
            bool fOver = false;
            int ind = 0;

            long[][] t1 = track.OrderBy(e => e[0]).ToArray();
            
            for (int i = 0; i < k; i++)
            {
                r = t1[i][0];
                c1 = t1[i][1];
                c2 = t1[i][2];

                l1 = getValueMap(t, r);

                l0 = new long[2];
                l0[0] = c1;
                l0[1] = c2;

                if (l1 == null)
                {
                    l1 = new List<long[]>();
                    l1.Add(l0);
                    t.Add(r, l1);

                    //lampposts.Add(r, new List<long[]>());
                    lamppostsTot.Add(r, 0);
                    if (rPrev == 0)
                    {
                        if (r > 1) { tFreeUp.Add(r, true); } else { tFreeUp.Add(r, false); }
                    }
                    else
                    {
                        if (r > rPrev + 1)
                        {
                            tFreeUp.Add(r, true);
                            tFreeBottom.Add(rPrev, true);
                        }
                        else
                        {
                            tFreeUp.Add(r, false);
                            tFreeBottom.Add(rPrev, false);
                        }
                        if (r == maxR)
                        {
                            if (maxR < n) { tFreeBottom.Add(r, true); } else { tFreeBottom.Add(r, false); }
                        }
                        tSucc.Add(rPrev, r);
                    }
                }
                else
                {
                    fOver = false;
                    listT = new List<long[]>(t[r].OrderBy(x => x[0]));
                    ind = 0;
                    foreach (long[] a in listT)
                    {
                        if (!(c1 > a[1] + 1 || c2 < a[0] - 1))
                        {
                            if (c1 < a[0])
                            {
                                minC = c1;
                            }
                            else
                            {
                                minC = a[0];
                            }
                            if (c2 > a[1])
                            {
                                maxC = c2;
                            }
                            else
                            {
                                maxC = a[1];
                            }
                            fOver = true;
                            break;
                        }
                        ind += 1;
                    }
                    if (fOver)
                    {
                        l1[ind][0] = minC;
                        l1[ind][1] = maxC;
                    }
                    else
                    {
                        l1.Add(l0);
                    }
                    t[r] = l1;
                }

                if (r != rPrev) { rPrev = r; }
                nRow += 1;
            }

            nRow = 0;

            foreach (KeyValuePair<long, List<long[]>> row in t)
            {
                l1 = row.Value.OrderBy(e => e[0]).ToList();
                count = l1.Count();
                //minC = l1[0][0];
                //maxC = l1[count - 1][1];
                upFree = tFreeUp[row.Key];
                bottomFree = tFreeBottom[row.Key];

                for (int i = 0; i < count; i++)
                {
                    c1 = l1[i][0];
                    c2 = l1[i][1];
                    if (c1 > 1) { lim1 = c1 - 1; } else { lim1 = c1; }
                    if (c2 < m) { lim2 = c2 + 1; } else { lim2 = c2; }

                    if (upFree)
                    {
                        //lampposts[row.Key].Add(new long[3] { row.Key - 1, lim1, lim2 });
                        lamppostsTot[row.Key] += (lim2 - lim1 + 1);
                    }

                    lUp = t[row.Key - 1];
                    count2 = lUp.Count();
                    for (int j = 0; j < count2; j++)
                    {
                        cc1 = lUp[i][0];
                        cc2 = lUp[i][1];


                    }

                    if (bottomFree)
                    {
                        //lampposts[row.Key].Add(new long[3] { row.Key +1,  lim1, lim2 });
                        lamppostsTot[row.Key] += (lim2 - lim1 + 1);
                        if (c1 > 1)
                        {
                            lamppostsTot[row.Key] += 1;
                        }
                        if (c2 < m)
                        {
                            lamppostsTot[row.Key] += 1;
                        }
                    }
                }

                nRow += 1;
                if (row.Key != rPrev) { rPrev = row.Key; }
            }

            res = lamppostsTot.Sum(e => e.Value);

            return res;
        }

        static List<long[]> getValueMap(Dictionary<long, List<long[]>> t, long e)
        {
            List<long[]> v = null;
            t.TryGetValue(e, out v);
            return v;
        }

    }
}
