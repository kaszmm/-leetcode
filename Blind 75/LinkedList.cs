using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blind_75
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    public class LinkedList
    {
        //1
        public ListNode ReverseList(ListNode head)
        {
            if (head == null) return null;
            ListNode cur = head;
            ListNode prev = null;
            
            while (cur != null)
            {
                ListNode temp = cur.next;
                cur.next = prev;
                prev = cur;
                cur = temp;
            }
            return prev;

        }

        //recursion not optimal solution
        public ListNode RecReverseList(ListNode head)
        {
            if (head == null) return null;
            ListNode cur = head;

            if (head.next != null)
            {
                cur.next = RecReverseList(head.next);
                head.next.next = head;
            }
            head.next = null;
            
            return cur;

        }


        //2
        public ListNode Merge(ListNode l1, ListNode l2)
        {

            ListNode c1 = l1;
            ListNode c2 = l2;
            ListNode dummy = new ListNode();
            ListNode tail = dummy;
            while (c1 != null && c2 != null)
            {
                if (c1.val <= c2.val)
                {
                    tail.next = c1;
                    c1 = c1.next;
                }
                else
                {
                    tail.next = c2;
                    c2 = c2.next;
                }
                tail = tail.next;
            }
            if (c1 != null)
            {
                tail.next = c1;
            }
            else
            {
                tail.next = c2;
            }
            return dummy.next;
        }

        //3
        public void ReorderList(ListNode head)
        {
            ListNode fast = head;
            ListNode slow = head;
            ListNode prev = null;
            while (fast != null)   //found the mid value
            {
                fast = fast.next;
                prev = slow;
                slow = slow.next;
                if (fast != null)
                {
                    fast = fast.next;
                }
            }
            prev.next = null;  //break from mid point, here will be just before mid so use prev to break list into two
            slow = ReverseList(slow);  //reverse second half of list
            ListNode p1 = head;
            ListNode c1 = head;
            ListNode p2 = slow;
            ListNode c2 = slow;
            while (c1!=null)   //merge together sequntially
            {
                c1 = c1.next;
                p1.next = c2;
                p1 = c1;

                if (c2 != null)  //beacasue c2 will always have less nodes than c1  because mid for odd numbers (5)
                                 //will split list into 3-2 so c2 will become null earlier than c1
                {
                    c2 = c2.next;
                    p2.next = c1;
                    p2 = c2;
                }
            }
        }

        //4
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (head == null || head.next == null) return null;
            ListNode dummy = new ListNode();
            dummy.next = head;
            ListNode current = head;
            ListNode previous = dummy;
            while (n > 0)
            {
                current = current.next;
                n--;
            }

            while (current != null)
            {
                previous = previous.next;
                current = current.next;
            }
            previous.next = previous.next.next;
            return dummy.next;
        }

        //5
        public bool HasCycle(ListNode head)
        {
            if (head==null || head.next == null) return false;
            ListNode fast = head;
            ListNode slow = head;
            while (fast != null)
            {
              
                fast = fast.next;
                if (fast != null) fast = fast.next;
                if (slow == fast) return true;
                slow = slow.next;
            }
            return false;
        }

        //6
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists.Count() == 0) return null;
            
            ListNode dummy = new ListNode(int.MinValue);
            ListNode tail = dummy;
            while (lists.Count()>0)
            {
                if (lists[0] == null)
                {
                    var temp = lists.ToList();
                    temp.RemoveAt(0);
                    lists = temp.ToArray();
                }
                else
                {
                    ListNode minNode = lists[0];
                    var removeIn = 0;
                    for (var i = 1; i < lists.Count(); i++)
                    {
                        if (lists[i] == null)
                        {
                            var temp = lists.ToList();
                            temp.RemoveAt(i);
                            lists = temp.ToArray();
                            i--;
                        }
                        else if (minNode.val > lists[i].val)
                        {
                            removeIn = i;
                            minNode = lists[i];
                            continue;
                        }
                    }
                    tail.next = minNode;
                    tail = tail.next;
                    lists[removeIn] = lists[removeIn].next;
                }
            }

            return dummy.next;
        }

        //Optimized
        public ListNode OptMergeKLists(ListNode[] lists)  //no recursion is used read carefully and dont panic
        {
            if(lists.Count() == 0) return null;

            while(lists.Count() > 1)                            //here we check if our lists length is 1 or not is its is not 1 then we continue merging multile listnodes under lists
            { 
                var mergedLists = new List<ListNode>();         //temperory list for saving merged listnodes
                for(var i = 0; i < lists.Length; i = i + 2)    //iterate through entire lists of listnode
                {
                    var l1 = lists[i];             //take first list
                    var l2 = i+1<lists.Count() ? lists[i + 1] : null;   //take second list , but second might not be available so put condition
                     mergedLists.Add(Merge(l1, l2));   //merge the two list lists using Merge method and increment i+2 because we merging two list at time
                                                       //so 0 is l1 and 1 is l2 then so we need to interate for loop where  i=2 and so on
                }
                lists = mergedLists.ToArray();
            }
            return lists[0];
        }
    }
}
