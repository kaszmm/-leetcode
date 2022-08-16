using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsQuestions
{
    public static class AddStrings__415_
    {
		public static string AddTwoString(string num1, string num2)
		{
			int carry = 0;
			StringBuilder sb = new StringBuilder();
			int idx1 = num1.Length-1;
			int idx2 = num2.Length-1;
			int val1 = 0;
			int val2 = 0;
			while (idx1 >= 0 || idx2 >= 0)
			{
				val1 = idx1 < 0 ? 0 : num1[idx1--] - '0';
				val2 = idx2 < 0 ? 0 : num2[idx2--] - '0';
				string sum = (val1 + val2 + carry).ToString();
				if (int.Parse(sum) > 9)
				{
					
					sb.Append($"{sum.Last()}");
					carry = 1;
				}
				else
				{
					sb.Append($"{sum}");
					carry = 0;
				}
				

			}
            if (carry == 1)
            {
				sb.Append(1);
            }
			return new string(sb.ToString().Reverse().ToArray());

		}

		public static string OptimizedAddStrings(string num1, string num2)
		{
			static int Get(string s, int index) => s.Length <= index ? 0 : s[s.Length - index - 1] - '0';

			var capacity = Math.Max(num1.Length, num2.Length);
			var sb = new StringBuilder(capacity + 1);

			int curry = 0;

			for (int i = 0; i < capacity; i++)
			{
				var value = Get(num1, i) + Get(num2, i) + curry;
				curry = value / 10;
				value %= 10;

				sb.Append(value);
			}

			if (curry != 0)
			{
				sb.Append(curry);
			}

			var s = sb.ToString();

			return string.Create(s.Length, s, (span, s1) =>
			{
				for (var i = 0; i < s1.Length; i++)
				{
					span[span.Length - i - 1] = s1[i];
				}
			});
		}

		public static string SecondOptimizedAddStrings(string num1, string num2)
		{
			int i = num1.Length - 1;
			int j = num2.Length - 1;
			int carry = 0;
			List<char> res = new List<char>();
			while (i >= 0 || j >= 0)
			{
				int a = i >= 0 ? num1[i] - '0' : 0;
				int b = j >= 0 ? num2[j] - '0' : 0;
				int sum = a + b + carry;
				carry = sum / 10;
				res.Add((char)((sum % 10) + '0'));
				i--;
				j--;
			}

			if (carry != 0)
			{
				res.Add((char)(carry + '0'));
			}

			res.Reverse();
			return string.Join("", res);
		}
	}
}
