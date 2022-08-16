using System;

namespace Greedy
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 6, 2, 6, 5, 1, 2 };
            int[] snums = { 3,4,5,1,2};
            int[][] jaggedArray = new int[][]
             {
                 
                new int[] { 6,8 },
                new int[] { 0,1},
                new int[] {0,2},
                new int[] { 0,4 },
                new int[] { 5,6},
                 new int[] { 0,3 },
                new int[] { 6,7},
                new int[] {1,3},
                new int[] {4,7 },
                new int[] { 1,4},
                 new int[] { 2,5 },
                new int[] { 2,6},
                new int[] {3,4},
                new int[] {4,5 },
                new int[] { 5,7},
                 new int[] { 6,9}
             };
            VideoStiching__1024_.VideoStitching(jaggedArray,9);
        }
    }
}
