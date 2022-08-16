using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoSums
{
    public static class PascaLTraingle
    {
        public static IList<IList<int>> Generate(int numRows)
        {
            IList<IList<int>> rows = new List<IList<int>>();
            if (numRows == 0) return rows;
            IList<int> row = new List<int>();
            row.Add(1);
            rows.Add(row);
            for(var i = 1; i < numRows; i++)
            {
                IList<int> prevRow = new List<int>();
                prevRow = rows.ElementAt(i - 1);
               List<int> curRow = new List<int>();
                curRow.Add(1);
                for(var j = 1; j < i; j++)
                {
                    curRow.Add(prevRow.ElementAt(j)+prevRow.ElementAt(j-1));
                }
                curRow.Add(1);
                rows.Add(curRow);
            }
            return rows;
        }
    }

    public static class Pascaltraingle2 {
        public static IList<int> GetRow(int rowIndex)
        {
            IList<IList<int>> rows = new List<IList<int>>();
            if (rowIndex == 0)
            {
                IList<int> a = new List<int>();
                a.Add(1);
                return a;
            }
            IList<int> row = new List<int>();
            row.Add(1);
            rows.Add(row);
            for (var i = 1; i < rowIndex+1; i++)
            {
                IList<int> prevRow = new List<int>();
                prevRow = rows.ElementAt(i - 1);
                List<int> curRow = new List<int>();
                curRow.Add(1);
                for (var j = 1; j < i; j++)
                {
                    curRow.Add(prevRow.ElementAt(j) + prevRow.ElementAt(j - 1));
                }
                curRow.Add(1);
                rows.Add(curRow);
            }
            return rows.ElementAt(rowIndex);

        }

        
        public static IList<int> GetRows(int rowIndex)
        {
            IList<int> a = new List<int>();
            
            long value = 1;
            for(var j = 0; j <= rowIndex; j++)
            {
                a.Add((int)value);
                value = value * (rowIndex - j) / (j + 1);
            }
            return a;
        }
        
    
    }

}
