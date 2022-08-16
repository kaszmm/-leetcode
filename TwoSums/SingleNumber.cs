using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoSums
{
	

	public static class SingleNumber
	{
		public static int ReturnUnique(int[] nums)
		{
			int current = 0;
			if (nums.Length == 1) { return nums[0]; }
			if (nums.Length == 0) return 0;
			List<int> listConvert = nums.ToList();
			for (var i = 0; i < nums.Length; i++)
			{
				if (listConvert.Count == 1) return listConvert.First();
				current = listConvert[0];
				listConvert.RemoveAt(0);
				if (!listConvert.Contains(current))
				{
					return current;
				}
                else
                {
					listConvert = listConvert.Where(x => x != current).ToList();
                }
			}
			return 0;

		}


		public static int OptimizedUnique(int[] nums)
        {
			int result = 0;
			for(var i = 0; i != nums.Length; i++)
            {
				result ^= nums[i];
            }
			return result;
        }



	}
}
