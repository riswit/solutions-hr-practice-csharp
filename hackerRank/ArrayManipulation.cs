using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class ArrayManipulation
    {
        public void Execute()
        {
            //int n = 5;
            //int[][] queries = new int[][] {
            //    new int[] { 1, 2, 100 },
            //    new int[] { 2, 5, 100 },
            //    new int[] { 3, 4, 100 }
            //};
            //long resExp = 200;

            //int n = 10;
            //int[][] queries = new int[][] {
            //    new int[] { 1, 5, 3 },
            //    new int[] { 4, 8, 7 },
            //    new int[] { 6, 9, 1 }
            //};
            //long resExp = 10;

            //int n = 10;
            //int[][] queries = new int[][] {
            //    new int[] { 2, 6, 8 },
            //    new int[] { 3, 5, 7 },
            //    new int[] { 1, 8, 1 },
            //    new int[] { 5, 9, 15 }
            //};
            //long resExp = 31;

            //int n = 4;
            //int[][] queries = new int[][] {
            //    new int[] { 2, 3, 603 },
            //    new int[] { 1, 1, 286 },
            //    new int[] { 4, 4, 882 }
            //};
            //long resExp = 882;

            int[][] queries = new int[][] {
                new int[] { 0, 0}
            };

            long resExp = 2497169732;

            bool testFile = true;
            int n = 0;
            int[] S = { };
            string dir = "";
            if (testFile)
            {
                dir = @"F:\test\hr\hackerRank\hackerRank\testArrayManipulation\";
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
                            S = line.Split(' ').Select(Int32.Parse).ToArray();
                            n = S[0];
                            queries = new int[S[1]][];
                        }
                        else if (i > 0)
                        {
                            S = line.Split(' ').Select(Int32.Parse).ToArray();
                            queries[countQ] = S;
                            countQ++;
                        }
                        i++;
                    }
                }
            }

            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            long result = arrayManipulation(n, queries);

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

        static long arrayManipulation(int n, int[][] queries)
        {
            long[] tl = new long[n + 1];
            int[] o = new int[n + 1];
            List<int> tl1 = new List<int>();
            List<List<int>> tl0 = new List<List<int>>();
            Dictionary<int, List<List<int>>> dict = new Dictionary<int, List<List<int>>>();
            int nDict = 0;

            for (int i = 0; i < queries.Length; i++)
            {
                tl[queries[i][0]] += queries[i][2];
                if (tl[queries[i][0]] != tl[queries[i][1]])
                {
                    tl[queries[i][1]] += queries[i][2];
                }
                if (queries[i][1] - queries[i][0] - 1 > 0)
                {
                    tl0 = new List<List<int>>();
                    tl1 = new List<int>();

                    tl1.Add(i);
                    tl1.Add(queries[i][1] - queries[i][0] - 1);
                    tl1.Add(queries[i][2]);

                    dict.TryGetValue(queries[i][0], out tl0);

                    if (tl0 == null)
                    {
                        tl0 = new List<List<int>>();
                        tl0.Add(tl1);
                        dict.Add(queries[i][0], tl0);
                        nDict += 1;
                    }
                    else
                    {
                        tl0.Add(tl1);
                        dict[queries[i][0]] = tl0;
                    }
                }
            }
            long maxValue = tl.Max();

            foreach (KeyValuePair<int, List<List<int>>> e in dict)
            {
                for (int j = 0; j < e.Value.Count; j++)
                {
                    for (long y = e.Key + 1; y <= e.Key + e.Value[j][1]; y++)
                    {
                        tl[y] += e.Value[j][2];

                        if (tl[y] > maxValue)
                        {
                            maxValue = tl[y];
                        }
                    }
                }
            }

            return maxValue;
        }

    }
}
