using System;
using System.Linq;

namespace Heap__Priority_Queue_
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] nums = {0.1,0.8,0.7,0.5,0.7,0.8};
            int[][] a = new int[][]
           {
                new int[] {0,1},
                new int[] {0,2},
                new int[] {0,3},
                new int[] {1,4},
                new int[] {3,4},
                new int[]{2,4}
                //new int[] {2,2,6},
                //new int[] { 1, 4, 11 }
           };
            //string p = "Aaahh";
            //NewSolution y = new NewSolution();
            //y.SortArray(nums);
            string s = "aabooooooottttteeeeeeedddddddddbbbbbbb";
            //MaxNumberOfEventTOAttend__1353_  e=new MaxNumberOfEventTOAttend__1353_();
            //e.MaxEventsToAttend(a);
            MaxProbability__1514_.MaxProbability(5,a,nums,1,4);




        }
    }
}
