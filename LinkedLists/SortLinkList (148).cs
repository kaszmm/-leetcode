using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    public  class SortLinkList__148_
    {
        private ListNode GetMiddle(ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            var left = head;
            var right = head.next;

            while (right != null)
            {
                right = right.next;
                if (right != null)
                {
                    left = left.next;
                    right = right.next;
                }
            }
            return left;
        }

        private ListNode Merge(ListNode first, ListNode second)
        {
            if (first == null)
            {
                return second;
            }

            if (second == null)
            {
                return first;
            }

            ListNode res;

            if (first.val <= second.val)
            {
                res = first;
                first = first.next;
            }
            else
            {
                res = second;
                second = second.next;
            }

            var last = res;

            while (first != null || second != null)
            {
                if (first == null)
                {
                    last.next = second;
                    second = second.next;
                }
                else if (second == null)
                {
                    last.next = first;
                    first = first.next;
                }
                else
                {
                    if (first.val <= second.val)
                    {
                        last.next = first;
                        first = first.next;
                    }
                    else
                    {
                        last.next = second;
                        second = second.next;
                    }
                }

                last = last.next;
            }

            return res;
        }

        public ListNode SortList(ListNode head)
        {
            if (head?.next == null)
            {
                return head;
            }

            var middle = GetMiddle(head);
            var middleNext = middle.next;

            middle.next = null;

            var left = SortList(head);
            var right = SortList(middleNext);

            return Merge(left, right);
        }
    }
}
