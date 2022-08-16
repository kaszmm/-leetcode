using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathemathics
{
    public static class PredictWinner__486_
    {
		public static bool PredictTheWinner(int[] nums)
		{
			if (nums.Length == 1) return true;
            int[][] dp = new int[nums.Length][];
            var sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                dp[i] = new int[nums.Length];
                sum += nums[i];
            }
            for (var k = 0; k < nums.Length; k++)
            {
                int i = 0;
                for(var j = k; j < nums.Length; j++)
                {
                    if (k == 0)
                    {
                        dp[i][j] = nums[i];
                    }
                    else if (k == 1)
                    {
                        dp[i][j] = Math.Max(nums[i],nums[j]);
                    }
                    else
                    {
                        var val1 = nums[i] + Math.Min(dp[i + 2][j], dp[i + 1][j - 1]);
                        var val2 = nums[j] + Math.Min(dp[i+1][j-1],dp[i][j-2]);
                        dp[i][j] = Math.Max(val1, val2);
                    }
                    i++;
                }
            }
            var p1 = dp[0][nums.Length - 1];
            var p2 = sum - dp[0][nums.Length - 1];
            return p1 >= p2;

        }
	}
}
