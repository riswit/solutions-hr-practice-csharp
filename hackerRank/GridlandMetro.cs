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
            Dictionary<long, List<long[]>> t = new Dictionary<long, List<long[]>>();
            Dictionary<long, List<long[]>> tFree = new Dictionary<long, List<long[]>>();
            Dictionary<long, long> tTot = new Dictionary<long, long>();

            long[] l0 = null;
            List<long[]> l1 = null;
            List<long[]> list1 = new List<long[]>();
            long tot = 0;

            for (int i = 0; i < track.Length; i++)
            {
                r = track[i][0];
                c1 = track[i][1];
                c2 = track[i][2];

                l1 = getValueMap(t, r);

                l0 = new long[2];
                //if (c1 > 1) { l0[0] = c1 - 1; tot += 1; } else { l0[0] = c1; }
                //if (c2 < m) { l0[1] = c2 + 1; tot += 1; } else { l0[1] = c2; }
                l0[0] = c1;
                l0[1] = c2;

                if (l1 == null)
                {
                    list1 = new List<long[]>();
                    list1.Add(l0);
                    t.Add(r, list1);
                    tTot.Add(r, tot);
                    tFree.Add(r, new List<long[]>());
                }
                else
                {
                    list1.Add(l0);
                    t[r] = list1;
                }
            }

            var t1 = t.OrderBy(e => e.Key);
            long min = 0;
            long max = 0;

            foreach (KeyValuePair<long, List<long[]>> row in t1)
            {
                l1 = row.Value.OrderBy(e => e[0]).ToList();
                min = 10000000000;
                max = 0;
                for (int i = 0; i < l1.Count; i++)
                {
                    c1 = l1[i][0];
                    c2 = l1[i][1];
                    if (c1 < min) { min = c1; }
                    if (c2 > max) { max = c2; }
                    
                }

            }

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
