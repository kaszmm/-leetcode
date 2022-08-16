using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greedy
{
    public static class BuyAndSellStock2__122_
    {
        public static int BuyAndSellStock(int[] nums)
        {
            var maxProf = 0;
            for (var days = 0; days < nums.Length - 1; days++)
            {
                var curDiff = nums[days] - nums[days + 1];
                if (nums[days+1]>nums[days])
                {
                    maxProf += Math.Abs(curDiff);
                }
            }
            return maxProf;
        }
    }
}
