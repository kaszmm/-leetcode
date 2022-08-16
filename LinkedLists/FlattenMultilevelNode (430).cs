using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    public class Node
    {
        public int val;
        public Node prev;
        public Node next;
        public Node child;
    }
    public  class FlattenMultilevelNode__430_
    {
        public Node Flatten(Node head)
        {
            Stack<Node> leftOver = new Stack<Node>();
            Node dummy = head;
            Node temp;
            while (dummy != null)
            {
                if (dummy.child != null)
                {
                    if (dummy.next != null)
                    {
                        leftOver.Push(dummy.next);
                    }
                    dummy.next = dummy.child;
                    dummy.child.prev = dummy;
                    dummy.child = null;
                }
                if (dummy.child == null && dummy.next == null)
                {
                    break;
                }
                dummy = dummy.next;
            }

            while (leftOver.Count > 0)
            {
                temp= leftOver.Pop();
                dummy.next = temp;
                temp.prev = dummy;
                while (dummy.next != null)
                {
                    dummy = dummy.next;
                }
            }
            return head;
        }
    }
}
