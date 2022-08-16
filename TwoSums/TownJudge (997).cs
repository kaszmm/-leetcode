using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoSums
{
    public static class TownJudge__997_
    {
        public static int FindJudge(int n,int[][] trust)
        {
            int[] temp = new int[n + 1];
            foreach(var item in trust)
            {
                temp[item[0]]--;
                temp[item[1]]++;
            }

            for(var i = 1; i < temp.Length; i++)
            {
                if (temp[i] == n - 1) return i;
            }
            return -1;
		}
    }
}
