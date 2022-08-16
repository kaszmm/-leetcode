using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoSums
{
    public static class ValidMountainArray__941_
    {
		public static bool IsMountain(int[] arr)
		{

			int peakMax = Int32.MinValue;
			int maxIndex = 0;
			int count = 0;

			for (var i = 0; i < arr.Length; i++)
			{
				if (arr[i] >= peakMax)
				{
					if (arr[i] == peakMax) count++;
					peakMax = arr[i];
					maxIndex = i;
				}

			}

			if (count > 0 || maxIndex==0 || maxIndex==arr.Length-1) return false;
			for (var i = 0; i < maxIndex; i++)
			{
				if (arr[i] >= arr[i + 1]) return false;
			}
			for (var i = maxIndex + 1; i < arr.Length-1; i++)
			{
				if (arr[i] <= arr[i + 1]) return false;
			}
			return true;
		}
	}
}
