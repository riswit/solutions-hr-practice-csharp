using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class DynamicArray
    {
        public void Execute()
        {
            int n = 0;
            List<List<int>> queries = new List<List<int>> { };
            int[] resExp = { 467, 1 };

            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            int[] result = dynamicArray(n, queries).ToArray();

            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

            if (string.Join(" ", resExp) != string.Join(" ", result))
            {
                Console.WriteLine("Errore - Expected: " + string.Join(" ", resExp) + " - now: " + string.Join(" ", result));
            }
            else
            {
                Console.WriteLine("Perfetto!!!");
                Console.WriteLine(string.Join(" ", result));
            }
        }

        static List<int> dynamicArray(int n, List<List<int>> queries)
        {
            List<List<int>> seqList = new List<List<int>>();
            for (int i = 0; i < n; i++)
            {
                seqList.Add(new List<int>());
            }

            int lastAnswer = 0;
            List<int> res = new List<int>();
            int ind = 0;
            int k = 0;
            int x = 0;
            int y = 0;

            for (int i = 0; i < queries.Count; i++)
            {
                k = queries[i][0];
                x = queries[i][1];
                y = queries[i][2];

                ind = (x ^ lastAnswer) % n;
                List<int> seq = seqList[ind];

                if (k == 1)
                {
                    seq.Add(y);
                }
                else if (k == 2) 
                {
                    lastAnswer = seq[(y % seq.Count)];
                    res.Add(lastAnswer);
                }
            }

            return res;
        }
    }
}
