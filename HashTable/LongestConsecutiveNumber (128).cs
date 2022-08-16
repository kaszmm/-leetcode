using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public static class LongestConsecutiveNumber__128_
    {
		public static int LongestConsecutiveNumber(int[] nums)
		{


			int counter = 1;
			int diff = 0;
			int max = int.MinValue;

			SortedDictionary<int, int> sortDict = new SortedDictionary<int, int>();
			for(var i = 0; i < nums.Length; i++)
            {
				if (!sortDict.ContainsKey(nums[i])) sortDict.Add(nums[i], 1);
			}
			var keysList = sortDict.Select(x=>x.Key).ToArray();
			for (var i = 0; i < keysList.Length - 1; i++)
			{
				diff = keysList[i + 1] - keysList[i];
				if (Math.Abs(diff) == 1) counter++;
				else
				{
					counter = 1;
				}
				max = Math.Max(counter, max);
			}
			if (max == int.MinValue) return 1;
			return max;
		}
		public static int optimizedLOngestConsecutiveNumber(int[] nums)
        {
            int res = 0;
            Dictionary<int, int> map = new Dictionary<int, int>();
            foreach(var n in nums)
            {
                if (!map.ContainsKey(n))
                {
                    int left = (map.ContainsKey(n - 1)) ? map[n - 1] : 0;
                    int right = (map.ContainsKey(n + 1)) ? map[n + 1] : 0;
                    // sum: length of the sequence n is in
                    int sum = left + right + 1;
                    map[n]= sum;

                    // keep track of the max length 
                    res = Math.Max(res, sum);

                    // extend the length to the boundary(s)
                    // of the sequence
                    // will do nothing if n has no neighbors
                    map[n - left]=sum;
                    map[n + right]=sum;
                }
                else
                {
                    // duplicates
                    continue;
                }
            }
            return res;
        }
        private static int res = 1;
        private static Dictionary<int, int[]> dict = new Dictionary<int, int[]>();

        public static int LongestConsecutive(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            foreach (var num in nums)
                if (!dict.ContainsKey(num))
                    dict.Add(num, new int[] { num, 1 });

            foreach (var num in nums)
            {
                if (dict.ContainsKey(num - 1))
                    Union(num - 1, num);

                if (dict.ContainsKey(num + 1))
                    Union(num, num + 1);
            }

            return res;
        }

        private static void Union(int x, int y)
        {
            int px = Find(x),
                py = Find(y);

            if (px != py)
            {
                dict[px][0] = py;
                dict[py][1] += dict[px][1];

                res = Math.Max(res, dict[py][1]);
            }
        }

        private static int Find(int x)
        {
            if (x != dict[x][0])
                dict[x][0] = Find(dict[x][0]);

            return dict[x][0];
        }
    }
}
