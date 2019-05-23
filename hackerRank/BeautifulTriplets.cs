using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class BeautifulTriplets
    {
        public void Execute()
        {
            int d = 3;
            int[] arr = { 1, 2, 4, 5, 7, 8, 10 };
            int resExp = 3;

            int result = beautifulTriplets(d, arr);

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

        static int beautifulTriplets(int d, int[] arr)
        {
            if (arr.Length < 3)
            {
                return 0;
            }

            int numTriplesTot = 0;
            List<int> list = new List<int>();
            
            for (int i = 0; i < arr.Length - 1; i++)
            {
                list = new List<int>();

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (list.Count() == 0)
                    {
                        if (arr[j] - arr[i] == d)
                        {
                            list.Add(arr[i]);
                            list.Add(arr[j]);
                        }
                    }
                    else
                    {
                        if (list.Count() < 3)
                        {
                            if (arr[j] - list[1] == d)
                            {
                                list.Add(arr[j]);

                                if (list[1] - list[0] == list[2] - list[1]
                                    && list[1] - list[0] == d
                                    && list[2] - list[1] == d)
                                {
                                    numTriplesTot++;
                                }
                                break;
                            }
                        }
                    }
                }
            }

            return numTriplesTot;
        }
    }
}
