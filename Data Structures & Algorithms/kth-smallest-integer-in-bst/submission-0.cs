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
    public int KthSmallest(TreeNode root, int k) {
        int index = 0;
        int res = -1;
        InorderDfs(root);
        return res;

        void InorderDfs(TreeNode node)
        {
            if (node.left != null && res == -1) InorderDfs(node.left);

            index++;
            if (index == k)
            {
                res = node.val;
                return;
            }
            
            if (node.right != null && res == -1) InorderDfs(node.right);
        }
    }
}
