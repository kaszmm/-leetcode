using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blind_75
{
    public static class TwoPointers
    {

		//1
		public static bool isPalindrome(string s)
		{
			s = s.ToLower().Trim();
			StringBuilder sb = new StringBuilder();
			foreach (var item in s)
			{
				if (char.IsLetterOrDigit(item))
				{
					sb.Append(item);
				}
			}
			s = sb.ToString();
			int start = 0;
			int end = s.Length - 1;
			while (start < end)
			{
				if (s[start] != s[end]) return false;
				start++;
				end--;
			}
			return true;

		}

		//2
		public static IList<IList<int>> ThreeSum(int[] nums)
		{
			IList<IList<int>> ans = new List<IList<int>>();
			int k = 0;
			Array.Sort(nums);
			while (k < nums.Length - 2)
			{
				if (k > 0 && nums[k] == nums[k - 1]) { k++; continue; } //this code avoid duplication for first elment
                int start = k + 1;
                int end = nums.Length - 1;
                var curElement = nums[k];
                while (start < end)
                {
					var threeSum = curElement + nums[start] + nums[end];
                    if (threeSum== 0)
                    {
                        ans.Add(new List<int>() { curElement, nums[start], nums[end] });
                        start++;
						while (nums[start] == nums[start - 1] && start<end) start++; //yhis code avoid duplications for second element also

                    }
                    else if (threeSum > 0)
                    {
                        end--;
                    }
                    else start++;
                }
                k++;

			}

			return ans;

		}

		//Extra not in Actual Blind75 list name: Two Sum II
		public static int[] TwoSumTwo(int[] numbers, int target)
		{
			int start = 0;
			int end = numbers.Length - 1;
			while (start < end)
			{
				if (numbers[start] + numbers[end] == target) return new int[] { start + 1, end + 1 };
				else if (numbers[start] + numbers[end] > target) end--;
				else start++;
			}

			return new int[] { };

		}


		//3
		public static int MaxArea(int[] height)
		{
			int maxArea = 0;
			int leftWall = 0;
			int rightWall = height.Length - 1;
			int curArea = 0;
			while (leftWall < rightWall)
			{
				curArea = (Math.Min(height[leftWall], height[rightWall]) * (rightWall - leftWall));
				maxArea = Math.Max(curArea, maxArea);
				if (height[leftWall] < height[rightWall]) leftWall++;
				else rightWall--;
			}
			return maxArea;

		}
	}
}
