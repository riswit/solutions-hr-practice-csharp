using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    //https://www.hackerrank.com/challenges/frequency-queries/problem
    class FrequencyQueries
    {
        public void Execute()
        {
            //int n = 0;
            //List<List<int>> queries = new List<List<int>>
            //                    {   new List<int>(){1, 5},
            //                        new List<int>(){1, 6},
            //                        new List<int>(){3, 2},
            //                        new List<int>(){1, 10},
            //                        new List<int>(){1, 10},
            //                        new List<int>(){1, 6},
            //                        new List<int>(){2, 5},
            //                        new List<int>(){3, 2}
            //                    };
            //int[] resExp = { 0, 1 };

            int n = 20;
            List<List<int>> queries = new List<List<int>>
                                {   new List<int>(){1, 3},
                                    new List<int>(){1, 38},
                                    new List<int>(){2, 1},
                                    new List<int>(){1, 16},
                                    new List<int>(){2, 1},
                                    new List<int>(){2, 2},
                                    new List<int>(){1, 64},
                                    new List<int>(){1, 84},
                                    new List<int>(){3, 1},
                                    new List<int>(){1, 100},
                                    new List<int>(){1, 10},
                                    new List<int>(){2, 2},
                                    new List<int>(){2, 1},
                                    new List<int>(){1, 67},
                                    new List<int>(){2, 2},
                                    new List<int>(){3, 1},
                                    new List<int>(){1, 99},
                                    new List<int>(){1, 32},
                                    new List<int>(){1, 58},
                                    new List<int>(){3, 2}

            };
            int[] resExp = { 1, 1, 0 };

            bool testFile = true;
            int totQ = 0;
            int[] S = { };
            string dir = "";
            int numTest = 1;
            int t = 1;

            if (testFile)
            {
                dir = @"F:\test\hr\hackerRank\hackerRank\testFrequencyQueries\";
                var fileStream = new FileStream(dir + "input10.txt", FileMode.Open, FileAccess.Read);

                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    string line;
                    int i = 0;
                    int countQ = 0;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (i == 0)
                        {
                            n = int.Parse(line);
                            queries = new List<List<int>>();
                        }
                        else if (i > 0)
                        {
                            S = line.Split(' ').Select(Int32.Parse).ToArray();
                            List<int> query = new List<int>();
                            query.Add(S[0]);
                            query.Add(S[1]);
                            queries.Add(query);
                            countQ++;
                        }
                        i++;
                    }

                }
            }

            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            int[] result = freqQuery(queries).ToArray();

            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

            if (string.Join(" ", resExp) != string.Join(" ", result))
            {
                Console.WriteLine("Errore - Expected: " + string.Join(" ", resExp) + " - now: " + string.Join(" ", result));
            }
            else
            {
                Console.WriteLine(string.Join(" ", result));
                Console.WriteLine("Perfetto!!!");
            }
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
        }

        static List<int> freqQuery(List<List<int>> queries)
        {
            List<int> res = new List<int>();
            int max = queries.Max(x => x[1]);
            Dictionary<long, int?> arr = new Dictionary<long, int?>();
            int c = 0;
            bool c1 = false;
            int lenQ = queries.Count();
            long[] co = new long[lenQ + 1];

            for (int i = 0; i < lenQ; i++)
            {
                c = queries[i][1];

                if (queries[i][0] == 1)
                {
                    c1 = getValueMap(arr, c);
                    if (!c1) { arr.Add(c, 0); }

                    if (co[arr[queries[i][1]].Value] > 0)
                    {
                        co[arr[queries[i][1]].Value] -= 1;
                    }
                    arr[queries[i][1]] += 1;

                    co[arr[queries[i][1]].Value] += 1;
                }
                else if (queries[i][0] == 2)
                {
                    c1 = getValueMap(arr, c);
                    if (c1)
                    {
                        if (arr[queries[i][1]].Value > 0)
                        {
                            if (co[arr[queries[i][1]].Value] > 0)
                            {
                                co[arr[queries[i][1]].Value] -= 1;
                            }
                            arr[queries[i][1]] -= 1;
                            co[arr[queries[i][1]].Value] += 1;
                        }
                    }
                }
                else if (queries[i][0] == 3)
                {
                    if (queries[i][1] > lenQ)
                    {
                        res.Add(0);
                    }
                    else
                    {
                        if (co[queries[i][1]] > 0)
                        {
                            res.Add(1);
                        }
                        else
                        {
                            res.Add(0);
                        }
                    }
                }
            }

            return res;
        }

        static bool getValueMap(Dictionary<long, int?> t, long e)
        {
            int? v = null;
            t.TryGetValue(e, out v);

            if (v == null) { return false; }

            return true;
        }

        static List<int> freqQuery_13Points(List<List<int>> queries)
        {
            List<int> res = new List<int>();
            int max = queries.Max(x => x[1]);
            long[] arr = new long[max + 1];
            int lenQ = queries.Count();
            long[] co = new long[lenQ + 1];

            for (int i = 0; i < lenQ; i++)
            {
                if (queries[i][0] == 1)
                {
                    if (arr[queries[i][1]] > 0)
                    {
                        co[arr[queries[i][1]]] -= 1;
                    }
                    arr[queries[i][1]] += 1;
                    co[arr[queries[i][1]]] += 1;
                }
                else if (queries[i][0] == 2)
                {
                    if (arr[queries[i][1]] > 0)
                    {
                        arr[queries[i][1]] -= 1;
                    }
                    if (co[arr[queries[i][1]]] > 0)
                    {
                        co[arr[queries[i][1]]] -= 1;
                    }
                }
                else if (queries[i][0] == 3)
                {
                    if (co[queries[i][1]] > 0)
                    {
                        res.Add(1);
                    }
                    else
                    {
                        res.Add(0);
                    }
                }
            }

            return res;
        }


    }
}
