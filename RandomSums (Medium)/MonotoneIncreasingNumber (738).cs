using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomSums__Medium_
{
    public static class MonotoneIncreasingNumber__738_
    {
		public static int MonoIncDigits(int n)
		{
            char[] arrN = n.ToString().ToCharArray();

            int monotoneIncreasingEnd = arrN.Length - 1;
            for (int i = arrN.Length - 1; i > 0; i--)
            {
                if (arrN[i] < arrN[i - 1])
                {
                    monotoneIncreasingEnd = i - 1;
                    arrN[i - 1]--;
                }
            }
            for (int i = monotoneIncreasingEnd + 1; i < arrN.Length; i++)
            {
                arrN[i] = '9';
            }
            return int.Parse(new String(arrN));


        }
	}
}
