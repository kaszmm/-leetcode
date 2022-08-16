using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathemathics
{
    public static  class PerfectSquares__279_
    {
		public static int NumSquares(int n)
		{
			int[] dp = new int[n + 1];
			Array.Fill(dp, int.MaxValue);
			dp[0] = 0;
			for (int i = 1; i <= n; ++i)
			{
				int min = int.MaxValue;
				int j = 1;
				while (i - j * j >= 0)
				{
					min = Math.Min(min, dp[i - j * j] + 1);
					++j;
				}
				dp[i] = min;
			}
			return dp[n];
		}

		public static int OptimizedNumSqures(int n)
        {
			if(n<=3) return 3;
			//to check if num is already perfect squre than do its squareRoot and divide it by 1 if  it is zero it means its is perfect square so return 1
			if (Math.Sqrt(n) % 1 == 0)
			{
				return 1;
			}
			while (n % 4 == 0) //remove term 4^a(8a+b) so here we are trying to rrmoev 4^a term
            {
				n /= 4;
            }
			if (n % 8 == 4) return 4; //here we are trying to check if number is in form of 8a+b is its is return 4
			for(var i = 1; i * i <= n; i++)
            {
				var curNum =Math.Floor(Math.Sqrt(n - (i * i))); //if number can be presented in 3 or 2
																//natural numbers than check whther
				if (curNum * curNum == (n - i * i))             //we can stumble uupon i value which divides
				{												 //n into two squareRoot numbers
					return 2;
				}

			}
			//if number can be divided into 4,2,1 then it will definitely be divided into 3 natural number 
			return 3;
        }
	}
}
