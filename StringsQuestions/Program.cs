using System;

namespace StringsQuestions
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] a = { "apple", "apple", "app" };
            string o = "GAGAGAGAGAGA";
            string p = "2-3*4+5";
            int n = 976;
            string[] words = { "hyeoo", "hyeo", "hye" };
            TreeNode t = new TreeNode() { val = 1, left = new TreeNode { val = 2, right = new TreeNode { val = 5 } }, right = new TreeNode { val = 3} };
            DiffWayToAddParenth__241_.DiffWaysToCompute(p);
            
        }
    }
}
