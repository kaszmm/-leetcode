using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public static class CircularArrayLoop__457_
    {
        private static readonly int NOT_VISITED = 0;
        private static readonly int VISITING = 1;
        private static readonly int VISITED = 2;

        public static bool circularArrayLoop(int[] nums)
        {
            var visited = new int[nums.Length];
            for (var i = 0; i < nums.Length; i++)
            {
                if (visited[i] == NOT_VISITED && dfs(i, visited, nums)) return true;

            }

            return false;

        }
        private static bool dfs(int cur, int[] visited, int[] nums)
        {
            int N = nums.Length;
            if (visited[cur] == VISITING) return true;
            if (visited[cur] == VISITED) return false;

            visited[cur] = VISITING;

            int next = cur + nums[cur];
            next %= N;
            if (next < 0) next += N;

            // not a valid cycle if the length is 1
            // not a valid cycle if coming from different directions
            if (next == cur || nums[next] * nums[cur] < 0)
            {
                visited[cur] = VISITED;
                return false;
            }

            if (dfs(next, visited, nums)) return true;
            visited[cur] = VISITED;
            return false;
        }

    }
}
