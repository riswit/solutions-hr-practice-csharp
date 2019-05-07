using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace hackerRank
{
    class ExtraLongFactorials
    {
        public void Execute()
        {
            int n = 30;

            extraLongFactorials(n);
        }


        static void extraLongFactorials(int n)
        {
            BigInteger res = n;

            for (int i = 1; i < n; i++)
            {
                res = res * (n - i);
            }

            Console.WriteLine(res.ToString());
        }

    }


}
