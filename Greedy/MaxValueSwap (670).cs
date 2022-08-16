using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greedy
{
    public static class MaxValueSwap__670_
    {
        public static int MaximumSwap(int num)
        {
            int[] buckets = new int[10];
            char[] nums = num.ToString().ToCharArray();

            for (int i = 0; i < nums.Length; i++)
            {
                buckets[nums[i] - '0'] = i;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                int digit = nums[i] - '0';

                for (int j = 9; j > digit; j--)
                {
                    if (buckets[j] > i)
                    {
                        char temp = nums[i];
                        nums[i] = nums[buckets[j]];
                        nums[buckets[j]] = temp;
                        return Int32.Parse(new string(nums));
                    }
                }
            }

            return num;
        }

       

    }
}
