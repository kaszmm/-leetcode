using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public static class IncreasingSubseqeunce__491_
    {
        public static IList<IList<int>> FindSubsequences(int[] nums)
        {
            var result = new List<IList<int>>();
            DFS(nums, 0, new List<int>(), result);
            return result;
        }

        private static void DFS(int[] nums, int startIndex, IList<int> oneResult, IList<IList<int>> result)
        {
            if (oneResult.Count > 1)
            {
                result.Add(new List<int>(oneResult));
            }

            // not able to sort, so we add isVisited to remove the duplicate 
            var isVisited = new HashSet<int>();

            var n = nums.Length;
            for (int i = startIndex; i < n; i++)
            {
                var cur = nums[i];
                if (isVisited.Contains(cur)) continue;
                if (!oneResult.Any() || oneResult.Last() <= cur)
                {
                    isVisited.Add(cur);
                    oneResult.Add(cur);
                    DFS(nums, i + 1, oneResult, result);
                    oneResult.RemoveAt(oneResult.Count - 1);
                }
            }
        }
    }
}
