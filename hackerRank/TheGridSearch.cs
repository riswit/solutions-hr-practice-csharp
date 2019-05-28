using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class TheGridSearch
    {
        public void Execute()
        {
            //string[] G = { "1234567890", "0987654321", "1111111111", "1111111111", "2222222222" };
            //string[] P = { "876543", "111111", "111111" };
            //string resExp = "YES";

            //string[] G = { "7283455864", "6731158619", "8988242643", "3830589324", "2229505813", "5633845374", "6473530293", "7053106601", "0834282956", "4607924137" };
            //string[] P = { "9505", "3845", "3530" };
            //string resExp = "YES";

            //string[] G = { "400453592126560", "114213133098692", "474386082879648", "522356951189169", "887109450487496", "252802633388782", "502771484966748", "075975207693780", "511799789562806", "404007454272504", "549043809916080", "962410809534811", "445893523733475", "768705303214174", "650629270887160" };
            //string[] P = { "99", "99" };
            //string resExp = "NO";

            //string[] G = { "7652157548860692421022503", "9283597467877865303553675", "4160389485250089289309493", "2583470721457150497569300", "3220130778636571709490905", "3588873017660047694725749", "9288991387848870159567061", "4840101673383478700737237", "8430916536880190158229898", "8986106490042260460547150", "2591460395957631878779378", "1816190871689680423501920", "0704047294563387014281341", "8544774664056811258209321", "9609294756392563447060526", "0170173859593369054590795", "6088985673796975810221577", "7738800757919472437622349", "5474120045253009653348388", "3930491401877849249410013", "1486477041403746396925337", "2955579022827592919878713", "2625547961868100985291514", "3673299809851325174555652", "4533398973801647859680907" };
            //string[] P = { "5250", "1457", "8636", "7660", "7848" };
            //string resExp = "YES";

            //string[] G = { "123412", "561212", "123634", "781288" };
            //string[] P = { "12", "34" };
            //string resExp = "YES";

            string[] G = { "111111111111111", "111111111111111", "111111011111111", "111111111111111", "111111111111111" };
            string[] P = { "11111", "11111", "11110" };
            string resExp = "YES";

            string result = gridSearch(G, P);

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

        static string gridSearch(string[] G, string[] P)
        {
            bool isGAnalyzed = false;
            bool isOk = false;
            string strFirstRowG = "";
            string strNextRowG = "";

            int rowG = -1;
            int startRowG = 0;
            int startColG = -1;
            int colG = 0;
            int initCol = 0;

            while (!isGAnalyzed && !isOk)
            {
                try
                {
                    strFirstRowG = G.Where((e, index) => e.Contains(P[0]) && index >= startRowG).First();
                }
                catch (Exception e)
                {
                    strFirstRowG = "";
                }
                if (strFirstRowG == "" || strFirstRowG == null)
                {
                    return "NO";
                }
                if (P.Length == 1)
                {
                    return "YES";
                }

                startRowG = Array.FindIndex(G, startRowG, e => e == strFirstRowG);
                if (startRowG + P.Length > G.Length)
                {
                    return "NO";
                }
                initCol = 0;
                while (strFirstRowG.IndexOf(P[0], initCol) > -1 && !isOk)
                {
                    startColG = strFirstRowG.IndexOf(P[0], initCol);

                    rowG = startRowG;

                    isOk = true;
                    for (int i = 1; i < P.Length; i++)
                    {
                        rowG++;
                        try
                        {
                            strNextRowG = G.Where((e, index) => e.Contains(P[i]) && index == rowG).First();
                        }
                        catch (Exception e)
                        {
                            strNextRowG = "";
                        }
                        if (strNextRowG == "" || strNextRowG == null)
                        {
                            isOk = false;
                            break;
                        }

                        colG = strNextRowG.IndexOf(P[i], startColG);

                        if (colG != startColG)
                        {
                            isOk = false;
                            break;
                        }
                    }

                    initCol = startColG + 1;
                }

                if (isOk)
                {
                    break;
                }

                startRowG++;

                if (startRowG >= G.Length - 1)
                {
                    isGAnalyzed = true;
                }
            }

            if (isOk)
            {
                return "YES";
            }

            return "NO";
        }


        /*
                    strFirstRowG = G.Where((e, index) => e.Contains(P[0])).First();
                    if (strFirstRowG == "" || strFirstRowG == null)
                    {
                        return "NO";
                    }

                    if (P.Length == 1)
                    {
                        return "YES";
                    }

                    startRowG = Array.FindIndex(G, e => e == strFirstRowG);
                    if (startRowG + P.Length > G.Length)
                    {
                        return "NO";
                    }

                    startColG = strFirstRowG.IndexOfAny(P[0].ToCharArray());
                    rowG = startRowG;
        */

        //startColG = G.Where((e, index) => e.Contains(P[0])).First().IndexOfAny(P[0].ToCharArray());

    }
}
