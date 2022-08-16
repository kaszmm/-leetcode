using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsQuestions
{
    public static class Anagram__242_
    {
		public static bool IsAnagram(string s, string t)
		{
			if (s.Length != t.Length) return false;
            if (s.Length == 1)
            {
				return s[0] == t[0];
            }
			Dictionary<char, int> letters = new Dictionary<char, int>();

			for (var i = 0; i < s.Length; i++)
			{
				if (!letters.ContainsKey(s[i]))
				{
					letters.Add(s[i], 0);
				}
				letters[s[i]]++;
			}

			foreach (var item in t)
			{
				if (!letters.ContainsKey(item)) return false;
				letters[item]--;
			}
			foreach(var item in s)
            {
				if (letters[item] > 0) return false;
            }
			//if (!letters.ContainsValue(0)) return false;

			return true;





		}
	}
}
