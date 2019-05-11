using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace hackerRank
{
    class NonDivisibleSubset
    {
        public void Execute()
        {
            //int k = 7;
            //int[] S = { 278, 576, 496, 727, 727, 410, 124, 338, 149, 209, 702, 282, 718, 771, 575, 436 };
            //int resExp = 11;

            //int k = 3;
            //int[] S = { 1, 7, 2, 4 };
            //int resExp = 3;

            //int k = 5;
            //int[] S = { 770528134, 663501748, 384261537, 800309024, 103668401, 538539662, 385488901, 101262949, 557792122, 46058493 };
            //int resExp = 6;

            int k = 100;
            int[] S = { };
            int resExp = 49747;

            string dir = @"F:\test\hr\hackerRank\hackerRank\testNonDivisibleSubset\";
            var fileStream = new FileStream(dir + "input09.txt", FileMode.Open, FileAccess.Read);

            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                int i = 0;
                while ((line = streamReader.ReadLine()) != null)
                {
                    switch (i)
                    {
                        case 0:
                            k = int.Parse(line);
                            break;
                        case 1:
                            S = line.Split(' ').Select(Int32.Parse).ToArray();
                            break;
                    }
                    i++;
                }
            }

            int result = nonDivisibleSubset(k, S);
            //int result = nonDivisibleSubset_Slow(k, S);

            if (resExp != result)
            {
                Console.WriteLine("Errore - Expected: " + resExp + " - now: " + result);
            }
            else
            {
                Console.WriteLine("Perfetto!!!");
            }

            Console.WriteLine(result);
        }

        static int nonDivisibleSubset_1(int k, int[] S)
        {
            int numMaxArray = 0;
            List<int> list = new List<int>();
            List<int> list2 = new List<int>();
            bool isDiv = false;
            int countArray = 0;
            int[] S1 = S.Distinct().ToArray();
            IEnumerable<int> S2;
            IEnumerable<int> S3;
            int i = 0;
            int j = 0;
            int c = (S1.Length / 2) + 1;

            for (i = 0; i < c; i++)
            {
                //list = new List<int>();
                //list.Add(S1[i]);
                S2 = S1.Where((number, index) => index > c && (S1[i] + number) % k != 0 && i != index).Distinct();

                /*
                for (j = 0; j < S1.Length; j++)
                {
                    if ((S1[i] + S1[j]) % k != 0 && i != j)
                    {
                        if (!list.Contains(S1[j]))
                        {
                            isDiv = false;
                            for (int jj = 0; jj < list.Count; jj++)
                            {
                                if ((S1[j] + list[jj]) % k == 0)
                                {
                                    isDiv = true;
                                    break;
                                }
                            }
                            if (!isDiv)
                            {
                                list.Add(S1[j]);
                            }
                        }
                    }
                }
                */

                if (countArray > numMaxArray)
                {
                    numMaxArray = countArray;
                }
            }

            return numMaxArray;
        }

        static bool isEven(int i)
        {
            return (i % 2 == 0);
        }

        static int nonDivisibleSubset(int k, int[] S)
        {
            if (S.Length <= 1000)
            {
                return nonDivisibleSubset_Slow(k, S);
            }

            return nonDivisibleSubset_Math(k, S);
        }

        static int nonDivisibleSubset_Math(int k, int[] S)
        {
            int[] remainders = new int[k];
            int count = 0;

            for (int i = 0; i < S.Length; i++)
            {
                remainders[S[i] % k]++;
            }

            for (int j = 1; j <= (k / 2); j++)
            {
                if (j == k - j)
                {
                    count++;
                    continue;
                }

                count += Math.Max(remainders[j], remainders[k - j]);
            }

            if (remainders[0] > 0)
            {
                count++;
            }

            return count;
        }

        static int nonDivisibleSubset_Slow(int k, int[] S)
        {
            int numMaxArray = 0;
            List<int> list = new List<int>();
            List<int> list2 = new List<int>();
            bool isDiv = false;

            int[] S1 = S.Distinct().ToArray();

            int i = 0;
            int j = 0;

            for (i = 0; i < (int)(S1.Length / 2) + 1; i++)
            {
                list = new List<int>();
                list.Add(S1[i]);

                for (j = 0; j < S1.Length; j++)
                {
                    if ((S1[i] + S1[j]) % k != 0 && i != j)
                    {
                        if (!list.Contains(S1[j]))
                        {
                            isDiv = false;
                            for (int jj = 0; jj < list.Count; jj++)
                            {
                                if ((S1[j] + list[jj]) % k == 0)
                                {
                                    isDiv = true;
                                    break;
                                }
                            }
                            if (!isDiv)
                            {
                                list.Add(S1[j]);
                            }
                        }
                    }
                }

                if (list.Count > numMaxArray)
                {
                    numMaxArray = list.Count;
                }
            }

            return numMaxArray;
        }

        //IEnumerable<int> list1 = S.Where((number, index) => number % k != 0);

    }
}
