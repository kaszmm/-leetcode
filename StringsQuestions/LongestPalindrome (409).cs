using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsQuestions
{
    public static class LongestPalindrome__409_
    {
		public static int FindLongestPalindrome(string s)
		{
            if (s.Length == 0) return 0;
            if (s.Length == 1) return 1;
			int[] countLetter = new int[58];
			for (var i = 0; i < s.Length; i++)
			{
				countLetter[s.ElementAt(i) - 'A']++;
			}

			int sum = 0;
			foreach(var c in countLetter)
			{
                if (c!=0)
                {
					int newSum = c / 2;
                    newSum *= 2;
                    sum += newSum;

					if (sum % 2 == 0 && c % 2 == 1) sum += 1;
                }
			}
			return sum;
		}
	}
}
