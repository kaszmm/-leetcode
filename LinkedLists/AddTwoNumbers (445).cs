using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    public  class AddTwoNumbers__445_
    {

		public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
		{
			ListNode dum1 = ReverseIt(l1);
			ListNode dum2 = ReverseIt(l2);
			
			int carry = 0;
			int sum = 0;
			ListNode totalSum = null;
			while (dum1 != null || dum2 != null)
			{
				int a = dum1 == null ? 0 : dum1.val;
				int b = dum2 == null ? 0 : dum2.val;
				sum = a + b + carry;
				carry = sum / 10;
				ListNode cur = new ListNode(sum % 10);
				cur.next = totalSum;
				totalSum = cur;
                if (dum1 != null)
                {
					dum1 = dum1.next;
				}
                if (dum2 != null)
                {
					dum2 = dum2.next;
				}
				
			}
            if (carry > 0)
            {
				ListNode cur = new ListNode(carry);
				cur.next = totalSum;
				totalSum = cur;
            }
			return totalSum;

		}

		public ListNode ReverseIt(ListNode head)
		{
			if (head.next == null) return head;
			ListNode prev = null;
			ListNode n;
			ListNode cur = head;
			while (cur != null)
			{
				n = cur.next;
				cur.next = prev;
				prev = cur;
				cur = n;
			}
			return prev;
		}
	}
}
