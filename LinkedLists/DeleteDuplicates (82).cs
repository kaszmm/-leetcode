using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    public static class DeleteDuplicates__82_
    {
		public static ListNode DeleteDuplicates(ListNode head)
		{
			if (head == null || head.next == null) return head;
			ListNode dummy = new ListNode(0);
			dummy.next = head;
			ListNode n = dummy;
			ListNode prev = null;
			HashSet<int> visited = new();
			HashSet<int> wanted = new();
			while (n.next != null)
			{

				if (!visited.Add(n.next.val))
				{
					wanted.Add(n.next.val);
					prev = n;
					prev.next = n.next.next;

				}
                else
                {
					n = n.next;
				}
				
			}
			n = dummy;
			while (n.next!=null)
			{

				if (wanted.Contains(n.next.val)){
					n.next = n.next.next;
				}
                else
                {
					n = n.next;
                }
			}
			return dummy.next;


		}

		public static  ListNode OptimizedDeleteDuplicates(ListNode head)
		{

			ListNode newHead = new ListNode(0);
			newHead.next = head;
			ListNode prev = newHead;
			ListNode cur = head;
			while (cur!= null)
			{

				while (cur.next!= null && cur.val == cur.next.val)
				{
					cur = cur.next;
				}
				if (prev.next == cur)
				{

					prev = prev.next;
				}
				else
				{
					prev.next = cur.next;
				}

				cur = cur.next;
			}
			return newHead.next;

		}
	}
}
