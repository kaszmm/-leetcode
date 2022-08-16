using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoSums
{
    public class SubArrayMaxSum
    {
        public int MaxSubArray(int[] nums)
        {
            int currentMax = 0;
            int maxTillNow = Int32.MinValue;
            foreach(var item in nums)
            {
                currentMax = Math.Max(item, currentMax + item);
                maxTillNow = Math.Max(maxTillNow, currentMax);
            }
            return maxTillNow;
        }
    }

}
