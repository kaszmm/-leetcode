using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public static class SetMatrixZero__73_
    {
		public static void SetZeroes(int[][] matrix)
		{
			HashSet<int> i = new HashSet<int>();
			HashSet<int> j = new HashSet<int>();
			for (var m = 0; m < matrix.Length; m++)
			{
				for (var n = 0; n < matrix[m].Length; n++)
				{
					if (matrix[m][n] == 0)
					{
						if (!i.Contains(m)) i.Add(m);
						if (!j.Contains(n)) j.Add(n);
					}

				}
			}
            if (j.Count != 0)
            {
				for (var m = 0; m < matrix.Length; m++)
				{
					if (i.Contains(m))
					{
						for (var n = 0; n < matrix[m].Length; n++)
						{
							matrix[m][n] = 0;
						}
					}
					else
					{
						for (var n = 0; n < matrix[m].Length; n++)
						{
							if (j.Contains(n))
							{
								matrix[m][n] = 0;
							}

						}

					}

				}
			}
			

		}
		public static void setZeroes(int[][] matrix)
		{
			int col0 = 1, rows = matrix.Length, cols = matrix[0].Length;

			for (int i = 0; i < rows; i++)
			{
				if (matrix[i][0] == 0) col0 = 0;
				for (int j = 1; j < cols; j++)
					if (matrix[i][j] == 0)
						matrix[i][0] = matrix[0][j] = 0;
			}

			for (int i = rows - 1; i >= 0; i--)
			{
				for (int j = cols - 1; j >= 1; j--)
					if (matrix[i][0] == 0 || matrix[0][j] == 0)
						matrix[i][j] = 0;
				if (col0 == 0) matrix[i][0] = 0;
			}
		}

	}
}
