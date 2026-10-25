public class Solution {
    public int[] FindRedundantConnection(int[][] edges) {
        int n = edges.Length;
        int[] rank = new int[n + 1]; // Nodes are labeled from 1 to n, not 0 to n - 1
        int[] par = new int[n + 1];
        for (int i = 0; i < rank.Length; i++)
        {
            rank[i] = 0;
            par[i] = i;
        }
        foreach (int[] edge in edges)
        {
            if (!Union(edge)) return edge;
        }
        return [];

        bool Union(int[] edge)
        {
            int parent1 = Find(edge[0]);
            int parent2 = Find(edge[1]);
            if (parent1 == parent2) return false;

            int rank1 = rank[parent1];
            int rank2 = rank[parent2];
            if (rank1 >= rank2)
            {
                par[parent2] = parent1;
                rank[parent1] += rank[parent2];
            }
            else
            {
                par[parent1] = parent2;
                rank[parent2] += rank[parent1];
            }
            return true;
        }

        int Find(int node)
        {
            if (node != par[node])
                return Find(par[node]);
            return node;
        }
    }
}
