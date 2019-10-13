using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class SherlockBeast
    {
        public void Execute()
        {
            int n = 13;

            decentNumber(n);
        }

        static void decentNumber(int n)
        {
            if (n == 1)
            {
                Console.WriteLine("-1");
                return;
            }

            int z = n;
            string str = "";

            while (z % 3 != 0)
            {
                z -= 5;
                if (z < 0)
                {
                    Console.WriteLine("-1");
                    return;
                }
                else
                {
                    str = (new string('5', z) + (new string('3', n - z)));
                }
            }
            if (str == "" && z % 3 == 0)
            {
                str = new string('5', z) + (new string('3', n - z));
            }
            Console.WriteLine(str);
        }
    }
}
