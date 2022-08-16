using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap__Priority_Queue_
{
    public static class NthSuperUglyNumber__313_
    {
        public static int NthSuperUglyNumber(int n, int[] primes)
        {
            var result = new int[n];

            result[0] = 1;
            var primeIndexs = new int[primes.Length];

            for (int i = 1; i < n; i++)
            {

                var tempResult = new int[primes.Length];
                for (int j = 0; j < primeIndexs.Length; j++)
                {
                    var primeIndex = primeIndexs[j];
                    tempResult[j] = result[primeIndex] * primes[j];
                }

                var min = tempResult.Min();

                for (int j = 0; j < tempResult.Length; j++)
                {
                    if (tempResult[j] == min)
                    {
                        primeIndexs[j]++;
                    }
                }

                result[i] = min;
            }

            return result[n - 1];

        }
        public static int nthSuperUglyNumber(int n, int[] primes)
        {
            if (n == 1) return n;
            int[] uglyNums = new int[n];
            int[] primeIndexPairWithUglyNums = new int[primes.Length];
            uglyNums[0] = 1;
            for (var i = 1; i < n; i++)
            {
                var tempUglyNums = new int[primes.Length];
                for (var j = 0; j < primes.Length; j++)
                {
                    int primeIndex = primeIndexPairWithUglyNums[j];
                    tempUglyNums[j] = uglyNums[primeIndex] * primes[j];

                }
                var min = tempUglyNums.Min();

                for (var j = 0; j < tempUglyNums.Length; j++)
                {
                    if (min == tempUglyNums[j]) primeIndexPairWithUglyNums[j]++;

                }
                uglyNums[i] = min;
            }
            return uglyNums[n - 1];
        }
        public static int OptimizedNthSuperUglyNumber(int n, int[] primes)
        {
            int[] ugly = new int[n];
            int[] idx = new int[primes.Length];
            int[] val = new int[primes.Length];
            for (int i = 0; i < primes.Length; i++) val[i] = 1;

            int next = 1;
            for (int i = 0; i < n; i++)
            {
                ugly[i] = next;
                next = int.MaxValue;
                for (int j = 0; j < primes.Length; j++)
                {
                    //skip duplicate and avoid extra multiplication
                    if (val[j] == ugly[i]) val[j] = ugly[idx[j]++] * primes[j];
                    //find next ugly number
                    next = Math.Min(next, val[j]);
                }
            }
            return ugly[n - 1];
        }
        public static int OptimizednthSuperUglyNumber(int n, int[] primes)
        {
            if (n == 1) return n;
            int[] uglyNums = new int[n];
            int[] primeIndex = new int[primes.Length];
            int[] val = new int[primes.Length];
            int next = 1;
            for (var i = 0; i < val.Length; i++) val[i] = 1;
            for (var i = 0; i < n; i++)
            {
                uglyNums[i] = next;
                next = Int32.MaxValue;
                for (var j = 0; j < primes.Length; j++)
                {
                    if (val[j] == uglyNums[i])
                    {
                        val[j] = uglyNums[primeIndex[j]] * primes[j];
                        primeIndex[j]++;
                    }
                    next = Math.Min(next, val[j]);
                }

            }


            return uglyNums[n - 1];


}
    }
}
