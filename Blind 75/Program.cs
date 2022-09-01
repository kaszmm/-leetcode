// See https://aka.ms/new-console-template for more information
using Blind_75;
//Console.WriteLine("Hello, World!");
//var str=ArraysAndHashing.EnDeString.Encode(new List<string> {"leet","code","kasim","naama"});
//ArraysAndHashing.EnDeString.Decode(str);
ListNode t = null;
ListNode t1 = new ListNode() { val = 2, next = new ListNode { val=3,next=new ListNode {val=4 } } };
ListNode t2 = new ListNode() { val = 1,next=new ListNode { val=3,next=new ListNode { val=5} } };
ListNode u = new ListNode() { val = 1, next = new ListNode { val = 2, next = new ListNode { val = 3 } } };
ListNode s = new ListNode();
LinkedList l = new LinkedList();

//ListNode[] lists = { t1,t2,u};
//l.OptMergeKLists(lists);

TreeNode tree = new TreeNode() { val = 3, left = new TreeNode { val = 9, left = new TreeNode { val = 15 }, right = new TreeNode { val = 7 } }, right = new TreeNode { val = 20, left = new TreeNode { val = 21}, right = new TreeNode { val = 22 } } };
TreeNode p = new TreeNode() { val = 0 };
TreeNode q = new TreeNode() { val = 1,left=new TreeNode() {val=2,left=new TreeNode() { val=3,left=new TreeNode() { val=4,left=new TreeNode() { val=5} } } } };
TreeNode bst1 = new TreeNode() { val = 5, left = new TreeNode { val = 1 }, right = new TreeNode { val = 4,left=new TreeNode { val=3},right=new TreeNode { val=6} } };

TreeNode bst2 = new TreeNode() { val = 5, left = new TreeNode { val = 4, left = new TreeNode { val = 2, right = new TreeNode { val=3} } }, right = new TreeNode { val = 10, left = new TreeNode { val = 7, right = new TreeNode { val = 8 } }, right = new TreeNode { val = 11, right = new TreeNode { val = 12 } } } };
TreeNode bst3 = new TreeNode() { val = 6, left = new TreeNode { val = 2, left = new TreeNode { val = 0 }, right = new TreeNode { val = 4, left = new TreeNode { val = 3 }, right = new TreeNode { val = 5 } } }, right = new TreeNode { val = 8, left = new TreeNode { val = 7 }, right = new TreeNode { val = 9 } } };


Trees trees = new Trees();
var ans=trees.IsValid(bst2);
var x = ans;