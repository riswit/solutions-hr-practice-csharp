using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class Kangaroo
    {
        public void Execute()
        {
            int x1 = 0;
            int v1 = 3;
            int x2 = 4;
            int v2 = 2;

            String can = matchKangaroo(x1, v1, x2, v2);

            Console.WriteLine(can);
        }

        static string matchKangaroo(int x1, int v1, int x2, int v2)
        {
            int len1 = v1 - x1;

            if ((x2 >= x1 && v2 > v1) 
                || (x1 >= x2 && v1 > v2) 
                || (x2 >= v1 && v2 > v1) 
                || (x2 > len1 && v2 > v1))
            {
                return "NO";
            }

            for (int i = 1; i <= 10000; i++)
            {
                if (x1 + v1 == x2 + v2) {
                    return "YES";
                }
                x1 += v1;
                x2 += v2;
            }

            return "NO";
        }

    }
}
