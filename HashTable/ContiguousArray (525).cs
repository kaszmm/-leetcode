using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
	public static class ContiguousArray__525_
	{
		public static int FindMaxLength(int[] nums)
		{
			Dictionary<int, int> dict = new Dictionary<int, int>();
			int sum = 0;
			int max = 0;
			for (var i = 0; i < nums.Length; i++)
			{
				if (nums[i] == 1) sum++;
				else sum--;
				if (sum == 0) max = Math.Max(max, i + 1);
				else if (!dict.ContainsKey(sum))
				{
					dict.Add(sum, i);
				}
				else
				{
					max = Math.Max(max, i - dict[sum]);
				}


			}
			return max;

		}
		public static int findMaxLength(int[] nums)
		{
			// [diff of ones and zeros, min index]
			Dictionary<int, int> map = new Dictionary<int, int>();
			map[0] = -1;
			int zero = 0;
			int one = 0;
			int result = 0;
			for (int i = 0; i < nums.Length; i++)
			{
				if (nums[i] == 0)
					zero++;
				else
					one++;
				int diff = one - zero;
				// if we found the same diff again, it means there exists equal 1 and 0 between these two same diff index
				if (map.ContainsKey(diff))
					result = Math.Max(result, i - map[diff]);
				// if we found this diff first time, memorize it, and we never update it again
				else
					map[diff] = i;
			}
			return result;
		}
	}
}
