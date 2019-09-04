using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class BreadthFirstSearch
    {
        public void Execute()
        {
            int n = 5;
            int m = 5;
            int s = 5;
            int[][] edges = new int[][] {
                new int[] { 2, 2, 3 },
                new int[] { 3, 1, 4 },
                new int[] { 4, 4, 4 }
            };
            int[] resExp = { 2, 3, 1 };

            int[] result = bfs(n, m, edges, s);

            if (string.Join(" ", resExp) != string.Join(" ", result))
            {
                Console.WriteLine("Errore - Expected: " + string.Join(" ", resExp) + " - now: " + string.Join(" ", result));
            }
            else
            {
                Console.WriteLine("Perfetto!!!");
            }
        }

        static int[] bfs(int n, int m, int[][] edges, int s)
        {
            int[] res = null;
            int[] arr = new int[n + 1];
            bool[] arrView = new bool[n + 1];
            Dictionary<int, List<int>> t = new Dictionary<int, List<int>>();
            int v = 0;
            int w = 0;
            int count = 0;
            List<int> l0 = null;
            List<List<int>> l1 = null;
            int c = 0;

            var e1 = edges.OrderBy(e => e[0]).ToArray();

            for (int i = 0; i < e1.Length; i++)
            {
                arr[e1[i][0]] = 1;
                arr[e1[i][1]] = 1;

                l0 = getValueMap(t, e1[i][0]);

                if (l0 == null)
                {
                    l0 = new List<int>();
                    l0.Add(e1[i][1]);
                    t.Add(e1[i][0], l0);
                }
                else
                {
                    l0.Add(e1[i][1]);
                    t[e1[i][0]] = l0;
                }

                l0 = getValueMap(t, e1[i][1]);

                if (l0 == null)
                {
                    l0 = new List<int>();
                    l0.Add(e1[i][0]);
                    t.Add(e1[i][1], l0);
                }
                else
                {
                    l0.Add(e1[i][0]);
                    t[e1[i][1]] = l0;
                }

            }

            arrView[s] = true;
            Queue<int> q = new Queue<int>();
            q.Enqueue(s);

            while (q.Count() > 0)
            {
                v = q.Dequeue();
                if (v == n)
                {
                    break;
                }

                foreach (KeyValuePair<int, List<int>> e in t)
                {
                    l0 = e.Value.Distinct().OrderBy(x => x).ToList();
                    count = l0.Count();

                    for (int i = 0; i < count; i++)
                    {
                        w = l0[i];
                        if (!arrView[w])
                        {
                            arrView[w] = true;
                        }

                        q.Enqueue(w);
                    }

                }

                /*
                for all edges from v to w in G.adjacentEdges(v) do
                    if w is not labeled as discovered:
                        label w as discovered
                        w.parent = v
                        Q.enqueue(w)                  
                */
            }

            return res;
        }

        static List<int> getValueMap(Dictionary<int, List<int>> t, int e)
        {
            List<int> v = null;
            t.TryGetValue(e, out v);
            return v;
        }

    }
}
