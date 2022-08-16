using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathemathics
{
	public class CanIWin__464_
	{
		enum RESULT { UNKNOWN, WIN, LOSE };
		
		public bool canIWin(int maxChoosableInteger, int desiredTotal)
		{
			if (maxChoosableInteger >= desiredTotal) return true;

			int s = maxChoosableInteger * (maxChoosableInteger + 1) / 2;
			if (s < desiredTotal) return false;
			if (s == desiredTotal) return maxChoosableInteger % 2!=0;
			RESULT[] memo=new RESULT[1 << (maxChoosableInteger + 1)];
			var ans = dfs(maxChoosableInteger, desiredTotal, memo);
			return ans;
	    }
		
		private bool dfs(int max, int t, RESULT[] memo, int k = 0)
		{
			if (t <= 0) return false;
			if (memo[k] != RESULT.UNKNOWN) return memo[k] == RESULT.WIN;

			for (int i = 1; i <= max; i++)
			{
				if (!((k & 1 << i)!=0) && !dfs(max, t - i, memo, k | (1 << i)))
				{
					memo[k] = RESULT.WIN;
					return true;
				}
			}
			memo[k] = RESULT.LOSE;
			return false;
		}
	}
}
