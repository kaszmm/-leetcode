using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomSums__Medium_
{
    public static class DailyTemperatures__739_
    {
		public static int[] DailyTemperatures(int[] temp)
		{
			    Stack<int> candidates = new Stack<int>();
			    int[] ans = new int[temp.Length];
			    for(var i=temp.Length-1; i>=0; i--)
                {
				    while(candidates.Count > 0 && temp[candidates.Peek()] <= temp[i])
                    {
					    candidates.Pop();
                    }
                    if (candidates.Count > 0)
                    {
                        ans[i] = candidates.Peek()-i;
                    }

                    candidates.Push(i);
                }
                return ans;

		}
	}
}
