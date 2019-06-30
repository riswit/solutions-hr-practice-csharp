using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class IntroTutorialChallenges
    {
        public void Execute()
        {
            int V = 4;
            int[] arr = { 1, 4, 5, 7, 9, 12 };
            int resExp = 1;

            int result = introTutorial(V, arr);

            if (resExp != result)
            {
                Console.WriteLine("Errore - Expected: " + resExp + " - now: " + result);
            }
            else
            {
                Console.WriteLine("Perfetto!!!");
                Console.WriteLine(result);
            }

        }

        static int introTutorial(int V, int[] arr)
        {
            return Array.FindIndex(arr, m => m.Equals(V));

        }
    }
}
