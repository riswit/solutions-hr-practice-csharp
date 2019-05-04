using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace hackerRank
{
    class ClimbingLeaderboard
    {
        public void Execute()
        {

            int[] scores = new int[200000];
            int[] alice = new int[100000];
            int[] resExp = new int[100000];

            //string AppPath = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            //string path = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            //var directory = System.IO.Path.GetDirectoryName(path);

            string dir = @"F:\test\hr\hackerRank\hackerRank\testClimbingLeaderboard\";
            var fileStream = new FileStream(dir + "input06.txt", FileMode.Open, FileAccess.Read);

            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                int i = 0;
                while ((line = streamReader.ReadLine()) != null)
                {
                    switch (i)
                    {
                        case 0:
                            scores = new int[int.Parse(line)];
                            break;
                        case 1:
                            scores = line.Split(' ').Select(Int32.Parse).ToArray();
                            break;
                        case 2:
                            alice = new int[int.Parse(line)];
                            break;
                        case 3:
                            alice = line.Split(' ').Select(Int32.Parse).ToArray();
                            break;
                    }
                    i++;
                }
            }

            var fileStreamOut = new FileStream(dir + "output06.txt", FileMode.Open, FileAccess.Read);

            using (var streamReader = new StreamReader(fileStreamOut, Encoding.UTF8))
            {
                string line;
                int i = 0;
                while ((line = streamReader.ReadLine()) != null)
                {
                    switch (i)
                    {
                        case 0:
                            resExp = line.Split(',').Select(Int32.Parse).ToArray();
                            break;
                    }
                    i++;
                    break;
                }
            }

            //scores = new int[] { 100, 100, 50, 40, 40, 20, 10 };
            //alice = new int[] { 5, 25, 50, 120 };
            //resExp = new int[] { 6, 4, 2, 1 };

            //scores = new int[] { 997, 981, 957, 933, 930, 927, 926, 920, 916, 896, 887, 874, 863, 863, 858, 847, 815, 809, 803, 794, 789, 785, 783, 778, 764, 755, 751, 740, 737, 730, 691, 677, 652, 650, 587, 585, 583, 568, 546, 541, 540, 538, 531, 527, 506, 493, 457, 435, 430, 427, 422, 422, 414, 404, 400, 394, 387, 384, 374, 371, 369, 369, 368, 365, 363, 337, 336, 328, 325, 316, 314, 306, 282, 277, 230, 227, 212, 199, 179, 173, 171, 168, 136, 125, 124, 95, 92, 88, 85, 70, 68, 61, 60, 59, 44, 43, 28, 23, 13, 12 };
            //alice = new int[] { 12, 20, 30, 32, 35, 37, 63, 72, 83, 85, 96, 98, 98, 118, 122, 125, 129, 132, 140, 144, 150, 164, 184, 191, 194, 198, 200, 220, 228, 229, 229, 236, 238, 246, 259, 271, 276, 281, 283, 287, 300, 302, 306, 307, 312, 318, 321, 325, 341, 341, 341, 344, 349, 351, 354, 356, 366, 369, 370, 379, 380, 380, 396, 405, 408, 417, 423, 429, 433, 435, 438, 441, 442, 444, 445, 445, 452, 453, 465, 466, 467, 468, 469, 471, 475, 482, 489, 491, 492, 493, 498, 500, 501, 504, 506, 508, 523, 529, 530, 539, 543, 551, 552, 556, 568, 569, 571, 587, 591, 601, 602, 606, 607, 612, 614, 619, 620, 623, 625, 625, 627, 638, 645, 653, 661, 662, 669, 670, 676, 684, 689, 690, 709, 709, 710, 716, 724, 726, 730, 731, 733, 737, 744, 744, 747, 757, 764, 765, 765, 772, 773, 774, 777, 787, 794, 796, 797, 802, 805, 811, 814, 819, 819, 829, 830, 841, 842, 847, 857, 857, 859, 860, 866, 872, 879, 882, 895, 900, 900, 903, 905, 915, 918, 918, 922, 925, 927, 928, 929, 931, 934, 937, 955, 960, 966, 974, 982, 988, 996, 996 };
            //resExp = new int[] { 97, 96, 94, 94, 94, 94, 89, 87, 87, 86, 83, 83, 83, 83, 83, 81, 81, 81, 80, 80, 80, 80, 76, 76, 76, 76, 75, 74, 73, 73, 73, 72, 72, 72, 72, 72, 72, 71, 70, 70, 70, 70, 69, 69, 69, 67, 67, 66, 63, 63, 63, 63, 63, 63, 63, 63, 61, 59, 59, 57, 57, 57, 54, 52, 52, 51, 50, 49, 48, 47, 47, 47, 47, 47, 47, 47, 47, 47, 46, 46, 46, 46, 46, 46, 46, 46, 46, 46, 46, 45, 45, 45, 45, 45, 44, 44, 44, 43, 43, 41, 39, 38, 38, 38, 37, 37, 37, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 32, 32, 32, 32, 32, 32, 31, 31, 31, 30, 30, 30, 30, 30, 30, 29, 29, 29, 28, 27, 27, 27, 25, 24, 24, 24, 24, 24, 24, 24, 21, 19, 19, 19, 19, 18, 17, 17, 16, 16, 16, 16, 16, 16, 15, 15, 15, 14, 14, 13, 13, 12, 12, 11, 10, 10, 10, 10, 10, 9, 9, 8, 8, 6, 6, 6, 5, 4, 4, 4, 3, 3, 3, 2, 2, 2, 2 };

            //scores = new int[] { 100, 100, 50, 40, 40, 20, 10 };
            //alice = new int[] { 5, 25, 50, 120 };
            //resExp = new int[] { 6, 4, 2, 1 };

            //scores = new int[] { 100, 90, 90, 80, 75, 60 };
            //alice = new int[] { 50, 65, 77, 90, 102 };
            //resExp = new int[] { 6, 5, 4, 2, 1 };

            //scores = new int[] { 109, 10, 10, 10, 9, 8 };
            //alice = new int[] { 1, 109 };
            //resExp = new int[] { 5, 1 };

            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();

            int[] result = climbingLeaderboard(scores, alice);

            watch.Stop();

            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

            if (string.Join(" ", resExp) != string.Join(" ", result))
            {
                Console.WriteLine("Errore!!!");
                Console.WriteLine("Expected: ");
                Console.WriteLine(string.Join(" ", resExp));
                Console.WriteLine("");
                Console.WriteLine("Now: ");
                Console.WriteLine(string.Join(" ", result));
            }
            else
            {
                Console.WriteLine("Perfetto!!!");
            }

            //Console.WriteLine(string.Join(" ", result));
        }

        static int[] climbingLeaderboard(int[] scores, int[] alice)
        {
            int[] rankScores = getArrayRank(scores);
            int[] rankAlice = new int[alice.Length];
            int indScores = scores.Length;

            for (int i = 0; i < alice.Length; i++)
            {
                if (alice[i] < scores[scores.Length - 1])
                {
                    rankAlice[i] = rankScores[rankScores.Length - 1] + 1;
                }
                else
                {
                    if (alice[i] >= scores[0])
                    {
                        rankAlice[i] = 1;
                    }
                    else
                    {
                        if (indScores == 1)
                        {
                            if (alice[i] == scores[0])
                            {
                                rankAlice[i] = rankScores[0];
                            }
                            else
                            {
                                rankAlice[i] = rankScores[0] + 1;
                            }
                        }

                        for (int s = indScores; s > 1; s--)
                        {
                            if (alice[i] == scores[s - 1])
                            {
                                rankAlice[i] = rankScores[s - 1];
                                if (i > 100 && scores.Length > 200)
                                {
                                    indScores = s;
                                }
                                break;
                            }
                            else
                            {
                                if (alice[i] > scores[s - 1] && alice[i] < scores[s - 2])
                                {
                                    rankAlice[i] = rankScores[s - 2] + 1;
                                    if (i > 100 && scores.Length > 200)
                                    {
                                        indScores = s;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            return rankAlice;
        }

        static int[] getArrayRank(int[] scores)
        {
            int actualRank = 1;
            int[] arrayRank = new int[scores.Length];
            arrayRank[0] = actualRank;

            for (int i = 1; i < scores.Length; i++)
            {
                if (i == (scores.Length - 1))
                {
                    if (scores[i] < scores[i - 1])
                    {
                        actualRank++;
                    }
                }
                else
                {
                    if (scores[i] < scores[i - 1])
                    {
                        actualRank++;
                    }
                }
                arrayRank[i] = actualRank;
            }

            return arrayRank;
        }

    }
}
