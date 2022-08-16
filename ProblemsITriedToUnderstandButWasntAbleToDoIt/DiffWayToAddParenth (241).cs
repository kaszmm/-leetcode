using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsQuestions
{
    public static class DiffWayToAddParenth__241_
    {
        public static IList<int> DiffWaysToCompute(string input)
        {

            //***** Method 2, using l and r pointers instead of string manipulation **//
            var dp = new Dictionary<string, List<int>>();
            return helper(input, dp, 0, input.Length - 1);
        }

        private static List<int> helper(string input, Dictionary<string, List<int>> dp, int l, int r)
        {
            var curInput = input.Substring(l, r - l + 1);
            if (dp.ContainsKey(curInput)) //memo
                return dp[curInput];

            var result = new List<int>();

            for (int i = l; i <= r; i++)
            {
                if (input[i] == '+' || input[i] == '*' || input[i] == '-')
                {
                    var leftResult = helper(input, dp, l, i - 1);
                    var rightResult = helper(input, dp, i + 1, r);

                    foreach (var left in leftResult)
                    {
                        foreach (var right in rightResult)
                        {
                            if (input[i] == '+')
                                result.Add(left + right);
                            else if (input[i] == '*')
                                result.Add(left * right);
                            else
                                result.Add(left - right);
                        }
                    }
                }
            }

            if (result.Count <= 0)
                result.Add(Convert.ToInt32(curInput));

            dp.Add(curInput, new List<int>(result)); //memo
            return result;
        }
    }
}
