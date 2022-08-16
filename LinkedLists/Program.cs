using System;

namespace LinkedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode t = new ListNode() { val = 1, next = new ListNode { val = 5, next = new ListNode { val = 4 ,next=new ListNode { val=7,next=new ListNode { val=1,next=new ListNode { val=2,next=new ListNode { val=6} } } } } }};
            ListNode p = new ListNode() { val = 1, next = new ListNode { val = 0, next = new ListNode { val = -9,next = new ListNode { val = 2, next = new ListNode { val = 3,next=new ListNode { val=5} } } } } };
            ListNode tl= new ListNode() { val = 1 ,next=new ListNode { val=-7,next= new ListNode { val=7,next=new ListNode { val=-4,next=new ListNode { val=19,next=new ListNode {val=6,next=new ListNode { val=-9,next=new ListNode {val=-5,next= new ListNode { val=-2,next=new ListNode { val=-5} } } } } } } } } };
            ListNode pm= new ListNode() { val = 5 ,next=new ListNode { val=5} };
            TreeNode tree = new TreeNode() { val = 1, left = new TreeNode { val = 2, left = new TreeNode { val = 3 }, right = new TreeNode { val = 4 } }, right = new TreeNode { val = 5, right = new TreeNode { val = 6 } } };
            Node n = new Node() {val=1,child=new Node { val=2,child=new Node { val=3}} };
            
            //MyHashMap myHashMap = new MyHashMap();
            //myHashMap.Put(1, 9);
            //myHashMap.Put(2, 8);
            //myHashMap.Put(1, 0);
            //myHashMap.Get(5);
            //myHashMap.Get(2);
            //myHashMap.Remove(2);
            //MergeTwoSortedLists__21_ m = new MergeTwoSortedLists__21_();
            //SortLinkList__148_ sortLinkList__148_ = new SortLinkList__148_();
            //ReOrderOddEvenList__328_.ReOrderIt(pm);
            //FlattenTreeIntoPreOrder__114_ order__114_ = new FlattenTreeIntoPreOrder__114_();
            // order__114_.FlattenIt(tree);
            //DeleteMiddleNode__2095_.DeleteMiddle(t);
            //SortedListToBST__109_ f = new SortedListToBST__109_();
            RemoveNthLastNode__19_.RemoveNthNode(p,4);
        }
    }
}
