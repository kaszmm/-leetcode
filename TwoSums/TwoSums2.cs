using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoSums
{
    public static  class TwoSums2
    {
		public static int[] ReturnNums(int[] numbers, int target)
		{
			if (numbers.Length == 0 || numbers.Length == 1)
            {
				numbers[0] = 1;
				return numbers;
            }
			List<int> listNums = numbers.ToList();
			int current = 0;
			int secondCurrent = 0;
			List<int> sumIndices = new List<int>();
			for (var i = 0; i <= listNums.Count; i++)
			{
				current = listNums[0];
				secondCurrent = Math.Abs(target - current);

				listNums.RemoveAt(0);
				if (listNums.Contains(secondCurrent))
				{
					listNums = numbers.ToList();
					sumIndices.Add(listNums.IndexOf(current)+1);
					listNums.Remove(current);
					sumIndices.Add(listNums.IndexOf(secondCurrent)+2);
                    if (sumIndices[0] < sumIndices[1])
                    {
						return sumIndices.ToArray();
					}
				}

			}
			return sumIndices.ToArray();





		}

		public static int[] OptimizedReturnNums(int[] nums, int target)
		{
			int start = 0;
			int end = nums.Length - 1;
			while (start < end)
			{
				if (nums[start] + nums[end] == target) break;
				if (nums[start] + nums[end] < target) { start++; }
				else { end--; }

			}
			return new int[] { start + 1, end + 1 };



		}

	}
}
