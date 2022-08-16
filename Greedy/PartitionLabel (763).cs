using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greedy
{
    public static class PartitionLabel__763_
    {
        public static IList<int> PartitionLabels(string s)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            for(var i=0;i<s.Length;i++)
            {
                if (!dict.ContainsKey(s[i])) dict.Add(s[i], 0);
                dict[s[i]] = i;
            }
            IList<int> parts = new List<int>();
            int size = 0;
            int end = 0;
            for(var i=0;i<s.Length;i++)
            {
                size++;
                end = Math.Max(end, dict[s[i]]);
                
                if (i == end)
                {
                    parts.Add(size);
                    size = 0;
                }
            }
            return parts;

        }
    }
}
