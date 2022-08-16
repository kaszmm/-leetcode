using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public static class ContinuousSubrraySum__523_
    {
        public static bool CheckSubarraySum(int[] nums, int k)
        {
            Dictionary<int, int> sums = new Dictionary<int, int>();
            int sum = 0;
            sums.Add(0, -1);
            for(var i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                if (k!=0)
                {
                    sum %= k;
                }
                if (sums.ContainsKey(sum))
                {
                    if (i - sums[sum] > 1) return true;
                }
                else
                {
                    sums.Add(sum, i);
                }
            }
            return false;
        }
    }
}
