using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public static class FindAllAnagramInString__438_
    {
		public static IList<int> FindAnagram(string s, string p)
		{
			if (s.Length < p.Length) return new List<int>();
			int[] sHash = new int[26];
			int[] pHash = new int[26];
			List<int> indexes = new List<int>();
			int left = 0;
			int right = 0;
            while (right < p.Length)
            {
				pHash[p[right] - 'a']++;
				sHash[s[right] - 'a']++;
				right++;
			}
			right--;
            while (right < s.Length)
            {
                if (sHash.SequenceEqual(pHash))
                {
					indexes.Add(left);
                }
				
				right++;
				if(right!=s.Length) sHash[s[right] - 'a']++;
				sHash[s[left] - 'a']--;
				left++;
            }
			return indexes;
		}
		public static IList<int> findAnagrams(string s, string p)
		{
			IList<int> result = new List<int>();

			int[] chars = new int[26];
			if (s == null || p == null || s.Length < p.Length)
				return result;

			foreach (char c in p)
				chars[c - 'a']++;

			int start = 0, end = 0, count = p.Length;
			// Go over the string
			while (end < s.Length)
			{
				// If the char at start appeared in p, we increase count
				if (end - start == p.Length && chars[s[start++] - 'a']++ >= 0)
					count++;
				// If the char at end appeared in p (since it's not -1 after decreasing), we decrease count
				if (--chars[s[end++] - 'a'] >= 0)
					count--;
				if (count == 0)
					result.Add(start);
			}

			return result;
		}

	}
}
