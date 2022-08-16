using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathemathics
{
    public static class  CheckIfNumIsSumOfPowOfThree__1780_
    {
        public static bool checkPowersOfThree(int n)
        {
            while (n > 0)
            {         // calculation finish once reach 0, reached 3^0
                if (n % 3 == 2)
                    return false;   // mod remainder 2 will not have distinct sum
                n /= 3;             // right shift ternary bits by 1 is divide by 3
            }
            return true;
        }
        public static bool CheckPowersOfThree(int n)
        {
           for(var i = 15; i >= 0; i--)
            {
                var sum = Math.Pow(3, i);
                if (sum <= n)
                {
                    n -= (int)sum;
                }
                if (n == 0)
                    return true;
            }
            return false;
        }
    }
}
