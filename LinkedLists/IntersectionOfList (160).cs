using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    public static class IntersectionOfList__160_
    {
		public static ListNode GetIntersectionNode(ListNode headA, ListNode headB)
		{
			ListNode d1 = headA;
			ListNode d2 = headB;
			bool isd1TraversedHeadB = false;
			while(d1 != d2)
            {
				d1 = d1.next;
				d2 = d2.next;
				if (d1 == d2) 
					return d1;
				if (d1 == null)
                {
					if (isd1TraversedHeadB) return null;
					isd1TraversedHeadB = true;
					d1 = headB;
				}
				if (d2 == null) d2 = headA;
            }
			return d1;


		}
	}
}
