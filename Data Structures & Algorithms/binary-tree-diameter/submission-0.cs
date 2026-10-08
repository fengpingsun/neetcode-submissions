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
    public int DiameterOfBinaryTree(TreeNode root) {
        int res = 0;
        DFS(root);
        return res;
        
        // Returns max depth of a node; also check if there is a bigger diameter coming out of the current node
        int DFS(TreeNode node)
        {
            if (node == null) return 0;
            int leftMaxDepth = 0, rightMaxDepth = 0;
            leftMaxDepth = DFS(node.left);
            rightMaxDepth = DFS(node.right);
            res = Math.Max(res, leftMaxDepth + rightMaxDepth);
            return 1 + Math.Max(leftMaxDepth, rightMaxDepth);
        }
    }
}
