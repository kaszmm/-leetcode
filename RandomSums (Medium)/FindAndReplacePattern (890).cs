using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomSums__Medium_
{
    public  static class FindAndReplacePattern__890_
    {
		public static IList<string> FindAndReplacePattern(string[] words, string pattern)
		{
			IList<string> ans = new List<string>();

            foreach(String word in words)
            {
                bool match = isAMatch(pattern, word);
                if (match) ans.Add(word);
            }

            return ans;

        }
        public static bool isAMatch(String pattern, String word)
        {
            if (pattern.Count() != word.Count()) return false;

            char[] patternToWOrd = new char[26];
            char[] wordToPattern = new char[26];


            for (int i = 0; i < word.Count(); i++)
            {
                char ch1 = pattern.ElementAt(i);
                char ch2 = word.ElementAt(i);

                if (patternToWOrd[ch1 - 'a'] != 0)
                {
                    if (patternToWOrd[ch1 - 'a'] != ch2) return false;
                }
                else patternToWOrd[ch1 - 'a'] = ch2;

                if (wordToPattern[ch2 - 'a'] != 0)
                {
                    if (wordToPattern[ch2 - 'a'] != ch1) return false;
                }
                else wordToPattern[ch2 - 'a'] = ch1;

            }

            return true;
        }
    }
}
