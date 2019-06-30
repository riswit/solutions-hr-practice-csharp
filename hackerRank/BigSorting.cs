using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace hackerRank
{
    class BigSorting
    {
        public void Execute()
        {
            //string[] unsorted = { "6", "131415926535897932384626433832795", "41415926535897932384626433832795", "31415926535897932384626433832795", "3", "10", "3", "5" };
            //string[] resExp = { "3", "3", "5", "6", "10", "31415926535897932384626433832795", "41415926535897932384626433832795", "131415926535897932384626433832795" };

            string[] unsorted = { "131415926535897932384626433832795", "41415926535897932384626433832795", "31415926535897932384626433832795" };
            string[] resExp = { "3", "3", "5", "6", "10", "31415926535897932384626433832795", "41415926535897932384626433832795", "131415926535897932384626433832795" };

            bool testFile = true;
            int[] S = { };
            string dir = "";
            int n = 0;
            List<string> listElem = new List<string>();

            if (testFile)
            {
                dir = @"F:\test\hr\hackerRank\hackerRank\testBigSorting\";
                var fileStream = new FileStream(dir + "input02.txt", FileMode.Open, FileAccess.Read);

                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    string line;
                    int i = 0;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (i == 0)
                        {
                            n = int.Parse(line);
                        }
                        else if (i >= 1)
                        {
                            listElem.Add(line);
                        }
                        i++;
                    }
                }

                unsorted = listElem.ToArray();
            }

            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            string[] result = bigSorting(unsorted);

            watch.Stop();

            ////////////////////////// test with output
            bool exeTestResults = true;

            if (exeTestResults && testFile)
            {
                listElem = new List<string>();

                dir = @"F:\test\hr\hackerRank\hackerRank\testBigSorting\";
                var fileStream = new FileStream(dir + "output02.txt", FileMode.Open, FileAccess.Read);

                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    string line;
                    int i = 0;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        listElem.Add(line);

                        i++;
                    }
                }

                resExp = listElem.ToArray();
            }

            if (string.Join(" ", resExp) != string.Join(" ", result))
            {
                Console.WriteLine("Errore - Expected: " + string.Join(" ", resExp) + " - now: " + string.Join(" ", result));
            }
            else
            {
                Console.WriteLine("Perfetto!!!");
                Console.WriteLine(string.Join(" ", result));
                Console.WriteLine("Perfetto!!!");
            }

            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
        }

        static string[] bigSorting(string[] unsorted)
        {
            int lenMax = unsorted.Select(e => e.Length).Max();

            string[] res = new string[0];

            long[] arrSmall = unsorted.Where(e => e.Length <= 18).Select(a => long.Parse(a)).ToArray();
            string[] arrBig = unsorted.Where(e => e.Length > 18).ToArray();

            string[] arrSmallStr = (from a in arrSmall orderby a select a.ToString()).ToArray();

            res = res.Concat(arrSmallStr).ToArray();

            if (arrBig.Length == 1)
            {
                res = res.Concat(arrBig).ToArray();
            }
            else if (arrBig.Length > 1)
            {
                arrBig = (from a in arrBig orderby a select a).ToArray();

                IGrouping<int, string>[] t = (from a in arrBig.GroupBy(x => x.Length) orderby a.Key select a).ToArray();

                res = res.Concat(t.SelectMany(p => p).ToArray()).ToArray();
            }

            return res;
        }

    }
}
