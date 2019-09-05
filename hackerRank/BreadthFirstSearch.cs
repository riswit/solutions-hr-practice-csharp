using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class BreadthFirstSearch
    {
        public void Execute()
        {
            int totQ = 0;
            int n = 4;
            int m = 2;
            int s = 1;
            int[][] edges = new int[][] {
                new int[] { 1, 2 },
                new int[] { 1, 3 }
            };
            //int[] resExp = { 6, 6, -1 };
            int[] resExp = { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };

            bool testFile = true;
            int[] S = { };
            string dir = "";
            int numTest = 5;
            int t = 1;

            if (testFile)
            {
                dir = @"F:\test\hr\hackerRank\hackerRank\testBreadthFirstSearch\";
                var fileStream = new FileStream(dir + "input05.txt", FileMode.Open, FileAccess.Read);

                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    string line;
                    int i = 0;
                    int countQ = 0;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (i == 0)
                        {
                            totQ = int.Parse(line);
                        }
                        else if (i == 1)
                        {
                            S = line.Split(' ').Select(Int32.Parse).ToArray();
                            edges = new int[S[1]][];
                            n = S[0];
                            m = S[1];
                        }
                        else if (i > 1)
                        {
                            S = line.Split(' ').Select(Int32.Parse).ToArray();
                            if (S.Length == 2)
                            {
                                edges[countQ] = S;
                                countQ++;
                            }
                            else
                            {
                                s = int.Parse(line);
                                i = 0;
                                countQ = 0;
                                if (t == numTest)
                                {
                                    break;
                                }
                                t += 1;
                            }
                        }
                        i++;
                    }

                }
            }

            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            int[] result = bfs(n, m, edges, s);

            watch.Stop();

            if (string.Join(" ", resExp) != string.Join(" ", result))
            {
                Console.WriteLine("Errore - Expected: " + string.Join(" ", resExp) + " - now: " + string.Join(" ", result));
            }
            else
            {
                Console.WriteLine("Expected: " + string.Join(" ", resExp));
                Console.WriteLine("Perfetto!!!");
            }
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
        }

        static int[] bfs(int n, int m, int[][] edges, int s)
        {
            List<int> res = new List<int>();
            int[] arr2 = new int[n + 1];
            bool[] arrView = new bool[n + 1];
            for (int i = 1; i <= n; i++)
            {
                arr2[i] = -1;
            }

            Dictionary<int, List<int>> t = new Dictionary<int, List<int>>();
            int v = 0;
            int w = 0;
            int count = 0;
            List<int> l0 = null;
            int a = 0;
            int b = 0;

            //var e1 = edges.OrderBy(e => e[0]).ToArray();
            bool existS = false;
            int numT = 0;

            for (int i = 0; i < edges.Length; i++)
            {
                a = edges[i][0];
                b = edges[i][1];
                if (a == s || b == s) { existS = true; }
                l0 = getValueMap(t, a);

                if (l0 == null)
                {
                    l0 = new List<int>();
                    l0.Add(b);
                    t.Add(a, l0);
                    numT += 1;
                }
                else
                {
                    l0.Add(b);
                    //l0 = l0.Distinct().ToList();
                    t[a] = l0;
                }

                l0 = getValueMap(t, b);

                if (l0 == null)
                {
                    l0 = new List<int>();
                    l0.Add(a);
                    t.Add(b, l0);
                    numT += 1;
                }
                else
                {
                    l0.Add(a);
                    //l0 = l0.Distinct().ToList();
                    t[b] = l0;
                }

            }

            for (int i = 0; i < numT; i++)
            {
                List<int> row = t.ElementAt(i).Value.Distinct().OrderBy(x => x).ToList();
                t[t.ElementAt(i).Key] = row;
            }

            if (existS)
            {
                arrView[s] = true;
                Queue<int> q = new Queue<int>();
                q.Enqueue(s);
                arr2[s] = 0;

                while (q.Count() > 0)
                {
                    v = q.Dequeue();
                    if (v == n)
                    {
                        break;
                    }
                    l0 = t[v]; //.OrderBy(x => x).ToList();
                    count = l0.Count();

                    for (int i = 0; i < count; i++)
                    {
                        w = l0[i];
                        if (!arrView[w] && arr2[w] == -1)
                        {
                            arr2[w] = arr2[v] + 1;
                            arrView[w] = true;
                            q.Enqueue(w);
                        }

                    }
                }
            }

            bool allN = true;

            for (int i = 1; i < arr2.Length; i++)
            {
                if (arr2[i] == -1)
                {
                    if (!(i == arr2.Length - 1 && allN))
                    {
                        res.Add(arr2[i]);
                    }
                }
                else if (arr2[i] != 0)
                {
                    allN = false;
                    res.Add(arr2[i] * 6);
                }
            }

            return res.ToArray();
        }

        static List<int> getValueMap(Dictionary<int, List<int>> t, int e)
        {
            List<int> v = null;
            t.TryGetValue(e, out v);
            return v;
        }

    }
}
