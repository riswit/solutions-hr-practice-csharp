using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Numerics;

namespace hackerRank
{
    class ModifiedKaprekarNumbers
    {
        public void Execute()
        {
            int p = 1;
            int q = 100000;

            kaprekarNumbers(p, q);
        }

        static void kaprekarNumbers(int p, int q)
        {
            int d = 0;
            long sqr = 0;
            List<long> listSqr = new List<long>();
            string l = "";
            string r = "";
            int lenRight = 0;

            for (long i = p; i <= q; i++)
            {
                sqr = calcSquare(i);
                lenRight = i.ToString().Length;
                r = sqr.ToString().Substring(sqr.ToString().Length - lenRight).ToString();
                if (sqr.ToString().Length == 1)
                {
                    l = "0";
                }
                else
                {
                    l = sqr.ToString().Substring(0, sqr.ToString().Length - lenRight);
                }

                if (i == (int.Parse(l) + int.Parse(r)))
                {
                    listSqr.Add(i);
                }
            }

            if (listSqr.Count() > 0)
            {
                string strNumsKraper = "";
                foreach (int e in listSqr)
                {
                    if (strNumsKraper != "")
                    {
                        strNumsKraper += " ";
                    }
                    strNumsKraper += e;
                }
                Console.WriteLine(strNumsKraper);
                return;
            }

            Console.WriteLine("INVALID RANGE");
        }

        static long calcSquare(long n)
        {
            return n * n;
        }
    }
}
