using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    public static class DeleteMiddleNode__2095_
    {
		public static ListNode DeleteMiddle(ListNode root)
		{
			if (root.next == null) return null;
			ListNode prev = root;
			ListNode n = root.next;
			while (n.next != null)
			{
				n = n.next;
				if (n.next != null)
				{
					prev = prev.next;
					n = n.next;
				}
			}
			prev.next = prev.next.next;

			return root;


		}

		public static ListNode OptimizedDeleteMiddle(ListNode head)
		{
			if (head == null || head.next == null)
			{
				return null;
			}
			ListNode slow = head, fast = head.next.next;
			while (fast != null && fast.next != null)
			{
				slow = slow.next;
				fast = fast.next.next;
			}
			slow.next = slow.next.next;
			return head;
		}

	}
}
