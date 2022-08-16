using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathemathics
{
    public static class ClimbingStairs__70_
    {
        public static int ClimbStairs(int n)
        {
            if (n <= 3) return n;
            int[] dp = new int[n + 1];
            dp[0] = 1;
            dp[1] = 1;
            for (var i = 2; i<=n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            return dp[n];
        }
    }
   
}
