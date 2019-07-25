﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerRank
{
    class Pairs
    {
        public void Execute()
        {
            int k = 663;
            int[] arr = { 756264, 302249, 796827, 823208, 867638, 242553, 521027, 53259, 744425, 610233, 551174, 959062, 272019, 502864, 870290, 716560, 974152, 977050, 565332, 243216, 811826, 24100, 619063, 883838, 21969, 361329, 702733, 440142, 293781, 291792, 604998, 858258, 549448, 759257, 964136, 285995, 394838, 709678, 362756, 830378, 715897, 400030, 5959, 899408, 292455, 868964, 904405, 143619, 522353, 720495, 935237, 244542, 52322, 507289, 41680, 15013, 208351, 516229, 583746, 910078, 985454, 536484, 356276, 982654, 811163, 235376, 210340, 906882, 902416, 106783, 711004, 569122, 552500, 721821, 96730, 976387, 721158, 28402, 281425, 108919, 398568, 526883, 52353, 399231, 792105, 15676, 192023, 42343, 715234, 173432, 869627, 41017, 54974, 194095, 792430, 526608, 827820, 22632, 19706, 583449, 411927, 901753, 209014, 52985, 358677, 109622, 812127, 551837, 609597, 942729, 986477, 827157, 386915, 497635, 526911, 743762, 566658, 395501, 412937, 949177, 500875, 194675, 903079, 892517, 884592, 53982, 27739, 983164, 396164, 34477, 438816, 693447, 866089, 443431, 23437, 829715, 197130, 21306, 16339, 745088, 810500, 669273, 760418, 973489, 348268, 225495, 458009, 476376, 193349, 961174, 121123, 934574, 875729, 5296, 68443, 49783, 353086, 868919, 992155, 95603, 702070, 828483, 243879, 484261, 462137, 787806, 134789, 332953, 228453, 442768, 796690, 829146, 987803, 979364, 520364, 53648, 626774, 795334, 231145, 826494, 7285, 285332, 933911, 903742, 975724, 565995, 397905, 341389, 442105, 108734, 110488, 834410, 821882, 396579, 360666, 132107, 199799, 359340, 335183, 700970, 179744, 501538, 29065, 704722, 438153, 553826, 831041, 477482, 566945, 617074, 170086, 441442, 618400, 975478, 324956, 387249, 192686, 963473, 525945, 348221, 710341, 779979, 393834, 172664, 717886, 723024, 617737, 399763, 933248, 788521, 439479, 719169, 976141, 501468, 704059, 22774, 829052, 319065, 130376, 209677, 461474, 91227, 962147, 822545, 17496, 987140, 553163, 297528, 54311 };
            int resExp = 87;

            int result = pairs(k, arr);

            if (resExp != result)
            {
                Console.WriteLine("Errore - Expected: " + resExp + " - now: " + result);
                Console.WriteLine("Errore!!!");
            }
            else
            {
                Console.WriteLine(result);
                Console.WriteLine("Perfetto!!!");
            }

        }

        static int pairs(int k, int[] arr)
        {
            int res = 0;
            int c1 = 0;
            int c2 = 0;

            Dictionary<int, int> d = arr.ToDictionary(p => p, p => p);

            for (int i = 0; i < arr.Length; i++)
            {
                c1 = arr[i];

                if (c1 - k >= 0)
                {
                    d.TryGetValue(c1 - k, out c2);
                    if (c2 > 0)
                    {
                        res += 1;
                    }
                }
            }

            return res;
        }

        static int pairs_SLOW(int k, int[] arr)
        {
            int res = 0;
            int c1 = 0;
            int c2 = 0;
            Array.Sort(arr);
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    c1 = arr[j];
                    c2 = arr[i];

                    if (c1 - c2 == k)
                    {
                        res += 1;
                    }
                }
            }

            return res;
        }
    }
}