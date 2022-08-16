using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greedy
{
    public static class LargestPerimeterTraingle__976_
    {
		public static int LargestPerimeter(int[] nums)
		{
            Array.Sort(nums);
            for (int i = nums.Length - 1; i > 1; --i)
                if (nums[i] < nums[i - 1] + nums[i - 2])
                    return nums[i] + nums[i - 1] + nums[i - 2];
            return 0;
        }

	}
}

