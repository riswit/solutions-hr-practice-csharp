using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class DrawingBook
    {
        public void Execute()
        {
            int n = 6;
            int p = 2;
            int resExp = 1;

            //int n = 5;
            //int p = 4;
            //int resExp = 0;

            int result = pageCount(n, p);

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

        static int pageCount(int n, int p)
        {
            if (p == 1)
            {
                return 0;
            }

            int numTurnFromStart = 0;
            int numTurnFromEnd = 0;

            numTurnFromStart = turnPagesFromPos("start", n, p);
            numTurnFromEnd = turnPagesFromPos("end", n, p);

            if (numTurnFromEnd < numTurnFromStart)
            {
                return numTurnFromEnd;
            }

            return numTurnFromStart;
        }

        static int turnPagesFromPos(string startFrom, int n, int p)
        {
            int actualPage = 0;
            int numPageTurned = 0;
            int numPageSx = 0;
            int numPageDx = 0;

            switch (startFrom)
            {
                case "start":
                    break;
                case "end":
                    actualPage = n / 2;
                    if (n % 2 == 0)
                    {
                        numPageSx = n;
                        numPageDx = numPageSx + 1;
                    }
                    else
                    {
                        numPageDx = n;
                        numPageSx = numPageDx - 1;
                    }
                    if (p >= numPageSx && p <= numPageDx)
                    {
                        return 0;
                    }

                    break;
            }

            bool f = false;

            while (!f)
            {
                numPageTurned++;

                switch (startFrom)
                {
                    case "start":
                        actualPage++;
                        break;
                    case "end":
                        actualPage--;
                        break;
                }
                numPageSx = actualPage * 2;
                numPageDx = numPageSx + 1;

                if (p >= numPageSx && p <= numPageDx)
                {
                    f = true;
                }
            }

            return numPageTurned;
        }

    }
}
