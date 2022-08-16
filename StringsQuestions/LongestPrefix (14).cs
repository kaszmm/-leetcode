using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsQuestions
{
    public static class LongestPrefix__14_
    {
		public static string LongestPrefix(string[] strs)
		{
			if (strs[0].Length == 0) return "";
			Queue<char> firstPrefix = new Queue<char>();
			//fill queue with first word
			foreach (var item in strs[0])
			{
				firstPrefix.Enqueue(item);
			}

			for (var i = 1; i < strs.Length; i++)
			{
				Queue<char> newestPrefix = new Queue<char>();
				foreach (var item in strs[i])
				{
					if (item.ToString().Length == 0) return "";
					if (firstPrefix.Count != 0 && item == firstPrefix.Peek())
					{
						//matched words get entered in newestPrefix and words also get removed from firstPrefix
						newestPrefix.Enqueue(item);
						firstPrefix.Dequeue();

					}
					else  break;
				}
				//if newest queue is null means the word doesnt match at all so retunr null
				if (newestPrefix.Count == 0) return "";
			
				firstPrefix.Clear();
				firstPrefix = newestPrefix;
			}
			string prefix = "";
			foreach(var item in firstPrefix.ToList())
            {
				prefix += item;
            }
			return prefix;

		}
		public static string LongestCommonPrefix(string[] strs)
		{

			if (strs.Length == 0)
			{
				return "";
			}
			string prefix = strs[0];
			for (int i = 1; i < strs.Length; i++)
				while (strs[i].IndexOf(prefix) != 0)
				{

                    Console.WriteLine($"{strs[i].IndexOf(prefix)}, i:{i},prefix:{prefix}");
					prefix = prefix.Substring(0, prefix.Length - 1);
					if (string.IsNullOrEmpty(prefix)) return "";
				}
			return prefix;
		}
	}
}
