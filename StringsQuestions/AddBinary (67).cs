using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsQuestions
{
	public static class AddBinary__67_
	{


		public static string BinarySumIt(string a, string b)
		{
			if (a.Length == 0 && b.Length == 0) return "0";
			int carry = 0;
			string sum = "";
			string first = "";
			string second = "";
			if (a.Length > b.Length)
			{
				first = a;
				second = b;
			}
			else
			{
				first = b;
				second = a;

			}
			int diff = first.Length - second.Length;
			for (var i = 0; i < diff; i++)
				second = "0" + second;

			for (var i = first.Length - 1; i >= 0; i--)
			{
				int current = carry + int.Parse(first[i].ToString()) + int.Parse(second[i].ToString());
				if (current == 2)
				{
					if (carry != 1) carry = 1;
					sum += "0";
					if (i == 0 && carry == 1) { sum += "1"; break; }
				}
				else if (current == 3)
				{
					if (carry != 1) carry = 1;
					sum += "1";
					if (i == 0 && carry == 1) { sum += "1"; break; }
				}
				else
				{
					carry = 0;
					sum += $"{current}";
				}

			}
			char[] num = sum.ToCharArray();
			Array.Reverse(num);
			return new string(num);


		}


		public static string OptimizedAddBinary(string a, string b)
		{
			int idx1 = a.Length - 1, idx2 = b.Length - 1;
			int val1 = 0, val2 = 0, carry = 0;
			var sb = new StringBuilder();
			while (idx1 >= 0 || idx2 >= 0)
			{
				val1 = idx1 < 0 ? 0 : a[idx1--] - '0';
				val2 = idx2 < 0 ? 0 : b[idx2--] - '0';

				int sum = val1 + val2 + carry;
				if (sum == 0 || sum == 2)
					sb.Insert(0, "0");
				else
					sb.Insert(0, "1");

				if (sum < 2)
					carry = 0;
				else
					carry = 1;
			}

			if (carry == 1)
				sb.Insert(0, "1");

			return sb.ToString();
		}
	}
}
