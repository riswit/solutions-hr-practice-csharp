using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class BreakingRecords
    {
        public void Execute()
        {
            int[] scores = { 10, 5, 20, 20, 4, 5, 2, 25, 1 };
            int[] resExp = { 2, 4};

            int[] result = breakingRecords(scores);

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

        static int[] breakingRecords(int[] scores)
        {
            List<int> result = new List<int>();
            int scoreMin = 0;
            int scoreMax = 0;
            int numScoreMin = 0;
            int numScoreMax = 0;

            for (int i = 0; i < scores.Length; i++)
            {
                if (i == 0)
                {
                    scoreMin = scores[i];
                    scoreMax = scores[i];
                }
                else
                {
                    if (scores[i] < scoreMin)
                    {
                        scoreMin = scores[i];
                        numScoreMin++;
                    }
                    else
                    {
                        if (scores[i] > scoreMax)
                        {
                            scoreMax = scores[i];
                            numScoreMax++;
                        }
                    }
                }

            }

            result.Add(numScoreMax);
            result.Add(numScoreMin);

            return result.ToArray();
        }
    }
}
