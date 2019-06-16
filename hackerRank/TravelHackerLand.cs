using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            travel(t, roads, queries);
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

        static void printAnswerOfQuery(int x, int y, int k, int[] t, int[][] roads, int q, int[][] queries)
        {
            //List<int> crowds;
            //int pos = 0;
            //List<int> numKMet = new List<int>();
            //int[][] tmp;
            //int countRoadsFromX = 0;
            //int countRoadsToX = 0;

            //crowds = new List<int>();
            List<int> listBuild = new List<int>();
            List<int> listCrowd = new List<int>();
            int maxCrowd = 0;
            bool finish = false;
            int min = 0;
            int max = 0;
            List<int> numKMet = new List<int>();
            int[][] tmp;
            int totBuildMet = 0;
            if (x > y) { min = y; max = x; } else { min = x; max = y; }
            int start = min;
            int end = max;
            int[] city;

            var roadsDest = from array in roads
                            where (array[1] == end && array[0] < end - 1 )
                            orderby array[2]
                            select array;

            var roadsPath = from array in roads
                            where (array[0] >= start && array[0] <= end)
                                && (array[1] >= start && array[1] <= end)
                                && (array[1] < array[array[1]])
                            orderby array[2]
                            select array;

            //listPath = roadsPath.ToList();
            foreach (int[] road in roadsPath)
            {
                //city = new int[2] { t[road[1] - 1], road[0]};
                listBuild.Add(t[road[1] - 1]);
                listCrowd.Add(road[2]);

            }

            listBuild.Distinct();
            maxCrowd = listCrowd.Max();


        }

        //static int[][] getExistPaths(int x, int y, int k, int[] t, int[][] roads)
        //{

        //    //while (!finish)
        //    //{

        //    //}

        //    return listPath.ToArray();
        //}

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
