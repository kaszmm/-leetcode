using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    public static class ValidPalindrome__234_
    {
		public static bool IsPalindrome(ListNode head)
		{
			if (head.next == null) return false;
			int count = 0;
			int partitionAt = 0;
			ListNode checker = head;
			ListNode d1 = head;
			ListNode d2 = head;
			ListNode d1Cur = d1;
			while (checker != null)
			{
				checker = checker.next;
				count++;
			}
			partitionAt = count / 2;
			while (partitionAt >0)
			{
				d1Cur = d2;
				d2 = d2.next;
				partitionAt--;
			}
			d1Cur.next = null;
			if (count % 2 != 0)
				d2 = d2.next;

			ListNode current = d2;
			ListNode n = d2;
			ListNode prev = null;
			while (n != null)
			{
				n = n.next;
				current.next = prev;
				prev = current;
				current = n;
			}
			d2 = prev;


			bool run = true;
            while (run)
            {
				if (d1.val == d2.val)
				{
					d1 = d1.next;
					d2 = d2.next;
					if (d1 == null && d2 == null) return true;
				}
                else
                {
					run = false;
                }
            }
			return false;


		}
	}
}
