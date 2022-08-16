using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
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

    public class FlattenTreeIntoPreOrder__114_
    {
        private TreeNode prev = null;

        public void flatten(TreeNode root)
        {
            if (root == null)
                return;
            flatten(root.right);
            flatten(root.left);
            root.right = prev;
            root.left = null;
            prev = root;
        }
        public void Flatten(TreeNode root)
        {
            var stack = new Stack<TreeNode>();
            while (root != null)
            {
                if (root.right != null)
                    stack.Push(root.right);

                root.right = root.left;
                root.left = null;
                if (root.right == null && stack.Count > 0)
                    root.right = stack.Pop();
                root = root.right;
            }
        }
        public void FlattenIt(TreeNode root)
        {
            if (root == null)
                return;
            while (root != null)
            {
                if (root.left != null)
                {
                    TreeNode left = root.left;
                    TreeNode temp = left;
                    while (temp.right != null)
                    {
                        temp = temp.right;
                    }
                    temp.right = root.right;
                    root.left = null;
                    root.right = left;
                }
                root = root.right;
            }
        }

        public void FlattenByMe(TreeNode t)
        {
            if (t == null) return;
            while (t != null)
            {
                if (t.left != null)
                {
                    TreeNode left = t.left;
                    TreeNode n = left;
                    while (n.right != null)
                    {
                        n = n.right;
                    }
                    n.right = t.right;
                    t.left = null;
                    t.right = left;
                }
                t = t.right;
            }

        }


    }
}

