using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class EqualizeTheArray
    {
        public void Execute()
        {
            int[] arr = { 1, 2, 2, 3 };
            int resExp = 2;

            //int[] arr = { 3, 3, 2, 1, 3 };
            //int resExp = 2;

            int result = equalizeArray(arr);

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

        static int equalizeArray(int[] arr)
        {
            int numMinDelete = 0;
            int numDup = 0;
            int countMAxDup = 0;

            var groups = arr.GroupBy(v => v);
            foreach (var group in groups)
            {
                if (group.Count() > countMAxDup)
                {
                    countMAxDup = group.Count();
                    numDup = group.Key;
                }
            }

            if (countMAxDup == 1)
            {
                return arr.Length - 1;
            }

            numMinDelete = arr.Length - countMAxDup;

            return numMinDelete;
        }

    }
}
