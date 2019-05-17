using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace hackerRank
{
    class ACMICPCTeam
    {
        public void Execute()
        {
            //string[] topic = { "10101", "11100", "11010", "00101" };
            //int[] resExp = { 5, 2 };

            //string[] topic = { "11101", "10101", "11001", "10111", "10000", "01110" };
            //int[] resExp = { 5, 6 };

            //string[] topic = { "1001101111101011011100101100100110111011111011000100111100111110111101011011011100111001100011111010",
            //                   "1111010101101010011101101101011101111111111011110010001001100111000111011111101110010111110111110010",
            //                    "0011111011111010111101111110101101111001111111100011111101101100100011010011111011111110110011111000",
            //                    "0011111001001100111111011110011110100111111100010100111111101011111010101111111011111010111001111111" };
            //int[] resExp = { 5, 2 };

            string[] topic = { };
            int[] resExp = { 467, 1 };
            List<string> listInput = new List<string>();

            string dir = @"F:\test\hr\hackerRank\hackerRank\testACMICPCTeam\";
            var fileStream = new FileStream(dir + "input03.txt", FileMode.Open, FileAccess.Read);

            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                int i = 0;
                while ((line = streamReader.ReadLine()) != null)
                {
                    switch (i)
                    {
                        case 0:
                            break;
                        default:
                            listInput.Add(line);
                            break;
                    }
                    i++;
                }
            }

            topic = new string[listInput.Count()];
            topic = listInput.ToArray();

            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            int[] result = acmTeam(topic);

            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

            if (string.Join(" ", resExp) != string.Join(" ", result))
            {
                Console.WriteLine("Errore - Expected: " + string.Join(" ", resExp) + " - now: " + string.Join(" ", result));
            }
            else
            {
                Console.WriteLine("Perfetto!!!");
            }

            Console.WriteLine(string.Join(" ", result));
        }

        static int[] acmTeam(string[] topic)
        {
            int[] res = { 0, 0 };
            int numMaxTopic = 0;
            int p1 = 0;
            int p2 = 0;

            List<int> listMaxTopic = new List<int>();
            int sumTopic = 0;

            for (p1 = 0; p1 < topic.Length - 1; p1++)
            {
                for (p2 = p1 + 1; p2 < topic.Length; p2++)
                {
                    char[] x = new char[topic[p1].Length];
                    char[] y = new char[topic[p2].Length];
                    x = string.Concat(topic[p1]).ToCharArray();
                    y = string.Concat(topic[p2]).ToCharArray();

                    sumTopic = 0;
                    for (int i = 0; i < topic[p1].Length; i++)
                    {
                        if (x[i] == '1' || y[i] == '1')
                        {
                            sumTopic++;
                        }
                    }

                    if (sumTopic > numMaxTopic)
                    {
                        numMaxTopic = sumTopic;
                    }

                    listMaxTopic.Add(sumTopic);

                }
            }

            IEnumerable<int> numMaxTeam = listMaxTopic.Where((item, index) => item == numMaxTopic);

            res[0] = numMaxTopic;
            res[1] = numMaxTeam.Count();
            return res;
        }

        static int[] acmTeam3(string[] topic)
        {
            int[] res = { 0, 0 };
            int numMaxTopic = 0;
            int p1 = 0;
            int p2 = 0;
            int maxDigit = 18;

            List<int> listMaxTopic = new List<int>();
            StringBuilder sb1 = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();
            int lTopic = 0;
            BitArray ba1;
            BitArray ba2;
            BitArray ba3;
            bool[] arr;
            int sumTopic = 0;

            for (p1 = 0; p1 < topic.Length - 1; p1++)
            {
                for (p2 = p1 + 1; p2 < topic.Length; p2++)
                {
                    //lTopic = topic[p1].Length;
                    //if (lTopic > maxDigit)
                    //{
                    //    lTopic = maxDigit;
                    //}

                    //var watch1 = new System.Diagnostics.Stopwatch();
                    //watch1.Start();

                    char[] x = new char[topic[p1].Length];
                    char[] y = new char[topic[p2].Length];
                    x = string.Concat(topic[p1]).ToCharArray();
                    y = string.Concat(topic[p2]).ToCharArray();

                    //sb1 = new StringBuilder();
                    sumTopic = 0;
                    for (int i = 0; i < topic.Length; i++)
                    {
                        //sb1.Append(x[i] == '1' || y[i] == '1' ? '1' : '0');
                        if (x[i] == '1' || y[i] == '1')
                        {
                            sumTopic++;
                        }

                    }

                    //ba1 = new BitArray(topic[p1].Select(c => c == '1').ToArray());
                    //ba2 = new BitArray(topic[p2].Select(c => c == '1').ToArray());
                    //ba3 = ba1.Or(ba2);
                    //arr = new bool[topic[p1].Length]; 
                    //ba3.CopyTo(arr, 0);
                    //arr = arr.Where(x => x == true).ToArray();

                    //string.Concat(topic[p2]).ToCharArray();
                    //char[] z = sb1.ToString().Where(z => z == '1');

                    if (sumTopic > numMaxTopic)
                    {
                        numMaxTopic = sumTopic;
                    }

                    listMaxTopic.Add(sumTopic);

                    //watch1.Stop();
                    //if (watch1.ElapsedMilliseconds > 10)
                    //{
                    //    Console.WriteLine($"Execution Time: {watch1.ElapsedMilliseconds} ms");
                    //}
                }
            }

            //var watch2 = new System.Diagnostics.Stopwatch();
            //watch2.Start();

            IEnumerable<int> numMaxTeam = listMaxTopic.Where((item, index) => item == numMaxTopic);

            //watch2.Stop();
            //if (watch2.ElapsedMilliseconds > 10)
            //{
            //    Console.WriteLine($"Execution Time: {watch2.ElapsedMilliseconds} ms");
            //}

            res[0] = numMaxTopic;
            res[1] = numMaxTeam.Count();
            return res;
        }

        static Predicate<int> predTeam(int numMaxTopic)
        {
            return delegate (int e)
            {
                return e == numMaxTopic;
            };
        }

        static int[] acmTeam_SLOW(string[] topic)
        {
            int[] res = { 0, 0 };
            int numMaxTopic = 0;
            int p1 = 0;
            int p2 = 0;
            int maxDigit = 18;

            List<int> listMaxTopic = new List<int>();
            string sumTopic = "";
            StringBuilder sb1 = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();
            bool isCal = false;
            int lastPos = 0;
            long t1 = 0;
            long t2 = 0;
            int lTopic = 0;
            BitArray ba1;
            BitArray ba2;
            BitArray ba3;
            bool[] arr;

            for (p1 = 0; p1 < topic.Length - 1; p1++)
            {
                for (p2 = p1 + 1; p2 < topic.Length; p2++)
                {
                    lastPos = 0;
                    sumTopic = "";
                    lTopic = topic[p1].Length;
                    if (lTopic > maxDigit)
                    {
                        lTopic = maxDigit;
                    }

                    isCal = false;
                    while (!isCal)
                    {
                        t1 = long.Parse(topic[p1].Substring(lastPos, lTopic));
                        t2 = long.Parse(topic[p2].Substring(lastPos, lTopic));

                        sumTopic += (t1 + t2).ToString().Replace("2", "1").Replace("0", "");

                        if (lTopic < maxDigit)
                        {
                            isCal = true;
                        }
                        else
                        {
                            lastPos += lTopic;
                            if ((topic[p1].Length - lastPos) >= maxDigit)
                            {
                                lTopic = maxDigit;
                            }
                            else
                            {
                                lTopic = topic[p1].Length - lastPos;
                            }
                        }
                    }

                    if (sumTopic.Length > numMaxTopic)
                    {
                        numMaxTopic = sumTopic.Length;
                    }

                    listMaxTopic.Add(sumTopic.Length);

                }
            }

            IEnumerable<int> numMaxTeam = listMaxTopic.Where((item, index) => item == numMaxTopic);

            res[0] = numMaxTopic;
            res[1] = numMaxTeam.Count();
            return res;
        }

        static int[] acmTeam_old(string[] topic)
        {
            int[] res = { 0, 0 };
            int numMaxTopic = 0;
            int p1 = 0;
            int p2 = 0;
            string strTopic1 = "";
            string strTopic2 = "";
            List<int> listMaxTopic = new List<int>();
            int sumTopic = 0;
            int lMax = 0;

            for (p1 = 0; p1 < topic.Length - 1; p1++)
            {
                for (p2 = p1 + 1; p2 < topic.Length; p2++)
                {
                    strTopic1 = topic[p1];
                    strTopic2 = topic[p2];
                    sumTopic = 0;
                    for (int i = 0; i < strTopic1.Length; i++)
                    {
                        if (strTopic1.Substring(i, 1) == "1" || strTopic2.Substring(i, 1) == "1")
                        {
                            sumTopic++;
                        }
                    }

                    listMaxTopic.Add(sumTopic);
                }

                lMax = listMaxTopic.Max();
                if (lMax > numMaxTopic)
                {
                    numMaxTopic = lMax;
                }
            }

            IEnumerable<int> numMaxTeam = listMaxTopic.Where((item, index) => item == numMaxTopic);

            res[0] = numMaxTopic;
            res[1] = numMaxTeam.Count();
            return res;
        }

    }
}
