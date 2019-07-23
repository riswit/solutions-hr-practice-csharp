using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class SherlockAndArray
    {
        public void Execute()
        {
            //int[] B = { 1, 1, 4, 1, 1 };
            //string resExp = "YES";

            //int[] B = { 1, 2, 3 };
            //string resExp = "NO";

            //int[] B = { 1, 2, 3, 3 };
            //string resExp = "YES";

            //int[] B = { 2, 0, 0, 0 };
            //string resExp = "YES";

            int[] B = { 1, 2 };
            string resExp = "NO";

            List<int> arr = new List<int>();

            arr.AddRange(B);

            string result = balancedSums(arr);

            if (resExp != result)
            {
                Console.WriteLine("Errore - Expected: " + resExp + " - now: " + result);
            }
            else
            {
                Console.WriteLine(result);
                Console.WriteLine("Perfetto!!!");
            }

        }

        static string balancedSums(List<int> arr)
        {
            int lenArr = arr.Count();
            if (lenArr == 1)
            {
                return "YES";
            }
            if (lenArr == 2)
            {
                if (arr[0].Equals(arr[1]))
                {
                    return "YES";
                }
                else
                {
                    return "NO";
                }
            }

            int[] arrSum = new int[lenArr];
            int[] arrSumRev = new int[lenArr];
            int c1 = 0;
            int c2 = 0;
            int sumSx = 0;
            int sumDx = 0;

            for (int i = 0; i < lenArr; i++)
            {
                if (i == 0)
                {
                    arrSum[i] = arr[i];
                }
                else
                {
                    c1 = arr[i];
                    c2 = arrSum[i - 1];
                    arrSum[i] = c1 + c2;
                }
            }

            for (int i = lenArr - 1; i >= 0; i--)
            {
                if (i == lenArr - 1)
                {
                    sumSx = arrSum[i - 1];
                    sumDx = 0;
                }
                else
                {
                    if (i == 0)
                    {
                        sumSx = 0;
                    }
                    else
                    {
                        sumSx = arrSum[i - 1];
                        c1 = arr[i + 1];
                        sumDx += c1;
                    }
                }

                if (sumSx.Equals(sumDx))
                {
                    return "YES";
                }
            }

            return "NO";
        }
    }
}
