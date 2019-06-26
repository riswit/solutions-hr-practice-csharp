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

                    var roadsQueries = ((from a in queries select a[0]).Concat(
                                    from b in queries select b[1])
                                    ).Distinct();

                    Dictionary<int, int[][]> roadsQConn = roadsQueries.ToDictionary(
                                                    p => p,
                                                    p => (from a in roads.Where(a => a[0].Equals(p) || a[1].Equals(p))
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
                            Console.WriteLine("Errore!! Caso di test n° " + (i + 1).ToString() + " - Output: " + res.Trim() + " - Output Expected: " + line.Trim());
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

            //IGrouping<int, int>[] roadsWithConn = getRoadsWithConnects(roads);
            //int[][] roadsWithConnArr = (from a in roadsWithConn select new int[2] { a.Key, a.Count() }).ToArray();
            //var totBuildsDistConnected = (from arr in roadsWithConn.Select(e => t[e.Key]) select arr).Distinct();

            var roadsQueries = ((from a in queries select a[0]).Concat(
                from b in queries select b[1])
                    ).Distinct();

            Dictionary<int, int[][]> roadsQConn = roadsQueries.ToDictionary(
                                            p => p,
                                            p => (from a in roads.Where(a => a[0].Equals(p) || a[1].Equals(p))
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

        //static string printAnswerOfQuery(int x, int y, int k, int[] t, int[][] roadsOrig, Dictionary<int, int[][]> roadsQConn)
        //{
        //    string res = "";

        //    List<int[][]> listPathsFound = new List<int[][]>();
        //    int numCityAnalyzed = 0;

        //    //find alls paths from x to y

        //    int[][] roadsCityTo = (from a in roadsOrig
        //                        where a[0].Equals(x) || a[1].Equals(x)
        //                            orderby a[2]
        //                            select new int[3] { a[0].Equals(x) ? a[0] : a[1], a[0].Equals(x) ? a[1] : a[0], a[2] } ).ToArray();

        //    if (roadsCityTo.Count() == 0)
        //    {
        //        res = "-1";
        //        return res;
        //    }

        //    listPathsFound.Add(roadsCityTo);

        //    var roadsCityToDelete = new int[1] { x };

        //    int[][] roadsDone = (from a in roadsOrig
        //                            select new int[3] { roadsCityToDelete.Contains(a[0]) && !a[0].Equals(y) ? a[0] * -1 : a[0],
        //                                                roadsCityToDelete.Contains(a[1]) && !a[0].Equals(y) ? a[1] * -1 : a[1],
        //                                                a[2] }).ToArray();

        //    Dictionary<int, int[][]> dictPathsWithY = new Dictionary<int, int[][]>();

        //    int[][] pathsY = (from a in roadsCityTo.Where(e => e.Contains(y))
        //                        select a).ToArray();

        //    dictPathsWithY.Add(0, pathsY);

        //    //dictPathsWithY = getPaths(x, y, roadsWithConn, roadsDone, roadsCityTo, listPathsFound, dictPathsWithY);



        //    //path found, then find better road (road wih min crowd)


        //    //write max Crowd


        //    return res;
        //}

        static string printAnswerOfQuery(int x, int y, int k, int[] t, int[][] roadsOrig, Dictionary<int, int[][]> roadsQConn)
        {
            string res = "";

            List<int[][]> listPathsFound = new List<int[][]>();

            int[][] connX;
            roadsQConn.TryGetValue(x, out connX);

            int[][] connY;
            roadsQConn.TryGetValue(y, out connY);


            if (connX.Count() == 0 || connY.Count() == 0)
            {
                res = "-1";
                return res;
            }

            connX = (from a in connX orderby a[2] select new int[3] { a[0].Equals(x) ? a[0] : a[1], a[0].Equals(x) ? a[1] : a[0], a[2] } ).ToArray();
            connY = (from a in connY orderby a[2] select new int[3] { a[0].Equals(y) ? a[0] : a[1], a[0].Equals(y) ? a[1] : a[0], a[2] } ).ToArray();

            //int d = connX.Where(a => (a[0].Equals(x) && a[1].Equals(y)) || (a[0].Equals(y) && a[1].Equals(x))).Count();
            int d = (from a in connX
                     where (a[0].Equals(x) && a[1].Equals(y)) || (a[0].Equals(y) && a[1].Equals(x))
                     select a).Count();

            if (d > 0)
            {

                return res;
            }

            var roadsCityToTmp = connX.Select(s => s[1]);

            var pr1 = (from c in roadsOrig
                       group c by roadsCityToTmp.Contains(c[0]) || roadsCityToTmp.Contains(c[1]) into g
                       select g).Where(e => e.Key == true).SelectMany(p => p).ToArray();

            var roadsCityToTmp2 = connY.Select(s => s[1]);

            var pr2 = (from c in roadsOrig
                       group c by roadsCityToTmp2.Contains(c[0]) || roadsCityToTmp2.Contains(c[1]) into g
                       select g).Where(e => e.Key == true).SelectMany(p => p).ToArray();

            //var vPr1 = pr1.Where(a => a.Key == true);

            //int[][] roadsCityNearX = (from c in roadsOrig
            //                          where (roadsCityToTmp.Contains(c[0]) || roadsCityToTmp.Contains(c[1]))
            //                          && c[0] > 0 && c[1] > 0
            //                          orderby c[2]
            //                          select new int[3] { roadsCityToTmp.Contains(c[0]) ? c[0] : c[1],
            //                                                    roadsCityToTmp.Contains(c[0]) ? c[1] : c[0],
            //                                                                                        c[2] })
            //                                .ToArray();

            //var roadsCityToTmp2 = connY.Select(s => s[1]);

            //int[][] roadsCityNearY = (from c in roadsOrig
            //                          where (roadsCityToTmp.Contains(c[0]) || roadsCityToTmp.Contains(c[1]))
            //                          && c[0] > 0 && c[1] > 0
            //                          orderby c[2]
            //                          select new int[3] { roadsCityToTmp.Contains(c[0]) ? c[0] : c[1],
            //                                                    roadsCityToTmp.Contains(c[0]) ? c[1] : c[0],
            //                                                                                        c[2] })
            //                                .ToArray();

            return res;
        }

        static Dictionary<int, int[][]> getPaths(int x, int y, int[][] roadsWithConn, int[][] roadsDone, int[][] roadsCityTo, List<int[][]> listPathsFound, Dictionary<int, int[][]> dictPathsWithY)
        {
            int level = 1;
            int[][] roadsCityNearCity = findParents(x, y, level, roadsDone, roadsCityTo, listPathsFound, dictPathsWithY);

            while (roadsCityNearCity.Count() > 0)
            {
                level++;

                roadsCityNearCity = findParents(x, y, level, roadsDone, roadsCityTo, listPathsFound, dictPathsWithY);
            }
            return dictPathsWithY;
        }

        static int[][] findParents(int from, int to, int level, int[][] roadsDone, int[][] roadsCityTo, List<int[][]> listPathsFound, Dictionary<int, int[][]> dictPathsWithY)
        {
            var roadsCityToTmp = roadsCityTo.Select(s => s[1]);

            int[][] roadsCityNearCity = (from c in roadsDone.Where(cn =>
                            roadsCityToTmp.Contains(cn[0]) || roadsCityToTmp.Contains(cn[1]))
                                        where c[0] > 0 && c[1] > 0 
                                            orderby c[2]
                                            select new int[3] { roadsCityToTmp.Contains(c[0]) ? c[0] : c[1],
                                                                roadsCityToTmp.Contains(c[0]) ? c[1] : c[0],
                                                                                                    c[2] })
                                            .ToArray();

            //if (roadsCityNearCity.Count() == 0) { return true; };

            listPathsFound.Add(roadsCityNearCity);

            var roadsCityToDelete = roadsCityTo.Select(s => s[1]);
            roadsDone = (from a in roadsDone
                        select new int[3] { roadsCityToDelete.Contains(a[0]) && !a[0].Equals(to) ? a[0] * -1 : a[0],
                                            roadsCityToDelete.Contains(a[1]) && !a[1].Equals(to) ? a[1] * -1 : a[1],
                                                        a[2] }).ToArray();

            int[][] pathsY = (from a in roadsCityNearCity.Where(e => e.Contains(to))
                                    select a).ToArray();

            dictPathsWithY.Add(level, pathsY);

            //return findParents(from, to, level, roadsDone, roadsCityNearCity, listPathsFound, dictPathsWithY);
            return roadsCityNearCity;
        }

        static IGrouping<int,int>[] getRoadsWithConnects(int[][] roadsOrig)
        {
            var res = ((from a in roadsOrig select a[0]).Concat(
                            from b in roadsOrig select b[1])
                                ).GroupBy(x => x).Where(g => g.Count() > 0);
                            //.Select(y => y.Key)
                            //.ToArray();

            var res1 = (from a in res orderby a.Count() descending select a).ToArray();

            return res1;
        }

        /*
        static bool existInHashPathsNumCityAnalyzed(int n, HashSet<int> hashPathsNumCityAnalyzed)
        {
            var roadsE = from elem in hashPathsNumCityAnalyzed
                         where elem == n
                         select elem;
            if (roadsE.Count() > 0) { return true; }

            return false;
        }

        static bool verifyStartEnd(int start, List<int[]> listCityPathStart, List<int[]> listCityPathEnd, List<int[]> listConnectedPoint)
        {
            int e = 0;
            for (int i2 = start; i2 < listCityPathStart.Count(); i2++)
            {
                var roadsE = from array in listCityPathEnd
                             where (array[0] == listCityPathStart[i2][1] || array[1] == listCityPathStart[i2][1])
                             select array;
                if (roadsE.Count() > 0) {

                    int[][] arr = roadsE.ToArray();
                    if (listCityPathStart[i2][1] == arr[0][1])
                    {
                        e = arr[0][0];
                    }
                    else
                    {
                        e = arr[0][1];
                    }

                    listConnectedPoint.Add(new int[2] { listCityPathStart[i2][1] , e });
                    return true;
                }
            }

            return false;
        }

        static bool verifyEndStart(int start, List<int[]> listCityPathStart, List<int[]> listCityPathEnd, List<int[]> listConnectedPoint)
        {
            int e = 0;
            for (int i2 = start; i2 < listCityPathEnd.Count(); i2++)
            {
                var roadsE = from array in listCityPathStart
                             where (array[0] == listCityPathEnd[i2][1] || array[1] == listCityPathEnd[i2][1])
                             select array;
                if (roadsE.Count() > 0)
                {
                    int[][] arr = roadsE.ToArray();
                    if (listCityPathEnd[i2][1] == arr[0][1])
                    {
                        e = arr[0][0];
                    }
                    else
                    {
                        e = arr[0][1];
                    }

                    listConnectedPoint.Add(new int[2] { listCityPathEnd[i2][1], e });
                    return true;
                }
            }

            return false;
        }

        static List<int[]> getRoadsOfNumCity(int c, int[][] roadsOrig)
        {
            var roadsTmp = from array in roadsOrig
                           where (array[0].Equals(c) || array[1].Equals(c))
                           orderby array[2] select array;

            return roadsTmp.ToList();
        }

        static int existPath(int a, int b, List<int[]> listCityPathStart, List<int[]> listCityPathEnd)
        {
            int roadsTmp = (from arrayS in listCityPathStart
                            from arrayE in listCityPathEnd
                            where (arrayS[0].Equals(a) && arrayS[1].Equals(b)) || (arrayS[0].Equals(b) && arrayS[1].Equals(a))
                                || (arrayE[0].Equals(a) && arrayE[1].Equals(b)) || (arrayE[0].Equals(b) && arrayE[1].Equals(a))
                                || (arrayS[0].Equals(a) && arrayE[0].Equals(b))
                            select arrayS).Count();
            return roadsTmp;
        }

        */
    }
}
