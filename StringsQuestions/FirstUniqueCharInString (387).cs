using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsQuestions
{
    public static class FirstUniqueCharInString__387_
    {
		public static int UnikChar(string s)
		{
			if (s.Length == 0) return -1;
			if (s.Length == 1) return 0;
			Dictionary<char, int> dict = new Dictionary<char, int>();
			foreach (var item in s)
			{
				if (!dict.ContainsKey(item)) dict.Add(item, 1);
				else dict[item]++;
			}
			for (var i = 0; i < s.Length; i++)
			{
				if (dict[s[i]] == 1) return i;
			}
			return -1;
		}
		public static int OptimizedFirstUniqChar(string s)
		{
			int[] charCount = new int[26];
			for (int i = 0; i < s.Length; i++)
			{
				charCount[s[i] - 'a']++;
			}
			for (int i = 0; i < s.Length; i++)
			{
				if (charCount[s[i] - 'a'] == 1) return i;
			}
			return -1;
		}
	}
}
