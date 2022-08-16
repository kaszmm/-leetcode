using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap__Priority_Queue_
{
    public static class SortCharactersByFrequency__451_
    {
		public static string FreqeuncySort(string s)
		{
			if (s.Length == 1) return s;
			Dictionary<char, int> dict = new Dictionary<char, int>();
			List<string> sortedChar = new List<string>();
			for (var i = 0; i < s.Length; i++)
			{
				if (!dict.ContainsKey(s[i])) dict.Add(s[i], 1);
				else dict[s[i]]++;
			}
			List<string>[] buckets= new List<string>[s.Length+1];
			foreach (var item in dict)
			{
				if (buckets[item.Value] == null) buckets[item.Value] = new List<string>();
				buckets[item.Value].Add(new string(item.Key, item.Value));
			}
			for (var i = s.Length; i > 0; i--)
			{
                if (buckets[i] != null)
                {
					foreach (var item in buckets[i])
					{
						sortedChar.Add(item);
					}
				}
				
			}
			return new string(string.Join("", sortedChar.ToArray()));
		}

		public static string OptimizedFrequencySort(string s)
        {
			var d = new Dictionary<char, int>();
			foreach (var c in s)
			{
				if (!d.ContainsKey(c))
				{
					d.Add(c, 0);
				}

				d[c]++;
			}

			var kvList = d.ToList();
			kvList.Sort((x, y) => y.Value - x.Value);

			var r = string.Empty;
			foreach (var (k, v) in kvList)
			{
				r += new string(k, v);
			}

			return r;
		}
	}
}
