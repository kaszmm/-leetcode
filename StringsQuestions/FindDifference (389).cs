using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsQuestions
{
    public static class FindDifference__389_
    {
		public static char GetAddedElement(string s, string t)
		{
            if (s.Length == 0)
            {
				return t[0];
            }
			IDictionary<char, int> sDict = new Dictionary<char, int>();
			IDictionary<char, int> tDict = new Dictionary<char, int>();
			for (var i = 0; i < s.Length; i++)
			{
				if (!sDict.ContainsKey(s[i])) sDict.Add(s[i], 0);
				sDict[s[i]]++;
			}
			for (var i = 0; i < t.Length; i++)
			{
				if (!tDict.ContainsKey(t[i])) tDict.Add(t[i], 0);
				tDict[t[i]]++;

			}

			foreach (var item in t)
			{
				if (!sDict.ContainsKey(item)) return item;
				if (tDict[item] != sDict[item]) return item;
			}
			return 'a';


			

		}
	}
}
