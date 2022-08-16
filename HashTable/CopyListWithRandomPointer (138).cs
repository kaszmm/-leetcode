using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public class Node
    {
        public int val;
        public Node next;
        public Node random;
        public Node(int _val)
        {
            val = _val;
            next = null;
            random = null;
        }
    }
    public  class CopyListWithRandomPointer__138_
    {
		public static Node CopyRandomList(Node head)
		{

            Node dum = head;
            while (dum != null)
            {
                Node c = dum.next;
                dum.next = new Node(dum.val);
                dum.next.next = c;
                dum = c;
            }

            dum = head;
            while (dum != null)
            {
                if (dum.random != null)
                {
                    dum.next.random = dum.random.next;
                }
                dum = dum.next.next;
            }
            dum = head;
            Node copyNode = head.next;
            Node dumCopy = copyNode;
            while (dumCopy.next != null)
            {
                dum.next = dum.next.next;
                dum = dum.next;

                dumCopy.next = dumCopy.next.next;
                dumCopy = dumCopy.next;
            }
            dum.next = dum.next.next;
            return copyNode;
		}
        public static Node OptimizedCopyRandomList(Node head)
        {
            if (head == null)
                return null;

            Node current = head;
            Node newHead = null;
            Node newCurrent = null;
            Dictionary<Node, Node> map = new Dictionary<Node, Node>();

            do
            {
                Node temp = new Node(current.val);
                if (newHead == null)
                {
                    newHead = temp;
                    newCurrent = newHead;
                }
                else
                {
                    newCurrent.next = temp;
                    newCurrent = newCurrent.next;
                }
                map.Add(current, newCurrent);
                current = current.next;

            } while (current != null);

            newCurrent = newHead;
            current = head;

            while (current != null)
            {
                Node random = current.random;
                if (random == null)
                    newCurrent.random = null;
                else
                {
                    Node newRandom = map[random];
                    newCurrent.random = newRandom;
                }
                current = current.next;
                newCurrent = newCurrent.next;
            }
            return newHead;
        }
    }
}
