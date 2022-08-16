using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }

    }

    public  class MergeTwoSortedLists__21_
    {
		

		public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            if (list1 == null) return list2;
            if (list2 == null) return list1;

            if (list1.val < list2.val)
            {
                list1.next = MergeTwoLists(list1.next, list2);
                return list1;
            }
            else
            {
                list2.next = MergeTwoLists(list1, list2.next);
                return list2;
            }
        }
        public ListNode NewMergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null)
                return l2;
            else if (l2 == null)
                return l1;

            ListNode d = new ListNode(), cur = d;

            while (l1 != null && l2 != null)
            {
                if (l1.val < l2.val)
                {
                    cur.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    cur.next = l2;
                    l2 = l2.next;
                }

                cur = cur.next;
            }

            if (l1 != null)
                cur.next = l1;

            if (l2 != null)
                cur.next = l2;

            return d.next;
        }

        public  ListNode NewestMergeTwoLists(ListNode list1, ListNode list2)
        {
            var dummy = new ListNode(-1);

            var cur = dummy;
            var cur1 = list1;
            var cur2 = list2;

            while (cur1 != null && cur2 != null)
            {
                if (cur1.val <= cur2.val)
                {
                    cur.next = cur1;
                    cur1 = cur1.next;
                }
                else
                {
                    cur.next = cur2;
                    cur2 = cur2.next;
                }

                cur = cur.next;
            }

            if(cur1 != null)
            {
                cur.next = cur1;
                cur = cur.next;
                cur1 = cur1.next;
            }

            if (cur2 != null)
            {
                cur.next = cur2;
                cur = cur.next;
                cur2 = cur2.next;
            }

            var newHead = dummy.next;
            dummy.next = null;

            return newHead;
        }

    }
}
