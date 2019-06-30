using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace hackerRank
{
    class THL
    {
        public void Execute()
        {
            int[] t = new int[] { 1, 1, 4, 5, 1, 3, 2 };
            int[][] roads = new int[][] {
                new int[] { 1, 2, 3 },
                new int[] { 2, 6, 2 },
                new int[] { 2, 3, 4 },
                new int[] { 3, 4, 3 },
                new int[] { 2, 4, 9 },
                new int[] { 5, 7, 9 }
            };
            int[][] queries = new int[][] {
                new int[] { 1, 2, 4 }
            };
            //int resExp = 4;

            bool testFile = true;

            int n = 0;
            int m = 0;
            int q = 0;
            int[] S = { };
            string dir = "";

            if (testFile)
            {
                dir = @"F:\test\hr\hackerRank\hackerRank\testTHL\";
                var fileStream = new FileStream(dir + "input01.txt", FileMode.Open, FileAccess.Read);

                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    string line;
                    int i = 0;
                    int countR = 0;
                    int countQ = 0;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (i == 0)
                        {
                            S = line.Split(' ').Select(Int32.Parse).ToArray();
                            n = S[0];
                            m = S[1];
                            q = S[2];
                            t = new int[n];
                            roads = new int[m][];
                            queries = new int[q][];
                        }
                        else if (i == 1)
                        {
                            t = line.Split(' ').Select(Int32.Parse).ToArray();
                        }
                        else if (i >= 2 && i < n + 2)
                        {
                            roads[countR] = line.Split(' ').Select(Int32.Parse).ToArray();
                            countR++;
                        }
                        else if (i >= n + 2)
                        {
                            queries[countQ] = line.Split(' ').Select(Int32.Parse).ToArray();
                            countQ++;
                        }
                        i++;
                    }
                }
            }

            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            travel(t, roads, queries);

            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

            ////////////////////////// test with output
            bool exeTestResults = false;

            if (exeTestResults)
            {
                dir = @"F:\test\hr\hackerRank\hackerRank\testTHL\";
                var fileStream = new FileStream(dir + "output01.txt", FileMode.Open, FileAccess.Read);

                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    string line;
                    int i = 0;
                    int x = 0;
                    int y = 0;
                    int k = 0;
                    int[] arrQ;
                    string res = "";

                    var roadsTmp = ((from a in roads select a[0]).Concat(
                                    from b in queries select b[1])
                                    ).Distinct();

                    Dictionary<int, int[][]> roadsQConn = roadsTmp.ToDictionary(
                                                    p => p,
                                                    p => (from a in roads.Where(a => a[0].Equals(p) || a[1].Equals(p))
                                                          orderby a[2]
                                                          select a).ToArray()
                                                    );

                    int totBuildInRoads = roads.Select(a => t[a[0]]).Concat(roads.Select(b => t[b[1]])).Distinct().Count();

                    while ((line = streamReader.ReadLine()) != null)
                    {

                        arrQ = queries[i];
                        x = arrQ[0];
                        y = arrQ[1];
                        k = arrQ[2];

                        if (totBuildInRoads < k)
                        {
                            res = "-1";
                        }
                        else
                        {
                            res = printAnswerOfQuery(x, y, k, t, roads, roadsQConn);
                        }

                        if (res.Trim() != line.Trim())
                        {
                            Console.WriteLine("Errore!! Caso di test n° " + (i + 1).ToString() + 
                                                    " - Output: " + res.Trim() + " - Output Expected: " + line.Trim());
                            break;
                        }

                        i++;
                    }
                }
            }
        }

        static void travel(int[] t, int[][] roads, int[][] queries)
        {
            string res = "";
            int x = 0;
            int y = 0;
            int k = 0;

            var roadsTmp = ((from a in roads select a[0]).Concat(
                from b in roads select b[1])
                    ).Distinct();

            Dictionary<int, int[][]> roadsQConn = roadsTmp.ToDictionary(
                                            p => p,
                                            p => (from a in roads.Where(a => a[0].Equals(p) || a[1].Equals(p))
                                                    orderby a[2]
                                                    select a).ToArray()
                                            );

            int totBuildInRoads = roads.Select(a => t[a[0]]).Concat(roads.Select(b => t[b[1]])).Distinct().Count();

            foreach (int[] arrQ in queries)
            {
                x = arrQ[0];
                y = arrQ[1];
                k = arrQ[2];

                if (totBuildInRoads < k)
                {
                    Console.WriteLine("-1");
                }
                else
                {
                    res = printAnswerOfQuery(x, y, k, t, roads, roadsQConn);
                    Console.WriteLine(res);
                }
            }
        }

        static string printAnswerOfQuery(int x, int y, int k, int[] t, int[][] roadsOrig, Dictionary<int, int[][]> roadsConn)
        {
            string res = "";
            int levelS = 0;
            int levelE = 0;

            List<int> listPathsFound = new List<int>();
            HashSet<int> listCityVisited = new HashSet<int>();

            int[][] connX = getConn(x, roadsConn);
            int[][] connY = getConn(y, roadsConn);

            if (connX == null || connY == null)
            {
                return "-1";
            }

            listPathsFound.Add(x);

            int d = (from a in connX
                        where (a[0].Equals(x) && a[1].Equals(y)) || (a[0].Equals(y) && a[1].Equals(x))
                        select a).Count();

            if (d > 0)
            {
                listPathsFound.Add(y);

                return res;
            }

            bool pathFound = false;
            int start = x;
            int finish = y;

            int[] arrS;
            int[] arrE;
            int[] arrST;
            int[] arrET;

            arrS = ((from a in connX select a[0]).Concat(from b in connX select b[1])).Where(c => !c.Equals(start)).Distinct().ToArray();
            arrE = ((from a in connY select a[0]).Concat(from b in connY select b[1])).Where(c => !c.Equals(finish)).Distinct().ToArray();

            var se = arrS.Intersect(arrE);
            if (se.Count() > 0)
            {
                pathFound = true;
            }

            listCityVisited.Add(start);
            listCityVisited.Add(finish);

            Dictionary<int, int[][]> citiesMetX = new Dictionary<int, int[][]>();
            Dictionary<int, int[][]> citiesMetY = new Dictionary<int, int[][]>();

            levelS++;
            levelE++;

            citiesMetX.Add(levelS, connX);
            citiesMetY.Add(levelE, connY);

            var roadsElab = (from a in roadsConn
                            where !listCityVisited.Contains(a.Key)
                            select a);

            while (!pathFound)
            {
                var nextXT = (from a in roadsElab where arrS.Contains(a.Key) select a.Value).SelectMany(p => p);
                if (nextXT.Count() == 0)
                {
                    break;
                }

                var nextYT = (from a in roadsElab where arrE.Contains(a.Key) select a.Value).SelectMany(p => p);
                if (nextYT.Count() == 0)
                {
                    break;
                }

                arrST = ((from a in nextXT select a[0]).Concat(from b in nextXT select b[1])).Where(c => !arrS.Contains(c)).Distinct().ToArray();

                se = arrST.Intersect(arrE);
                if (se.Count() > 0)
                {
                    levelS++;
                    citiesMetX.Add(levelS, nextXT.ToArray());

                    pathFound = true;
                    break;
                }

                levelE++;
                citiesMetY.Add(levelE, nextYT.ToArray());
                arrET = ((from a in nextYT select a[0]).Concat(from b in nextYT select b[1])).Where(c => !arrE.Contains(c)).Distinct().ToArray();

                se = arrET.Intersect(arrS);
                if (se.Count() > 0)
                {
                    pathFound = true;
                    break;
                }

                levelS++;
                citiesMetX.Add(levelS, nextXT.ToArray());

                se = arrST.Intersect(arrET);
                if (se.Count() > 0)
                {
                    pathFound = true;
                    break;
                }

                listCityVisited.UnionWith(arrST);
                listCityVisited.UnionWith(arrET);

                roadsElab = roadsElab.Where(a => !listCityVisited.Contains(a.Key));

                arrS = arrST;
                arrE = arrET;
            }

            if (!pathFound)
            {
                return "-1";
            }

            int totx = citiesMetX.Aggregate(0, (total, kv) =>
            {
                total += (kv.Value.Select(a => t[a[0]]).Concat(kv.Value.Select(a => t[a[1]]))).Distinct().Count();
                return total;
            });

            int toty = citiesMetY.Aggregate(0, (total, kv) =>
            {
                total += (kv.Value.Select(a => t[a[0]]).Concat(kv.Value.Select(a => t[a[1]]))).Distinct().Count();
                return total;
            });


            return res;
        }

        static int[][] getConn(int n, Dictionary<int, int[][]> roadsConn)
        {
            int[][] conn;

            roadsConn.TryGetValue(n, out conn);

            if (conn == null)
            {
                return null;
            }
            if (conn.Count() == 0)
            {
                return null;
            }

            return conn;
        }

    }
}
