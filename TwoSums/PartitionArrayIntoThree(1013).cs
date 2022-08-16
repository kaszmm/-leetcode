using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoSums
{
    public static class PartitionArrayIntoThree_1013_
    {
		public static bool CanThreePartition(int[] arr)
		{
			int sum = arr.Sum();
			if (sum % 3 != 0) return false;
			int subSum = sum / 3;
			int count = 0;
			sum = 0;
			for(var i = 0; i < arr.Length; i++)
            {
				sum += arr[i];
                if (sum == subSum)
                {
					count++;
					sum = 0;
                }
				if (count == 3) return true;
            }

			return false;


		}
	}
}
