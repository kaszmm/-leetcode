using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greedy
{
    public static class HandOfStraights__846_
    {
        public static bool IsNStraightHand(int[] hand, int groupSize)
        {
            if (hand.Length < groupSize) return false;
            else if (hand.Length % groupSize != 0) return false;
            Array.Sort(hand);
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach(var item in hand)
            {
                if (!dict.ContainsKey(item)) dict.Add(item, 0);
                dict[item]++;
            }
            for(var i = 0; i < hand.Length; i++)
            {
                if (dict[hand[i]] > 0)
                {
                    int j =1;
                    while (j < groupSize)
                    {
                        if (!dict.ContainsKey(hand[i] + j)|| dict[hand[i] + j] <= 0 || dict[hand[i]] > dict[hand[i] + j]) return false;
                        dict[hand[i] + j] -= dict[hand[i]];
                        j++;
                    }
                    dict[hand[i]] = 0;
                }
            }
            return true;
        }
    }
}
