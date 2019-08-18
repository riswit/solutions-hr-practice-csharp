using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class CutTree
    {
        public void Execute()
        {
            List<int> data = new List<int>();
            data.Add(100);
            data.Add(200);
            data.Add(100);
            data.Add(500);
            data.Add(100);
            data.Add(600);

            List<List<int>> edges = new List<List<int>>();
            List<int> edge = new List<int>();
            edge.Add(1);
            edge.Add(2);
            edges.Add(edge);

            edge = new List<int>();
            edge.Add(2);
            edge.Add(3);
            edges.Add(edge);

            edge = new List<int>();
            edge.Add(2);
            edge.Add(5);
            edges.Add(edge);

            edge = new List<int>();
            edge.Add(5);
            edge.Add(6);
            edges.Add(edge);

            edge = new List<int>();
            edge.Add(4);
            edge.Add(5);
            edges.Add(edge);

            int resExp = 400;

            int result = cutTheTree(data, edges);

            if (resExp != result)
            {
                Console.WriteLine("Errore - Expected: " + resExp + " - now: " + result);
            }
            else
            {
                Console.WriteLine(result);
                Console.WriteLine("Perfetto!!!");
            }
        }

        public static int[] dataC;

        public static List<List<int>> tree;
        public static bool[] viewed;
        public static int total;
        public static int min;
        public static int n;

        public static int cutTheTree(List<int> data, List<List<int>> edges)
        {
            int a = 0;
            int b = 0;
            n = data.Count();
            min = 1000000000;

            viewed = new bool[n + 1];
            tree = new List<List<int>>();
            tree.Add(new List<int>());

            for (int i = 0; i < n; i++)
            {
                total += data[i];
                tree.Add(new List<int>());
            }
            for (int i = 0; i < edges.Count(); i++)
            {
                a = edges[i][0];
                b = edges[i][1];

                tree[a].Add(b);
                tree[b].Add(a);
            }

            findSumList2(data, 1);

            return min;
        }

        static int findSumList2(List<int> data, int u)
        {
            int below = data[u - 1];
            viewed[u] = true;

            for (int i = 0; i < tree[u].Count(); i++)
            {
                if (!viewed[tree[u][i]])
                {
                    below += findSumList2(data, tree[u][i]);
                }
            }
            if (Math.Abs(total - (2 * below)) < min)
            {
                min = Math.Abs(total - (2 * below));
            }

            return below;
        }

        public static int cutTheTree_SLOW(List<int> data, List<List<int>> edges)
        {
            int min = 0;
            int res = 0;
            List<List<int>> wEdges;
            dataC = new int[data.Count()];

            for (int i = 0; i < data.Count(); i++)
            {
                total += data[i];
            }

            int c = 0;

            for (int i = 0; i < edges.Count(); i++)
            {
                data.CopyTo(dataC);

                var r = edges.Where((e, ind) => ind != i);
                wEdges = r.ToList();

                int a = edges[i][0];
                int b = edges[i][1];

                res = dataC[a - 1];
                dataC[a - 1] = 0;
                int s1 = findSumList(ref res, wEdges, dataC, a, b);

                //res = dataC[b - 1];
                //dataC[b - 1] = 0;
                //int s2 = findSumList(ref res, wEdges, dataC, b, a);
                int s2 = total - s1;

                c = Math.Abs(s1 - s2);

                if ((min == 0 && c > 0) || c < min)
                {
                    min = c;
                }
            }

            return min;
        }

        static int findSumList(ref int res, List<List<int>> edges, int[] data, int f, int ex)
        {
            int dest = 0;
            int destEx = 0;

            for (int i = 0; i < edges.Count(); i++)
            {
                int a1 = edges[i][0];
                int b1 = edges[i][1];

                if ((a1 == f || b1 == f) && ex != a1 && ex != b1)
                {
                    if (a1 == f)
                    {
                        dest = b1;
                        destEx = a1;
                    }
                    else
                    {
                        dest = a1;
                        destEx = b1;
                    }

                    if (data[dest - 1] != 0)
                    {
                        res += data[dest - 1];
                        data[dest - 1] = 0;
                    }
                    findSumList(ref res, edges, data, dest, destEx);
                }
            }

            return res;
        }

        //public static int cutTheTree(List<int> data, List<List<int>> edges)
        //{
        //    int min = 0;
        //    int res = 0;
        //    List<List<int>> wEdges;
        //    dataC = new int[data.Count()];

        //    int c = 0;

        //    for (int i = 0; i < edges.Count(); i++)
        //    {
        //        data.CopyTo(dataC);

        //        var r = edges.Where((e, ind) => ind != i);
        //        wEdges = r.ToList();

        //        int a = edges[i][0];
        //        int b = edges[i][1];

        //        res = dataC[a - 1];
        //        dataC[a - 1] = 0;
        //        int s1 = findSumList(i, 0, ref res, wEdges, dataC, a, b);

        //        res = dataC[b - 1];
        //        dataC[b - 1] = 0;
        //        int s2 = findSumList(i, 0, ref res, wEdges, dataC, b, a);

        //        c = Math.Abs(s1 - s2);

        //        if ((min == 0 && c > 0) || c < min)
        //        {
        //            min = c;
        //        }
        //    }

        //    return min;
        //}

        //static int findSumList(int ind, int col, ref int res, List<List<int>> edges, int[] data, int f, int ex)
        //{
        //    if (edges[ind][col] == 0)
        //    {
        //        return res;
        //    }

        //    int dest = 0;
        //    int destEx = 0;
        //    int colDest = 0;

        //    for (int i = 0; i < edges.Count(); i++)
        //    {
        //        int a1 = edges[i][0];
        //        int b1 = edges[i][1];

        //        if ((a1 == f || b1 == f) && ex != a1 && ex != b1)
        //        {
        //            if (a1 == f)
        //            {
        //                dest = b1;
        //                destEx = a1;
        //                colDest = 0;
        //            }
        //            else
        //            {
        //                dest = a1;
        //                destEx = b1;
        //                colDest = 1;
        //            }

        //            edges[i][colDest] = 0;

        //            if (data[dest - 1] != 0)
        //            {
        //                res += data[dest - 1];
        //                data[dest - 1] = 0;
        //            }

        //            findSumList(i, colDest, ref res, edges, data, dest, destEx);

        //        }
        //    }

        //    return res;
        //}

    }
}
