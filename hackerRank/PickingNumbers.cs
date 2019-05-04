using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class PickingNumbers
    {
        public void Execute()
        {
            List<int> a = new List<int>();
            //a.Add(1);
            //a.Add(2);
            //a.Add(3);
            //a.Add(3);
            //a.Add(1);
            //a.Add(2);
            //int resExp = 5;

            //a.Add(1);
            //a.Add(1);
            //a.Add(2);
            //a.Add(2);
            //a.Add(4);
            //a.Add(4);
            //a.Add(5);
            //a.Add(5);
            //a.Add(5);
            //int resExp = 5;

            //a.Add(4);
            //a.Add(6);
            //a.Add(5);
            //a.Add(3);
            //a.Add(3);
            //a.Add(1);
            //int resExp = 3;

            a.Add(1);
            a.Add(2);
            a.Add(2);
            a.Add(3);
            a.Add(1);
            a.Add(2);
            int resExp = 5;

            int result = pickingNumbers(a);

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

        public static int pickingNumbers(List<int> a)
        {
            int numMax = 0;
            List<int> p;
            bool isOk = false;

            for (int i = 0; i < a.Count; i++)
            {
                p = new List<int>();
                p.Add(a[i]);

                for (int j = 0; j < a.Count; j++)
                {
                    if (Math.Abs(a[i] - a[j]) <= 1 && i != j)
                    {
                        isOk = true;
                        for (int ip = 0; ip < p.Count; ip++)
                        {
                            if (Math.Abs(p[ip] - a[j]) > 1)
                            {
                                isOk = false;
                            }
                        }
                        if (isOk)
                        {
                            p.Add(a[j]);
                        }
                    }
                }

                if (p.Count > numMax)
                {
                    numMax = p.Count;
                }
            }

            return numMax;
        }


    }
}
