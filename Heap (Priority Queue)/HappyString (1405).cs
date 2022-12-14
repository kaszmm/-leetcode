using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap__Priority_Queue_
{
    public static class HappyString__1405_
    {
		public static string LongestDiverseString(int a, int b, int c)
        {
                string s = "";
                int len = a + b + c;
                int anum = 0, bnum = 0, cnum = 0;
                while (s.Length < len)
                {
                    if (((a >= b && a >= c) || (bnum == 2 || cnum == 2)) && (anum < 2 && a > 0))
                    {
                        s += 'a';
                        anum++;
                        bnum = 0;
                        cnum = 0;
                        a--;
                    }
                    else if (((b >= c && b >= a) || (cnum == 2 || anum == 2)) && (bnum < 2 && b > 0))
                    {
                        s += 'b';
                        bnum++;
                        cnum = 0;
                        anum = 0;
                        b--;
                    }
                    else if (((c >= a && c >= a) || (anum == 2 || bnum == 2)) && (cnum < 2 && c > 0))
                    {
                        s += 'c';
                        cnum++;
                        anum = 0;
                        bnum = 0;
                        c--;
                    }
                    else
                        return s;
                }
                return s;
            
        }
	}
}
