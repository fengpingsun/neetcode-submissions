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
    public bool IsValidBST(TreeNode root) {
        return DFS(root, int.MinValue, int.MaxValue);

        bool DFS(TreeNode node, int min, int max)
        {
            return node.val > min && node.val < max
                && (node.left == null || DFS(node.left, min, node.val))
                && (node.right == null || DFS(node.right, node.val, max));
        }
    }
}
