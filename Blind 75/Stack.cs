using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blind_75
{
    public static  class Stack
    {
		public static bool IsValid(string s)
		{
			Stack<char> stack = new Stack<char>();
			for (var i = 0; i < s.Length; i++)
			{
				var isTopElementAvailable = stack.TryPeek(out char k);
				if (( isTopElementAvailable && k=='('&& s[i] == ')') ||
				   (isTopElementAvailable && k == '{' && s[i] == '}') ||
				   (isTopElementAvailable && k == '[' && s[i] == ']'))
				{
					stack.Pop();
				}
				else
				{
					stack.Push(s[i]);
				}
			}
			return stack.Count == 0;

		}

		public static int GarbageCollection(string[] garbage, int[] travel)
		{
			Dictionary<char, int[]> dict = new Dictionary<char, int[]>();
			dict.Add('M', new int[travel.Length + 1]);
			dict.Add('P', new int[travel.Length + 1]);
			dict.Add('G', new int[travel.Length + 1]);
			for (var i = 0; i < garbage.Length; i++)
			{

				foreach (var item in garbage[i])
				{
					dict[item][i]++;
				}
			}

			var totTime = 0;
			foreach (var item in dict)
			{
				totTime += dict[item.Key][0];
				for (var i = 1; i < dict[item.Key].Length; i++)
				{
					if (dict[item.Key][i] > 0)
					{
						totTime += travel[i - 1];
						totTime += dict[item.Key][i];
					}

				}

			}


			return totTime;
		}


		public static int LongestNiceSubarray(int[] nums)
		{
			if (nums.Length == 1) return 1;
			int maxLength = 1;
			int i = 0;
			int j = 1;
			while (j < nums.Length)
			{
                while ((nums[i] & nums[j]) == 0)
                {
					j++;
				}
				int tempI = i+1;
				int[] possibleRes = new int[j-i];

				while (tempI<j-1)
                {
					if ((nums[tempI] & nums[j-1]) == 0)
					{
					}
                    else
                    {
						possibleRes[(j-1) - tempI] = -1;
                    }
					tempI++;
				}
				for (var k = 1; k < possibleRes.Length; k++)
                {
					if (possibleRes[k] == 0)
					{
						maxLength = Math.Max(maxLength, k+1);
					}
					else break;
				}
				i = j;
				j++;
			}
			return maxLength;
		}
	}
}
