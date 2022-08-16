using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greedy
{
    public static class ArrayPartition1__561_
    {
        public static int ArrayPairSum(int[] nums)
        {
            Array.Sort(nums);
            int sum = 0;
            for(var i = 0; i < nums.Length - 1; i=i+2)
            {
                sum += Math.Min(nums[i], nums[i + 1]);
            }
            return sum;
        }
    }
}
