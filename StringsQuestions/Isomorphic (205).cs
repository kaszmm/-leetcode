using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsQuestions
{
    public static class Isomorphic__205_
    {
		public static bool IsIsomorphic(string s, string t)
		{
            
			if (s.Length == 1) return true;
			int[] first = new int[256];
			int[] second = new int[256];

			for (var i = 0; i < s.Length; i++)
			{
				if (first[s[i]] != second[t[i]]) return false;
				first[s[i]] = i + 1;
				second[t[i]] = i + 1;

			}
			return true;
		}
	}
}
