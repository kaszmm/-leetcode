using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    public static class DetectCycle__142_
    {
		public static ListNode DetectCycle(ListNode head)
		{
            if (head == null || head.next == null) return null;
			ListNode fast = head;
			ListNode slow = head;
			while(fast!=null && fast.next != null)
            {
				fast = fast.next.next;
				slow = slow.next;
                if (slow == fast)
                {
					slow = head;
                    while (slow != fast)
                    {
                        slow = slow.next;
                        fast = fast.next;
                    }
                    return slow;
                }
            }
            return null;
		}
        public static ListNode LazyDetect(ListNode head)
        {
            HashSet<ListNode> list = new();
            ListNode tmp = head;

            while (tmp != null)
            {
                if (!list.Add(tmp))
                    return tmp;

                tmp = tmp.next;
            }

            return null;
        }
	}
}
