using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    public static class ReverseLinkedList__206_
    {
		public static ListNode ReverseList(ListNode head)
		{
			ListNode prev = null;
			ListNode current=head;
			ListNode next;
            while (current != null)
            {
				next = current.next;
				current.next = prev;
				prev = current;
				current = next;
            }
			return prev;
		}
	}
}
