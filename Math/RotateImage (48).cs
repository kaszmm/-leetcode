using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathemathics
{
    public static class  RotateImage__48_
    {
  
        public static void Rotate(int[][] matrix)
        {
            int level = matrix[0].Length / 2;
            int curlevel = 0;
            int last = matrix[0].Length-1;
            while (curlevel < level)
            {
                for(var i = curlevel; i < last; i++)
                {
                    (matrix[curlevel][i], matrix[i][last])= (matrix[i][last], matrix[curlevel][i]);
                    (matrix[curlevel][i], matrix[last][last-i+curlevel])= (matrix[last][last - i + curlevel], matrix[curlevel][i]); ;
                    (matrix[curlevel][i], matrix[last-i+curlevel][curlevel])= ( matrix[last - i + curlevel][curlevel], matrix[curlevel][i]);
                }
                curlevel++;
                last--;
            }

        }

        
    }
}
