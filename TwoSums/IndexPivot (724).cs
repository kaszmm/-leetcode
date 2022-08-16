using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoSums
{
    public static class IndexPivot__724_
    {
        public static int FindPivot(int[] nums){

            int sum = 0;
            int leftSumm = 0;
            int pivotElement = 0;
            for(var i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
            }
            for(var i = 0; i < nums.Length; i++)
            {
                pivotElement = nums[i];
                if (leftSumm == sum - leftSumm - pivotElement) return i;
                leftSumm += nums[i];
            }
            return -1;
        }
    }
}
