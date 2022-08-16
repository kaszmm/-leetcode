using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public static class ConstructTreeFromInorderAndPostOrder__106_
    {
        static int index;
        static Dictionary<int, int> dict = new Dictionary<int, int>();
        public static TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            for(var i = 0; i < inorder.Length; i++)
            {
                dict.Add(inorder[i], i);
            }
            index = postorder.Length - 1;
            TreeNode t = Helper(inorder,postorder,0,index);
            return t;
        }
        public static TreeNode Helper(int[] inorder,int[] postorder,int start,int end)
        {
            if (start > end) return null;
            TreeNode root = new TreeNode(postorder[index]);
            index--;
            int curIndex = dict[root.val];
            root.right = Helper(inorder, postorder, curIndex + 1, end);
            root.left = Helper(inorder, postorder, start, curIndex - 1);
            return root;
        }  
    }

}
