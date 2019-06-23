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
                    while ((line = streamReader.ReadLine()) != null)
                    {

                        arrQ = queries[i];
                        x = arrQ[0];
                        y = arrQ[1];
                        k = arrQ[2];
                        res = printAnswerOfQuery(x, y, k, t, roads, queries);

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
            int[] arrQ;
            int x = 0;
            int y = 0;
            int k = 0;

            IGrouping<int, int>[] roadsWithConn = getRoadsWithConnects(roads);
            int[][] roadsWithConnArr = (from a in roadsWithConn select new int[2] { a.Key, a.Count() }).ToArray();
            var totBuildsDistConnected = (from arr in roadsWithConn.Select(e => t[e.Key]) select arr).Distinct();

            int totBuildDistConnected = totBuildsDistConnected.Count();

            for (int q = 0; q < queries.Length; q++)
            {
                arrQ = queries[q];
                x = arrQ[0];
                y = arrQ[1];
                k = arrQ[2];

                if (totBuildDistConnected < k)
                {
                    Console.WriteLine("-1");
                }
                else
                {
                    res = printAnswerOfQuery(x, y, k, t, roads, roadsWithConnArr);
                    Console.WriteLine(res);
                }
            }
        }

        //static string printAnswerOfQuery(int x, int y, int k, int[] t, int[][] roadsOrig, int[][] queries)
        //{
        //    string res = "";

        //    List<int> listBuild = new List<int>();
        //    List<int> listCrowd = new List<int>();
        //    List<int[]> listPathTmp = new List<int[]>();
        //    List<int[]> listPath = new List<int[]>();
        //    List<int[]> listCityPathStart = new List<int[]>();
        //    List<int[]> listCityPathEnd = new List<int[]>();
        //    List<int[]> listConnectedPoint = new List<int[]>();
        //    HashSet<int> hashPathsNumCityAnalyzed = new HashSet<int>();
        //    HashSet<int> hashBuild = new HashSet<int>();
        //    int maxCrowd = 0;
        //    bool finish = false;
        //    int min = 0;
        //    int max = 0;
        //    List<int> numKMet = new List<int>();
        //    int[][] tmp;
        //    int totBuildMet = 0;
        //    int nBuildMet = 0;
        //    if (x > y) { min = y; max = x; } else { min = x; max = y; }
        //    int start = min;
        //    int end = max;
        //    int[] r;
        //    int tot = 0;
        //    int a = 0;
        //    int b = 0;
        //    int u = 0;
        //    int cX = x;
        //    int cY = y;
        //    int c = 0;
        //    bool pathFound = false;
        //    int countCycle = 0;
        //    int counterListStart = 0;
        //    int counterListEnd = 0;
        //    int actListAnalyze = 0; // 0: Start - 1: End
        //    int totListStart = 0;
        //    int totListEnd = 0;
        //    int numCityAnalyzed = 0;

        //    //find path from x to y

        //    for (int i1 = 1; i1 <= 2; i1++)
        //    {
        //        if (i1 == 1) { c = cX; } else { c = cY; }

        //        hashPathsNumCityAnalyzed.Add(c);                

        //        if (i1 == 1)
        //        {
        //            tot = getRoadsOfNumCity(c, k, t, roadsOrig, listBuild, listCrowd, listPath, listCityPathStart);
        //        }
        //        else
        //        {
        //            tot = getRoadsOfNumCity(c, k, t, roadsOrig, listBuild, listCrowd, listPath, listCityPathEnd);
        //        }

        //        if (tot == 0)
        //        {
        //            //Console.WriteLine("-1");
        //            res = "-1";
        //            return res;
        //        }
        //    }

        //    nBuildMet = listBuild.Distinct().Count();

        //    if (existPath(x, y, listCityPathStart) > 0)
        //    {
        //        pathFound = true;
        //    }
        //    else if (existPath(x, y, listCityPathEnd) > 0)
        //    {
        //        pathFound = true;
        //    }

        //    //pathFound = verifyStartEnd(0, listCityPathStart, listCityPathEnd);

        //    while (nBuildMet <= t.Length)
        //    {

        //        totListStart = listCityPathStart.Count();
        //        totListEnd = listCityPathEnd.Count();

        //        for (int i = counterListStart; i < totListStart && !pathFound; i++)
        //        {
        //            c = listCityPathStart[counterListStart][1];
        //            counterListStart++;

        //            if (!existInHashPathsNumCityAnalyzed(c, hashPathsNumCityAnalyzed))
        //            {
        //                hashPathsNumCityAnalyzed.Add(c);

        //                tot = getRoadsOfNumCity(c, k, t, roadsOrig, listBuild, listCrowd, listPath, listCityPathStart);

        //                pathFound = verifyStartEnd(totListStart - 1, listCityPathStart, listCityPathEnd, listConnectedPoint);

        //                if (pathFound)
        //                {
        //                    c = listCityPathEnd[counterListEnd][1];
        //                    counterListEnd++;

        //                    hashPathsNumCityAnalyzed.Add(c);

        //                    tot = getRoadsOfNumCity(c, k, t, roadsOrig, listBuild, listCrowd, listPath, listCityPathEnd);

        //                    pathFound = verifyEndStart(totListEnd - 1, listCityPathStart, listCityPathEnd, listConnectedPoint);

        //                }
        //            }
        //        }

        //        nBuildMet = listBuild.Distinct().Count();

        //        countCycle += 1;
        //    }

        //    if (nBuildMet >= t.Length && !pathFound)
        //    {
        //        //Console.WriteLine("-1");
        //        res = "-1";
        //        return res;
        //    }


        //    //path found, then find better road (road wih min crowd)


        //    //write max Crowd


        //    return res;
        //}

        static string printAnswerOfQuery(int x, int y, int k, int[] t, int[][] roadsOrig, int[][] roadsWithConn)
        {
            string res = "";

            List<int[][]> listPathsFound = new List<int[][]>();
            int numCityAnalyzed = 0;

            //find alls paths from x to y

            int[][] roadsCityTo = (from a in roadsOrig
                                where a[0].Equals(x) || a[1].Equals(x)
                                select new int[3] { a[0].Equals(x) ? a[0] : a[1], a[0].Equals(x) ? a[1] : a[0], a[2] } ).ToArray();

            if (roadsCityTo.Count() == 0)
            {
                res = "-1";
                return res;
            }

            listPathsFound.Add(roadsCityTo);

            var roadsCityToDelete = new int[1] { x };

            int[][] roadsDone = (from a in roadsOrig
                                 select new int[3] { roadsCityToDelete.Contains(a[0]) && !a[0].Equals(y) ? a[0] * -1 : a[0],
                                                     roadsCityToDelete.Contains(a[1]) && !a[0].Equals(y) ? a[1] * -1 : a[1],
                                                        a[2] }).ToArray();

            Dictionary<int, int[][]> dictPathsWithY = new Dictionary<int, int[][]>();

            int[][] pathsY = (from a in roadsCityTo.Where(e => e.Contains(y))
                              select a).ToArray();

            dictPathsWithY.Add(0, pathsY);

            dictPathsWithY = getPaths(x, y, roadsWithConn, roadsDone, roadsCityTo, listPathsFound, dictPathsWithY);



            //path found, then find better road (road wih min crowd)


            //write max Crowd


            return res;
        }

        static Dictionary<int, int[][]> getPaths(int x, int y, int[][] roadsWithConn, int[][] roadsDone, int[][] roadsCityTo, List<int[][]> listPathsFound, Dictionary<int, int[][]> dictPathsWithY)
        {
            int level = 0;
            findParents(x, y, level, roadsDone, roadsCityTo, listPathsFound, dictPathsWithY);

            return dictPathsWithY;
        }

        static bool findParents(int from, int to, int level, int[][] roadsDone, int[][] roadsCityTo, List<int[][]> listPathsFound, Dictionary<int, int[][]> dictPathsWithY)
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

            if (roadsCityNearCity.Count() == 0) { return true; };

            listPathsFound.Add(roadsCityNearCity);

            var roadsCityToDelete = roadsCityTo.Select(s => s[1]);
            roadsDone = (from a in roadsDone
                        select new int[3] { roadsCityToDelete.Contains(a[0]) && !a[0].Equals(to) ? a[0] * -1 : a[0],
                                            roadsCityToDelete.Contains(a[1]) && !a[1].Equals(to) ? a[1] * -1 : a[1],
                                                        a[2] }).ToArray();

            int[][] pathsY = (from a in roadsCityNearCity.Where(e => e.Contains(to))
                                    select a).ToArray();

            level++;
            dictPathsWithY.Add(level, pathsY);

            return findParents(from, to, level, roadsDone, roadsCityNearCity, listPathsFound, dictPathsWithY);
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
