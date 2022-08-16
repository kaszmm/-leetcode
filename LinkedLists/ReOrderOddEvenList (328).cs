using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    public static class ReOrderOddEvenList__328_
    {
        public static ListNode ReOrderIt(ListNode head)
        {
            if (head == null) return head; 
            ListNode oddList = head;
            ListNode evenList = head.next;
            ListNode evenHead = evenList;

            while(evenList!=null && evenList.next != null)
            {
                oddList.next = oddList.next.next;
                evenList.next = evenList.next.next;
                oddList = oddList.next;
                evenList = evenList.next;
            }

            oddList.next = evenHead;
            return head;
        }
    }
}
