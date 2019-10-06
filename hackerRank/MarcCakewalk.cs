using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class MarcCakewalk
    {
        public void Execute()
        {
            int[] calorie = { 3, 3, 9, 9, 5 };
            long resExp = 10;

            long result = marcsCakewalk(calorie);

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

        static long marcsCakewalk(int[] calorie)
        {
            long res = 0;

            calorie = calorie.OrderByDescending(x => x).ToArray();

            for (int i = 0; i < calorie.Length; i++)
            {
                res += ((long)(Math.Pow(2, i)) * calorie[i]);
            }

            return res;
        }
    }
}
