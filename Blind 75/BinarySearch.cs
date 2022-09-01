using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blind_75
{
    public static  class BinarySearch
    {
        //1
		public static int Search(int[] nums, int target)
		{
			int l = 0;
			int r = nums.Length - 1;
            while (l <= r)
            {
				int mid = (l + r) / 2;
                if (nums[mid]==target) return mid;
                if (nums[mid] >= nums[l])
                {
                    if (target < nums[l] || target > nums[mid])
                    {
                        l = mid + 1;

                    }
                    else
                    {
                        r = mid - 1;
                    }
                }
                else
                {
                    if (target > nums[r] || target < nums[mid])
                    {
                        r = mid - 1;
                    }
                    else
                    {
                        l = mid + 1;
                    }
                }
            }
            return -1;
		}

        //2
        public static int FindMin(int[] nums)
        {
            int l = 0;
            int r = nums.Length - 1;
            int ans = nums[0];
            while (l <= r)
            {
                if (nums[l] <= nums[r])
                {
                    ans = Math.Min(ans, nums[l]);
                    break;
                }
                int mid = (l + r) / 2;
                ans = Math.Min(ans, nums[mid]);
                if (nums[mid] >= nums[l])  //if this condition true means left side element are sorted array of 3,4,5 or 6,7,8 
                {
                    l = mid + 1;
                }
                else                     //if this conditions true means we are in right side of roatted array so take
                                         //entire left side exclding mid as we already added mid in our ans 
                {
                    r = mid - 1;
                }
            }
            return ans;
        }

        //more optimized
        public static int OptFindMin(int[] nums)
        {
            var start = 0;
            var end = nums.Length - 1;
            while (start < end)
            {
                if (nums[start] < nums[end])
                {
                    return nums[start];
                }
                var mid = (start + end) / 2;

                if (nums[mid] >= nums[start])
                { // search window needs to go right of mid
                    start = mid + 1;
                }
                else
                {
                    end = mid;  //includes mid because mid can also be minmum at this point 
                }
            }
            return nums[start];
        }
    }
}
