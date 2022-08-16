using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsQuestions
{
    public static class RepeatedDna__187_
    {
		public static IList<string> FindRepeatedDna(string s)
		{
			if (s.Length < 11) return null;

			string newString = s.Substring(0, 10);
			int j = 1;
			IList<string> dna = new List<string>();
			int i = 1;
			while (i <= s.Length - 10)
			{
				var currentString = s.Substring(i, 10);
				if (newString == currentString)
				{
					if(!dna.Contains(newString))
					dna.Add(newString);
					newString = s.Substring(j, 10);
					i = j + 1;
					j++;
				}
				else if (i == s.Length - 10)
                {
					newString = s.Substring(j, 10);
					i = j + 1;
					j++;
				}
                else
                {
					i++;
				}
			}

			return dna;
		}

		public static IList<string> FindDna(string s)
        {
			if (s.Length < 11) return new List<string>();
			Dictionary<string, int> repeatedDna = new Dictionary<string, int>();
			IList<string> dna = new List<string>();
			int i = 0;
            while (i <= s.Length - 10)
            {
				string subS = s.Substring(i, 10);
				if (!repeatedDna.ContainsKey(subS)) repeatedDna.Add(subS, 1);
				else repeatedDna[subS]++;
				i++;
			}
			foreach(var item in repeatedDna)
            {
                if (repeatedDna[item.Key] > 1)
                {
					dna.Add(item.Key);
                }
            }
			return dna;
        }

		public static IList<string> OptimizedDnaSearch(string s)
        {
			if (s.Length < 11) return new List<string>();
			HashSet<string> seen = new HashSet<string>();
			HashSet<string> repeated = new HashSet<string>();
			for(var i = 0; i < s.Length - 9; i++)
            {
				var subS = s.Substring(i, 10);
				if (seen.Contains(subS)) repeated.Add(subS);
				else seen.Add(subS);
            }
			return repeated.ToList();
        }
	}
}
