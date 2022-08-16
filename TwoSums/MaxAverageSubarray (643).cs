using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoSums
{
    public static class MaxAverageSubarray__643_
    {
		public static double SlidingWindow(int[] nums,int k)
        {
			int sum = 0;
			double maxSum = Int32.MinValue;
			for(var i = 0; i < nums.Length; i++)
            {
                if (i < k)
                {
					sum += nums[i];
                }
                else
                {
					maxSum = Math.Max(maxSum, sum);
					sum -= nums[i - k];
					sum += nums[i];
                }
            }

			maxSum = Math.Max(maxSum,sum);
			return maxSum / k;

        }

        public static double OptimalFindMaxAverage(int[] nums, int k)
        {

            double sum = 0;
            double max = 0;

            for (int i = 0; i < k; i++)
            {
                sum += nums[i];
            }
            max = sum;

            for (int i = k; i < nums.Length; i++)
            {

                sum += nums[i] - nums[i - k];
                max = Math.Max(sum, max);
            }

            return max / k;

        }
    }
}
