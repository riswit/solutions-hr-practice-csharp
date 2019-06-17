using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace hackerRank
{
    class TravelHackerLand
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
                new int[] { 7, 1, 4 },
                new int[] { 6, 1, 4 },
                new int[] { 1, 2, 4 }
            };
            //int resExp = 4;

            int n = 0;
            int m = 0;
            int q = 0;
            int[] S = { };

            string dir = @"F:\test\hr\hackerRank\hackerRank\testTravelHackerLand\";
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

            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            travel(t, roads, queries);

            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
        }

        static void travel(int[] t, int[][] roads, int[][] queries)
        {
            int[] arrQ;
            int x = 0;
            int y = 0;
            int k = 0;

            for (int q = 0; q < queries.Length; q++)
            {
                arrQ = queries[q];
                x = arrQ[0];
                y = arrQ[1];
                k = arrQ[2];

                printAnswerOfQuery(x, y, k, t, roads, q, queries);

            }
        }

        static void printAnswerOfQuery(int x, int y, int k, int[] t, int[][] roadsOrig, int q, int[][] queries)
        {
            List<int> listBuild = new List<int>();
            List<int> listCrowd = new List<int>();
            List<int[]> listPathTmp = new List<int[]>();
            List<int[]> listPath = new List<int[]>();
            List<int[]> listCityPathStart = new List<int[]>();
            List<int[]> listCityPathEnd = new List<int[]>();
            HashSet<int> hashPathsNumCityAnalyzed = new HashSet<int>();
            HashSet<int> hashBuild = new HashSet<int>();
            int maxCrowd = 0;
            bool finish = false;
            int min = 0;
            int max = 0;
            List<int> numKMet = new List<int>();
            int[][] tmp;
            int totBuildMet = 0;
            int nBuildMet = 0;
            if (x > y) { min = y; max = x; } else { min = x; max = y; }
            int start = min;
            int end = max;
            int[] r;
            int tot = 0;
            int a = 0;
            int b = 0;
            int u = 0;
            int cX = x;
            int cY = y;
            int c = 0;
            bool pathFound = false;
            int countCycle = 0;
            int counterListStart = 0;
            int counterListEnd = 0;
            int actListAnalyze = 0; // 0: Start - 1: End
            int totListStart = 0;
            int totListEnd = 0;
            int numCityAnalyzed = 0;

            //find path from x to y

            for (int i1 = 1; i1 <= 2; i1++)
            {
                if (i1 == 1) { c = cX; } else { c = cY; }

                hashPathsNumCityAnalyzed.Add(c);                

                if (i1 == 1)
                {
                    tot = getRoadsOfNumCity(c, k, t, roadsOrig, listBuild, listCrowd, listPath, listCityPathStart);
                }
                else
                {
                    tot = getRoadsOfNumCity(c, k, t, roadsOrig, listBuild, listCrowd, listPath, listCityPathEnd);
                }

                if (tot == 0)
                {
                    Console.WriteLine("-1");
                    return;
                }
            }

            nBuildMet = listBuild.Distinct().Count();

            if (existPath(x, y, listCityPathStart) > 0)
            {
                pathFound = true;
            }
            else if (existPath(x, y, listCityPathEnd) > 0)
            {
                pathFound = true;
            }

            pathFound = verifyStartEnd(0, listCityPathStart, listCityPathEnd);

            while (nBuildMet <= t.Length && !pathFound)
            {

                totListStart = listCityPathStart.Count();
                totListEnd = listCityPathEnd.Count();

                for (int i = counterListStart; i < totListStart && !pathFound; i++)
                {
                    c = listCityPathStart[counterListStart][1];
                    counterListStart++;

                    if (!existInHashPathsNumCityAnalyzed(c, hashPathsNumCityAnalyzed))
                    {
                        hashPathsNumCityAnalyzed.Add(c);

                        tot = getRoadsOfNumCity(c, k, t, roadsOrig, listBuild, listCrowd, listPath, listCityPathStart);

                        pathFound = verifyStartEnd(totListStart - 1, listCityPathStart, listCityPathEnd);

                        if (pathFound)
                        {
                            c = listCityPathEnd[counterListEnd][1];
                            counterListEnd++;

                            hashPathsNumCityAnalyzed.Add(c);

                            tot = getRoadsOfNumCity(c, k, t, roadsOrig, listBuild, listCrowd, listPath, listCityPathEnd);

                            pathFound = verifyEndStart(totListEnd - 1, listCityPathStart, listCityPathEnd);

                        }
                    }
                }

                nBuildMet = listBuild.Distinct().Count();

                countCycle += 1;
            }

            if (nBuildMet >= t.Length && !pathFound)
            {
                Console.WriteLine("-1");
                return;
            }


            //path found, then find better road (road wih min crowd)


            //write max Crowd



        }

        static bool existInHashPathsNumCityAnalyzed(int n, HashSet<int> hashPathsNumCityAnalyzed)
        {
            var roadsE = from elem in hashPathsNumCityAnalyzed
                         where elem == n
                         select elem;
            if (roadsE.Count() > 0) { return true; }

            return false;
        }

        static bool verifyStartEnd(int start, List<int[]> listCityPathStart, List<int[]> listCityPathEnd)
        {
            for (int i2 = start; i2 < listCityPathStart.Count(); i2++)
            {
                var roadsE = from array in listCityPathEnd
                             where (array[0] == listCityPathStart[i2][1] || array[1] == listCityPathStart[i2][1])
                             select array;
                if (roadsE.Count() > 0) { return true; }
            }

            return false;
        }

        static bool verifyEndStart(int start, List<int[]> listCityPathStart, List<int[]> listCityPathEnd)
        {
            for (int i2 = start; i2 < listCityPathEnd.Count(); i2++)
            {
                var roadsE = from array in listCityPathStart
                             where (array[0] == listCityPathEnd[i2][1] || array[1] == listCityPathEnd[i2][1])
                             select array;
                if (roadsE.Count() > 0) { return true; }
            }

            return false;
        }

        static int getRoadsOfNumCity(int c, int k, int[] t, int[][] roadsOrig, List<int> listBuild, 
                                    List<int> listCrowd, List<int[]> listPath, List<int[]> listCityPath)
        {
            int i = 0;
            int[] r;
            int s = 0;
            int e = 0;
            int u = 0;

            var roadsTmp = from array in roadsOrig
                           where (array[0] == c || array[1] == c)
                           orderby array[2] select array;
            i = 0;
            foreach (int[] road in roadsTmp)
            {
                if (road[0] == c)
                {
                    listBuild.Add(t[road[1] - 1]);
                    //e = road[1];
                }
                else
                {
                    listBuild.Add(t[road[0] - 1]);
                    //e = road[0];
                }
                listCrowd.Add(road[2]);
                //r = new int[2] { c, e };
                listCityPath.Add(road);

                i++;
            }

            return i;
        }

        static int existPath(int a, int b, List<int[]> listCityPath)
        {
            var roadsTmp = from array in listCityPath
                           where (array[0] == a && array[1] == b) || (array[0] == b && array[1] == a)
                           select array;
            return roadsTmp.Count();
        }

        static int[][] getRangePathsFromXtoY(int x, int y, int k, int[] t, int[][] roads)
        {
            int min = 0;
            int max = 0;

            if (x > y) { min = y; max = x; } else { min = x; max = y; }

            var roadsRange = from array in roads
                            where (array[0] >= min && array[1] <= max)
                                || (array[0] <= max && array[1] >= min)
                             orderby array[2]
                            select array;


            return roadsRange.ToArray();
        }

        static bool ctrlExistPath(int[][] validPaths)
        {

            return true;
        }

        /*
                        var hits = from array in roads
                                   where (array[0] == x)
                                   orderby array[2]
                                   //from str in array  
                                   //where str != x && str != y
                                   select array[0].ToString() + "," + array[1].ToString() + "," + array[2].ToString();

                        List<string> p1 = hits.ToList();
                        //p1.Sort();

                        foreach (var hit in p1)
                        {
                            Console.WriteLine(Convert.ToString(hit));
                        }

        */

    }
}
