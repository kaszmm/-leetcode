using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public static class SubArraySumEqualsK__560_
    {
		public static int Subarray(int[] nums, int k)
		{
            Dictionary<int, int> sumCount = new Dictionary<int, int>();
            int result = 0;
            int sum = 0;
            sumCount.Add(0, 1);
            foreach (int n in nums)
            {
                // compute sum at each index
                sum += n;
                // if (current sum - k) exists in dictionary then it means we have sum equal to k between two indices
                if (sumCount.ContainsKey(sum - k))
                    result += sumCount[sum - k];
                // add current sum to dic if it already exists increment count else add new with count set to 1
                if (sumCount.ContainsKey(sum))
                    sumCount[sum] += 1;
                else
                    sumCount.Add(sum, 1);
            }

            return result;
        }
	}
}
