using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greedy
{
    public static class AssignCookie__455_
    {
		public static int FindContentChildren(int[] g, int[] s)
		{
            if (s.Length == 0) return 0;

            Array.Sort(g);
            Array.Sort(s);

            int i = 0, j = 0, count = 0;

            while (i < g.Length && j < s.Length)
            {
                if (g[i] <= s[j])
                {
                    count++;
                    i++;
                }
                j++;
            }
            return count;

        }
	}
}
