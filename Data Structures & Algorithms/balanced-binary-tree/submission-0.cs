/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

public class Solution {
    public bool IsBalanced(TreeNode root) {        
        return DFS(root).isBalanced;

        (bool isBalanced, int depth) DFS(TreeNode node)
        {
            if (node == null) return (true, 0);
            var left = DFS(node.left);
            var right = DFS(node.right);
            return (left.isBalanced && right.isBalanced && Math.Abs(left.depth - right.depth) <= 1, 1 + Math.Max(left.depth, right.depth));
        }
    }
}
