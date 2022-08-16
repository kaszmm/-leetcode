using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap__Priority_Queue_
{
    public static  class SplitArrayIntoSubsequence__659_
    {
        public static bool IsPossible(int[] nums)
        {
            Dictionary<int, int> freqmap = new Dictionary<int, int>();
            Dictionary<int, int> hypomap = new Dictionary<int, int>();
            //first find the frequency of each nums;
            //if the nums[i] is not in hypomap; create its new sequence if the consecutive number exists;
            //set the next number to be in hypomap; 1,2,3 => 4 will be in hypomap;
            //when we move to next number, check the hypomap first;
            //if it is not there, create a new sequence and insert the hypo num into hypo map;

            foreach (int i in nums)
            {
                if (!freqmap.ContainsKey(i))
                    freqmap.Add(i, 0);
                freqmap[i]++;
            }
            foreach (int num in nums)
            {
                if (freqmap[num] == 0) continue;
                if (HasKey(hypomap, num))
                {
                    hypomap[num]--;
                    freqmap[num]--;
                    if (hypomap.ContainsKey(num + 1))
                        hypomap[num + 1]++;
                    else
                        hypomap[num + 1] = 1;

                }
                else
                {    //need to create a new sequence of 3, if it is not possible return false;
                    if (HasKey(freqmap, num + 1) && HasKey(freqmap, num + 2))
                    {
                        freqmap[num + 1]--;
                        freqmap[num + 2]--;
                        freqmap[num]--;
                        if (hypomap.ContainsKey(num + 3))
                            hypomap[num + 3]++;
                        else
                            hypomap.Add(num + 3, 1);
                    }
                    else
                        return false;

                }
            }
            return true;
        }
        public static bool HasKey(Dictionary<int, int> map, int key)
        {
            if (map.ContainsKey(key) && map[key] > 0)
                return true;
            else
                return false;
        }
    }
}
