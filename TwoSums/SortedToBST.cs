using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoSums
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

    public class SortedToBST {
        public TreeNode SortedArrayToBST()
        {
            TreeNode t = new TreeNode();
            int[] num = { -10, -3, 0, 5, 9 };
            t=AssignVal(num,0,num.Length-1);
            return t;
        }
        
        public TreeNode AssignVal(int[] nums, int left, int right)
        {
            if (left >right)
            {
                return null;
            }
                int mid = (left + right) / 2;
                TreeNode tree = new TreeNode();
                tree.val = nums[mid];
                tree.left = AssignVal(nums, left, mid - 1);
                tree.right = AssignVal(nums, mid + 1, right);
                return tree;
        }
    }

}
