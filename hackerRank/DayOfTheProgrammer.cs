using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class DayOfTheProgrammer
    {
        public void Execute()
        {
            int year = 1918;
            string resExp = "26.09." + year;

            string result = dayOfProgrammer(year);

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

        static string dayOfProgrammer(int year)
        {
            string dayOfProgr = "";
            int numDayOfYear = 256;
            int[] daysMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int i = 0;
            int numDays = 0;
            int day = 0;
            int numMonth = 0;

            if (year == 1918)
            {
                daysMonth[1] = 15;
            }

            if (isLeapYear(year))
            {
                daysMonth[1]++;
            }

            while (i < 12 && numDays < numDayOfYear)
            {
                numMonth++;

                if ((numDays + daysMonth[i]) > numDayOfYear)
                {
                    day = numDayOfYear - numDays;
                    numDays += day;
                }
                else
                {
                    numDays += daysMonth[i];
                }

                i++;
            }

            if (day < 10)
            {
                dayOfProgr += "0";
            }
            dayOfProgr += day.ToString() + ".";
            if (numMonth < 10)
            {
                dayOfProgr += "0";
            }
            dayOfProgr += numMonth.ToString() + "." + year;

            return dayOfProgr;
        }

        static bool isLeapYear(int year)
        {
            string gregGiul = isGregGiulURSS(year);

            switch (gregGiul)
            {
                case "giulian":
                    if (year % 4 == 0)
                    {
                        return true;
                    }
                    break;
                case "gregorian":
                    if (year % 400 == 0)
                    {
                        return true;
                    }
                    if (year % 4 == 0)
                    {
                        if (year % 100 != 0)
                        {
                            return true;
                        }
                    }
                    break;
            }

            return false;
        }

        static string isGregGiulURSS(int year)
        {
            string res = "";

            if (year >= 1700 && year <= 1917)
            {
                res = "giulian";
            }
            else
            {
                if (year >= 1918)
                {
                    res = "gregorian";
                }
            }

            return res;
        }

    }
}
