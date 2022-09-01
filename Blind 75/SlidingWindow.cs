using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blind_75
{
    public static class SlidingWindow
    {
		//1
		public static int MaxProfit(int[] prices)
		{
			if (prices.Length == 1) return 0;
			int i = 0;
			int j = 1;
			int totMax = 0;
			while (j < prices.Length)
			{
				if (prices[i] < prices[j])
				{
					totMax = Math.Max(totMax, prices[j] - prices[i]);
				}
				else
				{
					i = j;
				}
				j++;
			}
			return totMax;
		}

		//2
		public static int LengthOfLongestSubstring(string s)
		{
            if (s == null || s == String.Empty)
                return 0;

            HashSet<char> set = new HashSet<char>();
            int currentMax = 0,
                i = 0,
                j = 0;

            while (j < s.Length)
                if (!set.Contains(s[j]))
                {
                    set.Add(s[j]);
					j++;
                    currentMax = Math.Max(currentMax, j - i);
                }
                else
                {
					set.Remove(s[i]);
					i++;
				}
            return currentMax;
        }

		//3
		public static int CharacterReplacement(string s, int k)
		{
            int left = 0;
            int right = 0;
			int result = 0;
			Dictionary<char, int> numCount = new Dictionary<char, int>();
			int maxFreq = 0;
			while(right<s.Length)
            {
                if (!numCount.ContainsKey(s[right])) numCount.Add(s[right], 0);
				numCount[s[right]]++;
				maxFreq = Math.Max(maxFreq, numCount[s[right]]);  //max freq count of string can be found with this (this one is faster)
				//var max = numCount.Values.Max();                 // <- and also with this    (this one is slower)
                while ((right - left + 1) - maxFreq > k)
                {
					numCount[s[left]]--;
					left++;
                }
				result = Math.Max(result, right - left + 1);
				right++;
            }
			return result;
		}

		//4
		public static string MinWindow(string s, string t)
		{
			if (t.Length > s.Length || t =="") return "";
			Dictionary<char, int> sDict = new Dictionary<char, int>();
			Dictionary<char, int> tDict = new Dictionary<char, int>();
			int l = 0;
			int r = 0;
			int resultLen = int.MaxValue;
			Tuple<int, int> range = new Tuple<int, int>(-1,-1);
			int have = 0;
			foreach(var item in t)
            {
				if (!tDict.ContainsKey(item)) tDict.Add(item, 0);
				tDict[item]++;
            }
			int need = tDict.Count();
            while (r < s.Length)
            {
				if (!sDict.ContainsKey(s[r])) sDict.Add(s[r], 0);
				sDict[s[r]]++;

                if (tDict.ContainsKey(s[r]) && sDict[s[r]] == tDict[s[r]])
                {
					have++;
                }
                while (have == need)
                {
                    if (r - l + 1 < resultLen)
                    {
						range = new Tuple<int, int>(l, r);
						resultLen = r - l + 1;
                    }
						sDict[s[l]]--;
					if (tDict.ContainsKey(s[l]) && sDict[s[l]] < tDict[s[l]]) have--;
					l++;
                }
				r++;
            }
			var resultString = resultLen != int.MaxValue ? s.Substring(range.Item1, range.Item2-range.Item1+1) : "";
 			return resultString;
		}
	}
}
