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
    public int GoodNodes(TreeNode root) {
        int res = 0;
        DFS(root, -101, -101);
        return res;

        // min: the minimum value for the nodes from root to current
        void DFS(TreeNode node, int min, int max)
        {
            if (node == null) return;
            res += node.val >= max ? 1 : 0;
            min = Math.Min(node.val, min);
            max = Math.Max(node.val, max);
            DFS(node.left, min, max);
            DFS(node.right, min, max);
        }
    }
}
