// See https://aka.ms/new-console-template for more information
using Blind_75;
using static Blind_75.PriorityQ;
using static Heap__Priority_Queue_.MaxNumberOfEventTOAttend__1353_;
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
TreeNode bst3 = new TreeNode() { val = 1, left = new TreeNode { val = 2, left = new TreeNode { val = 4 }, right = new TreeNode { val = 5 } }, right = new TreeNode { val = 3, left = new TreeNode { val = 8 }, right = new TreeNode { val = 9 } } };


//Trees trees = new Trees();
//var ans = trees.serialize(bst1);
//var ans2 = trees.deserialize(ans);
//var y = Stack.LongestNiceSubarray(new int[] { 744437702,379056602,145555074,392756761,560864007,934981918,113312475,1090,16384,33,217313281,117883195,978927664 });
//var x = ans;
char[][] jaggedArray = new char[][]
          {

                new char[] {'1','1','0','0','0' },
                new char[] {'1','1','0','0','0'},
                new char[] { '0','0','1','0','0' },
                new char[] { '0', '0', '0', '1', '1' }
          };
int[][] jaggedArrayInt = new int[][]
          {

                new int[] {0, 1},
                new int[] {1, 2},
                new int[] {2, 3},
                new int[] {1, 3},
                new int[] {1, 4},
          };
string[] words = new string[] { "wrt", "wrf", "er", "ett","eftt" };
//Tries tries = new Tries();
//// //tries.OptInsert("kasim");
//// tries.AddWord("bat");
////tries.AddWord("pan");
////tries.AddWord("max");
////tries.AddWord("lad");

//tries.FindWords(jaggedArray,words);

//MinHeap heap = new MinHeap(10);
//heap.Enqueue(10);
//heap.Enqueue(6);
//heap.Enqueue(0);
//heap.Enqueue(5);
//heap.Dequeue();
//heap.Dequeue();
//heap.Dequeue();
//heap.Dequeue();
//heap.Dequeue();
//Backtracking_Pruning_ bt = new Backtracking_Pruning_();
//bt.Exist(jaggedArray, "ABCCED".ToLower());
//bt.PartitionString("abacaba");
TwoDDynamicProgramming dp_2D = new TwoDDynamicProgramming();
//Node n2=new Node() { val=2,neighbors=new List<Node>()};
//Node n3 = new Node() { val = 3, neighbors = new List<Node>() };
//Node n4 = new Node() { val = 4, neighbors = new List<Node>() };
//Node n = new Node()
//{
//    val = 1,
//    neighbors = new List<Node>()
//};
//var x1 = new Node() { val=1};
//var x2 = new Node() { val = 3 };
//n2.neighbors.Add(x1);
//n2.neighbors.Add(x2);

//var y1 = new Node() { val = 2 };
//var y2 = new Node() { val = 4 };
//n3.neighbors.Add(y1);
//n3.neighbors.Add(y2);

//var z1 = new Node() { val = 1 };
//var z2 = new Node() { val = 3 };
//n4.neighbors.Add(z1);
//n4.neighbors.Add(z2);

//var a1 = new Node() { val = 2 };
//var a2 = new Node() { val = 4 };
//n.neighbors.Add(n2);
//n.neighbors.Add(n4);

dp_2D.LongestCommonSubsequence("psnw", "vozsh");