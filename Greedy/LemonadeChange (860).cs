using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greedy
{
    public static class LemonadeChange__860_
    {
		public static bool LemonadeChange(int[] bills)
		{
            int five = 0, ten = 0;
            foreach (int i in bills)
            {
                if (i == 5) five++;
                else if (i == 10) { five--; ten++; }
                else if (ten > 0) { ten--; five--; }
                else five -= 3;
                if (five < 0) return false;
            }
            return true;
        }
	}
}
