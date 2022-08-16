using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoSums
{
    public static class MisMatchNumber
    {
		public static  int[] FindDuplicateAndUnique(int[] nums)
		{
            int[] table = new int[nums.Length + 1];
            int duplicate = 0;
            int missed = 0;
            int indexOfTable = 0;
            for(var i = 0; i <nums.Length; i++)
            {
                indexOfTable = nums[i];
                table[indexOfTable]++;

            }
            for(var i = 1; i < table.Length; i++)
            {
                if (table[i] == 2) duplicate = i;
                else if (table[i] == 0) missed = i;
            }

            return new int[]{ duplicate,missed};
        }
	}
}
