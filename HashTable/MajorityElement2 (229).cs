using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public static class MajorityElement2__229_
    {
		public static IList<int> MajorityElement(int[] nums)
		{
			if (nums.Length == 1) {

				var obj = new List<int>(nums[0]);
			};
			Dictionary<int, int> dict = new Dictionary<int, int>();
			IList<int> result = new List<int>();
			foreach (var item in nums)
			{
				if (!dict.ContainsKey(item)) dict.Add(item, 0);
				dict[item]++;
			}

			int target = Convert.ToInt32(Math.Floor((double)(nums.Length / 3)));
			foreach (var item in dict)
			{
				if (item.Value > target)
				{
					result.Add(item.Key);
				}

			}

			return result;

		}


		public static IList<int> OptimizedMajority(int[] nums)
        {
			int? candidate1 = null;
			int? candidate2 = null;
			int counter1 = 0;
			int counter2 = 0;
			IList<int> result = new List<int>();
			foreach (var item in nums)
            {
                if (item == candidate1)
                {
					counter1++;
                }
				else if (item == candidate2)
                {
					counter2++;
                }
				else if (counter1 == 0)
                {
					candidate1 = item;
					counter1 = 1;
                }
				else if (counter2 == 0)
                {
					candidate2 = item;
					counter2 = 1;
                }
                else
                {
					counter1--;
					counter2--;
                }
            }
			counter1 = counter2 = 0;
			foreach(var item in nums)
            {
				if (item == candidate1) counter1++;
				if (item == candidate2) counter2++;
            }
			if (counter1 > nums.Length / 3)  result.Add(candidate1??0);
			if (counter2 > nums.Length / 3)  result.Add(candidate2??0);
			return result;
		}

	}
}
