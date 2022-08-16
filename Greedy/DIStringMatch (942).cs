using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greedy
{
    public class DIStringMatch__942_
    {
        public static int[] DiStringMatch(string s)
        {
            int min = 0;
            int max = s.Length;
            int[] perms = new int[max+1];
            int i = 0;
            foreach(var item in s)
            {
                if (item == 'I')
                {
                    perms[i] = min;
                    min++;
                }
                else
                {
                    perms[i] = max;
                    max--;
                }
                i++;
            }
            perms[i] = min;
            return perms;
        }
    }
}
