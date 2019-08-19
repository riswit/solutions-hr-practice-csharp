using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class BearSteadyGene
    {
        public void Execute()
        {
            string gene = "GAAATAAA";
            int resExp = 5;

            int result = steadyGene(gene);

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

        public static int ma;
        public static List<List<int>> tree;

        static int steadyGene(string gene)
        {
            int res = 0;
            ma = gene.Length / 4;

            Dictionary<char, int> mTot = getDictCount(gene);
            if (isSteady(mTot))
            {
                return 0;
            }

            Dictionary<char, List<int>> mPos = new Dictionary<char, List<int>>();
            mPos.Add('A', new List<int>());
            mPos.Add('C', new List<int>());
            mPos.Add('G', new List<int>());
            mPos.Add('T', new List<int>());

            Dictionary<int, int> mI = new Dictionary<int, int>();
            int iA = 0;
            int iC = 0;
            int iG = 0;
            int iT = 0;

            for (int i = 0; i < gene.Length; i++)
            {
                mPos[gene[i]].Add(i);
                switch (gene[i])
                {
                    case 'A':
                        mI.Add(i, iA);
                        iA++;
                        break;
                    case 'C':
                        mI.Add(i, iC);
                        iC++;
                        break;
                    case 'G':
                        mI.Add(i, iG);
                        iG++;
                        break;
                    case 'T':
                        mI.Add(i, iT);
                        iT++;
                        break;
                }
            }

            int geneMaxValue = mTot.Select(e => e.Value).Max();
            int diff = geneMaxValue - ma;
            char geneOverflow = getGeneOverflow(mTot, geneMaxValue);
            int d = 0;
            int p = 0;
            int a = 0;
            for (d = diff; d > 0; d--)
            {
                string c = new String(geneOverflow, d);
                p = gene.IndexOf(c);
                if (p > -1)
                {
                    if (d == diff && d > 1)
                    {
                        return d;
                    }
                    a = diff - d;
                    List<int> mp = mPos[geneOverflow];
                    int j = 0;
                    res = mp[mI[p + d - 1] + a] - p + 1;
                    string s = gene.Substring(p, res);

                    mTot = equalize(mTot, s);
                    if (isSteady(mTot))
                    {
                        return res;
                    }

                    //break;
                }
            }

            return res;
        }

        static Dictionary<char, int> equalize(Dictionary<char, int> mTot, string s)
        {
            Dictionary<char, int> mT = getDictCount(s);

            foreach (KeyValuePair<char,int> e in mT)
            {
                mTot[e.Key] -= e.Value;
            }

            int lim = s.Length;
            int di = 0;
            foreach (KeyValuePair<char, int> e in mTot)
            {
                if (mTot[e.Key] < ma)
                {
                    di = ma - mTot[e.Key];
                    mTot[e.Key] += di;
                    lim -= di;
                }
                if (lim <= 0)
                {
                    break;
                }
            }

            return mTot;
        }

        static char getGeneOverflow(Dictionary<char, int> mTot, int geneMaxValue)
        {
            char geneOverflow = mTot.Where(e => e.Value.Equals(geneMaxValue)).Select(x => x.Key).First();

            return geneOverflow;
        }

        static Dictionary<char, int> getDictCount(string str)
        {
            Dictionary<char, int> mTot = (from a in str.ToCharArray().GroupBy(x => x) select a).ToDictionary(
                                                                            p => p.Key,
                                                                            p => p.Count()
                                                                            );
            return mTot;
        }

        static bool isSteady(Dictionary<char, int> t)
        {
            if (t['A'] == ma && t['A'] == t['C'] && t['A'] == t['G'] && t['A'] == t['T'])
            {
                return true;
            }

            return false;
        }

    }
}
