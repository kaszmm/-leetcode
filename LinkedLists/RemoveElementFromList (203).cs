using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    public static class RemoveElementFromList__203_
    {
		public static ListNode RemoveElements(ListNode head, int val)
		{

			
			ListNode remove = head;
			ListNode n = remove.next;
			ListNode newList = remove;
			while (n!=null)
			{
				while(remove.val==val)
				{
					head = head.next;
					remove = head;
                    if (remove.next == null)
                    {
						if(remove.val == val) return null;
						else return remove;
					}
					n = remove.next;
				}
				while (remove.next.val != val )
				{
						remove = remove.next;
						n = remove.next;
					if (n == null) return head;
				}
				remove.next = n.next;
				n.next = null;
				if (remove.next!= null)
				{
						n = null;
						n = remove.next;
				}
                else
                {
					return head;
                }

			}
			return head;

		}

		public static ListNode OptimizedRemovedElements(ListNode head,int val)
        {
			if (head == null) return null;
			ListNode current = head;
			ListNode prev = null;
			while (current != null)
			{
				if (current.val == val)
				{
					if (current == head)
					{
						head = head.next;
						current = current.next;
					}
					else
					{
						prev.next = current.next;
						current = current.next;
					}
				}
				else
				{
					prev = current;
					current = current.next;
				}

			}
			return head;
		}
	}
}
