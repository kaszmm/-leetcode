using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    public static  class ReverseMiddleList__92_
    {
		public static ListNode ReverseBetween(ListNode head, int left, int right)
		{
			if (head == null|| head.next==null || left==right) return head;
			ListNode n = new ListNode();
			n.next = head;
			ListNode nDum = n;
            ListNode newNeutral = null;
			int count = 0;
			ListNode newPrevNode = null;
			while (n!= null)
			{
				if (count== left-1)
				{
					newPrevNode = n;
					newNeutral = n.next;
					break;
				}
				n = n.next;
				count++;
			}
			count++;
			ListNode prev = null;
			ListNode cur = newNeutral;
			ListNode m = newNeutral.next;
			ListNode finalDum = null;
			ListNode temp = null;
			while (cur!=null || count<=right)
			{
				cur.next = prev;
				prev = cur;
				cur = m;
				if(m!=null) m = m.next;
				count++;
				if (count==right)
                {
                    if (cur != null)
                    {
						temp = cur.next;
						cur.next = prev;
						prev = cur;
					}
					break;
				}
			}
			newPrevNode.next = prev;
			finalDum = nDum.next;
			while (finalDum.next != null)
			{
				finalDum = finalDum.next;
			}
			finalDum.next = temp;
			return nDum.next;
		}


		public static ListNode OptimizedReverseBetween(ListNode head,int left,int right)
        {
			ListNode dummy = new ListNode();
			dummy.next = head;
			ListNode p = dummy;
			ListNode tail = null;
			for(var i = 0; i < left-1; i++)
            {
				p = p.next;
            }
			tail = p.next;
			ListNode temp = null;
			for(var i = 0; i < (right - left); i++)
            {
				temp = p.next;
				p.next = tail.next;
				tail.next = tail.next.next;
				p.next.next = temp;
            }
			return dummy.next;
        }
	}
}
