using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    //https://www.hackerrank.com/challenges/ctci-ransom-note/problem
    class HashTablesRansomNote
    {
        public void Execute()
        {
            string[] magazine = { "give", "me", "one", "grand", "today", "night" }; 
            string[] note = { "give", "one", "grand", "today" }; 

            checkMagazine(magazine, note);
        }

        static void checkMagazine(string[] magazine, string[] note)
        {
            Dictionary<string, int?> d = magazine.GroupBy(x => x).ToDictionary(p => p.Key, p => (int?)p.Count());
            int c = 0;

            for (int i = 0; i < note.Length; i++)
            {
                if (getValueMap(d, note[i]))
                {
                    d[note[i]] -= 1;
                    if (d[note[i]] < 0)
                    {
                        Console.WriteLine("No");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("No");
                    return;
                }

            }

            Console.WriteLine("Yes");
        }

        static bool getValueMap(Dictionary<string, int?> t, string e)
        {
            int? v = null;
            t.TryGetValue(e, out v);

            if (v == null) { return false; }

            return true;
        }

    }
}
