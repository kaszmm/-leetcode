using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greedy
{
    public static class ValidTriangleNumber__611_
    {
        public static int TriangleNumber(int[] nums)
        {
            var count = 0;
            Array.Sort(nums);
            for(var i = 0; i < nums.Length - 1; i++)
            {
                    if (nums[i] == 0) continue;
                    for (var j = i + 1; j < nums.Length - 1; j++)
                    {
                        var sum = nums[i] + nums[j];
                        for(var k = j + 1; k < nums.Length; k++)
                        {
                            if (sum > nums[k]) count++;
                            else break;
                        }
                        
                    }
               
            }
            return count;
        }
        public static int triangleNumber(int[] A)
        {
            Array.Sort(A);
            int count = 0, n = A.Length;
            for (int i = n - 1; i >= 2; i--)
            {
                int left = 0, right = i - 1;
                while (left < right)
                {
                    if (A[left] + A[right] > A[i])
                    {
                        count += right - left;
                        right--;
                    }
                    else left++;
                }
            }
            return count;
        }
    }
}
