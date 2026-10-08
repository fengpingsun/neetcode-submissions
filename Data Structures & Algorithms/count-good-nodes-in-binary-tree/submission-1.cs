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
        return DFS(root, root.val);

        int DFS(TreeNode node, int max)
        {
            int res = 0;
            if (node == null) return res;
            if (node.val >= max)
            {
                res++;
                max = node.val;
            }
            res += DFS(node.left, max);
            res += DFS(node.right, max);
            return res;
        }
    }
}
