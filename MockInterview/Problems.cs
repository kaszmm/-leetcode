using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockInterview
{
    public class InterviewProblems
    {
        public bool ContainsDuplicate(int[] nums)
        {

            Dictionary<int, int> hashMap = new Dictionary<int, int>();


            foreach (var num in nums)
            {
                if (!hashMap.ContainsKey(num))
                {
                    hashMap.Add(num, 0);
                }
                hashMap[num]++;
                if (hashMap[num] > 1)
                {
                    Console.WriteLine("true");
                    return true;

                }
            }
            Console.WriteLine("false");
            return false;
        }
		public int MaxSum(int[][] grid)
		{
			int RowCounter(int row, int col)
			{
				int rowSum = 0;
				if (row <= grid.Length && col + 2 <= grid[row].Length - 1)
				{
					var maxCols = col + 2;
					while (col <= maxCols)
					{
						rowSum += grid[row][col];
						col++;
					}
				}
				return rowSum;

			}
			int Max = 0;
			int i = 0;
			int j = 0;
			for (var level = 0; level < grid.Length - 2; level++)
			{
				i = level;
				j = 0;
				int Start = RowCounter(i, j);
				int mid = grid[i + 1][j + 1]; //diagonal Value
		        int End = RowCounter(i + 2, j);
				j++;
				int curSum = Start + mid + End;
				int curMax = curSum;
				while (j < grid[0].Length - 2)
				{
					curSum = curSum - grid[i][j - 1] - grid[i + 2][j - 1] - grid[i][j];
					curSum = curSum + grid[i][j + 2] + grid[i + 2][j + 2] + grid[i + 1][j + 1];
					curMax = Math.Max(curMax, curSum);
					j++;
				}
				Max = Math.Max(Max, curMax);
			}

			return Max;
		}
	}
}
