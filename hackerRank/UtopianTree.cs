using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class UtopianTree
    {
        public void Execute()
        {
            //int n = 0;
            //int resExp = 1;

            //int n = 1;
            //int resExp = 2;

            int n = 4;
            int resExp = 7;

            int result = utopianTree(n);

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

        static int utopianTree(int n)
        {
            int h = 1;
            bool isSpring = true;

            for (int i = 1; i <= n; i++)
            {
                if (isSpring)
                {
                    h = (h * 2);
                    isSpring = false;
                }
                else
                {
                    h += 1;
                    isSpring = true;
                }
            }

            return h;
        }


    }
}
