using System;
using System.Collections;
using System.Collections.Generic;

namespace Mathemathics 
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] jaggedMAtrix = new int[][]
              {
                new int[] { 1,2,3},
                new int[] { 4,5,6 },
                new int[] { 7,8,9 },

             };
            int[] num = { 1,1,1,1,2,2,2,2,2,2 };
            ListNode l1 = new ListNode() { val = 2, next = new ListNode() { val = 4, next = new ListNode() { val = 3 } } };
            ListNode l2 = new ListNode() { val = 5, next = new ListNode() { val = 6, next = new ListNode() { val = 4 } } };

            ListNode l3 = new ListNode() { val = 9};
            ListNode l4 = new ListNode() { val = 9};
            IList<string> nums = new List<string>() { "2:09", "12:00","00:00","3:00"};

            CheckIfNumIsSumOfPowOfThree__1780_.CheckPowersOfThree(12);
        }
    }
}
