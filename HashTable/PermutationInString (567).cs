using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public static class PermutationInString__567_
    {
		public static bool CheckInclusion(string s1, string s2)
		{
			if (s1.Length > s2.Length) return false;

            int[] freqS1 = new int[26];
            foreach(char c in s1) freqS1[c - 'a']++;

            int[] freqS2 = new int[26];
            int i = 0, j = 0;

            while (j < s2.Length)
            {
                freqS2[s2[j] - 'a']++;

                if (j - i + 1 == s1.Length)
                {
                    if (freqS1.SequenceEqual(freqS2)) return true;
                }

                if (j - i + 1 < s1.Length) j++;
                else
                {
                    freqS2[s2[i] - 'a']--;
                    i++;
                    j++;
                }
            }
            return false;
        }
	}
}
