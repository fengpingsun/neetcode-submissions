public class Solution {
    public bool ValidTree(int n, int[][] edges) {
        // Create adjacency list
        Dictionary<int, List<int>> adjList = new();
        for (int i = 0; i < n; i++) adjList[i] = new();
        foreach (int[] edge in edges)
        {
            adjList[edge[0]].Add(edge[1]);
            adjList[edge[1]].Add(edge[0]);
        }

        // Run DFS to detect cycle and check if all nodes are connected
        bool[] visited = new bool[n];
        return DFS(0, -1) == false && visited.All(x => x == true);

        bool DFS(int i, int parent) // Has cycle?
        {
            if (visited[i]) return true;

            visited[i] = true;
            foreach (int nei in adjList[i])
            {
                if (nei == parent) continue;
                if (DFS(nei, i)) return true;
            }
            return false;
        }
    }
}
