using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap__Priority_Queue_
{
    public static  class FindKClosestElements__658_
    {
        public static IList<int> FindClosestElements(int[] arr, int k, int x)
        {
            int sum = 0;
            int i = 0;

            for (i = 0; i < k; i++)
            {
                sum += Math.Abs(arr[i] - x);
            }

            int minSum = sum;
            int resultRangeEnd = k - 1; // resultRangeStart = resultRangeEnd - k + 1;
            int curSum = sum;

            for (i = k; i < arr.Length; i++)
            {
                curSum = curSum - Math.Abs(arr[i - k] - x) + Math.Abs(arr[i] - x);
                if (minSum > curSum)
                {
                    resultRangeEnd = i;
                    minSum = curSum;
                }
            }

            return arr.Skip(resultRangeEnd - k + 1).Take(k).ToList();
        }

        public static IList<int> findClosestElements(int[] arr, int k, int x)
        {
            int left = 0, right = arr.Length - k;
            while (left < right)
            {
                int mid = (left + right) / 2;
                if (x - arr[mid] > arr[mid + k] - x)
                    left = mid + 1;
                else
                    right = mid;
            }
            return new List<int>(arr.Skip(left).Take(k).ToList());
        }
    }
}
