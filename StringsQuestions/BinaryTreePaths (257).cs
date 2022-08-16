using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoSums;

namespace StringsQuestions
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
	public static class BinaryTreePaths__257_
    {
		public static  string s = "";
		public static  IList<string> paths = new List<string>();

        public static IList<string> GetPaths(TreeNode root)
        {
			IList<string> result = new List<string>();
			BinaryTreePathsHelper(root);
			return result;

			void BinaryTreePathsHelper(TreeNode node, string path = "")
			{
				if (node == null)
					return;
				if (node.left == null && node.right == null)
					result.Add($"{path}{node.val}");
				else
				{
					BinaryTreePathsHelper(node.left, $"{path}{node.val}->");
					BinaryTreePathsHelper(node.right, $"{path}{node.val}->");
				}
			}
		}
        public static IList<string> BinaryTreePaths(TreeNode root)
        {
            if (root == default)
                return new List<string>();

            if (root.left == default && root.right == default)
                return new List<string>(new[] { $"{root.val}" });

            var left = BinaryTreePaths(root.left);
            var right = BinaryTreePaths(root.right);

            var paths = new List<string>();

            foreach (var path in left)
                paths.Add($"{root.val}->{path}");

            foreach (var path in right)
                paths.Add($"{root.val}->{path}");

            return paths;
        }
    }
}
