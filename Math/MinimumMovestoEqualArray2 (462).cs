using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathemathics
{
    public static class MinimumMovestoEqualArray2__462_
    {
		public static int MinMoves2(int[] nums)
		{
            if (nums.Length == 1) return 0;
            int i = 0;
            int j = nums.Length - 1;
            Array.Sort(nums);
            int totDiff = 0;
            while (i < j)
            {
                totDiff += nums[j] - nums[i];
                i++;
                j--;
            }

            return totDiff;
        }
        public static int OptimizedMinMoves2(int[] nums)
        {
            var mid = QuickSelect(nums, 0, nums.Length - 1, nums.Length / 2);

            int ans = 0;
            for (int i = 0; i < nums.Length; i++)
                ans += Math.Abs(nums[i] - mid);

            return ans;
        }

        private static int QuickSelect(int[] nums, int left, int right, int target)
        {
            if (left == right)
                return nums[left];

            var pivot = Partition(nums, left, right);
            if (pivot == target)
                return nums[pivot];

            if (pivot < target)
                return QuickSelect(nums, pivot + 1, right, target);
            else
                return QuickSelect(nums, left, pivot - 1, target);
        }

        private static int Partition(int[] nums, int left, int right)
        {
            int loc = left;
            for (int i = left; i < right; i++)
            {
                if (nums[i] < nums[right])
                {
                    var temp = nums[loc];
                    nums[loc] = nums[i];
                    nums[i] = temp;
                    loc++;
                }
            }

            var temp1 = nums[loc];
            nums[loc] = nums[right];
            nums[right] = temp1;

            return loc;
        }
    }
}
