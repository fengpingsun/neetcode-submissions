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
        int[] visited = new int[n]; // 0-unvisited; 1-visiting; 2-visited
        int count = 0;
        for (int i = 0; i < n; i++)
        {
            if (visited[i] == 0)
            {
                count++;
                if (DFS(i)) return false;
            }
        }
        return count == 1;

        bool DFS(int i) // Has cycle?
        {
            if (visited[i] != 0) return visited[i] == 2;

            visited[i] = 1;
            foreach (int nei in adjList[i])
            {
                if (DFS(nei)) return true;
            }
            visited[i] = 2;
            return false;
        }
    }
}
