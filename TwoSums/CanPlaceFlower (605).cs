using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoSums
{
    public static class CanPlaceFlower__605_
    {
		public static bool IsSpaceFree(int[] flowerbed, int n)
		{
            if (n == 0) return true;
            int count = 1;
            int result = 0;
            for (int i = 0; i < flowerbed.Length; i++)
            {
                if (flowerbed[i] == 0)
                {
                    count++;
                }
                else
                {
                    result += (count - 1) / 2;
                    count = 0;
                }
            }
            if (count != 0) result += count / 2;
            return result >= n;

        }
	}
}
