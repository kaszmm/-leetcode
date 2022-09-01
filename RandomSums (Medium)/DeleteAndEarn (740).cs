using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomSums__Medium_
{
    public static class DeleteAndEarn__740_
    {
		public static int DeleteAndEarn(int[] nums)
		{
            var d = new Dictionary<int, int>();
            foreach (var item in nums)
            {
                d[item] = d.GetValueOrDefault(item, 0) + item;
            }

            nums = nums.Distinct().OrderBy(x => x).ToArray();
            var dp = new int[nums.Length + 1];
            dp[0] = 0;
            dp[1] = d[nums[0]];
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == nums[i - 1]+1)
                {
                    dp[i + 1] = Math.Max(dp[i], dp[i - 1] + d[nums[i]]);
                }
                else
                {
                    dp[i + 1] = dp[i] + d[nums[i]];
                }
            }
            return dp.Last();
        }
	}
}
