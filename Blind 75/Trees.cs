using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blind_75
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    public class Trees
    {
        //1
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null) return null;
            if (root.left == null && root.right==null)
            {
                return root;
            }
            TreeNode left = InvertTree(root.left);
            TreeNode right = InvertTree(root.right);
            (left, right) = (right, left);
            root.right = right;
            root.left = left;
            return root;
        }

        //optimized
        public TreeNode OptInvertTree(TreeNode root)
        {

            if (root == null) return root;

            TreeNode left = OptInvertTree(root.left);
            TreeNode right = OptInvertTree(root.right);
            root.left = right;
            root.right = left;
            return root;
        }

        //2
        public int MaxDept(TreeNode root)
        {
            if (root == null) return 0;
            return (1 + Math.Max(MaxDept(root.left), MaxDept(root.right)));
        }

        //iterative solution
        public int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;

            int depth = 0;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                depth++;
                int n = queue.Count;
                for (int i = 0; i < n; i++)
                {
                    TreeNode node = queue.Dequeue();
                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }
            }


            return depth;
        }


        //3
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true;       //when both noth are null means theya re same
            if ((p!=null && q==null) || (p==null&& q!=null) || p.val != q.val) return false;  //when one node is null while other is not or both node values are not same return false
            if (!IsSameTree(p.left, q.left)) return false;    //if this return false then it will run and return false further else it will not run
            else if (!IsSameTree(p.right, q.right)) return false;  //if IsSAme for right returns false it will return false further else it will not run 
            return true;  //if we passed from both left and right is same means they are both same so return true

        }

        //optimized
        public bool OptIsSameTree(TreeNode p, TreeNode q)
        {

            //base cases
            if (p == null && q == null)
                return true;

            if ((p == null || q == null) || (p.val != q.val))
                return false;

            return (OptIsSameTree(p.left, q.left) && OptIsSameTree(p.right, q.right));

        }

        //4
        public bool IsSubTree(TreeNode root, TreeNode subroot)
        {
            if (root == null) return false;
            if (IsSameTree(root, subroot)) return true;
            return (IsSubTree(root.left, subroot) || IsSubTree(root.right, subroot));
        }


        //5
        public TreeNode LCA(TreeNode root, TreeNode p, TreeNode q)
        {
            while (root != null)
            {
                
                if(p.val>root.val && q.val > root.val)
                {
                    root = root.right;
                }
                else if(p.val<root.val && q.val < root.val)
                {
                    root = root.left;
                }
                else
                {
                    return root;
                }
            }
            return root;

        }


        //recursion
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {

            if ((p.val >= root.val && q.val <= root.val) || (p.val <= root.val && q.val >= root.val)) return root;

            if (p.val < root.val)
                return LowestCommonAncestor(root.left, p, q);
            return LowestCommonAncestor(root.right, p, q);

        }


        //6
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            if (root == null) return new List<IList<int>>();
            IList<IList<int>> ans = new List<IList<int>>();
            IList<int> a = null;
            TreeNode node = null;
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count != 0)
            {
                a= new List<int>();
                var qLength = q.Count;
                for(var i=0;i<qLength;i++)
                {
                    node=q.Dequeue();
                    a.Add(node.val);

                    if (node.left!= null)
                    {
                        q.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        q.Enqueue(node.right);
                    }
                }
                ans.Add(a);
            }

            return ans;

        }

        //recursion
        IList<IList<int>> valsByDepth = new List<IList<int>>();
        public IList<IList<int>> OptLevelOrder(TreeNode root)
        {
            PreorderTraversal(root, 0);

            return valsByDepth;
        }

        public void PreorderTraversal(TreeNode root, int depth)
        {
            if (root == null)
            {
                return;
            }

            if (valsByDepth.Count <= depth)
            {
                valsByDepth.Add(new List<int> { root.val });
            }
            else
            {
                valsByDepth[depth].Add(root.val);
            }

            PreorderTraversal(root.left, depth + 1);
            PreorderTraversal(root.right, depth + 1);
        }

        //7
        public bool IsValidBST(TreeNode root)    //logic works with long varibale type only edge cases are int.MinValue and int.MaxValue
        {
            return HelperBst(root, long.MinValue, long.MaxValue);

        }
        public bool HelperBst(TreeNode root, long left, long right)  //we pass root with left and right range
        {
            if (root == null) return true;
            if (!(root.val > left && root.val < right))  //w
            {
                return false;
            }
            return (HelperBst(root.left, left, root.val) && HelperBst(root.right, root.val, right));
        }

        //optimized (same logic as above bust BFS is used)
        public bool OptIsValidBST(TreeNode root)
        {
            if (root == null) return true;
            var queue = new Queue<(TreeNode, long, long)>();
            queue.Enqueue((root, long.MinValue, long.MaxValue));
            while (queue.Count != 0)
            {
                var el = queue.Dequeue();
                var min = el.Item2; var max = el.Item3;
                root = el.Item1;
                if (min >= root.val || root.val >= max) return false;
                if (root.left != null) queue.Enqueue((root.left, min, root.val));
                if (root.right != null) queue.Enqueue((root.right, root.val, max));
            }
            return true;
        }

        //8         Didnt solved this follow up yet so solve it->        //(What if the BST is modified (insert/delete operations) often and you need to find the kth smallest frequently?
                                                                         // How would you optimize the kthSmallest routine?)
        List<int> list;
        public int KthSmallest(TreeNode root, int k)
        {
            list = new List<int>(); //List to hold values in the increasing order
            InOrder(root);          //InOrder to get values in increasing order
            return list[k - 1];       //Get kth element as k starts from 1
        }

        private void InOrder(TreeNode root)
        {
            if (root != null)
            {
                InOrder(root.left);
                list.Add(root.val);
                InOrder(root.right);
            }
        }

        //iterative
        public int ItKthSmallest(TreeNode root,int k)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode cur = root;
            int n = 0;
            while(cur!=null && stack.Count > 0)
            {
                while (cur != null)
                {
                    stack.Push(cur);
                    cur = cur.left;
                }
                cur = stack.Pop();
                n += 1;
                if (n == k) return cur.val;
                cur = cur.right;
            }
            return -1;
        }


        //9
        private Dictionary<int, int> inMap = new Dictionary<int, int>();
        public TreeNode Helper(int[] preorder, ref int preIndex, int left, int right)
        {
            if (left > right || preIndex == preorder.Length)
            {
                return null;
            }
            TreeNode root = new TreeNode(preorder[preIndex]);
            int index = inMap[preorder[preIndex++]];
            root.left = Helper(preorder, ref preIndex, left, index - 1);
            root.right = Helper(preorder, ref preIndex, index + 1, right);
            return root;
        }
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            for (int i = 0; i < inorder.Length; i++)
            {
                inMap[inorder[i]] = i;
            }
            int preIndex = 0;
            return Helper(preorder, ref preIndex, 0, inorder.Length - 1);
        }

        //10
        public int maxPathSum(TreeNode root)
        {
            int[] res = { int.MinValue };
            maxPathSum(root, res);
            return res[0];
        }

        public int maxPathSum(TreeNode root, int[] res)
        {
            if (root == null)
                return 0;

            int left = maxPathSum(root.left, res);
            left = Math.Max(left, 0);
            int right =maxPathSum(root.right, res);
            right = Math.Max(right, 0);
            res[0] = Math.Max(res[0], root.val + left + right);

            return root.val + Math.Max(left, right);
        }

        //10   (Serailize and Desrailize is done using preorder traversal quite easy once you know what traversal to use)
        public string serialize(TreeNode root)
        {
            StringBuilder sb = new StringBuilder();
            TraversePreOrder(root, ref sb);
            return sb.ToString();
        }
        public void TraversePreOrder(TreeNode root,ref StringBuilder sb)
        {
            if (root == null) { sb.Append("null,"); return; }
            sb.Append($"{root.val},");
            TraversePreOrder(root.left, ref sb);
            TraversePreOrder(root.right, ref sb);
        }

        public TreeNode deserialize(string data)
        {
            var arr = data.Split(",");
            int idx = 0;
            return TraversePreOrderAndBuilt(arr, ref idx);
        }

        public TreeNode TraversePreOrderAndBuilt(string[] arr,ref int idx)
        {
            if (arr[idx] == "null")
            {
                idx++;
                return null;
            }
            TreeNode root = new TreeNode(int.Parse(arr[idx]));
            idx++;
            root.left = TraversePreOrderAndBuilt(arr, ref idx);
            root.right = TraversePreOrderAndBuilt(arr, ref idx);
            return root;
        }
    }
}

