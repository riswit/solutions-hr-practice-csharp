using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class AlmostSorted
    {
        public void Execute()
        {
            //int[] arr = { 5, 6, 7, 8 }; //yes

            //int[] arr = { 4, 2 }; //swap 1 2

            //int[] arr = { 1, 5, 4, 3, 2, 6 }; //reverse 2 5

            //int[] arr = { 3, 1, 2 }; //no

            int[] arr = { 20, 12, 14, 2 }; //swap 1 4

            almostSorted(arr);
        }

        static void almostSorted(int[] arr)
        {
            List<int> list = new List<int>(arr);
            List<int> listOrdered = new List<int>(arr);
            listOrdered.Sort();

            if (arr.SequenceEqual(listOrdered))
            {
                Console.WriteLine("yes");
                return;
            }

            int change = 0;
            int min = arr.Min();
            int i = 0;

            for (i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] != listOrdered[i])
                {
                    break;
                }
            }

            int indexF = Array.FindIndex(arr, i, e => e == listOrdered[i]);

            change = list[i];
            list[i] = list[indexF];
            list[indexF] = change;

            if (list.SequenceEqual(listOrdered))
            {
                Console.WriteLine("yes");
                Console.WriteLine("swap " + (i + 1).ToString() + " " + (indexF + 1).ToString());
                return;
            }

            list = new List<int>(arr);

            int[] arrRange = new int[(indexF - i + 1)];
            list.CopyTo(i, arrRange, 0, indexF - i + 1);

            List<int> listRev = new List<int>();
            listRev = arrRange.OrderByDescending(c => c).ToList();

            if (listRev.SequenceEqual(arrRange))
            {
                list.Sort(i, indexF - i + 1, Comparer<int>.Default);

                if (list.SequenceEqual(listOrdered))
                {
                    Console.WriteLine("yes");
                    Console.WriteLine("reverse " + (i + 1).ToString() + " " + (indexF + 1).ToString());
                    return;
                }
            }

            Console.WriteLine("no");
        }


    }
}
