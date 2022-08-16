using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public static class WordBreak__139_
    {
        public static bool WordBreak(string s, IList<string> wordDict)
        {

            //dp[i] indicates whehter substring of length i can be segmented.
            bool[] dp = new bool[s.Length + 1];
            //assume empty string is always in the wordDict
            dp[0] = true;

            // HashSet<T>.Contains(T) is O(1) operation. It's better than List<T>.Contains<T) which is O(n) operation
            HashSet<string> set = new HashSet<string>(wordDict);

            // check substring from length 1 to s.Length 
            // i and j represent the length of substrings
            for (int i = 1; i < dp.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (dp[j] && set.Contains(s.Substring(j, i - j)))
                    {
                        dp[i] = true;
                        break;
                    }
                }
            }

            return dp[s.Length];
        }
    }
}
