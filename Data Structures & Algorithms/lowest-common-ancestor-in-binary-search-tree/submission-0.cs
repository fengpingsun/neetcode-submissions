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
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        TreeNode res = null;
        DFS(root);
        return res;

        void DFS(TreeNode node)
        {
            if (res != null || node == null) return;
            if (node.val > p.val && node.val > q.val) DFS(node.left);
            else if (node.val < p.val && node.val < q.val) DFS(node.right);
            else res = node;
        }
    }
}
