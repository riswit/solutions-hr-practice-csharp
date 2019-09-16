using System;
using System.Collections.Generic;
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
            int n = 0;
            List<List<int>> queries = new List<List<int>>
                                {   new List<int>(){1, 5},
                                    new List<int>(){1, 6},
                                    new List<int>(){3, 2},
                                    new List<int>(){1, 10},
                                    new List<int>(){1, 10},
                                    new List<int>(){1, 6},
                                    new List<int>(){2, 5},
                                    new List<int>(){3, 2}
                                };
            int[] resExp = { 0, 1 };

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
        }

        static List<int> freqQuery(List<List<int>> queries)
        {
            List<int> res = new List<int>();
            long[] arr = new long[queries.Max(x => x[1]) + 1];
            long[] co = new long[100000000]; 
            int lenQ = queries.Count();

            for (int i = 0; i < lenQ; i++)
            {
                if (queries[i][0] == 1)
                {
                    co[arr[queries[i][0]]] = 0;
                    arr[queries[i][0]] += 1;
                    co[arr[queries[i][0]]] = 1;
                }
                else if (queries[i][0] == 2)
                {
                    arr[queries[i][0]] -= 1;
                }
                else if (queries[i][0] == 3)
                {

                }
            }

            return res;
        }
    }
}
