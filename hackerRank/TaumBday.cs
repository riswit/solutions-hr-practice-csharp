using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace hackerRank
{
    class TaumBday
    {
        public void Execute()
        {
            //int b = 10;
            //int w = 10;
            //int bc = 1;
            //int wc = 1;
            //int z = 1;
            //int resExp = 20;

            //int b = 5;
            //int w = 9;
            //int bc = 2;
            //int wc = 3;
            //int z = 4;
            //int resExp = 37;

            //int b = 3;
            //int w = 6;
            //int bc = 9;
            //int wc = 1;
            //int z = 1;
            //int resExp = 12;

            //int b = 7;
            //int w = 7;
            //int bc = 4;
            //int wc = 2;
            //int z = 1;
            //int resExp = 35;

            //int b = 0;
            //int w = 7;
            //int bc = 0;
            //int wc = 2;
            //int z = 1;
            //int resExp = 35;

            //int b = 3;
            //int w = 5;
            //int bc = 3;
            //int wc = 4;
            //int z = 1;
            //int resExp = 29;

            int b = 27984;
            int w = 1402;
            int bc = 619246;
            int wc = 615589;
            int z = 247954;
            BigInteger resExp = 18192035842;

            BigInteger total = taumBday(b, w, bc, wc, z);

            if (resExp != total)
            {
                Console.WriteLine("Errore - Expected: " + resExp + " - now: " + total);
            }
            else
            {
                Console.WriteLine("Perfetto!!!");
            }

            Console.WriteLine(total);
        }

        static BigInteger taumBday(int b, int w, int bc, int wc, int z)
        {
            BigInteger wg = 0;
            BigInteger bg = 0;
            BigInteger t = 0;
            
            if (bc == wc
                || (z > bc && z > wc))
            {
                bg = BigInteger.Multiply(b, bc);
                wg = BigInteger.Multiply(w, wc);
                return BigInteger.Add(wg, bg); 
            }
            
            if (bc < wc)
            {
                bg = BigInteger.Multiply(b, bc);
                t = BigInteger.Add(bc, z);

                if (BigInteger.Compare(wc, t) == 1)
                {
                    wg = BigInteger.Multiply(w, t);
                }
                else
                {
                    wg = BigInteger.Multiply(w, wc);
                }
            }

            if (bc > wc)
            {
                wg = BigInteger.Multiply(w, wc);
                t = BigInteger.Add(wc, z);

                if (BigInteger.Compare(bc, t) == 1)
                {
                    bg = BigInteger.Multiply(b, t);
                }
                else
                {
                    bg = BigInteger.Multiply(b, bc);
                }
            }

            return BigInteger.Add(wg, bg);
        }


        static BigInteger taumBday1(int b, int w, int bc, int wc, int z)
        {
            BigInteger wg = 0;
            BigInteger bg = 0;
            BigInteger t = 0;

            if (bc == wc
                || (z > bc && z > wc))
            {
                bg = BigInteger.Multiply(b, bc);
                wg = BigInteger.Multiply(w, wc);
                return BigInteger.Add(wg, bg);
            }

            if (bc < wc)
            {
                bg = BigInteger.Multiply(b, bc);
                if (wc > bc + z)
                {
                    wg = w * (bc + z);
                }
                else
                {
                    wg = w * wc;
                }
            }

            if (bc > wc)
            {
                wg = w * wc;
                if (bc > wc + z)
                {
                    bg = b * (wc + z);
                }
                else
                {
                    bg = b * bc;
                }
            }

            return BigInteger.Add(wg, bg);
        }

        //if (bc < (wc + z))
        //{
        //    wg = (b + w) * wc;
        //    bg = b * z;
        //    return wg + bg;
        //}

    }
}
