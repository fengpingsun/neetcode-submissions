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
    public List<List<int>> VerticalOrder(TreeNode root) {
        Dictionary<int, List<(int row, int val)>> cols = new Dictionary<int, List<(int row, int val)>>(); // key: column number, value: node values of a given column
        DFS(root, 0, 0);
        List<List<int>> res = new List<List<int>>();
        if (cols.Count == 0) return res;
        int minCol = cols.Keys.Min();
        int maxCol = cols.Keys.Max();
        for (int i = minCol; i <= maxCol; i++)
        {
            List<int> list = cols[i].OrderBy(x => x.row).Select(x => x.val).ToList();
            res.Add(list);
        }
        return res;

        // Pre-order traverse
        void DFS(TreeNode node, int row, int col)
        {
            if (node == null) return; // Base case

            // Add node to its column list
            if (!cols.ContainsKey(col))
                cols[col] = [ (row, node.val) ];
            else
                cols[col].Add((row, node.val));
            
            DFS(node.left, row + 1, col - 1);
            DFS(node.right, row + 1, col + 1);
        }
    }
}