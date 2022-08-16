using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicProgramming
{
    public static class DiffWayToAddParentheses__241_
    {
        static Dictionary<string, List<int>> map = new Dictionary<string, List<int>>();
        public static List<int> diffWaysToCompute(string input)
        {
            if (map.ContainsKey(input)) return map[input];

            List<int> ret = new List<int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '-' ||
                    input[i] == '*' ||
                    input[i] == '+')
                {
                    string part1 = input.Substring(0, i);
                    string part2 = input.Substring(i + 1);
                    List<int> part1Ret = diffWaysToCompute(part1);
                    List<int> part2Ret = diffWaysToCompute(part2);
                    foreach(int p1 in part1Ret)
                    {
                        foreach(int p2 in  part2Ret)
                        {
                            int c = 0;
                            switch (input[i])
                            {
                                case '+':
                                    c = p1 + p2;
                                    break;
                                case '-':
                                    c = p1 - p2;
                                    break;
                                case '*':
                                    c = p1 * p2;
                                    break;
                            }
                            ret.Add(c);
                        }
                    }
                }
            }
            if (ret.Count == 0)
            {
                ret.Add(int.Parse(input));
            }
            map.Add(input, ret);
            return ret;
        }
    }
}
