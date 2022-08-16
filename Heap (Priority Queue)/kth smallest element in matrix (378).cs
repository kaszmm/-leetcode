using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap__Priority_Queue_
{
    public static class kth_smallest_element_in_matrix__378_
    {
        public static int kthSmallest(int[][] matrix, int k)
        {
            int lo = matrix[0][0], hi = matrix[matrix.Length - 1][matrix[0].Length - 1] + 1;//[lo, hi)
            while (lo < hi)
            {
                int mid = lo + (hi - lo) / 2;
                int count = 0, j = matrix[0].Length - 1;
                for (int i = 0; i < matrix.Length; i++)
                {
                    while (j >= 0 && matrix[i][j] > mid) j--;
                    count += (j + 1);
                }
                if (count < k) lo = mid + 1;
                else hi = mid;
            }
            return lo;
        }

        public static int KthSmallest(int[][] matrix, int k)
        {
            return matrix.SelectMany(a => a).OrderBy(x => x).Skip(k - 1).FirstOrDefault();

        }
    }
}
