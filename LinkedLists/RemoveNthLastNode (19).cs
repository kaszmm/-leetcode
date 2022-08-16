using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    public static class RemoveNthLastNode__19_
    {
		public static ListNode RemoveNthNode(ListNode head, int n)
		{
			if (head == null || head.next==null) return null;
			ListNode dummy = new ListNode();
			dummy.next = head;
			ListNode cur = dummy;
			ListNode nn = null;
			int count = 0;
			while (cur != null)
			{
				count = 0;
				nn = cur.next;
				while (nn.next != null && count<=n)
				{
					nn = nn.next;
					count++;
				}
				if (count == n-1)
				{
					cur.next = cur.next.next;
					return dummy.next;
				}
				cur = cur.next;
			}

			return dummy.next;

		}



		public static ListNode OptimizedRemoveNthNode(ListNode head,int n)
        {
			if (head == null || head.next == null) return null;
			ListNode start = new ListNode(0);
			ListNode slow = start, fast = start;
			slow.next = head;

			//Move fast in front so that the gap between slow and fast becomes n
			for (int i = 1; i <= n + 1; i++)
			{
				fast = fast.next;
			}
			//Move fast to the end, maintaining the gap
			while (fast != null)
			{
				slow = slow.next;
				fast = fast.next;
			}
			//Skip the desired node
			slow.next = slow.next.next;
			return start.next;
		}
	}
}
