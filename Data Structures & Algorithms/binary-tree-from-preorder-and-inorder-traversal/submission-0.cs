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
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        return BuildSubTree(0, 0, preorder.Length);

        TreeNode BuildSubTree(int preorderStart, int inorderStart, int subtreeLen)
        {
            if (subtreeLen == 0) return null;
            int rootNodeVal = preorder[preorderStart];
            TreeNode rootNode = new TreeNode(rootNodeVal);
            int rootNodeInorderPos = Array.IndexOf(inorder, rootNodeVal);
            int leftSubtreeLen = rootNodeInorderPos - inorderStart;
            int rightSubtreeLen = subtreeLen - leftSubtreeLen - 1;
            rootNode.left = BuildSubTree(preorderStart + 1, inorderStart, leftSubtreeLen);
            rootNode.right = BuildSubTree(preorderStart + leftSubtreeLen + 1, rootNodeInorderPos + 1, rightSubtreeLen);
            return rootNode;
        }
    }
}
