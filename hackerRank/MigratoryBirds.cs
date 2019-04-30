using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class MigratoryBirds
    {
        public void Execute()
        {
            List<int> arr = new List<int>();
            arr.Add(1);
            arr.Add(4);
            arr.Add(4);
            arr.Add(4);
            arr.Add(5);
            arr.Add(3);

            int resExp = 4;

            int result = migratoryBirds(arr);

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

        static int migratoryBirds(List<int> arr)
        {
            int[] typeBirdMax = { 0, 0, 0, 0, 0 };
            int typeBird = 0;
            int max = 0;

            for (int i = 0; i < typeBirdMax.Length; i++)
            {
                for (int j = 0; j < arr.Count; j++)
                {
                    if ((i + 1) == arr[j])
                    {
                        typeBirdMax[i]++;
                    }
                }
            }

            for (int j = 0; j < typeBirdMax.Length; j++)
            {
                if (typeBirdMax[j] > max)
                {
                    max = typeBirdMax[j];
                    typeBird = j + 1;
                }
            }

            return typeBird;
        }


    }
}
