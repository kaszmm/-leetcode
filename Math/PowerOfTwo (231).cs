using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathemathics
{
    public static class PowerOfTwo__231_
    {
        public static  bool IsPowerOfTwo(int n)
        {
            if (n <= 2) return true;

            var val = Math.Log2(n);
            return Math.Floor(val) == Math.Ceiling(val);

        }
    }
}
