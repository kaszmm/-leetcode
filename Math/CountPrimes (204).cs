using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathemathics
{
    public static class CountPrimes__204_
    {
        public static int CountPrimes(int n)
        {
            if (n <= 1) return 0;

            bool[] notPrime = new bool[n];
            notPrime[0] = true;
            notPrime[1] = true;
            int count = 0;
            for (int i = 2; i < Math.Sqrt(n); i++)
            {
                if (!notPrime[i])
                {
                    for (int j = 2; j * i < n; j++)
                    {
                        notPrime[i * j] = true;
                    }
                }
            }
            for (int i = 2; i < notPrime.Length; i++)
            {
                if (!notPrime[i]) count++;
            }
            return count;
        }
    }
}
