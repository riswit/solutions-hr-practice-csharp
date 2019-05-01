using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class BonAppetit
    {
        public void Execute()
        {
            List<int> bill = new List<int>();
            bill.Add(3);
            bill.Add(10);
            bill.Add(2);
            bill.Add(9);

            int k = 1;
            int b = 7;

            bonAppetit(bill, k, b);
        }

        static void bonAppetit(List<int> bill, int k, int b)
        {
            string res = "";
            int costAnna = 0;
            int costTot = 0;

            for (int i = 0; i < bill.Count; i++)
            {
                if (i != k)
                {
                    costAnna += bill[i];
                }
                costTot += bill[i];
            }

            costAnna = costAnna / 2;

            if (b > costAnna)
            {
                res = (b - costAnna).ToString();
            }
            else
            {
                res = "Bon Appetit";
            }

            Console.WriteLine(res);
        }

    }
}
