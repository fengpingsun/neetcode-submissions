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
    public int MaxPathSum(TreeNode root) {
        int res = root.val;
        DFS(root);
        return res;

        int DFS(TreeNode node)
        {
            if (node == null) return 0;
            int leftSumMax = Math.Max(0, DFS(node.left));
            int rightSumMax = Math.Max(0, DFS(node.right));
            res = Math.Max(res, node.val + leftSumMax + rightSumMax);
            return Math.Max(node.val + leftSumMax, node.val + rightSumMax);
        }
    }
}
