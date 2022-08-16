using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsQuestions
{
    public static class AlienDictionary__953_
    {
        public static bool IsAlienDictionary(string[] words,string order)
        {
            IDictionary<char, int> dict = new Dictionary<char, int>();
            for(var i = 0; i < order.Length; i++)
            {
                dict.Add(order[i], i);
            }

            
            for (var i = 0; i < words.Length-1; i++)
            {
                int j = 0;
                int k = 0;
                while (j != words[i].Length && k != words[i + 1].Length)
                {
                    if(dict[words[i][j]] > dict[words[i + 1][k]])
                    {
                        return false;
                    }
                    if (dict[words[i][j]] < dict[words[i + 1][k]])
                    {
                        break;
                    }
                    j++;
                    k++;
                }

                if (k == words[i + 1].Length && j < words[i].Length) return false;
            }
            return true;
        }
    }
}
