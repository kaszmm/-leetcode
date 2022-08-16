using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    public static class SwapPairs__24_
    {
		public static ListNode SwapPair(ListNode head)
		{
			if (head == null || head.next == null) return head;
			ListNode dummy = new ListNode(0);
			dummy.next = head;
			ListNode point = dummy;
			while (point.next != null && point.next.next != null)
			{
				ListNode node1 = point.next;
				ListNode node2 = point.next.next;
				point.next = node2;
				node1.next = node2.next;
				node2.next = node1;
				point = node1;
			}
			return dummy.next;

		}
	}
}
