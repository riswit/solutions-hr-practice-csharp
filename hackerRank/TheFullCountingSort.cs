using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class TheFullCountingSort
    {
        public void Execute()
        {
            List<List<string>> arr = new List<List<string>>
                                {   new List<string>(){"0", "ab"},
                                    new List<string>(){"6", "cd"},
                                    new List<string>(){"0", "ef"},
                                    new List<string>(){"6", "gh"},
                                    new List<string>(){"4", "ij"},
                                    new List<string>(){"0", "ab"},
                                    new List<string>(){"6", "cd"},
                                    new List<string>(){"0", "ef"},
                                    new List<string>(){"6", "gh"},
                                    new List<string>(){"0", "ij"},
                                    new List<string>(){"4", "that"},
                                    new List<string>(){"3", "be"},
                                    new List<string>(){"0", "to"},
                                    new List<string>(){"1", "be"},
                                    new List<string>(){"5", "question"},
                                    new List<string>(){"1", "or"},
                                    new List<string>(){"2", "not"},
                                    new List<string>(){"4", "is"},
                                    new List<string>(){"2", "to"},
                                    new List<string>(){"4", "the"}
                                };

            countSort(arr);
        }

        static void countSort(List<List<string>> arr)
        {
            int m = arr.Count() / 2;

            var s = arr.Aggregate(new List<List<string>>(), (acc, val) => transform(acc, val, m)).ToList();

            var q = (from a in s orderby int.Parse(a[0]) select a);

            string res = q.Aggregate(new StringBuilder(), (acc, val) => ch(acc, val, m)).ToString();

            Console.WriteLine(res);
        }

        static List<List<string>> transform(List<List<string>> acc, List<string> val, int m)
        {
            if (acc.Count() < m)
            {
                val[1] = "-"; 
            }
            acc.Add(val);
            return acc;
        }

        static StringBuilder ch(StringBuilder acc, List<string> val, int m)
        {
            if (acc.Length > 0)
            {
                acc.Append(" ");
            }
            acc.Append(val[1]);
            
            return acc;
        }

        //static void countSort_SLOW(List<List<string>> arr)
        //{
        //    int m = arr.Count() / 2;

        //    var r = arr.Select((e, i) => i < m ? new List<string> { e[0], "-" } : e);
        //    var s = (from a in r select int.Parse(a[0]) > 9 ? a : new List<string> { "0" + a[0], a[1] });
        //    var q = (from a in s orderby a[0] select a);

        //    string res = q.Aggregate(new StringBuilder(), (acc, val) => acc.Append(acc.Length > 0 ? " " + val[1] : val[1])).ToString();

        //    Console.WriteLine(res);
        //}

    }
}
