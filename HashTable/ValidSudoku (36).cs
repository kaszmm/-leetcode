using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public static class ValidSudoku__36_
    {
		public static bool isValidSudoku(char[][] board)
		{

			HashSet<string> sudoku = new HashSet<string>();
			for (var i = 0; i < 9; i++)
			{
				for (var j = 0; j < 9; j++)
				{
					string number = board[i][j].ToString();
                    if (number != ".")
                    {
						if (!sudoku.Add($"{number} in row {i}") ||
					   !sudoku.Add($"{number} in column {j}") ||
					   !sudoku.Add($"{number} in block {i / 3} - {j / 3}"))
							return false;
					}
					

				}
			}

			return true;

		}
        public static bool IsValidSudoku(char[][] board)
        {
            for (int i = 0; i < 9; ++i)
            {
                bool[] row = new bool[9];
                bool[] col = new bool[9];
                bool[] cub = new bool[9];

                int rowIdx = 3 * (i / 3), colIdx = 3 * (i % 3);
                for (int j = 0; j < 9; ++j)
                {
                    if (board[i][j] != '.')
                    {
                        if (row[board[i][j] - '1'])
                            return false;
                        row[board[i][j] - '1'] = true;
                    }
                    if (board[j][i] != '.')
                    {
                        if (col[board[j][i] - '1'])
                            return false;
                        col[board[j][i] - '1'] = true;
                    }

                    if (board[rowIdx + j / 3][colIdx + j % 3] != '.')
                    {
                        if (cub[board[rowIdx + j / 3][colIdx + j % 3] - '1'])
                            return false;
                        cub[board[rowIdx + j / 3][colIdx + j % 3] - '1'] = true;
                    }
                }
            }
            return true;
        }

    }
    
}
