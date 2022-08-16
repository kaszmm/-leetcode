using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathemathics
{
    public  class XOfKindDeckCard__914_
    {
        private long GreatestCommonDivisor(long a, long b)
        {
            if (a == 0)
            {
                return b;
            }
            return GreatestCommonDivisor(b % a, a);
        }
        //private static ulong GCD(ulong a, ulong b)
        //{
        //    while (a != 0 && b != 0)
        //    {
        //        if (a > b)
        //            a %= b;
        //        else
        //            b %= a;
        //    }

        //    return a | b;
        //}
        public  bool HasGroupsSizeX(int[] deck)
        {
            Dictionary<int, int> val2Count = new Dictionary<int, int>();

            foreach (var card in deck)
            {
                if (!val2Count.ContainsKey(card))
                {
                    val2Count.Add(card, 0);
                }
                val2Count[card]++;
            }

            int min = val2Count.Min(p => p.Value);
            if (min < 2)
            {
                return false;
            }

            int gcd = min;

            foreach (var p in val2Count)
            {
                gcd = (int)GreatestCommonDivisor(gcd, p.Value);
            }

            return gcd > 1;
        }

    }
}
