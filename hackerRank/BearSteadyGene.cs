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
            //string gene = "GAAATAAA";
            //int resExp = 5;

            string gene = "TGATGCCGTCCCCTCAACTTGAGTGCTCCTAATGCGTTGC";
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

        static int steadyGene(string gene)
        {
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

            for (int i = 0; i < gene.Length; i++)
            {
                mPos[gene[i]].Add(i);
            }

            Dictionary<char, int> gCut = new Dictionary<char, int>();
            gCut.Add('A', getValueCut(mTot, 'A'));
            gCut.Add('C', getValueCut(mTot, 'C'));
            gCut.Add('G', getValueCut(mTot, 'G'));
            gCut.Add('T', getValueCut(mTot, 'T'));

            int count = 0;
            int n1 = 0;
            int n2 = 0;
            int p1 = 0;
            int p2 = 0;
            int maxV = 0;
            char c1 = '_';
            char c2 = '_';
            int[] mp;
            List<int> mp1 = new List<int>();
            List<int> mp2 = new List<int>();
            foreach (KeyValuePair<char, int> e in gCut.Where(e => e.Value > 0))
            {
                count += 1;

                if (count == 1)
                {
                    mp1 = mPos[e.Key];
                    n1 = e.Value;
                    p1 = mp1[0];
                    c1 = e.Key;
                }
                else 
                {
                    mp2 = mPos[e.Key];
                    n2 = e.Value;
                    p2 = mp2[0];
                    c2 = e.Key;
                }

                if (e.Value > maxV)
                {
                    maxV = e.Value;
                }

            }

            if (count == 1 && maxV == 1)
            {
                return 1;
            }

            int nCut = n1 + n2;
            int dist = 0;
            int init = p1;
            mp = new int[mp1.Count()];
            mp1.CopyTo(mp);

            if (count > 1)
            {
                if (p2 < init)
                {
                    init = p2;

                    mp = new int[mp2.Count()];
                    mp2.CopyTo(mp);
                }
            }

            int k = 0;
            int posL = 0;
            int posR = 0;

            while (k < mp1.Count())
            {
                int start = mp1[k];
                int end = 0;
                int start2 = 0;
                int end2 = 0;

                if (k + n1 - 1 < mp1.Count())
                {
                    end = mp1[k + n1 - 1];
                }
                else
                {
                    break;
                }

                dist = end - start + 1;

                if (count > 1)
                {
                    string str = gene.Substring(start, dist);
                    int totn2Into = str.Where(e => e.Equals(c2)).Count();
                    if (totn2Into < n2)
                    {
                        int totn2Out = n2 - totn2Into;
                        int[] tL = mp2.Where(e => e < start).ToArray();
                        int[] tR = mp2.Where(e => e > end).ToArray();

                        int indL = tL.Length - 1;
                        int indR = 0;
                        if (tR.Length == 0)
                        {
                            indR = -1;
                        }
                        bool ok = false;
                        while ((indL >= 0 && indL < tL.Length) || (indR >= 0 && indR < tR.Length))
                        {
                            if (indL >= 0 && indL < tL.Length)
                            {
                                posL = tL[indL];
                            }
                            if (indR >= 0 && indR < tR.Length)
                            {
                                posR = tR[indR];
                            }
                            if (indL >= 0 && indR >= 0)
                            {

                            }
                            else if (indL >= 0 && indR < 0)
                            {

                            }
                            else if (indL < 0 && indR >= 0)
                            {

                            }

                            if (start - posL <= posR - end)
                            {

                                totn2Out -= 1;
                                indL -= 1;
                            }
                            else
                            {

                                indR += 1;
                            }
                        }

                        end2 = mp2[n2 - 1];
                        if (start2 < start)
                        {
                            start = start2;
                        }
                        if (end2 > end)
                        {
                            end = end2;
                        }
                    }

                }

                if (dist < min)
                {
                    min = dist;
                }

                k += 1;
            }

            if (count > 1)
            {
                k = 0;

                while (k < mp2.Count())
                {
                    int start = mp2[k];
                    int end = 0;
                    int start2 = 0;
                    int end2 = 0;

                    if (k + n2 - 1 < mp2.Count())
                    {
                        end = mp2[k + n2 - 1];
                    }
                    else
                    {
                        break;
                    }

                    start2 = mp1[0];
                    end2 = mp1[n1 - 1];

                    if (start2 < start)
                    {
                        start = start2;
                    }
                    if (end2 > end)
                    {
                        end = end2;
                    }

                    dist = end - start + 1;

                    if (dist < min)
                    {
                        min = dist;
                    }

                    k += 1;
                }
            }

            return min;
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

        //static Dictionary<char, int> upMTot(Dictionary<char, int> mTot, char e)
        //{
        //    foreach (KeyValuePair<char, int> el in mTot.Where(x => !x.Equals(e)))
        //    {
        //        if (mTot[el.Key] < ma)
        //        {
        //            mTot[el.Key] += 1;
        //            break;
        //        }
        //    }

        //    return mTot;
        //}

        //static Dictionary<char, int> removePlus(Dictionary<char, int> mTot, string s)
        //{
        //    Dictionary<char, int> mT = getDictCount(s);

        //    foreach (KeyValuePair<char,int> e in mT)
        //    {
        //        mTot[e.Key] -= e.Value;
        //    }

        //    return mTot;
        //}

        //static Dictionary<char, int> equalize(Dictionary<char, int> mTot, string s)
        //{
        //    int lim = s.Length;
        //    int di = 0;
        //    foreach (KeyValuePair<char, int> e in mTot)
        //    {
        //        if (e.Value < ma)
        //        {
        //            di = ma - e.Value;
        //            mTot[e.Key] += di;
        //            lim -= di;
        //        }
        //        if (lim <= 0)
        //        {
        //            break;
        //        }
        //    }

        //    return mTot;
        //}

        //static char getGeneOverflow(Dictionary<char, int> mTot, int geneMaxValue)
        //{
        //    char geneOverflow = mTot.Where(e => e.Value.Equals(geneMaxValue)).Select(x => x.Key).First();

        //    return geneOverflow;
        //}

    }
}
