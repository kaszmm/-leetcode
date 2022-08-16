using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    public static  class PartitionLinkedList__86_
    {
		public static ListNode Partition(ListNode head, int x)
		{
			if (head == null || head.next==null) return head;
			ListNode current = new ListNode(-999);
			current.next = head;
			ListNode dummy = current;
			Queue<int> nodes = new Queue<int>();
			while (dummy.next != null)
			{

				if (dummy.next.val >= x)
				{
					nodes.Enqueue(dummy.next.val);
					dummy.next = dummy.next.next;
				}
                else
                {
					dummy = dummy.next;
				}
				

			}
			while (nodes.Count > 0)
			{
				dummy.next = new ListNode(nodes.Dequeue());
				dummy = dummy.next;
			}
			return current.next;

		}

		public static ListNode OptimizedPartition(ListNode head,int x)
        {
			if (head == null || head.next == null) return head;
			ListNode smallNodes = new ListNode();
			ListNode bigNodes = new ListNode();
			ListNode smallDum = smallNodes;
			ListNode bigDum = bigNodes;
			while (head != null)
			{

				if (head.val >= x)
				{
					bigDum.next = head;
					bigDum = bigDum.next;
				}
				else
				{
					smallDum.next = head;
					smallDum = smallDum.next;
				}

				head = head.next;
			}
			bigDum.next = null;
			smallDum.next = null;
			if (smallNodes.next == null)
			{
				return bigNodes.next;
			}
			smallDum.next = bigNodes.next;
			return smallNodes.next;

		}
	}
}
