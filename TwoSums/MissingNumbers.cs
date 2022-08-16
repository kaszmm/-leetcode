using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoSums
{
	public static class MissingNumber
	{
		public static int FindUnique(int[] nums)
		{
			if (nums.Length == 1) {
				if (nums[0] == 1) return 0;
				else return 1;
			}
			int number = 0;
			for(var i=0;i<=nums.Length;i++)
			{
				if (!nums.Contains(number)) return number;
				else number++;
			}
			return 0;
		}

        public static int OptimizedUnique(int[] nums)
        {
            int[] refArr = new int[nums.Length + 1];
            for (int i = 0; i < refArr.Length; i++)
            {
                refArr[i] = i;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                refArr[nums[i]] = -1;
            }


            for (int i = 0; i < refArr.Length; i++)
            {
                if (refArr[i] != -1)
                    return refArr[i];
            }

            return -1; //not Possible Option
        }

        public static int AnotherOptimizedUnique(int[] nums)
        {
            int xor = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                xor = xor ^ nums[i] ^ (i + 1);
            }
            return xor;
        }
    }
}
