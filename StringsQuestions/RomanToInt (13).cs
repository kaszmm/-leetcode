using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsQuestions
{
    public static class RomanToInt__13_
    {
		public static int RomanToInt(string s)
		{
			int first = 0;
			int second = 0;
			int total = 0;
			for (var i = 0; i <s.Length; i++)
			{
                if (i == s.Length - 1)
                {
					total += FetchNumber(s[i]);
					return total;
                }
				first = FetchNumber(s[i]);
				second = FetchNumber(s[i + 1]);

                if (second == first)
                {
					total += first + second;
					i++;
                }
				else if (second < first)
				{
					total += first;
				}
				else
				{
					if (second / 5 == first || second / 10 == first)
					{
						total += second - first;
						i++;
					}
				}



			}
			return total;


		}

		public static int FetchNumber(char s)
		{
			switch(s){
				case 'I':
					return 1; 
				case 'V':
					return 5;
				case 'X':
					return 10;
				case 'L':
					return 50; 
				case 'C':
					return 100; 
				case 'D':
					return 500; 
				case 'M':
					return 1000;

				default: return 0;

			}

		}


		public static int OptimizedRomanToInt(string s)
		{
			Dictionary<char, int> dic = new Dictionary<char, int> { { 'I', 1 }, { 'V', 5 }, { 'X', 10 }, { 'L', 50 }, { 'C', 100 }, { 'D', 500 }, { 'M', 1000 } };

			int result = 0;

			for (int i = 0; i < s.Length; i++)
			{
				int val = dic[s[i]];
				if (i == s.Length - 1 || dic[s[i]] >= dic[s[i + 1]])
				{
					result += val;
				}
				else
				{
					result -= val;
				}
			}
			return result;
		}
	}
}
