using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greedy
{
    public static class JumpGame__55_
    {
        public static bool CanJump(int[] nums)
        {
            int maxLocation = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (maxLocation < i) return false; // if previous maxLocation smaller than i, meaning we cannot reach location i, thus return false.
                maxLocation = Math.Max(i + nums[i], maxLocation); // greedy:
            }
            return true;
        }
    }
}
