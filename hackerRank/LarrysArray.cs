using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class LarrysArray
    {
        public void Execute()
        {
            //int[] A = { 1, 6, 5, 2, 4, 3 };
            //string resExp = "YES";

            //int[] A = { 1, 2, 3 };
            //string resExp = "YES";

            //int[] A = { 3, 1, 2 };
            //string resExp = "YES";

            //int[] A = { 1, 3, 4, 2 };
            //string resExp = "YES";

            int[] A = { 1, 2, 3, 5, 4 };
            string resExp = "NO";

            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            string result = larrysArray(A);

            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

            if (resExp != result)
            {
                Console.WriteLine("Errore - Expected: " + resExp + " - now: " + result);
            }
            else
            {
                Console.WriteLine("Perfetto!!!");
                Console.WriteLine(result);
            }
        }

        static string larrysArray(int[] A)
        {
            int min = A.Min();
            int max = A.Max();
            List<int> listOrdered = getListOrdered(min, max);

            if (A.SequenceEqual(listOrdered))
            {
                return "YES";
            }

            int indexInit = 0;
            int counter = 0;
            int nextNum = 0;
            int indexNext = 0;
            bool isOk = false;

            while (!isOk)
            {
                if (indexInit == 0 && A[0] != min)
                {
                    nextNum = min;
                }
                else
                {
                    indexInit = getIndexBreak(A, indexInit);
                    if (indexInit >= (A.Length - 1))
                    {
                        break;
                    }
                    counter = A[indexInit - 1];
                    nextNum = counter + 1;
                }

                if (counter > A.Length)
                {
                    break;
                }

                indexNext = Array.FindIndex(A, indexInit, e => e == nextNum);

                if (indexNext == (A.Length - 1) && indexNext - indexInit == 1)
                {
                    return "NO";
                }

                A = rotatePartialArray(A, indexInit, indexNext, nextNum);

                if (A.SequenceEqual(listOrdered))
                {
                    return "YES";
                }
            }

            if (A.SequenceEqual(listOrdered))
            {
                return "YES";
            }

            return "NO";
        }

        static int[] rotatePartialArray(int [] A, int indexInit, int indexNext, int nextNum)
        {
            int lenFromCounter = 0;
            int numRotate = 2;
            int[] r = new int[3];

            while (numRotate == 2)
            {
                lenFromCounter = indexNext - indexInit;

                if (lenFromCounter < 2)
                {
                    numRotate = 1;
                }

                if (numRotate == 1)
                {
                    r[0] = A[indexNext];
                    r[1] = A[indexNext + 1];
                    r[2] = A[indexNext - 1];

                    A[indexNext - 1] = r[0];
                    A[indexNext] = r[1];
                    A[indexNext + 1] = r[2];

                    indexNext -= 1;
                }
                else
                {
                    r[0] = A[indexNext];
                    r[1] = A[indexNext - 2];
                    r[2] = A[indexNext - 1];

                    A[indexNext - 2] = r[0];
                    A[indexNext - 1] = r[1];
                    A[indexNext] = r[2];

                    indexNext -= 2;
                }

                if (indexInit == indexNext)
                {
                    break;
                }
            }

            return A;
        }

        static bool isOrdered(int[] r)
        {
            if ((r[0] < r[1] && r[1] - r[0] == 1)
                && (r[1] < r[2] && r[2] - r[1] == 1))
            {
                return true;
            }
            return false;
        }

        static int getIndexBreak(int[] A, int start)
        {
            int i = 0;

            if (start == A.Length - 1)
            {
                return A.Length - 1;
            }

            for (i = start; i < A.Length - 1; i++)
            {
                if (!(A[i] < A[i + 1] && A[i + 1] - A[i] == 1))
                {
                    break;
                }
            }

            return i + 1;
        }

        static List<int> getListOrdered(int from, int to)
        {
            List<int> list = new List<int>();

            for (int i = from; i <= to; i++)
            {
                list.Add(i);
            }
            return list;
        }

    }
}
