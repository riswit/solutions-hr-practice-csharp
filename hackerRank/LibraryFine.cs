using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace hackerRank
{
    class LibraryFine
    {
        public void Execute()
        {
            int d1 = 9;
            int m1 = 6;
            int y1 = 2015;

            int d2 = 6;
            int m2 = 6;
            int y2 = 2015;

            int resExp = 45;

            int result = libraryFine(d1, m1, y1, d2, m2, y2);

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

        static int libraryFine(int d1, int m1, int y1, int d2, int m2, int y2)
        {
            CultureInfo strCultureInfo = new CultureInfo("en-US");
            int fine = 0;

            DateTime dueDate = DateTime.Parse(m2.ToString() + "/" + d2.ToString() + "/" + y2.ToString(), strCultureInfo);
            DateTime returnDate = DateTime.Parse(m1.ToString() + "/" + d1.ToString() + "/" + y1.ToString(), strCultureInfo);

            if ((returnDate - dueDate).TotalDays <= 0)
            {
                return 0;
            }

            if (dueDate.Month == returnDate.Month 
                && dueDate.Year == returnDate.Year)
            {
                return ((int)(returnDate - dueDate).TotalDays) * 15;
            }

            if (returnDate.Month > dueDate.Month
                && dueDate.Year == returnDate.Year)
            {
                return (returnDate.Month - dueDate.Month) * 500;
            }

            if (returnDate.Year > dueDate.Year)
            {
                return 10000;
            }

            return fine;
        }

    }
}
