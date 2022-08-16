using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathemathics
{
    public static class BreakInteger__343_
    {
        public static  int IntegerBreak(int n)
        {
            int[] dp = new int[n + 1];
            dp[1] = 1;
            for (int i = 1; i <= n; i++)
            {
                int max = 1;
                for (int j = 1; j < i; j++)
                {
                    int factor1 = Math.Max(j, dp[j]);
                    int factor2 = Math.Max(i - j, dp[i - j]);
                    max = Math.Max(max, factor1 * factor2);
                }
                dp[i] = max;
            }
            return dp[n];
        }
    }
}
