using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoSums
{
	public static  class MaxProduct__628_
	{
		public static int FindMAxProduct(int[] nums)
		{
			int max1 = Int32.MinValue;
			int max2 = Int32.MinValue;
			int max3 = Int32.MinValue;
			int min1= Int32.MaxValue;
			int min2 = Int32.MaxValue;

			foreach (var item in nums)
            {
                if (item > max1)
                {
					max3 = max2;
					max2 = max1;
					max1 = item;
                }
				else if (item > max2)
                {
					max3 = max2;
					max2 = item;
                }
				else if (item > max3)
                {
					max3 = item;
                }

                if (item < min1)
                {
					min2 = min1;
					min1 = item;
                }
                else if (item < min2)
                {
					min2 = item;
                }

            }

			return Math.Max(max1 * max2 * max3, max1 * min1 * min2);
			
		}
	}
}
