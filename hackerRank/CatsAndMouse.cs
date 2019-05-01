using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class CatsAndMouse
    {
        public void Execute()
        {
            int x = 2;
            int y = 5;
            int z = 4;
            string resExp = "Cat B";

            string result = catAndMouse(x, y, z);

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

        static string catAndMouse(int x, int y, int z)
        {
            string res = "";

            int lenA = 0;
            int lenB = 0;

            if (x > z)
            {
                lenA = x - z;
            }
            else
            {
                if (x < z)
                {
                    lenA = z - x;
                }
            }

            if (y > z)
            {
                lenB = y - z;
            }
            else
            {
                if (y < z)
                {
                    lenB = z - y;
                }
            }

            if (lenA < lenB)
            {
                res = "Cat A";
            }
            else
            {
                if (lenA > lenB)
                {
                    res = "Cat B";
                }
                else
                {
                    res = "Mouse C";
                }
            }

            return res;
        }


    }
}
