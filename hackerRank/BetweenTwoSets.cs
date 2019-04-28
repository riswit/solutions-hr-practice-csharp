using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class BetweenTwoSets
    {
        public void Execute()
        {
            int[] a = { 2, 4 };
            int[] b = { 16, 32, 96 };
            int resExp = 3;

            //int[] a = { 2, 6 };
            //int[] b = { 24, 36 };
            //int resExp = 2;

            //int[] a = { 2 };
            //int[] b = { 20, 30, 12 };
            //int resExp = 1;

            //int[] a = { 3, 9, 6 };
            //int[] b = { 36, 72 };
            //int resExp = 2;

            //int[] a = { 1 };
            //int[] b = { 100 };
            //int resExp = 9;

            int total = getTotalX(a, b);

            if (resExp != total)
            {
                Console.WriteLine("Errore - Expected: " + resExp + " - now: " + total);
            }
            else
            {
                Console.WriteLine("Perfetto!!!");
            }

            Console.WriteLine(total);
        }

        static int getTotalX(int[] a, int[] b)
        {
            int numValid = 0;
            List<int> numHidden = getNumHiddenValid(a, b);

            for (int i = 0; i < a.Length; i++)
            {
                if (elemValidA(a[i], a, b))
                {
                    numValid++;
                }
            }

            foreach (int elem in numHidden) {
                if (elemValidA(elem, a, b))
                {
                    numValid++;
                }
            }

            for (int i = 0; i < b.Length; i++)
            {
                if (elemValidB(b[i], numHidden, a, b))
                {
                    numValid++;
                }
                break;
            }

            return numValid;
        }

        static List<int> getNumHiddenValid(int[] a, int[] b)
        {
            List<int> numHidden = new List<int>();

            for (int j = 1; j <= 100; j++)
            {
                if (!existInArrays(j, a, b))
                {
                    if (elemValidA(j, a, b))
                    {
                        numHidden.Add(j);
                    }
                }
            }

            return numHidden;
        }

        static bool existInArrays(int elem, int[] a, int[] b)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (elem == a[i])
                {
                    return true;
                }
            }
            for (int i = 0; i < b.Length; i++)
            {
                if (elem == b[i])
                {
                    return true;
                }
            }

            return false;
        }

        static bool elemValidA(int elem, int[] a, int[] b)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (elem % a[i] != 0)
                {
                    return false;
                }
            }

            for (int i = 0; i < b.Length; i++)
            {
                if (b[i] % elem != 0)
                {
                    return false;
                }
            }

            return true;
        }

        static bool elemValidB(int elem, List<int> numHidden, int[] a, int[] b)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (elem % a[i] != 0)
                {
                    return false;
                }
            }

            foreach (int num in numHidden)
            {
                if (elem % num != 0)
                {
                    return false;
                }
            }

            for (int i = 0; i < b.Length; i++)
            {
                if (b[i] % elem != 0)
                {
                    return false;
                }
            }

            return true;
        }

        static int resMult(int[] a)
        {
            int resA = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (i == 0)
                {
                    resA = a[i];
                }
                else
                {
                    resA = resA * a[i];
                }
            }

            return resA;
        }

        //static bool elemValidC(int elem, int[] a, int[] b)
        //{
        //    for (int i = 0; i < a.Length; i++)
        //    {
        //        if (elem % a[i] != 0)
        //        {
        //            return false;
        //        }
        //    }
        //    for (int i = 0; i < b.Length; i++)
        //    {
        //        if (b[i] >= elem)
        //        {
        //            if (b[i] % elem != 0)
        //            {
        //                return false;
        //            }
        //        }
        //        else
        //        {
        //            if (elem % b[i] != 0)
        //            {
        //                return false;
        //            }
        //        }
        //    }
        //    return true;
        //}

        //static IList<int> loadList(int[] a, int[] b)
        //{
        //    IList<int> intList = new List<int>();

        //    foreach (int elem in a)
        //    {
        //        intList.Add(elem);
        //    }
        //    foreach (int elem in b)
        //    {
        //        intList.Add(elem);
        //    }

        //    return intList;
        //}
    }
}
