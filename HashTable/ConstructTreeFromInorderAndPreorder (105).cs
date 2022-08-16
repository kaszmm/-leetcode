using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
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
    public static class ConstructTreeFromInorderAndPreorder__105_
    {
       

        public static TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            if (preorder == null || preorder.Length == 0 || inorder == null || inorder.Length == 0)
                return null;

            return BuildTree(preorder, 0, preorder.Length - 1, inorder, 0, inorder.Length - 1);
        }

        private static TreeNode BuildTree(int[] preorder, int i, int j, int[] inorder, int k, int l)
        {
            if (i > j || k > l)
                return null;

            TreeNode node = new TreeNode(preorder[i]);

            if (i != j)
            {
                int m = k;

                for (; m < inorder.Length; m++)
                    if (inorder[m] == preorder[i])
                        break;

                node.left = BuildTree(preorder, i + 1, i + m - k, inorder, k, m - 1);
                node.right = BuildTree(preorder, i + 1 + m - k, j, inorder, m + 1, l);
            }

            return node;
        }
        public static TreeNode buildTree(int[] preorder, int[] inorder)
        {
            if (preorder.Length != inorder.Length) return null;
            return build(preorder, 0, preorder.Length - 1, inorder, 0, inorder.Length - 1);
        }

        public static TreeNode build(int[] preorder, int preLow, int preHigh, int[] inorder, int inLow, int inHigh)
        {
            if (preLow > preHigh || inLow > inHigh) return null;
            TreeNode root = new TreeNode(preorder[preLow]);

            int inorderRoot = inLow;
            for (int i = inLow; i <= inHigh; i++)
            {
                if (inorder[i] == root.val) { inorderRoot = i; break; }
            }

            int leftTreeLen = inorderRoot - inLow;
            root.left = build(preorder, preLow + 1, preLow + leftTreeLen, inorder, inLow, inorderRoot - 1);
            root.right = build(preorder, preLow + leftTreeLen + 1, preHigh, inorder, inorderRoot + 1, preHigh);
            return root;
        }
    }
}
