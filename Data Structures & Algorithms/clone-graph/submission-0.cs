/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    public Node CloneGraph(Node node) {
        if (node == null) return null;
        Dictionary<Node, Node> cloned = new();
        return DFS(node);

        Node DFS(Node n)
        {
            if (cloned.ContainsKey(n)) return cloned[n];

            cloned[n] = new Node(n.val);
            foreach (var neighbor in n.neighbors)
            {
                cloned[n].neighbors.Add(DFS(neighbor));
            }
            return cloned[n];
        }
    }
}
