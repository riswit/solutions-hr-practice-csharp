using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class LeftRotation
    {
        public void Execute()
        {
            int n = 0;
            int d = 4;
            int[] a = { 1, 2, 3, 4, 5 };
            int[] resExp = { 5, 1, 2, 3, 4 };

            int[] result = leftRotation(n, d, a);

            if (string.Join(" ", resExp) != string.Join(" ", result))
            {
                Console.WriteLine("Errore - Expected: " + string.Join(" ", resExp) + " - now: " + string.Join(" ", result));
            }
            else
            {
                Console.WriteLine("Perfetto!!!");
                Console.WriteLine(string.Join(" ", result));
            }
        }

        static int[] leftRotation(int n, int d, int[] a)
        {
            var l = a.Where((e, ind) => ind < d);
            return (a.Where((e, ind) => ind >= d)).Concat(l).ToArray();

        }

    }

    /*
    TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

    string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

    int n = Convert.ToInt32(firstMultipleInput[0]);

    int q = Convert.ToInt32(firstMultipleInput[1]);

    List<List<int>> queries = new List<List<int>>();

        for (int i = 0; i<q; i++)
        {
            queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
        }

List<int> result = Result.dynamicArray(n, queries);

textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    */
}
