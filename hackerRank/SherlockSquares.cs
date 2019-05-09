using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class SherlockSquares
    {
        public void Execute()
        {
            //int a = 3;
            //int b = 9;
            //int resExp = 2;

            //int a = 17;
            //int b = 24;
            //int resExp = 0;

            //int a = 100;
            //int b = 1000;
            //int resExp = 22;

            int a = 24;
            int b = 49;
            int resExp = 3;

            int result = squares(a, b);

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

        static int squares(int a, int b)
        {
            int numSquares = 0;

            int nA = (int)Math.Sqrt(a);
            int nB = (int)Math.Sqrt(b);

            if ((a % Math.Sqrt(a)) == 0 && (b % Math.Sqrt(b)) == 0 && a == b)
            {
                return 1;
            }

            if (nA == nB)
            {
                return 0;
            }

            if ((a % Math.Sqrt(a)) == 0)
            {
                numSquares++;
            }

            numSquares += nB - nA;

            return numSquares;
        }

        /*
        double actualSquares = 0;
        double lastSquares = 0;
        int n = a;

        while (n <= b)
        {
            actualSquares = Math.Sqrt(n);
            if ((n % actualSquares) == 0)
            {
                if (numSquares > 0)
                {
                    n += (int)((actualSquares - lastSquares) + actualSquares + 2);
                }
                else
                {
                    n++;
                }
                numSquares++;
                lastSquares = actualSquares;
            }
            else
            {
                n++;
            }
        }
        */

    }
}
