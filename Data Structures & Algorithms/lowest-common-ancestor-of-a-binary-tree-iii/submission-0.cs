/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node parent;
}
*/

public class Solution {
    public Node LowestCommonAncestor(Node p, Node q) {
        HashSet<Node> ancestors = new HashSet<Node>();
        while (p != null)
        {
            ancestors.Add(p);
            p = p.parent;
        }
        while (!ancestors.Contains(q))
        {
            q = q.parent;
        }
        return q;
    }
}