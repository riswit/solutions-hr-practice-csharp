using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class BirthdayChocolate
    {
        public void Execute()
        {
            //List<int> s = new List<int>() { 2, 2, 1, 3, 2 };
            //int d = 4;
            //int m = 2;
            //int resExp = 2;

            List<int> s = new List<int>() { 4 };
            int d = 4;
            int m = 1;
            int resExp = 1;

            int result = birthday(s, d, m);

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

        static int birthday(List<int> s, int d, int m)
        {
            if (s.Count < m)
            {
                return 0;
            }

            if (getSumListInt(s) < d)
            {
                return 0;
            }

            int numTimes = 0;

            for (int i = 0; i < s.Count; i++)
            {
                if (foundSeq(i, s, d, m))
                {
                    numTimes++;
                }
            }

            return numTimes;
        }

        static bool foundSeq(int start, List<int> s, int d, int m)
        {
            int sum = 0;
            int c = 0;
            int i = start;

            while (c < m)
            {
                if (i >= s.Count)
                {
                    break;
                }
                sum += s[i];

                i++;
                c++;
            }

            if (sum == d)
            {
                return true;
            }

            return false;
        }

        static int getSumListInt(List<int> s)
        {
            int sum = 0;
            for (int i = 0; i < s.Count; i++)
            {
                sum += s[i];
            }
            return sum;
        }

        class ContextPos {
            private int startPos;
            private int lastPos;

            public ContextPos(int startPos, int lastPos)
            {
                this.startPos = startPos;
                this.lastPos = lastPos;
            }

            public int StartPos
            {
                get { return startPos; }
                set { startPos = value; }
            }
            public int LastPos
            {
                get { return lastPos; }
                set { lastPos = value; }
            }


        }
    }
}
