using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    public class SortedListToBST__109_
    {
		
		public TreeNode OptimizedListToBSt(ListNode head)
        {
            return Converter(head, null);
        }

        public TreeNode Converter(ListNode head,ListNode tail)
        {
            ListNode fast = head;
            ListNode slow = head;
            if (head == tail) return null;
            
            while (fast!=tail&&fast.next != tail)
            {
                fast = fast.next.next;
                slow = slow.next;
            }
            TreeNode t = new TreeNode(slow.val);
            t.left = Converter(head, slow);
            t.right = Converter(slow.next, tail);
            return t;
        }
        public TreeNode OptimizedSortedListToBST(ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            if (head.next == null)
            {
                return new TreeNode(head.val, null, null);
            }

            ListNode prev = null;
            ListNode middle = head;
            ListNode fast = head.next;

            while (fast?.next != null)
            {
                prev = middle;
                middle = middle.next;
                fast = fast.next?.next;
            }

            TreeNode node = new TreeNode(middle.val);
            if (prev == null)
            {
                node.left = null;
            }
            else
            {
                prev.next = null;
                node.left = OptimizedSortedListToBST(head);
            }

            node.right = OptimizedSortedListToBST(middle.next);

            return node;
        }
    }
	
}
