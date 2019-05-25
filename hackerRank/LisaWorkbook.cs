using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class LisaWorkbook
    {
        public void Execute()
        {
            //int n = 5;
            //int k = 3;
            //int[] arr = { 4, 2, 6, 1, 10 };
            //int resExp = 4;

            int n = 2;
            int k = 3;
            int[] arr = { 4, 2 };
            int resExp = 1;

            int result = workbook(n, k, arr);

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

        static int workbook(int n, int k, int[] arr)
        {
            int specialProblems = 0;
            int pageNumber = 0;
            int problemsChapter = 0;
            int numProblFrom = 0;
            int numProblTo = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                problemsChapter = arr[i];
                numProblFrom = 1;
                if (problemsChapter >= k)
                {
                    numProblTo = k;
                }
                else
                {
                    numProblTo = problemsChapter;
                }

                while (problemsChapter > 0)
                {
                    pageNumber++;

                    if (pageNumber >= numProblFrom && pageNumber <= numProblTo)
                    {
                        specialProblems++;
                    }

                    problemsChapter -= k;

                    if (problemsChapter > 0)
                    {
                        numProblFrom = numProblTo + 1;
                        if (numProblTo + k <= arr[i])
                        {
                            numProblTo = numProblTo + k;
                        }
                        else
                        {
                            numProblTo = numProblTo + (arr[i] - numProblTo);
                        }
                    }
                }
            }

            return specialProblems;
        }
    }
}
