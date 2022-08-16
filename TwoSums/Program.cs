using System;
using System.Collections.Generic;
using System.Linq;

namespace TwoSums
{
    class Program
    {
        static void Main(string[] args)
        {
            //PascaLTraingle.Generate(3);
            int[] a = {0,0,0,0,1,0,0,0,0};
            int[][] jaggedArray = new int[][]
            {

                new int[] {1,3 },
                new int[] {2,3 },
                new int[] {3,4},
                new int[] {2,4},
                new int[] {1,4},
            };
            //BuyAndSellStock.MaxProfits(a);
            //SingleNumber.OptimizedUnique(a);
            //TwoSums2.ReturnNums(a,8);
            //MissingNumber.FindUnique(a);
            CanPlaceFlower__605_.IsSpaceFree(a,3);
        }

        public static int[] TwoSum(int[] nums, int target)
        {
            int x = 0;
            int y = 0;
            int[] output = { 0, 0 };
            for(var i= 0;i<nums.Length-1;i++)
            {
                x = nums[i];
                for (var j = i+1; j < nums.Length; j++)
                {
                    y = nums[j];
                    if ((x + y) == target)
                    {
                        output[0] = i;
                        output[1] = j;
                        return output;
                    }
                }
            }

            return output;

        }

        public static int[] OptimizedSum(int[] nums, int target)
        {
            int[] output = { 0, 0 };
            Dictionary<int, int> hash = new Dictionary<int, int>();
            for(var i = 0; i < nums.Length; i++)
            {
                if (hash.ContainsValue(Math.Abs(nums[i] - target)))
                {
                    output[0] = i;
                    output[1] = hash.FirstOrDefault(x => x.Value == (Math.Abs(nums[i] - target))).Key;
                    return output;
                }
                if (!hash.ContainsValue(Math.Abs(nums[i] - target)))
                {
                    hash.Add(i, nums[i]);
                }

            }
            return output;
        }
    }
}
