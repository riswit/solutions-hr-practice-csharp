using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class ElectronicsShop
    {
        public void Execute()
        {
            int[] keyboards = { 3, 1 };
            int[] drives = { 5, 2, 8 };
            int b = 10;
            int resExp = 9;

            //int[] keyboards = { 4 };
            //int[] drives = { 5 };
            //int b = 5;
            //int resExp = -1;

            int result = getMoneySpent(keyboards, drives, b);

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

        static int getMoneySpent(int[] keyboards, int[] drives, int b)
        {
            int maxSpended = 0;
            int next = 0;
            int sum = 0;

            for (int i = 0; i < keyboards.Length; i++)
            {
                for (int j = 0; j < drives.Length; j++)
                {
                    sum = keyboards[i] + drives[j];

                    if (sum > maxSpended && sum <= b)
                    {
                        maxSpended = sum;
                    }
                }
            }

            if (maxSpended > 0)
            {
                return maxSpended;
            }

            return -1;
        }

    }
}
