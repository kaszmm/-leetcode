using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blind_75
{
    //go to this link to understand it https://leetcode.com/explore/learn/card/recursion-ii/472/backtracking/2654/
    public class Backtracking_Pruning_
    {
		//1
		IList<IList<int>> ans = new List<IList<int>>();
		public IList<IList<int>> CombinationSum(int[] candidates, int target)
		{
			
				Dfs(0,candidates,0,target,new List<int>());
			return ans;
		}

		public void Dfs(int idx, int[] candidates, int curSum, int tar, List<int> curList)
		{
			if (curSum == tar)
			{
				ans.Add(new List<int>(curList));
				return;
			}
			if (idx == candidates.Length || curSum > tar)
			{
				return;
			}
			curSum += candidates[idx];
			curList.Add(candidates[idx]);
			Dfs(idx, candidates, curSum, tar, curList);

			curSum -= candidates[idx];
			curList.RemoveAt(curList.Count - 1);
			Dfs(idx + 1, candidates, curSum, tar, curList);
			return;
		}
		//the code like this first 2 than 22 than 222 than 2222(but cursum is greter than target)
		//revert now 2223 than 2226 than 2227 but all give not result sor evertthan 223 than 226 than 227 than after reaching last index revert 23
		//than so on and at last we have 2 and than [] array

		//2
		public bool Exist(char[][] board, string word)
		{
			HashSet<(int,int)> visited=new HashSet<(int,int)>();

			bool Dfs(int r, int c,int idx)
			{
				if (idx==word.Length) return true;  //means we reach end of word of return true
				if (r >= board.Length || r < 0 || c < 0 || c >= board[0].Length || word[idx] != board[r][c] || visited.Contains((r,c)))
				{
					return false;
				}
				visited.Add((r, c));
				idx++;
				var result = (Dfs(r, c - 1, idx) || Dfs(r, c + 1, idx) || Dfs(r - 1, c, idx) || Dfs(r + 1, c, idx));
				visited.Remove((r, c));
				return result;
			}
			for(var i = 0; i < board.Length; i++)
            {
				for(var j=0;j< board[0].Length; j++)
                {
					if (Dfs(i,j,0)) return true;
				}
            }
			return false;
		}

		public bool OptExist(char[][] board, string word)
		{
			for (int i = 0; i < board.Length; i++)
			{
				for (int j = 0; j < board[0].Length; j++)
				{
					if (OptDfs(board, i, j, word, 0))
						return true;
				}
			}
			return false;
		}
		private int[][] moves = new int[][]{
		new int[]{0,1},
		new int[]{0,-1},
		new int[]{1,0},
		new int[]{-1,0}
	    };
		private bool OptDfs(char[][] board, int r, int c, string word, int pos)
		{

			if (pos == word.Length)
				return true;
			//int code = r * board[0].Length + c;

			if (r < 0 || r >= board.Length || c < 0 || c >= board[0].Length
				|| board[r][c] != word[pos])
				return false;

			board[r][c] = '#';

			foreach (int[] move in moves)
			{
				int nr = r + move[0];
				int nc = c + move[1];
				if (OptDfs(board, nr, nc, word, pos + 1))
					return true;

			}

			board[r][c] = word[pos];

			return false;
		}
	}


}
