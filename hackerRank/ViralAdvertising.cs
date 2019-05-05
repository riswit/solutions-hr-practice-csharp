using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class ViralAdvertising
    {
        public void Execute()
        {
            //int n = 3;
            //int resExp = 9;

            int n = 5;
            int resExp = 24;

            int result = viralAdvertising(n);

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

        static int viralAdvertising(int n)
        {
            int liked = 0;
            int totLiked = 0;
            int shared = 5;
            int sharedToFriends = 3;

            for (int numDay = 1; numDay <= n; numDay++)
            {
                if (numDay > 1)
                {
                    shared = (liked * sharedToFriends);
                }

                liked = shared / 2;

                totLiked += liked;
            }

            return totLiked;
        }

    }
}
