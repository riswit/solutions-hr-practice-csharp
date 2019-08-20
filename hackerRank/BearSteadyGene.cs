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
            int min = 1000000000;
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

            //int geneMaxValue = mTot.Select(e => e.Value).Max();
            //int diff = geneMaxValue - ma;
            //char g = getGeneOverflow(mTot, geneMaxValue);
            int d = 0;
            int p = 0;
            int init = 0;
            int fini = 0;
            string s = "";
            int c = 0;

            Dictionary<char, int> gCut = new Dictionary<char, int>();
            gCut.Add('A', getValueCut(mTot, 'A'));
            gCut.Add('C', getValueCut(mTot, 'C'));
            gCut.Add('G', getValueCut(mTot, 'G'));
            gCut.Add('T', getValueCut(mTot, 'T'));

            int sumCut = gCut.Select(e => e.Value).Sum();

            foreach (KeyValuePair<char, int> e in gCut.Where(e => e.Value > 0))
            {
                List<int> mp = mPos[e.Key];
                int i = 0;
                c = mp.Count();

                while (i + e.Value - 1 < c)
                {
                    
                    init = mp[i];
                    fini = mp[i + e.Value - 1]
                    d = mp[i];

                    i++;
                }

            }

            /*
            for (d = diff; d > 0; d--)
            {
                string c = new String(g, d);
                p = gene.IndexOf(c);
                if (p > -1)
                {
                    if (d == diff && d > 1)
                    {
                        return d;
                    }
                    ap = diff - d;
                    List<int> mp = mPos[g];
                    int j = 0;
                                        
                    //s = gene.Substring(p, res);

                    for (int i = mI[p]; i < mp.Count(); i++)
                    {

                    }
                    for (int i = mI[p] - 1; i >= 0; i--)
                    {

                    }

                    mTot = equalize(mTot, s);
                    if (isSteady(mTot))
                    {
                        return res;
                    }

                    //break;
                }
            }
            */
            return res;
        }

        static Dictionary<char, int> removePlus(Dictionary<char, int> mTot, string s)
        {
            Dictionary<char, int> mT = getDictCount(s);

            foreach (KeyValuePair<char,int> e in mT)
            {
                mTot[e.Key] -= e.Value;
            }

            return mTot;
        }

        static Dictionary<char, int> equalize(Dictionary<char, int> mTot, string s)
        {
            int lim = s.Length;
            int di = 0;
            foreach (KeyValuePair<char, int> e in mTot)
            {
                if (e.Value < ma)
                {
                    di = ma - e.Value;
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
            Dictionary<char, int> t = (from a in str.ToCharArray().GroupBy(x => x) select a).ToDictionary(
                                                                            p => p.Key,
                                                                            p => p.Count()
                                                                            );

            Dictionary<char, int> mTot = new Dictionary<char, int>();
            mTot.Add('A', getValueMap(t, 'A'));
            mTot.Add('C', getValueMap(t, 'C'));
            mTot.Add('G', getValueMap(t, 'G'));
            mTot.Add('T', getValueMap(t, 'T'));

            return mTot;
        }

        static int getValueMap(Dictionary<char, int> t, char e)
        {
            int v = 0;
            t.TryGetValue(e, out v);
            return v;
        }

        static int getValueCut(Dictionary<char, int> t, char e)
        {
            int v = 0;
            t.TryGetValue(e, out v);
            int r = v - ma;
            if (r < 0)
            {
                return 0;
            }
            return r;
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
