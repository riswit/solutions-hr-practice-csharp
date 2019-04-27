using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class AppleAndOrange
    {
        public void Execute()
        {
            int a = 4;
            int s = 7;
            int t = 10;
            int b = 12;

            int m = 3;
            int n = 3;

            int[] apples = { 2, 3, -4 };

            int[] oranges = { 3, -2, -4 };

            countApplesAndOranges(s, t, a, b, apples, oranges);
        }

        static void countApplesAndOranges(int s, int t, int a, int b, int[] apples, int[] oranges)
        {
            int numApplesTot = 0;
            int numOrangesTot = 0;
            int applesThrown = 0;
            int orangesThrown = 0;

            for (int i = 0; i < apples.Length; i++)
            {
                applesThrown = a + apples[i];

                if (applesThrown >= s && applesThrown <= t)
                {
                    numApplesTot++;
                }
            }

            for (int i = 0; i < oranges.Length; i++)
            {
                orangesThrown = b + oranges[i];

                if (orangesThrown >= s && orangesThrown <= t)
                {
                    numOrangesTot++;
                }
            }

            Console.WriteLine(numApplesTot);
            Console.WriteLine(numOrangesTot);

        }


    }
}
