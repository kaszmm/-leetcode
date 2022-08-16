using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap__Priority_Queue_
{
    public static class kth_largest_element_in_array__215_
    {
        public static int FindKthLargest(int[] nums, int k)
        {
            
            var rnd = new Random();
            int lower = 0, upper = nums.Length;
            while (true)
            {
                int i = lower;
                int pivot = rnd.Next(lower, upper);
                (nums[lower], nums[pivot]) = (nums[pivot], nums[lower]);
                for (int j = lower + 1; j < upper; j++)
                {
                    if (nums[j] >= nums[lower])
                    {
                        i++;
                        (nums[i], nums[j]) = (nums[j], nums[i]);
                    }
                }
                (nums[lower], nums[i]) = (nums[i], nums[lower]);
                if (i == k - 1) return nums[i];
                (lower, upper) = i > k - 1 ? (lower, i) : (i + 1, upper);
            }
        }
    }
}
