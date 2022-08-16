using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public static class LongestSubstringWithKRepeatingChar__395_
    {
        public static  int LongestSubstring(string s, int k)
        {
            return LongestSubstringHelper(s, k, 0, s.Length);
        }

        private static int LongestSubstringHelper(string s, int k, int start, int end)
        {
            if (end < k)
            {
                return 0;
            }
            var dict = new int[26];
            for (int i = start; i < end; i++)
            {
                dict[s[i] - 'a']++;
            }
            var index = start;
            while (index < end)
            {
                if (dict[s[index] - 'a'] >= k)
                {
                    index++;
                    continue;
                }
                else
                {
                    int next = index + 1;
                    while (next < end)
                    {
                        if (dict[s[next] - 'a'] < k)
                        {
                            next++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    var left = LongestSubstringHelper(s, k, start, index);
                    var right = LongestSubstringHelper(s, k, next, end);
                    return Math.Max(left, right);
                }
            }
            return end - start;
        }
        public static int longestSubstring(String s, int k)
        {
            if (s.Length < k) return 0;
            var charFreq = new int[26];
            for (int i = 0; i < s.Length; i++)
                charFreq[s[i] - 'a']++;
            var charToRemove = new List<char>();
            for (int i = 0; i < 26; i++)
                if (charFreq[i] > 0 && charFreq[i] < k)
                    charToRemove.Add((char)(i + 'a'));
            if (charToRemove.Count == 0)
                return s.Length;
            var strs = s.Split(charToRemove.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            int max = 0;
            foreach (string str in strs)
            {
                if (str.Length >= k)
                {
                    max = Math.Max(max, longestSubstring(str, k));
                }
            }
            return max;
        }
    }
}
