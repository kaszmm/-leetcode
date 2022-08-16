using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsQuestions
{
    public static class NumberOfBalloons__1189_
    {
		public static int MaxNumOfBallons(string text)
		{
            var dic = new Dictionary<char, int>()
            {
                {'b', 1 },
                {'a', 1 },
                {'l' , 2},
                {'o', 2 },
                {'n', 1 }
            };

            var dic2 = new Dictionary<char, int>();
            foreach (var ch in text)
            {
                if (dic2.ContainsKey(ch))
                    dic2[ch]++;
                else dic2.Add(ch, 1);
            }

            int count = int.MaxValue;
            foreach (var keyVal in dic)
            {
                if (!dic2.ContainsKey(keyVal.Key))
                    return 0;

                count = Math.Min(count, dic2[keyVal.Key] / keyVal.Value);
            }

            return count;

        }

        public static int OptimizedNumOfBalloon(string text)
        {
            var dic = new Dictionary<char, int>()
            {
                {'b', 0 },
                {'a', 0 },
                {'l' , 0},
                {'o', 0 },
                {'n', 0 }
            };
            foreach(var i in text)
            {
                if (i == 'a' || i == 'b' || i == 'l' || i == 'n' || i == 'o')
                {
                    dic[i]++;
                }
            }
            dic['o'] = dic['o'] / 2;
            dic['l'] = dic['l'] / 2;

            return dic.Values.ToList().Min();
        }
	}
}
