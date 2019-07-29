using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace hackerRank
{
    class MaximumPalindromes
    {
        private static string sG = "";
        public void Execute()
        {
            string s = "wuhmbspjnfviogqzldrcxtaeyk";

            int l = 2;
            int r = 4;
            int resExp = 3;

            bool testFile = true;

            int[][] queries = new int[][] {
                new int[] { 1, 2}
            };

            int n = 0;
            int[] S = { };
            string dir = "";

            if (testFile)
            {
                dir = @"F:\test\hr\hackerRank\hackerRank\testMaximumPalindromes\";
                var fileStream = new FileStream(dir + "input04.txt", FileMode.Open, FileAccess.Read);

                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    string line;
                    int i = 0;
                    int countQ = 0;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (i == 0)
                        {
                            s = line;
                        }
                        else if (i == 1)
                        {
                            n = int.Parse(line);
                            queries = new int[n][];
                        }
                        else if (i > 1)
                        {
                            S = line.Split(' ').Select(Int32.Parse).ToArray();
                            queries[countQ] = S;
                            countQ++;
                        }
                        i++;
                    }
                }
            }

            initialize(s);

            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            //int result = answerQuery(l, r);

            //if (resExp != result)
            //{
            //    Console.WriteLine("Errore - Expected: " + resExp + " - now: " + result);
            //}
            //else
            //{
            //    Console.WriteLine("Perfetto!!!");
            //    Console.WriteLine(result);
            //}

            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

            ////////////////////////// test with output
            bool exeTestResults = true;

            if (exeTestResults)
            {
                dir = @"F:\test\hr\hackerRank\hackerRank\testMaximumPalindromes\";
                var fileStream = new FileStream(dir + "output04.txt", FileMode.Open, FileAccess.Read);

                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    string line;
                    int i = 0;
                    int[] arrQ;
                    string res = "";

                    while ((line = streamReader.ReadLine()) != null)
                    {

                        arrQ = queries[i];
                        l = arrQ[0];
                        r = arrQ[1];

                        int result = answerQuery(l, r);

                        if (result.ToString() != line.Trim())
                        {
                            Console.WriteLine("Errore!! Caso di test n° " + (i + 1).ToString() +
                                                    " - Output: " + res.Trim() + " - Output Expected: " + line.Trim());
                            break;
                        }

                        i++;
                    }
                }
            }

        }

        public static void initialize(string s)
        {
            // This function is called once before all queries.
            sG = s;
        }

        public static int answerQuery(int l, int r)
        {
            string s = sG.Substring(l -1, r - l + 1);

            int lenArr = s.Length;
            if (lenArr == 1)
            {
                return 1;
            }
            if (lenArr == 2)
            {
                if (s[0].Equals(s[1]))
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }

            int res = s.Distinct().Count();

            if (res == s.Length)
            {
                return res;
            }

            Dictionary<char, int> t1 = (from a in s.GroupBy(x => x) select a).ToDictionary(
            p => p.Key,
            p => p.Count()
            );
            int nt1 = t1.Count();
            int c = 0;
            int sumPairs = 0;
            int sumOdd = 0;

            for (int i = 0; i < nt1; i++)
            {
                c = t1.ElementAt(i).Value;
                if (c % 2 == 0)
                {
                    if (c > 2)
                    {
                        sumPairs += (c / 2);
                    }
                    else
                    {
                        sumPairs += 1;
                    }
                }
                else
                {
                    if (c > 2)
                    {
                        sumOdd += ((c - 1) / 2);
                    }
                    else
                    {
                        sumOdd += 1;
                    }
                }
            }

            res = sumPairs * (res - 1);
            return res;
        }

        public static int answerQuery_forLMinusRGraterThree(int l, int r)
        {
            string s = sG.Substring(l - 1, r - l + 1);

            int lenArr = s.Length;
            if (lenArr == 1)
            {
                return 1;
            }
            if (lenArr == 2)
            {
                if (s[0].Equals(s[1]))
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

            int res = 0;
            Dictionary<char, int> t1 = (from a in s.GroupBy(x => x) select a).ToDictionary(
            p => p.Key,
            p => p.Count()
            );
            int lenT1 = t1.Count();

            int lenOdd = t1.Select(e => e.Value).Where(a => a % 2 != 0).Count();
            int lenPair = lenT1 - lenOdd;
            int c = 0;
            int numPairs = 0;
            int numOdd = 0;
            for (int i = 0; i < lenT1; i++)
            {
                c = t1.ElementAt(i).Value;
                if (c % 2 == 0)
                {
                    if (c > 2)
                    {
                        numPairs += (c / 2);
                    }
                    else
                    {
                        numPairs += 1;
                    }
                }
                else
                {
                    if (c > 2)
                    {
                        numOdd += (c - 1 / 2);
                    }
                    else
                    {
                        numOdd += 1;
                    }
                }
            }

            if (lenOdd == 0)
            {
                res = numPairs;
            }
            else
            {
                res = numOdd * numPairs;
            }

            return res;
        }

    }
}
