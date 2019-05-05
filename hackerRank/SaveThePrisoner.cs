using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class SaveThePrisoner
    {
        public void Execute()
        {
            //int n = 5; // the number of prisoners
            //int m = 2; // the number of sweets
            //int s = 1; // the chair number to start passing out treats at
            //int resExp = 2;

            //int n = 5;
            //int m = 2;
            //int s = 2;
            //int resExp = 3;

            //int n = 5;
            //int m = 5;
            //int s = 4;
            //int resExp = 3;

            //int n = 5;
            //int m = 4;
            //int s = 2;
            //int resExp = 5;

            //int n = 7;
            //int m = 19;
            //int s = 2;
            //int resExp = 6;

            int n = 3;
            int m = 7;
            int s = 3;
            int resExp = 3;

            int result = saveThePrisoner(n, m, s);

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

        static int saveThePrisoner(int n, int m, int s)
        {
            int chairNumber = 0;

            if (m <= n)
            {
                chairNumber = getChairNumberSweetLess(n, m, s);
            }
            else
            {
                int cicles = 0;
                int i = 0;
                int sweetNeedFirstCicle = n - s + 1;
                if ((m - sweetNeedFirstCicle) % n == 0)
                {
                    cicles = ((m - sweetNeedFirstCicle) / n) - 1;
                }
                else
                {
                    cicles = ((m - sweetNeedFirstCicle) / n);
                }
                int sweetRem = (m - sweetNeedFirstCicle) - (cicles * n);
                chairNumber = sweetRem;
            }

            return chairNumber;
        }

        static int getChairNumberSweetLess(int n, int m, int s)
        {
            int chairNumber = 0;

            if (s == 1)
            {
                chairNumber = m;
            }
            else
            {
                if ((n - s + 1) >= m)
                {
                    chairNumber = s;
                    chairNumber += (m - 1);
                }
                else
                {
                    chairNumber = m - (n - s + 1);
                }
            }

            return chairNumber;

        }




        static int getChairNumberSlow_NotUse(int n, int m, int s)
        {
            int chairNumber = 0;

            for (int j = 1; j <= m; j++)
            {
                if (j == 1)
                {
                    chairNumber = s;
                }
                else
                {
                    if (chairNumber == n && j < m)
                    {
                        chairNumber = 1;
                    }
                    else
                    {
                        if (chairNumber < n)
                        {
                            chairNumber++;
                        }
                    }
                }
            }

            return chairNumber;
        }

    }
}
