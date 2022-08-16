using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsQuestions
{
    public static class WordPattern__290_
    {
		public static bool IsPattern(string pattern, string s)
		{
			
			Dictionary<char, string> pDict = new Dictionary<char, string>();
			string[] words = s.Split(" ");
			if (pattern.Length == 1 && words.Count() == 1) return true;
		    if (pattern.Length != words.Count()) return false;
			for (var i = 0; i < pattern.Length; i++)
			{
				if (!pDict.ContainsKey(pattern[i]))
				{
					if (pDict.ContainsValue(words[i])) return false;
					pDict.Add(pattern[i], words[i]);
					
				}
				else if(pDict[pattern[i]] != words[i]) return false;

			}
			return true;

		}
	}
}
