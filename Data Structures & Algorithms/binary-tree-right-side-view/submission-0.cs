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
    public List<int> RightSideView(TreeNode root) {
        List<int> res = new();
        Queue<TreeNode> queue = new();
        if (root != null) queue.Enqueue(root);
        while (queue.Count > 0)
        {
            int levelCount = queue.Count;
            TreeNode node = null;
            for (int i = 0; i < levelCount; i++)
            {
                node = queue.Dequeue();
                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }
            res.Add(node.val);
        }
        return res;
    }
}
