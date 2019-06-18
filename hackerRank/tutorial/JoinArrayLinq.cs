using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class JoinArrayLinq
    {
        public void Execute()
        {

            //int n = 0;
            //int m = 0;
            //int q = 0;
            //int[] S = { };

            //string dir = @"F:\test\hr\hackerRank\hackerRank\testTravelHackerLand\";
            //var fileStream = new FileStream(dir + "input01.txt", FileMode.Open, FileAccess.Read);

            //using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            //{
            //    string line;
            //    int i = 0;
            //    int countR = 0;
            //    int countQ = 0;
            //    while ((line = streamReader.ReadLine()) != null)
            //    {
            //        if (i == 0)
            //        {
            //            S = line.Split(' ').Select(Int32.Parse).ToArray();
            //            n = S[0];
            //            m = S[1];
            //            q = S[2];
            //            t = new int[n];
            //            roads = new int[m][];
            //            queries = new int[q][];
            //        }
            //        else if (i == 1)
            //        {
            //            t = line.Split(' ').Select(Int32.Parse).ToArray();
            //        }
            //        else if (i >= 2 && i < n + 2)
            //        {
            //            roads[countR] = line.Split(' ').Select(Int32.Parse).ToArray();
            //            countR++;
            //        }
            //        else if (i >= n + 2)
            //        {
            //            queries[countQ] = line.Split(' ').Select(Int32.Parse).ToArray();
            //            countQ++;
            //        }
            //        i++;
            //    }
            //}

            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            exeJoinArrayLinq();

            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

            ////////////////////////// test with output
            bool exeTest = false;

            if (exeTest)
            {
            }
        }

        static void exeJoinArrayLinq()
        {
            var array1 = new double[][]
                        {
              new double[] {1,2,3,4},
              new double[] {5,6,7,8},
              new double[] {9,10,11,12}
                        };

            var array2 = new double[][]
                        {
              new double[] {1,2,5,6},
              new double[] {7,8,9,10},
              new double[] {9,10,11,12}
                        };

            var key = new int[] { 0, 1 };

            double?[][] res = (from a in array1
                                  from b in array2.Where(bi => key.Select(k => bi[k] == a[k])
                                                                  .Aggregate((k1, k2) => k1 && k2))
                                                  .DefaultIfEmpty()
                                  select a.Select(an => (double?)an)
                                          .Concat(b == null ?
                                                  a.Select(an => (double?)null) :
                                                  b.Select(bn => (double?)bn))
                                          .ToArray()
                                  ).Union
                                  (from b in array2
                                   from a in array1.Where(ai => key.Select(k => ai[k] == b[k])
                                                                   .Aggregate((k1, k2) => k1 && k2))
                                                   .DefaultIfEmpty()
                                   where a == null
                                   select b.Select(bn => (double?)null)
                                           .Concat(b.Select(bn => (double?)bn))
                                           .ToArray()
                                   ).ToArray();
        }
    }
}
